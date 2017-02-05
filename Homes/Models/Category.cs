using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homes.Models
{
    public class Category {
        private const int nCat = 5;
        public string[][] cat = new string[nCat][];
        public string[] name = new string[nCat];
        public Category(string pdam, string disdik, string kebersihan, string diskes, string dbmp)
        {
            cat[0] = pdam.Split(new string[] { "; " }, StringSplitOptions.None);
            cat[1] = disdik.Split(new string[] { "; " }, StringSplitOptions.None);
            cat[2] = kebersihan.Split(new string[] { "; " }, StringSplitOptions.None);
            cat[3] = diskes.Split(new string[] { "; " }, StringSplitOptions.None);
            cat[4] = dbmp.Split(new string[] { "; " }, StringSplitOptions.None);
            name[0] = "PDAM";
            name[1] = "Dinas Pendidikan";
            name[2] = "Dinas Kebersihan";
            name[3] = "Dinas Kesehatan";
            name[4] = "Dinas Bina Marga dan Pengairan";
        }

        public int getN()
        {
            return nCat;
        }

        public override string ToString()
        {
            string tmp = "";
            int i = 1;
            foreach (string[] s in cat)
            {
                tmp = tmp + "\nkategori ke-" + i;
                foreach (string t in s)
                {
                    tmp = tmp + t + ", ";
                }
                i++;
            }

            return tmp;
        }

    }
}