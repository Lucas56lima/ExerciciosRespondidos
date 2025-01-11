namespace Service.Services
{
    public class Exercicio_1___Total_de_Soma
    {   
        /// <summary>
        /// Faz o cálculo da varíável "soma" iterando sob o indice.
        /// </summary>
        /// <returns>Retorna o valor da varíavel "soma" atualizado.</returns>
        public static int Somar()
        {
            int indice = 13;
            int soma = 0;
            int k = 0;
            
            while (k < indice)
            {
                k += 1;
                soma += k;

                Console.WriteLine($"Valor de K: {k}\n Valor de Soma: {soma}");

                //Soma é igual a 91.
            }

            return soma;
        }
    }
}
