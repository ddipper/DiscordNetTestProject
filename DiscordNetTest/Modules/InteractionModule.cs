using Discord.Interactions;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Discord.WebSocket;

namespace DiscordNetTest.Modules
{
    public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly ulong roleID = 865929380266246215;

        [SlashCommand("ping", "Печатает ПИНГ!")]
        public async Task HandlePingCommand()
        {
            await RespondAsync("PONG"); 
        }

        [SlashCommand("components", "Демонстрация меню кнопок")]
        public async Task HanldeComponentCommand()
        {
            var button = new ButtonBuilder()
            {
                Label = "Тестовая кнопочка",
                CustomId = "button",
                Style = ButtonStyle.Primary
            };

            var menu = new SelectMenuBuilder()
            {
                CustomId = "menu",
                Placeholder = "Возможные действия"
            };

            menu.AddOption("Первое действие", "first", "Выполняет 1 действие");
            menu.AddOption("Второе действие", "second", "Выполняет 2 действие");

            var components = new ComponentBuilder();
            components.WithButton(button);
            components.WithSelectMenu(menu);

            await RespondAsync("Выбери действие", components: components.Build());
        }

        [SlashCommand("avatar", "Показывает аватар юзера <3")]
        public async Task HandleAvatarTask(IUser user)
        {
            var embed = new EmbedBuilder()
            {
                Color = Color.Green,
                Title = "You use /avatar",
                Description = "<@" + $"{user.Id}" + ">" + " avatar",
                ImageUrl = user.GetAvatarUrl()
            };

            await ReplyAsync("", false, embed.Build());
            await RespondAsync("");
        }

        [ComponentInteraction("button")]
        public async Task HandleButtonInput()
        {
            await RespondWithModalAsync<DemoModal>("demo_modal");
        }

        [ModalInteraction("demo_modal")]
        public async Task HandleModalInput(DemoModal modal)
        {
            string input = modal.Greeting;
            await RespondAsync(input);
        }

        [UserCommand("role-list")]
        public async Task HandlerUserListCommand(IUser user)
        {
            var roles = (user as SocketGuildUser).Roles;
            string rolesList = $"<@{user.Id}>\n";
            bool first = true;

            foreach (var role in roles)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                rolesList += "<@&" + role.Id + ">" + "\n";
            }

            var embedBuilder = new EmbedBuilder()
            {
                Color = Color.Green,
                Title = $"<@{user.Id}> role list",
                Description = $"{rolesList}"
            };

            await RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
            //await RespondAsync($"User {user.Mention} has the following roles:\n" + rolesList);
        }

        [MessageCommand("msg-command")]
        public async Task HandleMessageCommand(IMessage message)
        {
            await RespondAsync($"Message author is: {message.Author.Username}");
        }
    }

    public class DemoModal : IModal
    {
        public string Title => "Demo Modal";
        [InputLabel("Отправь милое сообщение!")]
        [ModalTextInput("greeting_input", TextInputStyle.Short, placeholder: "Ты очень..", maxLength: 50)]
        public string Greeting { get; set; }
    }
}