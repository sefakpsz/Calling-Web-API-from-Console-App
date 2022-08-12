using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;
using ConsoleApp1;
using JsonSerializer = System.Text.Json.JsonSerializer;

class Result
{
    public static void plusMinus(List<int> arr)
    {
        decimal positive = 0, negative = 0, zero = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] > 0)
            {
                positive++;
            }
            else if (arr[i] < 0)
            {
                negative++;
            }
            else
            {
                zero++;
            }
        }
        positive /= arr.Count;
        negative /= arr.Count;
        zero /= arr.Count;

        Console.WriteLine($"{positive}\n{negative}\n{zero}");
    }
}


class Solution
{
    public static void Main(string[] args)
    {
        CallWebAPIAsync()
        .Wait();

        //var arr = new List<int> { -4, 3, -9, 0, 4, 1 };

        //Result.plusMinus(arr);
    }
    static async Task CallWebAPIAsync()
    {
        using HttpClient client = new HttpClient();
        Console.WriteLine("Calling WebAPI...");


        var responseTask = client.GetAsync("https://localhost:44348/api/Bank/GetAllBankList");
        responseTask.Wait();
        if (responseTask.IsCompleted)
        {
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var messageTask = result.Content.ReadAsStringAsync();
                messageTask.Wait();
                string jsonString = JsonConvert.SerializeObject(messageTask.Result);

                var json = JsonConvert.DeserializeObject(jsonString);

                Console.WriteLine(json);
                Console.WriteLine("Banks from WebAPI: " + messageTask.Result);
                Console.ReadLine();
            }
        }
        //string jsonArray = "[{\"BankId\": 101,\"BankName\":\"IT\" }, {\"BankId\": 102,\"BankName\":\"Accounts\" }]";

        //var banks = JsonSerializer.Deserialize<IList<Bank>>(jsonArray);

        //foreach (var bank in banks)
        //{
        //    Console.WriteLine("Department Id is: {0}", bank.BankId);
        //    Console.WriteLine("Department Name is: {0}", bank.BankName);
        //}
    }
}