using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Usuarios.Dtos;
using AcademiaFS.Proyecto.Inventario.Infrastructure.Inventario_AJM.Entities;
using AcademiaFS.Proyecto.Inventario.Utility;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using SistemaInventario._Common;

namespace SistemaInventario._Features.Lotes
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonService _commonService;

        public UsuarioService(UnitOfWorkBuilder unitOfWork, IMapper mapper, CommonService commonService)
        {
            _unitOfWork = unitOfWork.BuilderInventarioAjm();
            _mapper = mapper;
            _commonService = commonService;
        }

        public Respuesta<List<UsuarioListarDto>> ListarUsuarios()
        {
            try
            {
                var listado = (from usua in _unitOfWork.Repository<Usuario>().AsQueryable()
                               join empe in _unitOfWork.Repository<Empleado>().AsQueryable()
                               on usua.IdEmpleado equals empe.IdEmpleado
                               join perf in _unitOfWork.Repository<Perfil>().AsQueryable()
                               on usua.IdPerfil equals perf.IdPerfil
                               where usua.Activo == true
                               select new UsuarioListarDto
                               {
                                   IdUsuario = usua.IdUsuario,
                                   Nombre = usua.Nombre,
                                   EsAdmin = usua.EsAdmin,
                                   IdEmpleado = usua.IdEmpleado,
                                   NombreEmpleado = empe.Nombres + empe.Apellidos,
                                   IdPerfil = usua.IdPerfil,
                                   NombrePerfil = perf.Nombre
                               }).ToList();

                return Respuesta.Success(listado, Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<List<UsuarioListarDto>>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }

        public Respuesta<UsuarioDto> InsertarUsuarios(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                var contrasena = EncriptarClave.GenerateSHA512Hash(usuario.Contrasena);
                var contrasenaHash = EncriptarClave.HashedString(contrasena);

                usuario.FechaCreacion = DateTime.Now;
                usuario.IdUsuarioCreacion = 1;
                usuario.Contrasena = contrasenaHash;

                _unitOfWork.Repository<Usuario>().Add(usuario);
                _unitOfWork.SaveChanges();

                return Respuesta.Success(_mapper.Map<UsuarioDto>(usuario), Codigos.Success, Mensajes.PROCESO_EXITOSO);
            }
            catch
            {
                return Respuesta.Fault<UsuarioDto>(Codigos.Error, Mensajes.PROCESO_FALLIDO);
            }
        }
    }
}
