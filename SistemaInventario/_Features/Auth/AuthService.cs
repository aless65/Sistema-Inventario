using AcademiaFS.Proyecto.Inventario._Features.Auth.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using SistemaInventario._Common;

namespace AcademiaFS.Proyecto.Inventario._Features.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(UnitOfWorkBuilder unitOfWork)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
        }

        public Respuesta<UsuarioListarDto> Login(string nombre, string contrasena)
        {
            var contrasenaString = EncriptarClave.GenerateSHA512Hash(contrasena);
            var contrasenaHash = EncriptarClave.HashedString(contrasenaString);

            var respuesta = (from usua in _unitOfWork.Repository<Usuario>().AsQueryable()
                             join empl in _unitOfWork.Repository<Empleado>().AsQueryable()
                             on usua.IdEmpleado equals empl.IdEmpleado into emplleft 
                             from subempl in emplleft.DefaultIfEmpty()
                             join perf in _unitOfWork.Repository<Perfil>().AsQueryable()
                             on usua.IdPerfil equals perf.IdPerfil into perfleft
                             from subperf in perfleft.DefaultIfEmpty()
                             where usua.Nombre == nombre && usua.Contrasena == contrasenaHash && usua.Activo == true
                             select new UsuarioListarDto
                             {
                                 IdUsuario = usua.IdUsuario,
                                 Nombre = usua.Nombre,
                                 IdPerfil = usua.IdPerfil,
                                 NombrePerfil = subperf.Nombre ?? string.Empty,
                                 IdEmpleado = usua.IdEmpleado,
                                 NombreEmpleado = subempl.Nombres + subempl.Apellidos ?? string.Empty,
                                 EsAdmin = usua.EsAdmin,
                             }).FirstOrDefault();

            if (respuesta != null)
            {
                DatosSesion.IdUsuario = respuesta.IdUsuario;
                DatosSesion.IdPerfil = respuesta.IdPerfil;
                DatosSesion.EsAdmin = respuesta.EsAdmin;

                return Respuesta.Success(respuesta, Mensajes.LOGIN_EXITOSO, Codigos.Success);
            }
            else
                return Respuesta.Fault< UsuarioListarDto>(Mensajes.LOGIN_FALLIDO, Codigos.NotFound);
        }
    }
}
