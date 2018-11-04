using P09CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace P09CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        protected IList<string> collection = new List<string>();

        public virtual int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
