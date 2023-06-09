﻿namespace DiscordBot.VoiceManager.Domain.Bll.Models;

public record VoiceChannelSettingsModel(
    ulong GuildId,
    ulong Id,
    string? Name,
    int? UsersLimit,
    int? Bitrate
);