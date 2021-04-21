using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestUserId = table.Column<int>(type: "int", nullable: false),
                    ApprovalUserId = table.Column<int>(type: "int", nullable: true),
                    RejectUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingRequests_Users_RequestUserId",
                        column: x => x.RequestUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRequestDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRequestDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingRequestDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingRequestDetails_BorrowingRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "BorrowingRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Game" },
                    { 2, "Novel" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Member" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "ShortContent", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" },
                    { 2, 2, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" },
                    { 3, 2, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" },
                    { 4, 2, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" },
                    { 5, 2, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" },
                    { 6, 2, "Gacha for your life", "Genshin Impact", "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "123", 1, "admin" },
                    { 2, "123", 2, "member" }
                });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "ApprovalUserId", "RejectUserId", "RequestDate", "RequestUserId", "Status", "UpdateDate" },
                values: new object[] { 1, 1, null, new DateTime(2021, 4, 14, 17, 28, 44, 611, DateTimeKind.Local).AddTicks(4319), 2, 1, new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(5541) });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "ApprovalUserId", "RejectUserId", "RequestDate", "RequestUserId", "Status", "UpdateDate" },
                values: new object[] { 2, 1, null, new DateTime(2021, 4, 14, 17, 28, 44, 612, DateTimeKind.Local).AddTicks(6950), 2, 1, new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(6957) });

            migrationBuilder.InsertData(
                table: "BorrowingRequests",
                columns: new[] { "Id", "ApprovalUserId", "RejectUserId", "RequestDate", "RequestUserId", "Status", "UpdateDate" },
                values: new object[] { 3, 1, null, new DateTime(2021, 4, 14, 17, 28, 44, 612, DateTimeKind.Local).AddTicks(6961), 2, 1, new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(6962) });

            migrationBuilder.InsertData(
                table: "BorrowingRequestDetails",
                columns: new[] { "Id", "BookId", "RequestId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "BorrowingRequestDetails",
                columns: new[] { "Id", "BookId", "RequestId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequestDetails_BookId",
                table: "BorrowingRequestDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequestDetails_RequestId",
                table: "BorrowingRequestDetails",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRequests_RequestUserId",
                table: "BorrowingRequests",
                column: "RequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowingRequests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
