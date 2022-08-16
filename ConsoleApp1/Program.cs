using Newtonsoft.Json;
using ConsoleApp1;

class Program
{
    public static void Main(string[] args)
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
                //string jsonString = JsonConvert.SerializeObject(messageTask.Result);

                var dataResultObject = JsonConvert.DeserializeObject<DataResult>(messageTask.Result);

                foreach (var item in dataResultObject.data)
                {
                    Bank bank = new();
                    Console.WriteLine("Bank Id: " + item.bankId);
                    Console.WriteLine("Bank Name: " + item.bankName);
                    Console.WriteLine("Bank Status: " + item.status + "\n");
                    
                    bank.bankId = item.bankId;
                    bank.bankName = item.bankName;
                    bank.status = item.status;
                }

                if (dataResultObject.message != null)
                {
                    Console.WriteLine("Bank Message: " + dataResultObject.message);
                }
                Console.WriteLine("Bank Success Status: " + dataResultObject.success);
            }
        }
    }
}