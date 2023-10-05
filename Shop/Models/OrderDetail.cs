namespace Shop.Models
{
    public class OrderDetail
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BeerId { get; set; }
        public uint Price { get; set; }
        //переменные для работы с заказом и самим пивком для бд
        public virtual Beer Beer { get; set; }
        public virtual Order Order { get; set; }
    }
}
