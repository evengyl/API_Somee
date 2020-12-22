using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.IRepository;
using DAL.Repository;

namespace ApiCoreForSomee.Services
{
    public class ApiControllerUse : IApiControllerUse
    {
        private IUserRepository userRepo;
        public ApiControllerUse()
        {
            userRepo = new UserRepository();
        }


        public void ActivateUser(int id)
        {
            userRepo.ActivateUser(id);
        }
        public void Create(User user)
        {
            userRepo.Create(user);
        }
        public void DesactivateUser(int id)
        {
            userRepo.DesactivateUser(id);
        }
        public User Get(int id)
        {
            return userRepo.Get(id);
        }
        public IEnumerable<User> GetAll()
        {
            return userRepo.GetAll();
        }
        public void Update(User user)
        {
            userRepo.Update(user);
        }

        public int VerifyEmail(string email)
        {
            return userRepo.VerifyEmail(email);
        }
    }
}
