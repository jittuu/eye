using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class PriceRangeQuery
    {
        IDbConnection _conn;
        public PriceRangeQuery(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<IEnumerable<PriceRange>> RunAsync(int minPrice, int maxPrice)
        {
            var sql = @"
                    select price/3000*3000 as MinPrice, 
                        (price/3000+1)*3000-1 as MaxPrice, 
                        count(*) as Total
                    from Posts
                    where Price > @minPrice AND Price < @maxPrice
                    group by price/3000
                    order by MinPrice";
            return _conn.QueryAsync<PriceRange>(sql, new { minPrice = minPrice, maxPrice = maxPrice });
        }
    }
}
