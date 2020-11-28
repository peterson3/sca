using Newtonsoft.Json;
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

        public bool IsRealizada { get; set; }

        [JsonIgnore]
        public Ativo Ativo { get; set; }

    }
}
