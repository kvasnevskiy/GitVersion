﻿using GitVersion.Infrastructure;

namespace GitVersion.Wix;

[Command("wix", typeof(OutputSettings), "Outputs version to wix file")]
public class OutputWixCommand : Command<OutputWixSettings>
{
    private readonly ILogger logger;
    private readonly IService service;

    public OutputWixCommand(ILogger logger, IService service)
    {
        this.logger = logger;
        this.service = service;
    }

    public override Task<int> InvokeAsync(OutputWixSettings settings)
    {
        var value = service.Call();
        logger.LogInformation($"Command : 'output wix', LogFile : '{settings.LogFile}', WorkDir : '{settings.OutputDir}', InputFile: '{settings.InputFile}', WixFile: '{settings.WixFile}' ");
        return Task.FromResult(value);
    }
}