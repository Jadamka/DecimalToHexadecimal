using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        public static string CalcRemainder(int x)
        {
            string result = "";
            double val;
            float hX;

            do
            {
                if (x == 0)
                    result += "00";
                else if (x > 0)
                {
                    hX = (float)x / 16;
                    x = (int)hX;
                    val = (hX - Math.Truncate(hX)) * 16;
                    result += Hexa(val.ToString());
                }
            } while (x > 0);

            return Reverse(result);
        }

        public static string Hexa(string color)
        {
            if (color == "00")
                return "00";

            string result = "";

            int x = int.Parse(color);
            switch (x)
            {
                case 10:
                    result += "A";
                    break;
                case 11:
                    result += "B";
                    break;
                case 12:
                    result += "C";
                    break;
                case 13:
                    result += "D";
                    break;
                case 14:
                    result += "E";
                    break;
                case 15:
                    result += "F";
                    break;
                default:
                    result += x.ToString();
                    break;
            }

            return result;
        }

        public static string Reverse(string s)
        {
            char[] charArr = s.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        public static string Rgb(int r, int g, int b)
        {
            string red = "", green = "", blue = "";

            // any value that is not in range 0-255 must be rounded to the closest value

            r = (r < 0) ? r = 0 : (r > 255) ? r = 255 : r;
            g = (g < 0) ? g = 0 : (g > 255) ? g = 255 : g;
            b = (b < 0) ? b = 0 : (b > 255) ? b = 255 : b;

            red = CalcRemainder(r);
            green = CalcRemainder(g);
            blue = CalcRemainder(b);

            if(red.Length == 1)
            {
                red += "0";
                red = Reverse(red);
            }
            if(green.Length == 1)
            {
                green += "0";
                green = Reverse(green);
            }
            if(blue.Length == 1)
            {
                blue += "0";
                blue = Reverse(blue);
            }

            return $"{red}{green}{blue}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Rgb(212, 53, 12));
            Console.ReadKey();
        }
    }
}
