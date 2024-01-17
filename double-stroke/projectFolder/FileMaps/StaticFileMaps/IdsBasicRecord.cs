namespace double_stroke.projectFolder.StaticFileMaps;

public record IdsBasicRecord(
    List<UnicodeCharacter> rawIds,
    List<UnicodeCharacter> rolledOutIds,
    List<UnicodeCharacter> rolledOutIdsWithNoShape
    );