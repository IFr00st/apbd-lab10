using System.Runtime.InteropServices.JavaScript;
using lab09.Models;

namespace lab09.DTOs;

public class AddPrescriptionDTO
{
    public Patient patient;
    public List<Medicament> medicaments;
    public Doctor Doctor;
    public DateTime Date;
    public DateTime DueDate;
    public int Dose;
}