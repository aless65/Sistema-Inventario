using AcademiaFS.Proyecto.Inventario._Common;
using System.Drawing.Drawing2D;

namespace SistemaInventario._Common
{
    public static class Mensajes
    {
        public const string PROCESO_EXITOSO = "Operación exitosa";
        public const string PROCESO_FALLIDO = "Error. Intente más tarde";
        public const string LLAVE_FORANEA = "Hay un conflicto con las llaves foráneas. Verifique los datos e intente de nuevo o comuníquese con programación.";
        public const string SEXO_INVALIDO = "El sexo debe ser F o M";
        public const string LOGIN_EXITOSO = "Sesión iniciada";
        public const string LOGIN_FALLIDO = "El nombre de usuario o la contraseña son incorrectos";
        public const string NO_AUTORIZADO = "No tiene los permisos para ejecutar esta acción";
        public const string STOCK_INSUFICIENTE = "No hay suficiente stock";

        public static string OPERACION_EXITOSA(string nombreOperacion)
        {
            return $"El registro ha sido {nombreOperacion} correctamente";
        }

        public static string CAMPO_VACIO(string nombrePropiedad)
        {
            return $"El campo '{nombrePropiedad}' es requerido";
        }

        public static string LONGITUD_ERRONEA(string nombrePropiedad, int numeroCaracteres)
        {
            return $"El campo '{nombrePropiedad}' no cumple con el número de caracteres permitidos ({numeroCaracteres})";
        }

        public static string CAMPO_MAYOR(string nombrePropiedad, int cantidad)
        {
            return $"El campo '{nombrePropiedad}' debe ser mayor que {cantidad}";
        }

        public static string CAMPO_MENOR(string nombrePropiedad, int cantidad)
        {
            return $"El campo '{nombrePropiedad}' debe ser menor que {cantidad}";
        }

        public static string REPETIDO(string nombrePropiedad)
        {
            return $"Este(a) {nombrePropiedad} ya existe";
        }

        public static string NO_EXISTE(string nombrePropiedad)
        {
            return $"El/la '{nombrePropiedad}' no existe";
        }

        public static string LIMITE_SUCURSAL(int cantidad)
        {
            return $"Esta sucursal cuenta con más de L. {cantidad} en salidas enviadas";
        }
    }
}
