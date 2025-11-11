using Grpc.Core;

namespace dotnet.grpc
{
  public class GreeterService : Greeter.GreeterBase
  {

    public override Task<HelloReply> SayHello(
      HelloRequest request,
      ServerCallContext context)
    {
      return Task.FromResult(new HelloReply
      {
        Message = $"Hello {request.Name}",
        MessageHello = request.Reply?.MessageHello ?? "empty message",
      });
    }


    public override async Task SayHelloStream(
      HelloRequest request,
      IServerStreamWriter<HelloReply>
      responseStream, ServerCallContext context)
    {
      for (int i = 0; i < 5; i++)
      {
        await Task.Delay(1000);
        var reply = new HelloReply
        {
          Message = $"Hello {request.Name} from server stream, message {i + 1}",
        };
        await responseStream.WriteAsync(reply);
      }
    }

  }
}
