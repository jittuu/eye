using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class UpdateShopAction
    {
        IDbConnection _conn;
        public UpdateShopAction(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<int> RunAsync(Shop shop)
        {
            var sql = @"
                UPDATE [Shops]
                   SET [Name] = @Name
                      ,[TotalLikes] = @TotalLikes
                      ,[LastPostedDate] = @LastPostedDate
                      ,[IsPreOrder] = @IsPreOrder
                      ,[IsOnStock] = @IsOnStock
                      ,[IsPrePaid] = @IsPrePaid
                      ,[PageURL] = @PageURL
                 WHERE Id = @Id
            ";
            return _conn.ExecuteAsync(sql, shop);
        }
    }
}
