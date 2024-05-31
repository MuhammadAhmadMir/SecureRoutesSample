using SecureRoutesSample.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace SecureRoutesSample.Web.Data
{
    public enum UserRole
    {
        Admin,
        User
    }

    public class UserData
    {
        public List<User> Users { get; set; }

        public UserData()
        {
            Users =
            [
                new User { Id = 1, Name = "Alice", EmailAddress = "alice@example.com", Password = "alice@123", Role = UserRole.Admin },
                new User { Id = 2, Name = "Bob", EmailAddress = "bob@example.com", Password = "bob@123", Role = UserRole.User }
            ];
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void RemoveUser(int id) => Users.RemoveAll(u => u.Id == id);

        public User GetUserById(int id) => Users.Find(u => u.Id == id);

        public User GetUser(string emailAddress, string password)
            => Users.Find(u => u.EmailAddress == emailAddress && u.Password == password);
    }
}
