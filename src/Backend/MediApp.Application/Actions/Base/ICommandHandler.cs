using MediatR;

namespace MediApp.Application.Actions.Base;

public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>;
    
public interface IQueryableHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>;