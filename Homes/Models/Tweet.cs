using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homes.Models
{
    public class Tweet {
        public String text;
        public String userID;
        public String userName;
        public String photoURL;
        public ulong tweetID;
        public int category;
        private int nFound;
        public List<int> idxFound;
        public string namaTempat;
        public int idxTempat;

        /*
         * Custom constructor
         * */
        public Tweet(String txt, String uID, String uName, String photo, ulong twitID)
        {
            text = txt;
            userID = uID;
            userName = uName;
            photoURL = photo;
            category = Searcher.ValUndef;
            tweetID = twitID;
            nFound = 0;
            idxFound = new List<int>();
            idxTempat = 0;
            namaTempat = "";
        }

        public override string ToString()
        {
            string tmp = "";
            foreach (int i in idxFound)
            {
                tmp = tmp + " " + i;
            }

            return "text " + text + "\nuserID " + userID +
                "\nuserName " + userName + "\ncat " + category + " nFound " + nFound + "\nFound on " + tmp;
        }

        public void CategorizeTweet(Category C, int option)
        { //option == 1 buat BM, 2 buat KMP
            List<int> tmp = new List<int>();
            int nCount;
            int idx = 0;
            int n;
            List<int> temp1 = new List<int>();
            for (int i = 0; i < C.getN(); i++)
            {
                nCount = 0; n = 0;
                for (int j = 0; j < C.cat[i].Length; j++)
                { //cek setiap kategori.
                    string[] splitted = C.cat[i][j].Split(new char[] { ' ' });
                    n = 0;
                    for (int k = 0; k < splitted.Length; k++)
                    {
                        if (option == 1)
                        {
                            idx = Searcher.searchBM(text, splitted[k]);
                        }
                        else
                        {
                            idx = Searcher.searchKMP(text, splitted[k]);
                        }
                        if (idx != Searcher.ValUndef)
                        {
                            n++;
                            temp1.Add(idx);
                        }
                    }
                    if (n == splitted.Length)
                    {
                        nCount++;
                        foreach (int it in temp1)
                        {
                            tmp.Add(it);
                        }
                    }
                    temp1.Clear();
                }
                if (nFound < nCount)
                { // ubah nilai categori sama idxfound di sebuah tweet
                    nFound = nCount;
                    idxFound = tmp.ToList();
                    category = i + 1;
                }
                tmp.Clear();
            }
        }

        public void caritempat()
        {
            int y;
            bool j = true;
            char d = 'd';
            char i = 'i';
            if (text[0].CompareTo(d) == 0 && text[1].CompareTo(i) == 0)
            {
                j = false;
                y = 0;
            }
            else
            {
                string di = " di ";
                y = (Searcher.searchKMP(text, di));
            }

            char b = ' ';
            string namanya = "";
            if (y != -1)
            {
                if (j == true)
                {
                    y++;
                }
                while (y < text.Length && text[y] != b)
                {
                    y++;
                }
                y++;
                string[] namat = new string[4];
                namat[0] = "terminal";
                namat[1] = "sungai";
                namat[2] = "kota";
                namat[3] = "taman";
                int v = 0;
                while (y < text.Length && text[y] != b)
                {
                    namanya = namanya.Insert(v, text[y].ToString());
                    y = y + 1;
                    v++;
                }
                foreach (string x in namat)
                {
                    if (x.Contains(namanya))
                    {

                        namanya = namanya.Insert(v, text[y].ToString());
                        y++;
                        v++;
                        while (y < text.Length && text[y] != b)
                        {
                            namanya = namanya.Insert(v, text[y].ToString());
                            y = y + 1;
                            v++;
                        }
                        break;
                    }
                }
            }

            namaTempat = namanya;
        }

        public void makebold()
        {
            int tambah = 0;
            int x;
            foreach (int j in idxFound)
            {
                if (tambah > 0)
                {
                    x = j + 14 * tambah;
                }
                else
                    x = j;
                text = text.Insert(x, "<b><i>");
                char b = ' ';
                while (x < text.Length && text[x] != b)
                {
                    x++;
                }
                text = text.Insert(x, "</b></i>");
                tambah++;
            }
        }

    }
}