using Twilio.AspNet.Core;
using Twilio.TwiML;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;



namespace Backend.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ReceiveController : TwilioController
    {

        [HttpPost("Send")]
        public TwiMLResult SendReply([FromForm] TwilioSMS request)
        {
            var response = new MessagingResponse();
            response.Message("Teste Robbots! Vamooooo ");
            return TwiML(response);

        }
    }
//     public ActionResult SendSms()
//     {
//         var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
//         var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
//         TwilioClient.Init(accountSid.authToken);

//         var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);
//         var from = new PhoneNumber("12672024057");

//         var message = MessageResource.Create(
//             to: to,
//             from: from,
//             body: "this is a teste");
//         return Content(message.Sid);
//     }

//     public ActionResult ReceiveSms()
//     {
//         var response = new MessagingResponse();
//         response.Message("Teste Robbots ");
//         return TwiML(response);
//     }
// }
