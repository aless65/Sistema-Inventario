using AcademiaFS.Proyecto.Inventario._Features.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcademiaFS.Proyecto.Inventario.Utility
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (DatosSesion.IdUsuario <= 0)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
