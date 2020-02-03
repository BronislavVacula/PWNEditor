using System.ComponentModel;

namespace Base.Enums
{
    public enum ScriptInsertMode
    {
        [Description("Schránka windows")]
        WindowsClipboard = 1,

        [Description("Aktuálně editovaný soubor")]
        ScinitillaEditor = 2
    }

    public enum CompilationStatus
    {
        [Description("Úspěšná")]
        Success = 1,

        [Description("Neúspěšná")]
        Unsuccess = 2,
    }
}
