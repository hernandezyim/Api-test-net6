using System.Text.Json;

class CompraController{
    public static IResult GetCompras(DataContext context){
        try
        {
            var compras = context.compra;

            var listaDeCompras = compras.ToList();

            return Results.Ok(listaDeCompras);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> AddCompra(DataContext context, dynamic body){
        try
        {
            Compra data = JsonSerializer.Deserialize<Compra>(body);
            
            if(data.Proveedor is null || data.Articulo is null || data.Cantidad is null)
            throw new Exception("Algo salio mal");

            var articulos = context.articulo;

            bool existe = articulos.Any(x => x.Nombre == data.Articulo);

            if(!existe) throw new Exception("El articulo Agotado");

            await context.compra.AddAsync(data);
            await context.SaveChangesAsync();
            
            return Results.Ok("Nueva Compra agregada con exito");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }
}