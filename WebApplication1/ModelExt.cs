using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public partial class User : EntityObject
    {
        public User GetLeader()
        {
            return this.Group.Users.First(p => p.Roles.Any(x => x.Name == "组长"));
        }
        public User GetManager()
        {
            return this.Group.Users.First(p => p.Roles.Any(x => x.Name == "经理"));
        }
    }
}