using System;

namespace CSharpKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Method Parameters
            int number = 1;
            MethodParameters.RefMethod(ref number);
            Console.WriteLine(number);
            
            MethodParameters.ModifyProductByReference();

            MethodParameters methodParameters = new MethodParameters();
            methodParameters.ListBooks();
            ref var book = ref methodParameters.GetBookByTitle("三体");
            if (book!=null)
            {
                book = new Book { Title = "The Three-Body Problem", Author = "Liu Cixin" };
            }
            methodParameters.ListBooks();
            #endregion
        }
    }
    #region Method Parameters
    /// <summary>
    /// visit:https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/method-parameters 
    /// </summary>
    class MethodParameters
    {
        #region ref
        public static void RefMethod(ref int refArgument)
        {
            refArgument += 1;
        }

        public static void ModifyProductByReference()
        {
            // Declare an instance of product and display its initial values.
            Product item = new Product("laptops", 10001);
            Console.WriteLine($"Original values in Main. Name:{item.ItemName},ID:{item.ItemID}");

            // Pass the prodcut instance to ChangeByReference.
            ChangeByRefrence(ref item);
            Console.WriteLine($"Back in Main. Name:{item.ItemName},ID:{item.ItemID}");
        }
        private static void ChangeByRefrence(ref Product itemRef)
        {
            itemRef = new Product("laptops", 10001);
            itemRef.ItemID = 10002;
        }

        private Book[] books = { new Book { Title = "三体", Author = "刘慈欣" },new Book { Title="三体II:黑暗森林",Author="刘慈欣"},new Book { Title="三体III:死神永生",Author="刘慈欣"} };
        private Book nobook = null;

        public ref Book GetBookByTitle(string title)
        {
            for (int ctr = 0; ctr < books.Length; ctr++)
            {
                if (title==books[ctr].Title)
                {
                    return ref books[ctr];
                }
            }
            return ref nobook;
        }
        public void ListBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title},by {book.Author}");
            }
            Console.WriteLine();
        }
        #endregion
    }
    #endregion

    class Product
    {
        public Product(string name, int newID)
        {
            ItemName = name;
            ItemID = newID;
        }
        public string ItemName { get; set; }
        public int ItemID { get; set; }
    }

    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
    }

}
