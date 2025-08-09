namespace SignalRChat_Server.Models
{
    public sealed class User
    {
        public User()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Avatar { get; set; }= string.Empty;
        public string Status { get; set; }= string.Empty;
        


    }
}
