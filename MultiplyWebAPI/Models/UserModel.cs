namespace MultiplyWebAPI.Models
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserMessage { get; set; }
        public string AccessToken { get; set; }

    }

    public class UserClinics
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
    }
}
