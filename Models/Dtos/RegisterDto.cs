﻿using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
