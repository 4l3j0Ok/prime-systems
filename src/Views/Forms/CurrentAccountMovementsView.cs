using PrimeSystems.Services;
using PrimeSystems.Core;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using Panel = System.Windows.Forms.Panel;

namespace PrimeSystems.Views.Forms
{
    public partial class CurrentAccountMovementsView : UserControl
    {
        private CurrentAccountService currentAccountController;
        private CurrentAccountMovementService movementController;
        private CurrentAccountModel currentAccount;
        private Main? formMain;
        private const int PAGE_SIZE = 20;
        private Panel pMovementsContainer = null!;
        private MaterialLabel lblAccountTitle = null!;
        private MaterialLabel lblCurrentBalance = null!;

        public CurrentAccountMovementsView(CurrentAccountModel account)
        {
            currentAccountController = new CurrentAccountService();
            movementController = new CurrentAccountMovementService();
            currentAccount = account;
            formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
            InitializeComponent();
            LoadMovements();
        }

        private void InitializeComponent()
        {
            Size = new Size(844, 600);
            BackColor = Color.FromArgb(255, 255, 255);

            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(20)
            };

            lblAccountTitle = new MaterialLabel
            {
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Pixel),
                Text = currentAccount.Title ?? $"Cuenta #{currentAccount.Id}",
                AutoSize = false,
                Height = 30
            };

            lblCurrentBalance = new MaterialLabel
            {
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                Text = $"Saldo Actual: ${currentAccount.Balance:N2}",
                AutoSize = false,
                Height = 25
            };

            var btnBack = new MaterialButton
            {
                Text = "Volver",
                Dock = DockStyle.Bottom,
                Width = 100,
                Height = 30,
                Type = MaterialButton.MaterialButtonType.Outlined
            };
            btnBack.Click += (s, e) => ReturnToList();

            var btnAddMovement = new MaterialButton
            {
                Text = "Agregar Movimiento",
                Dock = DockStyle.Bottom,
                Width = 150,
                Height = 30,
                Margin = new Padding(0, 0, 10, 0)
            };
            btnAddMovement.Click += (s, e) => ShowAddMovementForm();

            var btnContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 50
            };
            btnContainer.Controls.Add(btnBack);
            btnContainer.Controls.Add(btnAddMovement);

            pMovementsContainer = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            headerPanel.Controls.Add(lblCurrentBalance);
            headerPanel.Controls.Add(lblAccountTitle);
            headerPanel.Controls.Add(btnContainer);

            Controls.Add(pMovementsContainer);
            Controls.Add(headerPanel);
        }

        private void LoadMovements()
        {
            pMovementsContainer.Controls.Clear();

            var movements = movementController.GetByCurrentAccountId(currentAccount.Id);

            if (movements.Count == 0)
            {
                var emptyLabel = new MaterialLabel
                {
                    Text = "No hay movimientos registrados.",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pMovementsContainer.Controls.Add(emptyLabel);
                return;
            }

            foreach (var movement in movements)
            {
                var movementItem = CreateMovementItem(movement);
                pMovementsContainer.Controls.Add(movementItem);
            }
        }

        private Panel CreateMovementItem(CurrentAccountMovementModel movement)
        {
            var item = new Panel
            {
                Height = 80,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(15)
            };

            var typeColor = movement.Type switch
            {
                MovementType.Credit or MovementType.Payment => Color.FromArgb(76, 175, 80),
                MovementType.Debit or MovementType.Charge => Color.FromArgb(244, 67, 54),
                _ => Color.Gray
            };

            var typeText = movement.Type switch
            {
                MovementType.Credit => "Credito",
                MovementType.Debit => "Debito",
                MovementType.Payment => "Pago",
                MovementType.Charge => "Cargo",
                _ => "Movimiento"
            };

            var amountPrefix = (movement.Type == MovementType.Credit || movement.Type == MovementType.Payment) ? "+" : "-";

            var lblDate = new MaterialLabel
            {
                Text = movement.Date.ToString("dd/MM/yyyy HH:mm"),
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Pixel)
            };

            var lblType = new MaterialLabel
            {
                Text = typeText,
                Dock = DockStyle.Top,
                ForeColor = typeColor,
                Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Pixel)
            };

            var lblAmount = new MaterialLabel
            {
                Text = $"{amountPrefix}${movement.Amount:N2}",
                Dock = DockStyle.Right,
                ForeColor = typeColor,
                Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
            };

            var lblDescription = new MaterialLabel
            {
                Text = movement.Description ?? "Sin descripcion",
                Dock = DockStyle.Top,
                Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Pixel),
                ForeColor = Color.Gray
            };

            var lblBalance = new MaterialLabel
            {
                Text = $"Saldo: ${movement.BalanceAfter:N2}",
                Dock = DockStyle.Bottom,
                Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Pixel),
                ForeColor = Color.Gray
            };

            item.Controls.Add(lblBalance);
            item.Controls.Add(lblDescription);
            item.Controls.Add(lblAmount);
            item.Controls.Add(lblType);
            item.Controls.Add(lblDate);

            return item;
        }

        private void ShowAddMovementForm()
        {
            var movementsView = new CurrentAccountMovementsView(currentAccount);
            if (formMain != null)
            {
                formMain.ShowControlInTabPage(formMain.tpCurrentAccounts, movementsView);
            }
        }

        private void ReturnToList()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(formMain.tpCurrentAccounts);
            }
        }
    }
}