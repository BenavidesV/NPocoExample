using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPocoExample.Models
{
    [TableName("Doctors")]
    [PrimaryKey("Id")]
    public class Doctor:Persona
    {
        public string Especialidad { get; set; }
        public string Horario { get; set; }
    }
}