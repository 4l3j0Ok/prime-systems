using PrimeSystems.Controllers;
using PrimeSystems.Views.Controls;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Forms.Add;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Diagnostics;
using Panel = System.Windows.Forms.Panel;

namespace PrimeSystems
{
    public partial class Main : MaterialForm
    {
        private readonly Dictionary<System.Windows.Forms.TabPage, List<Control>> originalTabContents = new Dictionary<System.Windows.Forms.TabPage, List<Control>>();

        public Main()
        {
            UIConfig.GetSkinManager().AddFormToManage(this);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReloadTabPage<UserModel, User>(
                tpUsersList,
                () => new UserController(),
                (user) => user.Username,
                (user) => $"{user.Name} {user.LastName}",
                (user) => GetUserProfilePicture(user),
                (user) => new User(user)
            );
            SaveOriginalTabContents();
            PositionFloatingButtonsInTabControl(tcMain);
        }


        private Bitmap? GetUserProfilePicture(UserModel user)
        {
            if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
            {
                var image = Utils.ByteArrayToImage(user.ProfilePicture);
                if (image is Bitmap bitmap)
                {
                    return bitmap;
                }
                else if (image != null)
                {
                    return new Bitmap(image);
                }
            }
            return new Bitmap(Config.default_profile_picture);
        }

        private void ReloadTabPage<T, TForm>(
            System.Windows.Forms.TabPage tabPage,
            Func<IGenericController<T>> controllerFactory,
            Func<T, string> titleSelector,
            Func<T, string> descriptionSelector,
            Func<T, Bitmap?>? pictureSelector,
            Func<T, TForm> formFactory
        ) where TForm : Control
        {
            LoadCardsOnTabPage<T>(
                tabPage,
                controllerFactory,
                (entity) => new Card(
                    title: titleSelector(entity),
                    description: descriptionSelector(entity),
                    picture: pictureSelector?.Invoke(entity),
                    editCallback: () => ShowControlInTabPage(tabPage, formFactory(entity)),
                    removeCallback: () => RemoveEntity<T>(
                        entity,
                        GetEntityId(entity),
                        titleSelector(entity),
                        controllerFactory,
                        tabPage,
                        () => ReloadTabPage<T, TForm>(tabPage, controllerFactory, titleSelector, descriptionSelector, pictureSelector, formFactory)
                    )
                )
            );
        }

        private object GetEntityId<T>(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                return idProperty.GetValue(entity) ?? throw new InvalidOperationException("Entity ID cannot be null");
            }
            throw new InvalidOperationException($"Entity type {typeof(T).Name} does not have an Id property");
        }

