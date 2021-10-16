using Microsoft.AspNetCore.Mvc;
using Logica;
using Entidad;
using Datos;
using Back.Models;
using Microsoft.AspNetCore.Http;


namespace Back.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class PacienteController: ControllerBase{
        private PacienteService _pacienteService;
        public PacienteController (ConsultorioContext context){
            _pacienteService = new PacienteService(context);
        }
        [HttpPost]
        public ActionResult<PacienteViewModel> GuardarPaciente(PacienteInputModel pacienteInput){
            Paciente paciente = Mapear(pacienteInput);
            var response = _pacienteService.GuardarPaciente(paciente);
            if(response.Error){
                ModelState.AddModelError("Error al guardar al paciente", response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(response.Estado.Equals("EXISTE"))   detalleProblemas.Status=StatusCodes.Status302Found;
                if(response.Error.Equals("ERROR"))   detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            response.Mensaje="Paciente Guardado";
            return Ok(response);
        }

        private Paciente Mapear(PacienteInputModel pacienteInput){
            var paciente = new Paciente{
                CodigoPaciente = pacienteInput.CodigoPaciente,
                Persona = pacienteInput.Persona,

            };
            return paciente;
        }

    }
}