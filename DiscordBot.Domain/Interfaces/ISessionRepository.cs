﻿using DiscordBot.Domain.Entities;

namespace DiscordBot.Domain.Interfaces;

public interface ISessionRepository
{
    public IEnumerable<ulong> Get(ulong userId);

    public void Set(ulong userId, ulong voiceId);

    public void Remove(ulong voiceId);
}