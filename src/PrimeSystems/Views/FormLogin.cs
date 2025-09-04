using System.Windows.Forms;
using PrimeSystems.Data;
using PrimeSystems.Views;
using PrimeSystems.Models;
using ReaLTaiizor.Enum.Crown;
using ReaLTaiizor.Forms;


namespace PrimeSystems
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();
            ColorScheme.GetSkinManager().AddFormToManage(this);

        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                DBInitializer.CreateDatabaseIfNotExists();
                Database.CheckConnection();
            } catch (Exception ex) {
                MessageBox.Show(
                    text: ex.Message,
                    caption: "Error de conexión",
                    icon: MessageBoxIcon.Error,
                    buttons: MessageBoxButtons.OK
                );
            }
            DBInitializer.CreateTablesIfNotExists();
            UserModel? user = UserRepository.CreateAdminUserIfNotExists();
            if (user != null)
            {
                MessageBox.Show(
                    text: $"Se creó el usuario administrador por defecto con los siguientes datos:\n" +
                            $"Usuario: {user.username}\n" +
                            $"Contraseña: {user.password}\n" +
                            $"Por favor, anotalo para poder loguearte por primera vez.\n" +
                            $"Posteriormente podras eliminarlo si así lo deseas.",
                    caption: "Usuario administrador creado",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Warning
                );
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = tbUsuario.Text;
            string password = tbContrasena.Text;
            UserModel? user = UserRepository.Get(username);
            if (user == null || user.password != password)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
            this.Hide();
        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (tbUsuario.Text.Length > 0 && tbContrasena.Text.Length > 0)
                btnLogin.Enabled = true;
        }
    }
}
