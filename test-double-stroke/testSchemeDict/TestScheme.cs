using double_stroke.projectFolder.StaticFileMaps;

namespace test_double_stroke.testSchemeDict;

public class TestScheme: testSetup
{
    private List<SchemeRecord> schemeRecList;
    
    [OneTimeSetUp]
    public void Setup()
    {
        schemeRecList = generateTestSchemeDict
            .schemeFromDictionary(foundExceptions, junda, tzai);
    }
    
    [Test]
    public void handNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "手");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void handCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "扔");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"sq", "sk"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fdh", "fat"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"扌"}));
        Assert.IsTrue(hand.rawCodepoint == "121(35|53)");
        Assert.IsTrue(hand.jundaNumber == 8045);
        Assert.IsTrue(hand.tzaiNumber == 931);
    }
    
    [Test]
    public void eyeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "目");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"d"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngg"}));
        Assert.IsTrue(hand.exceptionLetter == "d");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.IsTrue(hand.rawCodepoint == "25111");
        Assert.IsTrue(hand.jundaNumber == 180827);
        Assert.IsTrue(hand.tzaiNumber == 157966);
        
    }
    
    [Test]
    public void eyeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "眤");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"dhth", "dheh", "dhqt"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"ngada", "ngadq", "ngadk"}));
        Assert.IsTrue(hand.exceptionLetter == "d");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"目"}));
        Assert.IsTrue(hand.rawCodepoint == "25111513(15|35|53)");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void footNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "足");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"fnfw"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfdy"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"足"}));
        Assert.IsTrue(hand.rawCodepoint == "2512134");
        Assert.IsTrue(hand.jundaNumber == 77385);
        Assert.IsTrue(hand.tzaiNumber == 47014);
    }
    
    [Test]
    public void footCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "趵");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"fnfh", "fnfl"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfaqg", "nfaqy", "nffdh", "nffdl"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.IsTrue(hand.rawCodepoint == "251(215|2121)35(1|4)");
        Assert.IsTrue(hand.jundaNumber == 53);
        Assert.IsTrue(hand.tzaiNumber == 8);
    }
    
    
    [Test]
    public void footAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𧾷");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"f"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfa", "nffg"}));
        Assert.IsTrue(hand.exceptionLetter == "f");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"𧾷"}));
        Assert.IsTrue(hand.rawCodepoint == "251(215|2121)");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void insectNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虫");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"j"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfs"}));
        Assert.IsTrue(hand.exceptionLetter == "j");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.IsTrue(hand.rawCodepoint == "251214");
        Assert.IsTrue(hand.jundaNumber == 18909);
        Assert.IsTrue(hand.tzaiNumber == 4789);
    }
    
    [Test]
    public void insectCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "虾");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"jfy"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"nfsfy"}));
        Assert.IsTrue(hand.exceptionLetter == "j");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"虫"}));
        Assert.IsTrue(hand.rawCodepoint == "251214124");
        Assert.IsTrue(hand.jundaNumber == 2338);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void treeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "木");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"k"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "1234");
        Assert.IsTrue(hand.jundaNumber == 54433);
        Assert.IsTrue(hand.tzaiNumber == 39692);
    }
    
    //朩
    [Test]
    public void treeAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "朩");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"k"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fw"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "1234");
        Assert.IsTrue(hand.jundaNumber == null);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    
    [Test]
    public void treeCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "松");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"kwl"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"fwwl"}));
        Assert.IsTrue(hand.exceptionLetter == "k");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"木", "朩"}));
        Assert.IsTrue(hand.rawCodepoint == "12343454");
        Assert.IsTrue(hand.jundaNumber == 37563);
        Assert.IsTrue(hand.tzaiNumber == 28277);
    }
    
    [Test]
    public void bambooNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "竹");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    
    [Test]
    public void bambooAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "⺮");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    
    [Test]
    public void bambooCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "签");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"lwst"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tiswst"}));
        Assert.IsTrue(hand.exceptionLetter == "l");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"⺮", "竹"}));
        Assert.IsTrue(hand.rawCodepoint == "3143143414431");
        Assert.IsTrue(hand.jundaNumber == 20057);
        Assert.IsTrue(hand.tzaiNumber == null);
    }
    /*
    [Test]
    public void goldNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "金");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void goldCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "錯");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eatNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "食");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void eatAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飠");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    
    [Test]
    public void eatCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "飼");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void carNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "車");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void carCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "軒");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void threadNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "糸");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void threadCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "絆");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "言");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "訁");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void sayCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "謬");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void horseNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "馬");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void horseCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "騎");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "門");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateAlternativeNoCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "𠁣");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void gateCombo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "閥");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    
    [Test]
    public void noExceptOne()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "丠");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }

    [Test]
    public void noExceptionTwo()
    {
        SchemeRecord hand = schemeRecList.FirstOrDefault(
            x => x.character == "甑");
        
        Assert.IsTrue(hand.code4.SetEquals(new HashSet<string>{"s"}));
        Assert.IsTrue(hand.code6.SetEquals(new HashSet<string>{"tf"}));
        Assert.IsTrue(hand.exceptionLetter == "s");
        Assert.IsTrue(hand.foundExceptionElems.SetEquals(new HashSet<string>{"手"}));
        Assert.IsTrue(hand.rawCodepoint == "3112");
        Assert.IsTrue(hand.jundaNumber == 280442);
        Assert.IsTrue(hand.tzaiNumber == 236673);
    }
    */
}