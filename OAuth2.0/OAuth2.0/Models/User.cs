using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth2._0.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Senha em texto simples apenas para fins de demonstração
    }
}