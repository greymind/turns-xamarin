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

        public void InitializeMockData()
        {
            people = new List<Person>
            {
                new Person{ Id = 0, Name = "Balki" },
                new Person{ Id = 1, Name = "Mavi" },
                new Person{ Id = 2, Name = "Martin" },
                new Person{ Id = 3, Name = "Matko" },
            };

            groups = new List<Group>()
            {
                new Group{ Id = 0, Name = "Burek" },
            };

            activities = new List<Activity>
            {
                new Activity{ Id = 0, Name = "Coffee", GroupId = 0},
                new Activity{ Id = 1, Name = "Cake", GroupId = 0},
            };

            // Add members to group
            groups
                .Single(g => g.Name == "Burek")
                .Members
                .AddRange(people);

            // Populate group object based on group id
            activities
                .ForEach(a => a.Group = groups.Single(g => g.Id == a.GroupId));
        }
    }
}