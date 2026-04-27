using ReaLTaiizor.Colors;
using ReaLTaiizor.Enum.Crown;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Windows.Forms;
using PrimeSystems.Services;
using PrimeSystems.Models;
using System.Diagnostics;
using PrimeSystems.Core;
using System.Runtime.InteropServices;

namespace PrimeSystems
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            UIConfig.GetSkinManager().AddFormToManage(this);
        }

        private void tbHandleEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.PerformClick();
        }

        private void tbCredentials_TextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length > 0 && tbPassword.Text.Length > 0)
                btnLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            UserService userController = new UserService();
            UserModel? user = userController.GetByUsername(username);

            if (user == null || user.Password != password)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Session.CurrentUser = user;
            Main Main = new Main();
            Main.Show();
            this.Hide();
        }
    }
}
