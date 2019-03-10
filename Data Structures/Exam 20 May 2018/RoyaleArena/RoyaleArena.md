

# Problem 1.Data Structures Exam Retake: RoyaleArena

# Problem 2.Description

You have been invited by the blue king himself. He is in a huge need for an application to help him fight in the glorious Royale Arena. As one of the top players on the arena, he has a reputation to maintain, therefore he cannot afford to lose. The application must be able to keep and query all the cards that exist within the game. Each card has its own specifics. The trick is that the intervals between the battles are so small, that the application must be fast in order to help the king.

**Battlecard** will hold:

- **int Id** – unique card id
- **CardType Type** – enumeration of battlecard
- **string Name** – the name of the card
- **int Damage** – the damage of the card
- **int Swag** – the swag of the card

You need to support the following operations (and they should be **fast** ):

- **Add()** – Add a battle card to the arena. You will need to implement the **Contains()** methods as well.
- **Contains(Battlecard)** – checks if a given battlecard is present in the arena.
- **Count** – returns the number of cards in the arena
- **ChangeCardType(id, type)** – changes the status of the battlecard with the given id or throws **ArgumentException** if no such card exists.
- **GetById(id)** – return the card with the given **id**. If such card doesn&#39;t exist, throw **InvalidOperationException**.
- **RemoveById(id)** – Removes the card with the given id, otherwise throws **InvalidOperationException**
- **GetByCardType(type)** – Returns the cards with the given **card type ordered by damage descending then by id**. If there are no cards with the given type, throw **InvalidOperationException**
- **GetByTypeAndDamageRangeOrderedByDamageThenById(type, lo, hi)** – returns all cards with particular card type ordered by damage descending (exclusive), then by id ascending. If there are no such types throw **InvalidOperationException**
- **GetByCardTypeAndMaximumDamage(type, damage)** – returns all cards with given type and damage less or equal to a maximum allowed amount ordered by damage descending, then by id. Throws an **InvalidOperationException** if such cards were not found.
- **GetByNameOrderedBySwagDescending(name)** – search for all cards with a specific name and return them ordered by swag descending then by id. If there are no such cards throw **InvalidOperationException**
- **GetByNameAndSwagRange(name, lo, hi)** – returns all cards with given name and swag between lo (inclusive) and hi (exclusive) ordered by swag descending then by id. If there are no such cards throw **InvalidOperationException****.**

**GetAllByNameAndSwag() –**  **Returns the most swaggish card for each name****. Throws InvalidOperationException/IllegalOperationException if none were found**

- **FindFirstLeastSwag(n) –**  **Returns the first n cards with least swag. If there are two identical swags, order by id. If the argument passed exceeds the count of the arena,**

**Throw InvalidOperationException/IllegalOperationException**

- **GetAllInSwagRange(lo, hi)** – returns all cards within a range ordered by swag(the range is inclusive). Returns an empty collection if no such cards were found.
- **GetEnumerator()** – Iterate the arena by insertion order

The equivalent exception in java is **IllegalArgumentException** **(all exceptions in java will be IllegalArgumentException)**.

# Problem 3.Input / Output

You are given a **Visual Studio C# project skeleton** (unfinished project) / **IntelliJ Java project** holding the interface **IArena** , the unfinished classes **RoyaleArena** and **Battlecard**. **Tests** covering the **RoyaleArena**** functionality **and** performance**.

Your task is to **finish this class** to make the tests run correctly.

- You are **not allowed to change the tests**.
- You are **not allowed to change the interface**.
- You can add to the **Battlecard** class, but don&#39;t remove anything.
- You can edit the **RoyaleArena** class if it implements the **IArena** interface.

# Problem 4.Interface

The interface **IArena** in C# looks like the code below:

| publicinterfaceIArena : IEnumerable\&lt;Battlecard\&gt;{    void Add(Battlecard card);    bool Contains(Battlecard card);    int Count { get; }    void ChangeCardType(int id, CardType type);    Battlecard GetById(int id);    void RemoveById(int id);    IEnumerable\&lt;Battlecard\&gt; GetByCardType(CardType type);    IEnumerable\&lt;Battlecard\&gt; GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type);    IEnumerable\&lt;Battlecard\&gt; GetByCardTypeAndMaximumDamage(CardType type, int damage);     IEnumerable\&lt;Battlecard\&gt; GetByNameOrderedBySwagDescending(string name);    IEnumerable\&lt;Battlecard\&gt; GetByNameAndSwagRange(string name, int lo, int hi);     IEnumerable\&lt;Battlecard\&gt; GetAllByNameAndSwag(string name);    IEnumerable\&lt;Battlecard\&gt; FindFirstLeastSwag(int n);     IEnumerable\&lt;Battlecard\&gt; GetAllInSwagRange(int lo, int hi);} |
| --- |

The interface **Arena** in Java looks like the code below:

| **public interface Arena extends Iterable\&lt;Battlecard\&gt; {****     void add(Battlecard card);****    boolean contains(Battlecard card);****    int getCount();****    void changeCardType(int id, CardType type);****    Battlecard getById(int id);****    void removeById(int id);****    Iterable\&lt;Battlecard\&gt; GetByCardType(CardType type);****    Iterable\&lt;Battlecard\&gt; GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type);****    Iterable\&lt;Battlecard\&gt; GetByCardTypeAndMaximumDamage(CardType type, int damage);****    Iterable\&lt;Battlecard\&gt; GetByNameOrderedBySwagDescending(String name);****    Iterable\&lt;Battlecard\&gt; GetByNameAndSwagRange(String name, int lo, int hi);****    Iterable\&lt;Battlecard\&gt; GetAllByNameAndSwag(String name);****    Iterable\&lt;Battlecard\&gt; FindFirstLeastSwag(int n);****    Iterable\&lt;Battlecard\&gt; GetAllInSwagRange(int lo, int hi);****}** |
| --- |

# Problem 5.Submission

Submit an archive (.zip) of the source code. Your code **mustn&#39;t** contain **namespaces** / **packages**.

# Problem 6.Scoring

Each implemented method brings you a specific amount of points, some of the points are awarded for correct behavior, others for performance. **The performance tests might not work on your PC**. You need to cover all tests in each group to receive points. Bellow is a breakdown of all points by methods:

|   | Correct Behavior | Performance | Total |
| --- | --- | --- | --- |
| Overall | 100 | 100 | 200 |

