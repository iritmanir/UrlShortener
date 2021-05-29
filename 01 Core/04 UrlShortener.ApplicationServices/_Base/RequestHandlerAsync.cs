using System.Threading.Tasks;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Requests;
using UrlShortener.Contracts._Base;

namespace UrlShortener.ApplicationServices._Base
{
    public abstract class RequestHandlerAsync : BaseApplicationService, IRequestHandler
    {
        protected RequestHandlerAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public abstract Task HandleAsync();
    }

    public abstract class RequestHandlerByInAsync<TRequest> : BaseApplicationService, IRequestHandler
        where TRequest : IRequest
    {
        protected RequestHandlerByInAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public abstract Task HandleAsync(TRequest req);
    }

    public abstract class RequestHandlerByOutAsync<TResult> : BaseApplicationService, IRequestHandler
        where TResult : class
    {
        protected RequestHandlerByOutAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public abstract Task<TResult> HandleAsync();
    }

    public abstract class RequestHandlerAsync<TIn, TResult> : BaseApplicationService, IRequestHandler
        where TIn : IRequest
        where TResult : class
    {
        protected RequestHandlerAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public abstract Task<TResult> HandleAsync(TIn req);
    }
}