using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        private static readonly DateTime Start = new DateTime(2026, 1, 5);

        private static readonly string[] FirstNames =
        {
            "Eva", "Marta", "Karl", "Mari", "Jaan", "Liis", "Kristjan", "Triinu", "Margus", "Helena",
            "Tõnis", "Anu", "Indrek", "Kaidi", "Toomas", "Merle", "Rain", "Sirje", "Urmas", "Kaie",
            "Peeter", "Piret", "Rein", "Kristiina", "Andrus", "Heli", "Jüri", "Maarja", "Aivar", "Tiina",
            "Olavi", "Virve", "Kalev", "Annely", "Tiit", "Pille"
        };

        private static readonly string[] LastNames =
        {
            "Aibast", "Kask", "Tamm", "Sepp", "Ilves", "Kallas", "Oja", "Pärn", "Rebane", "Saar",
            "Vaher", "Kuusk", "Mets", "Laan", "Nurm", "Põld", "Riis", "Sarv", "Tuul", "Varas",
            "Õun", "Kivi", "Kukk", "Lepp", "Mägi", "Papp", "Rahu", "Sild", "Teras", "Vilu",
            "Äär", "Ööp", "Üllar", "Annik", "Koort", "Rõõm"
        };

        private static readonly string[] Cities =
        {
            "Tallinn", "Tartu", "Pärnu", "Narva", "Kohtla-Järve", "Viljandi",
            "Haapsalu", "Kuressaare", "Rakvere", "Valga", "Võru", "Jõgeva"
        };

        private static readonly string[] Streets =
        {
            "Tartu maantee", "Tallinna tänav", "Narva maantee", "Vabaduse puiestee", "Pikk tänav",
            "Lai tänav", "Kesk tänav", "Võru tänav", "Pärnu maantee", "Viljandi tänav",
            "Tehase tänav", "Kooli tänav", "Aia tänav", "Jõe tänav"
        };

        private static readonly string[] CategoryNames =
        {
            "Elektroonika", "Arvutid", "Sülearvutid", "Tahvelarvutid", "Telefonid", "Kõrvaklapid",
            "Kõlarid", "Kodumasinad", "Köögitehnika", "Mööbel", "Kontoritoolid", "Meeste riided",
            "Naiste riided", "Laste riided", "Jalatsid", "Kotid", "Sport", "Matkavarustus",
            "Tennis", "Jooksmine", "Raamatud", "Õpikud", "Lasteraamatud", "Filmid ja seriaalid",
            "Mänguasjad", "Lauamängud", "Arvutimängud", "Muusika", "Fototehnika", "Aiatarbed",
            "Tööriistad", "Auto tarvikud", "Ilu ja hooldus", "Tervis", "Lemmikloomad", "Kingitused"
        };

        private static readonly string[] DepartmentNames =
        {
            "Müük", "Turundus", "Klienditeenindus", "Laohaldus", "Logistika", "IT",
            "Raamatupidamine", "Personaliarvestus", "Hanked", "Arendus", "Tootejuhtimine",
            "Kvaliteedikontroll", "Turvalisus", "Õigus", "Disain", "Analüütika", "Veebiarendus",
            "Andmebaasid", "Sisu", "Avalikud suhted", "Tarneahel", "Müügitoetus", "Tehniline tugi",
            "Kampaaniad", "Partnerlused", "Transport", "Pakkimine", "Sorteerimine", "Kinnisvara",
            "Tehnika", "Hooldus", "Koolitus", "Kvaliteediaruanne", "Areng", "Juhtimine", "Vahetustöö"
        };

        private static readonly string[] BrandNames =
        {
            "Logitech", "Dell", "Apple", "Samsung", "Lenovo", "HP", "Asus", "Acer", "MSI", "Keychron",
            "Razer", "Sony", "LG", "Philips", "JBL", "Bosch", "Miele", "Nike", "Adidas", "Puma",
            "H&M", "Zara", "Levis", "New Balance", "The North Face", "Decathlon", "IKEA", "MUJI",
            "Canon", "Nikon", "Fujifilm", "Garmin", "Suunto", "Fjallraven", "Tommy Hilfiger", "Philips Hue"
        };

        private static readonly string[] ProductNames =
        {
            "Logitech G502 hiir", "Keychron K2 klaviatuur", "Dell U2723QE monitor", "Lenovo IdeaPad Slim3 sularvuti",
            "HP Pavilion 14 sularvuti", "Samsung Galaxy S25 telefon", "iPhone 16 telefon", "Sony WH-1000XM5 klapid",
            "JBL Flip 6 kõlar", "Apple Watch SE kell", "Garmin Forerunner 265 kell", "Canon EOS R50 kaamera",
            "Fujifilm X-T50 kaamera", "Nike Air Max tossud", "Adidas Ultraboost tossud", "The North Face jope",
            "Fjallraven Kånken kott", "Levis 501 püksid", "HM puuvillane särk", "Zara kleit",
            "IKEA Markus tool", "Bosch köögikombain", "Miele tolmuimeja", "Philips hambahari",
            "ASUS RT-AX86U ruuter", "Samsung T7 SSD 512GB", "Kingston Fury RAM 16GB", "MSI RTX 4060 graafikakaart",
            "ASP.NET Core Mastery raamat", "C# ja andmebaasid raamat", "Clean Code raamat", "Laine romaan",
            "Decathlon matkakott", "Suunto sukeldumiskell", "Tommy Hilfiger kampsun", "New Balance 574 tossud"
        };

        private static readonly string[] CurrencyData =
        {
            "EUR|Euro|€", "USD|USA dollar|$", "GBP|Suurbritannia nael|£", "JPY|Jeeni|¥",
            "CHF|Šveitsi frank|fr", "SEK|Rootsi kroon|kr", "NOK|Norra kroon|kr", "DKK|Taani kroon|kr",
            "PLN|Poola zloot|zł", "CZK|Tšehhi kroon|Kč", "HUF|Ungari forint|Ft", "RON|Rumeenia lei|lei",
            "BGN|Bulgaaria leev|lev", "HRK|Horvaatia kuna|kn", "RSD|Serbia dinar|din", "UAH|Ukraina grivna|грн",
            "RUB|Vene rubla|₽", "TRY|Türgi liira|₺", "CNY|Hiina jüaan|¥", "HKD|Hongkongi dollar|HK$",
            "SGD|Singapuri dollar|S$", "KRW|Korea won|₩", "INR|India rupee|₹", "AUD|Austraalia dollar|A$",
            "NZD|Uus-Meremaa dollar|NZ$", "CAD|Kanada dollar|C$", "BRL|Brasiilia real|R$", "MXN|Mehhiko peso|Mex$",
            "ZAR|Lõuna-Aafrika rand|R", "ILS|Iisraeli shekel|₪", "AED|Araabia ÜE dirham|د.إ", "SAR|Saudi riaal|﷼",
            "THB|Tai baht|฿", "MYR|Malaisia ringgit|RM", "IDR|Indoneesia rupiah|Rp", "PHP|Filipiinide peso|₱"
        };

        private static readonly string[] CountryNames =
        {
            "Eesti", "Soome", "Rootsi", "Läti", "Leedu", "Saksamaa", "Prantsusmaa", "Hispaania",
            "Itaalia", "Poola", "Tšehhi", "Ungari", "Rumeenia", "Bulgaaria", "Kreeka", "Portugal",
            "Belgia", "Holland", "Iirimaa", "Austria", "Slovakkia", "Sloveenia", "Horvaatia", "Taani",
            "Ühendkuningriik", "Šveits", "Norra", "Ukraina", "Türgi", "USA", "Kanada", "Jaapan",
            "Hiina", "Austraalia", "Brasiilia", "Lõuna-Aafrika"
        };

        private static readonly decimal[] VatValues =
        {
            24m, 25.5m, 25m, 21m, 21m, 19m, 20m, 21m, 22m, 23m, 21m, 27m, 19m, 20m, 24m, 23m,
            21m, 21m, 23m, 20m, 20m, 22m, 25m, 25m, 20m, 8.1m, 25m, 20m, 20m, 7.25m, 5m, 10m,
            13m, 10m, 17m, 15m
        };

        private static readonly string[] CarrierNames =
        {
            "Omniva", "DPD", "SmartPOST", "DHL", "FedEx", "UPS", "GLS", "Venipak", "Itella", "Baltic Logistics",
            "Eesti Kaubavedu", "Põhja Logistika", "Lõuna Kaubavedu", "Kiirpost", "Meri Transport"
        };

        public static void Generate(ApplicationDbContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            SeedCustomerGroups(context);
            SeedCurrencies(context);
            SeedVatRates(context);
            SeedDepartments(context);
            SeedBrands(context);
            SeedCategories(context);
            SeedCustomers(context);
            SeedAddresses(context);
            SeedCarriers(context);
            SeedWarehouses(context);
            SeedSuppliers(context);
            SeedEmployees(context);
            SeedEmployeeRoles(context);
            SeedProducts(context);
            SeedProductImages(context);
            SeedProductVideos(context);
            SeedProductOptions(context);
            SeedOptionValues(context);
            SeedProductVariants(context);
            SeedVariantOptions(context);
            SeedPriceHistory(context);
            SeedCampaigns(context);
            SeedCampaignProducts(context);
            SeedCoupons(context);
            SeedShoppingCarts(context);
            SeedCartItems(context);
            SeedWishlists(context);
            SeedWishlistItems(context);
            SeedOrders(context);
            SeedOrderLines(context);
            SeedOrderStatusHistory(context);
            SeedPayments(context);
            SeedRefunds(context);
            SeedReturnRequests(context);
            SeedReturnLines(context);
            SeedShipments(context);
            SeedShipmentTrackings(context);
            SeedStockLevels(context);
            SeedStockMovements(context);
            SeedWarehouseTransfers(context);
            SeedWarehouseTransferLines(context);
            SeedPurchaseOrders(context);
            SeedPurchaseOrderLines(context);
            SeedGoodsReceipts(context);
            SeedExchangeRates(context);
            SeedLoyaltyAccounts(context);
            SeedLoyaltyPoints(context);
            SeedGiftCards(context);
            SeedReviews(context);
            SeedReviewResponses(context);
            SeedReviewImages(context);
            SeedSupportTickets(context);
            SeedTicketMessages(context);
            SeedNotifications(context);
            SeedAuditLogs(context);
        }

        private static void SeedCustomerGroups(ApplicationDbContext context)
        {
            var tiers = new[] { "Tavaline", "Hõbe", "Kuld", "Plaatina", "Teemant" };
            var groups = new List<CustomerGroup>();

            for (var i = 0; i < 36; i++)
            {
                groups.Add(new CustomerGroup
                {
                    GroupName = i < 5 ? tiers[i] : "Soodustusklubi " + (i + 1),
                    DiscountPercent = i < 5 ? i * 5m : (i % 25) + 1m
                });
            }

            context.CustomerGroups.AddRange(groups);
            context.SaveChanges();
        }

        private static void SeedCurrencies(ApplicationDbContext context)
        {
            var currencies = new List<Currency>();

            for (var i = 0; i < 36; i++)
            {
                var parts = CurrencyData[i].Split('|');
                currencies.Add(new Currency
                {
                    Code = parts[0],
                    Name = parts[1],
                    Symbol = parts[2]
                });
            }

            context.Currencies.AddRange(currencies);
            context.SaveChanges();
        }

        private static void SeedVatRates(ApplicationDbContext context)
        {
            var rates = new List<VatRate>();

            for (var i = 0; i < 36; i++)
            {
                rates.Add(new VatRate
                {
                    Country = CountryNames[i],
                    Rate = VatValues[i],
                    ValidFrom = new DateTime(2024, 1, 1),
                    ValidTo = new DateTime(2030, 12, 31)
                });
            }

            context.VatRates.AddRange(rates);
            context.SaveChanges();
        }

        private static void SeedDepartments(ApplicationDbContext context)
        {
            var departments = new List<Department>();

            for (var i = 0; i < 36; i++)
            {
                departments.Add(new Department
                {
                    Name = DepartmentNames[i]
                });
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }

        private static void SeedBrands(ApplicationDbContext context)
        {
            var brands = new List<Brand>();

            for (var i = 0; i < 36; i++)
            {
                var slug = BrandNames[i].ToLower().Replace(" ", "").Replace("&", "and").Replace("'", "");
                brands.Add(new Brand
                {
                    Name = BrandNames[i],
                    Website = "https://www." + slug + ".com"
                });
            }

            context.Brands.AddRange(brands);
            context.SaveChanges();
        }

        private static void SeedCategories(ApplicationDbContext context)
        {
            var categories = new List<Category>();

            for (var i = 0; i < 36; i++)
            {
                categories.Add(new Category
                {
                    ParentCategoryId = i < 6 ? 0 : (i % 6) + 1,
                    Name = CategoryNames[i],
                    Description = "Kategooria " + CategoryNames[i] + " tooted"
                });
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedCustomers(ApplicationDbContext context)
        {
            var customers = new List<Customer>();

            for (var i = 0; i < 36; i++)
            {
                customers.Add(new Customer
                {
                    Email = "klient" + (i + 1) + "@epood.ee",
                    PasswordHash = "$2a$11$" + (i + 1).ToString("D4") + "Xk9mQ2pL7vR4tN8sB1cD5fG6hJ0",
                    FirstName = FirstNames[i],
                    LastName = LastNames[i],
                    Phone = "+3725" + (5000000 + i).ToString(),
                    Status = i % 9 == 0 ? "Blokeeritud" : "Aktiivne",
                    CreatedAt = Start.AddDays(i * 5),
                    LastLogin = Start.AddDays(180 + i)
                });
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void SeedAddresses(ApplicationDbContext context)
        {
            var addresses = new List<Address>();

            for (var i = 0; i < 36; i++)
            {
                addresses.Add(new Address
                {
                    CustomerId = (i % 36) + 1,
                    Country = "Eesti",
                    City = Cities[i % Cities.Length],
                    PostalCode = "1" + (1000 + i * 7).ToString("D4"),
                    Street = Streets[i % Streets.Length],
                    HouseNumber = (i + 1).ToString(),
                    Apartment = i % 3 == 0 ? "B" + ((i % 8) + 1) : null,
                    IsDefault = i % 4 == 0
                });
            }

            context.Addresses.AddRange(addresses);
            context.SaveChanges();
        }

        private static void SeedCarriers(ApplicationDbContext context)
        {
            var carriers = new List<Carrier>();

            for (var i = 0; i < 36; i++)
            {
                var baseName = CarrierNames[i % CarrierNames.Length];
                var repeat = i / CarrierNames.Length;
                var name = repeat == 0 ? baseName : baseName + " " + (repeat + 1);
                var slug = baseName.ToLower().Replace(" ", "");
                carriers.Add(new Carrier
                {
                    Name = name,
                    Website = "https://www." + slug + ".ee"
                });
            }

            context.Carriers.AddRange(carriers);
            context.SaveChanges();
        }

        private static void SeedWarehouses(ApplicationDbContext context)
        {
            var warehouses = new List<Warehouse>();

            for (var i = 0; i < 36; i++)
            {
                var city = Cities[i % Cities.Length];
                var repeat = i / Cities.Length;
                warehouses.Add(new Warehouse
                {
                    Name = repeat == 0 ? city + " ladu" : city + " ladu " + (repeat + 1),
                    AddressId = (i % 36) + 1
                });
            }

            context.Warehouses.AddRange(warehouses);
            context.SaveChanges();
        }

        private static void SeedSuppliers(ApplicationDbContext context)
        {
            var suppliers = new List<Supplier>();

            for (var i = 0; i < 36; i++)
            {
                suppliers.Add(new Supplier
                {
                    Name = BrandNames[i] + " Baltic OÜ",
                    ContactEmail = "tarne" + (i + 1) + "@baltic-tarne.ee",
                    Phone = "+3726" + (400000 + i).ToString(),
                    ContractReference = "LEPING-" + (2021 + (i % 5)) + "-" + (i + 1).ToString("D3")
                });
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void SeedEmployees(ApplicationDbContext context)
        {
            var employees = new List<Employee>();

            for (var i = 0; i < 36; i++)
            {
                employees.Add(new Employee
                {
                    Name = FirstNames[i] + " " + LastNames[i],
                    Email = "töötaja" + (i + 1) + "@epood.ee",
                    PasswordHash = "$2a$11$" + (i + 1).ToString("D4") + "Yp8nR3qM6uS9wE2xA7bC1dF5gH4",
                    DepartmentId = (i % 36) + 1,
                    CreatedAt = Start.AddDays(i * 4)
                });
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        private static void SeedEmployeeRoles(ApplicationDbContext context)
        {
            var roles = new[] { "Admin", "Müügijuht", "Klienditeenindaja", "Laotöötaja", "Turundusspetsialist", "Arendaja", "Raamatupidaja", "Logistik" };
            var employeeRoles = new List<EmployeeRole>();

            for (var i = 0; i < 36; i++)
            {
                employeeRoles.Add(new EmployeeRole
                {
                    EmployeeId = (i % 36) + 1,
                    Role = roles[i % roles.Length]
                });
            }

            context.EmployeeRoles.AddRange(employeeRoles);
            context.SaveChanges();
        }

        private static void SeedProducts(ApplicationDbContext context)
        {
            var products = new List<Product>();

            for (var i = 0; i < 36; i++)
            {
                var price = Math.Round(12.90m + (i % 18) * 29.50m + (i / 18) * 150m, 2);
                products.Add(new Product
                {
                    CategoryId = (i % 36) + 1,
                    BrandId = (i % 36) + 1,
                    Name = ProductNames[i],
                    Description = ProductNames[i] + " - kvaliteetne toode, sobib nii koju kui kontorisse.",
                    BasePrice = Math.Round(price * 0.8m, 2),
                    Price = price,
                    WeightKg = Math.Round(0.2m + (i % 10) * 0.45m, 2),
                    ImageUrl = "/images/tooted/" + (i + 1) + ".jpg",
                    Status = i % 7 == 0 ? "Inactive" : "Active",
                    CreatedAt = Start.AddDays(i * 3)
                });
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void SeedProductImages(ApplicationDbContext context)
        {
            var images = new List<ProductImage>();

            for (var i = 0; i < 36; i++)
            {
                images.Add(new ProductImage
                {
                    ProductId = (i % 36) + 1,
                    Url = "https://cdn.epood.ee/tooted/" + ((i % 36) + 1) + "-" + ((i / 36) + 1) + ".jpg",
                    AltText = "Toode " + ((i % 36) + 1) + " pilt " + ((i % 3) + 1),
                    SortOrder = (i % 3) + 1,
                    IsMain = i % 3 == 0
                });
            }

            context.ProductImages.AddRange(images);
            context.SaveChanges();
        }

        private static void SeedProductVideos(ApplicationDbContext context)
        {
            var titles = new[] { "Toote ülevaade", "Unboxing", "Paigaldusjuhend", "Kasutusnäide" };
            var videos = new List<ProductVideo>();

            for (var i = 0; i < 36; i++)
            {
                videos.Add(new ProductVideo
                {
                    ProductId = (i % 36) + 1,
                    Url = "https://www.youtube.com/watch?v=epood" + (i + 1).ToString("D4"),
                    Title = ProductNames[i % ProductNames.Length] + " - " + titles[i % titles.Length]
                });
            }

            context.ProductVideos.AddRange(videos);
            context.SaveChanges();
        }

        private static void SeedProductOptions(ApplicationDbContext context)
        {
            var optionNames = new[] { "Värv", "Suurus", "Materjal", "Mõõt" };
            var options = new List<ProductOption>();

            for (var i = 0; i < 36; i++)
            {
                options.Add(new ProductOption
                {
                    ProductId = (i % 36) + 1,
                    Name = optionNames[i % optionNames.Length]
                });
            }

            context.ProductOptions.AddRange(options);
            context.SaveChanges();
        }

        private static void SeedOptionValues(ApplicationDbContext context)
        {
            var values = new[] { "Must", "Valge", "Punane", "S", "M", "L", "XL", "Puit", "Metall", "Puuvill" };
            var optionValues = new List<OptionValue>();

            for (var i = 0; i < 36; i++)
            {
                optionValues.Add(new OptionValue
                {
                    ProductOptionId = (i % 36) + 1,
                    Value = values[i % values.Length]
                });
            }

            context.OptionValues.AddRange(optionValues);
            context.SaveChanges();
        }

        private static void SeedProductVariants(ApplicationDbContext context)
        {
            var variants = new List<ProductVariant>();

            for (var i = 0; i < 36; i++)
            {
                variants.Add(new ProductVariant
                {
                    ProductId = (i % 36) + 1,
                    ProductCode = "VAR-" + (i + 1).ToString("D3"),
                    Barcode = "474" + (1000000000 + i * 13).ToString(),
                    Price = Math.Round(12.90m + (i % 18) * 29.50m + (i / 18) * 150m, 2),
                    WeightKg = Math.Round(0.2m + (i % 10) * 0.45m, 2),
                    Status = i % 6 == 0 ? "Inactive" : "Active"
                });
            }

            context.ProductVariants.AddRange(variants);
            context.SaveChanges();
        }

        private static void SeedVariantOptions(ApplicationDbContext context)
        {
            var variantOptions = new List<VariantOption>();

            for (var i = 0; i < 36; i++)
            {
                variantOptions.Add(new VariantOption
                {
                    VariantId = (i % 36) + 1,
                    OptionValueId = (i % 36) + 1
                });
            }

            context.VariantOptions.AddRange(variantOptions);
            context.SaveChanges();
        }

        private static void SeedPriceHistory(ApplicationDbContext context)
        {
            var history = new List<PriceHistory>();

            for (var i = 0; i < 36; i++)
            {
                history.Add(new PriceHistory
                {
                    VariantId = (i % 36) + 1,
                    CurrentPrice = Math.Round(12.90m + (i % 18) * 29.50m, 2),
                    ValidFrom = Start.AddDays(i * 7),
                    ValidTo = Start.AddDays(i * 7 + 90)
                });
            }

            context.PriceHistories.AddRange(history);
            context.SaveChanges();
        }

        private static void SeedCampaigns(ApplicationDbContext context)
        {
            var baseNames = new[]
            {
                "Süvismüük", "Jõulukampaania", "Suvemüük", "Kevadmüük", "Must reede", "Aasta alguse soodustus",
                "Kliendipäev", "Uue kliendi soodustus", "Nädalapakkumised", "Naistepäev", "Isadepäev", "Emadepäev"
            };
            var campaigns = new List<Campaign>();

            for (var i = 0; i < 36; i++)
            {
                var repeat = i / baseNames.Length;
                campaigns.Add(new Campaign
                {
                    Name = repeat == 0 ? baseNames[i] : baseNames[i % baseNames.Length] + " " + (repeat + 1),
                    Description = "Kampaania " + (i + 1) + " - valik tooteid soodushinnaga.",
                    StartDate = Start.AddDays(i * 10),
                    EndDate = Start.AddDays(i * 10 + 21),
                    Status = i % 3 == 0 ? "Aktiivne" : "Lõppenud"
                });
            }

            context.Campaigns.AddRange(campaigns);
            context.SaveChanges();
        }

        private static void SeedCampaignProducts(ApplicationDbContext context)
        {
            var items = new List<CampaignProduct>();

            for (var i = 0; i < 36; i++)
            {
                items.Add(new CampaignProduct
                {
                    CampaignId = (i % 36) + 1,
                    ProductId = (i % 36) + 1,
                    DiscountPercent = (i % 30) + 5m
                });
            }

            context.CampaignProducts.AddRange(items);
            context.SaveChanges();
        }

        private static void SeedCoupons(ApplicationDbContext context)
        {
            var coupons = new List<Coupon>();

            for (var i = 0; i < 36; i++)
            {
                coupons.Add(new Coupon
                {
                    CampaignId = (i % 36) + 1,
                    Code = "SOODUS" + (i + 1).ToString("D3"),
                    UsageLimit = 50 + (i % 10) * 25,
                    UsedCount = (i * 3) % 60,
                    MinimumOrderAmount = (i % 4) * 25m
                });
            }

            context.Coupons.AddRange(coupons);
            context.SaveChanges();
        }

        private static void SeedShoppingCarts(ApplicationDbContext context)
        {
            var carts = new List<ShoppingCart>();

            for (var i = 0; i < 36; i++)
            {
                carts.Add(new ShoppingCart
                {
                    CustomerId = (i % 36) + 1,
                    CreatedAt = Start.AddDays(i * 6),
                    UpdatedAt = Start.AddDays(i * 6 + 2)
                });
            }

            context.ShoppingCarts.AddRange(carts);
            context.SaveChanges();
        }

        private static void SeedCartItems(ApplicationDbContext context)
        {
            var items = new List<CartItem>();

            for (var i = 0; i < 36; i++)
            {
                items.Add(new CartItem
                {
                    CartId = (i % 36) + 1,
                    VariantId = (i % 36) + 1,
                    Quantity = (i % 3) + 1,
                    UnitPrice = Math.Round(12.90m + (i % 18) * 29.50m, 2)
                });
            }

            context.CartItems.AddRange(items);
            context.SaveChanges();
        }

        private static void SeedWishlists(ApplicationDbContext context)
        {
            var names = new[] { "Soovid", "Jõuludeks", "Sünnipäevaks", "Uus kodu", "Spordihooaeg", "Reisikott", "Kooliks", "Kontoriks" };
            var wishlists = new List<Wishlist>();

            for (var i = 0; i < 36; i++)
            {
                var repeat = i / names.Length;
                wishlists.Add(new Wishlist
                {
                    CustomerId = (i % 36) + 1,
                    Name = repeat == 0 ? names[i] : names[i % names.Length] + " " + (repeat + 1),
                    CreatedAt = Start.AddDays(i * 6)
                });
            }

            context.Wishlists.AddRange(wishlists);
            context.SaveChanges();
        }

        private static void SeedWishlistItems(ApplicationDbContext context)
        {
            var items = new List<WishlistItem>();

            for (var i = 0; i < 36; i++)
            {
                items.Add(new WishlistItem
                {
                    WishlistId = (i % 36) + 1,
                    VariantId = (i % 36) + 1,
                    AddedAt = Start.AddDays(i * 6 + 1)
                });
            }

            context.WishlistItems.AddRange(items);
            context.SaveChanges();
        }

        private static void SeedOrders(ApplicationDbContext context)
        {
            var statuses = new[] { "pending", "paid", "shipped", "delivered" };
            var orders = new List<Order>();

            for (var i = 0; i < 36; i++)
            {
                var price1 = Math.Round(12.90m + ((i * 2) % 18) * 29.50m, 2);
                var price2 = Math.Round(12.90m + ((i * 2 + 1) % 18) * 29.50m, 2);
                var subtotal = price1 + price2;
                var discount = i % 4 == 0 ? Math.Round(subtotal * 0.1m, 2) : 0m;
                var shipping = subtotal > 100m ? 0m : 4.99m;
                var step = i % 4;
                var orderDate = Start.AddDays(60 + i * 3);

                orders.Add(new Order
                {
                    OrderNumber = 2001 + i,
                    CustomerId = (i % 36) + 1,
                    InvoiceAddressId = (i % 36) + 1,
                    DeliveryAddressId = (i % 36) + 1,
                    OrderDate = orderDate,
                    PaidAt = step == 0 ? (DateTime?)null : orderDate.AddHours(2),
                    SentAt = step < 2 ? (DateTime?)null : orderDate.AddDays(1),
                    DeliveredAt = step < 3 ? (DateTime?)null : orderDate.AddDays(3),
                    Subtotal = subtotal,
                    Discount = discount,
                    Vat = Math.Round(subtotal * 0.24m, 2),
                    ShippingCost = shipping,
                    Amount = subtotal - discount + shipping,
                    Status = statuses[step]
                });
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        private static void SeedOrderLines(ApplicationDbContext context)
        {
            var lines = new List<OrderLine>();

            for (var i = 0; i < 72; i++)
            {
                var orderIndex = i / 2;
                var part = i % 2;
                var productIndex = (orderIndex * 2 + part) % 36;
                var price = Math.Round(12.90m + ((orderIndex * 2 + part) % 18) * 29.50m, 2);

                lines.Add(new OrderLine
                {
                    OrderId = orderIndex + 1,
                    VariantId = productIndex + 1,
                    ProductId = productIndex + 1,
                    ProductName = ProductNames[productIndex],
                    VariantCode = "VAR-" + (productIndex + 1).ToString("D3"),
                    Quantity = 1,
                    UnitPrice = price,
                    Discount = orderIndex % 4 == 0 ? Math.Round(price * 0.1m, 2) : 0m,
                    Amount = orderIndex % 4 == 0 ? Math.Round(price * 0.9m, 2) : price
                });
            }

            context.OrderLines.AddRange(lines);
            context.SaveChanges();
        }

        private static void SeedOrderStatusHistory(ApplicationDbContext context)
        {
            var history = new List<OrderStatusHistory>();

            for (var i = 0; i < 36; i++)
            {
                history.Add(new OrderStatusHistory
                {
                    OrderId = (i % 36) + 1,
                    OldStatus = i % 4 == 0 ? "pending" : "paid",
                    NewStatus = i % 4 == 0 ? "paid" : (i % 4 == 1 ? "shipped" : "delivered"),
                    ModifiedAt = Start.AddDays(61 + i * 3),
                    ChangedBy = (i % 36) + 1
                });
            }

            context.OrderStatusHistories.AddRange(history);
            context.SaveChanges();
        }

        private static void SeedPayments(ApplicationDbContext context)
        {
            var methods = new[] { "Kaart", "Pangalink", "Järelmaks", "Arve" };
            var statuses = new[] { "Makstud", "Ootel", "Tõrjutud" };
            var payments = new List<Payment>();

            for (var i = 0; i < 36; i++)
            {
                var price1 = Math.Round(12.90m + ((i * 2) % 18) * 29.50m, 2);
                var price2 = Math.Round(12.90m + ((i * 2 + 1) % 18) * 29.50m, 2);
                var subtotal = price1 + price2;
                var shipping = subtotal > 100m ? 0m : 4.99m;

                payments.Add(new Payment
                {
                    OrderId = (i % 36) + 1,
                    Amount = subtotal - (i % 4 == 0 ? Math.Round(subtotal * 0.1m, 2) : 0m) + shipping,
                    Method = methods[i % methods.Length],
                    Status = i % 5 == 0 ? statuses[1] : statuses[0],
                    TransactionReference = "TXN" + (i + 1).ToString("D6"),
                    CreatedAt = Start.AddDays(60 + i * 3)
                });
            }

            context.Payments.AddRange(payments);
            context.SaveChanges();
        }

        private static void SeedRefunds(ApplicationDbContext context)
        {
            var reasons = new[] { "Kliendi soov", "Toode vigane", "Tarne hilines" };
            var statuses = new[] { "Kinnitatud", "Ootel", "Tagasi lükatud" };
            var refunds = new List<Refund>();

            for (var i = 0; i < 36; i++)
            {
                refunds.Add(new Refund
                {
                    PaymentId = (i % 36) + 1,
                    Amount = Math.Round(10m + (i % 8) * 25.50m, 2),
                    Reason = reasons[i % reasons.Length],
                    Status = statuses[i % statuses.Length],
                    CreatedAt = Start.AddDays(90 + i * 2)
                });
            }

            context.Refunds.AddRange(refunds);
            context.SaveChanges();
        }

        private static void SeedReturnRequests(ApplicationDbContext context)
        {
            var statuses = new[] { "Taotletud", "Kinnitatud", "Tagasi lükatud" };
            var reasons = new[] { "Ei sobi", "Vale suurus", "Vigane toode" };
            var requests = new List<ReturnRequest>();

            for (var i = 0; i < 36; i++)
            {
                requests.Add(new ReturnRequest
                {
                    OrderId = (i % 36) + 1,
                    Status = statuses[i % statuses.Length],
                    Reason = reasons[i % reasons.Length],
                    CreatedAt = Start.AddDays(100 + i * 2)
                });
            }

            context.ReturnRequests.AddRange(requests);
            context.SaveChanges();
        }

        private static void SeedReturnLines(ApplicationDbContext context)
        {
            var reasons = new[] { "Ei sobi", "Vale suurus", "Vigane toode" };
            var lines = new List<ReturnLine>();

            for (var i = 0; i < 36; i++)
            {
                lines.Add(new ReturnLine
                {
                    ReturnRequestId = (i % 36) + 1,
                    OrderLineId = (i % 72) + 1,
                    Quantity = (i % 2) + 1,
                    Reason = reasons[i % reasons.Length]
                });
            }

            context.ReturnLines.AddRange(lines);
            context.SaveChanges();
        }

        private static void SeedShipments(ApplicationDbContext context)
        {
            var statuses = new[] { "Pakitud", "Teel", "Kohal", "Tagastatud" };
            var shipments = new List<Shipment>();

            for (var i = 0; i < 36; i++)
            {
                var sentAt = Start.AddDays(61 + i * 3);
                shipments.Add(new Shipment
                {
                    OrderId = (i % 36) + 1,
                    WarehouseId = (i % 36) + 1,
                    CarrierId = (i % 36) + 1,
                    TrackingNumber = "EE" + (i + 1).ToString("D9"),
                    SentAt = sentAt,
                    EstimatedDelivery = sentAt.AddDays(3),
                    DeliveredAt = sentAt.AddDays(4),
                    Status = statuses[i % statuses.Length]
                });
            }

            context.Shipments.AddRange(shipments);
            context.SaveChanges();
        }

        private static void SeedShipmentTrackings(ApplicationDbContext context)
        {
            var statuses = new[] { "Vastu võetud", "Teel", "Sorteerimisel", "Üleandmisel" };
            var trackings = new List<ShipmentTracking>();

            for (var i = 0; i < 36; i++)
            {
                trackings.Add(new ShipmentTracking
                {
                    ShipmentId = (i % 36) + 1,
                    Status = statuses[i % statuses.Length],
                    Location = Cities[i % Cities.Length] + " sorteerimiskeskus",
                    Timestamp = Start.AddDays(61 + i * 3).AddHours(i % 12)
                });
            }

            context.ShipmentTrackings.AddRange(trackings);
            context.SaveChanges();
        }

        private static void SeedStockLevels(ApplicationDbContext context)
        {
            var levels = new List<StockLevel>();

            for (var i = 0; i < 36; i++)
            {
                levels.Add(new StockLevel
                {
                    WarehouseId = (i % 36) + 1,
                    VariantId = (i % 36) + 1,
                    Quantity = 50 + (i * 7) % 200,
                    Reserved = i % 10,
                    MinimumStock = 10
                });
            }

            context.StockLevels.AddRange(levels);
            context.SaveChanges();
        }

        private static void SeedStockMovements(ApplicationDbContext context)
        {
            var types = new[] { "Sisseost", "Müük", "Ülekanne", "Inventuur" };
            var reasons = new[] { "Tarnija saabumine", "Tellimuse täitmine", "Laovahetus", "Kvartaalne ülevaade" };
            var movements = new List<StockMovement>();

            for (var i = 0; i < 36; i++)
            {
                movements.Add(new StockMovement
                {
                    StockLevelId = (i % 36) + 1,
                    Type = types[i % types.Length],
                    Quantity = (i % 4) * 15 + 5,
                    Reason = reasons[i % reasons.Length],
                    CreatedAt = Start.AddDays(30 + i * 4)
                });
            }

            context.StockMovements.AddRange(movements);
            context.SaveChanges();
        }

        private static void SeedWarehouseTransfers(ApplicationDbContext context)
        {
            var statuses = new[] { "Ettevalmistusel", "Teel", "Saabunud" };
            var transfers = new List<WarehouseTransfer>();

            for (var i = 0; i < 36; i++)
            {
                transfers.Add(new WarehouseTransfer
                {
                    FromWarehouseId = (i % 36) + 1,
                    ToWarehouseId = ((i + 1) % 36) + 1,
                    Status = statuses[i % statuses.Length],
                    CreatedAt = Start.AddDays(40 + i * 3),
                    CompletedAt = Start.AddDays(43 + i * 3)
                });
            }

            context.WarehouseTransfers.AddRange(transfers);
            context.SaveChanges();
        }

        private static void SeedWarehouseTransferLines(ApplicationDbContext context)
        {
            var lines = new List<WarehouseTransferLine>();

            for (var i = 0; i < 36; i++)
            {
                lines.Add(new WarehouseTransferLine
                {
                    TransferId = (i % 36) + 1,
                    VariantId = (i % 36) + 1,
                    Quantity = (i % 5) * 10 + 5
                });
            }

            context.WarehouseTransferLines.AddRange(lines);
            context.SaveChanges();
        }

        private static void SeedPurchaseOrders(ApplicationDbContext context)
        {
            var statuses = new[] { "Esitatud", "Kinnitatud", "Täidetud", "Tühistatud" };
            var orders = new List<PurchaseOrder>();

            for (var i = 0; i < 36; i++)
            {
                orders.Add(new PurchaseOrder
                {
                    SupplierId = (i % 36) + 1,
                    WarehouseId = (i % 36) + 1,
                    OrderedAt = Start.AddDays(20 + i * 5),
                    ExpectedAt = Start.AddDays(27 + i * 5),
                    Status = statuses[i % statuses.Length]
                });
            }

            context.PurchaseOrders.AddRange(orders);
            context.SaveChanges();
        }

        private static void SeedPurchaseOrderLines(ApplicationDbContext context)
        {
            var lines = new List<PurchaseOrderLine>();

            for (var i = 0; i < 36; i++)
            {
                lines.Add(new PurchaseOrderLine
                {
                    PurchaseOrderId = (i % 36) + 1,
                    VariantId = (i % 36) + 1,
                    OrderedQuantity = 50 + (i % 5) * 25,
                    ReceivedQuantity = i % 5 == 0 ? 0 : 50 + (i % 5) * 25,
                    PurchasePrice = Math.Round(5m + (i % 20) * 3.5m, 2)
                });
            }

            context.PurchaseOrderLines.AddRange(lines);
            context.SaveChanges();
        }

        private static void SeedGoodsReceipts(ApplicationDbContext context)
        {
            var receipts = new List<GoodsReceipt>();

            for (var i = 0; i < 36; i++)
            {
                receipts.Add(new GoodsReceipt
                {
                    PurchaseOrderLineId = (i % 36) + 1,
                    Quantity = 50 + (i % 5) * 25,
                    CreatedAt = Start.AddDays(27 + i * 5),
                    EmployeeId = (i % 36) + 1
                });
            }

            context.GoodsReceipts.AddRange(receipts);
            context.SaveChanges();
        }

        private static void SeedExchangeRates(ApplicationDbContext context)
        {
            var rates = new List<ExchangeRate>();

            for (var i = 0; i < 36; i++)
            {
                rates.Add(new ExchangeRate
                {
                    FromCurrencyId = (i % 36) + 1,
                    ToCurrencyId = ((i + 1) % 36) + 1,
                    Rate = Math.Round(0.55m + (i % 30) * 0.03m, 4),
                    ValidFrom = Start.AddDays(i * 7),
                    CreatedAt = Start.AddDays(i * 7)
                });
            }

            context.ExchangeRates.AddRange(rates);
            context.SaveChanges();
        }

        private static void SeedLoyaltyAccounts(ApplicationDbContext context)
        {
            var accounts = new List<LoyaltyAccount>();

            for (var i = 0; i < 36; i++)
            {
                accounts.Add(new LoyaltyAccount
                {
                    CustomerId = (i % 36) + 1,
                    Balance = (i % 12) * 175,
                    CreatedAt = Start.AddDays(i * 5)
                });
            }

            context.LoyaltyAccounts.AddRange(accounts);
            context.SaveChanges();
        }

        private static void SeedLoyaltyPoints(ApplicationDbContext context)
        {
            var reasons = new[] { "Ost eest", "Boonus", "Sünnipäev", "Arvustuse eest" };
            var points = new List<LoyaltyPoints>();

            for (var i = 0; i < 36; i++)
            {
                points.Add(new LoyaltyPoints
                {
                    AccountId = (i % 36) + 1,
                    Points = 50 + (i % 7) * 25,
                    Reason = reasons[i % reasons.Length],
                    CreatedAt = Start.AddDays(65 + i * 4)
                });
            }

            context.LoyaltyPoints.AddRange(points);
            context.SaveChanges();
        }

        private static void SeedGiftCards(ApplicationDbContext context)
        {
            var amounts = new[] { 25m, 50m, 75m, 100m };
            var cards = new List<GiftCard>();

            for (var i = 0; i < 36; i++)
            {
                var initial = amounts[i % amounts.Length];
                cards.Add(new GiftCard
                {
                    Code = "GC-" + (i + 1).ToString("D4"),
                    InitialAmount = initial,
                    Balance = initial - (i % 3 == 0 ? 10m : 0m),
                    ExpiryDate = Start.AddYears(2).AddDays(i * 10)
                });
            }

            context.GiftCards.AddRange(cards);
            context.SaveChanges();
        }

        private static void SeedReviews(ApplicationDbContext context)
        {
            var titles = new[] { "Väga hea", "Ootuspärane", "Soovitan", "Hea hinna ja kvaliteedi suhe", "Tarne kiire" };
            var contents = new[]
            {
                "Toode vastas kirjeldusele, teenindus sujus.",
                "Kvaliteet hea, kasutan igapäevaselt.",
                "Pakis oli kõik korras, soovitan müüjat.",
                "Väike viivitus tarne, muidu korras.",
                "Vastas ootustele, ostan uuesti."
            };
            var statuses = new[] { "Ootel", "Kinnitatud", "Tagasi lükatud" };
            var reviews = new List<Review>();

            for (var i = 0; i < 36; i++)
            {
                reviews.Add(new Review
                {
                    CustomerId = (i % 36) + 1,
                    ProductId = (i % 36) + 1,
                    OrderLineId = (i % 72) + 1,
                    Rating = (i % 5) + 1,
                    Title = titles[i % titles.Length],
                    Content = contents[i % contents.Length],
                    CreatedAt = Start.AddDays(110 + i * 2),
                    Status = statuses[i % statuses.Length]
                });
            }

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }

        private static void SeedReviewResponses(ApplicationDbContext context)
        {
            var responses = new List<ReviewResponse>();

            for (var i = 0; i < 36; i++)
            {
                responses.Add(new ReviewResponse
                {
                    ReviewId = (i % 36) + 1,
                    EmployeeId = (i % 36) + 1,
                    Content = "Täname tagasiside eest! Võtame arvesse järgmistel tarnetel.",
                    CreatedAt = Start.AddDays(111 + i * 2)
                });
            }

            context.ReviewResponses.AddRange(responses);
            context.SaveChanges();
        }

        private static void SeedReviewImages(ApplicationDbContext context)
        {
            var images = new List<ReviewImage>();

            for (var i = 0; i < 36; i++)
            {
                images.Add(new ReviewImage
                {
                    ReviewId = (i % 36) + 1,
                    Url = "https://cdn.epood.ee/arvustused/" + (i + 1) + ".jpg"
                });
            }

            context.ReviewImages.AddRange(images);
            context.SaveChanges();
        }

        private static void SeedSupportTickets(ApplicationDbContext context)
        {
            var subjects = new[] { "Tarne hilinemine", "Toote defekt", "Tagastuse küsimus", "Arve küsimus", "Konto probleem" };
            var priorities = new[] { "Madal", "Kesmine", "Kõrge", "Kriitiline" };
            var statuses = new[] { "Avatud", "Töös", "Suletud" };
            var tickets = new List<SupportTicket>();

            for (var i = 0; i < 36; i++)
            {
                var createdAt = Start.AddDays(95 + i * 2);
                tickets.Add(new SupportTicket
                {
                    CustomerId = (i % 36) + 1,
                    ResponsibleEmployeeId = (i % 36) + 1,
                    Subject = subjects[i % subjects.Length] + " #" + (i + 1),
                    Priority = priorities[i % priorities.Length],
                    Status = statuses[i % statuses.Length],
                    CreatedAt = createdAt,
                    ClosedAt = createdAt.AddDays(3)
                });
            }

            context.SupportTickets.AddRange(tickets);
            context.SaveChanges();
        }

        private static void SeedTicketMessages(ApplicationDbContext context)
        {
            var senders = new[] { "Klient", "Töötaja" };
            var contents = new[]
            {
                "Tere, tellimus on viibinud juba mitu päeva.",
                "Vabandame, võtame tarnega ühendust.",
                "Kas saan toote tagastada ilma põhjenduseta?",
                "Jah,14 päeva jooksul on tagastus võimalik.",
                "Arve palun uuesti meilile."
            };
            var messages = new List<TicketMessage>();

            for (var i = 0; i < 36; i++)
            {
                messages.Add(new TicketMessage
                {
                    TicketId = (i % 36) + 1,
                    SenderType = senders[i % senders.Length],
                    SenderId = (i % 36) + 1,
                    Content = contents[i % contents.Length],
                    CreatedAt = Start.AddDays(95 + i * 2).AddHours(i % 10)
                });
            }

            context.TicketMessages.AddRange(messages);
            context.SaveChanges();
        }

        private static void SeedNotifications(ApplicationDbContext context)
        {
            var types = new[] { "Tellimus", "Kampaania", "Hinnamuutus", "Uudiskiri", "Lao täis" };
            var titles = new[] { "Tellimus vastu võetud", "Uus pakkumine", "Hind muutus", "Nädala uudiskiri", "Toode laos olemas" };
            var messages = new[]
            {
                "Sinu tellimus on vastu võetud ja töötluses.",
                "Vaata uut kampaaniat meie veebis.",
                "Toote hind on muutunud.",
                "Uus uudiskiri ootab sinu postkastis.",
                "Soovitud toode on jälle laos."
            };
            var notifications = new List<Notification>();

            for (var i = 0; i < 36; i++)
            {
                var createdAt = Start.AddDays(120 + i);
                notifications.Add(new Notification
                {
                    CustomerId = (i % 36) + 1,
                    Type = types[i % types.Length],
                    Title = titles[i % titles.Length],
                    Message = messages[i % messages.Length],
                    CreatedAt = createdAt,
                    ReadAt = createdAt.AddHours(2)
                });
            }

            context.Notifications.AddRange(notifications);
            context.SaveChanges();
        }

        private static void SeedAuditLogs(ApplicationDbContext context)
        {
            var objectTypes = new[] { "Toode", "Tellimus", "Klient", "Ladu", "Kampaania" };
            var actions = new[] { "Lisamine", "Muutmine", "Kustutamine", "Sisselogimine" };
            var logs = new List<AuditLog>();

            for (var i = 0; i < 36; i++)
            {
                logs.Add(new AuditLog
                {
                    EmployeeId = (i % 36) + 1,
                    ObjectType = objectTypes[i % objectTypes.Length],
                    ObjectId = (i % 36) + 1,
                    Action = actions[i % actions.Length],
                    OldValue = "{\"staatus\":\"vana\"}",
                    NewValue = "{\"staatus\":\"uus\"}",
                    IpAddress = "192.168.1." + ((i % 250) + 1),
                    CreatedAt = Start.AddDays(130 + i)
                });
            }

            context.AuditLogs.AddRange(logs);
            context.SaveChanges();
        }
    }
}
