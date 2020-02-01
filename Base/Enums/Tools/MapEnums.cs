using System.ComponentModel;

namespace Base.Enums.Tools
{
    public enum MapAction
    {
        [Description("Žádná")]
        None = 1,
        [Description("Spawn")]
        Spawn = 2,
        [Description("Car")]
        Car = 3,
        [Description("Pickup")]
        NovyPickup = 4,
        [Description("GangZone")]
        NovaGangZona = 5
    }
}
