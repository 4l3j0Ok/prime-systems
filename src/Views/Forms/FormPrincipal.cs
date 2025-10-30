using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeSystems.Controllers;
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
            LoadCardsOnTabPage<UserModel>(
                tabUsers,
                () => new UserController(), // Pasamos un lambda que crea el controlador
                (user) => new UserCard(user) // Pasamos un lambda que crea la tarjeta de usuario
            );
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

        public void LoadCardsOnTabPage<T>(
            System.Windows.Forms.TabPage tabPage,
            Func<IGenericController<T>> controllerFactory,
            Func<T, Control> createCard
        )
        {
            var controller = controllerFactory();
            List<T> items = controller.GetAll() ?? new List<T>();
            foreach (Control control in tabPage.Controls)
            {
                if (control is FlowLayoutPanel flp)
                {
                    flp.SuspendLayout();
                    flp.Controls.Clear();

                    foreach (T item in items)
                    {
                        Control uc = createCard(item);
                        uc.Dock = DockStyle.Top;
                        uc.Margin = new Padding(10);
                        flp.Controls.Add(uc);
                    }
                    flp.ResumeLayout();
                    break;
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ShowControlInTabPage(
                tabUsers,
                new UserAdd()
            );
        }
        public void ShowControlInTabPage(System.Windows.Forms.TabPage tabPage, Control controlToShow)
        {
            tabPage.Controls.Clear();
            controlToShow.Dock = DockStyle.Fill;
            tabPage.Controls.Add(controlToShow);
        }

        private void tabCerrarSesion_Click(object sender, EventArgs e)
        {
            // Reiniciar el programa
            Application.Restart();
        }
    }
}
