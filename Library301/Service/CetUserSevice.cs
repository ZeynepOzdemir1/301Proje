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
        public User Login(string a, string Password)
        { 
            var loginUser = db.Users.Where(u => u.SchoolNumber == a && u.Password == Password).FirstOrDefault(); ;

            return loginUser;
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password == password;
        }


        public void ChangePassword(User cetUser, string password)
        {
            var user = db.Users.Find(cetUser.Id);
            user.Password = password;
            db.SaveChanges();
        }

        public bool Insert(User cetUser)
        {
            return true;
        }

    }







}
