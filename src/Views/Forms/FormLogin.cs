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
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            UIConfig.GetSkinManager().AddFormToManage(this);
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            DbInitializer.Initialize();
            UsuarioModel? user = DbInitializer.InitializeUser();
            if (user != null)
            {
                CustomMessageBox msgBox = new CustomMessageBox();
                msgBox.Text = "Usuario administrador creado";
                msgBox.lblMessage.Text = $"Se creó el usuario administrador por defecto con los siguientes datos:\n" +
                    $"Usuario: {user.NombreUsuario}\n" +
                    $"Contraseña: {user.Contrasena}\n" +
                    $"Por favor, anótalo para poder loguearte por primera vez.\n" +
                    $"Posteriormente podrás eliminarlo si así lo deseas.";
                msgBox.btnLeft.Text = "Copiar";
                msgBox.btnLeft.Click += (s, ev) => 
                {
                    try
                    {
                        msgBox.btnLeft.Type = MaterialButton.MaterialButtonType.Outlined;
                        msgBox.btnLeft.Text = "¡Copiado!";
                        Clipboard.SetText(user.Contrasena ?? "");
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsuario.Text;
            string password = tbContrasena.Text;

            UserController userController = new UserController();
            UsuarioModel? user = userController.GetUserByUsername(username);

            if (user == null || user.Contrasena != password)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbCredentials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
