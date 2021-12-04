using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MongoDB.Domain.ValidationsAttribute
{
    public class RequiredField : ValidationAttribute
    {
        
        private string ErrorMessage { get; set; } = "Campo Obrigatório";

        public RequiredField(string errorMessage)
        {
            if(errorMessage != string.Empty)
                this.ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            return null;
        }
 
    }
}