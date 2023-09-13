using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Dictionaries;
using MediatR;

namespace ColoradoBeetle.Application.Contacts.Commands.SendContactEmail;

public class SendContactEmailCommandHandler : IRequestHandler<SendContactEmailCommand> {
    private readonly IEmail _email;
    private readonly IAppSettingsService _appSettings;

    public SendContactEmailCommandHandler(IEmail email, IAppSettingsService appSettings)
    {
        _email = email;
        _appSettings = appSettings;
    }
    public async Task<Unit> Handle(SendContactEmailCommand request,
        CancellationToken cancellationToken) {

        var body = $"Nazwa: {request.Name}.<br/></br>E-mail nadawcy: {request.Email}.<br/></br>" +
            $"Tytuł wiadomości: {request.Title}.<br/></br>Wiadomość: {request.Message}.<br/></br>" +
            $"Wysłao z: ColoradoBeetle.";

        await _email.SendAsync($"Wiadomość z ColoradoBeetle: {request.Title}",
            body, 
            await _appSettings.Get(SettingsDict.AdminEmail));

        return Unit.Value;
    }
}
