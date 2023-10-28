using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace Backend.Service;

public class Twi
{

    static void Main(string[] args)
    {
        // string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        // string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        string accountSid = "ACf82f18e00e9e016a053cecde8236b0ea";
        string authToken = "8b67690b9f69161af219b5f175debaee";

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
           body: " Vamoo lá",
           from: new Twilio.Types.PhoneNumber("+12294412069"),
           to: new Twilio.Types.PhoneNumber("+5548988745253")
       );

        Console.WriteLine("Mensagem" + message.Sid);
    }
}

//teste
// using System;
// using System.Collections.Generic;
// using Twilio;
// using Twilio.Rest.Api.V2010.Account;
// using Twilio.Types;

// class Example
// {
//   static void Main(string[] args)
//   {
//     var accountSid = "ACf82f18e00e9e016a053cecde8236b0ea";
//     var authToken = "[AuthToken]";
//     TwilioClient.Init(accountSid, authToken);

//     var messageOptions = new CreateMessageOptions(
//       new PhoneNumber("+5548988745253"));
//       messageOptions.From = new PhoneNumber("+12294412069");
//       messageOptions.Body = "pequeno teste";


//     var message = MessageResource.Create(messageOptions);
//     Console.WriteLine(message.Body);
//   }
// }

//resposta

// 201 - CREATED - The request was successful. We created a new resource and the response body contains the representation.
// {
//   "body": "Sent from your Twilio trial account - pequeno teste",
//   "num_segments": "1",
//   "direction": "outbound-api",
//   "from": "+12294412069",
//   "date_updated": "Sat, 28 Oct 2023 13:48:40 +0000",
//   "price": null,
//   "error_message": null,
//   "uri": "/2010-04-01/Accounts/ACf82f18e00e9e016a053cecde8236b0ea/Messages/SM0e87971769ec4d88472b376c5df4488a.json",
//   "account_sid": "ACf82f18e00e9e016a053cecde8236b0ea",
//   "num_media": "0",
//   "to": "+5548988745253",
//   "date_created": "Sat, 28 Oct 2023 13:48:40 +0000",
//   "status": "queued",
//   "sid": "SM0e87971769ec4d88472b376c5df4488a",
//   "date_sent": null,
//   "messaging_service_sid": null,
//   "error_code": null,
//   "price_unit": "USD",
//   "api_version": "2010-04-01",
//   "subresource_uris": {
//     "media": "/2010-04-01/Accounts/ACf82f18e00e9e016a053cecde8236b0ea/Messages/SM0e87971769ec4d88472b376c5df4488a/Media.json"
//   }
// }