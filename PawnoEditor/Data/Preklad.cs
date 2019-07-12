using System;
using System.Linq;

namespace PawnoEditor.Data
{
    class Preklad
    {
        public string[] Hledane =
        {
            "Error",
            "error",
            "warning",
            "unreachable code",
            "invalid expression, assumed zero",
            "function",
            "is not",
            "implemented",
            "undefined"
        };

        public string[] Nahrazeni =
        {
            "Chyba",
            "chyba",
            "upozornění",
            "nedosažitelný kód",
            "neplatný výraz",
            "funkce",
            "není",
            "implementována",
            "nedefinovaná"
        };

        public string PrelozTextDoCestiny(string text)
        {
            for (int i = 0; i < Hledane.Count(); i++)
                text = text.Replace(Hledane[i], Nahrazeni[i]);

            return text;
        }
    }
}
