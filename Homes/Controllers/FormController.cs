using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homes.Models;

namespace Homes.Controllers
{
    public class FormController : Controller
    {
        // GET: /Form/
        private string tmp;

        public ActionResult Index()
        {
            
            int ntweet = 100;
            ViewBag.nTweet = ntweet;

            FormModel themodel = (FormModel)TempData["frommodel"];
            //int pilih;
            //string pil = themodel.pil1;
            //if (pil[0] == 'K') {
            //    pilih = 1;
            //} else 
            //    pilih = 0;
            //@ViewBag.pil = pilih;
            
            //Category cat = new Category(themodel.pdam1, themodel.disdik1, themodel.kebersihan1, themodel.kesehatan1, themodel.dbmp1);
            Category cat = new Category("banjir", "un", "kotor", "sakit", "rusak");
            ViewBag.ct = cat;
            //var tweets = new ArrTweet(themodel.keyword, ntweet);
            var tweets = new ArrTweet("bandung", ntweet);
            
            //tweets.AnalizeTweet(cat, pilih);
            tweets.cariAllTempat();
            //tweets.AnalizeTweet(cat, 0);
            ViewBag.len = tweets.length;
            /**DEBUG*
            for (int i = 0; i < ntweet; i++)
            {
                tweets.T[i].category = i % 6 - 1;
            }*/
            if (tweets.length != 0)
            {
                ViewBag.twit = new Tweet[tweets.length];
                int i = 0;
                foreach (var tx in tweets.T)
                {
                    ViewBag.twit[i] = tweets.T[i];
                    i++;
                }
            }
            ViewBag.key = new string[5];
            ViewBag.key[0] = themodel.pdam1;
            ViewBag.key[1] = themodel.disdik1;
            ViewBag.key[2] = themodel.kebersihan1;
            ViewBag.key[3] = themodel.kesehatan1;
            ViewBag.key[4] = themodel.dbmp1;
            /*ViewBag.key[0] = "key1; key2; key3";
            ViewBag.key[1] = "key1; key2; key3";
            ViewBag.key[2] = "key1; key2; key3";
            ViewBag.key[3] = "key1; key2; key3";
            ViewBag.key[4] = "key1; key2; key3";*/

            return View();
        }

        [HttpPost]
        public ActionResult FormPage(FormModel fmodel)
        {
            tmp = fmodel.keyword;
            TempData["keyword"] = fmodel.keyword;
            TempData["frommodel"] = fmodel;
            var key1 = TempData["keyword"];
            ViewBag.keyword = "KEYWORD = " + key1;
            ViewBag.pdam = "PDAM = " + fmodel.pdam1;
            return RedirectToAction("Index");
            //return View();
        }

        /*[HttpPost]
        public ActionResult Index(arrayCategory categ, FormModel fmodel)
        {
            ViewBag.aa = "aaaapaaaa";
            var categ1 = TempData["keyword"];
            if (tmp != "")
                ViewBag.keyyy = tmp;
            else
                ViewBag.keyyy = "sdsds";
            //categ.insertTo(fmodel.pdam1, fmodel.disdik1, fmodel.kebersihan1, fmodel.kesehatan1, fmodel.dbmp1);
            //ViewBag.pdam1 = categ.pdam[0];
            //ViewBag.kesehatan1 = categ.kesehatan[0];
            return View();
        }*/

        public ActionResult FormPage()
        {
            return View();
        }

        public ActionResult Maps(string place)
        {
            string plc = place;
            ViewBag.plc = plc;

            return View();
        }
	}
}