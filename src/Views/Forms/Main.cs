using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeSystems.Controllers;
using PrimeSystems.Views.Controls;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;
using System.Linq;
using Panel = System.Windows.Forms.Panel;

namespace PrimeSystems
{
    public partial class Main : MaterialForm
    {
        private readonly UserModel currentUser;
        private readonly Dictionary<System.Windows.Forms.TabPage, List<Control>> originalTabContents = new Dictionary<System.Windows.Forms.TabPage, List<Control>>();

        public Main(UserModel currentUser)
        {
            this.currentUser = currentUser;
            UIConfig.GetSkinManager().AddFormToManage(this);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadCardsOnTabPage<UserModel>(
                tabUsers,
                    () => new UserController(),
                    (user) => new Card(
                title: user.Username,
                description: $"{user.Name} {user.LastName}",
                picture: GetUserProfilePicture(user),
                editCallback: () => ShowUserEditForm(user),
                removeCallback: () => RemoveUser(user)
                )
                    );
            SaveOriginalTabContents();
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

        private void ShowUserEditForm(UserModel user)
        {
            ShowControlInTabPage(tabUsers, new UserAdd(user));
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
                            tabUsers,
                            () => new UserController(),
                            (u) => new Card(
                                title: u.Username,
                                description: $"{u.Name} {u.LastName}",
                                picture: GetUserProfilePicture(u),
                                editCallback: () => ShowUserEditForm(u),
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
            foreach (System.Windows.Forms.TabPage tabPage in tcPrincipal.TabPages)
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
                CardHeader header = new CardHeader();
                header.Dock = DockStyle.Top;
                foreach (T item in items)
                {
                    Card card = cardFactory(item);
                    card.Dock = DockStyle.Top;
                    card.Margin = new Padding(10);
                    mainPanel.Controls.Add(card);
                }
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
            ShowControlInTabPage(tabUsers, new UserAdd());
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
                    tabUsers,
                    () => new UserController(),
                    (user) => new Card(
                        title: user.Username,
                        description: $"{user.Name} {user.LastName}",
                        picture: GetUserProfilePicture(user),
                        editCallback: () => ShowUserEditForm(user),
                        removeCallback: () => RemoveUser(user)
                    )
                );
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
    }
}
