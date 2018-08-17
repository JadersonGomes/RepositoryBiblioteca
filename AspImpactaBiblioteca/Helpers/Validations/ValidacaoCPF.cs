using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspImpactaBiblioteca.Helpers
{
    public class ValidacaoCPF : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            bool valido = ValidateCPF.CPF(value.ToString());

            return valido;
        }

        
       

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.FormatErrorMessage(null),
                ValidationType = "validacaocpf"
            };
        }
    }
}