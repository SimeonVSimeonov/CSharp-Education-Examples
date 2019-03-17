using System;
using System.Collections.Generic;
using System.Linq;

public class Microsystems : IMicrosystem
{
    Dictionary<int, Computer> byNumber = new Dictionary<int, Computer>();
    Dictionary<string, List<Computer>> byBrand = new Dictionary<string, List<Computer>>();

    public bool Contains(int number)
    {

        return this.byNumber.ContainsKey(number);

    }

    public int Count()
    {
        return this.byNumber.Count();
    }

    public void CreateComputer(Computer computer)
    {
        if (this.byNumber.ContainsKey(computer.Number))
        {
            throw new ArgumentException();
        }
        this.byNumber.Add(computer.Number, computer);

        string brand = computer.Brand.ToString();

        if (!this.byBrand.ContainsKey(brand))
        {
            this.byBrand.Add(brand, new List<Computer>());
        }
        this.byBrand[brand].Add(computer);
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {

        return this.byNumber.Values.Where(c => c.Brand == brand)
            .OrderByDescending(c => c.Price);
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        return this.byNumber.Values.Where(c => c.Color == color)
            .OrderByDescending(p => p.Price);
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        return this.byNumber.Values.Where(c => c.ScreenSize == screenSize)
            .OrderByDescending(n => n.Number);
    }

    public Computer GetComputer(int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        return this.byNumber[number];
    }

    public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
    {
        return this.byNumber.Values.Where(c => c.Price >= minPrice && c.Price <= maxPrice)
            .OrderByDescending(p => p.Price);
    }

    public void Remove(int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        this.byNumber.Remove(number);
    }

    public void RemoveWithBrand(Brand brand)
    {
        if (!this.byBrand.ContainsKey(brand.ToString()))
        {
            throw new ArgumentException();
        }
        this.byBrand.Remove(brand.ToString());

    }

    public void UpgradeRam(int ram, int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        if (this.byNumber[number].RAM < ram)
        {
            this.byNumber[number].RAM = ram;
        }

    }
}
