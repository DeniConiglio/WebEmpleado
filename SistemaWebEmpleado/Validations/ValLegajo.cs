using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebEmpleado.Validations
{
    public class ValLegajo : ValidationAttribute
    {
        public ValLegajo()
        {
            ErrorMessage = "El formato del legajo debe tener 2 letras (AA) y 5 numeros";
        }

        public override bool IsValid(object value)
        {
            string legajo = Convert.ToString(value);

        
            legajo.Replace(" ", "");

           
            if (legajo.Substring(0, 2) == "AA" && int.TryParse(legajo.Replace("AA", ""), out int numLegajo) && legajo.Replace("AA", "").Length == 5)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}