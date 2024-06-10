using System.ComponentModel.DataAnnotations;

namespace lab09.Models;

public class Patient
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)] 
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}