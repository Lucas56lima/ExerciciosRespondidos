namespace Service.Services
{
    public class Exercicio_4___Faturamento_Distribuidora
    {

        /// <summary>
        /// Cria uma lista com as informações de faturamento de cada estado, nome e valor.       
        /// </summary>        
        /// <returns>Informa o percentual correspondente de cada um em relação ao faturamento total</returns>
        public static void CalculatePercentual()
        {
            // Usando uma lista de objetos anônimos para associar estados e valores
            var stateData = new List<State>
            {
                new State("SP", 67836.43),
                new State("RJ", 36678.66),
                new State("MG", 29229.88),
                new State("ES", 27165.48),
                new State("Outros", 19849.53)
            };

            double totalValue = stateData.Sum(sd => sd.Value);  // Soma total dos valores

            foreach (var data in stateData)
            {
                double percentual = (data.Value / totalValue) * 100;
                Console.WriteLine($"Estado: {data.Name}");
                Console.WriteLine($"Percentual Correspondente: {percentual:0.00}%");
            }
        }
    }

    public class State
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public State(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
