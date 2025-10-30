using PrimeSystems.Models;
using PrimeSystems.Controllers;
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
using PrimeSystems.Core;

namespace PrimeSystems.Views
{
    public partial class UserCard : UserControl
    {
        private UserModel _user;

        public UserCard(UserModel user)
        {
            InitializeComponent();
            _user = user;

            lblUserName.Text = user.Name;
            lblUserUsername.Text = int.TryParse(user.PersonId?.ToString(), out int dni) ? $"DNI: {dni}" : "DNI: N/A";
            lblUserArea.Text = user.UserType?.Description ?? "Sin tipo";
            lblUserPhone.Text = user.Phone;
            pbUserProfilePicture.Image = Utils.ByteArrayToImage(user.ProfilePicture);
            Utils.CardSetupClickEvent(this, OnUserCardClick);
        }

        private void OnUserCardClick(object? sender, EventArgs? e)
        {
            OpenFormAdd(_user);
        }

        public static void OpenFormAdd(UserModel user)
        {
            FormPrincipal? formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();
            formPrincipal?.ShowControlInTabPage(
                formPrincipal.tabUsers,
                new UserAdd()
            );
        }
    }
}
