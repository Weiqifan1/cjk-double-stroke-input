using System.Text.RegularExpressions;

namespace double_stroke.projectFolder.StaticFileMaps;

public static class RolloutStrokes
{
    public static HashSet<string> rolloutString(string inputStrings)
    {
        //the input is a single string because each character in the codepoint file
        //can ONLY have one character code.
        HashSet<string> result = PrepareCombinations(inputStrings);
        
        
        return result;
    }
    
    
    private static HashSet<string> PrepareCombinations(string input)
    {
        var results = new HashSet<string> {input};
        var regex = new Regex(@"\(([^)]*)\)");
        
        while (true)
        {
            var newResults = new HashSet<string>();
            var replacementsExists = false;
            
            foreach (var sequence in results)
            {
                var match = regex.Match(sequence);
                if (match.Success)
                {
                    replacementsExists = true;
                    var alternatives = match.Groups[1].Value.Split('|');
                    foreach (var alternative in alternatives)
                    {
                        newResults.Add(sequence.Remove(match.Index, match.Length).Insert(match.Index, alternative));
                    }
                }
                else
                {
                    newResults.Add(sequence);
                }
            }

            results = newResults;
            if (!replacementsExists) 
                break;
        }
        
        return results;
    }

    
    
    
}