using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Jinget.ApplicationCore.WebApi.Controllers;
using Jinget.Core.Attributes;
using Jinget.Core.Types;
using JingetSample.API.ViewModels;
using JingetSample.CommandHandlers.Contracts;
using JingetSample.Domain.Entities;
using JingetSample.QueryHandlers.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace JingetSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserCommandHandler _userCommandHandler;

        public UserController(IMediator queryHandler, IMapper mapper, IUserCommandHandler userCommandHandler) : base(queryHandler, mapper)
        {
            _userCommandHandler = userCommandHandler;
        }

        [HttpGet]
        [Summary("Get the list of users")]
        public async Task<ResponseResult<List<AllUsersQueryMessage>>> GetAll(int pageSize, int pageNumber, string filter, string sortColumn, string sortDirection)
            => await QueryHandler.Send(new AllUsersQueryMessage(pageSize, pageNumber, filter, sortColumn, sortDirection));

        [HttpPost]
        [Summary("Create a new user")]
        public async Task Create([FromBody] NewUserViewModel createUserViewModel) => await Task.Run(() => _userCommandHandler.Create(JingetMapper.Map<UserModel>(createUserViewModel)));

        [HttpDelete]
        [Summary("Remove a user")]
        public async Task Delete(string username) => await Task.Run(() => _userCommandHandler.Remove(username));
    }
}
