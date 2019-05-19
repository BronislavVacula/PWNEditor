using System;
using System.IO;
using System.Drawing;
using ScintillaNET;
using System.Text;
using PawnoEditor.Funkce.Barvy;

namespace PawnoEditor.Komponenty
{
    public class PTextEdit : Scintilla
    {
        public AutocompleteMenuNS.AutocompleteMenu AutoComplete { get; set; }

        public PTextEdit()
        {
            WrapMode = WrapMode.None;
            IndentationGuides = IndentView.LookBoth;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            CaretForeColor = Color.White;

            NastavBarvuVyberu();
            NastavZvyrazneniSyntaxe();
            NastavFormatovaniCislovani();
            NastavSkladaniKodu();

            if(AutoComplete != null) AutoComplete.TargetControlWrapper = new ScintillaWrapper(this);
        }

        public Color PozadiEditoru { get; set; } = Color.FromArgb(26, 25, 25);
        public Color BarvaTextu { get; set; } = Color.FromArgb(183, 183, 183);

        private void NastavBarvuVyberu()
        {
            SetSelectionBackColor(true, Color.FromArgb(17, 77, 156));
        }

        private void VychoziSyntaxe()
        {
            StyleResetDefault();
            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = 12;
            Styles[Style.Default].BackColor = Color.FromArgb(33, 33, 33);
            Styles[Style.Default].ForeColor = Color.Black;
            StyleClearAll();
        }

        private void NastavKlicovaSlova()
        {
            SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
        }

        private void NastavZvyrazneniSyntaxe()
        {
            VychoziSyntaxe();
            
            Styles[Style.Cpp.Identifier].ForeColor = Prevod.IntRGBNaBarvu(0xD0DAE2);
            Styles[Style.Cpp.Comment].ForeColor = Prevod.IntRGBNaBarvu(0xBD758B);
            Styles[Style.Cpp.CommentLine].ForeColor = Prevod.IntRGBNaBarvu(0x40BF57);
            Styles[Style.Cpp.CommentDoc].ForeColor = Prevod.IntRGBNaBarvu(0x2FAE35);
            Styles[Style.Cpp.Number].ForeColor = Prevod.IntRGBNaBarvu(0xFFFF00);
            Styles[Style.Cpp.String].ForeColor = Prevod.IntRGBNaBarvu(0xFFFF00);
            Styles[Style.Cpp.Character].ForeColor = Prevod.IntRGBNaBarvu(0xE95454);
            Styles[Style.Cpp.Preprocessor].ForeColor = Prevod.IntRGBNaBarvu(0x8AAFEE);
            Styles[Style.Cpp.Operator].ForeColor = Prevod.IntRGBNaBarvu(0xE0E0E0);
            Styles[Style.Cpp.Regex].ForeColor = Prevod.IntRGBNaBarvu(0xff00ff);
            Styles[Style.Cpp.CommentLineDoc].ForeColor = Prevod.IntRGBNaBarvu(0x77A7DB);
            Styles[Style.Cpp.Word].ForeColor = Prevod.IntRGBNaBarvu(0x48A8EE);
            Styles[Style.Cpp.Word2].ForeColor = Prevod.IntRGBNaBarvu(0xF98906);
            Styles[Style.Cpp.CommentDocKeyword].ForeColor = Prevod.IntRGBNaBarvu(0xB3D991);
            Styles[Style.Cpp.CommentDocKeywordError].ForeColor = Prevod.IntRGBNaBarvu(0xFF0000);
            Styles[Style.Cpp.GlobalClass].ForeColor = Prevod.IntRGBNaBarvu(0x48A8EE);

            Styles[Style.Cpp.HashQuotedString].ForeColor = Color.Red;
            Styles[Style.Cpp.PreprocessorComment].ForeColor = Color.Red;

            Lexer = Lexer.Cpp;

            NastavKlicovaSlova();
        }

        private void BarvyPaneluCislovani()
        {
            Styles[Style.LineNumber].BackColor = Color.FromArgb(26, 25, 25);
            Styles[Style.LineNumber].ForeColor = Color.FromArgb(81, 80, 81);

            Styles[Style.IndentGuide].ForeColor = BarvaTextu;
            Styles[Style.IndentGuide].BackColor = PozadiEditoru;
        }

        private void NastavFormatovaniCislovani()
        {
            BarvyPaneluCislovani();

            var nums = Margins[1];
            nums.Width = 50;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        private void NastavSkladaniKodu()
        {
            SetFoldMarginColor(true, PozadiEditoru);
            SetFoldMarginHighlightColor(true, PozadiEditoru);

            SetProperty("fold", "1");
            SetProperty("fold.compact", "1");

            Margins[3].Type = MarginType.Symbol;
            Margins[3].Mask = Marker.MaskFolders;
            Margins[3].Sensitive = true;
            Margins[3].Width = 20;

            for (int i = 25; i <= 31; i++)
            {
                Markers[i].SetForeColor(PozadiEditoru); // styles for [+] and [-]
                Markers[i].SetBackColor(BarvaTextu); // styles for [+] and [-]
            }

            Markers[Marker.Folder].Symbol = true ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            Markers[Marker.FolderOpen].Symbol = true ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            Markers[Marker.FolderEnd].Symbol = true ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            Markers[Marker.FolderOpenMid].Symbol = true ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        public void OtevriSablonu()
        {
            Text = File.ReadAllText(new Data.Soubory.Cesty().Sablona("novy"), Encoding.Default);
        }
    }
}

