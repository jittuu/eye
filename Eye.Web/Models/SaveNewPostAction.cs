using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class SaveNewPostAction
    {
        IDbConnection _conn;
        public SaveNewPostAction(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<int> RunAsync(Post post)
        {
            var sql = @"
                INSERT INTO [dbo].[Posts]
                           ([ShopId]
                           ,[ShopName]
                           ,[ItemName]
                           ,[PostedDate]
                           ,[TotalLikes]
                           ,[Shares]
                           ,[Price]
                           ,[PreOrderDays]
                           ,[PhotoName]
                           ,[PostURL])
                     VALUES
                           (@ShopId
                           ,@ShopName
                           ,@ItemName
                           ,@PostedDate
                           ,@TotalLikes
                           ,@Shares
                           ,@Price
                           ,@PreOrderDays
                           ,@PhotoName
                           ,@PostURL)";

            return _conn.ExecuteAsync(sql, post);
        }
    }
}