        private void RemoveEntity<T>(
            T entity,
            object entityId,
            string entityDisplayName,
            Func<IGenericController<T>> controllerFactory,
            System.Windows.Forms.TabPage tabPage,
            Action reloadCallback
        )
        {
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar '{entityDisplayName}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var controller = controllerFactory();
                    bool success = controller.Delete(entityId);

                    if (success)
                    {
                        MessageBox.Show($"'{entityDisplayName}' eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadCallback();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar '{entityDisplayName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar '{entityDisplayName}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveOriginalTabContents()
        {
            foreach (System.Windows.Forms.TabPage tabPage in tcMain.TabPages)
            {
                var controls = new List<Control>();
                foreach (Control control in tabPage.Controls)
                {
                    controls.Add(control);
                }
                originalTabContents[tabPage] = controls;
            }
        }

        public void LoadCardsOnTabPage<T>(
            System.Windows.Forms.TabPage tabPage,
            Func<IGenericController<T>> controllerFactory,
            Func<T, Card> cardFactory
        )
        {
            try
            {
                var controller = controllerFactory();
                List<T> items = controller.GetAll() ?? new List<T>();

                Debug.WriteLine($"LoadCardsOnTabPage: Found {items.Count} items for tab {tabPage.Name}");
                tabPage.SuspendLayout();

                // Preservar MaterialFloatingActionButton antes de limpiar
                var floatingButtons = new List<ReaLTaiizor.Controls.MaterialFloatingActionButton>();
                foreach (Control control in tabPage.Controls)
                {
                    if (control is ReaLTaiizor.Controls.MaterialFloatingActionButton btnFloat)
                    {
                        floatingButtons.Add(btnFloat);
                    }
                }

                foreach (Control existingControl in tabPage.Controls)
                {
                    if (existingControl is Card card && card.pbPicture.Image != null)
                    {
                        card.pbPicture.Image.Dispose(); // Para liberar recursos
                    }
                }

                // Limpiar todos los controles
                tabPage.Controls.Clear();

                // Restaurar los MaterialFloatingActionButton
                foreach (var btnFloat in floatingButtons)
                {
                    tabPage.Controls.Add(btnFloat);
                }

                // Manejar el estado vacío
                if (items.Count == 0)
                {
                    tabPage.Controls.Add(new MaterialLabel
                    {
                        Name = "lblEmpty",
                        Text = "No hay elementos para mostrar.",
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    });
                    return;
                }

                foreach (T item in items)
                {
                    Card card = cardFactory(item);
                    card.Dock = DockStyle.Top;
                    tabPage.Controls.Add(card);
                    // Espaciador porque el DockStyle.Top no respeta la propiedad de margen
                    Panel spacer = new Panel();
                    spacer.Height = 5;
                    spacer.Dock = DockStyle.Top;
                    tabPage.Controls.Add(spacer);
                }
                // Mismo espaciador para el header pero un poco más grande
                Panel headerSpacer = new Panel();
                headerSpacer.Height = 8;
                headerSpacer.Dock = DockStyle.Top;
                tabPage.Controls.Add(headerSpacer);
                // Header de las tarjetas
                CardHeader header = new CardHeader();
                header.Dock = DockStyle.Top;
                tabPage.Controls.Add(header);

                // Asegurar que los botones flotantes estén al frente después de agregar las cards
                foreach (var btnFloat in floatingButtons)
                {
                    btnFloat.BringToFront();
                }

                tabPage.ResumeLayout();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadCardsOnTabPage: Error - {ex.Message}");
                MessageBox.Show($"Error al cargar elementos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ShowControlInTabPage(tpUsersList, new User());
        }

        public void ShowControlInTabPage(System.Windows.Forms.TabPage tabPage, Control controlToShow)
        {
            if (!originalTabContents.ContainsKey(tabPage))
            {
                var controls = new List<Control>();
                foreach (Control control in tabPage.Controls)
                {
                    controls.Add(control);
                }
                originalTabContents[tabPage] = controls;
            }
            tabPage.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            tabPage.Controls.Add(controlToShow);
        }

        public void RestoreTabPage(System.Windows.Forms.TabPage tabPage)
        {
            if (originalTabContents.ContainsKey(tabPage))
            {
                // Primero restaurar los controles originales
                tabPage.Controls.Clear();
                foreach (Control control in originalTabContents[tabPage])
                {
                    tabPage.Controls.Add(control);
                }

                // Recargar las pestañas usando el método genérico
                ReloadTabPage<UserModel, User>(
                    tpUsersList,
                    () => new UserController(),
                    (user) => user.Username,
                    (user) => $"{user.Name} {user.LastName}",
                    (user) => GetUserProfilePicture(user),
                    (user) => new User(user)
                );

                ReloadTabPage<RoleModel, Role>(
                    tpUsersRoles,
                    () => new UserTypeController(),
                    (userType) => userType.Name ?? "",
                    (userType) => userType.Id,
                    null,
                    (userType) => new Role(userType)
                );
            }
        }

        private void PositionFloatingButtonsInTabControl(ReaLTaiizor.Controls.MaterialTabControl tabControl)
        {
            const int MARGIN = 30;

            foreach (System.Windows.Forms.TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is ReaLTaiizor.Controls.MaterialTabControl nestedTabControl)
                    {
                        PositionFloatingButtonsInTabControl(nestedTabControl);
                    }
                }
                PositionFloatingButtonsInContainer(tabPage, MARGIN);
            }
        }

        private void PositionFloatingButtonsInContainer(Control container, int margin)
        {
            const int BUTTON_SPACING = 10;

            var floatingButtons = new List<ReaLTaiizor.Controls.MaterialFloatingActionButton>();

            foreach (Control control in container.Controls)
            {
                if (control is ReaLTaiizor.Controls.MaterialFloatingActionButton btnFloat)
                {
                    floatingButtons.Add(btnFloat);
                }
            }

            if (floatingButtons.Count == 0)
                return;

            int currentY = container.ClientSize.Height - margin;
            for (int i = floatingButtons.Count - 1; i >= 0; i--)
            {
                var btnFloat = floatingButtons[i];
                btnFloat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnFloat.Location = new Point(
                    container.ClientSize.Width - btnFloat.Width - margin,
                    currentY - btnFloat.Height
                );
                btnFloat.BringToFront();
                currentY -= (btnFloat.Height + BUTTON_SPACING);
            }
        }

        private void tabCerrarSesion_Click(object sender, EventArgs e)
        {
            // Reiniciar el programa
            Application.Restart();
        }

        private void btnAddSell_Click(object sender, EventArgs e)
        {
            ShowControlInTabPage(tpSells, new Sell());
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }
    }
}
