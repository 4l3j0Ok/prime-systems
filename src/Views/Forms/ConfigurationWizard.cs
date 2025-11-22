using PrimeSystems.Core;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PrimeSystems.Views.Forms
{
    public partial class ConfigurationWizard : MaterialForm
    {
        private const string YamlFileName = "config.yaml";

        public ConfigurationWizard()
        {
            InitializeComponent();
            UIConfig.GetSkinManager().AddFormToManage(this);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string connectionString = tbConnectionString.Text.Trim();
            string username = tbInitialUser.Text.Trim();
            string password = tbInitialUserPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("Por favor, ingrese una cadena de conexión válida.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbInitialUser.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbInitialUserPassword.Focus();
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbInitialUserPassword.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            var (success, errorMessage) = DbInitializer.TestConnection(connectionString);
            this.Cursor = Cursors.Default;

            if (!success)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la base de datos:\n\n{errorMessage}\n\nPor favor, verifique la cadena de conexión.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                var configuration = new UserAppConfiguration
                {
                    Database = new DatabaseConfig
                    {
                        ConnectionString = connectionString
                    }
                };

                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                string yamlContent = serializer.Serialize(configuration);

                string header = "# Archivo de configuración para Prime Systems\n" +
                                "# No deberías necesitar modificar este archivo manualmente ya que es gestionado por la aplicación.\n";

                File.WriteAllText(YamlFileName, header + yamlContent);
                Config.LoadConfiguration();

                this.Cursor = Cursors.WaitCursor;
                DbInitializer.Initialize();
                var user = DbInitializer.InitializeUser(username, password);
                Debug.WriteLine(user);
                this.Cursor = Cursors.Default;

                if (user != null)
                {
                    MessageBox.Show(
                        $"¡Configuración completada exitosamente!",
                        "Configuración completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "¡Configuración guardada correctamente!\n\n" +
                        "La base de datos ya contiene usuarios.",
                        "Configuración completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(
                    $"Error al guardar la configuración: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTestDBConnection_Click(object sender, EventArgs e)
        {
            string connectionString = tbConnectionString.Text.Trim();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("Por favor, ingrese una cadena de conexión para probar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var (success, errorMessage) = DbInitializer.TestConnection(connectionString);

            this.Cursor = Cursors.Default;

            if (success)
            {
                MessageBox.Show(
                    "¡Conexión exitosa!\n\nLa cadena de conexión es válida y se pudo conectar a la base de datos.",
                    "Prueba de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Error al conectar a la base de datos:\n\n{errorMessage}",
                    "Prueba de conexión fallida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
