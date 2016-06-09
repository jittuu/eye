using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class AllShopsQuery
    {
        private IDbConnection _conn;

        public AllShopsQuery(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Shop>> Run()
        {
            var sql = @"
                    select *,
                        (Select count(*) from Posts p where s.Id = p.ShopId) as TotalPosts
                    from Shops s";
            var shops = await _conn.QueryAsync<Shop>(sql);

            return shops;
        }

    }
}
