namespace double_stroke_input.projectFolder.StaticFileMaps;


using System.Data;
using System;
using System.Collections.Generic;
using System.IO;


public class GenerateJundaMap
{
    public void Run()
    {
        Console.WriteLine("Run - GenerateJundaMap.");
        var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        var jundaLines = ReadLinesFromFile(jundaPath);
        var test = "";
    }
    
    public List<string> ReadLinesFromFile(string filename)
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
}