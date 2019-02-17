using System;

namespace PawnoEditor.Data.SAMPNastroje
{
    public class DMapa
    {
        public enum Akce
        {
            Zadna,
            NovySpawn,
            NoveAuto,
            NovyPickup,
            NovaGangZona
        }

        public class Souradnice
        {
            public float X { get; set; } = 0.0f;
            public float Y { get; set; } = 0.0f;
            public float Z { get; set; } = 0.0f;
        }
    }
}
