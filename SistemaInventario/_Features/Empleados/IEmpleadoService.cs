using AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Empleados
{
    public interface IEmpleadoService
    {
        Respuesta<List<EmpleadoDto>> ListarEmpleados();
        Respuesta<EmpleadoDto> InsertarEmpleados(EmpleadoDto empleadoDto);
        Respuesta<EmpleadoDto> EditarEmpleados(EmpleadoDto empleadoDto);
        Respuesta<string> EliminarEmpleados(int id);
    }
}
