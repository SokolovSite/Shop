namespace Shop.Models
{

    //модель корзины
    public class ShopCartItem
    {
        //Получение id объекта 
        public int Id { get; set; }
        
        //конкретно сам объект из Beer
        public Beer Beer{ get; set; }

        public uint Price { get; set; }  

        public string ShopCartId { get; set; }
    }
}
