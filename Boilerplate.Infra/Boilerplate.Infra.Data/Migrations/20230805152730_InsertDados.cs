using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 5, 12, 25, 20, 117, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.Sql("INSERT INTO [dbo].[Users]([Id],[Situation],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber])VALUES('fe8abf87-8bf7-4436-9826-b9b47d91ddd5',1,'ADMIN','ADMIN','teste@gmail.com','TESTE@GMAIL.COM','AQAAAAIAAYagAAAAEHa5iZ75V7TSmKt4akaBURF1rvo9rYpt7ROIbvqWd4NL4uT78GAo/Y58gDFsH1JZCg==','74J4E333BNWCCZ7LMTWTIZ3K5J6AWXRL','50f06837-3933-40e4-ab97-8f0372347b4c','+5532998313394')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Roles]([Id],[Name],[NormalizedName],[ConcurrencyStamp])VALUES('fd301af2-4459-4a15-9e88-f9d3cf35ac16','Administrador','ADMINISTRADOR', NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Roles]([Id],[Name],[NormalizedName],[ConcurrencyStamp])VALUES('fd301af2-4459-4a15-9e88-f9d3cf35ac26','User','USER', NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[UserRolesMapping]([UserId],[RoleId]) VALUES('fe8abf87-8bf7-4436-9826-b9b47d91ddd5', 'fd301af2-4459-4a15-9e88-f9d3cf35ac16')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 5, 12, 25, 20, 117, DateTimeKind.Local).AddTicks(7533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
