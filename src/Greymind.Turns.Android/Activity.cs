namespace Greymind.Turns.Android
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}