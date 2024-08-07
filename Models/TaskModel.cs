namespace Eisenhower_Web_API.Models
{
    public class TaskModel
    {
        public string? TaskName { get; set; }
        public DateTime TaskTime { get; set; }
        public bool? IsCommented { get; set; }
        public string? Comments { get; set; }

    }
}
