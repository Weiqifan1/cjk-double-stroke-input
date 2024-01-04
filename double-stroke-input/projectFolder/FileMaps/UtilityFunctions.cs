using double_stroke_input.projectFolder.StaticFileMaps;

namespace double_stroke_input.projectFolder.FileMaps;

public class UtilityFunctions
{
    public UnicodeCharacter firstUnicodeCharacter(string rawCharacter)
    {
        List<UnicodeCharacter> clean  = CreateUnicodeCharacters(rawCharacter);
        return clean[0];
    }
    
    public List<UnicodeCharacter> CreateUnicodeCharacters(string input)
    {
        var characters = new List<UnicodeCharacter>();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsHighSurrogate(input[i]) && i + 1 < input.Length && char.IsLowSurrogate(input[i + 1]))
            {
                // Unicode character is a surrogate pair
                characters.Add(new UnicodeCharacter(input.Substring(i, 2)));
                i++; // because we processed two chars
            }
            else
            {
                // Unicode character is a single char
                characters.Add(new UnicodeCharacter(input[i].ToString()));
            }
        }
        return characters;
    }
    
}