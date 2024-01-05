﻿namespace double_stroke.projectFolder.StaticFileMaps;

public record CodepointWithExceptionRecord(
    CodepointExceptionRecord? idsException,
    List<CodepointExceptionRecord> codepointExceptions,
    CodepointBasicRecord originalCodepoint,
    string codepointAfterExceptionremoval,
    UnicodeCharacter letter,
    IdsBasicRecord? idsLookup);