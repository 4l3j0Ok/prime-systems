using ReaLTaiizor.Colors;
using ReaLTaiizor.Enum.Crown;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Windows.Forms;
using PrimeSystems.Controllers;
using PrimeSystems.Models;
using PrimeSystems.Data;
using System.Diagnostics;

namespace PrimeSystems
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            UIConfig.GetSkinManager().AddFormToManage(this);
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            UserModel? user = DbInitializer.InitializeUser();
            if (user != null)
            {
                CustomMessageBox msgBox = new CustomMessageBox();
                msgBox.Text = "Usuario administrador creado";
                msgBox.lblMessage.Text = $"Se creó el usuario administrador por defecto con los siguientes datos:\n" +
                    $"Usuario: {user.Username}\n" +
                    $"Contraseña: {user.Password}\n" +
                    $"Por favor, anótalo para poder loguearte por primera vez.\n" +
                    $"Posteriormente podrás eliminarlo si así lo deseas.";
                msgBox.btnLeft.Text = "Copiar";
                msgBox.btnLeft.Click += (s, ev) => copyPassword(user.Password ?? "");
                msgBox.btnLeft.Click += (s, ev) => msgBox.btnLeft.Text = "¡Copiado!";
                msgBox.btnLeft.Click += (s, ev) => msgBox.btnLeft.Type = MaterialButton.MaterialButtonType.Outlined;
                msgBox.btnRight.Text = "Aceptar";
                msgBox.btnRight.Click += (s, ev) => msgBox.Close();
                msgBox.ShowDialog();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsuario.Text;
            string password = tbContrasena.Text;

            UserController userController = new UserController();
            UserModel? user = userController.GetUserByUsername(username);

            if (user == null || user.Password != password)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!user.IsActive)
            {
                MessageBox.Show("El usuario está inactivo.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormPrincipal formPrincipal = new FormPrincipal(currentUser: user);
            formPrincipal.Show();
            this.Hide();
        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (tbUsuario.Text.Length > 0 && tbContrasena.Text.Length > 0)
                btnLogin.Enabled = true;
        }

        private static void copyPassword(string password)
        {
            Clipboard.SetText(password);
        }

        private void tbCredentials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
