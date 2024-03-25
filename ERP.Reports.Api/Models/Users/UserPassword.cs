using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Users
{
    public class UserPassword : ValueObject
    {
        public string Password { get; }
        private UserPassword(string password) => Password = password;

        public static Result<UserPassword> Create(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return Result.Failure<UserPassword>("The Password Field is Required");
            if (password.Length > 200)
                return Result.Failure<UserPassword>("The Password field cannot exceed 200 characters.");

            return Result.Success(new UserPassword(password));

        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return this.Password;
        }
    }
}