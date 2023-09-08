using EFCore_Sample.Helpers.BotReceiving;
using EFCore_Sample.Models;
using Newtonsoft.Json;
using Quartz;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace EFCore_Sample.Job
{
    [DisallowConcurrentExecution]
    public class CB_Process : IJob
    {
        ITelegramBotClient _bot { get; set; }
        public CB_Process(ITelegramBotClient bot) 
        { 
            this._bot = bot;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                int id;
                var data = LoadJson();

                int maxId = data.Lines.Count();

                Random random = new Random();
                id = random.Next(maxId);

                foreach(var el in ConfigurationApp.BotId.Distinct())
                {
                    ITelegramBotClient bot = new TelegramBotClient(ConfigurationApp.TGToken);
                    var t = await _bot.SendTextMessageAsync(el, data.Lines[id].Phrase);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private Root LoadJson()
        {
            Root root;
            using (StreamReader r = new StreamReader("Phrases.json", Encoding.GetEncoding("windows-1251")))//Encoding.GetEncoding("x-mac-ukrainian")))
            {
                string json = r.ReadToEnd();
                root = JsonConvert.DeserializeObject<Root>(json);
            }
            return root;
        }
    }
}
