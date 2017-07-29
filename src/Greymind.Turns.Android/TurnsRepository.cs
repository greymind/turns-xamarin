using System;
using System.Collections.Generic;
using System.Linq;

namespace Greymind.Turns.Android
{
    public class TurnsRepository
    {
        private List<Activity> activities;
        private List<Group> groups;
        private List<Person> people;
        private List<Turn> turns;

        public Activity[] GetActivities()
        {
            return activities.ToArray();
        }

        public Group[] GetGroups()
        {
            return groups.ToArray();
        }

        public Person[] GetPeople()
        {
            return people.ToArray();
        }

        public Person GetPerson(int id)
        {
            return people
                .Single(p => p.Id == id);
        }

        public Turn[] GetTurnsForActivity(int activityId)
        {
            return turns
                .Where(t => t.ActivityId == activityId)
                .ToArray();
        }

        public void AddNewPerson(string name)
        {
            if (people.Any(p => p.Name == name))
                return;

            var person = new Person
            {
                Id = people.Count,
                Name = name
            };

            people.Add(person);
        }

        public void AddTurnForActivity(int activityId, int personId, DateTime? timestamp = null)
        {
            var turn = new Turn
            {
                Id = turns.Count,
                ActivityId = activityId,
                PersonId = personId,
                Timestamp = timestamp ?? DateTime.UtcNow
            };

            turns.Add(turn);

            var activity = activities.Single(a => a.Id == activityId);

            activity.Turns.Add(turn);
        }

        public void AddMembersToGroup(int groupId, params int[] personIds)
        {
            var people = this.people.Where(p => personIds.Contains(p.Id));

            groups
                .Single(g => g.Id == groupId)
                .Members
                .AddRange(people);
        }

        public void InitializeMockData()
        {
            people = new List<Person>();
            AddNewPerson("Balki");
            AddNewPerson("Mavi");
            AddNewPerson("Martin");
            AddNewPerson("Matko");
            AddNewPerson("Petra");

            groups = new List<Group>()
            {
                new Group{ Id = 0, Name = "Burek" },
                new Group{ Id = 1, Name = "Unicorns" },
            };

            activities = new List<Activity>
            {
                new Activity{ Id = 0, Name = "Coffee", GroupId = 0},
                new Activity{ Id = 1, Name = "Cake", GroupId = 0},
                new Activity{ Id = 2, Name = "McDonald's", GroupId = 1},
            };

            turns = new List<Turn>();

            // Burek
            AddMembersToGroup(0, 0, 1, 2, 3);

            // Unicorns
            AddMembersToGroup(1, 0, 4);

            // Populate group object based on group id
            activities
                .ForEach(a => a.Group = groups.Single(g => g.Id == a.GroupId));

            // Coffee Turns
            AddTurnForActivity(0, 1, new DateTime(2017, 06, 05));
            AddTurnForActivity(0, 2, new DateTime(2017, 06, 16));
            AddTurnForActivity(0, 0, new DateTime(2017, 06, 23));
            AddTurnForActivity(0, 2, new DateTime(2017, 07, 14));
            AddTurnForActivity(0, 3, new DateTime(2017, 07, 19));
            AddTurnForActivity(0, 3, new DateTime(2017, 07, 27));

            // Cake Turns
            AddTurnForActivity(1, 3, new DateTime(2017, 06, 05));
            AddTurnForActivity(1, 1, new DateTime(2017, 06, 16));
            AddTurnForActivity(1, 0, new DateTime(2017, 06, 23));
            AddTurnForActivity(1, 2, new DateTime(2017, 07, 25));

            // McDonald's Turns
            AddTurnForActivity(2, 0, new DateTime(2017, 06, 05));
            AddTurnForActivity(2, 4, new DateTime(2017, 06, 16));
            AddTurnForActivity(2, 0, new DateTime(2017, 06, 23));
            AddTurnForActivity(2, 4, new DateTime(2017, 07, 14));
            AddTurnForActivity(2, 4, new DateTime(2017, 07, 19));
            AddTurnForActivity(2, 0, new DateTime(2017, 07, 24));

            // Sort activities
            activities = activities
                .OrderByDescending(a => a.Turns.Count)
                .ThenByDescending(a => a.LatestTurnTimestamp)
                .ToList();

            // Notes
            // Sort activities by most occurances > most recent turn
            // Sort turns by timestamp desc
            // Get next turn person by getting person with least turns
            //  > oldest turn > random
            // Nav menu
            //  Privacy
            //
        }
    }
}