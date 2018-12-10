using NUnit.Framework;

public class ExtendedDatabaseTests
{
    private Person pesho;
    private Person stavri;

    [SetUp]
    public void Setup()
    {
        pesho = new Person(112233, "Pesho");
        stavri = new Person(101202303404505, "Stavri");
    }

    [Test]
    public void ConstructorShoudInitializeCollection()
    {
        var expected = new Person[] { pesho, stavri };

        var db = new Database(expected);

        var actual = db.Fetch();

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void AddShouldAddValidPerson()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);
        var newPerson = new Person(54321, "Gosho");
        db.Add(newPerson);

        var actual = db.Fetch();
        var expected = new Person[] { pesho, stavri, newPerson };

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void AddSameUsernameShouldThrowExeption()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);
        var newPerson = new Person(112233, "Pesho");

        Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
    }

    [Test]
    public void AddSameIdShouldThrowExeption()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);
        var newPerson = new Person(112233, "Stamat");

        Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveShouldRemovePerson()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);
        db.Remove();

        var actual = db.Fetch();
        var expected = new Person[] { pesho };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RemoveEmptyCollectionShouldThrowExeption()
    {
        var persons = new Person[] { };
        var db = new Database();

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUsernameExistingPersonShouldReturnPerson()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        var expected = pesho;
        var actual = db.FindByUsername("Pesho");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void FindByUsernameNonExistingPersonShouldThrowException()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        Assert.That(() => db.FindByUsername("Gosho"), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUsernameNullArgumentShouldThrow()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
    }

    [Test]
    public void FindByUsernameIsCaseSensitive()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByIdExistingPersonShouldReturnPerson()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        var expected = pesho;
        var actual = db.FindById(112233);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FindByIdNonExistingPersonShouldThrow()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        Assert.That(() => db.FindById(558877), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByUsernameNegativeArgumentShouldThrow()
    {
        var persons = new Person[] { pesho, stavri };
        var db = new Database(persons);

        Assert.That(() => db.FindById(-5), Throws.Exception);
    }
}
