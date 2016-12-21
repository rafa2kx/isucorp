using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace IsuCorpRound3.Models.DB
{
    public class ContextFactory: IDbContextFactory<IsucorpContext>
    {

        public IsucorpContext Create()
        {
            return new IsucorpContext();
        }
    }
}