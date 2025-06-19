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
        }
    }
}
