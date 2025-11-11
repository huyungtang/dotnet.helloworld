using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dotnet.Providers;

namespace dotnet.ViewModels
{
  public class WeatherForecast
  {
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //[DisplayName("總結")]
    //[Required(ErrorMessage = "{0} Is Required!")]
    public string? Summary { get; set; }

    //[DisplayName("總結1")]
    //[Required(ErrorMessage = "{0} Is Required!")]
    public string? Summary1 { get; set; }

    public Int64? TempTime { get; set; }

  }

  public record ActionDTO
  {
    [Required]
    public ActionEnum Action { get; set; } = ActionEnum.NONE;
  }

  public record ValidationDTO : ActionDTO
  {
    public string? NameUser { get; set; }

    [Required]
    public string Username { get; set; } = "";

    [RequiredWhenAction(ActionEnum.INSERT | ActionEnum.UPDATE)]
    [JsonConverter(typeof(JsonPasswordProvider))]
    public string? Password { get; set; }

    public IList<Telephone>? TelephoneUser { get; set; }

    public class Telephone
    {
      public string Content { get; set; } = string.Empty;
    }

  }

  [Flags]
  public enum ActionEnum
  {
    NONE = 0,
    INSERT = 1 << 0,
    UPDATE = 1 << 1,
    DELETE = 1 << 2,
  }

  public class RequiredWhenActionAttribute(ActionEnum actions) : RequiredAttribute
  {
    private readonly ActionEnum _actions = actions;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (_actions != ActionEnum.NONE &&
        validationContext.ObjectInstance is ActionDTO act &&
          _actions.HasFlag(act.Action))
      {
        return base.IsValid(value, validationContext);
      }

      return null;
    }
  }
}
