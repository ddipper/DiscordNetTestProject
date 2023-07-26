﻿using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;

namespace DiscordNetTest
{
    public class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync()
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig
                        {
                            GatewayIntents = GatewayIntents.AllUnprivileged,
                            AlwaysDownloadUsers = true
                        })))
                .Build();
            await RunAsync(host);
        }

        public async Task RunAsync(IHost host)
        {
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var _client = provider.GetRequiredService<DiscordSocketClient>();

            _client.Log += async (LogMessage msg) => { Console.WriteLine(msg.Message); };

            _client.Ready += async () =>
            {
                Console.WriteLine("Bot ready!");
            };
            
            var token = File.ReadAllText(@"D:\token.txt");
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}