namespace Service.Services
{
    public class Exercicio_2___Fibonacci
    {
        /// <summary>
        /// Faz a sequência de Fibonacci baseado na quantidade de números informados.
        /// </summary>
        /// <param name="n"> O número limite de valores mostrados na sequência.</param>
        /// <returns>Uma lista da sequência com a quantidade de argumentos informados.</returns>
        public static List<int> Fibonacci(int n)
        {
            int a = 0, b = 1;
            List<int> sequence = new();

            for (int i = 1; i < n; i++)
            {
                sequence.Add(a);
                int temp = a;
                a = b;
                b = temp + b;                
            }
            bool isFibonnaci = IsFibonacci(n);
            if (!isFibonnaci)
            {
                Console.WriteLine($"O número {n} não pertence a sequência.");
            }
            return sequence;
        }
        /// <summary>
        /// Verifica se pertence a sequência baseado nas fórmulas 5n^2 + 4 e 5n^2 + 5
        /// </summary>
        /// <param name="n"> O número selecionado na sequência de fibonnaci</param>
        /// <returns>True ou false</returns>
        public static bool IsFibonacci(int n)
        {
            int x1 = (5 * n) * (n + 4);
            int x2 = (5 * n * n - 4);

            return IsPerfectSquare(x1) || IsPerfectSquare(x2);
        }

        /// <summary>
        /// Verifica se é um quadrado perfeito.
        /// </summary>
        /// <param name="n"> O número selecionado na sequência de fibonnaci</param>
        /// <returns>True ou false</returns>
        private static bool IsPerfectSquare(int n)
        {            
            int sqrt = (int)Math.Sqrt(n);
            
            return sqrt * sqrt == n;
        }

    }

}
