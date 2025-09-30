namespace Lab4.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string to, string subject, string body);
        bool IsEmailServiceAvailable();
    }
}
