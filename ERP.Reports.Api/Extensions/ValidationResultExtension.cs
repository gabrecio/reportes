using FluentValidation.Results;
using System.Web.Http.ModelBinding;

namespace ERP.Reports.Api.Extensions
{
    public static class ValidationResultExtension
    {
        /// <summary>
        /// Stores the errors in a ValidationResult object to the specified modelstate dictionary.
        /// </summary>
        /// <param name="result">The validation result to store</param>
        /// <param name="modelState">The ModelStateDictionary to store the errors in.</param>
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
        }
    }
}