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
    public partial class UCUserCard : UserControl
    {
        private UsuarioModel _user;

        public UCUserCard(UsuarioModel user)
        {
            InitializeComponent();
            _user = user;

            lblUserName.Text = user.Nombre;
            lblUserUsername.Text = int.TryParse(user.Dni?.ToString(), out int dni) ? $"DNI: {dni}" : "DNI: N/A";
            lblUserArea.Text = user.UsuarioTipo?.Descripcion ?? "Sin tipo";
            lblUserPhone.Text = user.Tel;
            pbUserProfilePicture.Image = Utils.ByteArrayToImage(user.Foto);
            Utils.CardSetupClickEvent(this, OnUserCardClick);
        }

        private void OnUserCardClick(object? sender, EventArgs? e)
        {
            OpenFormAdd(_user);
        }

        public static void OpenFormAdd(UsuarioModel user)
        {
            UCUserAdd userAdd = new UCUserAdd(user);
            FormPrincipal? formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();
            formPrincipal?.VerFormularioTab(userAdd, formPrincipal.tabUsers);
        }
    }
}
