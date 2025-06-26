using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems
{
    public partial class FormLogin : UserControl
    {
        private FormPrincipal formPrincipal;

        public FormLogin(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            this.formPrincipal = formPrincipal;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsuario.Text;
            string password = tbContrasena.Text;
            string dbPassword = Database.GetUserPassword(username);
            if (string.IsNullOrEmpty(dbPassword) || password != dbPassword)
            {
                MessageBox.Show(
                    text: "El usuario o contraseña son inválidos",
                    caption: "Error de inicio de sesión",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error
                );



            }

        }

       

        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (tbUsuario.Text.Length > 0 && tbContrasena.Text.Length > 0)
                btnLogin.Enabled = true;
        }
    }
}
