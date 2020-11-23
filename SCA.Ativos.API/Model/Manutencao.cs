using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Ativos.API.Model
{
    public class Manutencao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
