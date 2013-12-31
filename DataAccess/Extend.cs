using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class Extend
    {

        public static bool IsUser(this User u)
        {
            return u.Roles.Any(p => p.Name == "用户");
        }
        public static bool IsLeader(this User u)
        {
            return u.Roles.Any(p => p.Name == "组长");
        }
        public static bool IsManager(this User u)
        {
            return u.Roles.Any(p => p.Name == "经理");
        }

        public static User GetLeader(this User u)
        {
            if(u.IsUser())
            {
                return u.Group.GetLeader();
            }
            return null;
        }
        public static User GetManager(this User u)
        {
            if (u.IsUser())
            {
                return u.Group.GetManager();
            }
            return null;
        }


        public static User GetLeader(this Group g)
        {
            return g.Users.First(p => p.IsLeader());
        }

        public static User GetManager(this Group g)
        {
            return g.Users.First(p => p.IsManager());
        }
    }
}
