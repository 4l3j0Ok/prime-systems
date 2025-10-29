using PrimeSystems.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystems.Core
{
    internal class Utils
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string characters = Config.random_password_characters;
            string password = "";
            int index;
            for (int i = 0; i < length; i++)
            {
                index = random.Next(characters.Length);
                password += characters[index];
            }
            return password;
        }
        public static void CardSetupClickEvent(Control obj, EventHandler OnUserCardClick)
        {
            // Agregar evento click al UserControl principal
            obj.Click += OnUserCardClick;
            obj.Cursor = Cursors.Hand; // Cambiar cursor para indicar que es clickeable

            // Agregar evento click a todos los controles hijos recursivamente
            CardAddClickEventToControls(obj.Controls, OnUserCardClick);
        }

        public static void CardAddClickEventToControls(Control.ControlCollection controls, EventHandler function)
        {
            foreach (Control control in controls)
            {
                control.Click += function;
                control.Cursor = Cursors.Hand;

                // Si el control tiene controles hijos, agregar el evento recursivamente
                if (control.HasChildren)
                {
                    CardAddClickEventToControls(control.Controls, function);
                }
            }
        }
        public static byte[]? ImageToByteArray(Image? imageIn)
        {
            if (imageIn == null)
                return null;

            using (var ms = new MemoryStream())
            {
                // Usar PNG como formato predeterminado para evitar problemas con RawFormat
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public static Image? ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0) return null;
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
