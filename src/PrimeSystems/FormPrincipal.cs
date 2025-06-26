using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace PrimeSystems
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();

        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin(this);
            formLogin.Dock = DockStyle.Fill;
            formLogin.Show();
            panelPrincipal.Controls.Add(formLogin);
            try
            {
                Database.CheckConnection();
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            Database.CreateDatabaseIfNotExists();
            Database.CreateTablesIfNotExists();
            Dictionary<string, string> user = Database.CreateAdminUserIfNotExists();
            if (user.ContainsKey("username") && user.ContainsKey("password"))
            {
                MessageBox.Show(
                    text: $"Se creó el usuario administrador por defecto con los siguientes datos:\n" +
                            $"Usuario: {user["username"]}\n" +
                            $"Contraseña: {user["password"]}\n" +
                            $"Por favor, anotalo para poder loguearte por primera vez.\n" +
                            $"Posteriormente podras eliminarlo si así lo deseas.",
                    caption: "Usuario administrador creado",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Warning
                );
            }

        }
    }
}
