using System.Text.Json;
using System.Xml.Linq;

namespace Service.Services
{
    public class Exercicio_3___Retornando_Faturamento
    {
        /// <summary>
        /// Chama o método DataFromFile para ler o arquivo a partir do seu caminho e filtra baseado nas condições de 
        /// menor valor, maior valor, valor maior do que zero e a média dos valores.
        /// 
        /// </summary>
        /// <param name="filePath"> Caminho do arquivo Json ou XML</param>
        /// <return>Retorna o menor valor, maior valor a média e a quantidade de dias que superaram a média.</return>
        public static void ValuesMonth(string filePath)
        {           
            var data = DataFromFile(filePath).Where(d => d.Value > 0);
            float minValue = data.Min(d => d.Value);
            float maxValue = data.Max(d => d.Value); 
            float averageMonthValue = data.Average(d => d.Value);

            List<int> daysWithHighAverage = data
                .Where(d => d.Value > averageMonthValue)
                .Select(d => d.Day)
                .ToList();

            Console.WriteLine($"Menor valor de Faturamento: R$ {minValue:0.00}\nMaior valor de Faturamento: R$ {maxValue:0.00}");
            Console.WriteLine($"Média Mensal: R$ {averageMonthValue:0.00}");
            Console.WriteLine($"Total de dias em que o faturamento foi maior do que a média: {daysWithHighAverage.Count}");  // Acesso à propriedade Count
        }
        /// <summary>
        /// Lê um arquivo baseado nas condições em que sejam Json ou XML.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo Json ou XML</param>
        /// <returns>Retorna um IEnumerable dos dados presentes no arquivo "Dados".</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<Data> DataFromFile(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();

            if (fileExtension == ".json")
            {
                return ReadJsonFile(filePath);
            }
            else if (fileExtension == ".xml")
            {
                return ReadXmlFile(filePath);
            }
            else
            {
                throw new InvalidOperationException("Formato de arquivo não suportado.");
            }
        }

        /// <summary>
        /// Lê um arquivo Json.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo Json</param>
        /// <returns>Retorna um IEnumerable dos dados presentes no arquivo "Dados".</returns>
        private static IEnumerable<Data> ReadJsonFile(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                using (var jsonDoc = JsonDocument.Parse(fs))
                {
                    foreach (var element in jsonDoc.RootElement.EnumerateArray())
                    {
                        var data = new Data()
                        {
                            Day = element.GetProperty("dia").GetInt32(),
                            Value = element.GetProperty("valor").GetSingle()
                        };

                        yield return data;
                    }
                }
            }
        }

        /// <summary>
        /// Lê um arquivo XML.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo XML</param>
        /// <returns>Retorna um IEnumerable dos dados presentes no arquivo "Dados".</returns>
        private static IEnumerable<Data> ReadXmlFile(string filePath)
        {
            XDocument xDoc = XDocument.Load(filePath);

            foreach (var element in xDoc.Descendants("data"))
            {
                var data = new Data()
                {
                    Day = int.Parse(element.Element("dia")?.Value),
                    Value = float.Parse(element.Element("valor")?.Value)
                };

                yield return data;
            }
        }

        public class Data
        {
            public int Day { get; set; }
            public float Value { get; set; }
        }

    }
}
