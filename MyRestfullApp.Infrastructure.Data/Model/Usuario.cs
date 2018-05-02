using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestfullApp.Infrastructure.Data.Model
{
    [Table("User")]
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
