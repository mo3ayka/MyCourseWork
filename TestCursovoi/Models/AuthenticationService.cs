using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestCursovoi.DBWorkLogic;

namespace TestCursovoi
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        Session Session = new Session(DBconnecting.CurrentConnecting.DataLayer);

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            var userData = new XPCollection<User>(Session, CriteriaOperator.And(new BinaryOperator("Login", username), new BinaryOperator("Password", CalculateHash(clearTextPassword,username)))).ToList();

            if (userData.FirstOrDefault() == null)
                throw new UnauthorizedAccessException("Неверный логин или пароль");

            return userData.FirstOrDefault();
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
