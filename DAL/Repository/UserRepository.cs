using ADOToolBox;
using DAL.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private User _user;

        private Connection _connection;
        private string _connectionString;


        public UserRepository()
        {
            _connectionString = @"workstation id=EvengylBstorm.mssql.somee.com;packet size=4096;user id=evengyl_SQLLogin_1;pwd=h8akttoomm;data source=EvengylBstorm.mssql.somee.com;persist security info=False;initial catalog=EvengylBstorm";
            _connection = new Connection(_connectionString);

        }

        public IEnumerable<User> GetAll()
        {
            return _connection.ExecuteReader<User>(new Command("SELECT * FROM Users"));
        }



        public User Get(int id)
        {
            Command command = new Command("SELECT * FROM Users WHERE UserId = @UserId");
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader<User>(command).SingleOrDefault();
        }


        public void Create(User user)
        {
            Command command = new Command("INSERT INTO Users (LastName, FirstName, Password, Email, Active) " +
                "VALUES (@LastName, @FirstName, @Password, @Email, @Active) ");

            command.AddParameter("FirstName", (user.FirstName is null) ? "Default" : user.FirstName);
            command.AddParameter("LastName", (user.LastName is null) ? "Default" : user.LastName);
            command.AddParameter("Password", (user.Password is null) ? "Default" : user.Password);
            command.AddParameter("Email", (user.Email is null) ? "Default" : user.Email);
            command.AddParameter("Active", user.Active);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(User user)
        {
            Command command = new Command("UPDATE Users SET LastName = @LastName, FirstName = @FirstName, Password = @Password," +
                                                            "Email = @Email, Active = @Active WHERE UserId = @id");

            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("Password", user.Password);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Active", user.Active);
            command.AddParameter("id", user.UserId);

            _connection.ExecuteNonQuery(command);
        }

        public int VerifyEmail(string email)
        {
            Command command = new Command("SELECT UserId FROM Users WHERE Email = @Email");

            command.AddParameter("Email", email);
            

            int id = (int)_connection.ExecuteScalar(command);
            return id;
        }


        public void DesactivateUser(int id)
        {
            Command command = new Command("UPDATE Users SET Active = @Active WHERE UserId = @id");

            command.AddParameter("Active", false);
            command.AddParameter("id", id);

            _connection.ExecuteNonQuery(command);
        }

        public void ActivateUser(int id)
        {
            Command command = new Command("UPDATE Users SET Active = @Active WHERE UserId = @id");

            command.AddParameter("Active", true);
            command.AddParameter("id", id);

            _connection.ExecuteNonQuery(command);
        }





    }
}
