using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WE.DotNet4Win.Validation.Configuration;

namespace WE.DotNet4Win.Extensions
{

    public static class ValidationAttributeExtensions
    {

        public static void SetupErrorMessageResource(this ValidationAttribute attribute)
        {
            attribute.SetupErrorMessageResource(ValidationConfiguration.DefaultErrorMessageResourceTypeProvider, ValidationConfiguration.DefaultErrorMessageResourceNameProvider);
        }

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType)
        {
            attribute.SetupErrorMessageResource(errorMessageResourceType, ValidationConfiguration.DefaultErrorMessageResourceNameProvider);
        }

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType, Func<ValidationAttribute, string>? errorMessageResourceNameProvider)
        {
            if (errorMessageResourceNameProvider is null) throw new Exception($"{nameof(errorMessageResourceNameProvider)} Ç™èâä˙âªÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB");
            attribute.SetupErrorMessageResource(errorMessageResourceType, errorMessageResourceNameProvider.Invoke(attribute));
        }

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Func<ValidationAttribute, Type>? errorMessageResourceTypeProvider, Func<ValidationAttribute, string>? errorMessageResourceNameProvider)
        {
            if (errorMessageResourceTypeProvider is null) throw new Exception($"{nameof(errorMessageResourceTypeProvider)} Ç™èâä˙âªÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB");
            if (errorMessageResourceNameProvider is null) throw new Exception($"{nameof(errorMessageResourceNameProvider)} Ç™èâä˙âªÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒÅB");
            attribute.SetupErrorMessageResource(errorMessageResourceTypeProvider.Invoke(attribute), errorMessageResourceNameProvider.Invoke(attribute));
        }

        public static void SetupErrorMessageResource(this ValidationAttribute attribute, Type errorMessageResourceType, string errorMessageResourceName)
        {
            var t = typeof(ValidationAttribute);

            var field = GetBackingField(t, nameof(attribute.ErrorMessage));
            if (field is null) return;

            var errorMessage = field.GetValue(attribute) as string;
            if (!string.IsNullOrWhiteSpace(errorMessage)) return;

            attribute.ErrorMessageResourceType ??= errorMessageResourceType;
            attribute.ErrorMessageResourceName ??= errorMessageResourceName;
        }

        private static FieldInfo? GetBackingField(Type t, string propertyName)
        {
            var firstCharacter = propertyName[0].ToString().ToLower();
            var fieldName = $"_{firstCharacter}{new string(propertyName.ToCharArray(1, propertyName.Length - 1))}";
            return t.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

    }
}