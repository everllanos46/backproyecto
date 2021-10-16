using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidad
{
    public class Historial
    {
        [Key]
        public int CodigoHistorial{get; set;}
        public Paciente Paciente{get; set;}
        
    }
}