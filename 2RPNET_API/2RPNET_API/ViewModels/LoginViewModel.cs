using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2RPNET_API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Senha inv�lida")]
        public string password { get; set; }

        [Required(ErrorMessage = "Email inv�lido")]
        public string email { get; set; }
    }
}