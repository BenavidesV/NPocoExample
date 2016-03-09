using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPocoExample.Models
{
    [PrimaryKey("Id")]
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Column("email")]
        public string Email { get; set; }
        public int Telefono { get; set; }
    }
}