open System
open System.IO
open System.Text.Json

let handleQuestion question =
    match question with
    | "hello" -> "Hi there!"
    | "how are you?" -> "I'm just a bot, but thanks for asking!"
    | _ -> "I'm sorry, I didn't understand the question."

[<EntryPoint>]
let main argv =
    let listener = HttpListener()
    listener.Prefixes.Add("http://localhost:8000/")
    listener.Start()

    printfn "Listening for connections..."

    while true do
        let context = listener.GetContext()
        let request = context.Request
        let response = context.Response

        use reader = new StreamReader(request.InputStream)
        let question = reader.ReadToEnd()

        let answer = handleQuestion question

        let responseData = JsonSerializer.Serialize(answer)
        let responseBytes = Encoding.UTF8.GetBytes(responseData)

        response.ContentType <- "application/json"
        response.ContentLength64 <- int64 responseBytes.Length
        response.OutputStream.Write(responseBytes, 0, responseBytes.Length)
        response.Close()

    0
    
