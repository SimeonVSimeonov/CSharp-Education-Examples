using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Factories
{
    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
            }

            return null;
        }

    }
}
