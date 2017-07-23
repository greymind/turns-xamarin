using System.Collections.Generic;
using System.Linq;

namespace Greymind.Turns.Android
{
    public class TurnsRepository
    {
        private List<Activity> activities;
        private List<Group> groups;
        private List<Person> people;

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
            people = new List<Person>
            {
                new Person{ Id = 0, Name = "Balki" },
                new Person{ Id = 1, Name = "Mavi" },
                new Person{ Id = 2, Name = "Martin" },
                new Person{ Id = 3, Name = "Matko" },
                new Person{ Id = 4, Name = "Petra" },
            };

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

            AddMembersToGroup(0, 0, 1, 2, 3);
            AddMembersToGroup(1, 0, 4);

            // Populate group object based on group id
            activities
                .ForEach(a => a.Group = groups.Single(g => g.Id == a.GroupId));
        }
    }
}