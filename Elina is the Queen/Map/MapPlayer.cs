using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Elina_is_the_Queen
{
    public class MapPlayer
    {
        readonly TextMap points;
        public TextPoint CurrentPoint { get; private set; }

        public MapPlayer(string path)
        {
            points = DeserializeItem(path, new BinaryFormatter());
            CurrentPoint = points[0];
        }

        public void MoveTo(int ans)
        {
            int num = CurrentPoint.NextTo(ans);
            if (num == -1)
            {
                CurrentPoint = points[0];
            }
            else
            {
                CurrentPoint = points[num];
            }
            if (CurrentPoint == null)
            {
                CurrentPoint = new TextPoint("Ooops, this point don't create yet", 1, -1);
            }
        }

        public static TextMap DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            TextMap map = (TextMap)formatter.Deserialize(s);
            s.Close();
            return map;
        }
    }
}
