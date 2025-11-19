using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystems.Models;
using PrimeSystems.Controllers;

namespace PrimeSystems.Core
{
    public class Tests
    {
        private AppDbContext _context;

        public Tests(AppDbContext context)
        {
            _context = context;
        }
        public bool PopulateDB()
        {
            try
            {
                Console.WriteLine("Iniciando población de base de datos...");

                PopulateRoles();

                PopulateUsers();

                PopulateClients();

                PopulateSuppliers();

                PopulateCategories();

                PopulateSubcategories();

                PopulateArticles();

                PopulateStock();

                PopulatePurchases();

                PopulateSells();

                PopulateActivityRecords();

                Console.WriteLine("Base de datos poblada exitosamente!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al poblar la base de datos: {ex.Message}");
                return false;
            }
        }

        private void PopulateRoles()
        {
            if (_context.UserType.Any())
            {
                Console.WriteLine("Roles ya existen, saltando...");
                return;
            }

            var roles = new List<RoleModel>
            {
                new RoleModel
                {
                    Id = "admin",
                    Name = "Administrador",
                    PurchasesPermission = AccessLevel.Write,
                    SellsPermission = AccessLevel.Write,
                    FinancialStatePermission = AccessLevel.Write,
                    UserPermission = AccessLevel.Write
                },
                new RoleModel
                {
                    Id = "vendedor",
                    Name = "Vendedor",
                    PurchasesPermission = AccessLevel.Read,
                    SellsPermission = AccessLevel.Write,
                    FinancialStatePermission = AccessLevel.Read,
                    UserPermission = AccessLevel.None
                },
                new RoleModel
                {
                    Id = "gestor_compras",
                    Name = "Gestor de Compras",
                    PurchasesPermission = AccessLevel.Write,
                    SellsPermission = AccessLevel.Read,
                    FinancialStatePermission = AccessLevel.Read,
                    UserPermission = AccessLevel.None
                }
            };

            _context.UserType.AddRange(roles);
            _context.SaveChanges();
            Console.WriteLine($"{roles.Count} roles creados");
        }

        private void PopulateUsers()
        {
            if (_context.User.Any())
            {
                Console.WriteLine("Usuarios ya existen, saltando...");
                return;
            }

            var users = new List<UserModel>
            {
                new UserModel
                {
                    Username = "admin",
                    PasswordHash = "admin",
                    Name = "Juan",
                    LastName = "Administrador",
                    PersonId = 20123456,
                    Email = "admin@primesystems.com",
                    Phone = "2221234567",
                    RoleId = "admin",
                    ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
                },
                new UserModel
                {
                    Username = "vendedor1",
                    PasswordHash = Utils.GenerateRandomString(12),
                    Name = "María",
                    LastName = "González",
                    PersonId = 27654321,
                    Email = "maria.gonzalez@primesystems.com",
                    Phone = "2221234568",
                    RoleId = "vendedor",
                    ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
                },
                new UserModel
                {
                    Username = "comprador1",
                    PasswordHash = Utils.GenerateRandomString(12),
                    Name = "Carlos",
                    LastName = "Martínez",
                    PersonId = 33987654,
                    Email = "carlos.martinez@primesystems.com",
                    Phone = "2221234569",
                    RoleId = "gestor_compras",
                    ProfilePicture = Utils.ImageToByteArray(Config.default_profile_picture)
                }
            };

            _context.User.AddRange(users);
            _context.SaveChanges();
            Console.WriteLine($"{users.Count} usuarios creados");
        }

