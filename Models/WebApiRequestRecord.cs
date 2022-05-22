
namespace Models
{
    public class WebApiRequestRecord
    {
        public string RecordId { get; set; }
        public InputRecordData Data { get; set; } = new InputRecordData();
    }
}