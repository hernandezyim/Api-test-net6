using System.ComponentModel.DataAnnotations;

class Proveedor {

  [Key]
  public int IdProveedor { get; set; } 

  [Required]
  public string? Nombre { get; set; }

  [Required]
  public int? Rnc { get; set; } 

  [Required]
  public string? Telefono { get; set; }

  [Required]
  public string? CorreoElectronico { get; set; }

  [Required]
  public string? PersonaContacto { get; set; }
}