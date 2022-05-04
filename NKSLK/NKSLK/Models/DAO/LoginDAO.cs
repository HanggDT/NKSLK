using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DAO
{
    public class LoginDAO
    {
        Model1 db;
        public LoginDAO()
        {
            db = new Model1();
        }
        public IQueryable<ACCOUNT> ACCOUNTs
        {
            get { return db.ACCOUNTs; }
        }
        public bool Login(string email, string password)
        {
            var res = (from s in db.ACCOUNTs where s.Email == email && s.Password == password select s);
            if (res.Count() > 0)
                return true;
            return false;
        }
        public void Create(ACCOUNT ac)
        {
            db.ACCOUNTs.Add(ac);
            db.SaveChanges();
        }
        public ACCOUNT FindProductByID(string email)
        {
            return db.ACCOUNTs.Find(email);
        }



    }
}