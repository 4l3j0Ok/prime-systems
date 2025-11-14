using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class Client : UserControl
    {
        private ClientController clientController;
        private ClientModel selectedClient;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();

        public Client(ClientModel? client = null)
        {
            clientController = new ClientController();
            InitializeComponent();
            SetupControls();
            
            if (client == null)
            {
                selectedClient = new ClientModel();
                return;
            }
            
            // Modo edición
            mepClientAdd.Title = "Modificar Cliente";
            mepClientAdd.Description = "Edita los datos del cliente seleccionado";
            selectedClient = client;
            
            // Precargar datos
            tbClientrName.Text = client.Name;
            tbClientCuit.Text = client.Cuit?.ToString() ?? "";
            tbClientEntity.Text = client.Entity;
            tbClientPhone.Text = client.Phone;
            tbClientEmail.Text = client.Email;
        }

        private void SetupControls()
        {
            // Configurar validación de campos
            tbClientCuit.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbClientCuit.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
            
            tbClientPhone.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbClientPhone.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
            
            tbClientEmail.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Email);
            tbClientEmail.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Email);
            
            // Configurar eventos de los botones
            mepClientAdd.SaveClick += mepClientAdd_SaveClick;
            mepClientAdd.CancelClick += mepClientAdd_CancelClick;
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(tbClientrName.Text))
                emptyFields.Add("Nombre");

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato de email si se proporcionó
            if (!string.IsNullOrWhiteSpace(tbClientEmail.Text))
            {
                if (!tbClientEmail.Text.Contains("@") || !tbClientEmail.Text.Contains("."))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void mepClientAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            // Asignar valores al modelo
            selectedClient.Name = tbClientrName.Text;
            selectedClient.Cuit = int.TryParse(tbClientCuit.Text, out int cuit) ? cuit : null;
            selectedClient.Entity = string.IsNullOrWhiteSpace(tbClientEntity.Text) ? null : tbClientEntity.Text;
            selectedClient.Phone = string.IsNullOrWhiteSpace(tbClientPhone.Text) ? null : tbClientPhone.Text;
            selectedClient.Email = string.IsNullOrWhiteSpace(tbClientEmail.Text) ? null : tbClientEmail.Text;

            bool success;
            if (selectedClient.Id == 0)
                success = clientController.Create(selectedClient);
            else
                success = clientController.Update(selectedClient);

            if (success)
            {
                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnToClientsView();
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente. El CUIT o email ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepClientAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToClientsView();
        }

        private void ReturnToClientsView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpSellsClients);
            }
        }
    }
}
