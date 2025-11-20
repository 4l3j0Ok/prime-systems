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
using GroupBox = System.Windows.Forms.GroupBox;
using ReaLTaiizor.Extension;

namespace PrimeSystems
{
    public partial class Main : MaterialForm
    {
        private readonly Dictionary<TabPage, List<Control>> originalTabContents = new();
        // Config de paginación
        private const int PAGE_SIZE = 3;
        private readonly Dictionary<TabPage, int> currentPages = new();
        private readonly Dictionary<TabPage, bool> isLoadingMore = new();
        private readonly Dictionary<TabPage, bool> hasMoreData = new();
        private readonly Dictionary<TabPage, MaterialButton> loadMoreButtons = new();
        private readonly Dictionary<TabPage, MaterialLabel> allLoadedLabels = new();
        // Config de tabs
        private readonly Dictionary<TabPage, ITabConfiguration> tabConfigurations = new();
        // Config de filtros
        private readonly Dictionary<TabPage, Filters> filtersControls = new();
        private readonly Dictionary<TabPage, string> currentSearchTerms = new();
        private readonly Dictionary<TabPage, bool> currentIncludeInactive = new();

        public Main()
        {
            if (Session.CurrentUser == null)
            {
                throw new InvalidOperationException("No se ha iniciado sesión.");
            }
            UIConfig.GetSkinManager().AddFormToManage(this);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SaveOriginalTabContents();
            InitializeTabConfigurations();
            ApplyRolePermissions();
            ReloadAllTabPages();
            InitializePagination(tpFinancialState, pFinancialStateTableItems);
            InitializePagination(tpActivityLog, pActivityLogTableItems);
            PositionFloatingButtonsInTabControl(tcMain);
            dtpDateFrom.ValueChanged += (s, e) =>
            {
                currentPages[tpFinancialState] = 0;
                hasMoreData[tpFinancialState] = true;
                RefreshFinancialState(append: false);
            };
            dtpDateTo.ValueChanged += (s, e) =>
            {
                currentPages[tpFinancialState] = 0;
                hasMoreData[tpFinancialState] = true;
                RefreshFinancialState(append: false);
            };
        }

        private AccessLevel GetTabPagePermission(TabPage tabPage)
        {
            var role = Session.CurrentUser?.Role;
            if (role == null)
                return AccessLevel.None;

            // Map tab pages to their permission properties
            if (tabPage == tpSellsList || tabPage == tpSellsClients || tabPage == tpSells)
                return role.SellsPermission;
            else if (tabPage == tpPurchasesList || tabPage == tpSuppliers || tabPage == tpPurchases)
                return role.PurchasesPermission;
            else if (tabPage == tpArticles)
                return role.ArticlePermissions;
            else if (tabPage == tpActivityLog)
                return role.ActivityLogPermission;
            else if (tabPage == tpFinancialState)
                return role.FinancialStatePermission;
            else if (tabPage == tpUsersList || tabPage == tpUsersRoles || tabPage == tpUsers)
                return role.UserPermission;
            
            // Default: allow access to home and logout
            return AccessLevel.Write;
        }

        private void ApplyRolePermissions()
        {
            var role = Session.CurrentUser?.Role;
            if (role == null)
                return;

            // Process all main tabs
            ApplyPermissionsToTabControl(tcMain);
        }

