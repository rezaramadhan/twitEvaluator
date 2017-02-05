using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homes.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "Masukkan kata kunci!")]
        [Display(Name = "Keyword")]
        public string keyword { get; set; }

        [Display(Name = "Keyword untuk PDAM")]
        public string pdam1 { get; set; }

        [Display(Name = "Keyword untuk Dinas Pendidikan")]
        public string disdik1 { get; set; }

        [Display(Name = "Keyword untuk Dinas Kebersihan")]
        public string kebersihan1 { get; set; }

        [Display(Name = "Keyword untuk Dinas Kesehatan")]
        public string kesehatan1 { get; set; }

        [Display(Name = "Keyword untuk DBMP")]
        public string dbmp1 { get; set; }

        public string pil1 { get; set; }

        public string place { get; set; }
    }

    public class arrayCategory
    {
        public string[] pdam;
        public string[] disdik;
        public string[] kebersihan;
        public string[] kesehatan;
        public string[] dbmp;

        public void insertTo(string a, string b, string c, string d, string e)
        {
            pdam = a.Split(new string[] { ", " }, StringSplitOptions.None);

            /*int i = 0;
            foreach (string temp1 in split1)
            {
                pdam[i] = temp1;
                i++;
            }*/

            disdik = a.Split(new string[] { ", " }, StringSplitOptions.None);

            /*i = 0;
            foreach (string temp2 in split2)
            {
                disdik[i] = temp2;
                i++;
            }*/

            kebersihan = a.Split(new string[] { ", " }, StringSplitOptions.None);

            /*i = 0;
            foreach (string temp3 in split3)
            {
                kebersihan[i] = temp3;
                i++;
            }*/

            kesehatan = a.Split(new string[] { ", " }, StringSplitOptions.None);

            /*i = 0;
            foreach (string temp4 in split4)
            {
                kesehatan[i] = temp4;
                i++;
            }*/

            dbmp = a.Split(new string[] { ", " }, StringSplitOptions.None);

            /*i = 0;
            foreach (string temp5 in split5)
            {
                dbmp[i] = temp5;
                i++;
            }*/
        }
    }
}