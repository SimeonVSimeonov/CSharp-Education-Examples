using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    Dictionary<int, Battlecard> byId = new Dictionary<int, Battlecard>();
    Dictionary<CardType, List<Battlecard>> byType = new Dictionary<CardType, List<Battlecard>>();
    Dictionary<string, List<Battlecard>> byName = new Dictionary<string, List<Battlecard>>();

    public int Count => this.byId.Count();

    public void Add(Battlecard card)
    {
        if (!this.byId.ContainsKey(card.Id))
        {
            byId.Add(card.Id, card);
        }
        else
        {
            throw new ArithmeticException();
        }

        if (!this.byType.ContainsKey(card.Type))
        {
            byType.Add(card.Type, new List<Battlecard>());
        }
        byType[card.Type].Add(card);

        if (!this.byName.ContainsKey(card.Name))
        {
            byName.Add(card.Name, new List<Battlecard>());
        }
        byName[card.Name].Add(card);
    }

    public void ChangeCardType(int id, CardType type)
    {
        if (!this.byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.byId[id].Type = type;
    }

    public bool Contains(Battlecard card)
    {
        return this.byId.ContainsKey(card.Id);
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        if (n < 0 || n >= this.Count)
        {
            throw new InvalidOperationException();
        }

        var result = new List<Battlecard>();
        var maxSwag = 0.0;
        foreach (var item in byName)
        {
            maxSwag = item.Value.Select(s => s.Swag).Max();

            result = byName[item.Key].Where(c => c.Swag == maxSwag).ToList();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        var maxSwag = 0.0;
        var result = new List<Battlecard>();

        foreach (var item in byName)
        {
            maxSwag = item.Value.Select(s => s.Swag).Max();

            result = byName[item.Key].Where(c => c.Swag == maxSwag).ToList();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {

        if (!byType.ContainsKey(type))
        {
            throw new ArgumentException();
        }
        return this.byType[type].OrderByDescending(c => c.Damage).ThenBy(c => c.Id);
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {

        try
        {
            return this.byType[type].Where(c => c.Type == type && c.Damage <= damage)
            .OrderByDescending(c => c.Damage)
            .ThenBy(c => c.Id);
        }
        catch (Exception)
        {

            throw new InvalidOperationException();
        }
    }

    public Battlecard GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        return this.byId[id];
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {

        try
        {
            return this.byName[name].OrderByDescending(c => c.Swag).ThenBy(c => c.Id);
        }
        catch (Exception)
        {

            throw new InvalidOperationException();
        }
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        foreach (var card in this.byId)
        {
            yield return card.Value;
        }
    }

    public void RemoveById(int id)
    {
        this.byId.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
