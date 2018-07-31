namespace DC_Comic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'30ee7dc4-c0ce-4c4e-b800-4cdae8b6f4c6', N'admin@dc.com', 0, N'ALenB65tqghR4theRMtK6Rf8As9c//BX8Np2+4cx59RTCi2a6/C9HeVIMuCzMvCnLg==', N'ea8b50d1-cc97-44c2-bb79-a21d96d3d455', NULL, 0, 0, NULL, 1, 0, N'admin@dc.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4287d705-baa3-44ac-ba28-9b31a06ad5b3', N'ayesha@dc.com', 0, N'AMrc2aBBIf83qU0rH5bbLDqm/1AKfJFgdrpbRY2QLRy7Ugw57bWQqJw6yJmEscAACg==', N'19614b43-24be-402f-a9ab-e86a6fa1f750', NULL, 0, 0, NULL, 1, 0, N'ayesha@dc.com')
");
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8e84d163-0b25-4460-a51f-03c50b5930bf', N'CanManageCharacters')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'30ee7dc4-c0ce-4c4e-b800-4cdae8b6f4c6', N'8e84d163-0b25-4460-a51f-03c50b5930bf')
");

        }
        
        public override void Down()
        {
        }
    }
}
