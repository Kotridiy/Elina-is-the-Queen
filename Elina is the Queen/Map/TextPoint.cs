using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace Elina_is_the_Queen
{
    [Serializable]
    public class TextPoint : ISerializable
    {
        string  tableText;
        string  alterText;
        int     colorPack;
        int     number;
        int     yesTo;
        int     noTo;
        int     alterTo;
        float   textSize;
        bool    final;



        TextPoint(string table, string alter, int colors, int numb, int yes, int no, int alt, float size, bool final)
        {
            tableText = table;
            alterText = alter;
            colorPack = colors;
            number = numb;
            yesTo = yes;
            noTo = no;
            alterTo = alt;
            textSize = size;
            this.final = final;
        }

        
        public TextPoint(string mainText)
            : this(mainText, "Начать", 1, 0, 0, 0, 1, Palitra.font.Size, false) { } // Нулевая точка
        public TextPoint(string mainText, float size)
            : this(mainText, "Начать", 1, 0, 0, 0, 1, size, false) { } // Нулевая точка с размером
        public TextPoint(string table, int colors, int ownNumber, int yesNumber, int noNumber)
            : this(table, "", colors, ownNumber, yesNumber, noNumber, 0, Palitra.font.Size, false) { } // Обычная точка
        public TextPoint(string table, int colors, int ownNumber, int yesNumber, int noNumber, float size)
            : this(table, "", colors, ownNumber, yesNumber, noNumber, 0, size, false) { } // Обычная точка с размером
        public TextPoint(string table, string alter, int colors, int ownNumber, int yesNumber, int noNumber, int alterNumber)
            : this(table, alter, colors, ownNumber, yesNumber, noNumber, alterNumber, Palitra.font.Size, false) { } // Точка с альтернативным ответом
        public TextPoint(string table, string alter, int colors, int ownNumber, int yesNumber, int noNumber, int alterNumber, float size)
            : this(table, alter, colors, ownNumber, yesNumber, noNumber, alterNumber, size, false) { } // Точка с альтернативным ответом и размером
        public TextPoint(string mainText, int colors, int number)
            : this(mainText, "", colors, number, 0, 0, 0, Palitra.font.Size, true) { } // Финальная точка
        public TextPoint(string mainText, int colors, int number, float size)
            : this(mainText, "", colors, number, 0, 0, 0, size, true) { } // Финальная точка с размером

        protected TextPoint(SerializationInfo info, StreamingContext context)
        {
            tableText = (string)info.GetValue("table", typeof(string));
            alterText = (string)info.GetValue("alter", typeof(string));
            colorPack = (int)info.GetValue("color", typeof(int));
            number = (int)info.GetValue("num", typeof(int));
            yesTo = (int)info.GetValue("yes", typeof(int));
            noTo = (int)info.GetValue("no", typeof(int));
            alterTo = (int)info.GetValue("alt", typeof(int));
            textSize = (float)info.GetValue("size", typeof(float));
            final = (bool)info.GetValue("final", typeof(bool));
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //string index = (string)context.Context;
            info.AddValue("table", tableText);
            info.AddValue("alter", alterText);
            info.AddValue("color", colorPack);
            info.AddValue("num", number);
            info.AddValue("yes", yesTo);
            info.AddValue("no", noTo);
            info.AddValue("alt", alterTo);
            info.AddValue("size", textSize);
            info.AddValue("final", final);

        }

        public int Number {get { return number; } }

        public string TableText { get => tableText; }
        public string AlterText { get => alterText; }
        public int ColorPack { get => colorPack; }
        public float TextSize { get => textSize; }

        public int nextTo(int answer)
        {
            if (!final)
            {
                switch (answer)
                {
                    case 1:
                        {
                            return yesTo;
                        }
                    case 2:
                        {
                            return noTo;
                        }
                    case 3:
                        {
                            return alterTo;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("ans");
                }
            }
            else return -1;
        }

        public bool IsFinal() { return final; }

        public bool IsPathEmpty()
        {
            if (alterTo != 0 || (yesTo != 0 && noTo != 0)) return false;
            else return true;
        }

        public void ErasePath(int path)
        {
            if (yesTo == path) yesTo = 0;
            if (noTo == path) noTo = 0;
            if (alterTo == path) alterTo = 0;
        }

        public bool CreatePath(int ans, int path)
        {
            switch(ans)
            {
                case 1:
                    {
                        if (yesTo == 0) yesTo = path;
                        else return false;
                        break;
                    }
                case 2:
                    {
                        if (noTo == 0) noTo = path;
                        else return false;
                        break;
                    }
                case 3:
                    {
                        if (alterTo == 0) alterTo = path;
                        else return false;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("ans");
                    }
            }
            return true;
        }
    }
}