using NUnit.Core;
using System;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return Name == other.Name
                && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (Name).GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int comparison = Name.CompareTo(other.Name);
            if (comparison != 0)
            {
                return comparison;
            }

            return Id.CompareTo(other.Id);
        }
    }
}
