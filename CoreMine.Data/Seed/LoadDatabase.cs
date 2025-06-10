using CoreMine.Entities;

namespace CoreMine.Data.Seed
{
    public static class LoadDatabase
    {
        public static async Task InsertData(AppDbContext context)
        {
            // =============================================
            // 1. CATEGORÍAS DE PRODUCTOS (JERÁRQUICAS)
            // =============================================
            if (!context.ProductCategories.Any())
            {
                var categorias = new List<ProductCategory>
                {
                    new ProductCategory { Code = "ELEC", Name = "Electrodomésticos" },
                    new ProductCategory { Code = "MAQIND", Name = "Maquinaria Industrial" },
                    new ProductCategory { Code = "HERR", Name = "Herramientas" },
                    new ProductCategory { Code = "COMP", Name = "Componentes Eléctricos" },
                    new ProductCategory { Code = "LUBQ", Name = "Lubricantes y Químicos" }
                };

                context.ProductCategories.AddRange(categorias);
                await context.SaveChangesAsync();

                // Subcategorías
                var electrodomesticos = categorias.First(c => c.Name == "Electrodomésticos");
                var maquinaria = categorias.First(c => c.Name == "Maquinaria Industrial");
                var herramientas = categorias.First(c => c.Name == "Herramientas");
                var componentes = categorias.First(c => c.Name == "Componentes Eléctricos");

                var subcategorias = new List<ProductCategory>
                {
                    // Electrodomésticos
                    new ProductCategory { Code = "ELEC-REF", Name = "Refrigeración", Parent = electrodomesticos },
                    new ProductCategory { Code = "ELEC-LAV", Name = "Lavado", Parent = electrodomesticos },
                    new ProductCategory { Code = "ELEC-COC", Name = "Cocción", Parent = electrodomesticos },
                    new ProductCategory { Code = "ELEC-CLI", Name = "Climatización", Parent = electrodomesticos },
                    
                    // Maquinaria Industrial
                    new ProductCategory { Code = "MAQIND-MOT", Name = "Motores", Parent = maquinaria },
                    new ProductCategory { Code = "MAQIND-BOM", Name = "Bombas", Parent = maquinaria },
                    new ProductCategory { Code = "MAQIND-COM", Name = "Compresores", Parent = maquinaria },
                    new ProductCategory { Code = "MAQIND-TRA", Name = "Transmisión", Parent = maquinaria },
                    
                    // Herramientas
                    new ProductCategory { Code = "HERR-MAN", Name = "Manuales", Parent = herramientas },
                    new ProductCategory { Code = "HERR-ELE", Name = "Eléctricas", Parent = herramientas },
                    new ProductCategory { Code = "HERR-MED", Name = "Medición", Parent = herramientas },
                    
                    // Componentes Eléctricos
                    new ProductCategory { Code = "COMP-MOT", Name = "Motores Eléctricos", Parent = componentes },
                    new ProductCategory { Code = "COMP-CON", Name = "Controles", Parent = componentes },
                    new ProductCategory { Code = "COMP-CAB", Name = "Cableado", Parent = componentes }
                };

                context.ProductCategories.AddRange(subcategorias);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 2. UNIDADES DE MEDIDA
            // =============================================
            if (!context.UnitOfMeasures.Any())
            {
                var unidades = new List<UnitOfMeasure>
                {
                    new UnitOfMeasure { Symbol = "u", Name = "Unidad" },
                    new UnitOfMeasure { Symbol = "m", Name = "Metro" },
                    new UnitOfMeasure { Symbol = "cm", Name = "Centímetro" },
                    new UnitOfMeasure { Symbol = "kg", Name = "Kilogramo" },
                    new UnitOfMeasure { Symbol = "g", Name = "Gramo" },
                    new UnitOfMeasure { Symbol = "l", Name = "Litro" },
                    new UnitOfMeasure { Symbol = "ml", Name = "Mililitro" },
                    new UnitOfMeasure { Symbol = "par", Name = "Par" },
                    new UnitOfMeasure { Symbol = "jgo", Name = "Juego" },
                    new UnitOfMeasure { Symbol = "cja", Name = "Caja" },
                    new UnitOfMeasure { Symbol = "paq", Name = "Paquete" },
                    new UnitOfMeasure { Symbol = "rollo", Name = "Rollo" },
                    new UnitOfMeasure { Symbol = "m²", Name = "Metro cuadrado" },
                    new UnitOfMeasure { Symbol = "pza", Name = "Pieza" }
                };

                context.UnitOfMeasures.AddRange(unidades);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 3. TIPOS DE ESTADOS DE PRODUCTOS
            // =============================================
            if (!context.ProductStateTypes.Any())
            {
                var states = new List<ProductStateType>
                {
                    new ProductStateType { Name = "Nuevo" },
                    new ProductStateType { Name = "Usado" },
                    new ProductStateType { Name = "Reacondicionado" },
                    new ProductStateType { Name = "Defectuoso" },
                    new ProductStateType { Name = "En Garantía" },
                    new ProductStateType { Name = "Descontinuado" }
                };

                context.ProductStateTypes.AddRange(states);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 4. TIPOS DE MOVIMIENTOS DE STOCK
            // =============================================
            if (!context.StockMovementTypes.Any())
            {
                var movementTypes = new List<StockMovementType>
                {
                    new StockMovementType { Name = "Compra", IsPositive = true },
                    new StockMovementType { Name = "Venta", IsPositive = false },
                    new StockMovementType { Name = "Reparación", IsPositive = false },
                    new StockMovementType { Name = "Ajuste Positivo", IsPositive = true },
                    new StockMovementType { Name = "Ajuste Negativo", IsPositive = false },
                    new StockMovementType { Name = "Devolución Cliente", IsPositive = true },
                    new StockMovementType { Name = "Devolución Proveedor", IsPositive = false },
                    new StockMovementType { Name = "Pérdida", IsPositive = false },
                    new StockMovementType { Name = "Rotura", IsPositive = false },
                    new StockMovementType { Name = "Transferencia Entrada", IsPositive = true },
                    new StockMovementType { Name = "Transferencia Salida", IsPositive = false }
                };

                context.StockMovementTypes.AddRange(movementTypes);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 5. UBICACIONES / ALMACENES
            // =============================================
            if (!context.Locations.Any())
            {
                var locations = new List<Location>
                {
                    new Location { Name = "Almacén Principal", Description = "Depósito principal de repuestos en Santa Rosa 275" }
                };

                context.Locations.AddRange(locations);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 6. PROVEEDORES
            // =============================================
            if (!context.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Repuestos", Surname = "Córdoba SA", Contact = "ventas@repuestoscordoba.com.ar", Phone = "+54 351 234-5678" },
                    new Supplier { Name = "Electrodomésticos", Surname = "del Centro", Contact = "compras@electrocentro.com.ar", Phone = "+54 351 345-6789" },
                    new Supplier { Name = "Industrial", Surname = "Mediterránea SRL", Contact = "comercial@indmed.com.ar", Phone = "+54 351 456-7890" },
                    new Supplier { Name = "Importadora", Surname = "Técnica Argentina", Contact = "info@imptecarg.com.ar", Phone = "+54 351 567-8901" },
                    new Supplier { Name = "Herramientas", Surname = "y Más SRL", Contact = "ventas@herramientasymas.com.ar", Phone = "+54 351 901-2345" }
                };

                context.Suppliers.AddRange(suppliers);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 7. PRODUCTOS BÁSICOS
            // =============================================
            if (!context.Products.Any())
            {
                var productCategories = context.ProductCategories.ToList();
                var unitOfMeasures = context.UnitOfMeasures.ToList();

                var refrigeracion = productCategories.First(c => c.Name == "Refrigeración");
                var lavado = productCategories.First(c => c.Name == "Lavado");
                var coccion = productCategories.First(c => c.Name == "Cocción");
                var motores = productCategories.First(c => c.Name == "Motores");
                var bombas = productCategories.First(c => c.Name == "Bombas");
                var herramientasManuales = productCategories.First(c => c.Name == "Manuales");
                var herramientasElectricas = productCategories.First(c => c.Name == "Eléctricas");
                var controles = productCategories.First(c => c.Name == "Controles");
                var lubricantes = productCategories.First(c => c.Name == "Lubricantes y Químicos");

                var unidad = unitOfMeasures.First(u => u.Name == "Unidad");
                var litro = unitOfMeasures.First(u => u.Name == "Litro");
                var par = unitOfMeasures.First(u => u.Name == "Par");
                var kilogramo = unitOfMeasures.First(u => u.Name == "Kilogramo");

                var products = new List<Product>
                {
                    // Refrigeración
                    new Product { Name = "Compresor Embraco 1/4 HP", Description = "Compresor para heladeras domésticas", Code = "EMB-14HP-001", Category = refrigeracion, UnitOfMeasure = unidad },
                    new Product { Name = "Termostato Ranco K-50", Description = "Termostato universal para refrigeradores", Code = "RAN-K50-002", Category = refrigeracion, UnitOfMeasure = unidad },
                    new Product { Name = "Gas Refrigerante R134A", Description = "Gas ecológico para sistemas de refrigeración", Code = "GAS-R134-005", Category = refrigeracion, UnitOfMeasure = kilogramo },
                    
                    // Lavado
                    new Product { Name = "Bomba Drenaje Lavarropas", Description = "Bomba desagote universal", Code = "BOM-DRE-006", Category = lavado, UnitOfMeasure = unidad },
                    new Product { Name = "Correa Lavasecarropas", Description = "Correa transmisión 1270mm", Code = "COR-LAV-007", Category = lavado, UnitOfMeasure = unidad },
                    new Product { Name = "Carbones Motor Universal", Description = "Carbones 5x12x32mm", Code = "CAR-MOT-009", Category = lavado, UnitOfMeasure = par },
                    
                    // Cocción
                    new Product { Name = "Resistencia Horno 2000W", Description = "Resistencia inferior horno eléctrico", Code = "RES-HOR-011", Category = coccion, UnitOfMeasure = unidad },
                    new Product { Name = "Termocupla Universal", Description = "Sensor temperatura para hornos", Code = "TER-UNI-013", Category = coccion, UnitOfMeasure = unidad },
                    
                    // Motores Industriales
                    new Product { Name = "Motor Trifásico 5HP", Description = "Motor industrial 380V 1450 RPM", Code = "MOT-TRI-015", Category = motores, UnitOfMeasure = unidad },
                    new Product { Name = "Rodamiento 6203 ZZ", Description = "Rodamiento sellado ambos lados", Code = "ROD-6203-016", Category = motores, UnitOfMeasure = unidad },
                    new Product { Name = "Aceite Motor SAE 30", Description = "Aceite mineral para motores industriales", Code = "ACE-SAE-018", Category = motores, UnitOfMeasure = litro },
                    
                    // Bombas
                    new Product { Name = "Sello Mecánico 20mm", Description = "Sello mecánico eje bomba", Code = "SEL-MEC-020", Category = bombas, UnitOfMeasure = unidad },
                    
                    // Herramientas
                    new Product { Name = "Destornillador Phillips #2", Description = "Destornillador profesional mango ergonómico", Code = "DES-PHI-022", Category = herramientasManuales, UnitOfMeasure = unidad },
                    new Product { Name = "Llave Inglesa 12\"", Description = "Llave ajustable cromada", Code = "LLA-ING-024", Category = herramientasManuales, UnitOfMeasure = unidad },
                    new Product { Name = "Amoladora 115mm", Description = "Amoladora angular 900W", Code = "AMO-ANG-025", Category = herramientasElectricas, UnitOfMeasure = unidad },
                    
                    // Componentes Eléctricos
                    new Product { Name = "Contactor 3P 25A", Description = "Contactor electromagnético 220V", Code = "CON-3P-026", Category = controles, UnitOfMeasure = unidad },
                    
                    // Lubricantes
                    new Product { Name = "Grasa Multiuso", Description = "Grasa litio complejo EP2", Code = "GRA-MUL-029", Category = lubricantes, UnitOfMeasure = kilogramo },
                    new Product { Name = "Desengrasante Industrial", Description = "Limpiador biodegradable", Code = "DES-IND-030", Category = lubricantes, UnitOfMeasure = litro }
                };

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }

            // =============================================
            // 8. MÁQUINAS DE CLIENTES
            // =============================================
            if (!context.Machines.Any())
            {
                var machines = new List<Machine>
                {
                    new Machine { Code = "MAQ-001", Description = "Heladera Comercial Exhibidora Coca-Cola 400L", ModelYear = 2020, IsActive = true },
                    new Machine { Code = "MAQ-002", Description = "Lavarropas Industrial Firbimatic 18kg", ModelYear = 2019, IsActive = true },
                    new Machine { Code = "MAQ-003", Description = "Horno Convector Eléctrico Rational 6 Bandejas", ModelYear = 2021, IsActive = true },
                    new Machine { Code = "MAQ-004", Description = "Compresor Atlas Copco GA11 75HP", ModelYear = 2018, IsActive = true },
                    new Machine { Code = "MAQ-005", Description = "Bomba Centrífuga Grundfos 10HP", ModelYear = 2020, IsActive = true }
                };

                context.Machines.AddRange(machines);
                await context.SaveChangesAsync();
            }

            await context.SaveChangesAsync();
        }
    }
}