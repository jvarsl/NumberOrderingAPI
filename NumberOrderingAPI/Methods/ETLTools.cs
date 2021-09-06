using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace NumberOrderingAPI.Methods
{
    public static class ETLTools
    {
        public static List<BigInteger> StringToBigIntArray(string input)
        {
            var inputValues = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var values = new List<BigInteger>();
            foreach (var item in inputValues)
            {
                var hasParsed = BigInteger.TryParse(item, out BigInteger value);
                if (hasParsed) values.Add(value);
                else throw new ArgumentException($"{item} is not a valid integer");
            }
            return values;
        }

        private static readonly string filePath = "Results/result.txt";

        public static string ReturnFileContent()
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return null;
        }

        public static void WriteIntoFile(string str)
        {
            File.AppendAllText(filePath, $"\n{str}");
        }
        public static void WriteIntoFile(List<BigInteger> list)
        {
            File.WriteAllText(filePath, string.Join(" ", list));
        }

    }
}
