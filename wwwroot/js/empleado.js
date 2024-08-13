window.onload = Console();
window.onload = MostrarEmpleados();

function MostrarEmpleados() {
  $.ajax({
    url: "../Empleados/CargarLista",
    data: {},
    type: "POST",
    dataType: "json",
    success: function (listadoEmpleados) {
      let tabla = "";

      $.each(listadoEmpleados, function (index, empleados) {
        tabla += `
                        <tr>
                            
                            <td>${empleados.nombreEmpleado}</td>
                            <td>${empleados.fechaNacimiento}</td>
                            <td>${empleados.domicilio}</td>
                            
                            <td>${empleados.email}</td>
                            <td>${empleados.telefono}</td>
                            <td>${empleados.salario}</td>
                            <td></td>
                            <td>
                                <button type="button" class="btn btn-primary" onclick="ModalEditar(${empleados.empleadoId})">EDITAR</button>
                            </td>
                            <td>
                                <button type="button" class="btn btn-danger" onclick="ValidacionEliminar(${empleados.empleadoId})">ELIMINAR</button>
                            </td>
                        </tr>
                `;
      });
      document.getElementById("body-tabla").innerHTML = tabla;
    },
    error: function (xhr, status) {
      // Función que se ejecuta si hay un error
      console.error("Mensaje error");
    },
  });
}
function Console() {
  console.log("JS Funcion");
}

function LimpiarModal() {
  console.log("Limpiar funciona");
}

function CargarEmpleado() {
  let empleadoId = document.getElementById("empleadoId").value;
  let nombre = document.getElementById("nombre").value;
  let fechaNacimiento = document.getElementById("fecha").value;
  let domicilio = document.getElementById("domicilio").value;
  let email = document.getElementById("email").value;
  let telefono = document.getElementById("telefono").value;
  let salario = document.getElementById("salario").value;

  $.ajax({
    url: "../Empleados/GuardarEmpleado", 
    data: {empleadoId: empleadoId, nombre: nombre, fechaNacimiento: fechaNacimiento, domicilio: domicilio, email: email, telefono: telefono, salario:salario},
    type: "POST", 
    dataType: "json", 
    success: function(resultado) {
        
        console.log(resultado);
    },
    error: function(xhr, status) {
        // Función que se ejecuta si hay un error
        console.error("Mensaje error");
    }
});

}

function ValidacionEliminar (empleadoId) {
    var eliminar = confirm("Desea eliminar empleado?");
    if (eliminar == true) {
        EliminarEmpleado(empleadoId);
    }

}

function EliminarEmpleado(empleadoId) {
    $.ajax({
        url: "../Empleados/Eliminar", 
        data: {EmpleadoId: empleadoId},
        type: "POST", 
        dataType: "json", 
        success: function(resultado) {
            MostrarEmpleados();
            console.log(resultado);
        },
        error: function(xhr, status) {
            
            console.error("Mensaje error");
        }
    });
}
