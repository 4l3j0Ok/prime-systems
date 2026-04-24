using ReaLTaiizor.Util;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Colors;
using System.Drawing;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PrimeSystems.Core
{
    /// <summary>
    /// Configuration class loaded from YAML file
    /// </summary>
    public class UserAppConfiguration
    {
        public DatabaseConfig Database { get; set; } = new DatabaseConfig();
    }

    public class DatabaseConfig
    {
        public string Provider { get; set; } = "sqlite";
        public string ConnectionString { get; set; } = string.Empty;
    }

    internal class Config
    {
        private const string YamlConfigFile = "config.yaml";

        public static string application_name = "Prime Systems";
        public static string sql_database_name = "PrimeSystems";
        public static string random_password_characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}|;':,.<>?/~`";
        public static Bitmap default_profile_picture = Properties.Resources.user_placeholder;

        private static UserAppConfiguration? _configuration;

        public static string sql_connection_string = string.Empty;
        public static string sql_provider = "sqlite";

        public static string GetConnectionString()
        {
            if (sql_provider == "sqlite")
            {
                return "Data Source=data/primesystems.db";
            }
            return sql_connection_string;
        }

        public static bool ConfigFileExists()
        {
            return File.Exists(YamlConfigFile);
        }

        public static void LoadConfiguration()
        {
            try
            {
                if (ConfigFileExists())
                {
                    string yamlContent = File.ReadAllText(YamlConfigFile);
                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();

                    _configuration = deserializer.Deserialize<UserAppConfiguration>(yamlContent);

                    if (_configuration != null && !string.IsNullOrWhiteSpace(_configuration.Database?.ConnectionString))
                    {
                        sql_connection_string = _configuration.Database.ConnectionString;
                    }
                    if (_configuration != null && !string.IsNullOrWhiteSpace(_configuration.Database?.Provider))
                    {
                        sql_provider = _configuration.Database.Provider;
                    }
                    Console.WriteLine("Configuración YAML cargada exitosamente.");
                    return;
                }
                else
                {
                    Console.WriteLine("Archivo de configuración YAML no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar configuración YAML: {ex.Message}");
            }


            _configuration = new UserAppConfiguration
            {
                Database = new DatabaseConfig
                {
                    ConnectionString = sql_connection_string
                }
            };
        }

        public static UserAppConfiguration GetConfiguration()
        {
            return _configuration ?? new UserAppConfiguration();
        }
    }

    public enum ValidationType
    {
        Letters,
        Numbers,
        Decimal,
        LettersAndNumbers,
        Email
    }

    internal static class ValidationRegex
    {
        private static readonly Dictionary<ValidationType, string> patterns = new()
        {
            { ValidationType.Letters, "[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\\s]" },
            { ValidationType.Numbers, "[0-9]" },
            { ValidationType.Decimal, "[0-9\\,]" },
            { ValidationType.LettersAndNumbers, "[a-zA-Z0-9áéíóúÁÉÍÓÚñÑüÜ\\s]" },
            { ValidationType.Email, "[\\w@\\.\\-_]" }
        };
        public static string Get(ValidationType type) => patterns[type];
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

