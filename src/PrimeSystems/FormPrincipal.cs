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

        }
    }
}
