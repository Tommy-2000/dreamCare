using dreamCare.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace dreamCare.ApiService;

public class ApiDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Admin> AdminUsers => Set<Admin>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Assessment> Assessments => Set<Assessment>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<GPUser> GPUsers => Set<GPUser>();
    public DbSet<NurseUser> NurseUsers => Set<NurseUser>();
    public DbSet<PatientUser> PatientUsers => Set<PatientUser>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Create the BoolToStringConverter for boolean properties
        var boolToString = new BoolToStringConverter("No", "Yes");

        // Build a CosmosDb container based on each model
        // Convert UserPermissions to strings
        modelBuilder.Entity<Admin>()
            .ToContainer("adminusers");
        modelBuilder.Entity<Appointment>()
            .ToContainer("appointments")
            .Property(e => e.isAppointmentCancelled)
            .HasConversion(boolToString);
        modelBuilder.Entity<Appointment>()
            .Property(e => e.isAppointmentUrgent)
            .HasConversion(boolToString);
        modelBuilder.Entity<Assessment>()
            .ToContainer("assessments")
            .Property(e => e.recommendReferral)
            .HasConversion(boolToString);
        modelBuilder.Entity<Department>()
            .ToContainer("departments");
        modelBuilder.Entity<GPUser>()
            .ToContainer("gpusers")
            .Property(e => e.isGPCurrentlyAvailable)
            .HasConversion(boolToString);
        modelBuilder.Entity<NurseUser>()
            .ToContainer("nurseusers")
            .Property(e => e.isNurseCurrentlyAvailable)
            .HasConversion(boolToString);
        modelBuilder.Entity<PatientUser>()
            .ToContainer("patientusers")
            .Property(e => e.isReferred)
            .HasConversion(boolToString);
        // Have EFCore create the model based on the entity types
        base.OnModelCreating(modelBuilder);
    }
}
