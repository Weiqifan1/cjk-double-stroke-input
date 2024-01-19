using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testStaticFiles;

public class TestRollout: testSetup
{


    [Test]
    public void singleParenTest()
    {
        var test2 = foundExceptions.GetValueOrDefault("留");
        //(35352|35453)25121
        HashSet<string> result = RolloutStrokes.rolloutString(test2.originalCodepoint.rawCodepoint);
    }

    [Test]
    public void IdentifyMissingJundaAndTzaiCharacters()
    {
        var test1 = foundExceptions.GetValueOrDefault("甑");
        //(34|43)25243125111(5|21)54
        
        var test2 = foundExceptions.GetValueOrDefault("留");
        //(35352|35453)25121
        
        var test3 = foundExceptions.GetValueOrDefault("鰠");
        //35251214444544(|4)251214
        
        var test4 = foundExceptions.GetValueOrDefault("鵑");
        //251(2511|3511|3541)32511154444
        
        var test5 = foundExceptions.GetValueOrDefault("枈");
        //(1515|1535|1553|3535|5353)1234
        
        var test6 = foundExceptions.GetValueOrDefault("藣");
        //(122|1212|2112)2522154(2511|3511|3541)(15|35|53)\3
        
        var test7 = foundExceptions.GetValueOrDefault("藦");
        //(122|1212|2112)413(1234|1235)\23112
        
        var test8 = foundExceptions.GetValueOrDefault("譶");
        //(1111251|4111251)\1\1
        
        var test9 = foundExceptions.GetValueOrDefault("鏵");
        //34112431(122|1212|2112)1\1112
        
        
        //HashSet<string> test1 = RolloutStrokes.rolloutString();
        
        Console.WriteLine("test end");
    }
    
}