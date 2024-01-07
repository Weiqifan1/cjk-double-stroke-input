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
    private CodeExceptions exp = new CodeExceptions();
    public void Run()
    {
        Console.WriteLine("Run - GenerateFileMaps.");
        //var heisigTradPath = "../../../projectFolder/StaticFiles/heisigTrad.txt";
        //var heisigTradLines = removeIntroductionLines(heisigTradPath, 3);
       
        //var jundaMap = generateJundaMap();
        //var tzaiMap = generateTzaiMap();
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        const string codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";

        var codeExceptionsFromCharacter = exp.generateCodeExceptionsFromCharacter();
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = generateIdsMap(idsPath);
        var codepointMap = generateCodepointMap(
            codeExceptionsFromCharacter, idsMap, codepointPath);
        var codeExceptionsFromCodepoint = exp.generateCodeExceptionsFromCodepoint();
        Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> foundExceptions = 
            generateFoundEsceptionsMap(codepointMap, codeExceptionsFromCharacter, codeExceptionsFromCodepoint, idsMap);
        
        //
        //扌目趴  虫木竺
        
        var test = "";
    }

    public Dictionary<UnicodeCharacter, CodepointWithExceptionRecord> generateFoundEsceptionsMap(
        Dictionary<UnicodeCharacter, CodepointBasicRecord> codepointMap, 
        Dictionary<UnicodeCharacter, CodepointExceptionRecord> codeExceptionsFromids,
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint,
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
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint,
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap)
    {
        //CodepointWithExceptionRecord? record = null;
        IdsBasicRecord? idsLookup = idsMap.GetValueOrDefault(key);
        CodepointExceptionRecord? exceptionMatchByIds = 
            getExceptionMatchByIdsElement(numberofmissing, key, value, idsLookup, codeExceptionsIds);
        CodepointExceptionRecord? exceptionMatchByCodepoint = 
            getExceptionMatchByCodepoint(numberofmissing, key, value, idsLookup, codeExceptionsFromCodepoint);
        string codepointAfterExp = getCodepointAfterExp(value, exceptionMatchByCodepoint, exceptionMatchByIds, idsLookup);
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
        CodepointExceptionRecord? exceptionsByCodepoint, 
        CodepointExceptionRecord? exceptionMatchByIds, 
        IdsBasicRecord? idsLookup)
    {
        HashSet<string> allvalues = new HashSet<string>();
        int longestNum = 0;
        if (exceptionsByCodepoint != null)
        {
            if (value.rawCodepoint.StartsWith(exceptionsByCodepoint.rawCodepoint) && 
                idsLookup != null &&
                exceptionsByCodepoint.allAcceptableElems.Contains(idsLookup.rolledOutIdsWithNoShape[0]) &&
                exceptionsByCodepoint.rawCodepoint.Length > longestNum)
            {
                longestNum = exceptionsByCodepoint.rawCodepoint.Length;
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

    private CodepointExceptionRecord? getExceptionMatchByCodepoint(
        int numberofmissing, 
        UnicodeCharacter key, 
        CodepointBasicRecord value, 
        IdsBasicRecord? idsLookup, 
        Dictionary<string, CodepointExceptionRecord> codeExceptionsFromCodepoint)
    {
        CodepointExceptionRecord? result = null;
        foreach (var VARIABLE in codeExceptionsFromCodepoint)
        {
            if (value.rawCodepoint.StartsWith(VARIABLE.Key))
            {
                result = codeExceptionsFromCodepoint.GetValueOrDefault(VARIABLE.Key);
                return result;
            }
        }
        return result;
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