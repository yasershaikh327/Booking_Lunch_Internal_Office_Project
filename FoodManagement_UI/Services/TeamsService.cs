using Newtonsoft.Json;
using System.Text;

namespace FoodManagement_UI.Services
{
    public class TeamsService : ITeamsService
    {
        public async Task SendPing()
        {
            using (var httpClient = new HttpClient())
            {
                var webHookUrl = "https://zapcom.webhook.office.com/webhookb2/23c4eea7-5c4e-4d7e-9e5c-a1806bc1b4ba@25ea82b6-dfae-45a3-8712-f925d1b3397d/IncomingWebhook/6078312ac6dc4637969eaf19fd219c18/05ffbea6-d732-455b-b54f-a8e368c1818e";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), webHookUrl))
                {
                    var teamsMessage = new Root()
                    {

                        Title = "Reminder Alert!!!",
                        Text = "Book your lunch between 12 am to 10:30 am after that no booking will be accepted."

                    };

                    var teamsPayload = JsonConvert.SerializeObject(teamsMessage);
                    request.Content = new StringContent(teamsPayload, Encoding.UTF8, "application/json");
                    var response = await httpClient.SendAsync(request);


                }
            }
        }
        private class Root
        {
            public string Title { get; set; }
            public string Text { get; set; }

        }

    }
}
