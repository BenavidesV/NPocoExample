using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPocoExample.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<NPocoExample.Models.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<NPocoExample.Models.Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<NPocoExample.Models.Cita> Citas { get; set; }
    }
}