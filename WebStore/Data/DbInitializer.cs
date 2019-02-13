using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.DomainNew.Entities;

namespace WebStore.Data
{
    public static class DbInitializer
    {
        private static Section NewSection(int id, string Name, int order, int? parentId)
        {
            return new Section { Id = id, Name = Name, Order = order, ParentId = parentId };
        }

        private static Brand NewBrand(int id, string Name, int order)
        {
            return new Brand { Id = id, Name = Name, Order = order };
        }

        private static Product NewProduct(int id, string Name, int price, string immage, int order, int sectionId, int brandId)
        {
            return new Product { Id = id, Name = Name, Price = price, ImageUrl = immage, Order = order, SectionId = sectionId, BrandId = brandId };
        }

        public static void Initialize(WebStoreContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            var sections = new List<Section>()
            {
                NewSection(1, "Sportswear",0,null),
                NewSection(2, "Nike", 0, 0),
                NewSection(3, "Under Armour", 1, 1),
                NewSection(4, "Adidas", 2, 1),
                NewSection(5, "Puma", 3, 1),
                NewSection(6, "ASICS", 4, 1),

                NewSection(7, "Mens", 1, null),
                NewSection(8, "Fendi", 0, 7),
                NewSection(9, "Guess", 1, 7),
                NewSection(10, "Valentino", 2, 7),
                NewSection(11, "Dior", 3, 7),
                NewSection(12, "Versace", 4, 7),
                NewSection(13, "Armani", 5, 7),
                NewSection(14, "Prada", 6, 7),
                NewSection(15, "Dolce and Gabbana", 7, 7),
                NewSection(16, "Chanel", 8, 7),
                NewSection(17, "Gucci", 1, 7),

                NewSection(18, "Womens", 2, null),
                NewSection(19, "Fendi", 0, 18),
                NewSection(20, "Guess", 1, 7),
                NewSection(21, "Valentino", 2, 18),
                NewSection(22, "Dior", 3, 7),
                NewSection(23, "Versace", 4, 18),

                NewSection(24, "Kids", 3, null),
                NewSection(25, "Fasion", 4, null),

                NewSection(26, "Interiors", 6, null),
                NewSection(27, "Clothing", 7, null),
                NewSection(28, "Bags", 8, null),
                NewSection(29, "Shoes", 9, null),
            };


            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Sections.Add(section);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                trans.Commit();
            }

            var brands = new List<Brand>()
            {
                NewBrand(1,"Acne", 0 ),
                NewBrand(2,"Grüne Erde", 1 ),
                NewBrand(3,"Albiro", 2 ),
                NewBrand(4,"Ronhill", 3 ),
                NewBrand(5,"Oddmolly", 4 ),
                NewBrand(6,"Boudestijn", 5 ),
                NewBrand(7,"Rösch creative culture", 6 ),
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var brand in brands)
                {
                    context.Brands.Add(brand);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                trans.Commit();
            }
            var products = new List<Product>()
            {
               NewProduct(1,"Easy Polo Black Edition", 1025, "product1.jpg", 0, 2, 1),
               NewProduct(2,"Easy Polo Black Edition", 1025, "product2.jpg", 1, 2, 1),
               NewProduct(3,"Easy Polo Black Edition", 1025, "product3.jpg", 2, 2, 1),
               NewProduct(4,"Easy Polo Black Edition", 1025, "product4.jpg", 3, 2, 1),
               NewProduct(5,"Easy Polo Black Edition", 1025, "product5.jpg", 4, 2, 2),
               NewProduct(6,"Easy Polo Black Edition", 1025, "product6.jpg", 5, 2, 2),
               NewProduct(7,"Easy Polo Black Edition", 1025, "product7.jpg", 6, 2, 2),
               NewProduct(8,"Easy Polo Black Edition", 1025, "product8.jpg", 7, 25, 2),
               NewProduct(9,"Easy Polo Black Edition", 1025, "product9.jpg", 8, 25, 2),
               NewProduct(10,"Easy Polo Black Edition", 1025, "product10.jpg", 9, 25, 3),
               NewProduct(11,"Easy Polo Black Edition", 1025, "product11.jpg", 10, 25, 3),
               NewProduct(12,"Easy Polo Black Edition", 1025, "product12.jpg", 11, 25, 3),
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");
                trans.Commit();

            }
        }
    }
}
