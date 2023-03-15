using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "F://Lab text.txt";
            List<int> charCounts = new List<int>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    charCounts.Add(line.Length);
                }
            }
            foreach (int count in charCounts)
            {
                Console.WriteLine(count);
            }


            Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();

            dictionary.Add("Ten", new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9});
            dictionary.Add("Even", new List<int>() { 2, 4, 6, 8, 10});
            dictionary.Add("Prime", new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19});
            dictionary.Add("Odd", new List<int>() { 1, 3, 5, 7, 9, 11});

            // Порахувати кількість записів у словнику, значення яких є списком
            int listCount = 0;
            foreach (var item in dictionary)
            {
                if (item.Value is List<int>)
                {
                    listCount++;
                }
            }
            Console.WriteLine("Кількість записів у словнику, значення яких є списком: {0}", listCount);

            // Зберегти словник у JSON файл
            string json = JsonConvert.SerializeObject(dictionary);
            File.WriteAllText("F://Lab2_1JsonSerializerResult.json", json);

            string[] strings = { "hello", "world", "linq", "is", "awesome" };

            string query = strings.Aggregate("Результат:", (first, next) => first + next[0]);
            Console.WriteLine(query);

            Console.ReadKey();
        }
    }
}
