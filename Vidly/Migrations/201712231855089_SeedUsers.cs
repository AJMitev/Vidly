namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aed7ea58-7fd9-4b8b-ab82-1a580df9db97', N'admin@vidly.com', 0, N'ACEiGIL09w+qJ4XAn2+n3500naO6tZIDDpqj9hGk0TkMPs1lyHCHA0mgEbsQwldwNg==', N'f0959883-03f0-4336-af61-910685992940', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd7675c9-9591-4b1c-bd50-49383c652159', N'ajmitev@gmail.com', 0, N'AFTK97VHsxga7dmjEzotqRT7IYiIdaknIxEKSc38l4xKmRBhRyvgak/lJPnqUCw8KA==', N'e9a2d16e-718f-42da-a720-b9af6a7fdf64', NULL, 0, 0, NULL, 1, 0, N'ajmitev@gmail.com')
 INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3781c15b-537d-409c-bbc4-82d54dbbdba6', N'CanManageMovies')
       
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aed7ea58-7fd9-4b8b-ab82-1a580df9db97', N'3781c15b-537d-409c-bbc4-82d54dbbdba6')


"  );
        }

        public override void Down()
        {
        }
    }
}
