namespace console.leetcode.testing
{
  public class TestRemoveDuplicates
  {

    #region Properties ####################################################################################################################

    private readonly Solution _service = new Solution();

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 1 }, 1, new int[] { 1 })]
    [InlineData(new int[] { 1, 1, 1 }, 1, new int[] { 1 })]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4 })]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 4 }, 4, new int[] { 0, 1, 2, 4 })]
    [InlineData(new int[] { -3, -1, -1, 0, 0, 0, 0, 0, 2 }, 4, new int[] { -3, -1, 0, 2 })]
    public void RemoveDuplicates(int[] nums, int k, int[] esp)
    {
      var rtn = _service.RemoveDuplicates(nums);
      Assert.Equal(k, rtn);
      for (var i = 0; i < k; i++)
      {
        Assert.Equal(nums[i], esp[i]);
      }
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}