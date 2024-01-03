namespace double_stroke_input.projectFolder.StaticFileMaps;

public record IdsBasicRecord(
    string rawIds,
    List<UnicodeCharacter> rolledOutIds,
    List<UnicodeCharacter> rolledOutIdsWithNoShape
    );