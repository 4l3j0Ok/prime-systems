using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using Microsoft.Data.SqlClient;

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
            string query = File.ReadAllText(".\\queries\\06-select-users.sql");
            SqlDataReader data =  Database.ExecuteReader(query);
            DataTable dataTable = new DataTable();
            
        }
    }
}
