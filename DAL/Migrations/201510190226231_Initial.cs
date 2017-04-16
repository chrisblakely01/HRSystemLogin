namespace HRSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                    })
                .PrimaryKey(t => t.PermissionID);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        UserPermissionID = c.Int(nullable: false, identity: true),
                        UserTypeID = c.Int(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPermissionID)
                .ForeignKey("dbo.Permissions", t => t.PermissionID, cascadeDelete: true)
                .ForeignKey("dbo.UserType", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID)
                .Index(t => t.PermissionID);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserType", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 30),
                        Password = c.String(),
                        Email = c.String(maxLength: 200),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        SecurityQuestion = c.String(),
                        SecurityAnswer = c.String(maxLength: 200),
                        LoginAttempts = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.User");
            DropForeignKey("dbo.UserPermissions", "UserTypeID", "dbo.UserType");
            DropForeignKey("dbo.UserPermissions", "PermissionID", "dbo.Permissions");
            DropIndex("dbo.UserRoles", new[] { "UserTypeID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.UserPermissions", new[] { "PermissionID" });
            DropIndex("dbo.UserPermissions", new[] { "UserTypeID" });
            DropTable("dbo.User");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserType");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Permissions");
        }
    }
}
