using PrimeSystems.Controllers;
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
    public partial class UCUserAdd : UserControl
    {
        private UserController userController;
        private RoleController roleController;
        private UserModel currentUser;
        private FormPrincipal? formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();

        public UCUserAdd(UserModel? user = null)
        {
            userController = new UserController();
            roleController = new RoleController();
            InitializeComponent();
            if (user != null)
            {
                mepUserAdd.Title = "Modificar Usuario";
                mepUserAdd.Description = "Edita los datos del usuario seleccionado";
                currentUser = user;
                tbUserName.Text = user.Name;
                tbUserSurname.Text = user.Surname;
                tbUserUsername.Text = user.Username;
                tbUserPhone.Text = user.Phone;
                tbUserEmail.Text = user.Email;
                tbUserPassword.Text = user.Password;
                tbUserPasswordConfirm.Text = user.Password;
                tbUserPersonId.Text = user.PersonId;
                pbUserProfilePicture.Image = Utils.ByteArrayToImage(user.ProfilePicture);
                cmbRole.SelectedItem = user.Role?.Name ?? "Sin rol";
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
            List<RoleModel> roles = roleController.GetAllRoles();
            foreach (RoleModel role in roles)
            {
                cmbRole.Items.Add(role.Name);
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
                emptyFields.Add("Rol");

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
            currentUser.Surname = tbUserSurname.Text;
            currentUser.Username = tbUserUsername.Text;
            currentUser.Phone = tbUserPhone.Text;
            currentUser.Email = tbUserEmail.Text;
            currentUser.Password = tbUserPassword.Text;
            currentUser.PersonId = tbUserPersonId.Text;
            currentUser.ProfilePicture = Utils.ImageToByteArray(pbUserProfilePicture.Image);
            RoleModel? selectedRole = roleController.GetRoleByName(cmbRole.SelectedItem?.ToString() ?? "");
            if (selectedRole != null)
            {
                currentUser.RoleId = selectedRole.Id;
                currentUser.Role = selectedRole;
            }
            bool success;
            if (currentUser.Id == 0)
                success = userController.CreateUser(currentUser);
            else
                success = userController.UpdateUser(currentUser);
            if (success)
            {
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario. El nombre de usuario, email o identificación ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            formPrincipal.RestaurarFormularioTab(formPrincipal.tabUsers);
        }

        private void mepUserAdd_CancelClick(object sender, EventArgs e)
        {
            formPrincipal?.RestaurarFormularioTab(formPrincipal.tabUsers);
        }
    }
}