namespace Shop.Models
{

    //модель категории пивка
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Beer> Beer {  get; set; }

    }
}
