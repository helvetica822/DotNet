using WE.DotNetStandard4Win.Validation.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WE.DotNetStandard4Win.Extensions
{

    public static class ValidationAttributeExtensions
    {

        public static void SetupErrorMessageResource(this ValidationAttribute attribute) =>
            attribute.SetupErrorMessageResource(ValidationConfiguration.DefaultErrorMessageResourceTypeProvider, ValidationConfiguration.DefaultErrorMessageResourceNameProvider);

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType) =>
            attribute.SetupErrorMessageResource(errorMessageResourceType, ValidationConfiguration.DefaultErrorMessageResourceNameProvider);

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType, Func<ValidationAttribute, string> errorMessageResourceNameProvider) =>
            attribute.SetupErrorMessageResource(errorMessageResourceType, errorMessageResourceNameProvider.Invoke(attribute));

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Func<ValidationAttribute, Type> errorMessageResourceTypeProvider, Func<ValidationAttribute, string> errorMessageResourceNameProvider) =>
            attribute.SetupErrorMessageResource(errorMessageResourceTypeProvider.Invoke(attribute), errorMessageResourceNameProvider.Invoke(attribute));

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType, string errorMessageResourceName)
        {
            var t = typeof(ValidationAttribute);

            var field = GetBackingField(t, nameof(attribute.ErrorMessage));
            if (field == null) return;

            var errorMessage = field.GetValue(attribute) as string;
            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            if (attribute.ErrorMessageResourceType == null) attribute.ErrorMessageResourceType = errorMessageResourceType;
            if (attribute.ErrorMessageResourceName == null) attribute.ErrorMessageResourceName = errorMessageResourceName;
        }

        private static FieldInfo GetBackingField(Type t, string propertyName)
        {
            var firstCharacter = propertyName[0].ToString().ToLower();
            var fieldName = $"_{firstCharacter}{new string(propertyName.ToCharArray(1, propertyName.Length - 1))}";
            return t.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

    }
}