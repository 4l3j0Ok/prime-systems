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
            if (!Database.CheckConnection())
            {
                MessageBox.Show(
                    "Conexión a la base de datos fallida. Por favor, verifica la configuración.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            }
            Database.CreateDatabaseIfNotExists();
        }
    }
}
