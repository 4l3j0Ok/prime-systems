using PrimeSystems.Controllers;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PrimeSystems
{
    public partial class FormPrincipal : MaterialForm
    {
        private readonly UserModel currentUser;
        private readonly Dictionary<System.Windows.Forms.TabPage, List<Control>> originalTabContents = new Dictionary<System.Windows.Forms.TabPage, List<Control>>();

        public FormPrincipal(UserModel currentUser)
        {
            this.currentUser = currentUser;
            UIConfig.GetSkinManager().AddFormToManage(this);
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoadCards();
            // Guardar el estado inicial de todos los tabs
            SaveOriginalTabContents();
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

        public void LoadCards(Type? clearObjectsOfType = null)
        {
            if (clearObjectsOfType != null)
            {
                foreach (System.Windows.Forms.TabPage tabPage in tcPrincipal.TabPages)
                {
                    // Elimina todos los controles del tipo especificado
                    var controlsToRemove = tabPage.Controls.Cast<Control>()
                        .Where(c => c.GetType() == clearObjectsOfType)
                        .ToList();
                    foreach (var control in controlsToRemove)
                    {
                        tabPage.Controls.Remove(control);
                        control.Dispose();
                    }
                }
            }
            LoadUsersTable();
        }
        private void LoadUsersTable()
        {
            UserController userController = new UserController();
            List<UserModel> users = userController.GetAllUsers();
            if (users.Count > 0)
                lblEmptyUsers.Visible = false;
            foreach (UserModel user in users)
            {
                UCUserCard userCard = new UCUserCard(user: user);
                userCard.Dock = DockStyle.Top;
                userCard.Margin = new Padding(10);
                flpUsersList.Controls.Add(userCard);
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UCUserAdd userAddControl = new UCUserAdd();
            VerFormularioTab(userAddControl, tabUsers);
        }
        public void VerFormularioTab(UserControl uc, System.Windows.Forms.TabPage tabPage)
        {
            // Guardar el estado actual del tab si no está guardado o si ha cambiado
            if (!originalTabContents.ContainsKey(tabPage))
            {
                var controls = new List<Control>();
                foreach (Control control in tabPage.Controls)
                {
                    controls.Add(control);
                }
                originalTabContents[tabPage] = controls;
            }
            uc.Dock = DockStyle.Fill;
            tabPage.Controls.Clear();
            tabPage.Controls.Add(uc);
        }

        public void RestaurarFormularioTab(System.Windows.Forms.TabPage tabPage)
        {
            // Paso 1: Limpiar la pestaña completamente (esto elimina el formulario Add)
            tabPage.Controls.Clear();

            // Paso 2: Restaurar los controles originales del Designer
            if (originalTabContents.ContainsKey(tabPage))
            {
                foreach (Control control in originalTabContents[tabPage])
                {
                    tabPage.Controls.Add(control);
                }
            }

            // Paso 3: Limpiar solo las tarjetas dinámicas de los contenedores
            RemoveDynamicControls(tabPage);

            // Paso 4: Recargar el contenido específico del tab
            ReloadTabContent(tabPage);
        }

        private void RemoveDynamicControls(System.Windows.Forms.TabPage tabPage)
        {
            // Identificar y limpiar solo los contenedores de datos dinámicos
            if (tabPage == tabUsers)
            {
                // Limpiar solo las tarjetas del FlowLayoutPanel, no el FlowLayoutPanel mismo
                flpUsersList.Controls.Clear();
                lblEmptyUsers.Visible = true;
            }
        }

        private void ReloadTabContent(System.Windows.Forms.TabPage tabPage)
        {
            // Identificar qué tab es y recargar su contenido apropiado
            if (tabPage == tabUsers)
            {
                LoadUsersTable();
            }
        }

        // También actualizar el método ReloadTabContent() sin parámetros para manejar todos los tabs
        private void ReloadTabContent()
        {
            // Limpiar todos los contenedores antes de cargar
            flpUsersList.Controls.Clear();

            // Resetear todos los labels de vacío
            lblEmptyUsers.Visible = true;

            // Cargar todo el contenido
            LoadUsersTable();
        }
        private void tabCerrarSesion_Click(object sender, EventArgs e)
        {
            // Reiniciar el programa
            Application.Restart();
        }
    }
}
