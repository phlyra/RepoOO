using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista03
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "...Uma atividade livre, conscientemente tomada como “não - séria” e exterior à vida habitual, " +
                "mas ao mesmo tempo capaz de absorver o jogador de maneira intensa e total. " +
                "É uma atividade desligada de todo e qualquer interesse material, com a qual não se pode obter qualquer lucro, " +
                "praticada dentro de limites espaciais e temporais próprios, segundo uma certa ordem e certas regras." +
                "Promove a formação de grupos sociais com tendência a rodearem-se de segredo e a sublinharem sua diferença " +
                "em relação ao resto do mundo por meio de disfarces ou outros meios semelhantes.";


            #region Resolucao 01, 02 , 04 - Texto COM acentuacao
            Console.WriteLine("************************************************************");
            Console.WriteLine("\n Questões texto COM acentuação. \n");
            Dictionary<string, int> resultado = VerificarQuantidadePalavras(texto);
            foreach (var item in resultado)
            {
                Console.WriteLine($"A palavra [{item.Key}] se repete {item.Value} vez(es)");
            }
            Console.ReadLine();

            Console.WriteLine($"O texto tem {ContarPalavrasUnicasEmTexto(texto)} palavras únicas.");
            Console.ReadLine();
            #endregion

            #region Resolucao 01, 02 , 04 - Texto SEM acentuacao
            Console.WriteLine("************************************************************");
            Console.WriteLine("\n Questões texto SEM acentuação. \n");
            string textoSemAcentos = RemoverAcento(texto);

            Dictionary<string, int> resultado2 = VerificarQuantidadePalavras(textoSemAcentos);
            foreach (var item in resultado2)
            {
                Console.WriteLine($"A palavra [{item.Key}] se repete {item.Value} vez(es)");
            }
            Console.ReadLine();

            Console.WriteLine($"O texto tem {ContarPalavrasUnicasEmTexto(textoSemAcentos)} palavras únicas.");
            Console.ReadLine();
            #endregion

            # region Resolucao 03
            string expressaoCerta = "1+ (5 +3 - (8-5)*4 - ((3+7)*(3-1)))";

            Console.WriteLine($"Certa: {ChecarParentesesExpressao(expressaoCerta)}");
            #endregion
        }

        #region Questao01 e Questao04
        private static string RemoverAcento(string palavra)
        {
            palavra = palavra.Replace("À", "A");
            palavra = palavra.Replace("Â", "A");
            palavra = palavra.Replace("Á", "A");
            palavra = palavra.Replace("Ã", "A");

            palavra = palavra.Replace("à", "a");
            palavra = palavra.Replace("â", "a");
            palavra = palavra.Replace("á", "a");
            palavra = palavra.Replace("ã", "a");

            palavra = palavra.Replace("Ê", "E");
            palavra = palavra.Replace("É", "E");

            palavra = palavra.Replace("ê", "e");
            palavra = palavra.Replace("é", "e");

            palavra = palavra.Replace("Ó", "O");
            palavra = palavra.Replace("Ô", "O");

            palavra = palavra.Replace("ó", "o");
            palavra = palavra.Replace("ô", "o");

            palavra = palavra.Replace("ú", "u");

            return palavra;
        }

        static int ContarPalavrasUnicasEmTexto(string texto)
        {
            HashSet<string> palavrasDoTexto = new HashSet<string>();
            string[] palavras = texto.Split(' ', ',', ';', '.', '"', '-');
            foreach (var item in palavras)
            {
                if (item.Length != 0)
                {
                    palavrasDoTexto.Add(item);
                }
            }
            return palavrasDoTexto.Count();
        }
        #endregion


        #region Questao02
        static Dictionary<string, int> VerificarQuantidadePalavras(string texto)
        {
            Dictionary<string, int> palavrasColetadas = new Dictionary<string, int>();
            string[] palavras = texto.Split(' ', ',', ';', '.');
            foreach (var item in palavras)
            {
                if (item.Length != 0)
                {
                    int count;
                    if (!palavrasColetadas.TryGetValue(item.ToLower(), out count))
                    {
                        count = 0;
                    }
                    palavrasColetadas[item.ToLower()] = count + 1;
                }
            }
            return palavrasColetadas;
        }
        #endregion


        #region Questao03
        static bool ChecarParentesesExpressao(string expressao)
        {
            Stack<char> pilha = new Stack<char>();
            for (int i = 0; i < expressao.Length; i++)
            {
                char caractere = expressao[i];
                if (caractere == '(')
                {
                    pilha.Push(caractere);
                }
                else if (caractere == ')')
                {
                    if (!pilha.Any())
                    {
                        return false;
                    }
                    if (pilha.Pop() != '(')
                    {
                        return false;
                    }
                }
            }
            if (!pilha.Any())
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
