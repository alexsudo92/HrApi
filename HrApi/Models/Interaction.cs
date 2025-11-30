using HrApi.Models.Enums;

namespace HrApi.Models
{
    public class Interaction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public InteractionType Type { get; set; }
        public string Message { get; set; }
    }
}
