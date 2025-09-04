using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using PrimeSystems.Controllers;
using PrimeSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems.Data
{
    public static class UserRepository
    {
        public static List<UserModel> GetAll()
        {
            var users = new List<UserModel>();
            string query = "SELECT * FROM Usuarios";

            using var reader = Database.ExecuteReader(query);
            while (reader.Read())
            {
                users.Add(new UserModel
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    person_id = reader.GetInt32(reader.GetOrdinal("person_id")),
                    username = reader.GetString(reader.GetOrdinal("username")),
                    password = reader.GetString(reader.GetOrdinal("password")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                    surname = reader.GetString(reader.GetOrdinal("surname")),
                    phone = reader.GetString(reader.GetOrdinal("phone")),
                    email = reader.GetString(reader.GetOrdinal("email")),
                    p_buy = reader.GetString(reader.GetOrdinal("p_buy"))[0],
                    p_sells = reader.GetString(reader.GetOrdinal("p_sells"))[0],
                    p_hhrr = reader.GetString(reader.GetOrdinal("p_hhrr"))[0],
                    p_contable = reader.GetString(reader.GetOrdinal("p_contable"))[0]
                });
            }
            return users;
        }
        public static UserModel? Get(string username)
        {
        string query = "SELECT * FROM Usuarios WHERE username = @username";
            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };
            using var reader = Database.ExecuteReader(query, parameters);
            if (reader.Read())
            {
                return new UserModel
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    person_id = reader.GetInt32(reader.GetOrdinal("person_id")),
                    username = reader.GetString(reader.GetOrdinal("username")),
                    password = reader.GetString(reader.GetOrdinal("password")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                    surname = reader.GetString(reader.GetOrdinal("surname")),
                    phone = reader.GetString(reader.GetOrdinal("phone")),
                    email = reader.GetString(reader.GetOrdinal("email")),
                    p_buy = reader.GetString(reader.GetOrdinal("p_buy"))[0],
                    p_sells = reader.GetString(reader.GetOrdinal("p_sells"))[0],
                    p_hhrr = reader.GetString(reader.GetOrdinal("p_hhrr"))[0],
                    p_contable = reader.GetString(reader.GetOrdinal("p_contable"))[0]
                };
            }
            return null;
        }

        public static void Insert(UserModel user)
        {
            string query = @"
            INSERT INTO Usuarios VALUES (
                @username,
                @password,
                @name,
                @surname,
                @phone,
                @email,
                @person_id,
                @p_buy,
                @p_sells,
                @p_hhrr,
                @p_contable
            )";

            var parameters = new Dictionary<string, object> {
                { "@username", user.username},
                { "@password", user.password},
                { "@name", user.name},
                { "@surname", user.surname},
                { "@phone", user.phone},
                { "@email", user.email},
                { "@person_id", user.person_id},
                { "@p_buy", user.p_buy},
                { "@p_sells", user.p_sells},
                { "@p_hhrr", user.p_hhrr},
                { "@p_contable", user.p_contable}
            };

            Database.ExecuteNonQuery(query, parameters);
        }
        public static UserModel? CreateAdminUserIfNotExists()
        {
            string query = "SELECT TOP 1 * FROM Usuarios;";
            SqlDataReader sqlDataReader = Database.ExecuteReader(query);
            if (sqlDataReader.HasRows) return null;
            sqlDataReader.Close();
            UserModel user = new UserModel
            {
                person_id = 1,
                username = "admin",
                password = Utils.GenerateRandomString(12),
                name = "Admin",
                surname = "User",
                phone = "123456789",
                email = "admin@example.com",
                p_buy = 'Y',
                p_sells = 'Y',
                p_hhrr = 'Y',
                p_contable = 'Y'
            };
            UserRepository.Insert(user);
            return user;
        }
    }
}

