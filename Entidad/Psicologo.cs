using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Psicologo 
    {
        [Key]
        public string CodigoPsicologo {get; set;}
        public Persona Persona {get; set;}
        public double Salario { get; set; }
        [NotMapped]
        public List<Cita> citas{get; set;}
    }
}