using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        Contact Get(int id);
        IEnumerable<Contact> GetAll();
        void Update(Contact contact);
    }
}