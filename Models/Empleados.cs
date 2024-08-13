using System.ComponentModel.DataAnnotations;

namespace empleados.Models {
    public class Empleado {
        [Key]
        public int EmpleadoId {get; set;}
        /* public int ProvinciaId {get; set;} */
        public string? NombreEmpleado {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public string? Domicilio {get; set;}
        public string? Email {get; set;}
        public string? Telefono {get; set;}
        public int Salario {get; set;}

        /* public virtual Provincia Provincias {get;set;} */
    }

    /* public class VistaEmpleado {
        public int EmpleadoId {get; set;}
        public int ProvinciaId {get; set;}
        public string? NombreProvincia {get; set;}
        public string? NombreEmpleado {get; set;}
        public DateOnly FechaNacimiento {get; set;}
        public string? Domicilio {get; set;}
        public string? Email {get; set;}
        public string? Telefono {get; set;}
        public int Salario {get; set;}
    } */
}