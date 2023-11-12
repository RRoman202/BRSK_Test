namespace BRSK_Test.Data.Models.ModelGroup
{
    public class ModelGroup
    {
        public Brand Brand { get; set; }
        public ICollection<Model>? Models { get; set; }
    }
}
