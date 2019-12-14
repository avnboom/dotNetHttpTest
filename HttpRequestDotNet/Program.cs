using System;
using HttpRequestDotNet.Models;
using HttpRequestDotNet.Services;

namespace HttpRequestDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск программы.");
            
            var request = new AppRequest(){NextString = "NextString", RequestString = "RequestString"};

            var service = new HttpService();

            var resultObject = service.SendAsync("http://testurl/someurl", request.ToString());
            var resultString = resultObject.Result;

            Console.WriteLine("Результат!!!");
            Console.WriteLine(resultString);

            Console.ReadLine();
        }
    }
}
