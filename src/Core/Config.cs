using ReaLTaiizor.Util;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Colors;
using System.Drawing;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;


namespace PrimeSystems.Core
{
    internal class Config
    {
        public static string application_name = "Prime Systems";
        public static string sql_connection_string = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? "Server=127.0.0.1;Database=PrimeSystems;Trusted_Connection=True;TrustServerCertificate=True;";
        public static string sql_database_name = "PrimeSystems";
        public static string random_password_characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':,.<>?/~`";
        public static List<string> defaultRoles = new List<string>
        {
            "Administrador",
        };
        public static Bitmap default_profile_picture = Properties.Resources.user_placeholder;
    }
    internal class UIConfig
    {
        public static int primary = 0x003554; // Color primario
        public static int lightPrimary = 0x006494; // Tono más claro del color primario
        public static int darkPrimary = 0x051923; // Tono más oscuro del color primario
        public static int accent = 0x00a6fb; // Color de acento
        public static int background = 0xe7ecef; // Color de fondo

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

