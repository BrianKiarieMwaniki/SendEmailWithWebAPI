namespace SendEmailWithWebAPI.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}