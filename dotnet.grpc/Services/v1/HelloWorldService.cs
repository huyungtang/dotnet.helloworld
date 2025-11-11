using Grpc.Core;

namespace dotnet.grpc.v1
{
  public class HelloWorldService : HelloWorld.HelloWorldBase
  {

    public override Task<HelloWorldReply> Hello(HelloWorldRequest request, ServerCallContext context)
    {
      return Task.FromResult(new HelloWorldReply
      {
        Message = request.Message,
      });
    }

    public override Task<HelloWorldReply> Echo(HelloWorldRequest request, ServerCallContext context)
    {
      return base.Echo(request, context);
    }

  }
}
