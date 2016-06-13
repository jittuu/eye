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

        public static Task<Post> GetPostByIdAsync(this IDbConnection conn, int id)
        {
            var sql = "select * from Posts where Id = @id";
            return conn.QueryFirstOrDefaultAsync<Post>(sql, new { id = id });
        }
    }
}
