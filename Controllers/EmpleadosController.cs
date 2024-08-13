using empleados.Data;
using Microsoft.AspNetCore.Mvc;
using empleados.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EmpleadosController : Controller
{
    private ApplicationDbContext _context;
    //constructor
    public EmpleadosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        /* var selectListItems = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "[SELECCIONE...]" }
        };

        var provincias = _context.Provincias.ToList();
        var provinciasListItems = provincias.Select(p => new SelectListItem
        {   
            Value = p.ProvinciaId.ToString(),
            Text = p.NombreProvincia
        }).ToList();
        ViewBag.Provincias = provinciasListItems;
        ViewBag.List = new SelectList(provinciasListItems, "Text", "Value"); */
        return View();
    }

    public IActionResult GuardarEmpleado(int empleadoId, string nombre, DateOnly fechaNacimiento, string domicilio, string email, string telefono, int salario)
    {
        string resultado = "";

        if (empleadoId == 0) {
            var nuevoEmpleado = new Empleado {
                NombreEmpleado = nombre,
                FechaNacimiento = fechaNacimiento,
                Domicilio = domicilio,
                Email = email,
                Telefono = telefono,
                Salario = salario,
            };
            _context.Add(nuevoEmpleado);
            _context.SaveChanges();
            resultado = "Empleado agregado";
        }
        else {
            var editarEmpleado = _context.Empleados.Where(e => e.EmpleadoId == empleadoId).SingleOrDefault();
            if (editarEmpleado != null)
            {
                editarEmpleado.NombreEmpleado = nombre;
                editarEmpleado.FechaNacimiento = fechaNacimiento;
                editarEmpleado.Domicilio = domicilio;
                editarEmpleado.Email = email;
                editarEmpleado.Telefono = telefono;
                editarEmpleado.Salario = salario;
                _context.SaveChanges();
                resultado = "Se modifico";
            }
        } 
        return Json(resultado);
    }


public IActionResult CargarLista (int? EmpleadoId) {
    var listaEmpleados = _context.Empleados.ToList();
    

    if (EmpleadoId != null)
    {
        listaEmpleados = _context.Empleados.Where(l => l.EmpleadoId == EmpleadoId).ToList();
        listaEmpleados = _context.Empleados.OrderByDescending(l => l.NombreEmpleado).ToList();
    }
        return Json (listaEmpleados);
}

public IActionResult Eliminar(int EmpleadoId) {
    
    
    var eliminarEmpleado = _context.Empleados.Find(EmpleadoId);
    _context.Remove(eliminarEmpleado);
    _context.SaveChanges();
    
    return Json(eliminarEmpleado);
}

}