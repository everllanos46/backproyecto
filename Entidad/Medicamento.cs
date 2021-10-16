using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Medicamento
    {
        [Key] 
        public string CodigoMedicamento { get; set; }
        public string Nombre{get;set;}
        public string Instrucciones{get; set;}
    }
}