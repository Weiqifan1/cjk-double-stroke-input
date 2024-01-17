using double_stroke.projectFolder.FileMaps;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace double_stroke.projectFolder.StaticFileMaps;

public class GenerateIds
{

    public void generateAndSaveIdsMap(string idsPath, string newPathForSaveFile)
    {
        Dictionary<UnicodeCharacter, IdsBasicRecord> idsMap = generateIdsMap(idsPath);
        
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Converters.Add(new KeyAsStrConverter());
        string json = JsonConvert.SerializeObject(idsMap);
        File.WriteAllText(newPathForSaveFile, json);
    }

    public Dictionary<UnicodeCharacter, IdsBasicRecord> readIdsMap(string idsPath)
    {
        string jsonFromFile = File.ReadAllText(idsPath);

        JsonSerializerSettings settings = new JsonSerializerSettings();
        //settings.Converters.Add(new KeyAsStrConverter());
        Dictionary<UnicodeCharacter, IdsBasicRecord> resultDictionary =
            JsonConvert.DeserializeObject<Dictionary<UnicodeCharacter, IdsBasicRecord>>(jsonFromFile, settings);
        
        // Deserialize JSON to Dictionary
        /*
        Dictionary<UnicodeCharacter, IdsBasicRecord> resultDictionary =
            JsonConvert.DeserializeObject<Dictionary<UnicodeCharacter, IdsBasicRecord>>(jsonFromFile);
        */
        return resultDictionary;
    }

    public Dictionary<UnicodeCharacter, IdsBasicRecord> generateIdsMap(string idsPath)
    {
        //IdsBasicRecord(
        //string rawIds,
        //    List<UnicodeCharacter> rolledOutIds,
        //List<UnicodeCharacter> rolledOutIdsWithNoShape
        var latin = latinCharcters();
        var allUnwanted = irrelevantShapeAndLatinCharacters();
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> genRawIds = generateRawIdsMap(idsPath);
        var endResult = new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        foreach (var item in genRawIds)
        {
            if (item.Key.Equals("𠞂"))
            {
                var testRes = "";
            }

            List<UnicodeCharacter> rollOut = getRecursiveRawId(item.Key, genRawIds, latin);
            List<UnicodeCharacter> rollOutNoUnwanted = rollOut.Where(n => !allUnwanted.Contains(n)).ToList();
            if (rollOutNoUnwanted.Count > 0)
            {
                IdsBasicRecord basicRec = new IdsBasicRecord(
                    genRawIds.GetValueOrDefault(item.Key),
                    rollOut, 
                    rollOutNoUnwanted);
                endResult.Add(item.Key, basicRec);
            }
            //var rolledOutIds = generateRolledOutids(item.Key, tempDictionary);
            //var rolledOutIdsWithNoShape = UtilityFunctions.removeUnvantedCharacters(rolledOutIds, charsToRemove);
            //var idsBasicRecord = new IdsBasicRecord(item.Value.rawIds, rolledOutIds, rolledOutIdsWithNoShape);
            //endResult.Add(item.Key, idsBasicRecord);
        }
        return endResult;
        
    }
    
    private List<UnicodeCharacter> getRecursiveRawId(
        UnicodeCharacter character, 
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> rawIdsDict,
        List<UnicodeCharacter> unwanted)
    {
        List<UnicodeCharacter> resultSet = new List<UnicodeCharacter>();
        if (character.Value.Equals("𥺛") )//"𢺓" //|| character.Value.Equals()
        {
            var test = "";
        }
        if (!rawIdsDict.TryGetValue(character, out List<UnicodeCharacter> listValues))
            return resultSet; //character not in dictionary
        foreach (var item in listValues)
        {
            if (!unwanted.Contains(item)) //ignore self-references
            {
                if (!rawIdsDict.ContainsKey(item) || item.Equals(character))
                {
                    resultSet.Add(item);
                }
                else
                {
                    resultSet.AddRange(getRecursiveRawId(item, rawIdsDict, unwanted));
                }
            }
            //resultSet.AddRange(getRecursiveRawId(item, rawIdsDict, unwanted));
        }
        if (character.Value.Equals("𥺛") )//"𢺓" //|| character.Value.Equals()
        {
            var test = "";
        }
        return resultSet;
    }

