using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SendController : ControllerBase
{

    string accountSid = "ACf82f18e00e9e016a053cecde8236b0ea";
    string authToken = "8b67690b9f69161af219b5f175debaee";

    [HttpPost("SendText")]
    public ActionResult SendText(string phoneNumber)
    {
        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
                  body: "c-2222",
                  from: new Twilio.Types.PhoneNumber("+12294412069"),
                  to: new Twilio.Types.PhoneNumber("+55 " + phoneNumber)
              );
            return StatusCode(200, new {message = message.Sid});
    }

}
