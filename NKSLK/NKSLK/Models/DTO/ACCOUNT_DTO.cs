using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKSLK.Models.DTO
{
    public class ACCOUNT_DTO
    {
        public int ID { get; set; }

       
        public string Email { get; set; }

        
        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }
    }
}