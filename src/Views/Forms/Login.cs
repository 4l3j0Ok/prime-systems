using ReaLTaiizor.Colors;
using ReaLTaiizor.Enum.Crown;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Windows.Forms;
using PrimeSystems.Controllers;
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
        private void Login_Load(object sender, EventArgs e)
        {
            DbInitializer.Initialize();
            UserModel? user = DbInitializer.InitializeUser();
            if (user != null)
            {
                CustomMessageBox msgBox = new CustomMessageBox();
                msgBox.Text = "Usuario administrador creado";
                msgBox.lblMessage.Text = $"Se creó el usuario administrador por defecto con los siguientes datos:\n" +
                    $"Usuario: {user.Username}\n" +
                    $"Contraseña: {user.PasswordHash}\n" +
                    $"Por favor, anótalo para poder loguearte por primera vez.\n" +
                    $"Posteriormente podrás eliminarlo si así lo deseas.";
                msgBox.btnLeft.Text = "Copiar";
                msgBox.btnLeft.Click += (s, ev) => 
                {
                    try
                    {
                        msgBox.btnLeft.Type = MaterialButton.MaterialButtonType.Outlined;
                        msgBox.btnLeft.Text = "¡Copiado!";
                        Clipboard.SetText(user.PasswordHash ?? "");
                    }
                    catch (ExternalException)
                    {
                        Debug.WriteLine("Fallo al copiar al portapapeles.");
                    }
                };
                msgBox.btnRight.Text = "Aceptar";
                msgBox.btnRight.Click += (s, ev) => msgBox.Close();
                msgBox.ShowDialog();
            }
        }


        private void tbHandleEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.PerformClick();
        }

        private void tbCredentials_TextChanged(object sender, EventArgs e)
        {
            if (tbUsuario.Text.Length > 0 && tbContrasena.Text.Length > 0)
                btnLogin.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsuario.Text;
            string password = tbContrasena.Text;

            UserController userController = new UserController();
            UserModel? user = userController.GetByUsername(username);

            if (user == null || user.PasswordHash != password)
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
