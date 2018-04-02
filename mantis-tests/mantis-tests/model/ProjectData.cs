using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }
        public string State { get; set; }
        public bool GlobalCategory { get; set; }
        public string Enable { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
            //&& State == other.State && Enable == other.Enable && Description == other.Description;
        }

        public override int GetHashCode()
        {
            //return 0;
            return (Name).GetHashCode();
        }

        public override string ToString()
        {
            return "Name=" + Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Name).CompareTo(other.Name);
        }

    }
}