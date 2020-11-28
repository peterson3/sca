using System.ComponentModel.DataAnnotations;

namespace SCA.Auth.API.Model
{
    public class Funcao

    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
