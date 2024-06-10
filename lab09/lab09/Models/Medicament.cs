using System.ComponentModel.DataAnnotations;

namespace lab09.Models;

public class Medicament
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
}