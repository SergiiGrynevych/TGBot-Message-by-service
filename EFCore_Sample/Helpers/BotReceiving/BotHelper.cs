using EFCore_Sample.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EFCore_Sample.Helpers.BotReceiving
{
    public class BotHelper
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                ConfigurationApp.BotId.Add(update.Message.Chat.Id.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(ConfigurationApp.superId, exception.Message);
        }
    }
}
