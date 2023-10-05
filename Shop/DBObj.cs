using Shop.Models;


namespace Shop
{
    public class DBObj
    {


        //создание статической функции для обращения к ней по имени(.DBObj) из других классов
        public static void Initial(AppDBContext context) 
        {

            //добавление всех категорий БД, но если они не получены - добавить
            if(!context.Category.Any())
                context.Category.AddRange(Categories.Select(c => c.Value));

            //добавление всего пивка, также как и с категориями, но немного по-другому))) 
            if (!context.Beer.Any())
            {
                context.AddRange(

                    new Beer
                    {
                        Name = "Жигулёвское",
                        ShortDesc = "Золотая классика",
                        LongDesc = "",
                        Img = "/img/1.png",
                        Price = 50,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Алкогольное"]
                    },
                    new Beer
                    {
                        Name = "Green Beer",
                        ShortDesc = "Молодёжное пивко раньше было",
                        LongDesc = "",
                        Img = "/img/2.jpg",
                        Price = 70,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Алкогольное"]
                    },
                    new Beer
                    {
                        Name = "Gold mine beer",
                        ShortDesc = "Ну, про это сам всё понимаешь",
                        LongDesc = "",
                        Img = "/img/3.jpg",
                        Price = 80,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Алкогольное"]
                    },
                    new Beer
                    {
                        Name = "Кулер",
                        ShortDesc = "Ну, Кулер - есть Кулер",
                        LongDesc = "",
                        Img = "/img/6.jpeg",
                        Price = 60,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Алкогольное"]
                    },
                    new Beer
                    {
                    Name = "Bud 5.0%",
                        ShortDesc = "Классика американского лагера",
                        LongDesc = "",
                        Img = "/img/8.jpg",
                        Price = 70,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Алкогольное"]
                    },
                    new Beer
                    {
                        Name = "Bud 0.0",
                        ShortDesc = "Если хочешь освежиться",
                        LongDesc = "",
                        Img = "/img/4.png",
                        Price = 45,
                        IsFavourite = true,
                        Availablbe = true,
                        Category = Categories["Безалкогольное"]
                    });
            }

            //сохранение данных
            context.SaveChanges();

        }


        //создание списка категорий 
        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            //получение категории
            get
            {   
                //если список категорий пустой - создаем новый
                if(Category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Безалкогольное", CategoryDescription = "Если любишь пивко, но не хочешь нахрюкаться"},
                        new Category {CategoryName = "Алкогольное", CategoryDescription = "Всё с тобой ясно..."}
                    };

                    //выделяем память
                    Category = new Dictionary<string, Category>();

                    //перебор списка и добавление в переменную category
                    foreach(Category el in list)
                    {
                        Category.Add(el.CategoryName, el);
                    }
                }

                //возврат категории
                return Category;
            }
        }
    }
}
