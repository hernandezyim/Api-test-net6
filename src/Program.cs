var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Rutas Articulo

app.MapGet("/api/articulo", ArticuloController.GetArticulos);
app.MapPost("/api/articulo", ArticuloController.AddArticulo);

// Rutas Proveedor

app.MapGet("/api/proveedor", ProveedorController.GetProveedores);
app.MapPost("/api/proveedor", ProveedorController.AddProveedor);

// Rutas Compra

app.MapGet("/api/compra", CompraController.GetCompras);
app.MapPost("/api/compra", CompraController.AddCompra);

app.Run();