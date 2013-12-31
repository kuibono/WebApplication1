using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using DataAccess;

namespace DataInitialation
{
    public class V1
    {
        public static bool InstallAll()
        {
            using (Model2Container c = new Model2Container())
            {
                Group g = new Group();
                g.Name = "公司";
                c.AddToGroup(g);

                Group g2 = new Group();
                g2.Name = "财务部";
                g2.Parent = g;
                c.AddToGroup(g2);

                Role r = new Role();
                r.Name = "经理";
                c.AddToRole(r);

                Role r2 = new Role();
                r2.Name = "主管";
                c.AddToRole(r2);

                Role r3 = new Role();
                r3.Name = "组长";
                c.AddToRole(r3);

                Role r4 = new Role();
                r4.Name = "员工";
                c.AddToRole(r4);

                User u = new User();
                u.Group = g;
                u.LoginName = "user1";
                u.Name = "总经理1";
                u.Password = "1";
                u.Roles = new EntityCollection<Role>() { r };
                c.AddToUser(u);

                User u1 = new User();
                u1.Group = g2;
                u1.LoginName = "user1";
                u1.Name = "财务主管1";
                u1.Password = "1";
                u1.Roles = new EntityCollection<Role>() { r2 };
                c.AddToUser(u1);

                User u2 = new User();
                u2.Group = g2;
                u2.LoginName = "user1";
                u2.Name = "财务专员";
                u2.Password = "1";
                u2.Roles = new EntityCollection<Role>() { r4 };
                c.AddToUser(u2);

                DataVersion v = new DataVersion();
                v.Version = 1;
                c.AddToDataVersion(v);

                AddWorlFlow();
                try
                {
                    c.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }


        }

        private static bool AddWorlFlow()
        {
            using(Model2Container c=new Model2Container())
            {
                Form f=new Form();
                f.Name = "请假流程1";
                f.Description = "请假";
                c.AddToForm(f);

                Field f1=new Field();
                f1.Form = f;
                f1.Name = "days";
                f1.Title = "天数";
                f1.Type = 0;
                c.AddToField(f1);

                Field f2 = new Field();
                f2.Form = f;
                f2.Name = "leader";
                f2.Title = "主管意见";
                f2.Type = 1;
                c.AddToField(f2);

                Field f3 = new Field();
                f3.Form = f;
                f3.Name = "manager";
                f3.Title = "总经理意见";
                f3.Type = 1;
                c.AddToField(f3);

                try
                {
                    c.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
