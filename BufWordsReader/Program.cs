using System;
using System.Collections.Generic;
using System.Linq;

namespace BufWordsReader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Input 'help' to getting a help.");

            ReadCommand();
        }

        /// <summary>
        /// Считывает команду и определяет действие
        /// </summary>
        static void ReadCommand()
        {
            Console.Write("\n\n >  ");
            string input = Console.ReadLine().Trim();//считывание строки команды

            switch (input)
            {
                case "help":
                    Console.WriteLine("\nThis program is getting text from buffer and printing by ascending first 1000 words without symbols as '.', ',', ';', ':', '?', '!' then.");
                    Console.WriteLine("'run' - command for run program.");
                    Console.WriteLine("'exit' - command for exit program.");
                    break;

                case "run":
                    GetBufferWords();
                    break;

                case "exit":
                    return;
            }

            ReadCommand();
        }

        /// <summary>
        /// Считывет текст из буфера и выводит по возрастанию первую 1000 слов
        /// </summary>
        static void GetBufferWords()
        {
            string bufText= System.Windows.Forms.Clipboard.GetText();

            if (bufText == null || bufText == "")
            {
                Console.WriteLine("\nBuffer is empty");
                return;
            }

            bufText = bufText.ToLower();

            for (int i=bufText.Length-1; i>=0; i--)
            {
                char s = bufText[i];
                if (s == '.' || s == ',' || s == ';' || s == ':' || s == '?' || s == '!')
                {
                    bufText = bufText.Remove(i, 1);
                }
            }

            List<string> originWords = new List<string>();
            originWords = bufText.Split(' ').ToList<string>();

            for (int i= originWords.Count-1; i>=0; i--)
            {
                originWords[i] = originWords[i].Trim();
                if (originWords[i] == "")
                    originWords.RemoveAt(i);
            }

            List<string> mainWords= new List<string>();

            for (int i = 0; i < originWords.Count; i++)
            {
                if(!mainWords.Contains(originWords[i]))
                {
                    mainWords.Add(originWords[i]);
                }
            }

            mainWords.Sort();

            if(mainWords.Count<1000)
            {
                Console.Write("\n");
                for (int i = 0; i < mainWords.Count; i++)
                {
                    Console.WriteLine(mainWords[i]);
                }
            }
            else
            {
                Console.Write("\n");
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(mainWords[i]);
                }
            }
        }
    }
}
