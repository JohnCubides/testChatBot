using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WhatsappNet.Api.Models;
using WhatsappNet.Api.Services;
using WhatsappNet.Api.Services.ChatGPT;
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
        private readonly IChatGPTService _chatGPTService;

        public WhatsappController(IWhatsappCloudSendMessage whatsappCloudSendMessage, IUtil util, IChatGPTService chatGPTService)
        {
            _whatsappCloudSendMessage = whatsappCloudSendMessage;
            _util = util;
            _chatGPTService = chatGPTService;
        }

        [HttpGet("test")]
        public async Task<ActionResult> Sample(string number)
        {
            var data = new
            {
                messaging_product = "whatsapp",
                to = $"57{number}",
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

        public IActionResult Webhook([FromQuery(Name = "hub.mode")] string hub_mode, [FromQuery(Name = "hub.challenge")] string hub_challenge, [FromQuery(Name = "hub.verify_token")] string hub_verify_token)
        {
            // Tu Verify Token configurado
            const string verifyToken = "EAF5OwUZABAzUBO3kuck5rJWhRjFOfAGIZAXdnAvs7uSeC2OmOaZC5rEj9SIZBLol5z0ZBN3QEt04hwxZCJOHVNHR93Hov0vRIwxZAH8NzhBbzHkq4f5whHpmReZCntFKZB2e048Qh7gxbsoNzrBnCcOwnWXZCEAL5xpqZCy35TqlDs6cB8sbTimPzruStBYhSjVeSEFepp6do8WfYUOZAX0o893bttbr3VXU8DipwXgsePkZD";

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

                List <object> listObjectMessage = new List <object> ();

                #region sin chatgpt

                //if (userText.ToUpper().Contains("HOLA"))
                //{
                //    var objectMessage = _util.TextMessage("Hola, ¿como te puedo ayudar? 😃", userNumber);
                //    listObjectMessage.Add(objectMessage);

                //    var objectMessage2 = _util.TextMessage("Respondere todas tus preguntas 😃", userNumber);
                //    listObjectMessage.Add(objectMessage2);

                //    var objectMessage3 = _util.ImageMessage("https://media.revistagq.com/photos/5ca5f6a77a3aec0df5496c59/4:3/w_1960,h_1470,c_limit/bob_esponja_9564.png", userNumber);
                //    listObjectMessage.Add(objectMessage3);
                //}
                //else if (userText.ToUpper().Contains("GRACIAS") || userText.ToUpper().Contains("AGRADECID"))
                //{
                //    var objectMessage = _util.TextMessage("Gracias a ti por escribirme. 😃", userNumber);
                //    listObjectMessage.Add(objectMessage);
                //}
                //else if (userText.ToUpper().Contains("ADIOS") || userText.ToUpper().Contains("YA ME VOY"))
                //{
                //    var objectMessage = _util.TextMessage("Adios, Dios te bendiga. 😃", userNumber);
                //    listObjectMessage.Add(objectMessage);
                //}
                //else
                //{
                //    var objectMessage = _util.TextMessage("Lo siento, no puedo entenderte. 😔", userNumber);
                //    listObjectMessage.Add(objectMessage);
                //}

                #endregion

                #region con chatgpt
                var responseChatGPT = await _chatGPTService.Execute(userText);
                var objectMessage = _util.TextMessage(responseChatGPT, userNumber);

                listObjectMessage.Add(objectMessage);

                #endregion

                foreach (var item in listObjectMessage)
                {
                    await _whatsappCloudSendMessage.Execute(item);
                }

                
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
