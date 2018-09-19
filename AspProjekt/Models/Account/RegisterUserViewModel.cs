﻿using System.ComponentModel.DataAnnotations;

namespace AspProjekt.Models.Account
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Email{ get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
