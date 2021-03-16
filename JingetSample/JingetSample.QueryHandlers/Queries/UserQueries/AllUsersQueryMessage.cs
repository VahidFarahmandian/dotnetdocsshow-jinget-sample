using System.Collections.Generic;
using Jinget.Core.Enumerations;
using Jinget.Core.ExpressionToSql.Internal;
using Jinget.Core.ExtensionMethods;
using Jinget.Core.Types;
using Jinget.Handlers.QueryHandler.QueryMessages;

namespace JingetSample.QueryHandlers.Queries.UserQueries
{
    public class AllUsersQueryMessage : BaseOrderedMessage<AllUsersQueryMessage>, MediatR.IRequest<ResponseResult<List<AllUsersQueryMessage>>>

    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AllUsersQueryMessage()
        {
            OrderBy = new List<OrderBy>
            {
                new OrderBy {Name = x => ((AllUsersQueryMessage)x).LastName, Direction = OrderByDirection.Ascending},
            };
            PagingConfig = new Paging { PageNumber = 0, PageSize = 0 };
        }

        public AllUsersQueryMessage(int pageSize, int pageNumber, string filter, string sortColumn, string sortDirection = "asc") : this()
        {
            if (!string.IsNullOrEmpty(sortColumn))
                OrderBy = new List<OrderBy>
                {
                    new OrderBy
                    {
                        Name = x => typeof(AllUsersQueryMessage).GetPropertyInfo(sortColumn).Name,
                        Direction = (sortDirection == "desc" ? OrderByDirection.Descending : OrderByDirection.Ascending)
                    }
                };

            PagingConfig = new Paging { PageNumber = pageNumber, PageSize = pageSize };

            if (!string.IsNullOrEmpty(filter))
            {
                RowRestrictions = model => model.FirstName.Contains(filter) || model.LastName.Contains(filter);
            }
        }
    }
}
