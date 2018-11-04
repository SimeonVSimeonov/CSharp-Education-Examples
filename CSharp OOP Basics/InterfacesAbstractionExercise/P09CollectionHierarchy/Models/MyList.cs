using P09CollectionHierarchy.Contracts;

namespace P09CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, ICountable
    {
        public int Used => this.collection.Count;

        public override string Remove()
        {
            var item = this.collection[0];
            this.collection.RemoveAt(0);
            return item;
        }
    }
}
