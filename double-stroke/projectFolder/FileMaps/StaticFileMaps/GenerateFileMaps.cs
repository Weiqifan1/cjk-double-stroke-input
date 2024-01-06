using System.Text;
using double_stroke.projectFolder.FileMaps;
using double_stroke.projectFolder.StaticFileMaps;
using Microsoft.VisualBasic;

namespace double_stroke.projectFolder.StaticFileMaps;


using System.Data;
using System;
using System.Collections.Generic;
using System.IO;


public class GenerateFileMaps
{
    public void Run()
    {
        Console.WriteLine("Run - GenerateFileMaps.");
        //var heisigTradPath = "../../../projectFolder/StaticFiles/heisigTrad.txt";
        //var heisigTradLines = removeIntroductionLines(heisigTradPath, 3);
       
        //var jundaMap = generateJundaMap();
        //var tzaiMap = generateTzaiMap();
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        const string codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";

        var codeExceptionsFromCharacter = generateCodeExceptionsFromCharacter();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = generateIdsMap(idsPath);
        var codepointMap = generateCodepointMap(
            codeExceptionsFromCharacter, idsMap, codepointPath);
        var codeExceptionsFromCodepoint = generateCodeExceptionsFromCodepoint();
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            generateFoundEsceptionsMap(codepointMap, codeExceptionsFromCharacter, codeExceptionsFromCodepoint, idsMap);
        
        //
        //扌目趴  虫木竺
        
        var test = "";
    }

    public Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> generateFoundEsceptionsMap(
        Dictionary<UnicodeCharacter, CodepointBasicRecord> codepointMap, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptionsFromids,
        Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint,
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap)
    {
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> result =
            new Dictionary<UnicodeCharacter, CodepointWithExceptionRecord>();

        int numberofmissing = 0;
        foreach (KeyValuePair<UnicodeCharacter, CodepointBasicRecord> item in codepointMap)
        {
            UnicodeCharacter key = item.Key;
            CodepointBasicRecord value = item.Value;

            CodepointWithExceptionRecord newitem = generateCodepointWithExceptionRecord(
                numberofmissing, 
                key, 
                value, 
                codeExceptionsFromids, 
                codeExceptionsFromCodepoint, 
                idsMap);
            result.Add(key, newitem);
        }
        Console.WriteLine(numberofmissing);
        return result;
    }

    private CodepointWithExceptionRecord generateCodepointWithExceptionRecord(
        int numberofmissing,
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptionsIds,
        Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint,
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap)
    {
        //CodepointWithExceptionRecord? record = null;
        IdsBasicRecord? idsLookup = idsMap.GetValueOrDefault(key);
        CodepointExceptionRecord? exceptionMatchByIds = 
            getExceptionMatchByIdsElement(numberofmissing, key, value, idsLookup, codeExceptionsIds);
        List<CodepointExceptionRecord> exceptionMatchByCodepoint = 
            getExceptionMatchByCodepoint(numberofmissing, key, value, idsLookup, codeExceptionsFromCodepoint);
        string codepointAfterExp = getCodepointAfterExp(value, exceptionMatchByCodepoint);
        CodepointWithExceptionRecord record = new CodepointWithExceptionRecord(
            exceptionMatchByIds,
            exceptionMatchByCodepoint,
            value,
            codepointAfterExp,
            key,
            idsLookup);
        return record;
    }

    private string getCodepointAfterExp(
        CodepointBasicRecord value, 
        List<CodepointExceptionRecord> exceptionsByCodepoint)
    {
        HashSet<string> allvalues = new HashSet<string>();
        int longestNum = 0;
        foreach (var VARIABLE in exceptionsByCodepoint)
        {
            if (value.rawCodepoint.StartsWith(VARIABLE.rawCodepoint) && 
                VARIABLE.rawCodepoint.Length > longestNum)
            {
                longestNum = VARIABLE.rawCodepoint.Length;
            }
        }

        string result = value.rawCodepoint.Substring(longestNum);
        return result;
    }

    private string getCodevalueMinusException(
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        CodepointExceptionRecord exceptionMatch)
    {
        if (!value.rawCodepoint.StartsWith(exceptionMatch.rawCodepoint))
        {
            throw new FormatException("The found exception doesnt match the original full codepoint for character: " + 
                                      key.Value + " val: " + value.rawCodepoint + " exception: " + exceptionMatch.character);
        }

        string remainder = value.rawCodepoint.Substring(exceptionMatch.rawCodepoint.Length);
        return remainder;
    }

