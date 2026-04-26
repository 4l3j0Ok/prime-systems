using PrimeSystems.Controllers;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using Panel = System.Windows.Forms.Panel;
using GroupBox = System.Windows.Forms.GroupBox;
using PrimeSystems.Views.Controls;

namespace PrimeSystems.Views.Forms.Add
{
    public partial class AddCurrentAccountMovement : UserControl
    {
        private CurrentAccountController currentAccountController;
        private CurrentAccountModel currentAccount;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();

        private MaterialComboBox cmbMovementType = null!;
        private MaterialTextBoxEdit tbAmount = null!;
        private MaterialTextBoxEdit tbReference = null!;
        private MaterialTextBoxEdit tbDescription = null!;
        private MaterialExpansionPanelNonCollapsible mepMovementAdd = null!;

        public AddCurrentAccountMovement(CurrentAccountModel account)
        {
            currentAccountController = new CurrentAccountController();
            currentAccount = account;
            InitializeComponent();
            SetupControls();
        }

        private void InitializeComponent()
        {
            Size = new Size(844, 400);
            BackColor = Color.FromArgb(255, 255, 255);

            mepMovementAdd = new MaterialExpansionPanelNonCollapsible
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(255, 255, 255),
                CancelButtonText = "Cancelar",
                Description = "Registra un nuevo movimiento en la cuenta corriente",
                ExpandHeight = 400,
                Title = "Agregar Movimiento",
                ValidationButtonEnable = true,
                ValidationButtonText = "Guardar",
                ShowCollapseExpand = false
            };

            Controls.Add(mepMovementAdd);
        }

        private void SetupControls()
        {
            var container = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(10)
            };
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            container.RowStyles.Add(new RowStyle());
            container.RowStyles.Add(new RowStyle());
            container.RowStyles.Add(new RowStyle());
            container.RowStyles.Add(new RowStyle());

            var lblTitle = new MaterialLabel
            {
                Text = $"Cuenta: {currentAccount.Title}",
                Dock = DockStyle.Fill,
                Font = new Font("Roboto", 16F, FontStyle.Bold, GraphicsUnit.Pixel),
                AutoSize = false,
                Height = 30
            };

            var lblCurrentBalance = new MaterialLabel
            {
                Text = $"Saldo Actual: ${currentAccount.Balance:N2}",
                Dock = DockStyle.Fill,
                Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel),
                AutoSize = false,
                Height = 25
            };

            var panelTitle = new Panel { Dock = DockStyle.Fill, MinimumSize = new Size(0, 60) };
            panelTitle.Controls.Add(lblCurrentBalance);
            panelTitle.Controls.Add(lblTitle);

            container.Controls.Add(panelTitle, 0, 0);
            container.SetColumnSpan(panelTitle, 2);

            var panelType = CreateFieldPanel("Tipo de Movimiento", out cmbMovementType);
            cmbMovementType.Items.Add(new ComboBoxItem { Text = "Credito (+)", Value = MovementType.Credit });
            cmbMovementType.Items.Add(new ComboBoxItem { Text = "Debito (-)", Value = MovementType.Debit });
            cmbMovementType.Items.Add(new ComboBoxItem { Text = "Pago (+)", Value = MovementType.Payment });
            cmbMovementType.Items.Add(new ComboBoxItem { Text = "Cargo (-)", Value = MovementType.Charge });
            cmbMovementType.SelectedIndex = 0;

            var panelAmount = CreateFieldPanel("Monto", out tbAmount);

            var panelReference = CreateFieldPanel("Referencia", out tbReference);

            var panelDescription = CreateFieldPanel("Descripcion", out tbDescription);
            container.SetColumnSpan(panelDescription, 2);

            container.Controls.Add(panelType, 0, 1);
            container.Controls.Add(panelAmount, 1, 1);
            container.Controls.Add(panelReference, 0, 2);
            container.Controls.Add(panelDescription, 0, 3);
            container.SetColumnSpan(panelDescription, 2);

            var gbData = new GroupBox
            {
                Text = "Datos del Movimiento",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            gbData.Controls.Add(container);

            var mainTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };
            mainTable.Controls.Add(gbData);

            mepMovementAdd.Controls.Add(mainTable);

            tbAmount.KeyPress += (sender, e) => Utils.HandleTextBoxInput(sender, e, ValidationType.Decimal);
            tbAmount.TextChanged += (sender, e) => Utils.HandlePostTextBoxInput(sender, e, ValidationType.Decimal);

            mepMovementAdd.ValidationButtonEnable = true;
            mepMovementAdd.SaveClick += mepMovementAdd_SaveClick;
            mepMovementAdd.CancelClick += mepMovementAdd_CancelClick;
        }

        private Panel CreateFieldPanel(string labelText, out MaterialTextBoxEdit textBox)
        {
            textBox = new MaterialTextBoxEdit
            {
                Depth = 0,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel),
                MaxLength = 500,
                Name = $"tb{labelText.Replace(" ", "")}",
                Size = new Size(355, 48)
            };

            var label = new MaterialLabel
            {
                Text = labelText,
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                AutoSize = true
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                MinimumSize = new Size(0, 100),
                Padding = new Padding(15)
            };
            panel.Controls.Add(textBox);
            panel.Controls.Add(label);

            return panel;
        }

        private Panel CreateFieldPanel(string labelText, out MaterialComboBox comboBox)
        {
            comboBox = new MaterialComboBox
            {
                Depth = 0,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel),
                Name = $"cmb{labelText.Replace(" ", "")}"
            };

            var label = new MaterialLabel
            {
                Text = labelText,
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                AutoSize = true
            };

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                MinimumSize = new Size(0, 100),
                Padding = new Padding(15)
            };
            panel.Controls.Add(comboBox);
            panel.Controls.Add(label);

            return panel;
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            if (cmbMovementType.SelectedItem == null)
                emptyFields.Add("Tipo de Movimiento");

            if (string.IsNullOrWhiteSpace(tbAmount.Text))
                emptyFields.Add("Monto");

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(tbAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("El monto debe ser un numero positivo.", "Error de validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepMovementAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            if (cmbMovementType.SelectedItem is ComboBoxItem typeItem)
            {
                decimal amount = decimal.Parse(tbAmount.Text);
                var type = (MovementType)typeItem.Value;

                var success = currentAccountController.AddMovement(
                    currentAccount.Id,
                    type,
                    amount,
                    string.IsNullOrWhiteSpace(tbReference.Text) ? null : tbReference.Text,
                    string.IsNullOrWhiteSpace(tbDescription.Text) ? null : tbDescription.Text
                );

                if (success)
                {
                    MessageBox.Show("Movimiento registrado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnToMovementsView();
                }
                else
                {
                    MessageBox.Show("Error al registrar el movimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mepMovementAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToMovementsView();
        }

        private void ReturnToMovementsView()
        {
            if (formMain != null)
            {
                var movementsView = new CurrentAccountMovementsView(currentAccount);
                formMain.ShowControlInTabPage(formMain.tpCurrentAccounts, movementsView);
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