using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrimeSystems.Models
{
    public class UserModel
    {
        public int? id;
        public required string username;
        public required string password;
        public required string name;
        public required string surname;
        public required string phone;
        public required string email;
        public required int person_id;
        public required char p_buy;
        public required char p_sells;
        public required char p_hhrr;
        public required char p_contable;
    }
}
