using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.EntityFrameworkCore; 
using JobWebApp.Models; 

namespace JobWebApp.Data 
{
    // Declara la clase `JobDbContext`, que hereda de `DbContext`, la clase base para trabajar con Entity Framework.
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }
        // DbContextOptions<JobDbContext> options: Es un parámetro del constructor. DbContextOptions 
        // es una clase que contiene configuraciones para el DbContext. En este caso, está especificando opciones para la 
        // clase JobDbContext. Esto puede incluir configuraciones como la cadena de conexión a la base de datos, 
        // configuraciones de la base de datos, etc.

        public DbSet<Job> Jobs { get; set; }
        // DbSet<T>: Es una clase proporcionada por Entity Framework Core que representa 
        // una colección de entidades en la base de datos. Cada DbSet<T> se mapea a una tabla
        //  en la base de datos y te permite realizar operaciones
        //  como consultas, inserciones, actualizaciones y eliminaciones en esa tabla.
    }
}
