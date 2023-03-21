﻿using System.ComponentModel.DataAnnotations;

namespace SuperChatsWebAPI.Models
{
    public class RegisterDTO
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }

        [Required]
        public string NickName { get; set; }
    }
}
