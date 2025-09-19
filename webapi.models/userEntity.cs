using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using webapi.core;
using webapi.core.models;

namespace webapi.models
{
  [Table(name: "user")]
  public class UserEntity : Entity, IIdentifiable<long>, IDeletedState
  {

    #region Properties ####################################################################################################################

    [Key]
    public long Id { get; set; }

    [Column(name: "username", TypeName = "VARCHAR(90)")]
    public required string Username { get; set; } = "";

    [Column(name: "is_deleted", TypeName = "BOOLEAN")]
    public required bool IsDeleted { get; set; } = false;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################



    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}
