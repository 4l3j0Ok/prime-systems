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

namespace PrimeSystems.Views
{
    public partial class UserAdd : UserControl
    {
        private UserController userController;
        private UsuarioTipoController usuarioTipoController;
        private UserModel currentUser;
        private FormPrincipal? formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();

        public UserAdd(UserModel? user = null)
        {
            userController = new UserController();
            usuarioTipoController = new UsuarioTipoController();
            InitializeComponent();
            if (user != null)
            {
                mepUserAdd.Title = "Modificar Usuario";
                mepUserAdd.Description = "Edita los datos del usuario seleccionado";
                currentUser = user;
                tbUserName.Text = user.Name;
                tbUserSurname.Text = user.LastName;
                tbUserUsername.Text = user.Username;
                tbUserPhone.Text = user.Phone;
                tbUserEmail.Text = user.Email;
                tbUserPassword.Text = user.PasswordHash;
                tbUserPasswordConfirm.Text = user.PasswordHash;
                tbUserPersonId.Text = user.PersonId?.ToString() ?? "";
                pbUserProfilePicture.Image = Utils.ByteArrayToImage(user.ProfilePicture);
                cmbRole.SelectedItem = user.UserType?.Description ?? "Sin tipo";
            }
            else
            {
                currentUser = new UserModel();
            }
        }

        private void btnUploadProfilePicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imágen|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbUserProfilePicture.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void UCUserAdd_Load(object sender, EventArgs e)
        {
            List<UserTypeModel> usuariosTipo = usuarioTipoController.GetAll();
            foreach (UserTypeModel tipo in usuariosTipo)
            {
                cmbRole.Items.Add(tipo.Description);
            }
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(tbUserName.Text))
                emptyFields.Add("Nombre");

            if (string.IsNullOrWhiteSpace(tbUserSurname.Text))
                emptyFields.Add("Apellido");

            if (string.IsNullOrWhiteSpace(tbUserUsername.Text))
                emptyFields.Add("Nombre de usuario");

            if (string.IsNullOrWhiteSpace(tbUserPersonId.Text))
                emptyFields.Add("Documento");

            if (string.IsNullOrWhiteSpace(tbUserEmail.Text))
                emptyFields.Add("Correo electrónico");

            if (string.IsNullOrWhiteSpace(tbUserPhone.Text))
                emptyFields.Add("Número de teléfono");

            if (string.IsNullOrWhiteSpace(tbUserPassword.Text))
                emptyFields.Add("Contraseña");

            if (string.IsNullOrWhiteSpace(tbUserPasswordConfirm.Text))
                emptyFields.Add("Confirmación de contraseña");

            if (cmbRole.SelectedItem == null)
                emptyFields.Add("Tipo de usuario");

            // Mostrar mensaje de error si hay campos vacíos
            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que las contraseñas coincidan
            if (tbUserPassword.Text != tbUserPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar formato de email básico
            if (!tbUserEmail.Text.Contains("@") || !tbUserEmail.Text.Contains("."))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepUserAdd_SaveClick(object sender, EventArgs e)
        {
            // Validar campos antes de guardar
            if (!ValidateFields())
                return;

            currentUser.Name = tbUserName.Text;
            currentUser.LastName = tbUserSurname.Text;
            currentUser.Username = tbUserUsername.Text;
            currentUser.Phone = tbUserPhone.Text;
            currentUser.Email = tbUserEmail.Text;
            currentUser.PasswordHash = tbUserPassword.Text;
            currentUser.PersonId = int.TryParse(tbUserPersonId.Text, out int dni) ? dni : null;
            currentUser.ProfilePicture = Utils.ImageToByteArray(pbUserProfilePicture.Image);

            // Asignar UsuarioTipoId basado en la descripción seleccionada
            string? selectedTipoDescripcion = cmbRole.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTipoDescripcion))
            {
                var usuarioTipo = usuarioTipoController.GetByDescription(selectedTipoDescripcion);
                if (usuarioTipo != null)
                {
                    currentUser.UserTypeId = usuarioTipo.Id;
                }
            }
            
            bool success;
            if (currentUser.Id == 0)
                success = userController.Create(currentUser);
            else
                success = userController.Update(currentUser);
            if (success)
            {
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario. El nombre de usuario, email o identificación ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            formPrincipal.LoadCardsOnTabPage(
                formPrincipal.tabUsers,
                () => new UserController(),
                (user) => new UserCard(user)
            );
        }

        private void mepUserAdd_CancelClick(object sender, EventArgs e)
        {
            formPrincipal.LoadCardsOnTabPage(
                formPrincipal.tabUsers,
                () => new UserController(),
                (user) => new UserCard(user)
            );
        }
    }
}