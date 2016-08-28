namespace M5W2.M5W2.Data
{
    public interface IMail
    {
        string MailTo { get; }
        string Body { get; }
        string Subject { get; }
    }

}