        private void PopulateClients()
        {
            if (_context.Client.Any())
            {
                Console.WriteLine("Clientes ya existen, saltando...");
                return;
            }

            var clients = new List<ClientModel>
            {
                new ClientModel
                {
                    Cuit = 34567890,
                    Name = "Rodríguez",
                    Entity = "Empresa Construcciones S.A.",
                    Phone = "2211234567",
                    Email = "construcciones@email.com"
                },
                new ClientModel
                {
                    Cuit = 45678901,
                    Name = "López",
                    Entity = "Comercio El Progreso",
                    Phone = "2211234568",
                    Email = "progreso@email.com"
                },
                new ClientModel
                {
                    Cuit = 56789012,
                    Name = "Fernández",
                    Entity = "Ferretería Central",
                    Phone = "2211234569",
                    Email = "ferreteria@email.com"
                },
                new ClientModel
                {
                    Cuit = 67890123,
                    Name = "García",
                    Entity = "Mayorista Del Sur",
                    Phone = "2211234570",
                    Email = "mayorista@email.com"
                },
                new ClientModel
                {
                    Cuit = 78901234,
                    Name = "Pérez",
                    Entity = null,
                    Phone = "2211234571",
                    Email = "perez@email.com"
                }
            };

            _context.Client.AddRange(clients);
            _context.SaveChanges();
            Console.WriteLine($"{clients.Count} clientes creados");
        }

        private void PopulateSuppliers()
        {
            if (_context.Supplier.Any())
            {
                Console.WriteLine("Proveedores ya existen, saltando...");
                return;
            }

            var suppliers = new List<SupplierModel>
            {
                new SupplierModel
                {
                    Cuit = 67890123,
                    Name = "Distribuidora Piola",
                    ContactName = "Roberto Silva",
                    Phone = "1145678901",
                    Email = "contacto@distropiola.com"
                },
                new SupplierModel
                {
                    Cuit = 78901234,
                    Name = "Tecnología Piola",
                    ContactName = "Ana Morales",
                    Phone = "1145678902",
                    Email = "contacto@tecnopiola.com"
                },
                new SupplierModel
                {
                    Cuit = 89012345,
                    Name = "Mayorista Piola",
                    ContactName = "Diego Castro",
                    Phone = "1145678903",
                    Email = "contacto@mayoristapiola.com"
                },
                new SupplierModel
                {
                    Cuit = 90123456,
                    Name = "Electronica Piola",
                    ContactName = "Laura Benítez",
                    Phone = "1145678904",
                    Email = "contacto@electropiola.com"
                }
            };

            _context.Supplier.AddRange(suppliers);
            _context.SaveChanges();
            Console.WriteLine($"{suppliers.Count} proveedores creados");
        }

        private void PopulateCategories()
        {
            if (_context.Category.Any())
            {
                Console.WriteLine("Categorías ya existen, saltando...");
                return;
            }

            var categories = new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name = "Herramientas" },
                new CategoryModel { Id = 2, Name = "Electrónica" },
                new CategoryModel { Id = 3, Name = "Construcción" },
                new CategoryModel { Id = 4, Name = "Oficina" },
                new CategoryModel { Id = 5, Name = "Ferretería" }
            };

