using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{
    private Dictionary<string, Card> cards;
    private Dictionary<string, Card> death;
    private Dictionary<int, List<Card>> levels;

    public Board()
    {
        this.cards = new Dictionary<string, Card>();
        this.death = new Dictionary<string, Card>();
        this.levels = new Dictionary<int, List<Card>>();
    }

    public bool Contains(string name)
    {
        return this.cards.ContainsKey(name);
    }

    public int Count() => this.cards.Count();

    public void Draw(Card card)
    {
        if (!this.cards.ContainsKey(card.Name))
        {
            this.cards.Add(card.Name, card);
            if (!this.levels.ContainsKey(card.Level))
            {
                this.levels.Add(card.Level, new List<Card>());
            }
            this.levels[card.Level].Add(card);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        return this.cards
            .Values
            .Where(c => c.Score >= start && c.Score <= end)
            .OrderByDescending(c => c.Level);
    }

    public void Heal(int health)
    {
        var card = this.cards.Values.OrderBy(c => c.Health).First();
        card.Health += health;
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        var result = this.cards
            .Values
            .Where(c => c.Name.StartsWith(prefix))
            .OrderBy(s => new string(s.Name.ToCharArray().Reverse().ToArray()))
            .ThenBy(s => s.Level);

        if (result.Count() == 0)
        {
            return Enumerable.Empty<Card>();
        }

        return result;
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        if (!this.cards.ContainsKey(attackedCardName))
        {
            throw new ArgumentException();
        }

        if (!this.cards.ContainsKey(attackerCardName))
        {
            throw new ArgumentException();
        }

        var attaker = this.cards[attackerCardName];
        var attaked = this.cards[attackedCardName];

        if (attaked.Level != attaker.Level)
        {
            throw new ArgumentException();
        }

        if (attaked.Health > 0)
        {
            attaked.Health -= attaker.Damage;
            if (attaked.Health <= 0)
            {
                attaker.Score += attaked.Level;
                this.death.Add(attaked.Name, attaked);
            }
        }
    }

    public void Remove(string name)
    {
        if (!this.cards.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        this.cards.Remove(name);
        this.death.Remove(name);
    }

    public void RemoveDeath()
    {
        foreach (var item in death)
        {
            this.cards.Remove(item.Key);
        }
        this.death.Clear();
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return this.levels[level].OrderByDescending(c => c.Score);
    }
}