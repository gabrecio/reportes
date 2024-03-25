using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace ERP.Reports.Api.Models.Users
{
    public class UserCredential : ValueObject
    {
        public string User { get; }
        private UserCredential(string email) => User = email;

        public static Result<UserCredential> Create(string user)
        {
            if (string.IsNullOrWhiteSpace(user))
                return Result.Failure<UserCredential>("The Email Field is Required");


            return Result.Success(new UserCredential(user));

        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return User;
        }
    }
}