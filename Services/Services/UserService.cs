﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Services.DTOs;

namespace Services.Services
{
    internal class UserService
    {
        public async Task<int> AddUser(UserDTO dto)
        {
            return 0;
        }
        public void UpdateUser(int id, UserDTO dto)
        {

        }
        public async Task<List<IdentityUser>> GetUsers()
        {
            return null;
        }
    }
}
