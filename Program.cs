using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, List<char>> dictionary = new Dictionary<string, List<char>>()
        {
            { "1", new List<char> { 'A', 'd' } },
            { "2", new List<char> { 'C', 'B' } }
        };

        var combinations = GenerateCombinations(dictionary);

        foreach (var combination in combinations)
        {
            Console.WriteLine(combination);
        }

        string filePath = @"C:\Users\Polina\Desktop\combinations.json";

        string jsonResult = JsonConvert.SerializeObject(combinations, Formatting.Indented);
        File.WriteAllText(filePath, jsonResult);

        Console.WriteLine($"Файл збережено за шляхом на робочому столi: {filePath}");
    }

    static List<string> GenerateCombinations(Dictionary<string, List<char>> dictionary)
    {
        var result = new List<string>();
        var keys = new List<string>(dictionary.Keys);

        GenerateCombinationsRecursive(dictionary, keys, 0, "", result);
        return result;
    }

    static void GenerateCombinationsRecursive(Dictionary<string, List<char>> dictionary, List<string> keys, int index, string currentCombination, List<string> result)
    {

        if (index == keys.Count)
        {
            result.Add(currentCombination);
            return;
        }

        var key = keys[index];
        var values = dictionary[key];

        foreach (var value in values)
        {
            GenerateCombinationsRecursive(dictionary, keys, index + 1, currentCombination + value, result);
        }
    }
}
