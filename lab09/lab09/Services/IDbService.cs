using lab09.DTOs;
using lab09.Models;

namespace lab09.Services;

public interface IDbService
{
    Task<bool> DoesPatientExist(int patientID);
    Task<bool> DoesDoctorExist(int doctorID);
    Task<ICollection<Patient>> GetPatientByName(string name);
    Task<bool> DoesMedicamentExist(int medicamentId);
    Task AddNewPrescription(AddPrescriptionDTO prescription);

}