using System;
using System.Windows.Forms;
using PrimeSystems.Core;
using PrimeSystems.Views.Forms;

namespace PrimeSystems
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                Config.LoadConfiguration();

                if (!Config.ConfigFileExists())
                {
                    using (var wizard = new ConfigurationWizard())
                    {
                        var result = wizard.ShowDialog();
                        if (result != DialogResult.OK)
                        {
                            MessageBox.Show(
                                "La configuración es necesaria para iniciar la aplicación.",
                                "Configuración requerida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al iniciar la aplicación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}