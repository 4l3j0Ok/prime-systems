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
    public partial class Role : UserControl
    {
        private UserTypeController roleController;
        private RoleModel selectedRole;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
        private bool isNewRole;

        public Role(RoleModel? role = null)
        {
            roleController = new UserTypeController();
            InitializeComponent();

            if (role == null)
            {
                isNewRole = true;
                selectedRole = new RoleModel();
                tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm");
                tbCurrentUser.Text = Session.CurrentUser?.Username ?? "Usuario Actual"; // TODO: Get from session
                return;
            }

            isNewRole = false;
            mepSellAdd.Title = "Modificar Rol";
            mepSellAdd.Description = "Edita los datos del rol seleccionado";
            selectedRole = role;

            tbRoleId.Text = role.Id;
            tbRoleId.ReadOnly = true;
            tbRoleName.Text = role.Name;

            // Set checkboxes based on permissions
            SetCheckboxesFromPermission(role.SellsPermission, chbSellRead, chbSellWrite);
            SetCheckboxesFromPermission(role.PurchasesPermission, chbPurchaseRead, chbPurchaseWrite);
            SetCheckboxesFromPermission(role.FinancialStatePermission, chbFinancialStateRead, chbFinancialStateWrite);
            SetCheckboxesFromPermission(role.UserPermission, chbUserRead, chbUserWrite);

            tbDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm");
            tbCurrentUser.Text = "Usuario Actual"; // TODO: Get from session
        }

        private void SetCheckboxesFromPermission(AccessLevel permission, ReaLTaiizor.Controls.MaterialCheckBox readCheckbox, ReaLTaiizor.Controls.MaterialCheckBox writeCheckbox)
        {
            readCheckbox.Checked = permission == AccessLevel.Read || permission == AccessLevel.Write;
            writeCheckbox.Checked = permission == AccessLevel.Write;
        }

        private AccessLevel GetPermissionFromCheckboxes(ReaLTaiizor.Controls.MaterialCheckBox readCheckbox, ReaLTaiizor.Controls.MaterialCheckBox writeCheckbox)
        {
            if (writeCheckbox.Checked)
                return AccessLevel.Write;
            if (readCheckbox.Checked)
                return AccessLevel.Read;
            return AccessLevel.None;
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(tbRoleId.Text))
                emptyFields.Add("Identificador");

            if (string.IsNullOrWhiteSpace(tbRoleName.Text))
                emptyFields.Add("Nombre del rol");

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el ID no contenga espacios
            if (tbRoleId.Text.Contains(" "))
            {
                MessageBox.Show("El identificador no puede contener espacios.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el ID no sea demasiado largo
            if (tbRoleId.Text.Length > 20)
            {
                MessageBox.Show("El identificador no puede tener más de 20 caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepSellAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            selectedRole.Id = tbRoleId.Text.Trim();
            selectedRole.Name = tbRoleName.Text.Trim();

            // Get permissions from checkboxes
            selectedRole.SellsPermission = GetPermissionFromCheckboxes(chbSellRead, chbSellWrite);
            selectedRole.PurchasesPermission = GetPermissionFromCheckboxes(chbPurchaseRead, chbPurchaseWrite);
            selectedRole.FinancialStatePermission = GetPermissionFromCheckboxes(chbFinancialStateRead, chbFinancialStateWrite);
            selectedRole.UserPermission = GetPermissionFromCheckboxes(chbUserRead, chbUserWrite);

            bool success;
            if (isNewRole)
                success = roleController.Create(selectedRole);
            else
                success = roleController.Update(selectedRole);

            if (success)
            {
                MessageBox.Show("Rol guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnToRolesView();
            }
            else
            {
                MessageBox.Show("Error al guardar el rol. El identificador ya existe o hay un problema con los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepSellAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToRolesView();
        }

        private void ReturnToRolesView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpUsersRoles);
            }
        }

        private void chbWrite_CheckedChanged(object sender, EventArgs e)
        {
            // si esta chequeado el write, chequeamos el read y lo bloqueamos
            var checkbox = sender as ReaLTaiizor.Controls.MaterialCheckBox;
            if (checkbox != null)
            {
                if (checkbox == chbSellWrite)
                {
                    chbSellRead.Checked = checkbox.Checked || chbSellRead.Checked;
                    chbSellRead.Enabled = !checkbox.Checked;
                }
                else if (checkbox == chbPurchaseWrite)
                {
                    chbPurchaseRead.Checked = checkbox.Checked || chbPurchaseRead.Checked;
                    chbPurchaseRead.Enabled = !checkbox.Checked;
                }
                else if (checkbox == chbFinancialStateWrite)
                {
                    chbFinancialStateRead.Checked = checkbox.Checked || chbFinancialStateRead.Checked;
                    chbFinancialStateRead.Enabled = !checkbox.Checked;
                }
                else if (checkbox == chbUserWrite)
                {
                    chbUserRead.Checked = checkbox.Checked || chbUserRead.Checked;
                    chbUserRead.Enabled = !checkbox.Checked;
                }
            }
        }
    }
}
