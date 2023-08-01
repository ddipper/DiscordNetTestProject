using Discord.Interactions;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DiscordNetTest.Modules
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("ping", "Печатает ПИНГ!")]
        public async Task HandlePingCommand()
        {
            await RespondAsync("PING!"); 
        }

        [SlashCommand("components", "Демонстрация меню кнопок")]
        public async Task HanldeComponentCommand()
        {
            var button = new ButtonBuilder()
            {
                //Label = "Button";

            };
        }
    }
}
