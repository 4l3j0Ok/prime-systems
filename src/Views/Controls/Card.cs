using PrimeSystems.Models;
using PrimeSystems.Services;
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

namespace PrimeSystems.Views.Controls
{
    public partial class Card : UserControl
    {
        public Card(
            string? title = "",
            string? description = "",
            Bitmap? picture = null,
            Action? previewCallBack = null,
            Action? editCallback = null,
            Action? removeCallback = null
        )
        {
            InitializeComponent();
            lblTitle.Text = title ?? "";
            lblDescription.Text = description ?? "";
            if (picture != null)
            {
                pbPicture.Image = picture;
            }
            btnPreview.Click += (s, e) => { previewCallBack?.Invoke(); };
            btnEdit.Click += (s, e) => { editCallback?.Invoke(); };
            btnRemove.Click += (s, e) => { removeCallback?.Invoke(); };
        }

        /// <summary>
        /// Sets the card to read-only mode, hiding edit and remove buttons
        /// </summary>
        public void SetReadOnlyMode()
        {
            btnEdit.Visible = false;
            btnEdit.Enabled = false;
            btnRemove.Visible = false;
            btnRemove.Enabled = false;
        }

        /// <summary>
        /// Enables all buttons (default mode)
        /// </summary>
        public void SetWriteMode()
        {
            btnEdit.Visible = true;
            btnEdit.Enabled = true;
            btnRemove.Visible = true;
            btnRemove.Enabled = true;
            btnPreview.Visible = true;
            btnPreview.Enabled = true;
        }
    }
}
