using PrimeSystems.Models;

namespace PrimeSystems.Core
{
    public static class Session
    {
        public static UserModel? CurrentUser { get; set; }
    }
}