    private List<CodepointExceptionRecord> getExceptionMatchByCodepoint(
        int numberofmissing, 
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        IdsBasicRecord? idsLookup, 
        Dictionary<string, List<CodepointExceptionRecord>> codeExceptionsFromCodepoint)
    {
        List<CodepointExceptionRecord> result = new List<CodepointExceptionRecord>();
        foreach (var VARIABLE in codeExceptionsFromCodepoint)
        {
            if (value.rawCodepoint.StartsWith(VARIABLE.Key))
            {
                result = codeExceptionsFromCodepoint.GetValueOrDefault(VARIABLE.Key);
                return result;
            }
        }
        return new List<CodepointExceptionRecord>();
    }
    
    private CodepointExceptionRecord? getExceptionMatchByIdsElement(
        int numberofmissing, 
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        IdsBasicRecord? idsLookup, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptions)
    {
        if (idsLookup == null  && numberofmissing < 10) 
        {
            throw new FormatException("key is not in ids: " + key + " val: " + value);
        }
        else if (idsLookup != null)
        {
            var firstIdsMatch = idsLookup.rolledOutIdsWithNoShape[0];
            var exceptionMatch = codeExceptions.GetValueOrDefault(firstIdsMatch);
            return exceptionMatch;
        }
        else
        {
            return null;
        }
    }

    public Dictionary<string, List<CodepointExceptionRecord>> generateCodeExceptionsFromCodepoint()
    {
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> exceptFromChar = 
            generateCodeExceptionsFromCharacter();
        Dictionary<string, List<CodepointExceptionRecord>> result =
            new Dictionary<string, List<CodepointExceptionRecord>>();
        foreach (KeyValuePair<UnicodeCharacter, CodepointExceptionRecord> item in exceptFromChar)
        {
            string key = item.Value.rawCodepoint;

            if (result.ContainsKey(key))
            {
                result[key].Add(item.Value);
            }
            else
            {
                result[key] = new List<CodepointExceptionRecord>() { item.Value };
            }
        }
        return result;
    }

