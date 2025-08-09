
using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

using MongoDB.EntityFrameworkCore.Extensions; // Importante para UseMongoDB
using MongoEF; 

public class AppDbContext : DbContext

{

    private readonly IMongoDatabase _database;

    // Constructor que recibe las opciones de DbContext

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

    {

    }

    // Constructor para el caso de uso directo con IMongoDatabase (útil para pruebas o inyección manual)

    public AppDbContext(IMongoDatabase database)

    {

        _database = database;

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {

        base.OnModelCreating(modelBuilder);

        // Mapea la entidad Product a la colección "products" en MongoDB

        modelBuilder.Entity<Product>().ToCollection("products");
        modelBuilder.Entity<Product>().HasKey(e=> e.Id);

        // Puedes configurar más cosas aquí, como índices, si es necesario.

        // modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

    }

    // Sobrescribimos OnConfiguring si no inyectamos las opciones desde fuera

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        // Solo configurar si no se ha configurado previamente (ej. por inyección de dependencias)

        if (!optionsBuilder.IsConfigured)
        {
            // Reemplaza con tu cadena de conexión de MongoDB

            var mongoClient = new MongoClient("mongodb://localhost:27017");

            optionsBuilder.UseMongoDB(mongoClient, "dbproducts"); // "MyMongoDbDatabase" es el nombre de tu base de datos

        }

    }

}

