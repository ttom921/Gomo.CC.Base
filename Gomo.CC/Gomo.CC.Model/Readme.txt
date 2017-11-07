加入以下的package
Install-Package Microsoft.EntityFrameworkCore.SqlServer
nstall-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
注意目前的db first 只支援單一專案
Scaffold-DbContext "Data Source=DESKTOP-NITSS8T;Initial Catalog=Blogging;User ID=sa;Password=12345678;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
系統會DI 所以DBContext要改寫，
1.Delete the OnConfiguring(...) method
2.加入constructor
public BloggingContext(DbContextOptions<BloggingContext> options)
    : base(options)
{ }