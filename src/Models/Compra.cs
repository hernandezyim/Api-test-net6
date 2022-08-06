using System.ComponentModel.DataAnnotations;

class Compra {

  [Key]
  public int IdCompra { get; set; } 

  [Required]
  public string? Proveedor { get; set; }

  [Required]
  public string? Articulo { get; set; } 

  [Required]
  public int? Cantidad { get; set; }
}