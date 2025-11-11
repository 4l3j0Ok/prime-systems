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
            LoadCardsOnTabPage<UserModel>(
                tpUsers,
                    () => new UserController(),
                    (user) => new Card(
                title: user.Username,
                description: $"{user.Name} {user.LastName}",
                picture: GetUserProfilePicture(user),
                editCallback: () => ShowControlInTabPage(tpUsers, new User(user)),
                removeCallback: () => RemoveUser(user)
                )
                    );
            SaveOriginalTabContents();
            PositionFloatingButtonsInTabControl(tcMain);
            EnableDoubleBuffer(this);
        }

        void EnableDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(c, true, null);

            foreach (Control child in c.Controls)
                EnableDoubleBuffer(child);
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

        private void RemoveUser(UserModel user)
        {
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al usuario '{user.Username}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var userController = new UserController();
                    bool success = userController.Delete(user.Id);

                    if (success)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Recargar las tarjetas de usuarios usando la función genérica
                        LoadCardsOnTabPage<UserModel>(
                            tpUsers,
                            () => new UserController(),
                            (u) => new Card(
                                title: u.Username,
                                description: $"{u.Name} {u.LastName}",
                                picture: GetUserProfilePicture(u),
                                editCallback: () => ShowControlInTabPage(tpUsers, new User(u)),
                                removeCallback: () => RemoveUser(u)
                            )
                        );
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Panel? mainPanel = GetMainPanel(tabPage);
                mainPanel.SuspendLayout();
                foreach (Control existingControl in mainPanel.Controls)
                {
                    if (existingControl is Card card && card.pbPicture.Image != null)
                    {
                        card.pbPicture.Image.Dispose(); // Para liberar recursos
                    }
                }
                mainPanel.Controls.Clear();
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
                    mainPanel.Controls.Add(card);
                    // Espaciador porque el DockStyle.Top no respeta la propiedad de margen
                    Panel spacer = new Panel();
                    spacer.Height = 5;
                    spacer.Dock = DockStyle.Top;
                    mainPanel.Controls.Add(spacer);
                }
                // Mismo espaciador para el header pero un poco más grande
                Panel headerSpacer = new Panel();
                headerSpacer.Height = 8;
                headerSpacer.Dock = DockStyle.Top;
                mainPanel.Controls.Add(headerSpacer);
                // Header de las tarjetas
                CardHeader header = new CardHeader();
                header.Dock = DockStyle.Top;
                mainPanel.Controls.Add(header);
                mainPanel.ResumeLayout();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"LoadCardsOnTabPage: Error - {ex.Message}");
                MessageBox.Show($"Error al cargar elementos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ShowControlInTabPage(tpUsers, new User());
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

                // Luego cargar las tarjetas en el panel restaurado
                LoadCardsOnTabPage<UserModel>(
                    tpUsers,
                    () => new UserController(),
                    (user) => new Card(
                        title: user.Username,
                        description: $"{user.Name} {user.LastName}",
                        picture: GetUserProfilePicture(user),
                        editCallback: () => ShowControlInTabPage(tpUsers, new User(user)),
                        removeCallback: () => RemoveUser(user)
                    )
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
            const int BUTTON_SPACING = 10; // Spacing between buttons

            var floatingButtons = new List<ReaLTaiizor.Controls.MaterialFloatingActionButton>();

            // Collect all floating buttons
            foreach (Control control in container.Controls)
            {
                if (control is ReaLTaiizor.Controls.MaterialFloatingActionButton btnFloat)
                {
                    floatingButtons.Add(btnFloat);
                }
            }

            if (floatingButtons.Count == 0)
                return;

            // Calculate starting Y position (bottom of container minus margin)
            int currentY = container.ClientSize.Height - margin;

            // Position buttons from bottom to top
            for (int i = floatingButtons.Count - 1; i >= 0; i--)
            {
                var btnFloat = floatingButtons[i];
                btnFloat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                // Position button
                btnFloat.Location = new Point(
                    container.ClientSize.Width - btnFloat.Width - margin,
                    currentY - btnFloat.Height
                );

                btnFloat.BringToFront();

                // Move up for next button
                currentY -= (btnFloat.Height + BUTTON_SPACING);
            }
        }


        private Panel GetMainPanel(System.Windows.Forms.TabPage tabPage)
        {
            return tabPage.Controls.OfType<Panel>().FirstOrDefault();
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
