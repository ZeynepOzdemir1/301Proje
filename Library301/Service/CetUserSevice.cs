using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Library301;
using Microsoft.EntityFrameworkCore;

namespace Library301.Service
{
    public class CetUserService
    {
        private LibraryDbContext db;
        public CetUserService()
        {
            db = new LibraryDbContext();
        }
        public User Login(int SchoolNumber, string Password)
        { 
            string hashedPasword = Password;
            var loginUser = db.Users.Where(u => u.SchoolNumber == SchoolNumber && u.Password == hashedPasword).FirstOrDefault(); ;

            return loginUser;
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password == password;
        }

        internal object Login(string text, string password)
        {
            throw new NotImplementedException();
        }



        public void ChangePassword(User cetUser, string password)
        {
            var user = db.Users.Find(cetUser.UserId);
            user.Password = password;
            db.SaveChanges();
        }

        public bool Insert(User cetUser)
        {
            return true;
        }

    }







}
