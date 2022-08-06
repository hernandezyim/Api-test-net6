using System.Text.Json;

class ArticuloController{
    public static IResult GetArticulos(DataContext context){
        try
        {
            var articulos = context.articulo;

            var listaDeArticulos = articulos.ToList();

            return Results.Ok(listaDeArticulos);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }

    public static async Task<IResult> AddArticulo(DataContext context, dynamic body){
        try
        {
            Articulo data = JsonSerializer.Deserialize<Articulo>(body);
            
            if(data.Nombre is null || data.Precio is null || data.Categoria is null){
                return Results.BadRequest("Algo salio mal");
            }
            await context.articulo.AddAsync(data);
            await context.SaveChangesAsync();
            
            return Results.Ok("Nuevo Articulo agregado con exito");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }
}