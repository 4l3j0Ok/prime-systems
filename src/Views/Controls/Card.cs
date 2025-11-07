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

namespace PrimeSystems
{
    public partial class Card : UserControl
    {
        public Card(
            string? title = "",
            string? description = "",
            Bitmap? picture = null,
            Action? editCallback = null,
            Action? removeCallback = null
        )
        {
            InitializeComponent();
            lblTitle.Text = title ?? "";
            lblDescription.Text = description ?? "";

            // Set the picture, or use default if null
            if (picture != null)
            {
                pbPicture.Image = picture;
            }
            // Note: The default image is already set in the designer

            btnEdit.Click += (s, e) => { editCallback?.Invoke(); };
            btnRemove.Click += (s, e) => { removeCallback?.Invoke(); };
        }

        // Method to update the image if needed
        public void UpdateImage(Bitmap? newImage)
        {
            if (pbPicture.Image != null && pbPicture.Image != Properties.Resources.user_placeholder)
            {
                pbPicture.Image.Dispose();
            }

            if (newImage != null)
            {
                pbPicture.Image = newImage;
            }
            else
            {
                pbPicture.Image = Properties.Resources.user_placeholder;
            }
        }
    }
}
