using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jinget.Core.ExpressionToSql;
using Jinget.Core.IOptionTypes.ConnectionString;
using Jinget.Core.Types;
using Jinget.Handlers.QueryHandler.Contracts;
using Jinget.Handlers.QueryHandler.QueryHandlers;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace JingetSample.QueryHandlers.Queries.UserQueries
{
    public class AllUsersQueryHandlers : BaseSelectQueryHandler<AllUsersQueryMessage, List<AllUsersQueryMessage>>,
        IRequestHandler<AllUsersQueryMessage, ResponseResult<List<AllUsersQueryMessage>>>
    {
        public AllUsersQueryHandlers(IBaseQuery query, IMemoryCache cache,
            IOptions<ApplicationDBConnectionString> connectionString)
            : base(query, cache, connectionString) =>
            Set = new Table
            {
                Name = "Vie_AllUsers",
                Schema = "Account"
            };

        public async Task<ResponseResult<List<AllUsersQueryMessage>>> Handle(
            AllUsersQueryMessage request, CancellationToken cancellationToken)
        {
            //if (!string.IsNullOrEmpty(request.Filter))
            //{
            //    Conditions = x => x.FirstName.Contains(request.Filter);
            //}

            //Columns = x => new
            //{
            //    x.LastName,
            //    x.FirstName
            //};

            return await base.Handle(request);
        }
    }
}