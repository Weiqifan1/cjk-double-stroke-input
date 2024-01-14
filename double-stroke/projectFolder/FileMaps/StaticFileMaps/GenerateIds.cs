using double_stroke.projectFolder.FileMaps;

namespace double_stroke.projectFolder.StaticFileMaps;

public class GenerateIds
{
    
    
    
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
    
    
    
    
    
    private List<UnicodeCharacter> irrelevantShapeAndLatinCharacters()
    {
        List<UnicodeCharacter> result = new List<UnicodeCharacter>();
        string ideographicDiscription = UtilityFunctions.ideographicCharacterRange();
        string asciiStr = UtilityFunctions.GetAllAsciiCharacters();
        var ideographics = UtilityFunctions.CreateUnicodeCharacters(ideographicDiscription);
        var ascii = UtilityFunctions.CreateUnicodeCharacters(asciiStr);
        return ideographics.Concat(ascii).ToList();
    }
    
    
    
    
}