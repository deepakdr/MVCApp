using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords)
            : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class MovieReview : IValidatableObject
    {
        
        public int Id { get; set; }
        public int MovieId { get; set; }

        [Range(1, 10, ErrorMessage = "Please rate between 1 - 10")]
        public int Review { get; set; }
        
        [MaxWords(3)]
        [Display(Name = "User Name")]
        public string ReviewerName { get; set; }

        [MaxLength(250)]
        public string Body { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Review < 2 && ReviewerName.ToLower().StartsWith("dee"))
            {
                yield return new ValidationResult("Not allowed");
            }
        }
    }
}