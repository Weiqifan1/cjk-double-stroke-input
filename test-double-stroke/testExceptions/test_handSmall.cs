namespace test_double_stroke.testExceptions;
using double_stroke.projectFolder.StaticFileMaps;

public class test_handSmall : testSetup
{
    //TODO: change initials to be a list and ids matches to be a list
    
    [Test]
    public void handSmall_ThatShouldHaveBeenThere()
    {
        var mydict = foundExceptions;
        
        var handFull =
            exceptionHelper.FiltDict_hasCodeNotIds(
                mydict, 
                new() {"121"},
                new()
                {
                    new UnicodeCharacter("十"),
                    new UnicodeCharacter("土"),
                    new UnicodeCharacter("扌")
                });
        var handfullClean = exceptionHelper.displayDict(handFull);
        
        //执 is not split
        var smallhandEdge = mydict[new UnicodeCharacter("执")];
        
        //handfullClean have been looked through and no characters seem missing
        Assert.AreEqual(69, handfullClean.Count, "Result should be 4");
    }
    
    
}