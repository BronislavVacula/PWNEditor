using System;
using System.Windows.Forms;

namespace PawnoEditor.Funkce.Rozsireni
{
    public static class RozsireniRichTextBoxu
    {
        public static RichTextBox PridejRadek(this RichTextBox kam, string text)
        {
            kam.Text = kam.Text == "" ? text : text + Environment.NewLine;

            return kam;
        }
    }
}
