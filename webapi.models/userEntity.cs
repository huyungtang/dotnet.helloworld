using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webapi.core;

namespace webapi.models
{
  [Table(name: "user")]
  public class UserEntity : Entity, IIdentifiable<long>, ICreatedState, IDeletedState
  {

    #region Properties ####################################################################################################################

    [Key]
    [Column(name: "id", TypeName = "BIGINT")]
    public long Id { get; set; }

    [Column(name: "username", TypeName = "VARCHAR(90)")]
    public string Username { get; set; } = "";

    [Column(name: "creater_id", TypeName = "BIGINT")]
    public long CreaterId { get; set; } = 0;

    [Column(name: "created_at", TypeName = "BIGINT")]
    public long CreatedAt { get; set; } = 0;

    [Column(name: "is_deleted", TypeName = "BOOLEAN")]
    public bool IsDeleted { get; set; } = false;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################



    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}
