using Microsoft.AspNetCore.Mvc;
using WhatsappNet.Api.Models;
using WhatsappNet.Api.Services;

namespace WhatsappNet.Api.Controllers
{
    [ApiController]
    [Route("api/whatsapp")]
    public class WhatsappController : Controller
    {

        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;

        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
        }

        [HttpGet("test")]
        public async Task<ActionResult> Sample()
        {
            var data = new
            {
                messaging_product = "whatsapp",
                to = "573138617927",
                type = "text",
                text = new
                {
                    body = " Este es un mensaje de prueba "
                }

            };
            
            var result = await _whatsappCloudSendMessage.Execute(data);
            return Ok("Ok sample");
        }

        [HttpGet]
        public IActionResult VerifyToken()
        {
            string AccessToken = "asdsdsdsa";

            var token = Request.Query["hub.verify.token"].ToString();
            var challenge = Request.Query["hub.challenge"].ToString();

            if (challenge != null && token != null && token == AccessToken)
            {
                return Ok(challenge);
            }
            else {
                return BadRequest();
            }
         }

        [HttpPost]
        public async Task<IActionResult> ReceivedMessage( [FromBody] WhatsAppCloudModel body ) {
            try {
                Message Message = body.Entry[0].Changes[0].Value.Messages[0];
                string userNumber = Message.From;
                string userText = GetUserText( Message );
                return Ok("EVENT_RECEIVED");
            } catch (Exception ex) {
                return Ok("EVENT_RECEIVED");
            }
        }

        private string GetUserText(Message message)
        {
            string typeMessage = message.Type;
            string finalMessage = string.Empty;

            if (typeMessage.ToUpper() == "TEXT")
            {
                finalMessage = message.Text.Body;
            }

            if (typeMessage.ToUpper() == "INTERACTIVE")
            {
                string interactiveType = message.Interactive.Type;

                if (interactiveType.ToUpper() == "LIST_REPLY")
                {
                    finalMessage = message.Interactive.List_Reply.Title;
                }

                if (interactiveType.ToUpper() == "BUTTON_REPLY")
                {
                    finalMessage = message.Interactive.Button_Reply.Title;
                }
            }

            return finalMessage;
        } 
    }
}
