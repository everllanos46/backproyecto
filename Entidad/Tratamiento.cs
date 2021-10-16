using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Tratamiento
    {
        [Key] 
        public string Codigo{get; set;}
        public string Recomendacion{get; set;}
        public string Diagnostico{get; set;}
        [NotMapped]
        public List<Medicamento> Medicamentos{get; set;} 
    }
}