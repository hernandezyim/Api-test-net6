using Microsoft.EntityFrameworkCore;

class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Articulo> articulo { get; set; } = null!;
    public DbSet<Proveedor> proveedor { get; set; } = null!;
    public DbSet<Compra> compra { get; set; } = null!;
    
}