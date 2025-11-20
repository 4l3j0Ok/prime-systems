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
    public partial class User : UserControl
    {
        private UserController userController;
        private UserTypeController usuarioTipoController;
        private UserModel selectedUser;
        private Main? formMain = Application.OpenForms.OfType<Main>().FirstOrDefault();
        private TabPage ParentTabPage;

        public User(UserModel? user = null, TabPage? parentTabPage = null)
        {
            if (parentTabPage != null)
                ParentTabPage = parentTabPage;
            else
                ParentTabPage = formMain?.tpUsersList ?? new TabPage();
            userController = new UserController();
            usuarioTipoController = new UserTypeController();
            InitializeComponent();
            if (user == null)
            {
                selectedUser = new UserModel();
                return;
            }
            mepUserAdd.Title = "Modificar Usuario";
            mepUserAdd.Description = "Edita los datos del usuario seleccionado";
            selectedUser = user;
            tbUserName.Text = user.Name;
            tbUserSurname.Text = user.LastName;
            tbUserUsername.Text = user.Username;
            tbUserPhone.Text = user.Phone;
            tbUserEmail.Text = user.Email;
            tbUserPassword.Text = user.Password;
            tbUserPasswordConfirm.Text = user.Password;
            tbUserPersonId.Text = user.PersonId?.ToString() ?? "";
            cmbRole.SelectedItem = user.Role?.Name ?? "Sin tipo";
            if (user.ProfilePicture != null)
                pbUserProfilePicture.Image = Utils.ByteArrayToImage(user.ProfilePicture);
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
            List<RoleModel> usuariosTipo = usuarioTipoController.GetAll();
            foreach (RoleModel tipo in usuariosTipo)
            {
                cmbRole.Items.Add(tipo.Name);
            }
        }

        private bool ValidateFields()
        {
            List<string> emptyFields = new List<string>();

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

            if (emptyFields.Count > 0)
            {
                string message = "Los siguientes campos son obligatorios:\n\n" + string.Join("\n", emptyFields);
                MessageBox.Show(message, "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbUserPassword.Text != tbUserPasswordConfirm.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!tbUserEmail.Text.Contains("@") || !tbUserEmail.Text.Contains("."))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void mepUserAdd_SaveClick(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            int originalId = selectedUser.Id;
            selectedUser.Name = tbUserName.Text;
            selectedUser.LastName = tbUserSurname.Text;
            selectedUser.Username = tbUserUsername.Text;
            selectedUser.Phone = tbUserPhone.Text;
            selectedUser.Email = tbUserEmail.Text;
            selectedUser.Password = tbUserPassword.Text;
            selectedUser.PersonId = int.TryParse(tbUserPersonId.Text, out int dni) ? dni : null;
            selectedUser.ProfilePicture = Utils.ImageToByteArray(pbUserProfilePicture.Image);

            string? selectedTipoDescripcion = cmbRole.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTipoDescripcion))
            {
                var usuarioTipo = usuarioTipoController.GetByDescription(selectedTipoDescripcion);
                if (usuarioTipo != null)
                {
                    selectedUser.RoleId = usuarioTipo.Id;
                }
            }

            bool success;
            if (selectedUser.Id == 0)
                success = userController.Create(selectedUser);
            else
                success = userController.Update(selectedUser);

            if (success)
            {
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string action = originalId == 0 ? ActivityActions.Create : ActivityActions.Update;
                ActivityLogger.LogActivity(action, ActivityModules.Users);

                ReturnToUsersView();
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario. El nombre de usuario, email o identificación ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mepUserAdd_CancelClick(object sender, EventArgs e)
        {
            ReturnToUsersView();
        }

        private void ReturnToUsersView()
        {
            if (formMain != null)
            {
                formMain.RestoreTabPage(ParentTabPage);
            }
        }
    }
}