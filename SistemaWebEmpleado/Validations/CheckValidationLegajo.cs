using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaWebEmpleado.Validations
{
    public class CheckValidationLegajo:ValidationAttribute
    {
        public CheckValidationLegajo() 
        {
            ErrorMessage= "El legajo es incorrecto, tiene que comenzar con AA seguido de 5 numeros.";
        }

        public override bool IsValid(object value)
        {
            string cadena = value as string;

            if(cadena.Length > 7)
            {
                return false;
            }
            else
            {
                if (cadena[0] == 'A' && cadena[1] == 'A')
                {
                    string num = Regex.Match(cadena, @"\d+").Value;
                    if (num.Length == 5)
                    {
                        return true;
                    }  
                }
                return false;
            }
        }
    }
}
