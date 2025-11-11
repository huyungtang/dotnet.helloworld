using Grpc.Core;
using Grpc.Core.Interceptors;

namespace dotnet.grpc.v1
{
  public class Test1Interceptor : Interceptor
  {
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
      try
      {
        return await continuation(request, context);
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
