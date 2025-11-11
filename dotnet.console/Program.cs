// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations.Schema;
using dotnet.helloworld;

Console.WriteLine("Hello, World!");
string action = ActionEnum.Create.ToString();
Console.WriteLine(action);

var actEnum = Enum.Parse<ActionEnum>(action);
Console.WriteLine(actEnum);

Console.ReadLine();

namespace dotnet.helloworld
{
  public class ActionDto
  {
    [Column("action")]
    public ActionEnum Action { get; set; }
  }

  public enum ActionEnum
  {
    None = 0,
    Create = 1 << 0,
    Update = 1 << 1,
    Delete = 1 << 2,
  }
}