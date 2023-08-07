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
using System.ComponentModel;
using System.Threading.Channels;
using Discord.Commands;
using System.Reflection;

using static DiscordNetTest.InteractionHandler;

namespace DiscordNetTest.Modules
{
    public class GetCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly CommandService command;

        private readonly ulong AdminID = 1137441310161240094;
        private readonly ulong CuratorID = 1137441240644857866;
        private readonly ulong MasterID = 1135160306511921192;
        private readonly ulong ModeratorID = 1137441172848119919;

        [UserCommand("get-admin")]
        public async Task HandlerAdminGetCommand(IUser user)
        {
            await (user as SocketGuildUser).AddRoleAsync(AdminID);

            await RespondAsync($"User {user.Mention} get role <@&{AdminID}>");
        }

        [UserCommand("remove-admin")]
        public async Task HandlerAdminRemoveCommand(IUser user)
        {
            await (user as SocketGuildUser).RemoveRoleAsync(AdminID);

            await RespondAsync($"User {user.Mention} remove role <@&{AdminID}>");
        }

        [UserCommand("get-curator")]
        public async Task HandlerCuratorGetCommand(IUser user)
        {
            await (user as SocketGuildUser).AddRoleAsync(CuratorID);

            await RespondAsync($"User {user.Mention} get role <@&{CuratorID}>");
        }

        [UserCommand("get-test")]
        public async Task HandlerGetTestCommand(IUser user)
        {
            var embed = new EmbedBuilder()
            {
                Color = Color.Green,
                Description = "The test embed"
            };

            await (user as SocketGuildUser).RemoveRoleAsync(CuratorID);

            //await RespondAsync($"User {user.Mention} remove role <@&{CuratorID}>");
            await RespondAsync(user.GetAvatarUrl());
        }

        [SlashCommand("get-role", "Дать ролями")]
        public async Task HandleGetRoleCommand(IUser user, IRole role)
        {
            await (user as SocketGuildUser).AddRoleAsync(role.Id);

            await RespondAsync($"User {user.Mention} get role <@&{role.Id}>");
        }

        [SlashCommand("button-spawner", "Делает кнопочку")]
        public async Task ButtonSpawner()
        {
            var builder = new ComponentBuilder()
                    .WithButton("label", "custom-id");

            await RespondAsync("Here is a button!", components: builder.Build());
        }

        public async Task MyButtonHandler(SocketMessageComponent component)
        {
            switch (component.Data.CustomId)
            {
                case "custom-id":
                    await RespondAsync($"{component.User.Mention} has clicked the button!");
                    break;
            }
        }

        [SlashCommand("remove-role", "Отобрать ролями")]
        public async Task HandleRemoveRoleCommand(IUser user, IRole role)
        {
            await (user as SocketGuildUser).RemoveRoleAsync(role.Id);

            await RespondAsync($"User {user.Mention} remove role <@&{role.Id}>");
        }
    }
}