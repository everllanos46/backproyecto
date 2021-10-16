using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class ConsultorioContext :DbContext
    {
        public ConsultorioContext(DbContextOptions options) : base(options)
        {
            
        }
        //public DbSet<Persona> personas{get; set;}
        public DbSet<Paciente> pacientes{get; set;}
        public DbSet<Cita> citas{get; set;}
        public DbSet<Historial> historiales{get;set;}
        public DbSet<Medicamento> medicamentos{get; set;}
        public DbSet<Persona> personas{get; set;}
        public DbSet<Psicologo> psicologos{get; set;}
        public DbSet<Tratamiento> tratamientos{get; set;}

    }
}
