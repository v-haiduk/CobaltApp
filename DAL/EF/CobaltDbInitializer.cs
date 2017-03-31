﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class CobaltDbInitializer: DropCreateDatabaseAlways<CobaltContext>
    {
        protected override void Seed(CobaltContext context)
        {
            context.UserAccounts.Add(new UserAccount {Name = "admin", HashOfPassword = "???"});
            context.UserAccounts.Add(new UserAccount {Name = "sam", HashOfPassword = "???" });

            base.Seed(context);
        }
    }
}