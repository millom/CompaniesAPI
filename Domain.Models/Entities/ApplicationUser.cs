﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
       // public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; set; }

        public Guid CompanyId { get; set; }

        //Navigation Property
        public Company? Company { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }

    }
}
