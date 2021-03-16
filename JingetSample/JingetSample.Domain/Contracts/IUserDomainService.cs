using System;
using Jinget.Domain.Services.Contracts;
using JingetSample.Domain.Entities;

namespace JingetSample.Domain.Contracts
{
    public interface IUserDomainService : IBaseDomainService<UserModel, Guid>
    {
        bool Remove(string username);
    }
}
