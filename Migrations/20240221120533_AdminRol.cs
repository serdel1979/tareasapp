using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasAsp.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DO $$ 
                BEGIN 
                    IF NOT EXISTS (SELECT 1 FROM public.""AspNetRoles"" WHERE ""Id"" = '6ac4c111-4aeb-4e6a-927e-3c2cf76427eb') THEN 
                        INSERT INTO public.""AspNetRoles""(""Id"", ""Name"", ""NormalizedName"") 
                        VALUES ('6ac4c111-4aeb-4e6a-927e-3c2cf76427eb', 'admin', 'ADMIN'); 
                    END IF; 
                END $$;

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"AspNetRoles\" WHERE \"Id\" = '6ac4c111-4aeb-4e6a-927e-3c2cf76427eb'");
        }
    }
}
