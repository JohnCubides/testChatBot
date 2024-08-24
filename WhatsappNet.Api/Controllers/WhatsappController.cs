using Microsoft.AspNetCore.Mvc;
using WhatsappNet.Api.Models;
using WhatsappNet.Api.Services;
using WhatsappNet.Api.Util;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WhatsappNet.Api.Controllers
{
    [ApiController]
    [Route("api/whatsapp")]
    public class WhatsappController : Controller
    {

        private readonly IWhatsappCloudSendMessage _whatsappCloudSendMessage;
        private readonly IUtil _util;

        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage, IUtil util)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
            _util = util;
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
            return Ok($"Ok sample {result}");
        }

        [HttpGet]
        //public IActionResult VerifyToken()
        //{
        //    string AccessToken = "asdsdsdsa";

        //    var token = Request.Query["hub.verify.token"].ToString();
        //    var challenge = Request.Query["hub.challenge"].ToString();

        //    if (challenge != null && token != null && token == AccessToken)
        //    {
        //        return Ok(challenge);
        //    }
        //    else {
        //        return BadRequest();
        //    }
        // }

        public IActionResult Webhook([FromQuery] string hub_mode, [FromQuery] string hub_challenge, [FromQuery] string hub_verify_token)
        {
            // Tu Verify Token configurado
            const string verifyToken = "JSADJASDJJASDJAS";

            if (hub_mode == "subscribe" && hub_verify_token == verifyToken)
            {
                // Retorna el challenge proporcionado por WhatsApp
                return Ok(hub_challenge);
            }
            else
            {
                // Retorna un error 403 si el token no coincide
                return StatusCode(403);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReceivedMessage( [FromBody] WhatsAppCloudModel body ) {
            try 
            {
                Message Message = body.Entry[0].Changes[0].Value.Messages[0];
                string userNumber = Message.From;
                string userText = GetUserText( Message );

                object objectMessage;

                switch (userText.ToUpper())
                {
                    case "TEXT":
                        objectMessage = _util.TextMessage("Este es un ejemplo de texto", userNumber);
                        break;

                    case "IMAGE":
                        objectMessage = _util.ImageMessage("https://media.revistagq.com/photos/5ca5f6a77a3aec0df5496c59/4:3/w_1960,h_1470,c_limit/bob_esponja_9564.png", userNumber);
                        break;

                    case "AUDIO":
                        objectMessage = _util.AudioMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/audio_whatsapp.mp3", userNumber);
                        break;

                    case "VIDEO":
                        objectMessage = _util.VideoMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/video_whatsapp.mp4", userNumber);
                        break;

                    case "DOCUMENT":
                        objectMessage = _util.DocumentMessage("https://biostoragecloud.blob.core.windows.net/resource-udemy-whatsapp-node/document_whatsapp.pdf", userNumber);
                        break;

                    case "LOCATION":
                        objectMessage = _util.LocationMessage(userNumber);
                        break;

                    case "BUTTON":
                        objectMessage = _util.ButtonsMessage(userNumber);
                        break;

                    default:
                        objectMessage = _util.TextMessage("Lo siento, no pude entenderte", userNumber);
                        break;
                }


                await _whatsappCloudSendMessage.Execute(objectMessage);
                return Ok("EVENT_RECEIVED");
            } 
            catch (Exception ex) 
            {
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
