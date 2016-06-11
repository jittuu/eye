using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class SaveNewShopAction
    {
        IDbConnection _conn;
        public SaveNewShopAction(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<int> RunAsync(Shop shop)
        {
            var sql = @"INSERT INTO [dbo].[Shops]
                       ([Name]
                       ,[TotalLikes]
                       ,[LastPostedDate]
                       ,[IsPreOrder]
                       ,[IsOnStock]
                       ,[IsPrePaid]
                       ,[ImageContainer]
                       ,[PageURL]
                       ,[CreatedAt]
                       ,[CreatedBy])
                 VALUES
                       (@Name
                       ,@TotalLikes
                       ,@LastPostedDate
                       ,@IsPreOrder
                       ,@IsOnStock
                       ,@IsPrePaid
                       ,@ImageContainer
                       ,@PageURL
                       ,@CreatedAt
                       ,@CreatedBy)";


            return _conn.ExecuteAsync(sql, shop);
        }
    }
}
