using System;

namespace calss_Dogs
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDogName = null;
            Console.WriteLine("Write first dog name: ");
            firstDogName = Console.ReadLine();
            Dog firstDog = new Dog(firstDogName);

            Dog secondDog = new Dog();
            Console.WriteLine("Write second dog name: ");
            string secondDogName = Console.ReadLine();
            secondDog.Name = secondDogName;

            Dog thirdDog = new Dog();

            Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };
            foreach (var dog in dogs)
            {
                dog.Bark();
            }
        }
    }
    class Dog
    {
        private string name;

        public Dog()
        {
            this.name = "Balkan";
        }
        public Dog(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void Bark()
        {
            Console.WriteLine("{0} said: Wow-wow!", name);
        }
    }
}
