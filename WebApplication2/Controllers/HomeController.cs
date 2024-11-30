using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculationService _calculationService;
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ICalculationService calculationService,ILogger<HomeController> logger)
        {
            _logger = logger;
            _calculationService = calculationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsingModelCalc()
        {
            Random random = new Random();

            int num1 = random.Next(0, 11); // Случайное число от 0 до 10
            int num2 = random.Next(0, 11); // Случайное число от 0 до 10
            string Divide(int num1, int num2)
            {
                if (num2 == 0)
                {
                    return "Ошибка (деление на ноль)"; // Если делитель равен 0, возвращаем сообщение об ошибке
                }
                else
                {
                    double numdiv = (double)num1 / num2; // Делим, если делитель не 0
                    return numdiv.ToString(); // Возвращаем результат как строку
                }
            }
            var model = new Values
            {
                Number1 = num1,
                Number2 = num2,
                Add = num1 + num2,
                Sub = num1 - num2,
                Mult = num1 * num2,
                Div = Divide(num1, num2)

            };


            return View(model);
        }



        public IActionResult UsingViewBagCalc()
        {

            Random random = new Random();
            ViewBag.num1 = random.Next(0, 11); // Случайное число от 0 до 10
            ViewBag.num2 = random.Next(0, 11); // Случайное число от 0 до 10

            // Сохраняем числа и результаты операций в ViewData
            ViewBag.Add = ViewBag.num1 + ViewBag.num2;
            ViewBag.Sub = ViewBag.num1 - ViewBag.num2;
            ViewBag.Mult = ViewBag.num1 * ViewBag.num2;



            // Обработка деления с проверкой на ноль
            ViewBag.Div = ViewBag.num2 != 0 ? ((double)ViewBag.num1 / ViewBag.num2).ToString("F2") : "Ошибка (деление на ноль)";
            return View();
        }



        public IActionResult UsingViewDataCalc()
        {

            Random random = new Random();
            int num1 = random.Next(0, 11); // Случайное число от 0 до 10
            int num2 = random.Next(0, 11); // Случайное число от 0 до 10

            // Сохраняем числа и результаты операций в ViewData
            ViewData["Number1"] = num1;
            ViewData["Number2"] = num2;
            ViewData["Addition"] = num1 + num2;
            ViewData["Subtraction"] = num1 - num2;
            ViewData["Multiplication"] = num1 * num2;

            // Обработка деления с проверкой на ноль
            ViewData["Division"] = num2 != 0 ? ((double)num1 / num2).ToString("F2") : "Ошибка (деление на ноль)";
            return View();
        }

        public IActionResult AccessServiceDirectly()
        {
            Random random = new Random();
            int num1 = random.Next(0, 11);
            int num2 = random.Next(0, 11);

            // Вызываем методы сервиса
            ViewData["Numberr1"] = num1;
            ViewData["Numberr2"] = num2;
            ViewData["Additionn"] = _calculationService.Add(num1, num2);
            ViewData["Subtractionn"] = _calculationService.Sub(num1, num2);
            ViewData["Multiplicationn"] = _calculationService.Mult(num1, num2);
            ViewData["Divisionn"] = _calculationService.Div(num1, num2);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}