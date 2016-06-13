using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Eye.Web.Models
{
    public class UpdatePostAction
    {
        IDbConnection _conn;
        public UpdatePostAction(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<int> RunAsync(Post post)
        {
            var sql = @"
                        UPDATE [dbo].[Posts]
                           SET [ShopId] = @ShopId
                              ,[ShopName] = @ShopName
                              ,[ItemName] = @ItemName
                              ,[PostedDate] = @PostedDate
                              ,[TotalLikes] = @TotalLikes
                              ,[Shares] = @Shares
                              ,[Price] = @Price
                              ,[PreOrderDays] = @PreOrderDays
                              ,[PhotoName] = @PhotoName
                              ,[PostURL] = @PostURL
                         WHERE Id = @id";

            return _conn.ExecuteAsync(sql, post);
        }
    }
}
