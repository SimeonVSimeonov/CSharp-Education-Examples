using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings
    {
        List<string> data;

        public void Push(string item)
        {
            this.data.Add(item);
        }

        public string Pop()
        {
            var item = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return item;
        }

        public string Peek()
        {
            return data[data.Count - 1];
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }
    }
}
