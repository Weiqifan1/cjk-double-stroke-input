namespace test_double_stroke.testIds;

public class test_ids: testSetup
{
    
    [Test]
    public void handFull_ThatShouldHaveBeenThere()
    {
        var mydict = foundExceptions;

        Assert.AreEqual(69, 5+4, "Result should be 4");
    }
}