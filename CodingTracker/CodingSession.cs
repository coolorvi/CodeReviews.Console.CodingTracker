namespace CodingTracker
{
    public class CodingSession
    {
        public int ID { get; set; }
        public string StartTime { get; set; } = "";
        public string EndTime { get; set; } = "";
        public string Duration { get; set; } = "";
        public override string ToString()
        {
            return $"{ID}. {StartTime: dd.MM.yyyy HH:mm} → {EndTime: dd.MM.yyyy HH:mm} ({Duration})";
        }
    }
}
