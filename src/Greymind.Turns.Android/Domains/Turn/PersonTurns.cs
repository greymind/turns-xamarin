﻿using System;

namespace Greymind.Turns.Android
{
    public class PersonTurns
    {
        public string PersonName { get; set; }
        public int TurnsCount { get; set; }
        public DateTime? LatestTurnTimestamp { get; set; }
    }
}