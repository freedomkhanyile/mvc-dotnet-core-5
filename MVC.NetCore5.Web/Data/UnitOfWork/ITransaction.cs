using System;

namespace MVC.NetCore5.Web.Data.UnitOfWork
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
