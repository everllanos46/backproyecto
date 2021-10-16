using System.Collections.Generic;
using Entidad;

namespace Back.Models
{
    public class PacienteInputModel
    {
        public string CodigoPaciente { get; set; }
        public Persona Persona { get; set; }

    }

    public class PacienteViewModel : PacienteInputModel
        {
            public PacienteViewModel()
            {

            }
            public PacienteViewModel(Paciente paciente)
            {
                CodigoPaciente = paciente.CodigoPaciente;
                Persona = paciente.Persona;

            }

        }


}