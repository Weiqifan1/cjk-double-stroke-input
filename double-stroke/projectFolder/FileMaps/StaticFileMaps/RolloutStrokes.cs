namespace double_stroke.projectFolder.StaticFileMaps;

public static class RolloutStrokes
{
    public static HashSet<string> rolloutString(HashSet<string> inputStrings)
    {
        //the input is a set because each character in the codepoint file
        //can have multiple codes
        HashSet<string> result = new HashSet<string>();
        foreach (string VARIABLE in inputStrings)
        {
            HashSet<string> doRollout = rolloutSingleCode(VARIABLE);
            result.UnionWith(doRollout);
        }
        return result;
    }

    private static HashSet<string> rolloutSingleCode(string variable)
    {
        throw new NotImplementedException();
    }
}