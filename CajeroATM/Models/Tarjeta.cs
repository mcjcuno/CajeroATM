using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace CajeroATM.Models
{
    public class Tarjeta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(19)]
        public string NumeroTarjeta { get; set; }

        [Required]
        [StringLength(4)]
        public string PIN { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        public bool Bloqueado { get; set; }
    }
}
