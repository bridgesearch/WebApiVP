using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core
{
   public interface IUserRepo
    {
        bool ValidateUser(User creds);
        bool GetUserConfidentials(string email);
    }
}
