﻿using System;
using System.Linq;


public class Database
{
    private Person[] database;
    private int index;

    public Database(params Person[] data)
    {
        if (data.Length > 16)
        {
            throw new InvalidOperationException();
        }

        this.database = new Person[16];
        this.index = 0;

        foreach (var person in data)
        {
            this.Add(person);
        }
    }

    public void Add(Person person)
    {
        if (index == 16)
        {
            throw new InvalidOperationException();
        }

        if (this.database.Any(p => p != null && p.Id == person.Id))
        {
            throw new InvalidOperationException();
        }

        if (this.database.Any(p => p != null && p.Username == person.Username))
        {
            throw new InvalidOperationException();
        }

        this.database[index++] = person;
    }

    public Person Remove()
    {
        if (index == 0)
        {
            throw new InvalidOperationException();
        }

        return this.database[--index];
    }

    public Person FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        if (!this.database.Any(p => p != null && p.Username == username))
        {
            throw new InvalidOperationException();
        }

        return this.database.Single(p => p != null && p.Username == username);
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (!this.database.Any(p => p != null && p.Id == id))
        {
            throw new InvalidOperationException();
        }

        return this.database.Single(p => p != null && p.Id == id);
    }

    public Person[] Fetch()
    {
        return this.database.Take(index).ToArray();
    }
}

