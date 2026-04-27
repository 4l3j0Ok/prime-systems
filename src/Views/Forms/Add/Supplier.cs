using PrimeSystems.Services;
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
    public partial class Supplier : UserControl
    {
        private SupplierService supplierController;
        private SupplierModel selectedSupplier;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();

        public Supplier(SupplierModel? supplier = null)
        {
            supplierController = new SupplierService();
            InitializeComponent();
            SetupControls();
            
            if (supplier == null)
            {
                selectedSupplier = new SupplierModel();
                return;
            }
            
            mepSupplierAdd.Title = "Modificar Proveedor";
            mepSupplierAdd.Description = "Edita los datos del proveedor seleccionado";
            selectedSupplier = supplier;
            
            tbSupplierName.Text = supplier.Name;
            tbSupplierCuit.Text = supplier.Cuit?.ToString() ?? "";
            tbSupplierContactName.Text = supplier.ContactName;
            tbSupplierPhone.Text = supplier.Phone;
            tbSupplierEmail.Text = supplier.Email;
        }

        private void SetupControls()
        {
            tbSupplierCuit.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbSupplierCuit.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
            
            tbSupplierPhone.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Numbers);
            tbSupplierPhone.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Numbers);
            
            tbSupplierEmail.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Email);
            tbSupplierEmail.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Email);
            
            mepSupplierAdd.SaveClick += mepSupplierAdd_SaveClick;
            mepSupplierAdd.CancelClick += mepSupplierAdd_CancelClick;
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrWhiteSpace(tbSupplierName.Text))
                emptyFields.Add("Nombre");

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(tbSupplierEmail.Text))
            {
                if (!tbSupplierEmail.Text.Contains("@") || !tbSupplierEmail.Text.Contains("."))
                {
                    MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void mepSupplierAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            int originalId = selectedSupplier.Id;
            selectedSupplier.Name = tbSupplierName.Text;
            selectedSupplier.Cuit = int.TryParse(tbSupplierCuit.Text, out int cuit) ? cuit : null;
            selectedSupplier.ContactName = string.IsNullOrWhiteSpace(tbSupplierContactName.Text) ? null : tbSupplierContactName.Text;
            selectedSupplier.Phone = string.IsNullOrWhiteSpace(tbSupplierPhone.Text) ? null : tbSupplierPhone.Text;
            selectedSupplier.Email = string.IsNullOrWhiteSpace(tbSupplierEmail.Text) ? null : tbSupplierEmail.Text;

            bool success;
            if (selectedSupplier.Id == 0)
                success = supplierController.Create(selectedSupplier);
            else
                success = supplierController.Update(selectedSupplier);

            if (success)
            {
                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                string action = originalId == 0 ? ActivityActions.Create : ActivityActions.Update;
                ActivityLogger.LogActivity(action, ActivityModules.Suppliers, supplierId: selectedSupplier.Id);
                
                ReturnToSuppliersView();
            }
            else
            {
                MessageBox.Show("Error al guardar el proveedor. El CUIT o email ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepSupplierAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToSuppliersView();
        }

        private void ReturnToSuppliersView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpSuppliers);
            }
        }
    }
}
