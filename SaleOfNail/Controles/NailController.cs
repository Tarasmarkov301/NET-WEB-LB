using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaleOfNail.Data.Interfaces;
using SaleOfNail.Data.Models;
using Microsoft.AspNetCore.Http;

namespace SaleOfNail.Controles
{
    public class NailController : Controller
    {
        public string nameClient = "";
        public NailController(iNail allNail)
        {
            this.allNail = allNail;

        }
        private readonly iNail allNail;
        public ViewResult List()
        {
            var nail = allNail.ALLNail;
            string name;
            NailAndClient nac;
            if (Request.Cookies.TryGetValue("name", out name))
            {
                nac = new NailAndClient(nail, name);
            }
            else
            {
                nac = new NailAndClient(nail, "");
            }
            return View("/Views/Nail/List.cshtml", nac);
        }

        public ViewResult findNail(int maxPrice, string name)
        {
            int maxPriceC = int.Parse($"{maxPrice}");
            var nail = allNail.getNail(maxPriceC, name);
            string names;
            NailAndClient nac;
            if (Request.Cookies.TryGetValue("name", out names))
            {
                nac = new NailAndClient(nail, names);
            }
            else
            {
                nac = new NailAndClient(nail, "");
            }
            return View("/Views/Nail/List.cshtml", nac);
        }
        public ViewResult oneNail(int id)
        {


            var nail = allNail.getOneNail(id);
            string name;
            OneNailAndClient nac;
            if (Request.Cookies.TryGetValue("name", out name))
            {
                nac = new OneNailAndClient(nail, name);
            }
            else
            {
                nac = new OneNailAndClient(nail, "");
            }
            return View("/Views/Nail/OneNail.cshtml", nac);
        }
        [HttpPost]
        public ViewResult enter(string user_name, string user_password)
        {
            if (allNail.getPass(user_name, user_password))
            {
                Response.Cookies.Append("name", user_name);
            }
            return List();
        }

    }
}
