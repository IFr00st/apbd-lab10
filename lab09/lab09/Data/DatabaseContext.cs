using lab09.Models;
using Microsoft.EntityFrameworkCore;

namespace lab09.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Today
                },
                new Patient {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Birthdate = DateTime.Today
                }
            });

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Email = "xd@gmail.com"
                },
                new Doctor {
                    Id = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska",
                    Email = "xd@gmail.com"
                }
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription
                {
                    Id = 1,
                    Date = DateTime.Today,
                    DueDate = DateTime.Today,
                    IdPatient = 1,
                    IdDoctor = 1
                },
                
                new Prescription
                {
                    Id = 2,
                    Date = DateTime.Today,
                    DueDate = DateTime.Today,
                    IdPatient = 2,
                    IdDoctor = 1
                }
                
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament
                {
                    Id = 1,
                    Name = "Apap",
                    Description = "Ból głowy",
                    Type = "Tabletka"
                },
                
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
            {
               new PrescriptionMedicament
               {
                   IdMedicament = 1,
                   IdPrescription = 1,
                   Dose = 2,
                   Details = "Na noc"
               }
            });
    }
}