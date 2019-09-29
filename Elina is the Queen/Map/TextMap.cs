using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Elina_is_the_Queen
{
    [Serializable]
    public class TextMap : ICollection<TextPoint>, ISerializable
    {
        List<TextPoint> Points;

        public TextMap()
        {
            Points = new List<TextPoint>();
        }
        public TextMap(List<TextPoint> list)
        {
            Points = new List<TextPoint>(list);
        }
        protected TextMap(SerializationInfo info, StreamingContext context)
        {
            Points = (List<TextPoint>)info.GetValue("points", typeof(List<TextPoint>));
        }

        #region Difinition
        public int Count => Points.Count();

        public TextPoint this[int index]
        {
            get
            {
                try
                {
                    return Points.Find((elem) => elem.Number == index);
                }
                catch (Exception)
                {
                    return null;
                }
                
            }

            private set
            {
                if (Points.Exists((elem) => elem.Number == index))
                {
                    Points[Points.FindIndex((elem) => elem.Number == index)] = value;
                }
                else
                {
                    Points.Add(value);
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(TextPoint item)
        {
            if (this[item.Number] != null)
                throw new Exception("Point with this index is exist yet");

            if (item.Number == 0 || Points.Exists((elem) => elem.NextTo(1) != 0 || elem.NextTo(2) != 0 || elem.NextTo(3) != 0))
            {
                Points.Add(item);
            }
            else throw new Exception("Points that refer to Point don't exist");
        }

        public void Clear()
        {
            Points = new List<TextPoint>();
        }

        public bool Contains(TextPoint textPoint)
        {
            foreach (TextPoint point in Points)
            {
                if (point.Number == textPoint.Number) return true;
            }

            return false;
        }

        public void CopyTo(TextPoint[] array, int arrayIndex)
        {
            if (array == null)
                    throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            for (int i = 0; i < Points.Count; i++)
            {
                array[i + arrayIndex] = Points[i];
            }
        }

        public IEnumerator<TextPoint> GetEnumerator() => new MapEnumerator(this);

        public bool Remove(TextPoint item)
        {
            if (item == null) return false;

            Points.Remove(item);

            if (item.NextTo(1) != 0 && !Points.Exists((elem) => item.NextTo(1) == elem.NextTo(1) ||
                                                                item.NextTo(1) == elem.NextTo(2) ||
                                                                item.NextTo(1) == elem.NextTo(3)))
                Remove(this[item.NextTo(1)]);

            if (item.NextTo(2) != 0 && !Points.Exists((elem) => item.NextTo(2) == elem.NextTo(1) ||
                                                                item.NextTo(2) == elem.NextTo(2) ||
                                                                item.NextTo(2) == elem.NextTo(3)))
                Remove(this[item.NextTo(2)]);

            if (item.NextTo(3) != 0 && !Points.Exists((elem) => item.NextTo(3) == elem.NextTo(1) ||
                                                                item.NextTo(3) == elem.NextTo(2) ||
                                                                item.NextTo(3) == elem.NextTo(3)))
                Remove(this[item.NextTo(3)]);

            return true;
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
                    curPoint = collection.Points[curIndex];
                }
                return true;
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
        #endregion

        public string Preview(TextPoint point, int ans)
        {
            TextPoint nextPoint = this[point.NextTo(ans)];
            string substring;
            if (nextPoint.TableText.Length >= 10) substring = nextPoint.TableText.Substring(0, 11) + "...";
            else substring = nextPoint.TableText;
            return substring;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("points", Points, typeof(List<TextPoint>));
        }
    }
}