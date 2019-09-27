using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elina_is_the_Queen
{
    class TextPoint
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
            : this(mainText, "", 1, 0, 0, 0, 1, Palitra.font.Size, false) { }
        public TextPoint(string mainText, float size)
            : this(mainText, "", 1, 0, 0, 0, 1, size, false) { }
        public TextPoint(string table, int colors, int ownNumber, int yesNumber, int noNumber)
            : this(table, "", colors, ownNumber, yesNumber, noNumber, 0, Palitra.font.Size, false) { }
        public TextPoint(string table, int colors, int ownNumber, int yesNumber, int noNumber, float size)
            : this(table, "", colors, ownNumber, yesNumber, noNumber, 0, size, false) { }
        public TextPoint(string table, string alter, int colors, int ownNumber, int yesNumber, int noNumber, int alterNumber)
            : this(table, alter, colors, ownNumber, yesNumber, noNumber, alterNumber, Palitra.font.Size, false) { }
        public TextPoint(string table, string alter, int colors, int ownNumber, int yesNumber, int noNumber, int alterNumber, float size)
            : this(table, alter, colors, ownNumber, yesNumber, noNumber, alterNumber, size, false) { }
        public TextPoint(string mainText, int colors, int number)
            : this(mainText, "", colors, number, 0, 0, 0, Palitra.font.Size, true) { }
        public TextPoint(string mainText, int colors, int number, float size)
            : this(mainText, "", colors, number, 0, 0, 0, size, true) { }

        public int Number {get { return number; } }

        public int nextTo(int answer)
        {
            if (!final)
            {
                switch (answer)
                {
                    case 1:
                        {
                            if (yesTo == 0) throw new ArgumentOutOfRangeException("Not found yes answer");
                            return yesTo;
                        }
                    case 2:
                        {
                            if (noTo == 0) throw new ArgumentOutOfRangeException("Not found no answer");
                            return noTo;
                        }
                    case 3:
                        {
                            if (alterTo == 0) throw new ArgumentOutOfRangeException("Not found alter answer");
                            return alterTo;
                        }
                    default:
                        throw new ArgumentOutOfRangeException("Bad answer");
                }
            }
            else return -1;
        }
    }
}