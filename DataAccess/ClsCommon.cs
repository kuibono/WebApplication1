using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class ClsCommon
    {
        public static User CurrentUser
        {
            get
            {
                using (Model2Container con = new Model2Container())
                {
                    return con.User.First();
                }

            }
        }

        public static Form CurrentForm
        {
            get
            {
                using (Model2Container con = new Model2Container())
                {
                    return con.Form.First();
                }
            }
        }

        public static void SetFlowUser(User user)
        {

        }
    }
}
