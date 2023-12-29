﻿namespace AcademiaFS.Proyecto.Inventario._Features.Auth.Dto
{
    public static class DatosSesion
    {
        public static int IdUsuario { get; set; }
        public static int? IdPerfil { get; set; }
        public static bool EsAdmin { get; set; }

        public static bool HasLoginInfo() 
        {
            return IdUsuario != 0; 
        }
    }
}
