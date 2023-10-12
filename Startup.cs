using Microsoft.EntityFrameworkCore;
using bootcamp.Models;
using bootcamp.Controllers;

namespace bootcamp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SampleDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); ;
            services.AddScoped<EmployerController>();
            services.AddScoped<JobListingController>();
            services.AddScoped<ApplicantController>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SampleDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            SeedJobListings(dbContext);
        }

        private void SeedJobListings(SampleDbContext dbContext)
        {
            // adauga 2 JobListings si 5 Applicants if true
            if (false)
            {   
                //adaugam 2 JobListings
                var jobListings = new List<JobListing>
                {
                    new JobListing
                    {
                        Name = "QA Engeneer",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        EmployerId = 1
                    },
                    new JobListing
                    {
                        Name = "Internship",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                        EmployerId = 2
                    }
                    
                };
                dbContext.JobListings.AddRange(jobListings);

                // adaugam 5 Applicants
                var applicants = new List<Applicant>
                {
                    new Applicant
                    {
                        FirstName = "Ana",
                        LastName = "Muresan",
                        PhoneNumber= "0772684621",
                        Email = "Ana@gmail.com",
                        AddressLine1 = "Blv. Republici",
                        AddressLine2 = "",
                        Country = "Romania",
                        State = "",
                        City = "Cluj-Napoca",
                        JobListingId = 5,
                    },
                    new Applicant
                    {
                        FirstName = "Joe",
                        LastName = "Montana",
                        PhoneNumber= "0711354621",
                        Email = "joe@gmail.com",
                        AddressLine1 = "Str. Vlad Tepes",
                        AddressLine2 = "",
                        Country = "Romania",
                        State = "",
                        City = "Cluj-Napoca",
                        JobListingId = 5,
                    },
                    new Applicant
                    {
                        FirstName = "Catalin",
                        LastName = "Iuga",
                        PhoneNumber= "0717286421",
                        Email = "catalin@gmail.com",
                        AddressLine1 = "Blv. Independentei",
                        AddressLine2 = "",
                        Country = "Romania",
                        State = "",
                        City = "Satu Mare",
                        JobListingId = 5,
                    },
                    new Applicant
                    {
                        FirstName = "Rares",
                        LastName = "Chiuzbaian",
                        PhoneNumber= "0711354621",
                        Email = "rares@gmail.com",
                        AddressLine1 = "Blv. Traian",
                        AddressLine2 = "",
                        Country = "Romania",
                        State = "",
                        City = "Bucuresti",
                        JobListingId = 6,
                    },
                    new Applicant
                    {
                        FirstName = "Norbert",
                        LastName = "Covaks",
                        PhoneNumber= "0717458621",
                        Email = "Norbert@gmail.com",
                        AddressLine1 = "Str. Luminisului",
                        AddressLine2 = "",
                        Country = "Romania",
                        State = "",
                        City = "Constanta",
                        JobListingId = 6,
                    }
                    
                };
                dbContext.Applicants.AddRange(applicants);
                dbContext.SaveChanges();
            }
        }
    }
}