namespace WebApplication2.Models
{
    public interface ICalculationService
    {
        int Add(int a, int b);
        int Sub(int a, int b);
        int Mult(int a, int b);
        string Div(int a, int b);
    }

    public class CalculationService : ICalculationService
    {
        public int Add(int a, int b) => a + b;

        public int Sub(int a, int b) => a - b;

        public int Mult(int a, int b) => a * b;

        public string Div(int a, int b) =>
            b != 0 ? ((double)a / b).ToString("F2") : "Ошибка (деление на ноль)";
    }
}