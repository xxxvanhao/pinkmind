using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.Search
{
    public class SearchUserViewModel
    {
        public IEnumerable<SearchUserDTO> searchUsers { get; set; }
    }
}
