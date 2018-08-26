using System;

namespace AnimalsShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalShelter<Dog> shelter = new AnimalShelter<Dog>();

            shelter.Shelter(new Dog());

            shelter.Shelter(new Dog());

            shelter.Shelter(new Dog());

           


        }
    }

    internal class AnimalShelter<AnimasType>
    {
        private const int DefaultPlacesCount = 20;



        private AnimasType[] animalList;

        private int usedPlaces;



        public AnimalShelter()

              : this(DefaultPlacesCount)

        {

        }



        public AnimalShelter(int placesCount)

        {

            this.animalList = new AnimasType[placesCount];

            this.usedPlaces = 0;

        }



        public void Shelter(AnimasType newAnimal)

        {

            if (this.usedPlaces >= this.animalList.Length)

            {

                throw new InvalidOperationException("Shelter is full.");

            }

            this.animalList[this.usedPlaces] = newAnimal;

            this.usedPlaces++;

        }



        public AnimasType Release(int index)

        {

            if (index < 0 || index >= this.usedPlaces)

            {

                throw new ArgumentOutOfRangeException(

                      "Invalid cell index: " + index);

            }

            AnimasType releasedAnimal = this.animalList[index];

            for (int i = index; i < this.usedPlaces - 1; i++)

            {

                this.animalList[i] = this.animalList[i + 1];

            }

            this.animalList[this.usedPlaces - 1] = default(AnimasType);

            this.usedPlaces--;



            return releasedAnimal;

        }
    }
}
