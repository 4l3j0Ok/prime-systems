using PrimeSystems.Controllers;
using PrimeSystems.Views.Controls;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Forms.Add;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Diagnostics;
using Panel = System.Windows.Forms.Panel;
using TabPage = System.Windows.Forms.TabPage;

namespace PrimeSystems
{
    public partial class Main : MaterialForm
    {
        private readonly Dictionary<TabPage, List<Control>> originalTabContents = new();

        public Main()
        {
            UIConfig.GetSkinManager().AddFormToManage(this);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SaveOriginalTabContents();
            ReloadAllTabPages();
            PositionFloatingButtonsInTabControl(tcMain);
        }

        private void ReloadAllTabPages()
        {
            ReloadTabPage<UserModel, int, User>(
                tpUsersList,
                () => new UserController(),
                u => u.Username,
                u => $"{u.Name} {u.LastName}",
                u => GetUserProfilePicture(u),
                u => new User(u)
            );

            ReloadTabPage<RoleModel, string, Role>(
                tpUsersRoles,
                () => new UserTypeController(),
                r => r.Name ?? "",
                r => r.Id,
                null,
                r => new Role(r)
            );

            // Proveedores
            ReloadTabPage<SupplierModel, int, Supplier>(
                tpSuppliers,
                () => new SupplierController(),
                s => s.Name ?? "Sin nombre",
                s => $"CUIT: {s.Cuit?.ToString() ?? "N/A"}",
                null,
                s => new Supplier(s)
            );

            // Clientes
            ReloadTabPage<ClientModel, int, Client>(
                tpSellsClients,
                () => new ClientController(),
                c => c.Name ?? "Sin nombre",
                c => $"CUIT: {c.Cuit?.ToString() ?? "N/A"} | Entidad: {c.Entity ?? "N/A"}",
                null,
                c => new Client(c)
            );

            // Artículos
            ReloadTabPage<ArticleModel, int, Article>(
                tpSellsArticles,
                () => new ArticleController(),
                a => a.Name ?? "Sin nombre",
                a => $"Código: {a.Code} | Categoría: {a.Category?.Name ?? "N/A"}",
                null,
                a => new Article(a)
            );

            // Histórico de ventas
            ReloadTabPage<SellModel, int, Sell>(
                tpSellsList,
                () => new SellController(),
                s => $"Venta #{s.Id}",
                s => $"Cliente: {s.Client?.Name ?? "N/A"} | Fecha: {s.Date ?? "N/A"}",
                null,
                s => new Sell(s)
            );

            // Histórico de compras
            ReloadTabPage<PurchaseModel, int, Purchase>(
                tpPurchasesList,
                () => new PurchaseController(),
                p => $"Compra #{p.Id}",
                p => $"Proveedor: {p.Supplier?.Name ?? "N/A"} | Total: ${p.Total ?? "0.00"} | Fecha: {p.Date ?? "N/A"}",
                null,
                p => new Purchase(p)
            );
        }

        private Bitmap? GetUserProfilePicture(UserModel user)
        {
            if (user.ProfilePicture?.Length > 0)
            {
                var image = Utils.ByteArrayToImage(user.ProfilePicture);
                return image is Bitmap bitmap ? bitmap : new Bitmap(image);
            }
            return new Bitmap(Config.default_profile_picture);
        }

        private void ReloadTabPage<T, TId, TForm>(
            TabPage tabPage,
            Func<IGenericController<T, TId>> controllerFactory,
            Func<T, string> titleSelector,
            Func<T, string> descriptionSelector,
            Func<T, Bitmap?>? pictureSelector,
            Func<T, TForm> formFactory
        ) where TForm : Control
        {
            LoadCardsOnTabPage(
                tabPage,
                controllerFactory,
                entity => new Card(
                    title: titleSelector(entity),
                    description: descriptionSelector(entity),
                    picture: pictureSelector?.Invoke(entity),
                    editCallback: () => ShowControlInTabPage(tabPage, formFactory(entity)),
                    removeCallback: () =>
                        RemoveEntity(
                            entity,
                            GetEntityId(entity),
                            titleSelector(entity),
                            controllerFactory,
                            tabPage,
                            () => ReloadSingleTabPage(tabPage, controllerFactory, titleSelector, descriptionSelector, pictureSelector, formFactory)
                        )
                )
            );

            PositionFloatingButtonsInTabControl(tcMain);
        }

