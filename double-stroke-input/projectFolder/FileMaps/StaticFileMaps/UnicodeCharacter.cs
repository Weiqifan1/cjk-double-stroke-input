namespace double_stroke_input.projectFolder.StaticFileMaps;

public class UnicodeCharacter
{
    private string value;

    public UnicodeCharacter(string value, string fullLine)
    {
        if (value.Length < 1 || value.Length > 2)
        {
            throw new ArgumentException("Invalid length for Unicode character");
        }
        if (value.Length == 2 && !IsSurrogatePair(value))
        {
            throw new ArgumentException("Invalid length for Unicode character");
        }
        this.value = value;
    }

    public string Value
    {
        get { return this.value; }
    }
    
    private bool IsSurrogatePair(string input)  
    {  
        if (string.IsNullOrEmpty(input))  
        {  
            throw new ArgumentNullException(nameof(input));  
        }  
  
        if (input.Length != 2)  
        {  
            return false;  
        }  
  
        return char.IsHighSurrogate(input[0]) && char.IsLowSurrogate(input[1]);  
    }
    
    
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is UnicodeCharacter))
            return false;
        
        return value == ((UnicodeCharacter) obj).Value;
    }

    public override int GetHashCode()
    {
        return value != null ? value.GetHashCode() : 0;
    }
}