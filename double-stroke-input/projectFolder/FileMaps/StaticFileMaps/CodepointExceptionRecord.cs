﻿namespace double_stroke_input.projectFolder.StaticFileMaps;

//this should end up as a dictionary with element to codepointExceptionRecord, 
//hvor element er UnicodeCodepoint, dvs. der skal bruge
//flere 
public record CodepointExceptionRecord(
    UnicodeCharacter character,
    UnicodeCharacter alphabetLetter,
    string rawCodepoint,
    List<UnicodeCharacter> mistakenMatches
    );


////扌目趴  虫木竺
/// 金飣車糽言馬門
/// 
/*
 public record CodepointRecord(
    //UnicodeCharacter[] codepointNumbers,
    string rawCodepoint
    );
*/