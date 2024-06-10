using lab09.Data;
using lab09.DTOs;
using lab09.Models;
using Microsoft.EntityFrameworkCore;

namespace lab09.Services;

public class DbService : IDbService
{
    
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesMedicamentExist(int medicamentId)
    {
        return await _context.Medicaments.AnyAsync(e => e.Id == medicamentId);
    }

    public async Task AddNewPrescription(AddPrescriptionDTO prescription)
    {
        Prescription prescriptionTMP = new Prescription()
        {
            Date = prescription.Date,
            Doctor = prescription.Doctor,
            DueDate = prescription.DueDate,
            Id = 6,
            IdDoctor = prescription.Doctor.Id,
            IdPatient = prescription.patient.Id,
            Patient = prescription.patient
        };
        
        await _context.AddAsync(prescriptionTMP);

        foreach (var VARIABLE in prescription.medicaments)
        {
            PrescriptionMedicament prescriptionMedicament = new PrescriptionMedicament()
            {
                Prescription = prescriptionTMP,
                IdMedicament = VARIABLE.Id,
                Dose = prescription.Dose,
                Details = VARIABLE.Description,
                IdPrescription = prescriptionTMP.Id,
                Medicament = VARIABLE
            };
            await _context.AddAsync(prescriptionMedicament);
        }

        await _context.SaveChangesAsync();


    }


    public async Task<bool> DoesPatientExist(int patientID)
    {
        return await _context.Patients.AnyAsync(e => e.Id == patientID);
    }

    public Task<bool> DoesDoctorExist(int doctorID)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Patient>> GetPatientByName(string name)
    {
        return await _context.Patients
            .Where(e => e.LastName == null || e.LastName == name)
            .ToListAsync();
    }
}