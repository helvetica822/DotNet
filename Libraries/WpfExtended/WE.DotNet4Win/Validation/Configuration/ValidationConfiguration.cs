using System.ComponentModel.DataAnnotations;

namespace WE.DotNet4Win.Validation.Configuration
{

    public class ValidationConfiguration
    {

        private ValidationConfiguration() { }

        public static Func<ValidationAttribute, Type>? DefaultErrorMessageResourceTypeProvider { get; set; }

        public static Func<ValidationAttribute, string>? DefaultErrorMessageResourceNameProvider { get; set; }

    }

}