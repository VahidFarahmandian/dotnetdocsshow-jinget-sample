using System;
using Jinget.Handlers.ApplicationService.Contracts;
using JingetSample.Domain.Entities;

namespace JingetSample.CommandHandlers.Contracts
{
    public interface IUserCommandHandler : IBaseApplicationService<UserModel, Guid>
    {
        bool Remove(string username);
    }
}
