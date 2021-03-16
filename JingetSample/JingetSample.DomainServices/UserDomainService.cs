using System;
using System.Linq.Expressions;
using Jinget.Core.Exceptions;
using Jinget.Domain.Core.DataContracts.Repository;
using Jinget.Domain.Services;
using JingetSample.Domain.Contracts;
using JingetSample.Domain.Entities;

namespace JingetSample.DomainServices
{
    public class UserDomainService : BaseDomainService<UserModel, Guid>, IUserDomainService
    {
        public UserDomainService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override void Set(IRepository<UserModel, Guid> repository)
        {
            base.Set(repository);

            Repository.ConstantFields = UserModel.GetConstantFields();
        }

        public override UserModel Create(UserModel param)
        {
            if (Exists(x => x.UserName == param.UserName))
                throw new JingetException("An account with given username already exists", 2000);

            return base.Save(param);
        }

        public bool Remove(string username)
        {
            var user = base.Fetch(filter: x => x.UserName == username, columns: x => new { x.Id });
            if (user == null)
            {
                throw new JingetException("user not found");
            }
            var result = base.Remove(user);

            return result != Guid.Empty;
        }
    }
}