            _context.Category.AddRange(categories);
            _context.SaveChanges();
            Console.WriteLine($"{categories.Count} categorías creadas");
        }

        private void PopulateSubcategories()
        {
            if (_context.Subcategory.Any())
            {
                Console.WriteLine("Subcategorías ya existen, saltando...");
                return;
            }

            var subcategories = new List<SubcategoryModel>
            {
                                new SubcategoryModel { Name = "Manuales", CategoryId = 1 },
                new SubcategoryModel { Name = "Eléctricas", CategoryId = 1 },
                new SubcategoryModel { Name = "Medición", CategoryId = 1 },

                                new SubcategoryModel { Name = "Componentes", CategoryId = 2 },
                new SubcategoryModel { Name = "Cables", CategoryId = 2 },
                new SubcategoryModel { Name = "Iluminación", CategoryId = 2 },

                                new SubcategoryModel { Name = "Cemento y Mezclas", CategoryId = 3 },
                new SubcategoryModel { Name = "Pinturas", CategoryId = 3 },
                new SubcategoryModel { Name = "Materiales", CategoryId = 3 },

                                new SubcategoryModel { Name = "Papelería", CategoryId = 4 },
                new SubcategoryModel { Name = "Escritura", CategoryId = 4 },

                                new SubcategoryModel { Name = "Tornillería", CategoryId = 5 },
                new SubcategoryModel { Name = "Candados y Cerraduras", CategoryId = 5 }
            };

            _context.Subcategory.AddRange(subcategories);
            _context.SaveChanges();
            Console.WriteLine($"{subcategories.Count} subcategorías creadas");
        }

        private void PopulateArticles()
        {
            if (_context.Article.Any())
            {
                Console.WriteLine("Artículos ya existen, saltando...");
                return;
            }

            var suppliers = _context.Supplier.ToList();
            var subcategories = _context.Subcategory.ToList();

            var articles = new List<ArticleModel>
            {
                                new ArticleModel
                {
                    Code = "HM001",
                    Name = "Martillo de Carpintero 16 oz",
                    Description = "Martillo con mango de fibra de vidrio",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Manuales").Id,
                    SupplierId = suppliers[0].Id
                },
                new ArticleModel
                {
                    Code = "HM002",
                    Name = "Destornillador Phillips #2",
                    Description = "Destornillador punta phillips profesional",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Manuales").Id,
                    SupplierId = suppliers[0].Id
                },
                new ArticleModel
                {
                    Code = "HM003",
                    Name = "Alicate Universal 8\"",
                    Description = "Alicate con mango ergonómico",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Manuales").Id,
                    SupplierId = suppliers[2].Id
                },

                                new ArticleModel
                {
                    Code = "HE001",
                    Name = "Taladro Percutor 600W",
                    Description = "Taladro eléctrico con velocidad variable",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Eléctricas").Id,
                    SupplierId = suppliers[1].Id
                },
                new ArticleModel
                {
                    Code = "HE002",
                    Name = "Amoladora Angular 4.5\" 850W",
                    Description = "Amoladora con protector de disco",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Eléctricas").Id,
                    SupplierId = suppliers[1].Id
                },

                                new ArticleModel
                {
                    Code = "HMD001",
                    Name = "Cinta Métrica 5m",
                    Description = "Cinta métrica con freno automático",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Medición").Id,
                    SupplierId = suppliers[0].Id
                },
                new ArticleModel
                {
                    Code = "HMD002",
                    Name = "Nivel de Burbuja 60cm",
                    Description = "Nivel de aluminio con 3 burbujas",
                    CategoryId = 1,
                    SubcategoryId = subcategories.First(s => s.Name == "Medición").Id,
                    SupplierId = suppliers[2].Id
                },

                                new ArticleModel
                {
                    Code = "EC001",
                    Name = "Resistencias 1/4W Kit x100",
                    Description = "Kit de resistencias valores variados",
                    CategoryId = 2,
                    SubcategoryId = subcategories.First(s => s.Name == "Componentes").Id,
                    SupplierId = suppliers[3].Id
                },
                new ArticleModel
                {
                    Code = "EC002",
                    Name = "LED 5mm Blanco x10",
                    Description = "Pack de 10 LEDs blancos de alta luminosidad",
                    CategoryId = 2,
                    SubcategoryId = subcategories.First(s => s.Name == "Componentes").Id,
                    SupplierId = suppliers[3].Id
                },

                                new ArticleModel
                {
                    Code = "ECB001",
                    Name = "Cable Unipolar 2.5mm x 100m",
                    Description = "Cable de cobre para instalaciones",
                    CategoryId = 2,
                    SubcategoryId = subcategories.First(s => s.Name == "Cables").Id,
                    SupplierId = suppliers[3].Id
                },

                                new ArticleModel
                {
                    Code = "EI001",
                    Name = "Lámpara LED 9W Luz Fría",
                    Description = "Lámpara LED bajo consumo",
                    CategoryId = 2,
                    SubcategoryId = subcategories.First(s => s.Name == "Iluminación").Id,
                    SupplierId = suppliers[3].Id
                },

                                new ArticleModel
                {
                    Code = "CC001",
                    Name = "Cemento Portland 50kg",
                    Description = "Cemento para construcción general",
                    CategoryId = 3,
                    SubcategoryId = subcategories.First(s => s.Name == "Cemento y Mezclas").Id,
                    SupplierId = suppliers[0].Id
                },
                new ArticleModel
                {
                    Code = "CC002",
                    Name = "Cal Hidratada 25kg",
                    Description = "Cal para mezclas y revoques",
                    CategoryId = 3,
                    SubcategoryId = subcategories.First(s => s.Name == "Cemento y Mezclas").Id,
                    SupplierId = suppliers[0].Id
                },

                                new ArticleModel
                {
                    Code = "CP001",
                    Name = "Pintura Látex Interior Blanco 20L",
                    Description = "Pintura látex lavable",
                    CategoryId = 3,
                    SubcategoryId = subcategories.First(s => s.Name == "Pinturas").Id,
                    SupplierId = suppliers[2].Id
                },

                                new ArticleModel
                {
                    Code = "FT001",
                    Name = "Tornillo Autoperforante 8x1\" x100",
                    Description = "Tornillos para metal y madera",
                    CategoryId = 5,
                    SubcategoryId = subcategories.First(s => s.Name == "Tornillería").Id,
                    SupplierId = suppliers[2].Id
                },
                new ArticleModel
                {
                    Code = "FT002",
                    Name = "Tarugos Plásticos 8mm x100",
                    Description = "Tarugos para pared",
                    CategoryId = 5,
                    SubcategoryId = subcategories.First(s => s.Name == "Tornillería").Id,
                    SupplierId = suppliers[2].Id
                },

                                new ArticleModel
                {
                    Code = "FC001",
                    Name = "Candado Laminado 50mm",
                    Description = "Candado con arco de acero templado",
                    CategoryId = 5,
                    SubcategoryId = subcategories.First(s => s.Name == "Candados y Cerraduras").Id,
                    SupplierId = suppliers[0].Id
                },

                                new ArticleModel
                {
                    Code = "OP001",
                    Name = "Resma A4 75gr x500",
                    Description = "Resma de papel blanco",
                    CategoryId = 4,
                    SubcategoryId = subcategories.First(s => s.Name == "Papelería").Id,
                    SupplierId = suppliers[1].Id
                },
                new ArticleModel
                {
                    Code = "OE001",
                    Name = "Lapicera Azul x12",
                    Description = "Pack de lapiceras de tinta azul",
                    CategoryId = 4,
                    SubcategoryId = subcategories.First(s => s.Name == "Escritura").Id,
                    SupplierId = suppliers[1].Id
                }
            };

            _context.Article.AddRange(articles);
            _context.SaveChanges();
            Console.WriteLine($"{articles.Count} artículos creados");
        }

        private void PopulateStock()
        {
            if (_context.Stock.Any())
            {
                Console.WriteLine("Stock ya existe, saltando...");
                return;
            }

            var articles = _context.Article.ToList();
            var random = new Random();

            var stockList = new List<StockModel>();

            foreach (var article in articles)
            {
                decimal baseCost = article.Code.StartsWith("HE") ? 15000m : article.Code.StartsWith("CC") ? 8000m : article.Code.StartsWith("CP") ? 12000m : article.Code.StartsWith("ECB") ? 25000m : random.Next(500, 5000);
                int quantity = article.Code.StartsWith("EC") ? random.Next(100, 500) : article.Code.StartsWith("FT") ? random.Next(50, 200) : random.Next(10, 100);
                stockList.Add(new StockModel
                {
                    ArticleId = article.Id,
                    Stock = quantity,
                    Cost = baseCost.ToString("F2"),
                    Profit = random.Next(20, 50)
                });
            }

            _context.Stock.AddRange(stockList);
            _context.SaveChanges();
            Console.WriteLine($"{stockList.Count} registros de stock creados");
        }

        private void PopulatePurchases()
        {
            if (_context.Purchase.Any())
            {
                Console.WriteLine("Compras ya existen, saltando...");
                return;
            }

            var users = _context.User.ToList();
            var suppliers = _context.Supplier.ToList();
            var articles = _context.Article.ToList();
            var comprador = users.FirstOrDefault(u => u.RoleId == "gestor_compras") ?? users.First();

            var purchases = new List<PurchaseModel>
            {
                new PurchaseModel
                {
                    UserId = comprador.Id,
                    Date = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss"),
                    SupplierId = suppliers[0].Id,
                    Subtotal = "45000.00",
                    Discount = "2250.00",
                    Total = "42750.00"
                },
                new PurchaseModel
                {
                    UserId = comprador.Id,
                    Date = DateTime.Now.AddDays(-25).ToString("yyyy-MM-dd HH:mm:ss"),
                    SupplierId = suppliers[1].Id,
                    Subtotal = "89000.00",
                    Discount = "4450.00",
                    Total = "84550.00"
                },
                new PurchaseModel
                {
                    UserId = comprador.Id,
                    Date = DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd HH:mm:ss"),
                    SupplierId = suppliers[2].Id,
                    Subtotal = "32500.00",
                    Discount = "0.00",
                    Total = "32500.00"
                }
            };

            _context.Purchase.AddRange(purchases);
            _context.SaveChanges();

            var purchaseDetails = new List<PurchaseDetailModel>();

            var purchase1Articles = articles.Where(a => a.SupplierId == suppliers[0].Id).Take(3).ToList();
            foreach (var article in purchase1Articles)
            {
                var stock = _context.Stock.FirstOrDefault(s => s.ArticleId == article.Id);
                if (stock != null)
                {
                    purchaseDetails.Add(new PurchaseDetailModel
                    {
                        PurchaseId = purchases[0].Id,
                        ArticleId = article.Id,
                        Description = article.Description,
                        UnitPrice = stock.Cost,
                        Quantity = "20"
                    });
                }
            }

            var purchase2Articles = articles.Where(a => a.SupplierId == suppliers[1].Id).Take(4).ToList();
            foreach (var article in purchase2Articles)
            {
                var stock = _context.Stock.FirstOrDefault(s => s.ArticleId == article.Id);
                if (stock != null)
                {
                    purchaseDetails.Add(new PurchaseDetailModel
                    {
                        PurchaseId = purchases[1].Id,
                        ArticleId = article.Id,
                        Description = article.Description,
                        UnitPrice = stock.Cost,
                        Quantity = "15"
                    });
                }
            }

            var purchase3Articles = articles.Where(a => a.SupplierId == suppliers[2].Id).Take(5).ToList();
            foreach (var article in purchase3Articles)
            {
                var stock = _context.Stock.FirstOrDefault(s => s.ArticleId == article.Id);
                if (stock != null)
                {
                    purchaseDetails.Add(new PurchaseDetailModel
                    {
                        PurchaseId = purchases[2].Id,
                        ArticleId = article.Id,
                        Description = article.Description,
                        UnitPrice = stock.Cost,
                        Quantity = "10"
                    });
                }
            }

            _context.PurchaseDetail.AddRange(purchaseDetails);
            _context.SaveChanges();
            Console.WriteLine($"{purchases.Count} compras y {purchaseDetails.Count} detalles creados");
        }

        private void PopulateSells()
        {
            if (_context.Sell.Any())
            {
                Console.WriteLine("Ventas ya existen, saltando...");
                return;
            }

            var users = _context.User.ToList();
            var clients = _context.Client.ToList();
            var articles = _context.Article.ToList();
            var vendedor = users.FirstOrDefault(u => u.RoleId == "vendedor") ?? users.First();

            var sells = new List<SellModel>
            {
                new SellModel
                {
                    UserId = vendedor.Id,
                    Date = DateTime.Now.AddDays(-20).ToString("yyyy-MM-dd HH:mm:ss"),
                    ClientId = clients[0].Id,
                    Subtotal = "28500.00",
                    Discount = "1425.00",
                    Total = "27075.00"
                },
                new SellModel
                {
                    UserId = vendedor.Id,
                    Date = DateTime.Now.AddDays(-18).ToString("yyyy-MM-dd HH:mm:ss"),
                    ClientId = clients[1].Id,
                    Subtotal = "15200.00",
                    Discount = "0.00",
                    Total = "15200.00"
                },
                new SellModel
                {
                    UserId = vendedor.Id,
                    Date = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"),
                    ClientId = clients[2].Id,
                    Subtotal = "42800.00",
                    Discount = "2140.00",
                    Total = "40660.00"
                },
                new SellModel
                {
                    UserId = vendedor.Id,
                    Date = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss"),
                    ClientId = clients[3].Id,
                    Subtotal = "19500.00",
                    Discount = "975.00",
                    Total = "18525.00"
                }
            };

            _context.Sell.AddRange(sells);
            _context.SaveChanges();

            var sellDetails = new List<SellDetailModel>();
            var random = new Random();

            foreach (var sell in sells)
            {
                int numArticles = random.Next(2, 6);
                var selectedArticles = articles.OrderBy(x => random.Next()).Take(numArticles).ToList();

                foreach (var article in selectedArticles)
                {
                    sellDetails.Add(new SellDetailModel
                    {
                        SellId = sell.Id,
                        ArticleId = article.Id,
                        Quantity = random.Next(1, 10)
                    });
                }
            }

            _context.SellDetail.AddRange(sellDetails);
            _context.SaveChanges();
            Console.WriteLine($"{sells.Count} ventas y {sellDetails.Count} detalles creados");
        }

        private void PopulateActivityRecords()
        {
            if (_context.Transaction.Any())
            {
                Console.WriteLine("Registros de actividad ya existen, saltando...");
                return;
            }

            var users = _context.User.ToList();
            var purchases = _context.Purchase.ToList();
            var sells = _context.Sell.ToList();
            var articles = _context.Article.Take(5).ToList();
            var clients = _context.Client.Take(3).ToList();
            var suppliers = _context.Supplier.Take(2).ToList();

            var activities = new List<ActivityRecordModel>
            {
                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Purchases,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-30),
                    PurchaseId = purchases[0].Id,
                    SupplierId = purchases[0].SupplierId
                },
                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Purchases,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-25),
                    PurchaseId = purchases[1].Id,
                    SupplierId = purchases[1].SupplierId
                },

                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Sells,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-20),
                    SellId = sells[0].Id,
                    ClientId = sells[0].ClientId
                },
                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Sells,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-18),
                    SellId = sells[1].Id,
                    ClientId = sells[1].ClientId
                },

                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Articles,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-35),
                    ArticleId = articles[0].Id
                },
                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Articles,
                    Action = ActivityActions.Update,
                    Date = DateTime.Now.AddDays(-22),
                    ArticleId = articles[1].Id
                },

                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Clients,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-40),
                    ClientId = clients[0].Id
                },

                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Suppliers,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-45),
                    SupplierId = suppliers[0].Id
                },

                new ActivityRecordModel
                {
                    UserId = users.First().Id,
                    Module = ActivityModules.Users,
                    Action = ActivityActions.Create,
                    Date = DateTime.Now.AddDays(-50)
                }
            };

            _context.Transaction.AddRange(activities);
            _context.SaveChanges();
            Console.WriteLine($"{activities.Count} registros de actividad creados");
        }

        public bool ClearDatabase()
        {
            try
            {
                Console.WriteLine("Limpiando base de datos...");

                _context.Transaction.RemoveRange(_context.Transaction);
                _context.SellDetail.RemoveRange(_context.SellDetail);
                _context.Sell.RemoveRange(_context.Sell);
                _context.PurchaseDetail.RemoveRange(_context.PurchaseDetail);
                _context.Purchase.RemoveRange(_context.Purchase);
                _context.Stock.RemoveRange(_context.Stock);
                _context.Article.RemoveRange(_context.Article);
                _context.Subcategory.RemoveRange(_context.Subcategory);
                _context.Category.RemoveRange(_context.Category);
                _context.Supplier.RemoveRange(_context.Supplier);
                _context.Client.RemoveRange(_context.Client);
                _context.User.RemoveRange(_context.User);
                _context.UserType.RemoveRange(_context.UserType);

                _context.SaveChanges();
                Console.WriteLine("Base de datos limpiada exitosamente");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al limpiar la base de datos: {ex.Message}");
                return false;
            }
        }
    }
}
