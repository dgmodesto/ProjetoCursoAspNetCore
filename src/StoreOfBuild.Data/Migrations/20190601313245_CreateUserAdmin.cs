using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StoreOfBuild.Data.Contexts;

namespace StoreOfBuild.Data.Migrations {

    [DbContext (typeof (ApplicationDbContext))]
    [Migration ("20190601313245_CreateUserAdmin")]
    public partial class CreateUserAdmin : Migration 
    {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql (@"INSERT INTO [dbo].[AspNetRoles]  VALUES ('C52A0F08-6989-4ADD-B54B-EBBD3803EDE8','','Admin','Admin');
                                    INSERT INTO [dbo].[AspNetRoles]  VALUES ('25410600-6AE6-4DF9-B607-DB3CB277A793','','Manager','Manager');
                                    INSERT INTO [dbo].[AspNetRoles]  VALUES ('3DB019-2810-4AE2-B5EB-607C79947C4D','','Operation','Operation');");
            //@Axsd12
            migrationBuilder.Sql (@"INSERT INTO [dbo].[AspNetUsers] VALUES ('43F6877-3E77-4633-AD2D-C9F495D848CF','Admin','Admin','ADMIN@ADMIN.COM','ADMIN@ADMIN.COM',1,'AQAAAAEAACcQAAAAEIIWoviAu641wICvbFTecu/e8tUNiQXxYQ9JaEUXLYmdcSrSS6OnOmJg1U6kxQgGbQ==','','','','','','',0,0)");

            migrationBuilder.Sql (@"INSERT INTO [dbo].[AspNetUserRoles] VALUES ('43F6877-3E77-4633-AD2D-C9F495D848CF', 'C52A0F08-6989-4ADD-B54B-EBBD3803EDE8')");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {

        }
    }
}