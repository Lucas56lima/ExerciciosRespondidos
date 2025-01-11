namespace Service.Services
{
    public class Exercício_5___Invertendo_Caracter
    {
        /// <summary>
        /// Inverte os caracteres de uma string.
        /// </summary>
        /// <param name="word">String informada</param>
        /// <returns>Retorna uma string invertida.</returns>
        public static string InvertCharacter(string word)
        {
            string invertWord = string.Empty;
            if (word == null ||  word.Trim().Length == 0)
            {
                Console.WriteLine($"Palavra não informada");
                return invertWord;
            }

            for (int i = 0; i < word.Length; i++)
            {
                invertWord += word[word.Length - i - 1]; // Corrigido
            }
            Console.WriteLine($"Palavra invertida: {invertWord}");
            return invertWord;
           
        }

    }
}
