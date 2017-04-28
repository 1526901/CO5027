using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027
{
    public class UserInfoModel
    {
        public UserInformation GetUserInformation(string guId)
        {
            CO5027Entities db = new CO5027Entities();
            UserInformation info = (from x in db.UserInformations where x.GUID == guId select x).FirstOrDefault();

            return info;
        }

        public void InsertUserInformation(UserInformation info)
        {
            CO5027Entities db = new CO5027Entities();
            db.UserInformations.Add(info);
            db.SaveChanges();
        }
    }
}