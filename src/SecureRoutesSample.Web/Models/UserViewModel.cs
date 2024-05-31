using SecureRoutesSample.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace SecureRoutesSample.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Required]
        public string EmailAddress { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
        public UserRole Role { get; set; }
    }
}
