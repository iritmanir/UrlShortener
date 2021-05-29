using UrlShortener.Contracts._Base;

namespace UrlShortener.ApplicationServices._Base
{
    public abstract class BaseApplicationService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseApplicationService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}