using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elina_is_the_Queen
{
    class TextMap : ICollection<TextPoint>
    {
        TextPoint[] Points;

        public TextMap(int count)
        {
            Points = new TextPoint[count];
        }

        #region Difinition
        public int Count => Points.Count<TextPoint>();

        public TextPoint this[int index]
        {
            get { return Points[index]; }
            set { Points[index] = value; }
        }

        public bool IsReadOnly => false;

        public void Add(TextPoint item)
        {
            if (item.Number == Count)
            {
                Points[item.Number] = item;
            }
            else throw new IndexOutOfRangeException("TextPoint.Number != Count");
        }

        public void Clear()
        {
            Points = new TextPoint[Points.Length];
        }

        public bool Contains(TextPoint item)
        {
            foreach (TextPoint point in Points)
            {
                if (point.Equals(item)) return true;
            }

            return false;
        }

        public void CopyTo(TextPoint[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = Points[i];
            }
        }

        public IEnumerator<TextPoint> GetEnumerator() => new MapEnumerator(this);

        public bool Remove(TextPoint item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => new MapEnumerator(this);

        public class MapEnumerator : IEnumerator<TextPoint>
        {
            private TextMap collection;
            private int curIndex;
            private TextPoint curPoint;

            public MapEnumerator(TextMap map)
            {
                collection = map;
                curIndex = -1;
                curPoint = default(TextPoint);
            }

            public TextPoint Current => curPoint;

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (++curIndex >= collection.Count)
                {
                    return false;
                }
                else
                {
                    curPoint = collection[curIndex];
                }
                return true;
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
        #endregion

        //public Point getPoint()
    }
}
