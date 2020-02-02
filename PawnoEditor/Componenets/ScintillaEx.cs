using System.IO;
using System.Text;
using System.Drawing;
using ScintillaNET;

namespace PawnoEditor.Components
{
    public class ScintillaEx : Scintilla
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the automatic complete.
        /// </summary>
        /// <value>
        /// The automatic complete.
        /// </value>
        public AutocompleteMenuNS.AutocompleteMenu AutoComplete { get; set; }

        /// <summary>
        /// Gets or sets the opened file.
        /// </summary>
        /// <value>
        /// The opened file.
        /// </value>
        public string OpenedFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is template.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is template; otherwise, <c>false</c>.
        /// </value>
        public bool IsTemplate { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is modified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is modified; otherwise, <c>false</c>.
        /// </value>
        public bool IsModified { get; private set; }
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ScintillaEx"/> class.
        /// </summary>
        public ScintillaEx()
        {
            WrapMode = WrapMode.None;
            IndentationGuides = IndentView.LookBoth;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            CaretForeColor = Color.White;

            BackColor = Color.FromArgb(26, 25, 25);
            ForeColor = Color.FromArgb(183, 183, 183);

            InitStyles();
            InitNumberFormat();

            SetKeywords();

            if (AutoComplete != null) 
                AutoComplete.TargetControlWrapper = new ScintillaWrapper(this);
        }

        /// <summary>
        /// Initializes the styles.
        /// </summary>
        private void InitStyles()
        {
            InitSelectionColor();
            InitDefaultStyle();
            InitSyntaxHiglightStyle();
            InitLineNumberStyle();
            InitMarkersStyle();
        }

        /// <summary>
        /// Initializes the color of the selection.
        /// </summary>
        private void InitSelectionColor()
        {
            SetSelectionBackColor(true, Color.FromArgb(17, 77, 156));
        }

        /// <summary>
        /// Initializes the default syntax.
        /// </summary>
        private void InitDefaultStyle()
        {
            StyleResetDefault();

            Styles[Style.Default].Font = "Consolas";
            Styles[Style.Default].Size = 12;
            Styles[Style.Default].BackColor = Color.FromArgb(33, 33, 33);
            Styles[Style.Default].ForeColor = Color.Black;

            StyleClearAll();
        }

        /// <summary>
        /// Sets the keywords.
        /// </summary>
        private void SetKeywords()
        {
            SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
        }

        /// <summary>
        /// Initializes the style of syntax.
        /// </summary>
        private void InitSyntaxHiglightStyle()
        {
            Styles[Style.Cpp.Identifier].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xD0DAE2);
            Styles[Style.Cpp.Comment].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xBD758B);
            Styles[Style.Cpp.CommentLine].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x40BF57);
            Styles[Style.Cpp.CommentDoc].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x2FAE35);
            Styles[Style.Cpp.Number].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xFFFF00);
            Styles[Style.Cpp.String].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xFFFF00);
            Styles[Style.Cpp.Character].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xE95454);
            Styles[Style.Cpp.Preprocessor].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x8AAFEE);
            Styles[Style.Cpp.Operator].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xE0E0E0);
            Styles[Style.Cpp.Regex].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xff00ff);
            Styles[Style.Cpp.CommentLineDoc].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x77A7DB);
            Styles[Style.Cpp.Word].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x48A8EE);
            Styles[Style.Cpp.Word2].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xF98906);
            Styles[Style.Cpp.CommentDocKeyword].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xB3D991);
            Styles[Style.Cpp.CommentDocKeywordError].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0xFF0000);
            Styles[Style.Cpp.GlobalClass].ForeColor = Base.Helpers.ColorHelper.ConvertRgbToColor(0x48A8EE);

            Styles[Style.Cpp.HashQuotedString].ForeColor = Color.Red;
            Styles[Style.Cpp.PreprocessorComment].ForeColor = Color.Red;

            Lexer = Lexer.Cpp;
        }

        /// <summary>
        /// Initializes the line number style.
        /// </summary>
        private void InitLineNumberStyle()
        {
            Styles[Style.LineNumber].BackColor = Color.FromArgb(26, 25, 25);
            Styles[Style.LineNumber].ForeColor = Color.FromArgb(81, 80, 81);

            Styles[Style.IndentGuide].ForeColor = ForeColor;
            Styles[Style.IndentGuide].BackColor = BackColor;
        }

        /// <summary>
        /// Initializes the number format.
        /// </summary>
        private void InitNumberFormat()
        {
            Margin nums = Margins[1];
            nums.Width = 50;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        /// <summary>
        /// Initializes the markers style.
        /// </summary>
        private void InitMarkersStyle()
        {
            SetFoldMarginColor(true, BackColor);
            SetFoldMarginHighlightColor(true, BackColor);

            SetProperty("fold", "1");
            SetProperty("fold.compact", "1");

            Margins[3].Type = MarginType.Symbol;
            Margins[3].Mask = Marker.MaskFolders;
            Margins[3].Sensitive = true;
            Margins[3].Width = 20;

            for (int i = 25; i <= 31; i++)
            {
                Markers[i].SetForeColor(BackColor); // styles for [+] and [-]
                Markers[i].SetBackColor(ForeColor); // styles for [+] and [-]
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
        #endregion

        #region Methods
        /// <summary>
        /// Opens the template.
        /// </summary>
        /// <param name="applicationPath">The application path.</param>
        public void OpenTemplate(string applicationPath)
        {
            IsTemplate = true;

            var filePath = applicationPath + Base.Helpers.Paths.Instance.GetTemplatePath("new");

            OpenFile(filePath);
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void OpenFile(string path)
        {
            try
            {
                Text = File.ReadAllText(path, Encoding.Default);
            }
            catch { return; }

            OpenedFile = path;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public bool SaveFile(string path = null)
        {
            if (!IsTemplate || path != null)
            {
                OpenedFile = path;
                IsTemplate = false;

                try
                {
                    File.WriteAllText(path, Text);

                    return true;
                }
                catch { }
            }

            return false;
        }
        #endregion
    }
}