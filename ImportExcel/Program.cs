using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Dapper;

namespace ImportExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            var p = new ExcelPackage(File.OpenRead("kanoak.xlsx"));
            var w = p.Workbook.Worksheets["shops"];

            // InsertShops(w);
            InsertPosts(p.Workbook.Worksheets["posts"]);
        }

        static void InsertShops(ExcelWorksheet w)
        {
            var sql = @"INSERT INTO [dbo].[Shops]
                       ([Name]
                       ,[TotalLikes]
                       ,[LastPostedDate]
                       ,[IsPreOrder]
                       ,[IsOnStock]
                       ,[IsPrePaid]
                       ,[PageURL])
                 VALUES
                       (@Name
                       ,@TotalLikes
                       ,@LastPostedDate
                       ,@IsPreOrder
                       ,@IsOnStock
                       ,@IsPrePaid
                       ,@PageURL)";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                var start = w.Dimension.Start;
                var end = w.Dimension.End;
                for (int row = start.Row; row <= end.Row; row++)
                {
                    if (row == 1)
                    {
                        continue;
                    }

                    var shop = new Shop();
                    shop.Name = w.Cells[row, 2].Text.Trim();
                    if (!string.IsNullOrEmpty(shop.Name))
                    {
                        shop.TotalLikes = w.Cells[row, 3].GetValue<int>();
                        shop.LastPostedDate = w.Cells[row, 4].GetValue<DateTime>();
                        shop.IsPreOrder = w.Cells[row, 5].Text == "Y";
                        shop.IsOnStock = w.Cells[row, 6].Text == "Y";
                        shop.IsPrePaid = w.Cells[row, 7].Text == "Y";
                        shop.PageURL = w.Cells[row, 8].Text;

                        conn.Execute(sql, shop);
                    }
                }
            }
        }

        static void InsertPosts(ExcelWorksheet w)
        {
            var sql = @"
                INSERT INTO [dbo].[Posts]
                           ([ShopName]
                           ,[ItemName]
                           ,[PostedDate]
                           ,[TotalLikes]
                           ,[Shares]
                           ,[Price]
                           ,[PreOrderDays]
                           ,[PhotoName]
                           ,[PostURL])
                     VALUES
                           (@ShopName
                           ,@ItemName
                           ,@PostedDate
                           ,@TotalLikes
                           ,@Shares
                           ,@Price
                           ,@PreOrderDays
                           ,@PhotoName
                           ,@PostURL)";
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {

                var start = w.Dimension.Start;
                var end = w.Dimension.End;
                for (int row = start.Row; row <= end.Row; row++)
                {
                    if (row == 1)
                    {
                        continue;
                    }

                    var post = new Post();
                    post.ShopName = w.Cells[row, 2].Text.Trim();
                    if (!string.IsNullOrEmpty(post.ShopName))
                    {
                        post.ItemName = w.Cells[row, 3].Text;
                        post.PostedDate = DateTime.ParseExact(w.Cells[row, 4].Text, "d-M-yy", null);
                        post.TotalLikes = w.Cells[row, 5].GetValue<int>();
                        post.Shares = w.Cells[row, 6].GetValue<int>();
                        post.Price = w.Cells[row, 7].GetValue<int>();
                        post.PreOrderDays = w.Cells[row, 8].GetValue<int>();
                        post.PhotoName = w.Cells[row, 9].Text;
                        post.PostURL = w.Cells[row, 10].Text;

                        conn.Execute(sql, post);
                    }
                }
            }
        }
    }
}
