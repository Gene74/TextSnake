using System.Collections.Generic;
using System.Linq;


namespace TextGameFramework
{
    public class FIFO<T> where T : class
    {
        List<T> elements;

        public long Count { get { return elements.Count; } }

        public FIFO()
        {
            elements = new List<T>();
        }

        public void Push(T e) => elements.Add(e);

        public T Pull()
        {
            if (Count == 0)
                return null;
            else
            {
                T e = elements.ElementAt(0);
                elements.RemoveAt(0);
                return e;
            }
        }
    }
}
