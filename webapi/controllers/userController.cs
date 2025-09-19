using Microsoft.AspNetCore.Mvc;
using webapi.models;
using webapi.services;

namespace webapi.controllers
{
  public class UserController(UserService userService) : BaseController
  {

    #region Properties ####################################################################################################################

    private readonly UserService _userService = userService;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    [HttpGet("{id}")]
    public async Task<UserEntity?> Get(long id)
    {
      var user = await _userService.GetByIdAsync(id);

      //TODO: Handle not found

      return user;
    }

    [HttpPost()]
    public async Task<long> Create([FromBody] UserEntity user)
    {
      await _userService.CreateAsync(user);

      return user.Id;
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