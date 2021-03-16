using System;
using System.Linq.Expressions;
using Jinget.Domain.Core.Entities;
using Jinget.Domain.Core.EntityContracts;

namespace JingetSample.Domain.Entities
{
    public class UserModel : BaseEntity<Guid>, IAggregateRoot
    {
        private UserModel()
        {
        }

        public UserModel(string userName, string firstName, string lastName, Guid id = default(Guid)) : base(id)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        public string UserName { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public static Expression<Func<UserModel, UserModel>> GetConstantFields() => user => new UserModel
        {
            UserName = user.UserName
        };
    }
}