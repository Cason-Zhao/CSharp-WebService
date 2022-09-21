using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Model
{
    public class UserValidation
    {
        public static bool IsUserLegal(string userName, string psw)
        {
            string password = "TestUserLegal";
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }
            return string.Equals(psw, password);
        }

        public static bool IsTokenLegal(string token)
        {
            string storedToken = "TestTokenLegal";
            return string.Equals(token, storedToken);
        }
    }
}
