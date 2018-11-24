namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            var item = this.data[data.Count - 1];
            this.data.RemoveAt(data.Count - 1);
            return item;
        }

    }
}
