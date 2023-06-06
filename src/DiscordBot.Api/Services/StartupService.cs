﻿using Discord;
using Discord.Net;
using Discord.WebSocket;
using DiscordBot.Api.Extensions;
using Newtonsoft.Json;

namespace DiscordBot.Api.Services;

public sealed class StartupService
{
    private readonly DiscordSocketClient _client;
    private readonly IConfiguration _configuration;
    private readonly ILogger<StartupService> _logger;

    public StartupService(DiscordSocketClient client, IConfiguration configuration, ILogger<StartupService> logger)
    {
        _client = client;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task RunAsync()
    {
        await _client.LoginAsync(TokenType.Bot, _configuration["Discord:Token"]);
        await _client.StartAsync();

        _client.Ready += async () =>
        {
            var command = new SlashCommandBuilder().AddVoiceSettingsCommand();
            var adminCommand = new SlashCommandBuilder().AddAdminCommand();
            try
            {
                await _client.Rest.CreateGuildCommand(command.Build(), 734819128916967494);
                await _client.Rest.CreateGuildCommand(adminCommand.Build(), 734819128916967494);
            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                _logger.LogError(json);
            }
        };
    }
}