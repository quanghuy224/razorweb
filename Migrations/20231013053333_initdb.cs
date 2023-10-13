using System;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            //Insert Data
            //FakeData voi Bogus
            Randomizer.Seed = new Random(8675309);

            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor( a=> a.Title, f => f.Lorem.Sentence(5,5));
            fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021,1,1),new DateTime(2023,1,1)));
            fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1,4));

            for(int i = 0; i < 150;  i++){

            Article article = fakeArticle.Generate();
            migrationBuilder.InsertData(
              table : "articles",
              columns : new[] { "Title", "Created", "Content" },
              values : new object[] {
                article.Title,
                article.Created,
                article.Content
              }
            );
            }




    //         migrationBuilder.InsertData(
    //             table: "articles",
    //             columns: new[] { "Title", "Created", "Content" },
    //             values: new object[] {
    //                   "Giới thiệu C# và viết chương trình CS đầu tiên",
    //                   new DateTime(2020,1,2),
    //                  @"Giới thiệu C#, cài đặt .NET Core SDK, VSC và viết
    //                                chương trình CS (C# CSharp) đầu tiên chạy đa nền tảng Windows,
    //                                macOS, Linux, hàm Main trong C# và viết các
    //                                comment - ghi chú - xml document"
    //                }
    //         );
    //         migrationBuilder.InsertData(
    //             table: "articles",
    //             columns: new[] { "Title", "Created", "Content" },
    //             values: new object[] {
    //                    "Biến hằng số kiểu dữ liệu và nhập xuất dữ liệu C# .NET Core",
    //                    new DateTime(2020,1,2),
    //                     @"Tìm hiểu về biến - hằng số, cách khai báo và khởi tạo biến
    //                                cùng các kiểu dữ liệu cơ bản trong C#, khai báo biến kiểu
    //                                ngầm định var, tiến hành nhập xuất dữ liệu với Console"
    //                }
    //                );
    //         migrationBuilder.InsertData(
    //      table: "articles",
    //      columns: new[] { "Title", "Created", "Content" },
    //      values: new object[] {

    //                   "Các toán tử tính toán số học trong C# toán tử gán và tăng giảm",
    //                    new DateTime(2020,10,2),
    //                    @"(C#) Khái niệm về toán tử, các loại toán tử số học như
    //                                + - / *, thứ tự ưu tiên toán tự trong biểu thức,
    //                                các loại toán tử gán và toán tử tăng giảm"
    //         });
    //         migrationBuilder.InsertData(
    //      table: "articles",
    //      columns: new[] { "Title", "Created", "Content" },
    //      values: new object[] {
    //                    "Toán tử so sánh logic và các câu lệnh if switch trong C# .NET",
    //                    new DateTime(2020,6,2),
    //                   @"Giới thiệu C#, cài đặt .NET Core SDK, VSC và viết chương trình CS
    //                                (C# CSharp) đầu tiên chạy đa nền tảng Windows, macOS,
    //                                Các toán tử so sánh như so sánh bằng, so sánh lớn hơn ..
    //                                cùng các phép toán logic và, hoặc hay phủ định,
    //                                áp dụng viết câu lệnh điều kiện if else hay câu lệnh rẽ nhiều nhánh
    //                                switch case trong lập trình C#"
    //         });
    //         migrationBuilder.InsertData(
    //      table: "articles",
    //      columns: new[] { "Title", "Created", "Content" },
    //      values: new object[] {
    //                    "Vòng lặp trong trong C# for do while và câu lệnh break continue",
    //                 new DateTime(2020,1,22),
    //                    @"Tạo các vòng lặp for, while, do while trong C# và sử dụng câu lệnh
    //                                .điều hướng vòng lặp continue, break"
    //         }
    //  );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
