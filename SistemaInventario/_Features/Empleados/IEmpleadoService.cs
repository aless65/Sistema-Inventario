using AcademiaFS.Proyecto.Inventario._Features.Empleados.Dtos;
using Farsiman.Application.Core.Standard.DTOs;

namespace AcademiaFS.Proyecto.Inventario._Features.Empleados
{
    public interface IEmpleadoService<T>
    {
        Respuesta<List<T>> ListarEmpleados();
        Respuesta<T> InsertarEmpleados(T empleadoDto);
        Respuesta<T> EditarEmpleados(T empleadoDto);
        Respuesta<string> EliminarEmpleados(int id);
    }
}
