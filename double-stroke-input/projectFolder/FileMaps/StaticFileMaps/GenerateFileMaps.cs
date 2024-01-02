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
        var jundaPath = "../../../projectFolder/StaticFiles/Junda2005.txt";
        var jundaLines = ReadLinesFromFile(jundaPath);
        var tzaiPath = "../../../projectFolder/StaticFiles/Tzai2006.txt";
        var tzaiLines = ReadLinesFromFile(tzaiPath);
        var codepointPath = "../../../projectFolder/StaticFiles/codepoint-character-sequence.txt";
        var codepointLines = removeIntroductionLines(codepointPath, 87);
        var heisigSimpPath = "../../../projectFolder/StaticFiles/heisigSimp.txt";
        var heisigSimpLines = removeIntroductionLines(heisigSimpPath, 3);
        var heisigTradPath = "../../../projectFolder/StaticFiles/heisigTrad.txt";
        var heisigTradLines = removeIntroductionLines(heisigTradPath, 3);
        var idsPath = "../../../projectFolder/StaticFiles/ids.txt";
        var idsLines = removeIntroductionLines(idsPath, 2);
        
        
        var test = "";
    }
    
    private List<string> removeIntroductionLines(string filePath, int introductoryLineLimmit)
    {
        var rawLines = ReadLinesFromFile(filePath);
        var resultLines = rawLines.Skip(introductoryLineLimmit).ToList();
        return resultLines;
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