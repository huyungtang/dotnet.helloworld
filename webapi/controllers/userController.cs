using Microsoft.AspNetCore.Mvc;
using webapi.core;
using webapi.interfaces;
using webapi.models;
using webapi.Providers;
using webapi.services;

namespace webapi.controllers
{
  public sealed class UserController(
    UserService userService,
    IConfigService configService,
    ICarService carService)
    : BaseController
  {

    #region Properties ####################################################################################################################

    private readonly UserService _userService = userService;
    private readonly IConfigService _configService = configService;
    private readonly ICarService _carService = carService;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    [HttpGet("{id}")]
    public async Task<UserEntity?> Get(long id)
    {
      var user = await _userService.GetByIdAsync(id);

      Console.WriteLine($"---------- Current Number: {SingletonProvider.Context.Current()}");
      Console.WriteLine($"---------- Is Production: {_configService.IsProduction}");
      _carService.Accele<ISedanCar>();
      _carService.Break<ISedanCar>();
      _carService.Accele<ISUVCar>();
      _carService.Break<ISUVCar>();

      //TODO: Handle not found

      return user;
    }

    [HttpPost()]
    public async Task<UserEntity> Create([FromBody] UserEntity? user)
    {
      if (user != null)
      {
        await _userService.CreateAsync(user);
      }

      return new UserEntity { Id = user?.Id ?? 0 };
    }

    [HttpPut()]
    public async Task<long> Update([FromBody] UserEntity user)
    {
      await _userService.UpdateAsync(user);

      return user.Id;
    }

    [HttpPost("list")]
    public bool List()
    {

      return false;
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}