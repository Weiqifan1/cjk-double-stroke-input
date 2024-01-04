namespace double_stroke.projectFolder.StaticFileMaps;

public record IdsBasicRecord(
    string rawIds,
    List<UnicodeCharacter> rolledOutIds,
    List<UnicodeCharacter> rolledOutIdsWithNoShape
    );