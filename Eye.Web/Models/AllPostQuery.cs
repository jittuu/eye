using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class AllPostQuery
    {
        private IDbConnection _conn;
        public AllPostQuery(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Post>> Run()
        {
            var sql = @"
                select p.*, s.ImageContainer
                from Posts p inner join Shops s
                on p.ShopId = s.Id";

            var posts = await _conn.QueryAsync<Post>(sql);

            return posts;
        }
    }
}
