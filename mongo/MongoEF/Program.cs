using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace MongoEF
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // Configuración de la conexión a MongoDB
            var connectionString = "mongodb://localhost:27017";         
            var databaseName = "dbproducts";         
            var mongoClient = new MongoClient(connectionString);         
            var database = mongoClient.GetDatabase(databaseName);         
            // Opciones del DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()             
                .UseMongoDB(mongoClient, databaseName);

            using (var context = new AppDbContext(optionsBuilder.Options))
            {            
                // Asegurarse de que la colección existe (opcional, MongoDB la crea al insertar)
               
                context.Database.EnsureCreated(); // No es necesario para MongoDB como lo es para SQL
            
                // ----------------------------------------//
            // Operaciones CRUD//
            // Crear un nuevo producto

                var newProduct = new Product
                {
                    Id = "68727f6efd9bafe292718dc7",
                    Name = "Laptop X1",
                    Price = "1200.50",
                    Quantity = "10",
                    Category = new Category 
                    { 
                        Name = "Electronics", 
                        Description = "Devices and gadgets" 
                    }
                };

                context.Products.Add(newProduct);
                await context.SaveChangesAsync();
                Console.WriteLine($"Producto agregado: {newProduct.Name} con Id: {newProduct.Id}");
               
                // Leer productos
                Console.WriteLine("\nProductos en la base de datos:");
                var products = await context.Products.ToListAsync();
                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name} ({product.Price:C}) - Categoría: {product.Category?.Name}");
                }
                
                // Actualizar un producto
                var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop X1");
                if (productToUpdate != null)
                {
                    productToUpdate.Price = "1150.00";
                    productToUpdate.Quantity += 5;

                    await context.SaveChangesAsync();

                    Console.WriteLine($"\nProducto actualizado: {productToUpdate.Name}, nuevo precio: {productToUpdate.Price:C}");

                }
                
                // Eliminar un producto

                var productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop X1");
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    await context.SaveChangesAsync();
                    Console.WriteLine($"\nProducto eliminado: {productToDelete.Name}"); }
                Console.WriteLine("\nProductos después de la eliminación:");
                
                products = await context.Products.ToListAsync();
                if (!products.Any())
                {
                    Console.WriteLine("No hay productos.");
                }

                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name} ({product.Price:C})");
                }

                //segunda insercion
                var newProduct2 = new Product
                {
                    Id = "68727da4fd9bafe292718dc6",
                    Name = "Laptop X2",
                    Price = "850",
                    Quantity = "5",
                    Category = new Category
                    {
                        Name = "Electronics",
                        Description = "Laptops"
                    }
                };

                context.Products.Add(newProduct2);
                await context.SaveChangesAsync();
                Console.WriteLine($"Producto agregado: {newProduct.Name} con Id: {newProduct.Id}");


            }

        }

    }
}
