namespace EmailService
{
    public class EmailAddress
    {
        public EmailAddress(string address, string displayName)
        {
            Address = address;
            DisplayName = displayName;
        }

        public string Address { get; set; }
        public string DisplayName { get; set; }
    }
}
