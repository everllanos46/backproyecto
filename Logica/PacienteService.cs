using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class PacienteService
    {
        private ConsultorioContext _consultorioContext;

        public PacienteService(ConsultorioContext context)
        {
            _consultorioContext = context;
        }

        public SaveResponse GuardarPaciente(Paciente paciente)
        {
            try
            {
                var response = _consultorioContext.pacientes.Find(paciente.CodigoPaciente);
                if (response == null)
                {
                    response = _consultorioContext.pacientes.Where(p => p.Persona.Usuario.Equals(paciente.Persona.Usuario)).FirstOrDefault();
                    if (response == null)
                    {
                        _consultorioContext.Add(paciente);
                        _consultorioContext.SaveChanges();
                        return new SaveResponse(paciente);
                    } else return new SaveResponse("Ya se encuentra un paciente con este usuario", "EXISTE");

                }
                else return new SaveResponse("Ya se encuentra un paciente con esta identificación", "EXISTE");
            }
            catch (Exception e)
            {
                return new SaveResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public LoginResponse LoginPaciente(string username, string password){
            var response = _consultorioContext.pacientes.Where(p=>p.Persona.Usuario.Equals(username) && p.Persona.password.Equals(password)).FirstOrDefault();
            if(response == null){
                var responsep = _consultorioContext.psicologos.Where(p=>p.Persona.Usuario.Equals(username) && p.Persona.password.Equals(password)).FirstOrDefault();
                if(responsep == null){
                    return new LoginResponse(false, "null");
                }else return new LoginResponse(true, "psicologo");
            }  else return new LoginResponse(true, "paciente");
        }


    }

    

    public class SaveResponse
    {

        public SaveResponse(Paciente paciente)
        {
            Error = false;
            Paciente = paciente;
            Estado = "Guardado";
        }

        public SaveResponse(string message, string estate)
        {
            Error = true;
            Mensaje = message;
            Estado = estate;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Paciente Paciente { get; set; }
        public string Estado { get; set; }
    }

    public class LoginResponse{
        public LoginResponse(bool state, string role)
        {
         Login=state;
         Rol=role;   
        }
        public bool Login{get; set;}
        public string Rol{get; set;}
    }
}
