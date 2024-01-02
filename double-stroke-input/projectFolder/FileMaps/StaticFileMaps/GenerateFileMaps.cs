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
       
        //var jundaMap = generateJundaMap();
        //var tzaiMap = generateTzaiMap();
        //var codepointMap = generateCodepointMap();
        var idsMap = generateIdsMap();
        
        var test = "";
    }
    
    public Dictionary<UnicodeCharacter, IdsBasicRecord> generateIdsMap()
    {
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        var idsLines = removeIntroductionLines(idsPath, 2);
        UtilityFunctions util = new UtilityFunctions();
        Dictionary<UnicodeCharacter, IdsBasicRecord> result = new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        Dictionary<string, string> tempDictionary = new Dictionary<string, string>();
        //List<UnicodeCharacter> rolledOutIds(character, )
        //IdsBasicRecord record = new IdsBasicRecord(input, );
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            tempDictionary.Add(character.Value, splitstr[2]);
        }
        
        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = util.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> rolldOutids = generateRolledOutids(character, tempDictionary);
            IdsBasicRecord basic = new IdsBasicRecord(input, rolldOutids);
            result.Add(character, basic);
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
    
    private List<UnicodeCharacter> generateRolledOutids(UnicodeCharacter character, Dictionary<string, string> tempDictionary)
    {
        //TODO: this code should be rewritten with ai, it is created with tab, and the ai didnt know what i wanted.
        List<UnicodeCharacter> rolledOutIds = new List<UnicodeCharacter>();
        /*
        if (tempDictionary.ContainsKey(character.Value))
        {
            string[] rolledOutIdsArray = tempDictionary[character.Value].Split(',');
            foreach (string rolledOutId in rolledOutIdsArray)
            {
                UnicodeCharacter rolledOutCharacter = util.firstUnicodeCharacter(rolledOutId);
                rolledOutIds.Add(rolledOutCharacter);
            }
        }*/
        return rolledOutIds;
    }

}