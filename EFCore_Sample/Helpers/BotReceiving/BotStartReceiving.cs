using Telegram.Bot;
using Telegram.Bot.Polling;

namespace EFCore_Sample.Helpers.BotReceiving
{
    public static class BotStartReceiving
    {
        public static void Execute(ITelegramBotClient bot)
        {
            ReceiverOptions receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                BotHelper.HandleUpdateAsync,
                BotHelper.HandleErrorAsync,
                receiverOptions
            );
        }
    }
}