    /*
    if (character.Value.Equals("𢺓") ) //|| character.Value.Equals()
        {
            var test = "";
        }
     */

    private Dictionary<UnicodeCharacter, List<UnicodeCharacter>> generateRawIdsMap(string idsPath)
    {
        var idsLines = UtilityFunctions.removeIntroductionLines(idsPath, 2);
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<UnicodeCharacter, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();

        foreach (string eachRawIdsLine in idsLines)
        {
            string[] splitstr = 
                eachRawIdsLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = UtilityFunctions.CreateUnicodeCharacters(splitstr[2]);

            if (character.Equals(new UnicodeCharacter("𬔦")))
            {
                string testWeird = "";
            }

            tempDictionary.TryAdd(character, strSplitIds);
        }
        return tempDictionary;
    }
    
    /*
    public Dictionary<UnicodeCharacter, IdsBasicRecord> generateIdsMap(string idsPath)
    {
        var idsLines = UtilityFunctions.removeIntroductionLines(idsPath, 2);
        Dictionary<UnicodeCharacter, IdsBasicRecord> tempResult = 
            new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary = 
            new Dictionary<UnicodeCharacter, List<UnicodeCharacter>>();
        var charsToRemove = irrelevantShapeAndLatinCharacters();

        foreach (string input in idsLines)
        {
            string[] splitstr = 
                input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            UnicodeCharacter character = UtilityFunctions.firstUnicodeCharacter(splitstr[1]);
            List<UnicodeCharacter> strSplitIds = UtilityFunctions.CreateUnicodeCharacters(splitstr[2]);

            if (character.Equals(new UnicodeCharacter("𬔦")))
            {
                string testWeird = "";
            }

            tempDictionary.TryAdd(character, strSplitIds);
            List<UnicodeCharacter> rolldOutids = generateRolledOutids(character, tempDictionary);
            var rolledOutWithNoShape = UtilityFunctions.removeUnvantedCharacters(rolldOutids, charsToRemove);
            IdsBasicRecord basic = new IdsBasicRecord(input, rolldOutids, rolledOutWithNoShape);
        
            tempResult.TryAdd(character, basic);
        }

        Dictionary<UnicodeCharacter, IdsBasicRecord> endResult = new Dictionary<UnicodeCharacter, IdsBasicRecord>();
        foreach (var item in tempResult)
        {
            //TODO use the old dictonary and generateRolledOutids function 
        }



        return endResult;
    }
    
    
    private List<UnicodeCharacter> generateRolledOutids(
        UnicodeCharacter character,
        Dictionary<UnicodeCharacter, List<UnicodeCharacter>> tempDictionary)
    {
        List<UnicodeCharacter> temporaryRollOut = new List<UnicodeCharacter>();
        if (tempDictionary.ContainsKey(character))
        {
            if (character.Equals(new UnicodeCharacter("𬔦")))
            {
                string test = "";
            }
            temporaryRollOut = tempDictionary.GetValueOrDefault(character);
        }
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
            List<UnicodeCharacter> toAdd = valueFromDict == null || valueFromDict.Count.Equals(0)
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
    
    */
    
    
    
    
    
    private List<UnicodeCharacter> irrelevantShapeAndLatinCharacters()
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        string ideographicDiscription = UtilityFunctions.ideographicCharacterRange();
        var ideographics = UtilityFunctions.CreateUnicodeCharacters(ideographicDiscription);
        var final = ideographics.Concat(latinCharcters()).ToList();
        return final;
    }

    private List<UnicodeCharacter> latinCharcters()
    {
        string asciiStr = UtilityFunctions.GetAllAsciiCharacters();
        var ascii = UtilityFunctions.CreateUnicodeCharacters(asciiStr);
        return ascii;
    }
    
    public class KeyAsStrConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(UnicodeCharacter));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (UnicodeCharacter)reader.Value.ToString();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }


}