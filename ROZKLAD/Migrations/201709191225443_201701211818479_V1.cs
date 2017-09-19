namespace ROZKLAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201701211818479_V1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ocinkas", "Mark", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ocinkas", "Mark", c => c.String());
        }
    }
}
