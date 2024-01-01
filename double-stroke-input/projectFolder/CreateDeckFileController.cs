using double_stroke_input.projectFolder.StaticFileMaps;

namespace double_stroke_input.projectFolder;

public class CreateDeckFileController
{
    public void myFunction()
    {
        Console.WriteLine("Hello, this is my function.");
        GenerateJundaMap genJunda = new GenerateJundaMap();
        genJunda.Run();
    }
    
}