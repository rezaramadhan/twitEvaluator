using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homes.Models
{
    public class Searcher {
        public static int ValUndef = -1;

        public static int searchBM(string text, string pattern)
        {
            int tl = text.Length, pl = pattern.Length;
            int i, j, v;
            int[] tabel = new int[256];
            for (i = 0; i < 256; i++) tabel[i] = pl;
            for (i = 0; i < pl; i++)
            {
                v = pl - i - 1;
                tabel[Char.ToUpper(pattern[i])] = Math.Max(1, v);
            }
            while (i <= tl - pl)
            {
                for (j = pl - 1; j >= 0; j--)
                    if (Char.ToUpper(text[i + j]) != Char.ToUpper(pattern[j])) break;
                if (j < 0)
                {
                    return i;
                }
                if (i + pl - 1 < tl)
                {
                    i = i + tabel[Char.ToUpper(text[i + pl - 1])];
                }
                else
                {
                    i = i + tabel[Char.ToUpper(text[tl - 1])];
                }
            }
            return ValUndef;
        }

        public static int searchKMP(string textIn, string patternIn)
        {
            string text = textIn.ToUpper();
            string pattern = patternIn.ToUpper();
            int TLength = text.Length, PLength = pattern.Length;  //n,m   
            int i = 0, j = 0;

            int[] BorderFunction = setBorderFunction(pattern);

            while (i < TLength)
            {
                if (pattern[j] == text[i])
                {
                    if (j == PLength - 1)
                    {
                        int retval = i - PLength + 1;
                        return retval;
                    }
                    i++;
                    j++;
                }
                else if (j > 0) j = BorderFunction[j - 1];
                else i++;
            }
            return ValUndef;
        }

        private static int[] setBorderFunction(String pattern)
        {
            int[] BorderFunction = new int[pattern.Length];
            int PLength = pattern.Length;
            int i = 1, j = 0;
            while (i < PLength)
            {
                if (pattern[j] == pattern[i])
                {
                    BorderFunction[i] = j + 1;
                    i++; j++;
                }
                else if (j > 0)
                {
                    j = BorderFunction[j - 1];
                }
                else
                {
                    BorderFunction[i] = 0;
                    i++;
                }
            }
            return BorderFunction;
        }

    }
}