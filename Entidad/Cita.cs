using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Cita 
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoCita { get; set; }
        public string Hora{get; set;}
        public string Fecha{get; set;}
        public Paciente Paciente{get; set;}
        public Psicologo Psicologo{get; set;}
        public string Estado{get; set;}

    }
}
