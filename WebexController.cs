using System;

[Route("api/webex")]
[ApiController]
public class WebexController : ControllerBase
{
    private readonly WebexAdapter _adapter;
    private readonly IBot _bot;

    public WebexController(WebexAdapter adapter, IBot bot)
    {
        _adapter = adapter;
        _bot = bot;
    }

    [HttpPost]
    public async Task PostAsync()
    {
        // Delegate the processing of the HTTP POST to the adapter.
        // The adapter will invoke the bot.
        await _adapter.ProcessAsync(Request, Response, _bot, default(CancellationToken));
    }
}
