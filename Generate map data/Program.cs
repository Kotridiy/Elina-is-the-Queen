using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elina_is_the_Queen;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Generate_map_data
{
    class Program
    {
        static void Main(string[] args)
        {
            TextMap textMap;
            string fileName = "map.dat";
            IFormatter formatter = new BinaryFormatter();

            
            //SerializeItem(fileName, formatter, textMap);
            //DeserializeItem(fileName, formatter, textMap);

            Console.Write("Откуда взять карту? \n" +
                "1. Создать новую \n" +
                "2. Открыть существующую \n");
            int.TryParse(Console.ReadLine(), out int func);

            switch (func)
            {
                case 1:
                    {
                        textMap = new TextMap();
                        Console.WriteLine("Вступительный текст");
                        string text = Console.ReadLine();
                        textMap.Add(new TextPoint(text));
                        break;
                    }
                case 2:
                    {
                        textMap = DeserializeItem(fileName, formatter);
                        break;
                    }

                default:
                    return;
            }

            do
            {
                Console.Clear();
                Console.Write("Выбирете действие: \n" +
                    "1. Создать элемент \n" +
                    "2. Посмотреть элемент \n" +
                    "3. Пройти по пути \n" +
                    "4. Отсечь ветку \n" +
                    "5. Посмотреть несуществующие ветки \n" +
                    "6. Посмотреть элементы с одним ответом \n" +
                    "7. Посмотреть финальные элементы \n" +
                    "0. Exit \n");
                int.TryParse(Console.ReadLine(), out func);

                switch (func)
                {
                    case 0:
                        {
                            SerializeItem(fileName, formatter, textMap);
                            break;
                        }
                    case 1:
                        {
                            string ans = "", text, alter = "";
                            string colors = "Выберите цвет: \n" +
                                "1. Нормальный \n" +
                                "2. Пессиместичный \n" +
                                "3. Весёлый \n" +
                                "4. Злой \n" +
                                "5. РаДуЖнЫй \n";
                            int num = 0, color = 0, yes = 0, no = 0, alt = 0, size = 0;

                            Console.Clear();
                            Console.WriteLine("Номер точки: ");
                            do
                            {
                                int.TryParse(Console.ReadLine(), out num);
                                if (num == 0) Console.WriteLine("Не может быть 0");
                                if (textMap[num] != null)
                                {
                                    Console.WriteLine("Такая точка сущесвует. Продолжить? (да/нет)");
                                    do
                                    {
                                        ans = Console.ReadLine();
                                    } while (ans != "да" || ans != "нет");
                                }
                            } while (num == 0 || textMap[num] != null && ans == "нет");

                            Console.Clear();
                            Console.WriteLine("Финальная точка? (да/нет)");
                            do
                            {
                                ans = Console.ReadLine();
                            } while (ans != "да" && ans != "нет");

                            Console.Clear();
                            Console.Write("Текст: ");
                            do
                            {
                                text = Console.ReadLine();
                            } while (text == "");

                            Console.Clear();
                            Console.Write("Размер текста: ");
                            do
                            {
                                int.TryParse(Console.ReadLine(), out size);
                            } while (size < 0);

                            Console.Clear();
                            Console.WriteLine(colors);
                            do
                            {
                                int.TryParse(Console.ReadLine(), out color);
                            } while (color < 1 || color > 5);


                            if (ans == "да")
                            {
                                if (size == 0) textMap.Add(new TextPoint(text, color, num));
                                else textMap.Add(new TextPoint(text, color, num, size));
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Ответ да - ");
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out yes);
                                } while (yes < 0);

                                Console.Clear();
                                Console.Write("Ответ нет - ");
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out no);
                                } while (no < 0);

                                Console.Clear();
                                Console.Write("Альтенативный ответ - ");
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out alt);
                                } while (alt < 0);

                                if (alt != 0)
                                {
                                    Console.Clear();
                                    Console.Write("Текст альтентавиного ответа: ");
                                    do
                                    {
                                        alter = Console.ReadLine();
                                    } while (alter == "");
                                }

                                if (size == 0)
                                {
                                    if (alt == 0) textMap.Add(new TextPoint(text, color, num, yes, no));
                                    else textMap.Add(new TextPoint(text, alter, color, num, yes, no, alt));
                                }
                                else
                                {
                                    if (alt == 0) textMap.Add(new TextPoint(text, color, num, yes, no, size));
                                    else textMap.Add(new TextPoint(text, alter, color, num, yes, no, alt, size));
                                }
                            }

                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            int num = 0;

                            Console.Clear();
                            Console.Write("Номер элемента: ");
                            do
                            {
                                int.TryParse(Console.ReadLine(), out num);
                            } while (num < 0);

                            ViewPoint(textMap, num);

                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            int num = 0;
                            Console.Clear();
                            do
                            {
                                Console.Write("\nНомер элемента: ");
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out num);
                                } while (num < 0);
                            } while (ViewPoint(textMap, num));

                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            int num = 0;

                            Console.Clear();
                            Console.Write("Номер элемента: ");
                            do
                            {
                                int.TryParse(Console.ReadLine(), out num);
                            } while (num < 0);

                            if (textMap[num] == null)
                                Console.WriteLine("Элемента нет");
                            else
                            {
                                textMap.Remove(textMap[num]);
                                Console.WriteLine("Ветка удалена");
                            }

                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            ForEachInMap(textMap, point => textMap[point.NextTo(1)] == null ||
                                                           textMap[point.NextTo(2)] == null ||
                                                           textMap[point.NextTo(3)] == null);
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            ForEachInMap(textMap, point => point.NextTo(3) == 0 &&
                                                           point.NextTo(1) * point.NextTo(2) == 0);
                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            ForEachInMap(textMap, point => point.IsFinal, true);
                            Console.ReadKey();
                            break;
                        }
                }
            } while (func != 0);
        }


        public static void SerializeItem(string fileName, IFormatter formatter, TextMap map)
        {
            FileStream stream = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(stream, map);
            stream.Close();
        }


        public static TextMap DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            TextMap map = (TextMap)formatter.Deserialize(s);
            /*foreach (TextPoint point in map)
            {
                if (point == null) continue;
                Console.WriteLine(point.TableText);
            }
            Console.ReadKey();*/
            s.Close();
            return map;
        }


        public static bool ViewPoint(TextMap map, int index)
        {

            TextPoint point = map[index];

            if (point == null)
            {
                Console.WriteLine("Такого элемента нет");
                return false;
            }
            else
            {
                Console.WriteLine("Точка №{0} {1}", point.Number, (point.IsFinal) ? "финальная" : "");

                Console.WriteLine("Основной текст - " + point.TableText);

                Console.WriteLine("С размером шрифта {0}px", point.TextSize);

                switch (point.ColorPack)
                {
                    case 1:
                        {
                            Console.Write("Нормальный");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Пессимистичный");
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Весёлый");
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Злой");
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Радужный");
                            break;
                        }
                }
                Console.WriteLine(" цвет");

                if (point.IsFinal) return false;

                Console.WriteLine("Ответы:");
                if (point.NextTo(1) == 0) Console.WriteLine("Да - 0");
                else if (map[point.NextTo(1)] == null) Console.WriteLine("Да - {0}, точки нет", point.NextTo(1));
                else Console.WriteLine("Да - {0}, {1}", point.NextTo(1), map.Preview(point, 1));

                if (point.NextTo(2) == 0) Console.WriteLine("Нет - 0");
                else if (map[point.NextTo(2)] == null) Console.WriteLine("Нет - {0}, точки нет", point.NextTo(2));
                else Console.WriteLine("Нет - {0}, {1}", point.NextTo(2), map.Preview(point, 2));

                if (point.NextTo(3) == 0) Console.WriteLine("Альтернативный - 0");
                else if (map[point.NextTo(3)] == null) Console.WriteLine("{1} - {0}, точки нет", point.NextTo(3), point.AlterText);
                else Console.WriteLine("{2} - {0}, {1}", point.NextTo(3), map.Preview(point, 3), point.AlterText);

                if (point.NextTo(1) == 0 && point.NextTo(2) == 0 && point.NextTo(3) == 0) return false;
                return true;
            }
        }


        public static void ForEachInMap(TextMap textMap, Predicate<TextPoint> predicate, bool useFinal = false)
        {
            bool find = false;
            foreach (var point in textMap)
            {
                if (point == null)
                {
                    Console.WriteLine("Null");
                    Console.WriteLine(new string('-', 20));
                    continue;
                }
                if (!useFinal && point.IsFinal) continue;
                if (predicate(point))
                {
                    ViewPoint(textMap, point.Number);
                    Console.WriteLine(new string('-', 20));
                    find = true;
                }
            }
            if (!find)
            {
                Console.WriteLine("Таких точек нет");
            }
        }
    }
}