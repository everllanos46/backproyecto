using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidad
{
    public class Paciente  
    {
        [Key]
        public string CodigoPaciente { get; set; }
        public Persona Persona{get; set;}
        
        [NotMapped]
        public List<Cita> Citas { get; set; }

    }
}
