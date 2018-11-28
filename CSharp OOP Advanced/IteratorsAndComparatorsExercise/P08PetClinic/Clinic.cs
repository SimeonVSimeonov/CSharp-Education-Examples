namespace P08PetClinic
{
    using System;
    using System.Linq;

    public class Clinic
    {
        private Pet[] petsRoom;
        private int addIndex;
        private int dropIndex;

        public Clinic(string name, int petsRoom)
        {
            if (petsRoom % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.petsRoom = new Pet[petsRoom];
            this.Name = name;
            this.addIndex = petsRoom / 2;
            this.dropIndex = petsRoom / 2;
        }

        public string Name { get; private set; }

        public bool AddPet(Pet pet)
        {
            if (pet == null)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i <= addIndex; i++)
            {
                if (petsRoom[addIndex - i] == null)
                {
                    petsRoom[addIndex - i] = pet;
                    return true;
                }

                if (petsRoom[addIndex + i] == null)
                {
                    petsRoom[addIndex + i] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int i = dropIndex; i < petsRoom.Length; i++)
            {
                if (petsRoom[i] != null)
                {
                    petsRoom[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < dropIndex; i++)
            {
                if (petsRoom[i] != null)
                {
                    petsRoom[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.petsRoom.Any(x => x == null);
        }

        public void PrintRoom(int number)
        {

            if (petsRoom[number - 1] != null)
            {
                Console.WriteLine(petsRoom[number - 1]);
            }
            else
            {
                Console.WriteLine("Room empty");
            }

        }

        public void Print()
        {
            foreach (var pet in petsRoom)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(pet);
                }
            }
        }
    }
}
