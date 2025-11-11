using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace dotnet.Providers
{

  public class EnumModelBinder : IModelBinder
  {
    public Task BindModelAsync(ModelBindingContext context)
    {
      ArgumentNullException.ThrowIfNull(context);

      if (!context.ModelType.IsEnum)
      {
        return Task.CompletedTask;
      }

      var valueResult = context.ValueProvider.GetValue(context.ModelName);
      if (valueResult == ValueProviderResult.None)
      {
        return Task.CompletedTask;
      }

      context.ModelState.SetModelValue(context.ModelName, valueResult);

      if (string.IsNullOrEmpty(valueResult.FirstValue))
      {
        return Task.CompletedTask;
      }

      try
      {
        var enumValue = Enum.Parse(context.ModelType, valueResult.FirstValue, true);
        context.Result = ModelBindingResult.Success(enumValue);
      }
      catch { }

      return Task.CompletedTask;
    }
  }

  public class ModelBinderProvider : IModelBinderProvider
  {
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
      ArgumentNullException.ThrowIfNull(context);

      if (context.Metadata.IsEnum)
      {
        return new BinderTypeModelBinder(typeof(EnumModelBinder));
      }

      return null;
    }
  }

}