using System.Text.Json.Serialization;

namespace MultiplyWebAPI.Models
{
    public class AccountCollectionData
    {
        public string AccountDate { get; set; }
        [JsonIgnore]
        public long ClinicId { get; set; }
        public string Clinic { get; set; }
        public string ClinicLocation { get; set; }
        [JsonIgnore]
        public long BranchId { get; set; }
        public string Branch { get; set; }
        public List<AccountData> AccountData { get; set; }
    }

    public class AccountData
    {
        public string AccountHead { get; set; }
        public double Amount { get; set; }
    }
}
