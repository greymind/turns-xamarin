using System;
using System.Collections.Generic;
using System.Linq;

namespace Greymind.Turns.Android
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<Turn> Turns { get; set; }

        public DateTime LatestTurnTimestamp
            => Turns.Max(t => t.Timestamp);

        public string GetNextTurnPersonName()
        {
            var turnsByPerson =
                from person in Group.Members
                join turn in Turns on person.Id equals turn.PersonId into turns
                select new
                {
                    Person = person,
                    NumberOfTurns = turns.Count(),
                    LatestTurnTimestamp = turns.Any()
                        ? turns.Max(t => t.Timestamp)
                        : (DateTime?)null
                };

            return turnsByPerson
                .OrderBy(t => t.NumberOfTurns)
                .ThenBy(t => t.LatestTurnTimestamp)
                .First()
                .Person
                .Name;
        }

        public Activity()
        {
            Turns = new List<Turn>();
        }
    }
}