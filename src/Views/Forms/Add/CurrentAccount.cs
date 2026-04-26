using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using PrimeSystems.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using Panel = System.Windows.Forms.Panel;
using GroupBox = System.Windows.Forms.GroupBox;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class CurrentAccount : UserControl
    {
        private CurrentAccountController currentAccountController;
        private CurrentAccountModel selectedAccount;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();

        private MaterialComboBox cmbEntityType;
        private MaterialComboBox cmbEntity;
        private MaterialTextBoxEdit tbInitialBalance;
        private MaterialLabel lblEntityType;
        private MaterialLabel lblEntity;
        private MaterialLabel lblInitialBalance;
        private MaterialExpansionPanelNonCollapsible mepCurrentAccountAdd;

        public CurrentAccount(CurrentAccountModel? account = null)
        {
            currentAccountController = new CurrentAccountController();
            InitializeComponent();
            SetupControls();

            if (account == null)
            {
                selectedAccount = new CurrentAccountModel();
                mepCurrentAccountAdd.Title = "Crear Cuenta Corriente";
                mepCurrentAccountAdd.Description = "Registra una nueva cuenta corriente";
                LoadEntityComboBoxes();
                return;
            }

            mepCurrentAccountAdd.Title = "Modificar Cuenta Corriente";
            mepCurrentAccountAdd.Description = "Edita los datos de la cuenta corriente seleccionada";
            selectedAccount = account;

            LoadEntityComboBoxes();
            SetEntitySelection(account.EntityType, account.EntityId);
            tbInitialBalance.Text = account.Balance.ToString("N2");
        }

        private void InitializeComponent()
        {
            mepCurrentAccountAdd = new MaterialExpansionPanelNonCollapsible
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(255, 255, 255),
                CancelButtonText = "Cancelar",
                Description = "",
                ExpandHeight = 450,
                Title = "Registrar Cuenta Corriente",
                ValidationButtonEnable = true,
                ValidationButtonText = "Guardar",
                ShowCollapseExpand = false
            };

            Controls.Add(mepCurrentAccountAdd);
        }

        private void SetupControls()
        {
            cmbEntityType = new MaterialComboBox
            {
                Depth = 0,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 34),
                Name = "cmbEntityType",
                Size = new Size(355, 48),
                TabIndex = 0,
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT
            };

            lblEntityType = new MaterialLabel
            {
                AutoSize = true,
                Depth = 0,
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 15),
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER,
                Name = "lblEntityType",
                Size = new Size(102, 19),
                TabIndex = 0,
                Text = "Tipo de Entidad"
            };

            cmbEntity = new MaterialComboBox
            {
                Depth = 0,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 34),
                Name = "cmbEntity",
                Size = new Size(355, 48),
                TabIndex = 1,
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT
            };

            lblEntity = new MaterialLabel
            {
                AutoSize = true,
                Depth = 0,
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 15),
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER,
                Name = "lblEntity",
                Size = new Size(51, 19),
                TabIndex = 0,
                Text = "Entidad"
            };

            tbInitialBalance = new MaterialTextBoxEdit
            {
                Depth = 0,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 34),
                MaxLength = 18,
                Name = "tbInitialBalance",
                Size = new Size(355, 48),
                TabIndex = 2,
                HideSelection = true,
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT
            };

            lblInitialBalance = new MaterialLabel
            {
                AutoSize = true,
                Depth = 0,
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                Location = new Point(15, 15),
                MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER,
                Name = "lblInitialBalance",
                Size = new Size(103, 19),
                TabIndex = 0,
                Text = "Saldo Inicial"
            };

            var panelEntityType = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15), MinimumSize = new Size(0, 120) };
            panelEntityType.Controls.Add(cmbEntityType);
            panelEntityType.Controls.Add(lblEntityType);

            var panelEntity = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15), MinimumSize = new Size(0, 120) };
            panelEntity.Controls.Add(cmbEntity);
            panelEntity.Controls.Add(lblEntity);

            var panelBalance = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15), MinimumSize = new Size(0, 120) };
            panelBalance.Controls.Add(tbInitialBalance);
            panelBalance.Controls.Add(lblInitialBalance);

            var tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(10)
            };
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.RowStyles.Add(new RowStyle());
            tableLayout.Controls.Add(panelEntityType, 0, 0);
            tableLayout.Controls.Add(panelEntity, 1, 0);
            tableLayout.Controls.Add(panelBalance, 0, 1);
            tableLayout.SetColumnSpan(panelBalance, 2);

            var gbData = new GroupBox
            {
                Text = "Datos de la Cuenta Corriente",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            gbData.Controls.Add(tableLayout);

            mepCurrentAccountAdd.Controls.Add(gbData);

            cmbEntityType.SelectedIndexChanged += CmbEntityType_SelectedIndexChanged;

            tbInitialBalance.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbInitialBalance.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);

            mepCurrentAccountAdd.SaveClick += mepCurrentAccountAdd_SaveClick;
            mepCurrentAccountAdd.CancelClick += mepCurrentAccountAdd_CancelClick;
        }

        private void LoadEntityComboBoxes()
        {
            cmbEntityType.Items.Clear();
            cmbEntityType.Items.Add(new ComboBoxItem { Text = "Cliente", Value = CurrentAccountType.Client });
            cmbEntityType.Items.Add(new ComboBoxItem { Text = "Proveedor", Value = CurrentAccountType.Supplier });
            cmbEntityType.Items.Add(new ComboBoxItem { Text = "Usuario", Value = CurrentAccountType.User });
            cmbEntityType.SelectedIndex = 0;
        }

        private void CmbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEntityType.SelectedItem is ComboBoxItem item)
            {
                var entityType = (CurrentAccountType)item.Value;
                LoadEntityList(entityType);
            }
        }

        private void LoadEntityList(CurrentAccountType entityType)
        {
            cmbEntity.Items.Clear();

            switch (entityType)
            {
                case CurrentAccountType.Client:
                    var clients = new ClientController().GetAll();
                    foreach (var client in clients)
                    {
                        cmbEntity.Items.Add(new ComboBoxItem { Text = client.Name ?? $"Cliente {client.Id}", Value = client.Id });
                    }
                    break;
                case CurrentAccountType.Supplier:
                    var suppliers = new SupplierController().GetAll();
                    foreach (var supplier in suppliers)
                    {
                        cmbEntity.Items.Add(new ComboBoxItem { Text = supplier.Name ?? $"Proveedor {supplier.Id}", Value = supplier.Id });
                    }
                    break;
                case CurrentAccountType.User:
                    var users = new UserController().GetAll();
                    foreach (var user in users)
                    {
                        cmbEntity.Items.Add(new ComboBoxItem { Text = user.Username ?? $"Usuario {user.Id}", Value = user.Id });
                    }
                    break;
            }

            if (cmbEntity.Items.Count > 0)
                cmbEntity.SelectedIndex = 0;
        }

        private void SetEntitySelection(CurrentAccountType entityType, int entityId)
        {
            for (int i = 0; i < cmbEntityType.Items.Count; i++)
            {
                if (cmbEntityType.Items[i] is ComboBoxItem item && (CurrentAccountType)item.Value == entityType)
                {
                    cmbEntityType.SelectedIndex = i;
                    break;
                }
            }

            LoadEntityList(entityType);

            for (int i = 0; i < cmbEntity.Items.Count; i++)
            {
                if (cmbEntity.Items[i] is ComboBoxItem item && (int)item.Value == entityId)
                {
                    cmbEntity.SelectedIndex = i;
                    break;
                }
            }
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            if (cmbEntityType.SelectedItem == null)
                emptyFields.Add("Tipo de Entidad");

            if (cmbEntity.SelectedItem == null)
                emptyFields.Add("Entidad");

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepCurrentAccountAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            if (cmbEntityType.SelectedItem is ComboBoxItem typeItem && cmbEntity.SelectedItem is ComboBoxItem entityItem)
            {
                selectedAccount.EntityType = (CurrentAccountType)typeItem.Value;
                selectedAccount.EntityId = (int)entityItem.Value;

                if (decimal.TryParse(tbInitialBalance.Text, out decimal balance))
                {
                    selectedAccount.Balance = balance;
                }

                bool success;
                if (selectedAccount.Id == 0)
                {
                    selectedAccount.Title = $"Cuenta Corriente - {(typeItem.Text)} #{(entityItem.Value)}";
                    success = currentAccountController.Create(selectedAccount);
                }
                else
                {
                    success = currentAccountController.Update(selectedAccount);
                }

                if (success)
                {
                    MessageBox.Show("Cuenta corriente guardada correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnToCurrentAccountsView();
                }
                else
                {
                    MessageBox.Show("Error al guardar la cuenta corriente. La entidad ya puede tener una cuenta asociada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mepCurrentAccountAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToCurrentAccountsView();
        }

        private void ReturnToCurrentAccountsView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpCurrentAccounts);
            }
        }

        private class ComboBoxItem
        {
            public string Text { get; set; } = "";
            public object Value { get; set; } = 0;
            public override string ToString() => Text;
        }
    }
}