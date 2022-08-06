using System.Text.Json;

class ProveedorController{
    public static IResult GetProveedores(DataContext context){
        try
        {
            var proveedores = context.proveedor;

            var listaDeProveedores = proveedores.ToList();

            return Results.Ok(listaDeProveedores);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> AddProveedor(DataContext context, dynamic body){
        try
        {
            Proveedor data = JsonSerializer.Deserialize<Proveedor>(body);
            
            if(data.Nombre is null || data.Rnc is null || data.Telefono is null || data.CorreoElectronico is null || data.PersonaContacto is null) 
            throw new Exception("Algo salio mal");

            await context.proveedor.AddAsync(data);
            await context.SaveChangesAsync();
            
            return Results.Ok("Nuevo Proveedor agregado con exito");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }
}