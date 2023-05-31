namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IEmail {
    Task SendAsync(string subject, string body, string to, string attachmentPath = null);
    Task Update(IAppSettingsService appSettingsService);
}
