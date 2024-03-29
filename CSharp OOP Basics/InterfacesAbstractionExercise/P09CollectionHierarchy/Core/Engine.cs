﻿using P09CollectionHierarchy.Contracts;
using P09CollectionHierarchy.Models;
using System;

namespace P09CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemove = new AddRemoveCollection();
            MyList list = new MyList();

            var input = Console.ReadLine().Split();

            AddInCollections(addCollection, input);
            AddInCollections(addRemove, input);
            AddInCollections(list, input);

            var removeCount = int.Parse(Console.ReadLine());

            RemoveFromCollections(addRemove, removeCount);
            RemoveFromCollections(list, removeCount);
        }

        static void RemoveFromCollections(IRemoveable collection, int removeCount)
        {
            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }

        private void AddInCollections(IAddable collection, string[] input)
        {
            foreach (var item in input)
            {
                Console.Write(collection.Add(item) + " ");
            }

            Console.WriteLine();
        }
    }
}
