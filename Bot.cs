using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

class Bot
{
    static string HandleQuestion(string question)
    {
        return question switch
        {
            "cześć" => "Witaj!",
            "jak się masz?" => "Jestem tylko botem, ale dziękuję za zapytanie!",
            _ => "Przepraszam, nie zrozumiałem pytania."
        };
    }

    static void Main(string[] args)
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8000/");
        listener.Start();

        Console.WriteLine("Nasłuchuję połączeń...");

        while (true)
        {
            var context = listener.GetContext();
            var request = context.Request;
            var response = context.Response;

            using (var reader = new StreamReader(request.InputStream))
            {
                var question = reader.ReadToEnd();
                var answer = HandleQuestion(question);
                var responseData = JsonSerializer.Serialize(answer);
                var responseBytes = Encoding.UTF8.GetBytes(responseData);

                response.ContentType = "application/json";
                response.ContentLength64 = responseBytes.Length;
                response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
            }

            response.Close();
        }
    }
}
