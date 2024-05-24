﻿using Microsoft.AspNetCore.Identity;

namespace Diplom.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public List<App> Apps { get; set; } = [];
    }
}
