using System;

namespace cat
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat firstCat = new Cat();
            firstCat.Name = "Tony";
            firstCat.SayMiau();

            Cat secondCat = new Cat("Pepy","Red");
            secondCat.SayMiau();

            Console.WriteLine("Cat {0} is {1}.",secondCat.Name, secondCat.Colour);

            Cat myCat = new Cat();
            myCat.Name = "Alfred";
            Console.WriteLine("My cat name is {0}",myCat.Name);
            myCat.SayMiau();
        }
    }
    public class Cat
    {
        private string name;
        private string color;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Colour
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public Cat()
        {
            this.name = "Pesho";
            this.color = "Grey";
        }
        public Cat(string name, string color)

        {
            this.name = name;
            this.color = color;
        }
        public void SayMiau()
        {
            Console.WriteLine("Cat {0} said: Miauuuuuu!", name);
        }
    }
}
