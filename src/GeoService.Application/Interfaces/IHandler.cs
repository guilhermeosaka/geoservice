namespace GeoService.Application.Interfaces;

public interface IHandler<in TRequest>
{
    Task Handle(TRequest request, CancellationToken ct);
}

public interface IHandler<in TRequest, TResult>
{
    Task<TResult> Handle(TRequest request, CancellationToken ct);
}