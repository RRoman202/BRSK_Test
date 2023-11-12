namespace BRSK_Test.Data.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public bool Active { get; set; }
    }
}
