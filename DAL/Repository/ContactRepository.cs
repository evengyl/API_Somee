using ADOToolBox;
using DAL.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private Contact _contact;

        private Connection _connection;
        private string _connectionString;


        public ContactRepository()
        {
            _connectionString = @"workstation id=EvengylBstorm.mssql.somee.com;packet size=4096;user id=evengyl_SQLLogin_1;pwd=h8akttoomm;data source=EvengylBstorm.mssql.somee.com;persist security info=False;initial catalog=EvengylBstorm";
            _connection = new Connection(_connectionString);

        }

        public IEnumerable<Contact> GetAll()
        {
            return _connection.ExecuteReader<Contact>(new Command("SELECT * FROM Contact"));
        }



        public Contact Get(int id)
        {
            Command command = new Command("SELECT * FROM Contact WHERE UserId = @UserId");
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader<Contact>(command).SingleOrDefault();
        }


        public void Create(Contact contact)
        {
            Command command = new Command("INSERT INTO Contact (UserName, Gsm, Email, Message) " +
                "VALUES (@UserName, @Gsm, @Email, @Message) ");

            command.AddParameter("UserName", (contact.UserName is null) ? "Default" : contact.UserName);
            command.AddParameter("Gsm", (contact.Gsm is null) ? "Default" : contact.Gsm);
            command.AddParameter("Email", (contact.Email is null) ? "Default" : contact.Email);
            command.AddParameter("Message", (contact.Message is null) ? "Default" : contact.Message);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(Contact contact)
        {
            Command command = new Command("UPDATE Contact SET UserName = @UserName, Gsm = @Gsm," +
                                                            "Email = @Email, Message = @Message WHERE UserId = @UserId");

            command.AddParameter("UserName", contact.UserName);
            command.AddParameter("Gsm", contact.Gsm);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("Message", contact.Message);
            command.AddParameter("UserId", contact.UserId);

            _connection.ExecuteNonQuery(command);
        }








    }
}
