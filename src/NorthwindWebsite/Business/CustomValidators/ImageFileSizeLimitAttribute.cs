﻿using NorthwindWebsite.Core.ApplicationSettings;
using System.ComponentModel.DataAnnotations;

namespace NorthwindWebsite.Business.CustomValidators
{
    public class ImageFileSizeLimitAttribute : ValidationAttribute
    {
        private const int bytesInKilobyte = 1000;

        private const string ErrorMessage = "The file is too large. Maximum file size is {0} kB.";

        private int size;

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var appsettings = validationContext.GetService<AppSettings>();

            var uploadedFile = value as IFormFile;

            size = appsettings!.FileUploadOptions.ImageMaxSize;

            if (uploadedFile.Length > size)
            {
                return new ValidationResult(string.Format(ErrorMessage, size / bytesInKilobyte));
            }

            return ValidationResult.Success;
        }
    }
}
