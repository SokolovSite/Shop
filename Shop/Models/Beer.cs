namespace Shop.Models
{

    //модель пивка
    public class Beer
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc {  get; set; }
        public string Img {  get; set; }
        public uint Price { get; set; }
        public bool IsFavourite {get; set; }
        public bool Availablbe { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


    }
}