        private void ReloadSingleTabPage<T, TId, TForm>(
            TabPage tabPage,
            Func<IGenericController<T, TId>> controllerFactory,
            Func<T, string> titleSelector,
            Func<T, string> descriptionSelector,
            Func<T, Bitmap?>? pictureSelector,
            Func<T, TForm> formFactory
        ) where TForm : Control
        {
            LoadCardsOnTabPage(
                tabPage,
                controllerFactory,
                entity => new Card(
                    title: titleSelector(entity),
                    description: descriptionSelector(entity),
                    picture: pictureSelector?.Invoke(entity),
                    editCallback: () => ShowControlInTabPage(tabPage, formFactory(entity)),
                    removeCallback: () =>
                        RemoveEntity(
                            entity,
                            GetEntityId(entity),
                            titleSelector(entity),
                            controllerFactory,
                            tabPage,
                            () => ReloadSingleTabPage(tabPage, controllerFactory, titleSelector, descriptionSelector, pictureSelector, formFactory)
                        )
                )
            );

            PositionFloatingButtonsInTabControl(tcMain);
        }

        private object GetEntityId<T>(T entity)
        {
            var idProp = typeof(T).GetProperty("Id")
                ?? throw new InvalidOperationException($"Entity type {typeof(T).Name} does not have an Id property");
            return idProp.GetValue(entity) ?? throw new InvalidOperationException("Entity ID cannot be null");
        }

