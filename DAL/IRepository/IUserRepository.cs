﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface IUserRepository
    {
        void ActivateUser(int id);
        void Create(User user);
        void DesactivateUser(int id);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Update(User user);
        int VerifyEmail(string email);
    }
}