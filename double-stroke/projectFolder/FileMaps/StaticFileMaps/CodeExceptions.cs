﻿namespace double_stroke.projectFolder.StaticFileMaps;

public class CodeExceptions
{
    
    public Dictionary<string, CodepointExceptionRecord> generateCodeExceptionsFromCharacter()
    {
        
        UnicodeCharacter uniHandOne = new UnicodeCharacter("手");
        CodepointExceptionRecord uniHandOne_except = new CodepointExceptionRecord(
            uniHandOne, 
            new UnicodeCharacter("s"),
            "3112",
            new List<string>(){new UnicodeCharacter("手").Value},
            new List<string>()
            );
        
        UnicodeCharacter uniHandTwo = new UnicodeCharacter("扌");
        CodepointExceptionRecord uniHandTwo_except = new CodepointExceptionRecord(
            uniHandTwo, 
            new UnicodeCharacter("s"),
            "121",
            new List<string>(){new UnicodeCharacter("扌").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniEye = new UnicodeCharacter("目");
        CodepointExceptionRecord uniEye_except = new CodepointExceptionRecord(
            uniEye, 
            new UnicodeCharacter("d"),
            "25111",
            new List<string>(){new UnicodeCharacter("目").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniFootOne = new UnicodeCharacter("足");
        CodepointExceptionRecord uniFootOne_except = new CodepointExceptionRecord(
            uniFootOne, 
            new UnicodeCharacter("f"),
            "2512134",
            new List<string>(){new UnicodeCharacter("足").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniFootTwo = new UnicodeCharacter("𧾷");
        CodepointExceptionRecord uniFootTwo_except = new CodepointExceptionRecord(
            uniFootTwo, 
            new UnicodeCharacter("f"),
            "251(215|2121)",
            new List<string>(){new UnicodeCharacter("𧾷").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniInsect = new UnicodeCharacter("虫");
        CodepointExceptionRecord uniInsect_except = new CodepointExceptionRecord(
            uniInsect, 
            new UnicodeCharacter("j"),
            "251214",
            new List<string>(){new UnicodeCharacter("虫").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniTreeOne = new UnicodeCharacter("木");
        CodepointExceptionRecord uniTreeOne_except = new CodepointExceptionRecord(
            uniTreeOne, 
            new UnicodeCharacter("k"),
            "1234",
            new List<string>()
            {
                new UnicodeCharacter("木").Value, new UnicodeCharacter("朩").Value
            },
            new List<string>()
        );
        /*
        UnicodeCharacter uniTreeTwo = new UnicodeCharacter("朩");
        CodepointExceptionRecord uniTreeTwo_except = new CodepointExceptionRecord(
            uniTreeTwo, 
            new UnicodeCharacter("k"),
            "1234",
            new List<UnicodeCharacter>(){new UnicodeCharacter()},
            new List<UnicodeCharacter>()
        );*/
        
        UnicodeCharacter uniBambooOne = new UnicodeCharacter("竹");
        CodepointExceptionRecord uniBambooOne_except = new CodepointExceptionRecord(
            uniBambooOne, 
            new UnicodeCharacter("l"),
            "312312",
            new List<string>(){new UnicodeCharacter("竹").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniBambooTwo = new UnicodeCharacter("⺮");
        CodepointExceptionRecord uniBambooTwo_except = new CodepointExceptionRecord(
            uniBambooTwo, 
            new UnicodeCharacter("l"),
            "314314",
            new List<string>(){new UnicodeCharacter("⺮").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniGold = new UnicodeCharacter("金");
        CodepointExceptionRecord uniGold_except = new CodepointExceptionRecord(
            uniGold, 
            new UnicodeCharacter("t"),
            "34112431",
            new List<string>(){new UnicodeCharacter("金").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniEatOne = new UnicodeCharacter("食");
        CodepointExceptionRecord uniEatOne_except = new CodepointExceptionRecord(
            uniEatOne, 
            new UnicodeCharacter("y"),
            "34(1|4)511534",
            new List<string>(){new UnicodeCharacter("食").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniEatTwo = new UnicodeCharacter("飠");
        CodepointExceptionRecord uniEatTwo_except = new CodepointExceptionRecord(
            uniEatTwo, 
            new UnicodeCharacter("y"),
            "34(1|4)51154",
            new List<string>(){new UnicodeCharacter("飠").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniCar = new UnicodeCharacter("車");
        CodepointExceptionRecord uniCar_except = new CodepointExceptionRecord(
            uniCar, 
            new UnicodeCharacter("g"),
            "1251112",
            new List<string>(){new UnicodeCharacter("車").Value},
            new List<string>()
        );

        
        UnicodeCharacter uniThread = new UnicodeCharacter("糸");
        CodepointExceptionRecord uniThread_except = new CodepointExceptionRecord(
            uniThread, 
            new UnicodeCharacter("h"),
            "(554234|554444)",
            new List<string>(){new UnicodeCharacter("糸").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniSayOne = new UnicodeCharacter("言");
        CodepointExceptionRecord uniSayOne_except = new CodepointExceptionRecord(
            uniSayOne, 
            new UnicodeCharacter("v"),
            "(1|4)111251",
            new List<string>()
            {
                new UnicodeCharacter("言").Value, new UnicodeCharacter("訁").Value
            },
            new List<string>()
        );
        /*
        UnicodeCharacter uniSayTwo = new UnicodeCharacter("訁");
        CodepointExceptionRecord uniSayTwo_except = new CodepointExceptionRecord(
            uniSayTwo, 
            new UnicodeCharacter("v"),
            "(1|4)111251",
            new List<UnicodeCharacter>(){new UnicodeCharacter("訁")},
            new List<UnicodeCharacter>()
        );*/
        
        UnicodeCharacter uniHorse = new UnicodeCharacter("馬");
        CodepointExceptionRecord uniHorse_except = new CodepointExceptionRecord(
            uniHorse, 
            new UnicodeCharacter("b"),
            "(12|21)11254444",
            new List<string>(){new UnicodeCharacter("馬").Value},
            new List<string>()
        );
        
        UnicodeCharacter uniGateOne = new UnicodeCharacter("門");
        CodepointExceptionRecord uniGateOne_except = new CodepointExceptionRecord(
            uniGateOne, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<string>(){new UnicodeCharacter("門").Value},
            new List<string>()
        );
        /*
        UnicodeCharacter uniGateTwo = new UnicodeCharacter("𠁣");
        CodepointExceptionRecord uniGateTwo_except = new CodepointExceptionRecord(
            uniGateTwo, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<UnicodeCharacter>(){new UnicodeCharacter("𠁣")},
            new List<UnicodeCharacter>()
        );*/
        
        UnicodeCharacter uniGateThree = new UnicodeCharacter("𠃛");
        CodepointExceptionRecord uniGateThree_except = new CodepointExceptionRecord(
            uniGateThree, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<string>()
            {
                new UnicodeCharacter("𠁣").Value, new UnicodeCharacter("𠃛").Value
            },
            new List<string>()
        );

        Dictionary<string, CodepointExceptionRecord> result =
            new Dictionary<string, CodepointExceptionRecord>();
        result.Add(uniHandOne.Value, uniHandOne_except);
        result.Add(uniHandTwo.Value, uniHandTwo_except);
        result.Add(uniEye.Value, uniEye_except);
        result.Add(uniFootOne.Value, uniFootOne_except);
        result.Add(uniFootTwo.Value, uniFootTwo_except);
        result.Add(uniInsect.Value, uniInsect_except);
        result.Add(uniTreeOne.Value, uniTreeOne_except);
        //result.Add(uniTreeTwo, uniTreeTwo_except);
        result.Add(uniBambooOne.Value, uniBambooOne_except);
        result.Add(uniBambooTwo.Value, uniBambooTwo_except);
        result.Add(uniGold.Value, uniGold_except);
        result.Add(uniEatOne.Value, uniEatOne_except);
        result.Add(uniEatTwo.Value, uniEatTwo_except);
        result.Add(uniCar.Value, uniCar_except);
        result.Add(uniThread.Value, uniThread_except);
        result.Add(uniSayOne.Value, uniSayOne_except);
        //result.Add(uniSayTwo, uniSayTwo_except);
        result.Add(uniHorse.Value, uniHorse_except);
        result.Add(uniGateOne.Value, uniGateOne_except);
        //result.Add(uniGateTwo, uniGateTwo_except);
        result.Add(uniGateThree.Value, uniGateThree_except);
        return result;

        //UnicodeCharacter character,
        //UnicodeCharacter alphabetLetter,
        //    List<string> rawCodepoints,
        //List<UnicodeCharacter> mistakenMatches

        //generate exception code for these characters:
        //and write tests for them
        //扌目趴  虫木竺
        //金飣車糽言馬門

        //s   "手","扌"   "121"
        //d    "目"  "25111"
        //f    "足",  2512134
        //f     "𧾷"   "251(215|2121)";   //251215  2512121
        //j    "虫"  "251214"
        //k    "木","朩"  "1234"
        //l     "竹","⺮","ケ" "314314"

        //t     "金"   "34112431"
        //y    "食","飠"    "34(1|4)(51154|511211)"    
        // "344511211"  "34451154",  "34151154",  "341511211",
        //g     "車"    "1251112"
        //h     "糸"    "(554234|554444)"   "554234"  "554444"
        //v      "言","訁"    "(1|4)111251"     "1111251"    "4111251"
        //b      "馬"    "(12|21)11254444"    "1211254444"   "2111254444"
        //n     "𠁣","𠃛","門"    "25112511"
    }
    
    
    public Dictionary<string, CodepointExceptionRecord> generateCodeExceptionsFromCodepoint()
    {
        Dictionary<string, CodepointExceptionRecord> exceptFromChar = 
            generateCodeExceptionsFromCharacter();
        Dictionary<string, CodepointExceptionRecord> result =
            new Dictionary<string, CodepointExceptionRecord>();
        foreach (KeyValuePair<string, CodepointExceptionRecord> item in exceptFromChar)
        {
            result[item.Value.rawCodepoint] = item.Value;
        }
        return result;
    }
}