using Microsoft.Data.SqlClient;
using PrimeSystems.Controllers;
using PrimeSystems.Data;
using PrimeSystems.Models;
using PrimeSystems.Views;
using ReaLTaiizor.Forms;
using System.Data;
using System.Windows.Forms;

namespace PrimeSystems
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
            ColorScheme.GetSkinManager().AddFormToManage(this);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            List<UserModel> data = UserRepository.GetAll();
            DataTable dataTable = new DataTable();
            //dataTable.Load();
            dgvRRHHUsers.DataSource = dataTable;
        }

        private void tcPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tcPrincipal.SelectedTab ?? throw new InvalidOperationException("No tab is selected.");
            this.Text = $"{Config.application_name} > {selectedTab.Text}";
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // tapamos los controles anteriores sin reemplazarlos
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.Dock = DockStyle.Fill;
            users.Controls.Add(formAddUser);
            formAddUser.BringToFront();
        }
    }
}