        private void ApplyPermissionsToTabControl(MaterialTabControl tabControl)
        {
            var tabsToRemove = new List<TabPage>();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                var permission = GetTabPagePermission(tabPage);

                // Handle nested tab controls
                foreach (Control control in tabPage.Controls)
                {
                    if (control is MaterialTabControl nestedTabControl)
                    {
                        ApplyPermissionsToTabControl(nestedTabControl);
                    }
                }

                // If None permission, hide the tab
                if (permission == AccessLevel.None)
                {
                    tabsToRemove.Add(tabPage);
                }
                // If Read permission, make controls read-only but keep preview button enabled
                else if (permission == AccessLevel.Read)
                {
                    // Disable add buttons for read-only tabs
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control is MaterialFloatingActionButton fab)
                        {
                            fab.Visible = false;
                            fab.Enabled = false;
                        }
                    }
                }
            }

            // Remove tabs with None permission
            foreach (var tabPage in tabsToRemove)
            {
                tabControl.TabPages.Remove(tabPage);
            }
        }

        private void InitializeTabConfigurations()
        {
            tabConfigurations[tpUsersList] = new TabConfiguration<UserModel, int, User>(
                () => new UserController(),
                u => u.Title ?? u.Username,
                u => u.Description ?? $"{u.Name} {u.LastName}",
                u => GetUserProfilePicture(u),
                u => new User(u)
            );
            tabConfigurations[tpUsersRoles] = new TabConfiguration<RoleModel, string, Role>(
                () => new UserTypeController(),
                r => r.Title ?? r.Name ?? "",
                r => r.Description ?? r.Id,
                null,
                r => new Role(r)
            );
            tabConfigurations[tpSuppliers] = new TabConfiguration<SupplierModel, int, Supplier>(
                () => new SupplierController(),
                s => s.Title ?? s.Name ?? "Sin nombre",
                s => s.Description ?? $"CUIT: {s.Cuit?.ToString() ?? "N/A"}",
                null,
                s => new Supplier(s)
            );
            tabConfigurations[tpSellsClients] = new TabConfiguration<ClientModel, int, Client>(
                () => new ClientController(),
                c => c.Title ?? c.Name ?? "Sin nombre",
                c => c.Description ?? $"CUIT: {c.Cuit?.ToString() ?? "N/A"} | Entidad: {c.Entity ?? "N/A"}",
                null,
                c => new Client(c)
            );
            tabConfigurations[tpArticles] = new TabConfiguration<ArticleModel, int, Article>(
                () => new ArticleController(),
                a => a.Title ?? a.Name ?? "Sin nombre",
                a => a.Description ?? $"Código: {a.Code} | Categoría: {a.Category?.Name ?? "N/A"}",
                a => Properties.Resources.article_placeholder,
                a => new Article(a)
            );
            tabConfigurations[tpSellsList] = new TabConfiguration<SellModel, int, Sell>(
                () => new SellController(),
                s => s.Title ?? $"Venta #{s.Id}",
                s => s.Description ?? $"Cliente: {s.Client?.Name ?? "N/A"} | Fecha: {s.Date ?? "N/A"}",
                s => Properties.Resources.sell_placeholder,
                s => new Sell(s)
            );
            tabConfigurations[tpPurchasesList] = new TabConfiguration<PurchaseModel, int, Purchase>(
                () => new PurchaseController(),
                p => p.Title ?? $"Compra #{p.Id}",
                p => p.Description ?? $"Proveedor: {p.Supplier?.Name ?? "N/A"} | Total: ${p.Total ?? "0.00"} | Fecha: {p.Date ?? "N/A"}",
                p => Properties.Resources.purchase_placeholder,
                p => new Purchase(p)
            );
        }

        private void InitializePagination(TabPage tabPage, Panel? targetPanel = null)
        {
            currentPages[tabPage] = 0;
            isLoadingMore[tabPage] = false;
            hasMoreData[tabPage] = true;

            var container = targetPanel ?? tabPage;

            if (!loadMoreButtons.ContainsKey(tabPage))
            {
                var btnLoadMore = new MaterialButton
                {
                    Name = "btnLoadMore",
                    Text = "Cargar Más",
                    Dock = DockStyle.Top,
                    Height = 30,
                    Type = MaterialButton.MaterialButtonType.Text,
                    Visible = false,
                };
                btnLoadMore.Click += (s, e) => LoadMoreCards(tabPage);
                loadMoreButtons[tabPage] = btnLoadMore;
            }

            if (!allLoadedLabels.ContainsKey(tabPage))
            {
                var lblAllLoaded = new MaterialLabel
                {
                    Name = "lblAllLoaded",
                    Text = "Todos los elementos cargados",
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Visible = false
                };
                allLoadedLabels[tabPage] = lblAllLoaded;
            }
        }

        private void LoadMoreCards(TabPage tabPage)
        {
            if (isLoadingMore.ContainsKey(tabPage) && isLoadingMore[tabPage])
                return;
            if (hasMoreData.ContainsKey(tabPage) && !hasMoreData[tabPage])
                return;
            isLoadingMore[tabPage] = true;
            try
            {
                if (currentPages.ContainsKey(tabPage))
                {
                    currentPages[tabPage]++;
                    if (tabPage == tpFinancialState)
                        RefreshFinancialState(append: true);
                    else if (tabPage == tpActivityLog)
                        RefreshActivityLog(append: true);
                    else
                        ReloadTabPage(tabPage, append: true);
                }
            }
            finally
            {
                isLoadingMore[tabPage] = false;
            }
        }

        private Bitmap? GetUserProfilePicture(UserModel user)
        {
            if (user.ProfilePicture?.Length > 0)
            {
                var image = Utils.ByteArrayToImage(user.ProfilePicture);
                return image is Bitmap bitmap ? bitmap : new Bitmap(image);
            }
            return null;
        }

        private void ReloadTabPage(TabPage tabPage, bool append = false)
        {
            if (!tabConfigurations.TryGetValue(tabPage, out var config))
                return;

            if (!append)
            {
                currentPages[tabPage] = 0;
                hasMoreData[tabPage] = true;
            }

            config.LoadCards(this, tabPage, append);

            if (!append)
            {
                PositionFloatingButtonsInTabControl(tcMain);
            }
        }
        private void ReloadAllTabPages()
        {
            foreach (var tabPage in tabConfigurations.Keys)
            {
                // Only reload if tab is still visible (not removed by permissions)
                if (tcMain.TabPages.Contains(tabPage) || IsTabInNestedControl(tabPage))
                {
                    InitializePagination(tabPage);
                    ReloadTabPage(tabPage);
                }
            }
        }

        private bool IsTabInNestedControl(TabPage tabPage)
        {
            foreach (TabPage mainTab in tcMain.TabPages)
            {
                foreach (Control control in mainTab.Controls)
                {
                    if (control is MaterialTabControl nestedTabControl)
                    {
                        if (nestedTabControl.TabPages.Contains(tabPage))
                            return true;
                    }
                }
            }
            return false;
        }

        private void UpdateLoadMoreUI(TabPage tabPage, bool hasMore, Panel? targetPanel = null)
        {
            hasMoreData[tabPage] = hasMore;
            var container = targetPanel ?? tabPage;

            if (loadMoreButtons.ContainsKey(tabPage))
            {
                var btn = loadMoreButtons[tabPage];
                if (container.Controls.Contains(btn))
                    container.Controls.Remove(btn);
            }

            if (allLoadedLabels.ContainsKey(tabPage))
            {
                var lbl = allLoadedLabels[tabPage];
                if (container.Controls.Contains(lbl))
                    container.Controls.Remove(lbl);
            }

            if (hasMore && loadMoreButtons.ContainsKey(tabPage))
            {
                var btn = loadMoreButtons[tabPage];
                btn.Visible = true;
                container.Controls.Add(btn);
                container.Controls.SetChildIndex(btn, 0);
            }
            else if (!hasMore && allLoadedLabels.ContainsKey(tabPage))
            {
                var lbl = allLoadedLabels[tabPage];
                lbl.Visible = true;
                container.Controls.Add(lbl);
                container.Controls.SetChildIndex(lbl, 0);
            }
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
            TabPage tabPage
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

                    LogDeleteActivity(entity, tabPage);
                    ReloadTabPage(tabPage);
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

        public void LoadCardsOnTabPagePaged<T, TId>(
            TabPage tabPage,
            Func<IGenericController<T, TId>> controllerFactory,
            Func<T, Card> cardFactory,
            bool append = false
        )
        {
            try
            {
                var controller = controllerFactory();
                int pageNumber = currentPages.ContainsKey(tabPage) ? currentPages[tabPage] : 0;
                string searchTerm = currentSearchTerms.ContainsKey(tabPage) ? currentSearchTerms[tabPage] : string.Empty;
                bool includeInactive = currentIncludeInactive.ContainsKey(tabPage) ? currentIncludeInactive[tabPage] : false;
                List<T> items;
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    items = controller.Search(searchTerm, includeInactive, pageNumber, PAGE_SIZE);
                }
                else
                {
                    items = controller.GetAll(includeInactive, pageNumber, PAGE_SIZE);
                }

                bool hasMore = items.Count >= PAGE_SIZE;

                tabPage.SuspendLayout();

                var floats = tabPage.Controls.OfType<MaterialFloatingActionButton>().ToList();
                Filters? existingFilter = null;
                if (!append)
                {
                    existingFilter = tabPage.Controls.OfType<Filters>().FirstOrDefault();
                    if (existingFilter != null)
                    {
                        tabPage.Controls.Remove(existingFilter);
                    }
                }

                if (!append)
                {
                    foreach (var card in tabPage.Controls.OfType<Card>())
                        card.pbPicture.Image?.Dispose();
                    var controlsToRemove = tabPage.Controls.Cast<Control>()
                        .Where(c => !(c is MaterialFloatingActionButton))
                        .ToList();

                    foreach (var control in controlsToRemove)
                    {
                        tabPage.Controls.Remove(control);
                    }

                    floats.ForEach(f => tabPage.Controls.Add(f));
                }
                else
                {
                    var emptyLabel = tabPage.Controls.Find("lblEmpty", false).FirstOrDefault();
                    if (emptyLabel != null)
                        tabPage.Controls.Remove(emptyLabel);
                }

                var cardsToAdd = new List<Control>();
                if (items.Count == 0 && !append)
                {
                    cardsToAdd.Add(new MaterialLabel
                    {
                        Name = "lblEmpty",
                        Text = "No hay elementos para mostrar.",
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    });
                }
                else
                {
                    // Get permission for this tab
                    var permission = GetTabPagePermission(tabPage);
                    bool isReadOnly = permission == AccessLevel.Read;

                    foreach (var item in items)
                    {
                        var card = cardFactory(item);
                        card.Dock = DockStyle.Top;
                        
                        // Apply read-only restrictions to cards
                        if (isReadOnly)
                        {
                            card.SetReadOnlyMode();
                        }
                        
                        cardsToAdd.Add(card);

                        var spacer = new Panel { Height = 5, Dock = DockStyle.Top };
                        cardsToAdd.Add(spacer);
                    }
                }

                if (!append)
                {
                    Filters filters;
                    if (existingFilter != null)
                    {
                        filters = existingFilter;
                    }
                    else
                    {
                        filters = new Filters { Dock = DockStyle.Top };
                        filters.Initialize<T, TId>(
                            tabPage,
                            controllerFactory,
                            () => ApplyFilters(tabPage)
                        );
                        filtersControls[tabPage] = filters;
                    }

                    var headerSpacer = new Panel { Height = 8, Dock = DockStyle.Top };
                    var header = new CardHeader { Dock = DockStyle.Top };
                    cardsToAdd.Add(header);
                    cardsToAdd.Add(headerSpacer);
                    cardsToAdd.Add(filters);
                }
                for (int i = cardsToAdd.Count - 1; i >= 0; i--)
                {
                    tabPage.Controls.Add(cardsToAdd[i]);
                    tabPage.Controls.SetChildIndex(cardsToAdd[i], 0);
                }

                UpdateLoadMoreUI(tabPage, hasMore);

                floats.ForEach(f => f.BringToFront());
                tabPage.ResumeLayout();
                tabPage.AutoScroll = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadCardsOnTabPagePaged: Error - {ex.Message}");
                MessageBox.Show($"Error al cargar elementos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters(TabPage tabPage)
        {
            if (!filtersControls.ContainsKey(tabPage))
                return;

            var filters = filtersControls[tabPage];
            currentSearchTerms[tabPage] = filters.tbSearchParam.Text.Trim();
            currentIncludeInactive[tabPage] = filters.chbShowInactive.Checked;
            currentPages[tabPage] = 0;
            hasMoreData[tabPage] = true;
            ReloadTabPage(tabPage, append: false);
        }

        private void ShowControlInTabPage(TabPage tabPage, Control control, bool readOnly = false)
        {
            Debug.WriteLine($"ShowControlInTabPage: Showing control {control.GetType().Name} in tab {tabPage.Name}");
            if (!originalTabContents.ContainsKey(tabPage))
                originalTabContents[tabPage] = tabPage.Controls.Cast<Control>().ToList();

            tabPage.Controls.Clear();
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            if (readOnly)
            {
                SetControlsReadOnly(control);
            }
        }

        private void SetControlsReadOnly(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                // Tipos de controles contenedores que no deben deshabilitarse para mantener el scroll
                bool isContainer = control is Panel
                    || control is TableLayoutPanel
                    || control is FlowLayoutPanel
                    || control is GroupBox
                    || control is MaterialTabControl
                    || control is TabPage
                    || control is SplitContainer;

                if (isContainer)
                {
                    // Recursivamente procesar los controles hijos del contenedor
                    if (control.HasChildren)
                    {
                        SetControlsReadOnly(control);
                    }
                }
                else
                {
                    // Deshabilitar controles interactivos
                    control.Enabled = false;
                }
            }
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
            ReloadTabPage(tabPage);
            PositionFloatingButtonsInTabControl(tcMain);
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
            ShowControlInTabPage(tpArticles, new Article());

        private void tpFinancialState_Paint(object sender, PaintEventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime oneMonthAgo = today.AddMonths(-1);

            if (dtpDateFrom.Value.Date == DateTime.Today.Date && dtpDateTo.Value.Date == DateTime.Today.Date)
            {
                dtpDateFrom.Value = oneMonthAgo;
                dtpDateTo.Value = today;
            }

            currentPages[tpFinancialState] = 0;
            hasMoreData[tpFinancialState] = true;
            RefreshFinancialState(append: false);

            // Apply read-only restrictions
            var permission = GetTabPagePermission(tpFinancialState);
            if (permission == AccessLevel.Read)
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
            }
        }

        private void RefreshFinancialState(bool append = false)
        {
            ActivityRecordController activityController = new ActivityRecordController();
            List<string> activityRecordModules = new List<string> { ActivityModules.Sells, ActivityModules.Purchases };
            DateTime dateFrom = dtpDateFrom.Value.Date;
            DateTime dateTo = dtpDateTo.Value.Date;

            if (!append)
            {
                currentPages[tpFinancialState] = 0;
                hasMoreData[tpFinancialState] = true;
            }

            int pageNumber = currentPages.ContainsKey(tpFinancialState) ? currentPages[tpFinancialState] : 0;
            List<ActivityRecordModel> activityRecords = activityController.GetRecordByModulesAndDateRangePaged(
                activityRecordModules,
                dateFrom,
                dateTo,
                pageNumber,
                PAGE_SIZE
            );

            bool hasMore = activityRecords.Count >= PAGE_SIZE;

            if (!append)
            {
                pFinancialStateTableItems.SuspendLayout();
                var itemsToRemove = pFinancialStateTableItems.Controls
                    .OfType<FinancialStateTableItem>()
                    .ToList();
                foreach (var item in itemsToRemove)
                    pFinancialStateTableItems.Controls.Remove(item);

                pFinancialStateTableItems.ResumeLayout();
            }
            var allRecordsForTotals = activityController.GetRecordByModulesAndDateRange(
                activityRecordModules,
                dateFrom,
                dateTo
            );

            int totalSells = 0;
            int totalPurchases = 0;
            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var record in allRecordsForTotals)
            {
                if (record.Module == ActivityModules.Sells && record.Sell != null)
                {
                    totalSells++;
                    if (decimal.TryParse(record.Sell.Total, out decimal sellAmount))
                    {
                        totalRevenue += sellAmount;
                    }
                }
                else if (record.Module == ActivityModules.Purchases && record.Purchase != null)
                {
                    totalPurchases++;
                    if (decimal.TryParse(record.Purchase.Total, out decimal purchaseAmount))
                    {
                        totalExpenses += purchaseAmount;
                    }
                }
            }

            var itemsToAdd = new List<FinancialStateTableItem>();
            // Get permission for this tab
            var financialPermission = GetTabPagePermission(tpFinancialState);
            bool isFinancialReadOnly = financialPermission == AccessLevel.Read;

            foreach (var record in activityRecords)
            {
                FinancialStateTableItem item = new FinancialStateTableItem();
                item.Date = record.Date?.ToString("g") ?? "N/A";
                item.UserName = record.User != null ? $"{record.User.Username}" : "N/A";
                item.Module = record.Module ?? "N/A";

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
                
                // Only allow clicks if not read-only
                if (!isFinancialReadOnly)
                {
                    item.lblUserUsername.Click += (s, e) =>
                    {
                        if (record.User != null)
                            ShowControlInTabPage(tpFinancialState, new User(record.User, tpFinancialState), true);
                    };
                    item.lblShowDetails.Click += (s, e) =>
                    {
                        if (record.Module == ActivityModules.Sells && record.Sell != null)
                            ShowControlInTabPage(tpFinancialState, new Sell(record.Sell, tpFinancialState), true);
                        else if (record.Module == ActivityModules.Purchases && record.Purchase != null)
                            ShowControlInTabPage(tpFinancialState, new Purchase(record.Purchase, tpFinancialState), true);
                    };
                }
                else
                {
                    // Make labels non-clickable in read-only mode
                    item.lblUserUsername.Cursor = Cursors.Default;
                    item.lblShowDetails.Cursor = Cursors.Default;
                }
                
                itemsToAdd.Add(item);
            }

            pFinancialStateTableItems.SuspendLayout();
            foreach (var item in itemsToAdd)
            {
                pFinancialStateTableItems.Controls.Add(item);
                pFinancialStateTableItems.Controls.SetChildIndex(item, 0);
            }
            UpdateLoadMoreUI(tpFinancialState, hasMore, pFinancialStateTableItems);

            pFinancialStateTableItems.ResumeLayout();

            fscTotalRevenue.Value = totalRevenue.ToString("C2");
            fscTotalExpenses.Value = totalExpenses.ToString("C2");
            fscTotalSells.Value = totalSells.ToString();
            fscTotalPurchases.Value = totalPurchases.ToString();
        }

        private void tpActivityLog_Paint(object sender, PaintEventArgs e)
        {
            currentPages[tpActivityLog] = 0;
            hasMoreData[tpActivityLog] = true;
            RefreshActivityLog(append: false);
        }

        private void RefreshActivityLog(bool append = false)
        {
            ActivityRecordController activityController = new ActivityRecordController();

            if (!append)
            {
                currentPages[tpActivityLog] = 0;
                hasMoreData[tpActivityLog] = true;
            }

            int pageNumber = currentPages.ContainsKey(tpActivityLog) ? currentPages[tpActivityLog] : 0;
            List<ActivityRecordModel> activityRecords = activityController.GetAll(
                false,
                pageNumber,
                PAGE_SIZE
            );

            bool hasMore = activityRecords.Count >= PAGE_SIZE;

            if (!append)
            {
                pActivityLogTableItems.SuspendLayout();
                var itemsToRemove = pActivityLogTableItems.Controls
                    .OfType<ActivityLogTableItem>()
                    .ToList();
                foreach (var item in itemsToRemove)
                    pActivityLogTableItems.Controls.Remove(item);

                pActivityLogTableItems.ResumeLayout();
            }

            var itemsToAdd = new List<ActivityLogTableItem>();
            // Get permission for this tab
            var activityPermission = GetTabPagePermission(tpActivityLog);
            bool isActivityReadOnly = activityPermission == AccessLevel.Read;

            foreach (var record in activityRecords)
            {
                ActivityLogTableItem item = new ActivityLogTableItem();
                item.Date = record.Date?.ToString("g") ?? "N/A";
                item.UserName = record.User != null ? $"{record.User.Username}" : "N/A";
                item.Module = record.Module ?? "N/A";
                item.Action = record.Action ?? "N/A";
                item.Dock = DockStyle.Top;
                item.Margin = new Padding(0, 0, 0, 0);
                
                // Only allow clicks if not read-only
                if (!isActivityReadOnly)
                {
                    item.lblUserUsername.Click += (s, e) =>
                    {
                        if (record.User != null)
                            ShowControlInTabPage(tpActivityLog, new User(record.User, tpActivityLog), true);
                    };
                }
                else
                {
                    // Make label non-clickable in read-only mode
                    item.lblUserUsername.Cursor = Cursors.Default;
                }
                
                itemsToAdd.Add(item);
            }

            pActivityLogTableItems.SuspendLayout();
            for (int i = itemsToAdd.Count - 1; i >= 0; i--)
            {
                pActivityLogTableItems.Controls.Add(itemsToAdd[i]);
                pActivityLogTableItems.Controls.SetChildIndex(itemsToAdd[i], 0);
            }

            UpdateLoadMoreUI(tpActivityLog, hasMore, pActivityLogTableItems);

            pActivityLogTableItems.ResumeLayout();
        }

        private interface ITabConfiguration
        {
            void LoadCards(Main mainForm, TabPage tabPage, bool append);
        }

        private class TabConfiguration<T, TId, TForm> : ITabConfiguration where TForm : Control
        {
            private readonly Func<IGenericController<T, TId>> controllerFactory;
            private readonly Func<T, string> titleSelector;
            private readonly Func<T, string> descriptionSelector;
            private readonly Func<T, Bitmap?>? pictureSelector;
            private readonly Func<T, TForm> formFactory;

            public TabConfiguration(
                Func<IGenericController<T, TId>> controllerFactory,
                Func<T, string> titleSelector,
                Func<T, string> descriptionSelector,
                Func<T, Bitmap?>? pictureSelector,
                Func<T, TForm> formFactory)
            {
                this.controllerFactory = controllerFactory;
                this.titleSelector = titleSelector;
                this.descriptionSelector = descriptionSelector;
                this.pictureSelector = pictureSelector;
                this.formFactory = formFactory;
            }

            public void LoadCards(Main mainForm, TabPage tabPage, bool append)
            {
                mainForm.LoadCardsOnTabPagePaged(
                    tabPage,
                    controllerFactory,
                    entity => new Card(
                        title: titleSelector(entity),
                        description: descriptionSelector(entity),
                        picture: pictureSelector?.Invoke(entity),
                        previewCallBack: () => mainForm.ShowControlInTabPage(tabPage, formFactory(entity), true),
                        editCallback: () => mainForm.ShowControlInTabPage(tabPage, formFactory(entity)),
                        removeCallback: () => mainForm.RemoveEntity(
                            entity,
                            mainForm.GetEntityId(entity),
                            titleSelector(entity),
                            controllerFactory,
                            tabPage
                        )
                    ),
                    append
                );
            }
        }
    }
}
