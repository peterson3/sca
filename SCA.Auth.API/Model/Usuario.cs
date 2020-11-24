using System.ComponentModel.DataAnnotations;

namespace SCA.Auth.API.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
