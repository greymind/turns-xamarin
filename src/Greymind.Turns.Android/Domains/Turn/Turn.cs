using System;

namespace Greymind.Turns.Android
{
    public class Turn
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int PersonId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}