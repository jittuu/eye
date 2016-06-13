using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class AllPostByShopIdQuery
    {
        IDbConnection _conn;
        public AllPostByShopIdQuery(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Post>> Run(int shopId)
        {
            var sql = @"
                select p.*, s.ImageContainer
                from Posts p inner join Shops s
                on p.ShopId = s.Id
                where s.Id = @shopId";

            var posts = await _conn.QueryAsync<Post>(sql, new { shopId = shopId });

            return posts;
        }
    }
}
