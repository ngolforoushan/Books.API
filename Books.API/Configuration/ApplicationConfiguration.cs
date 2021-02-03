namespace Books.API.Configuration
{
    public partial class ApplicationConfiguration
    {
        public ApplicationConfiguration()
        {
            Logging = new Logging();
            ConnectionStrings = new ConnectionStrings();
        }

        public Logging Logging { get; }
        public ConnectionStrings ConnectionStrings { get; }
    }

    public partial class ConnectionStrings
    {
        public ConnectionStrings()
        {
            BooksDbConnectionString = string.Empty;
        }
        public string BooksDbConnectionString { get; set; }
    }

    public partial class Logging
    {
        public LogLevel? LogLevel { get; set; }
    }

    public partial class LogLevel
    {
        public string? Default { get; set; }
        public string? Microsoft { get; set; }
        public string? MicrosoftHostingLifetime { get; set; }
    }
}
