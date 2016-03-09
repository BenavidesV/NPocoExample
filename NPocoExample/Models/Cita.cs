using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NPocoExample.Models
{
    [PrimaryKey("Id")]
    [TableName("Citas")]
    public class Cita
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }
        [ResultColumn]
        public Doctor Doctor { get; set; }
        public int Doctor_Id { get; set; }
        [ResultColumn]
        public Paciente Paciente { get; set; }
        public int Paciente_Id { get; set; }
        public string Lugar { get; set; }
    }
}