        private void RemoveEntity<T, TId>(
            T entity,
            object id,
            string displayName,
            Func<IGenericController<T, TId>> controllerFactory,
            TabPage tabPage,
            Action reloadAll
        )
        {
            if (MessageBox.Show(
                $"¿Está seguro que desea eliminar '{displayName}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) != DialogResult.Yes)
                return;

            try
            {
                var controller = controllerFactory();
                if (controller.Delete((TId)id))
                {
                    MessageBox.Show($"'{displayName}' eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Registrar actividad de eliminación
                    LogDeleteActivity(entity, tabPage);

                    reloadAll();
                }
                else
                {
                    MessageBox.Show($"Error al eliminar '{displayName}'.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar '{displayName}': {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogDeleteActivity<T>(T entity, TabPage tabPage)
        {
            try
            {
                // Determinar el módulo y los IDs según el tipo de entidad
                if (entity is ArticleModel article)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Articles,
                        articleId: article.Id
                    );
                }
                else if (entity is ClientModel client)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Clients,
                        clientId: client.Id
                    );
                }
                else if (entity is SupplierModel supplier)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Suppliers,
                        supplierId: supplier.Id
                    );
                }
                else if (entity is SellModel sell)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Sells,
                        sellId: sell.Id,
                        clientId: sell.ClientId
                    );
                }
                else if (entity is PurchaseModel purchase)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Purchases,
                        purchaseId: purchase.Id,
                        supplierId: purchase.SupplierId
                    );
                }
                else if (entity is UserModel user)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Users
                    );
                }
                else if (entity is RoleModel role)
                {
                    ActivityLogger.LogActivity(
                        ActivityActions.Delete,
                        ActivityModules.Roles
                    );
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al registrar actividad de eliminación: {ex.Message}");
            }
        }

        private void SaveOriginalTabContents()
        {
            foreach (TabPage tab in tcMain.TabPages)
            {
                SaveTabPageContents(tab);
            }
        }

        private void SaveTabPageContents(TabPage tabPage)
        {
            if (!originalTabContents.ContainsKey(tabPage))
            {
                originalTabContents[tabPage] = tabPage.Controls.Cast<Control>().ToList();
            }

            foreach (Control control in tabPage.Controls)
            {
                if (control is MaterialTabControl nestedTabControl)
                {
                    Debug.WriteLine($"SaveTabPageContents: Found nested TabControl in {tabPage.Name}");
                    foreach (TabPage nestedTab in nestedTabControl.TabPages)
                    {
                        SaveTabPageContents(nestedTab);
                    }
                }
            }
        }

        public void LoadCardsOnTabPage<T, TId>(
            TabPage tabPage,
            Func<IGenericController<T, TId>> controllerFactory,
            Func<T, Card> cardFactory
        )
        {
            try
            {
                var controller = controllerFactory();
                var items = controller.GetAll() ?? new List<T>();

                Debug.WriteLine($"LoadCardsOnTabPage: Found {items.Count} items for tab {tabPage.Name}");
                tabPage.SuspendLayout();

                var floats = tabPage.Controls.OfType<MaterialFloatingActionButton>().ToList();

                foreach (var card in tabPage.Controls.OfType<Card>())
                    card.pbPicture.Image?.Dispose();

                tabPage.Controls.Clear();
                floats.ForEach(f => tabPage.Controls.Add(f));

                if (items.Count == 0)
                {
                    tabPage.Controls.Add(new MaterialLabel
                    {
                        Name = "lblEmpty",
                        Text = "No hay elementos para mostrar.",
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    });
                    tabPage.ResumeLayout();
                    return;
                }

                foreach (var item in items)
                {
                    var card = cardFactory(item);
                    card.Dock = DockStyle.Top;
                    tabPage.Controls.Add(card);

                    var spacer = new Panel { Height = 5, Dock = DockStyle.Top };
                    tabPage.Controls.Add(spacer);
                }

                var headerSpacer = new Panel { Height = 8, Dock = DockStyle.Top };
                var header = new CardHeader { Dock = DockStyle.Top };
                tabPage.Controls.Add(header);
                tabPage.Controls.Add(headerSpacer);

                floats.ForEach(f => f.BringToFront());
                tabPage.ResumeLayout();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadCardsOnTabPage: Error - {ex.Message}");
                MessageBox.Show($"Error al cargar elementos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowControlInTabPage(TabPage tabPage, Control control)
        {
            Debug.WriteLine($"ShowControlInTabPage: Showing control {control.GetType().Name} in tab {tabPage.Name}");
            if (!originalTabContents.ContainsKey(tabPage))
                originalTabContents[tabPage] = tabPage.Controls.Cast<Control>().ToList();

            tabPage.Controls.Clear();
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
        }

        public void RestoreTabPage(TabPage tabPage)
        {
            Debug.WriteLine($"RestoreTabPage: Restoring tab {tabPage.Name}");

            tabPage.Controls.Clear();
            if (originalTabContents.ContainsKey(tabPage))
            {
                foreach (var control in originalTabContents[tabPage])
                    tabPage.Controls.Add(control);
            }
            ReloadSpecificTabPage(tabPage);
            PositionFloatingButtonsInTabControl(tcMain);
        }

        private void ReloadSpecificTabPage(TabPage tabPage)
        {
            if (tabPage == tpUsersList)
            {
                ReloadTabPage<UserModel, int, User>(
                    tpUsersList,
                    () => new UserController(),
                    u => u.Username,
                    u => $"{u.Name} {u.LastName}",
                    u => GetUserProfilePicture(u),
                    u => new User(u)
                );
            }
            else if (tabPage == tpUsersRoles)
            {
                ReloadTabPage<RoleModel, string, Role>(
                    tpUsersRoles,
                    () => new UserTypeController(),
                    r => r.Name ?? "",
                    r => r.Id,
                    null,
                    r => new Role(r)
                );
            }
            else if (tabPage == tpSuppliers)
            {
                ReloadTabPage<SupplierModel, int, Supplier>(
                    tpSuppliers,
                    () => new SupplierController(),
                    s => s.Name ?? "Sin nombre",
                    s => $"CUIT: {s.Cuit?.ToString() ?? "N/A"}",
                    null,
                    s => new Supplier(s)
                );
            }
            else if (tabPage == tpSellsClients)
            {
                ReloadTabPage<ClientModel, int, Client>(
                    tpSellsClients,
                    () => new ClientController(),
                    c => c.Name ?? "Sin nombre",
                    c => $"CUIT: {c.Cuit?.ToString() ?? "N/A"} | Entidad: {c.Entity ?? "N/A"}",
                    null,
                    c => new Client(c)
                );
            }
            else if (tabPage == tpSellsArticles)
            {
                ReloadTabPage<ArticleModel, int, Article>(
                    tpSellsArticles,
                    () => new ArticleController(),
                    a => a.Name ?? "Sin nombre",
                    a => $"Código: {a.Code} | Categoría: {a.Category?.Name ?? "N/A"}",
                    null,
                    a => new Article(a)
                );
            }
            else if (tabPage == tpSellsList)
            {
                ReloadTabPage<SellModel, int, Sell>(
                    tpSellsList,
                    () => new SellController(),
                    s => $"Venta #{s.Id}",
                    s => $"Cliente: {s.Client?.Name ?? "N/A"} | Fecha: {s.Date ?? "N/A"}",
                    null,
                    s => new Sell(s)
                );
            }
            else if (tabPage == tpPurchasesList)
            {
                ReloadTabPage<PurchaseModel, int, Purchase>(
                    tpPurchasesList,
                    () => new PurchaseController(),
                    p => $"Compra #{p.Id}",
                    p => $"Proveedor: {p.Supplier?.Name ?? "N/A"} | Total: ${p.Total ?? "0.00"} | Fecha: {p.Date ?? "N/A"}",
                    null,
                    p => new Purchase(p)
                );
            }
        }

        private void PositionFloatingButtonsInTabControl(MaterialTabControl tabControl)
        {
            const int MARGIN = 30;

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                    if (control is MaterialTabControl nested)
                        PositionFloatingButtonsInTabControl(nested);

                PositionFloatingButtonsInContainer(tabPage, MARGIN);
            }
        }

        private void PositionFloatingButtonsInContainer(Control container, int margin)
        {
            const int SPACING = 10;
            var floats = container.Controls.OfType<MaterialFloatingActionButton>().ToList();
            if (floats.Count == 0) return;

            int y = container.ClientSize.Height - margin;
            for (int i = floats.Count - 1; i >= 0; i--)
            {
                var btn = floats[i];
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btn.Location = new Point(
                    container.ClientSize.Width - btn.Width - margin,
                    y - btn.Height
                );
                btn.BringToFront();
                y -= btn.Height + SPACING;
            }
        }

        // Event Handlers
        private void tabCerrarSesion_Click(object sender, EventArgs e) => Application.Restart();

        private void btnAddUser_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpUsersList, new User());

        private void btnAddRole_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpUsersRoles, new Role());

        private void btnAddSell_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpSellsList, new Sell());

        private void btnAddPurchase_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpPurchasesList, new Purchase());

        private void btnAddSupplier_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpSuppliers, new Supplier());

        private void btnAddClient_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpSellsClients, new Client());

        private void btnAddArticle_Click(object sender, EventArgs e) =>
            ShowControlInTabPage(tpSellsArticles, new Article());

        private void tpFinancialState_Paint(object sender, PaintEventArgs e)
        {
            ActivityRecordController activityController = new ActivityRecordController();
            List<string> activityRecordModules = new List<string> { ActivityModules.Sells, ActivityModules.Purchases };
            List<ActivityRecordModel> activityRecords = activityController.GetRecordByModules(activityRecordModules);
            pFinancialStateTableItems.Controls.Clear();
            foreach (var record in activityRecords)
            {
                FinancialStateTableItem item = new FinancialStateTableItem();
                item.Date = record.Date?.ToString("g") ?? "N/A";
                item.UserName = record.User != null ? $"{record.User.Name} {record.User.LastName}" : "N/A";
                item.Module = record.Module ?? "N/A";

                // Obtener el monto directamente del modelo relacionado
                string amount = "N/A";
                if (record.Module == ActivityModules.Sells && record.Sell != null)
                {
                    amount = !string.IsNullOrWhiteSpace(record.Sell.Total) ? $"${record.Sell.Total}" : "N/A";
                }
                else if (record.Module == ActivityModules.Purchases && record.Purchase != null)
                {
                    amount = !string.IsNullOrWhiteSpace(record.Purchase.Total) ? $"${record.Purchase.Total}" : "N/A";
                }

                item.Amount = amount;
                item.Dock = DockStyle.Top;
                item.Margin = new Padding(0, 0, 0, 0);
                item.lblShowDetails.Click += (s, e) =>
                {
                    Debug.WriteLine($"FinancialStateTableItem: Show details clicked for module {record.Module}");
                    if (record.Module == ActivityModules.Sells && record.Sell != null)
                        ShowControlInTabPage(tpFinancialState, new Sell(record.Sell, tpFinancialState));
                    else if (record.Module == ActivityModules.Purchases && record.Purchase != null)
                        ShowControlInTabPage(tpFinancialState, new Purchase(record.Purchase, tpFinancialState));
                };
                pFinancialStateTableItems.Controls.Add(item);
            }
        }
    }
}
