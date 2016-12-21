using System.Data.Entity.Infrastructure;

namespace IsucorpDataAccess.Models.DB
{
    public class ContextFactory: IDbContextFactory<IsucorpContext>
    {

        public IsucorpContext Create()
        {
            return new IsucorpContext();
        }
    }
}