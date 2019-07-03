using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.Search
{
    public class GetSearchUserQuery : IRequest<SearchUserViewModel>
    {
        public string key { set; get; }
    }
}
