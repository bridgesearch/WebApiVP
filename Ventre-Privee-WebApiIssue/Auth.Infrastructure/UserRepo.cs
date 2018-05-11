using Auth.Core;
using System;
using System.Collections.Generic;

namespace Auth.Infrastructure
{
    public class UserRepo : IUserRepo
    {
        private List<User> _listusers;
        public UserRepo() {
            _listusers = new List<User>();
            _listusers = BuildUserCredentialsReference();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creds"></param>
        /// <returns></returns>
        public bool ValidateUser(User creds)
        {
            return _listusers.Contains(creds);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<User> BuildUserCredentialsReference()
        {
            return new List<User>()
            {
                new User("hh.mm@gmail.com","ddlo252"),
                new User("hh.mm1@gmail.com","ddlo252"),
                new User("hh.mm2@gmail.com","ddlo252"),
                new User("hh.mm3@gmail.com","ddlo252"),
                new User("hh.mm4@gmail.com","ddlo252"),
                new User("hh.mm5@gmail.com","ddlo252"),
            };
         }

    }
}