    public Dictionary<UnicodeCharacter, CodepointExceptionRecord> generateCodeExceptionsFromCharacter()
    {
        
        UnicodeCharacter uniHandOne = new UnicodeCharacter("手");
        CodepointExceptionRecord uniHandOne_except = new CodepointExceptionRecord(
            uniHandOne, 
            new UnicodeCharacter("s"),
            "3112",
            new List<UnicodeCharacter>()
            );
        
        UnicodeCharacter uniHandTwo = new UnicodeCharacter("扌");
        CodepointExceptionRecord uniHandTwo_except = new CodepointExceptionRecord(
            uniHandTwo, 
            new UnicodeCharacter("s"),
            "121",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniEye = new UnicodeCharacter("目");
        CodepointExceptionRecord uniEye_except = new CodepointExceptionRecord(
            uniEye, 
            new UnicodeCharacter("d"),
            "25111",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniFootOne = new UnicodeCharacter("足");
        CodepointExceptionRecord uniFootOne_except = new CodepointExceptionRecord(
            uniFootOne, 
            new UnicodeCharacter("f"),
            "2512134",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniFootTwo = new UnicodeCharacter("𧾷");
        CodepointExceptionRecord uniFootTwo_except = new CodepointExceptionRecord(
            uniFootTwo, 
            new UnicodeCharacter("f"),
            "251(215|2121)",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniInsect = new UnicodeCharacter("虫");
        CodepointExceptionRecord uniInsect_except = new CodepointExceptionRecord(
            uniInsect, 
            new UnicodeCharacter("j"),
            "251214",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniTreeOne = new UnicodeCharacter("木");
        CodepointExceptionRecord uniTreeOne_except = new CodepointExceptionRecord(
            uniTreeOne, 
            new UnicodeCharacter("k"),
            "1234",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniTreeTwo = new UnicodeCharacter("朩");
        CodepointExceptionRecord uniTreeTwo_except = new CodepointExceptionRecord(
            uniTreeTwo, 
            new UnicodeCharacter("k"),
            "1234",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniBambooOne = new UnicodeCharacter("竹");
        CodepointExceptionRecord uniBambooOne_except = new CodepointExceptionRecord(
            uniBambooOne, 
            new UnicodeCharacter("l"),
            "312312",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniBambooTwo = new UnicodeCharacter("⺮");
        CodepointExceptionRecord uniBambooTwo_except = new CodepointExceptionRecord(
            uniBambooTwo, 
            new UnicodeCharacter("l"),
            "314314",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniGold = new UnicodeCharacter("金");
        CodepointExceptionRecord uniGold_except = new CodepointExceptionRecord(
            uniGold, 
            new UnicodeCharacter("t"),
            "34112431",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniEatOne = new UnicodeCharacter("食");
        CodepointExceptionRecord uniEatOne_except = new CodepointExceptionRecord(
            uniEatOne, 
            new UnicodeCharacter("y"),
            "34(1|4)511534",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniEatTwo = new UnicodeCharacter("飠");
        CodepointExceptionRecord uniEatTwo_except = new CodepointExceptionRecord(
            uniEatTwo, 
            new UnicodeCharacter("y"),
            "34(1|4)51154",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniCar = new UnicodeCharacter("車");
        CodepointExceptionRecord uniCar_except = new CodepointExceptionRecord(
            uniCar, 
            new UnicodeCharacter("g"),
            "1251112",
            new List<UnicodeCharacter>()
        );

        
        UnicodeCharacter uniThread = new UnicodeCharacter("糸");
        CodepointExceptionRecord uniThread_except = new CodepointExceptionRecord(
            uniThread, 
            new UnicodeCharacter("h"),
            "(554234|554444)",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniSayOne = new UnicodeCharacter("言");
        CodepointExceptionRecord uniSayOne_except = new CodepointExceptionRecord(
            uniSayOne, 
            new UnicodeCharacter("v"),
            "(1|4)111251",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniSayTwo = new UnicodeCharacter("訁");
        CodepointExceptionRecord uniSayTwo_except = new CodepointExceptionRecord(
            uniSayTwo, 
            new UnicodeCharacter("v"),
            "(1|4)111251",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniHorse = new UnicodeCharacter("馬");
        CodepointExceptionRecord uniHorse_except = new CodepointExceptionRecord(
            uniHorse, 
            new UnicodeCharacter("b"),
            "(12|21)11254444",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniGateOne = new UnicodeCharacter("門");
        CodepointExceptionRecord uniGateOne_except = new CodepointExceptionRecord(
            uniGateOne, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniGateTwo = new UnicodeCharacter("𠁣");
        CodepointExceptionRecord uniGateTwo_except = new CodepointExceptionRecord(
            uniGateTwo, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<UnicodeCharacter>()
        );
        
        UnicodeCharacter uniGateThree = new UnicodeCharacter("𠃛");
        CodepointExceptionRecord uniGateThree_except = new CodepointExceptionRecord(
            uniGateThree, 
            new UnicodeCharacter("n"),
            "25112511",
            new List<UnicodeCharacter>()
        );

        Dictionary<UnicodeCharacter, CodepointExceptionRecord> result =
            new Dictionary<UnicodeCharacter, CodepointExceptionRecord>();
        result.Add(uniHandOne, uniHandOne_except);
        result.Add(uniHandTwo, uniHandTwo_except);
        result.Add(uniEye, uniEye_except);
        result.Add(uniFootOne, uniFootOne_except);
        result.Add(uniFootTwo, uniFootTwo_except);
        result.Add(uniInsect, uniInsect_except);
        result.Add(uniTreeOne, uniTreeOne_except);
        result.Add(uniTreeTwo, uniTreeTwo_except);
        result.Add(uniBambooOne, uniBambooOne_except);
        result.Add(uniBambooTwo, uniBambooTwo_except);
        result.Add(uniGold, uniGold_except);
        result.Add(uniEatOne, uniEatOne_except);
        result.Add(uniEatTwo, uniEatTwo_except);
        result.Add(uniCar, uniCar_except);
        result.Add(uniThread, uniThread_except);
        result.Add(uniSayOne, uniSayOne_except);
        result.Add(uniSayTwo, uniSayTwo_except);
        result.Add(uniHorse, uniHorse_except);
        result.Add(uniGateOne, uniGateOne_except);
        result.Add(uniGateTwo, uniGateTwo_except);
        result.Add(uniGateThree, uniGateThree_except);
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

    public Dictionary<UnicodeCharacter, IdsBasicRecord> generateIdsMap(string idsPath)
    {
        var idsLines = removeIntroductionLines(idsPath, 2);
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> result = 
            new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<UnicodeCharacter, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();

        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = util.CreateUnicodeCharacters(splitstr[2]);

            tempDictionary.TryAdd(character, strSplitIds);
            List<UnicodeCharacter> rolldOutids = generateRolledOutids(character, tempDictionary);
            var rolledOutWithNoShape = removeUnvantedCharacters(rolldOutids, charsToRemove);
            IdsBasicRecord basic = new IdsBasicRecord(input, rolldOutids, rolledOutWithNoShape);
        
            result.TryAdd(character, basic);
        }
        return result;
    }
    
    /*
    public Dictionary<UnicodeCharacter, IdsBasicRecord> generateIdsMap()
    {
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        var idsLines = removeIntroductionLines(idsPath, 2);
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> result = 
            new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<UnicodeCharacter, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();
        //List<UnicodeCharacter> rolledOutIds(character, )
        //IdsBasicRecord record = new IdsBasicRecord(input, );
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = util.CreateUnicodeCharacters(splitstr[2]);
            tempDictionary.Add(character, strSplitIds);
        }
        
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> rolldOutids = generateRolledOutids(character, tempDictionary);
            var rolledOutWithNoShape = removeUnvantedCharacters(rolldOutids, charsToRemove);
            IdsBasicRecord basic = new IdsBasicRecord(input, rolldOutids, rolledOutWithNoShape);
            result.Add(character, basic);
        }
        return result;
    }
*/
    
    private List<UnicodeCharacter> removeUnvantedCharacters(
        List<UnicodeCharacter> rolldOutids, 
        List<UnicodeCharacter> charsToRemove)
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        foreach (var VARIABLE in rolldOutids)
        {
            if (!charsToRemove.Contains(VARIABLE))
            {
                result.Add(VARIABLE);
            }
        }
        return result;
    }
    
    public Dictionary<UnicodeCharacter, CodepointBasicRecord> generateCodepointMap(
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptions,
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap,
        string codepointPath)
    {
        const int introLinesCount = 87;
        var codepointLines = removeIntroductionLines(codepointPath, introLinesCount);
        var uniDict = GenerateUniDictionary(codepointLines);
        //var test = uniDict.GetValueOrDefault("鰠");
        var result = GenerateFinalUnicodeMap(uniDict, codeExceptions, idsMap);
        return result;
    }

    private Dictionary<string, List<string>> GenerateUniDictionary(IEnumerable<string> codepointLines)
    {
        //add the missing codepointLines
        //missing junda:
        //裏 3 秊  1
        //missing tzai:
        // 兀  119  嗀  11
        List<string> missingChars = new List<string>();
        string one1 = "U+F9E7\t裏\t4125111213534";// + Environment.NewLine;
        string two2 = "U+F995\t秊\t31234312"; //+ Environment.NewLine;
        string three3 = "U+FA0C\t兀\t135"; //+ Environment.NewLine;
        string four4 = "U+FA0D\t嗀\t1214512513554";// + Environment.NewLine;
                     
        missingChars.Add(one1);
        missingChars.Add(two2);
        missingChars.Add(three3);
        missingChars.Add(four4);
        
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<string, List<string>> uniDict = new Dictionary<string, List<string>>();
        foreach (string input in codepointLines)
        {
            addToUniDict(input, util, uniDict);
        }

        foreach (var VARIABLE in missingChars)
        {
            addToUniDict(VARIABLE, util, uniDict);
        }
        
        return uniDict;
    }

    private void addToUniDict(string input, UtilityFunctions util, Dictionary<string, List<string>> uniDict)
    {
        if (!input.StartsWith("U+")) return;
        string[] splitstr = 
            input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        if (splitstr[1] == "鰠^")
        {
            string test = "";
        }

        var character = util.firstUnicodeCharacter(splitstr[1]);
        if (!uniDict.ContainsKey(character.Value)) 
        {
            uniDict[character.Value] = new List<string>();
        }
        uniDict[character.Value].Add(splitstr[2]);
    }

    private Dictionary<UnicodeCharacter, CodepointBasicRecord> GenerateFinalUnicodeMap(
        Dictionary<string, List<string>> uniDict, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptions, 
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap)
    {
        var finalUnicodeMap = new Dictionary<UnicodeCharacter, CodepointBasicRecord>();
        foreach (var entry in uniDict)
        {
            if (entry.Key == "鰠")
            {
                string test = "";
            }

            var character = new UnicodeCharacter(entry.Key);
            CodepointBasicRecord prelimEntry = generateCodepointRecord(entry, codeExceptions, idsMap);
            finalUnicodeMap[character] = prelimEntry; 
        }
        return finalUnicodeMap;
    }

    private CodepointBasicRecord generateCodepointRecord(
        KeyValuePair<string, List<string>> entry, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptions, 
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap)
    {
        //TODO: implement codeRecord
        if (entry.Value.Count != 1)
        {
            throw new FormatException("CodepointBasicRecord is given badly formatted: " + entry);
        }

        string firstItemInEntry = entry.Value[0];
        CodepointBasicRecord result = new CodepointBasicRecord(firstItemInEntry);

        string test = "";
        return result;
    }

    /*
    public Dictionary<UnicodeCharacter, CodepointBasicRecord> generateCodepointMap()
    {
        var codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";
        var codepointLines = removeIntroductionLines(codepointPath, 87);
        //var dictionary = new Dictionary<UnicodeCharacter, CodepointBasicRecord>();
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<string, List<string>> uniDict = new Dictionary<string, List<string>>();
        
        foreach (string input in codepointLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (input.StartsWith("U+"))
            {
                var character = util.firstUnicodeCharacter(splitstr[1]);

                if (uniDict.ContainsKey(character.Value))
                {
                    List<string> currentVals = uniDict[character.Value];
                    currentVals.Add(splitstr[2]);
                    uniDict.Add(character.Value, currentVals);
                }
                uniDict.Add(character.Value, [splitstr[2]]);
            } else
            {
                string test = "";
            }
        }

        Dictionary<UnicodeCharacter, CodepointBasicRecord> finalUnicodeMap =
            new Dictionary<UnicodeCharacter, CodepointBasicRecord>();
        foreach (var entry in uniDict)
        {
            var character = new UnicodeCharacter(entry.Key, entry.Value[0]);
            var entVal = entry.Value;
            if (entVal.Count > 1)
            {
                throw new NotImplementedException(); 
            }
            else
            {
                var codepointRecord = new CodepointBasicRecord(entry.Value[0]);
                finalUnicodeMap.Add(character, codepointRecord);
            }

            //var codepointRecord = new CodepointBasicRecord(entry.Value);
            //finalUnicodeMap.Add(character, codepointRecord);
        }
        return finalUnicodeMap;
    }
*/
    public Dictionary<UnicodeCharacter, HeisigRecord> generateHeisigTradMap()
    {
        var heisigTradPath = "../../../projectFolder/StaticFiles/heisigTrad.txt";
        var heisigTrad = 
            generateHeisigMap(WritingSystemEnum.Traditional, heisigTradPath);
        return heisigTrad;
    }
    
    public Dictionary<UnicodeCharacter, HeisigRecord> generateHeisigSimpMap()
    {
        var heisigSimpPath = "../../../projectFolder/StaticFiles/heisigSimp.txt";
        var heisigSimp = 
            generateHeisigMap(WritingSystemEnum.Simplified, heisigSimpPath);
        return heisigSimp;
    }

    public Dictionary<UnicodeCharacter, FrequencyRecord> generateTzaiMap(string tzaiPath)
    {
        //var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        var tzaiLines = ReadLinesFromFile(tzaiPath);

        var allOccurrences = CalculateSumTzai(tzaiLines);
        var dictionary = new Dictionary<UnicodeCharacter, FrequencyRecord>();

        foreach (string input in tzaiLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var character = new UnicodeCharacter(splitstr[0]);
            var freqRecord = new FrequencyRecord(
                WritingSystemEnum.Traditional,
                long.Parse(splitstr[1]),
                allOccurrences
            );
            dictionary.Add(character, freqRecord);
        }
        return dictionary;
    }
    
    public Dictionary<UnicodeCharacter, FrequencyRecord> generateJundaMap(string jundaPath)
    {
        //var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        var jundaLines = ReadLinesFromFile(jundaPath);
        var allOccurrences = CalculateSumJunda(jundaLines);
        var dictionary = new Dictionary<UnicodeCharacter, FrequencyRecord>();

        foreach (string input in jundaLines)
        {
            string[] splitstr = input.Split('\t');
            var character = new UnicodeCharacter(splitstr[1]);
            var freqRecord = new FrequencyRecord(
                WritingSystemEnum.Simplified,
                long.Parse(splitstr[2]),
                allOccurrences
            );
            dictionary.Add(character, freqRecord);
        }
        return dictionary;
    }
    
    private long CalculateSumTzai(List<string> inputs)
    {
        long sum = 0;
        foreach(var input in inputs)
        {
            var elements = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if(elements.Length > 2 && int.TryParse(elements[1], out var number)) 
            {
                sum += number;
            }
        }
        return sum;
    }
    
    private long CalculateSumJunda(List<string> inputs)
    {
        long sum = 0;
        foreach(var input in inputs)
        {
            var elements = input.Split('\t');
            if(elements.Length > 2 && int.TryParse(elements[2], out var number)) 
            {
                sum += number;
            }
        }
        return sum;
    }
    
    private List<string> removeIntroductionLines(string filePath, int introductoryLineLimmit)
    {
        var rawLines = ReadLinesFromFile(filePath);
        var resultLines = rawLines.Skip(introductoryLineLimmit).ToList();
        return resultLines;
    }
    
    private List<string> ReadLinesFromFile(string filename)
    {
        try
        {
            var lines = new List<string>();
            StreamReader reader = new StreamReader(filename);

            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    
    
    private Dictionary<UnicodeCharacter, HeisigRecord> generateHeisigMap(WritingSystemEnum system, string path)
    {
        var heisigSimpLines = removeIntroductionLines(path, 3);

        var dictionary = new Dictionary<UnicodeCharacter, HeisigRecord>();
        int linenumber = 0;

        foreach (string input in heisigSimpLines)
        {
            linenumber += 1;
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var character = new UnicodeCharacter(splitstr[1]);
            var freqRecord = new HeisigRecord(
                system,
                stringToInd(splitstr[0], splitstr, linenumber)
            );
            System.Console.WriteLine(linenumber + " " + splitstr[0]);
            dictionary.Add(character, freqRecord);
        }
        return dictionary;
    }
    
    int stringToInd(string s, string[] splitStrInput, int linenumber)
    {
        int result = 0;
        try
        {
            result = int.Parse(s);
        }
        catch (Exception ex)
        {
            result = linenumber;
        }
        return result;
    }
    
    private List<UnicodeCharacter> generateRolledOutids(
        UnicodeCharacter character,
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary)
    {
        UtilityFunctions util = new UtilityFunctions();
        List<UnicodeCharacter> temporaryRollOut = tempDictionary.GetValueOrDefault(character);
        return Helper(temporaryRollOut, tempDictionary);
    }

    private List<UnicodeCharacter> Helper(
        List<UnicodeCharacter> temporaryRollOut,
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary)
    {
        List<List<UnicodeCharacter>> rolledOutSingleLines = 
            new List<List<UnicodeCharacter>>();
        Boolean eachSublistEmptyOrLengthOne = false;
        foreach (var eachLetter in temporaryRollOut)
        {
            var valueFromDict = tempDictionary.GetValueOrDefault(eachLetter);
            List<UnicodeCharacter> toAdd = valueFromDict == null || valueFromDict.Count == 0
                ? new List<UnicodeCharacter>() {eachLetter}
                : valueFromDict;
            rolledOutSingleLines.Add(toAdd);
            if (valueFromDict?.Count > 1)
                eachSublistEmptyOrLengthOne = true;
        }
        temporaryRollOut = rolledOutSingleLines.SelectMany(subList => subList).ToList();
        if (eachSublistEmptyOrLengthOne)
        {
            return Helper(temporaryRollOut, tempDictionary);   // Recursive call
        }
        return temporaryRollOut;
    }
    
    private List<UnicodeCharacter> irrelevantShapeAndLatinCharacters()
    {
        UtilityFunctions util = new UtilityFunctions();
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        string ideographicDiscription = ideographicCharacterRange();
        string asciiStr = GetAllAsciiCharacters();
        var ideographics = util.CreateUnicodeCharacters(ideographicDiscription);
        var ascii = util.CreateUnicodeCharacters(asciiStr);
        return ideographics.Concat(ascii).ToList();
    }

    private string ideographicCharacterRange()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0x2FF0; i <= 0x2FFF; i++)
        {
            sb.Append(char.ConvertFromUtf32(i)); // Converts int to Unicode character and appends it to string builder
        }
        string output = sb.ToString(); // Holds all the characters from U+2FF0 to U+2FFF
        return output;
    }

    public string GetAllAsciiCharacters()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i <= 127; i++)
        {
            sb.Append((char)i);
        }
        return sb.ToString();
    }
}