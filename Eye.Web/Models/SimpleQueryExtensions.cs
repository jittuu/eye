using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public static class SimpleQueryExtensions
    {
        public static Task<Shop> GetShopByIdAsync(this IDbConnection conn, int id)
        {
            var sql = "select * from Shops where Id = @id";
            return conn.QueryFirstOrDefaultAsync<Shop>(sql, new { id = id });
        }
    }
}
