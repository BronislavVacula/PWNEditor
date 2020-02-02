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

    public enum PathsTypes
    {
        [Description("\\images\\")]
        Images = 0,
        [Description("\\include\\")]
        Includes = 1,
        [Description("\\images\\pickups\\")]
        Pickups = 2,
        [Description("\\images\\skins\\")]
        Skins = 3,
        [Description("\\SAMPServer\\")]
        SAMPServer = 4
    }

    public enum CompilationStatus
    {
        [Description("Úspěšná")]
        Success = 1,

        [Description("Neúspěšná")]
        Unsuccess = 2,
    }
}
