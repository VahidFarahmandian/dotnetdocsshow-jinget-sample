using System;
using Jinget.Domain.Core.DataContracts.UnitOfWork;
using Jinget.Handlers.ApplicationService;
using JingetSample.CommandHandlers.Contracts;
using JingetSample.Domain.Contracts;
using JingetSample.Domain.Entities;

namespace JingetSample.CommandHandlers.Services
{
    public class UserCommandHandler : BaseApplicationService<UserModel, Guid>, IUserCommandHandler
    {
        private readonly IUserDomainService _userDomainService;

        public UserCommandHandler(
            IServiceProvider serviceProvider,
            IApplicationUnitOfWork unitOfWork,
            IUserDomainService userDomainService
        ) : base(serviceProvider, unitOfWork, userDomainService) =>
            _userDomainService = userDomainService;

        public bool Remove(string username)
        {
            _userDomainService.Remove(username);
            return UnitOfWork.Commit() > 0;
        }
    }
}
