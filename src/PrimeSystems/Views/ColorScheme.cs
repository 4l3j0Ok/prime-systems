using ReaLTaiizor.Colors;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems.Views
{
    internal class ColorScheme
    {
        public static int primary = 0x2a4057; // Color primario #2a4057
        public static int lightPrimary = 0x5c7d8e; // Tono más claro del color primario #5c7d8e
        public static int darkPrimary = 0x0c213c; // Tono más oscuro del color primario #0c213c
        public static int accent = 0x9b4b5b; // Color de acento #9b4b5b
        public static int background = 0xEEEEEE; // Color de fondo

        public static MaterialSkinManager GetSkinManager()
        {
            MaterialSkinManager materialSkinManager;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialColorScheme(
                primary: primary,
                darkPrimary: darkPrimary,
                lightPrimary: lightPrimary,
                accent: accent,
                textShade: MaterialTextShade.LIGHT
            );
            return materialSkinManager;
        }
    }
}