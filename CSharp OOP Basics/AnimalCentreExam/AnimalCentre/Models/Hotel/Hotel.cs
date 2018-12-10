using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = 10;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);
        }

        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count > capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name,animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            else
            {
                IAnimal animal = animals[animalName];
                animal.IsAdopt = true;
                animal.Owner = owner;
                this.animals.Remove(animalName);
                capacity++;
            }
        }
    }
}
