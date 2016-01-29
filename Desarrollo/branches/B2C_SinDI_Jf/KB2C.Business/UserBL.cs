using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB2C.Data;

namespace KB2C.Business
{
    public class UserBL
    {
        public void insertUserOracle(string user, string password) 
        {
            UserDAL obj = new UserDAL();
            obj.insertUserOracle(user,password);
        }
    }
}
