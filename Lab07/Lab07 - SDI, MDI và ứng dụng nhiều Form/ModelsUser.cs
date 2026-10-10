namespace ShopManagerMini.Models
{
    /// <summary>
    /// Thông tin người dùng đăng nhập hệ thống.
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }   // "Admin" hoặc "User"

        public User() { }

        public User(string username, string password, string fullName, string role)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            Role = role;
        }

        public override string ToString()
        {
            return FullName + " (" + Role + ")";
        }
    }
}