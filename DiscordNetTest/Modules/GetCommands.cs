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
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace DiscordNetTest.Modules
{
    public class GetCommands : InteractionModuleBase<SocketInteractionContext>
    {
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

    }
}
