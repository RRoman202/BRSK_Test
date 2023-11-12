using BRSK_Test.Data.Models;

namespace BRSK_Test.Data
{
    public class TestData
    {
        public static void Seed(DataContext context)
        {
            var brands = new List<Brand> {
                new Brand{Active = true, Name="BMW"},
                new Brand{Active = true, Name="Toyota"},
                new Brand{Active = true, Name="Porshe"},
                new Brand{Active = true, Name="Lamborghini"},
                new Brand{Active = true, Name="Lada"},
                new Brand{Active = true, Name="Mercedes Benz"},
                new Brand{Active = true, Name="Chevrolet"},
                new Brand{Active = true, Name="Ford"},
            };

            var models = new List<Model>
            {
                new Model{ Active=true, BrandId=1, Name="E34" },
                new Model{ Active=true, BrandId=1, Name="E60" },
                new Model{ Active=true, BrandId=1, Name="M5" },
                new Model{ Active=true, BrandId=2, Name="Corolla" },
                new Model{ Active=true, BrandId=2, Name="Camry" },
                new Model{ Active=true, BrandId=2, Name="Rav4" },
                new Model{ Active=true, BrandId=3, Name="911" },
                new Model{ Active=true, BrandId=3, Name="Cayenne" },
                new Model{ Active=true, BrandId=3, Name="918" },
                new Model{ Active=true, BrandId=4, Name="Urus" },
                new Model{ Active=true, BrandId=4, Name="Aventador" },
                new Model{ Active=true, BrandId=4, Name="Huracan" },
                new Model{ Active=true, BrandId=5, Name="Granta" },
                new Model{ Active=true, BrandId=5, Name="Vesta" },
                new Model{ Active=true, BrandId=5, Name="Largus" },
                new Model{ Active=true, BrandId=6, Name="Cls 63" },
                new Model{ Active=true, BrandId=6, Name="W140" },
                new Model{ Active=true, BrandId=6, Name="Maybach" },
                new Model{ Active=true, BrandId=7, Name="Camaro" },
                new Model{ Active=true, BrandId=7, Name="Corvette" },
                new Model{ Active=true, BrandId=7, Name="Aveo" },
                new Model{ Active=true, BrandId=8, Name="Mustang" },
                new Model{ Active=true, BrandId=8, Name="Focus" },
                new Model{ Active=true, BrandId=8, Name="Fusion" },
            };

            foreach (var brand in brands)
                context.Brands.Add(brand);
            context.SaveChanges();
            foreach (var model in models)
                context.Models.Add(model);
            context.SaveChanges();
        }
    }
}
