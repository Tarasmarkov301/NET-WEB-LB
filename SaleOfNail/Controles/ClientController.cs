using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SaleOfNail.Data.Models;
using SaleOfNail.Data.Interfaces;

namespace SaleOfNail.Controles
{
    public class ClientController : Controller
    {
        public static int number = 0;

        public ClientController(iClient client)
        {
            this.client = client;
        }
        private readonly iClient client;
        [HttpPost]
        public ViewResult List(string name)
        {
            ClientBuy buy = new ClientBuy(client.inProcess(name), client.Done(name), client.notDone(name), name);
            return View("/Views/Clients/List.cshtml", buy);
        }
        public ViewResult registration()
        {
            return View("/Views/Clients/registration.cshtml", "");
        }
        public ViewResult writeInBd(string user_name, string user_password, string user_telephone)
        {
            string value = "*";
            if (user_password.Length > 20)
            {
                value = "*пароль дуже довгий(максимум 20 символів);";
            }
            if (user_password.Length <= 4)
            {
                value = "*пароль дуже короткий(мінімум 5 символів);";
            }
            if (user_password.Length > 320)
            {
                value = value + "ім'я дуже довге(максимум 320 символів)";
            }
            if (client.getClient(user_name))
            {
                value = value + "таке їм'я вже використовуеться;";
            }
            if (value == "*" && client.setClient(user_name, user_password, user_telephone))
            {
                Response.Cookies.Append("name", user_name);
                return List(user_name);
            }
            else if (value == "*")
            {
                value = value + ("Невідома помилка;");
            }
            return View("/Views/Clients/registration.cshtml", value);
        }
        public ViewResult writeSaleInBD(int numberOfNail)
        {
            string name;
            if (Request.Cookies.TryGetValue("name", out name))
            {
                client.writeSale(numberOfNail, name);
            }
            return List(name);
        }

    }
}
