using System.Text;
using double_stroke_input.projectFolder.FileMaps;
using Microsoft.VisualBasic;

namespace double_stroke_input.projectFolder.StaticFileMaps;


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
       
        var jundaMap = generateJundaMap();
        var tzaiMap = generateTzaiMap();
        var codepointMap = generateCodepointMap();
        var idsMap = generateIdsMap();
        
        var test = "";
    }
    
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

    public Dictionary<UnicodeCharacter, CodepointRecord> generateCodepointMap()
    {
        var codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";
        var codepointLines = removeIntroductionLines(codepointPath, 87);
        //var dictionary = new Dictionary<UnicodeCharacter, CodepointRecord>();
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

        Dictionary<UnicodeCharacter, CodepointRecord> finalUnicodeMap =
            new Dictionary<UnicodeCharacter, CodepointRecord>();
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
                var codepointRecord = new CodepointRecord(entry.Value[0]);
                finalUnicodeMap.Add(character, codepointRecord);
            }

            //var codepointRecord = new CodepointRecord(entry.Value);
            //finalUnicodeMap.Add(character, codepointRecord);
        }
        return finalUnicodeMap;
    }

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

    public Dictionary<UnicodeCharacter, FrequencyRecord> generateTzaiMap()
    {
        var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        var tzaiLines = ReadLinesFromFile(tzaiPath);

        var allOccurrences = CalculateSumTzai(tzaiLines);
        var dictionary = new Dictionary<UnicodeCharacter, FrequencyRecord>();

        foreach (string input in tzaiLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var character = new UnicodeCharacter(splitstr[0], input);
            var freqRecord = new FrequencyRecord(
                WritingSystemEnum.Traditional,
                long.Parse(splitstr[1]),
                allOccurrences
            );
            dictionary.Add(character, freqRecord);
        }
        return dictionary;
    }
    
    public Dictionary<UnicodeCharacter, FrequencyRecord> generateJundaMap()
    {
        var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        var jundaLines = ReadLinesFromFile(jundaPath);
        var allOccurrences = CalculateSumJunda(jundaLines);
        var dictionary = new Dictionary<UnicodeCharacter, FrequencyRecord>();

        foreach (string input in jundaLines)
        {
            string[] splitstr = input.Split('\t');
            var character = new UnicodeCharacter(splitstr[1], input);
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
            var character = new UnicodeCharacter(splitstr[1], input);
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
    
    /*
    private List<UnicodeCharacter> generateRolledOutids(
        UnicodeCharacter character,
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary)
    {
        UtilityFunctions util = new UtilityFunctions();
        //TODO: this code should be rewritten with ai, it is created with tab, and the ai didnt know what i wanted.
        List<UnicodeCharacter> temporaryRollOut = tempDictionary.GetValueOrDefault(character);
        List<List<UnicodeCharacter>> rolledOutSingleLines = new List<List<UnicodeCharacter>>();
        Boolean eachSublistEmptyOrLengthOne = true;
        do
        {
            eachSublistEmptyOrLengthOne = false;
            foreach (var eachLetter in temporaryRollOut)
            {
                var valueFromDict = tempDictionary.GetValueOrDefault(eachLetter);
                if (valueFromDict == null || valueFromDict.Count == 0)
                {
                    rolledOutSingleLines.Add(
                        new List<UnicodeCharacter>() { eachLetter });
                }
                else if (valueFromDict.Count == 1)
                {
                    rolledOutSingleLines.Add(valueFromDict);
                }
                else
                {
                    rolledOutSingleLines.Add(valueFromDict);
                    eachSublistEmptyOrLengthOne = true;
                }
            }
            temporaryRollOut = rolledOutSingleLines.SelectMany(subList => subList).ToList();
        } while (eachSublistEmptyOrLengthOne);

        return temporaryRollOut;
    }*/
}