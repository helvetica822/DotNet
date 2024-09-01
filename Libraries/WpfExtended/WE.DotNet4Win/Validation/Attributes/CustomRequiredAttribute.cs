using System.ComponentModel.DataAnnotations;
using WE.DotNet4Win.Extensions;

namespace WE.DotNet4Win.Validation.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomRequiredAttribute : RequiredAttribute
    {

        public CustomRequiredAttribute() => this.SetupErrorMessageResource();

    }

}