using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class ProductModel : PageModel
    {
        public String MessageRezult { get; set; }
        public Product Product { get; set; } = new Product();
        public void OnPost(string name, decimal? price)
        {
            if (!price.HasValue || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            decimal? result = price * (decimal?)0.18;
            MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscount(string name, decimal? price, double discount)
        {
            decimal? result = price * (decimal?)discount/100;
            MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostBuyWithoutDiscount(string name, decimal? price)
        {
            MessageRezult = $"Вы купили товар {name} за {price}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnGet()
        {
            MessageRezult = "Для товара можно определить скидку";
        }
    }
}