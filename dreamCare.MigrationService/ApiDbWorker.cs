using dreamCare.ApiService;
using dreamCare.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using static dreamCare.ApiService.Models.ModelExtensions;


namespace dreamCare.MigrationService
{
    public class ApiDbWorker(IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
    {

        public const string ActivitySourceName = "Migrations";
        private static readonly ActivitySource _activitySource = new(ActivitySourceName);


       

        // Manage the Database migrations as an asynchronous Task that follows the host application's lifecycle
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var activity = _activitySource.StartActivity("Migrating database", ActivityKind.Client);

            try
            {
                using var activity_scope = serviceProvider.CreateScope();
                var apiDbContext = activity_scope.ServiceProvider.GetRequiredService<ApiDbContext>();

                await EnsureDatabaseAsync(apiDbContext, cancellationToken);
                await RunMigrationsAsync(apiDbContext, cancellationToken);
                await SeedDataAsync(apiDbContext, cancellationToken);

            }
            catch (Exception ex)
            {
                // Attach the exception caught to the activity and throw it
                activity?.AddException(ex);
                throw;
            }

            // Stop the application when migrations are completed
            hostApplicationLifetime.StopApplication();

        }

        private static async Task EnsureDatabaseAsync(ApiDbContext apiDbContext, CancellationToken cancellationToken)
        {

            var dbCreator = apiDbContext.GetService<IRelationalDatabaseCreator>();

            var dbStrategy = apiDbContext.Database.CreateExecutionStrategy();

            await dbStrategy.ExecuteAsync(async () =>
            {
                if (!await apiDbContext.Database.EnsureCreatedAsync())
                {
                    await dbCreator.CreateAsync(cancellationToken);
                }
            });
        }



        // Execute the migrations following a migrations stategy
        private static async Task RunMigrationsAsync(ApiDbContext apiDbContext, CancellationToken cancellationToken)
        {
            var dbStrategy = apiDbContext.Database.CreateExecutionStrategy();
            // Wait for an instance of IExecutionStrategy
            await dbStrategy.ExecuteAsync(async () =>
            {
                if (!await apiDbContext.Database.EnsureCreatedAsync())
                {
                    await apiDbContext.Database.MigrateAsync(cancellationToken);
                }
            });
        }


        private static async Task SeedDataAsync(ApiDbContext apiDbContext, CancellationToken cancellationToken)
        {
            // Find any data already in the database
            if (apiDbContext.AdminUsers.Any() && apiDbContext.Appointments.Any() && apiDbContext.Assessments.Any() && apiDbContext.Departments.Any() && apiDbContext.GPUsers.Any() && apiDbContext.NurseUsers.Any() && apiDbContext.PatientUsers.Any())
            {
                return;
            }

            // Asyncronously seed initial data if there is no existing data
            var adminUserTest = new Admin[]
            {
                new() {aUserFirstName="Jack", aUserLastName="Bolton", registerDate=DateTime.Parse("2024-08-09"), lastLoggedIn=DateTime.Parse("2024-08-09"), userPermission=UserPermission.Read_And_Write }
            };


            var appointmentTest = new Appointment[]
            {
                new() {appointmentName="Check up with Dr Robinson", appointmentNotes="Patient must arrive 10 mins before appointment", appointmentDate=DateOnly.Parse("2024-08-09"), appointmentTime=TimeOnly.Parse("12:30"), isAppointmentCancelled=false, isAppointmentUrgent=true}
            };

            var assessmentTest = new Assessment[]
            {
                new() {assessmentName="Follow up - Check up with Dr. Robinson", assessmentNotes="Medication is required", recommendReferral=false, appointment=appointmentTest.First()}
            };

            var gpUserTest = new GPUser[]
            {
                new() {gpUserFirstName="Adam", gpUserLastName="Robinson", gpUserGenderIdentity=UserGenderIdentity.Male, gpPracticeType="Podiatry", roleLevel=RoleLevel.Senior, isGPCurrentlyAvailable=true, lastLoggedIn=DateTime.Parse(""), registerDate=DateTime.Parse(""), userPermission=UserPermission.Read_And_Write, appointments=[..appointmentTest]}
            };


            var nurseUserTest = new NurseUser[]
            {
                new() {nUserFirstName="", nUserLastName="", nUserGenderIdentity=UserGenderIdentity.Male, nPracticeType="", roleLevel=RoleLevel.Associate, lastLoggedIn=DateTime.Parse(""), registerDate=DateTime.Parse(""), isNurseCurrentlyAvailable=true, userPermission=UserPermission.Read_And_Write, appointments=[..appointmentTest]}
            };

            var departmentTest = new Department[]
            {
                new() {departmentType="", gpUsers=[..gpUserTest], nurseUsers=[..nurseUserTest]}
            };

            


            var patientUserTest = new PatientUser[]
            {
            new() {pUserFirstName="Rebecca", pUserLastName="Pearson", pUserGenderIdentity=UserGenderIdentity.Female, isReferred=true, registerDate=DateTime.Parse("2025-01-16"), userPermission=UserPermission.Read, lastCheckUp=DateTime.Parse("2025-03-12")}
            };



            var dbStrategy = apiDbContext.Database.CreateExecutionStrategy();
            await dbStrategy.ExecuteAsync(async () =>
            {
                // Seed the database if no data is found
                await using var dbTransaction = await apiDbContext.Database.BeginTransactionAsync(cancellationToken);
                await apiDbContext.AdminUsers.AddAsync(adminUserTest[0], cancellationToken);
                await apiDbContext.Appointments.AddAsync(appointmentTest[0], cancellationToken);
                await apiDbContext.Assessments.AddAsync(assessmentTest[0], cancellationToken);
                await apiDbContext.Departments.AddAsync(departmentTest[0], cancellationToken);
                await apiDbContext.GPUsers.AddAsync(gpUserTest[0], cancellationToken);
                await apiDbContext.NurseUsers.AddAsync(nurseUserTest[0], cancellationToken);
                await apiDbContext.PatientUsers.AddAsync(patientUserTest[0], cancellationToken);
                // Save and commit the changes
                await apiDbContext.SaveChangesAsync(cancellationToken);
                await dbTransaction.CommitAsync(cancellationToken);
            });
        }


    }
}
