namespace console.leetcode.testing
{
  public class TestLongestCommonPrefix
  {

    #region Properties ####################################################################################################################

    private readonly Solution _service = new Solution();

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    [Theory]
    [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new string[] { "dog", "racecar", "car" }, "")]
    public void LongestCommonPrefix(string[] strs, string prefix)
    {
      Assert.Equal(_service.LongestCommonPrefix(strs), prefix);
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}