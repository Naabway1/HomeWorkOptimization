using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string text = "Это пример текста. Текст должен быть проанализирован. Это важно.";
        Dictionary<string, int> wordCounts = WordFrequency(text);

        foreach (var item in wordCounts)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }

        Console.ReadKey();
    }

    static Dictionary<string, int> WordFrequency(string text)
    {
        char[] delimiters = { ' ', '.', ',', ';', ':', '?', '!', '-', '\n', '\t' }; //Это разделители слов

        var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower());
        // В данном случае мы разделяем слова в строке, используя массив символов (массив взял из ЧатаГПТ), а также убираем пустые строки из результата
        // Далее, мы усекаем лишние символы(пробелы) в начале и конце строки, а потом переводим все слова в нижний регистр.

        return words.GroupBy(word => word).ToDictionary(g => g.Key, g => g.Count());
        // тут мы возвращаем словарь (Dictionary) результата, группируем одинаковые слова, а потом преобразуем это в словарь, записывая частоту слов и слова.
    }
}