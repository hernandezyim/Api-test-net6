using System.ComponentModel.DataAnnotations;

class Articulo {

  [Key]
  public int IdArticulo { get; set; }

  [Required]
  public string? Nombre { get; set; }

  [Required]
  public double? Precio { get; set; } 

  [Required]
  public string? Categoria { get; set; }
}