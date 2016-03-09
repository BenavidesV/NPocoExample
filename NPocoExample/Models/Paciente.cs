using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPocoExample.Models
{
    [TableName("Pacientes")]
    public class Paciente : Persona
    {
        public string Domicilio { get; set; }
       
    }
}