using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    public class User : IdentityUser
    {
        public string Skin { get; set; }
        public string Language { get; set; }
        public byte[] Avatar { get; set; }
    }
}
