﻿namespace DiscordBot.VoiceManager.Domain.Bll.Exceptions;

public class OwnerInVoiceException : Exception
{
    public OwnerInVoiceException() : base("The owner of the voice channel is in it")
    {
        
    }
}