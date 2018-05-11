using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth.Core
{
    /// <summary>
    /// 
    /// </summary>
   public class User : IEquatable<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Equals(User other)
        {
            if (other == null) return false;
            return (this.Login.Equals(other.Login) && this.Password.Equals(other.Password));
        }
    }
}
