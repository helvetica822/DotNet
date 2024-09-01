using WE.DotNetStandard4Win.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace WE.DotNetStandard4Win.Validation.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomRequiredAttribute : RequiredAttribute
    {

        public CustomRequiredAttribute()
        {
            this.SetupErrorMessageResource();
        }

    }

}