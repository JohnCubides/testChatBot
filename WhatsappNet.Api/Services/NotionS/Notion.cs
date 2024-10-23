using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WhatsappNet.Api.Class;

namespace WhatsappNet.Api.Services.NotionS
{
    public class Notion
    {
        private readonly HttpClient _httpClient;
        private readonly string _notionApikey;
        private readonly string _databaseId;
        public Notion (string apiKey, string databaseId)
        {
            
            _httpClient = new HttpClient ();
            _notionApikey = apiKey;
            _databaseId = databaseId;

            _httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
        }
        public async Task GetAvailableSlots()
        {
            var url = $"https://api.notion.com/v1/databases/{_databaseId}/query";


            var response = await _httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonDocument.Parse(jsonResponse);


            // Procesar los datos para obtener los horarios disponibles
            foreach (var result in data.RootElement.GetProperty("results").EnumerateArray())
            {
                var properties = result.GetProperty("properties");

                // Intentamos obtener la propiedad "Horario"
                if (properties.TryGetProperty("Horario", out var horarioProperty))
                {
                    var horario = horarioProperty.GetProperty("title")[0].GetProperty("text").GetProperty("content").GetString();
                    // Intentamos obtener la propiedad "Ocupado"
                    if (properties.TryGetProperty("Ocupado", out var ocupadoProperty))
                    {
                        var ocupado = ocupadoProperty.GetProperty("checkbox").GetBoolean();

                        if (!ocupado)
                        {
                            Console.WriteLine($"Horario disponible: {horario}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La clave 'Ocupado' no está presente.");
                    }
                }
                else
                {
                    Console.WriteLine("La clave 'Horario' no está presente.");
                }
            }

        }
        public async Task CrearCitaAsync(AgendarCita request)
        {

            string jsonContent = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Asegúrate de que las propiedades sean camelCase
            });

            string url = "https://api.notion.com/v1/pages";
            string notionApiKey = "secret_DksadQNPQmw7brlFNttJzz0reIJfgR7DJimIzWxoTLG";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", notionApiKey);
                httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");

                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                try
                {

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Cita creada exitosamente.");
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode} - {errorContent}");
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine($"Error de HTTP: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error general: {ex.Message}");
                }
            }
        }
        public async Task<List<string>> ObtenerCitasAgendadas()
        {
            string url = $"https://api.notion.com/v1/databases/{_databaseId}/query";

            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsync(url, null);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la solicitud: {response.StatusCode} - {errorContent}");
                    return new List<string>();  // Retorna una lista vacía en caso de error
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                JsonDocument data = JsonDocument.Parse(jsonResponse);

                List<string> citasAgendadas = new List<string>();

                foreach (JsonElement result in data.RootElement.GetProperty("results").EnumerateArray())
                {
                    JsonElement properties = result.GetProperty("properties");

                    if (properties.TryGetProperty("Horario", out JsonElement horarioProperty))
                    {
                        // Extraer el contenido del título "Horario"
                        string? horario = horarioProperty.GetProperty("title")[0]
                                                     .GetProperty("text")
                                                     .GetProperty("content")
                                                     .GetString();

                        // Agregar el horario a la lista de citas agendadas
                        citasAgendadas.Add(horario);
                    }
                }

                return citasAgendadas;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error HTTP: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                throw;
            }
        }
    }
}