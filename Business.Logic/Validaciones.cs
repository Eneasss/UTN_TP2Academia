using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Business.Logic
{
    public class Validaciones
    {
        public static bool esMailValido(string correoIngresado)
        {
            string expresionCorrecta = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(correoIngresado, expresionCorrecta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool esCampoValido(string cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool esPrivilegioValido(string PrivilegioIngresado)
        {
            if (PrivilegioIngresado == "Administrador" || PrivilegioIngresado == "Alumno" || PrivilegioIngresado == "Profesor")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CuposValidos(int id)
        {
            CursoLogic cl = new CursoLogic();
            if (cl.GetOne(id).Cupo == 0)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los cursos.");
                throw ExcepcionManejada;
            }
            return true;
        }

        public static Boolean esNumeroValido(string numero)
        {
            if (Regex.IsMatch(numero, @"^[0-9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean esNotaValida(string nota)
        {
            if (esNumeroValido(nota))
            {

                if (int.Parse(nota) > 0 && int.Parse(nota) <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
