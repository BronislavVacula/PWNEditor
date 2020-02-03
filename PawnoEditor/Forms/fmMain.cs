using Base.Constants;
using Base.Interfaces;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawnoEditor.Forms
{
    public partial class fmMain : RibbonForm, IApplicationPath
    {
        #region Properties and fields
        /// <summary>
        /// The tab control
        /// </summary>
        private TabControlAdv tabControl;

        /// <summary>
        /// The compiler control
        /// </summary>
        private Controls.Panels.ucCompiler compilerControl;

        /// <summary>
        /// The workspace browser
        /// </summary>
        private Controls.Panels.ucWorkspaceBrowser workspaceBrowser;

        /// <summary>
        /// The workspace serializer
        /// </summary>
        private Base.Serializer<Base.Entities.Workspace> workspaceSerializer = new Base.Serializer<Base.Entities.Workspace>();

        /// <summary>
        /// Gets the application path.
        /// </summary>
        /// <value>
        /// The application path.
        /// </value>
        public string AppPath
        {
            get
            {
                return Application.ExecutablePath;
            }
        }
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="fmMain"/> class.
        /// </summary>
        public fmMain()
        {
            InitializeComponent();
            InitializeStyles();
            InitializeMdiManager();
            InitPanels();
        }

        /// <summary>
        /// Initializes the styles.
        /// </summary>
        private void InitializeStyles()
        {
            InitializeDockingManager();
            InitializeMessageBox();
        }

        /// <summary>
        /// Initializes the docking manager.
        /// </summary>
        private void InitializeDockingManager()
        {
            dockingManager.Office2007MdiColorScheme = Office2007Theme.Silver;
            dockingManager.Office2007MdiChildForm = true;
        }

        /// <summary>
        /// Initializes the MDI manager.
        /// </summary>
        private void InitializeMdiManager()
        {
            mdiManager.AttachToMdiContainer(this);
        }

        /// <summary>
        /// Initializes the message box.
        /// </summary>
        private void InitializeMessageBox()
        {
            MessageBoxAdv.ThemeName = "Office2016";
        }

        /// <summary>
        /// Initializes the panels.
        /// </summary>
        private void InitPanels()
        {
            //Create panel
            workspaceBrowser = CreatePanel<Controls.Panels.ucWorkspaceBrowser>("Solution files");
            var skinsPanel = CreatePanel<Controls.Panels.ucImageList>("Skins", "Skins");
            var carsPanel = CreatePanel<Controls.Panels.ucImageList>("Cars", "Cars");
            var pickupsPanel = CreatePanel<Controls.Panels.ucImageList>("Pickups", "Pickups");

            var includesPanel = CreatePanel<Controls.Panels.ucIncludeList>("Includes");
            var colorPickerPanel = CreatePanel<Controls.Panels.ucColorPicker>("Color picker");

            workspaceBrowser.CreateWorkspace("Workspace");

            //Dock settings
            dockingManager.DockControl(workspaceBrowser, this, DockingStyle.Left, 250);
            dockingManager.DockControl(carsPanel, workspaceBrowser, DockingStyle.Bottom, 250, true);
            dockingManager.DockControl(pickupsPanel, carsPanel, DockingStyle.Tabbed, 250, true);
            dockingManager.DockControl(skinsPanel, carsPanel, DockingStyle.Tabbed, 250, true);

            dockingManager.DockControl(includesPanel, this, DockingStyle.Right, 250);
            dockingManager.DockControl(colorPickerPanel, includesPanel, DockingStyle.Bottom, 250);

            //Events
            includesPanel.InsertIncludeRequest += IncludesPanel_InsertIncludeRequest;
            workspaceBrowser.OpenFileRequest += WorkspaceBrowser_OpenFileRequest;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title">The title.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private T CreatePanel<T>(string title, string parameter = null) where T : UserControl
        {
            var panel = CreatePanel<T>((object)parameter);

            CreatePanel<T>(title, panel);

            return panel;
        }

        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <typeparam name="PanelType">The type of the anel type.</typeparam>
        /// <param name="startingPath">The starting path.</param>
        /// <returns></returns>
        private T CreatePanel<T>(object parameter = null) where T : UserControl
        {
            T panel;

            if (parameter == null)
                panel = (T)Activator.CreateInstance(typeof(T));
            else
                panel = (T)Activator.CreateInstance(typeof(T), parameter);

            panel.Parent = this;
            panel.Visible = true;

            return panel;
        }

        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <param name="uc">The uc.</param>
        public void CreatePanel<T>(string title, T panel) where T : UserControl
        {
            dockingManager.SetEnableDocking(panel, true);
            dockingManager.SetDockLabel(panel, title);
        }

        /// <summary>
        /// Determines whether [is file already opened] [the specified file path].
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        ///   <c>true</c> if [is file already opened] [the specified file path]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFileAlreadyOpened(string filePath)
        {
            foreach (var form in mdiManager.MdiChildren)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is Components.ScintillaEx editor)
                    {
                        if (editor.OpenedFile == filePath)
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        private void CreateFile(string filePath = null)
        {
            if (filePath == null)
            {
                var editor = CreateEditor();

                editor.OpenTemplate(Path.GetDirectoryName(Application.ExecutablePath));

                CreateFile(editor, "New.pwn");
            }
            else
            {
                if (!IsFileAlreadyOpened(filePath))
                {
                    var editor = CreateEditor();

                    editor.OpenFile(filePath);

                    workspaceBrowser.AddFile(filePath, editor);

                    CreateFile(editor, Path.GetFileName(filePath));
                }
                else
                {
                    MessageBoxAdv.Show("Selected file is already opened.");
                }
            }
        }

        /// <summary>
        /// Creates the editor.
        /// </summary>
        /// <returns></returns>
        private Components.ScintillaEx CreateEditor()
        {
            var editor = new Components.ScintillaEx()
            {
                Parent = this,
                Dock = DockStyle.Fill,
            };

            editor.EditorStateChanged += Editor_EditorStateChanged;

            return editor;
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="fileName">Name of the file.</param>
        private void CreateFile(Components.ScintillaEx editor, string fileName)
        {
            dockingManager.SetEnableDocking(editor, true);
            dockingManager.SetDockLabel(editor, fileName);
            dockingManager.SetAsMDIChild(editor, true);

            CheckClosedTabs(Controls);
        }

        /// <summary>
        /// Gets the selected editor.
        /// </summary>
        /// <param name="controls">The controls.</param>
        /// <returns></returns>
        private Components.ScintillaEx GetSelectedEditor()
        {
            foreach (var form in mdiManager.MdiChildren)
            {
                if (mdiManager.GetTabPageAdvFromForm(form) != tabControl.SelectedTab)
                    continue;

                foreach (Control control in form.Controls)
                {
                    if (control is Components.ScintillaEx editor)
                    {
                        return editor;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Checks the closed tabs.
        /// </summary>
        private void CheckClosedTabs(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Controls.Count > 0)
                {
                    CheckClosedTabs(control.Controls);
                }

                if (control is Components.ScintillaEx editor)
                {
                    if (editor.Visible == false)
                    {
                        editor.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Updates the tab page text.
        /// </summary>
        /// <param name="editor">The editor.</param>
        private void UpdateTabPageText(Components.ScintillaEx editor)
        {
            if (editor.Parent is Form parentForm)
            {
                var tabPage = mdiManager.GetTabPageAdvFromForm(parentForm);

                tabPage.Text = Path.GetFileName(editor.OpenedFile);
            }
        }

        /// <summary>
        /// Saves the editor.
        /// </summary>
        /// <param name="editor">The editor.</param>
        private void SaveEditor(Components.ScintillaEx editor)
        {
            if (editor != null)
            {
                if (editor.IsTemplate && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    editor.SaveFile(saveFileDialog.FileName);

                    workspaceBrowser.AddFile(saveFileDialog.FileName, editor);

                    UpdateTabPageText(editor);
                }
                else
                {
                    editor.SaveFile();
                }
            }
        }

        /// <summary>
        /// Compiles the file.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <returns></returns>
        private bool CompileFile(Components.ScintillaEx editor)
        {
            if (!editor.IsTemplate && !editor.IsModified)
            {
                var compilerDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                List<Base.Entities.CompilerMessageItem> result 
                    = Base.Facades.SampServer.Instance.BuildGamemode(compilerDirectory, editor.OpenedFile);

                if(result != null)
                {
                    var errorCount = result.Count;

                    ShowCompilerErrors(result);

                    return errorCount == 0;
                }
            }
            else
            {
                MessageBoxAdv.Show("Soubor není uložený, nelze jej zkompilovat.");
            }

            return true;
        }

        /// <summary>
        /// Runs the game mode.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <returns></returns>
        private bool RunGameMode(Components.ScintillaEx editor)
        {
            if(CompileFile(editor))
            {
                var compiledFilePath = Path.GetDirectoryName(editor.OpenedFile) + "\\" + Path.GetFileNameWithoutExtension(editor.OpenedFile) + ".amx";
                var serversPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + EditorPaths.servers;

                var servers = Base.Facades.SampServer.Instance.GetServers(serversPath);
                if (servers.Count() > 0)
                {
                    Base.Facades.SampServer.Instance.Run(compiledFilePath, serversPath, servers.OrderBy(s => s).FirstOrDefault());
                }
            }

            return false;
        }

        /// <summary>
        /// Shows the compiler errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        private void ShowCompilerErrors(List<Base.Entities.CompilerMessageItem> errors)
        {
            if (compilerControl == null)
            {
                compilerControl = CreatePanel<Controls.Panels.ucCompiler>("Compiler");

                dockingManager.DockControl(compilerControl, this, DockingStyle.Bottom, 200);
            }

            compilerControl.ShowErrors(errors);
        }

        /// <summary>
        /// Determines whether this instance [can create workspace].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can create workspace]; otherwise, <c>false</c>.
        /// </returns>
        private bool CanCreateWorkspace()
        {
            if (tabControl?.TabCount > 0 || workspaceBrowser.workspace.Items.Count > 0)
            {
                if(MessageBoxAdv.Show("All unsaved data will be lost. Continue?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Closes all opened tabs.
        /// </summary>
        private void CloseAllOpenedTabs()
        {
            foreach (var form in mdiManager.MdiChildren)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is Components.ScintillaEx editor)
                    {
                        editor.Dispose();
                    }
                }

                form.Close();
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Handles the Click event of the btnNewFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        /// <summary>
        /// Handles the Click event of the btnOpenFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Pwn files (*.pwn)|*.pwn|Include files (*.inc)|*.inc|Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateFile(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles the OpenFileRequest event of the WorkspaceBrowser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Base.EventHandlers.OpenFileRequestEventArgs"/> instance containing the event data.</param>
        private void WorkspaceBrowser_OpenFileRequest(object sender, Base.EventHandlers.OpenFileRequestEventArgs e)
        {
            CreateFile(e.Path);
        }

        /// <summary>
        /// Handles the TabControlAdded event of the mdiManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="TabbedMDITabControlEventArgs"/> instance containing the event data.</param>
        private void mdiManager_TabControlAdded(object sender, TabbedMDITabControlEventArgs args)
        {
            tabControl = args.TabControl;
        }

        /// <summary>
        /// Handles the TabControlRemoved event of the mdiManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="TabbedMDITabControlEventArgs"/> instance containing the event data.</param>
        private void mdiManager_TabControlRemoved(object sender, TabbedMDITabControlEventArgs args)
        {
            tabControl = null;
        }

        /// <summary>
        /// Handles the InsertIncludeRequest event of the IncludesPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Base.EventHandlers.InsertIncludeRequestEventArgs"/> instance containing the event data.</param>
        private void IncludesPanel_InsertIncludeRequest(object sender, Base.EventHandlers.InsertIncludeRequestEventArgs e)
        {
            if (Base.Settings.Instance.ScriptInsertMode == Base.Enums.ScriptInsertMode.ScinitillaEditor && tabControl != null)
            {
                if (tabControl.TabCount > 0)
                {
                    var selectedEditor = GetSelectedEditor();
                    if (selectedEditor != null)
                    {
                        selectedEditor.InsertText(selectedEditor.CurrentPosition, e.Include);
                    }
                }
            }
            else
            {
                Clipboard.SetText(e.Include);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tabControl.TabCount > 0)
            {
                var selectedEditor = GetSelectedEditor();

                SaveEditor(selectedEditor);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveFileAs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveFileAs_Click(object sender, EventArgs e)
        {
            var selectedEditor = GetSelectedEditor();

            if (selectedEditor != null)
            {
                saveFileDialog.Filter = "Pwn files (*.pwn)|*.pwn|Include files (*.inc)|*.inc|Text files (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedEditor.SaveFile(saveFileDialog.FileName);

                    UpdateTabPageText(selectedEditor);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            foreach (var form in mdiManager.MdiChildren)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is Components.ScintillaEx editor)
                    {
                        SaveEditor(editor);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            var selectedEditor = GetSelectedEditor();

            if(selectedEditor != null)
            {
                if(selectedEditor.CanUndo)
                    selectedEditor.Undo();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnForward control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnForward_Click(object sender, EventArgs e)
        {
            var selectedEditor = GetSelectedEditor();

            if (selectedEditor != null)
            {
                if (selectedEditor.CanRedo)
                    selectedEditor.Redo();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCompile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompile_Click(object sender, EventArgs e)
        {
            var selectedEditor = GetSelectedEditor();

            if(selectedEditor != null)
            {
                CompileFile(selectedEditor);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCompileAndRun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompileAndRun_Click(object sender, EventArgs e)
        {
            var selectedEditor = GetSelectedEditor();

            if(selectedEditor != null)
            {
                RunGameMode(selectedEditor);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCreateWorkspace control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCreateWorkspace_Click(object sender, EventArgs e)
        {
            if (CanCreateWorkspace())
            {
                workspaceBrowser.ClearWorkspace();
                workspaceBrowser.CreateWorkspace("Workspace");

                foreach (Form form in mdiManager.MdiChildren)
                {
                    if(form.Controls.Count > 0 && form.Controls[0] is Components.ScintillaEx editor)
                    {
                        editor.Dispose();
                    }

                    form.Close();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveWorkspace control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSaveWorkspace_Click(object sender, EventArgs e)
        {
            if(workspaceBrowser.workspace != null)
            {
                saveFileDialog.Filter = "Workspace (*.pws)|*.pws";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workspaceSerializer.Serialize(workspaceBrowser.workspace, saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBoxAdv.Show("Workspace is not created!");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOpenWorkspace control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOpenWorkspace_Click(object sender, EventArgs e)
        {
            if(workspaceBrowser.workspace != null && workspaceBrowser.workspace.Items.Count > 0)
            {
                if(MessageBoxAdv.Show("All unsaved data will be lost. Continue?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            CloseAllOpenedTabs();

            openFileDialog.Filter = "Workspace (*.pws)|*.pws";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var workspace = workspaceSerializer.Deserialize(openFileDialog.FileName);

                workspaceBrowser.LoadWorkspace(workspace);
            }
        }

        /// <summary>
        /// Handles the EditorStateChanged event of the Editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Base.EventHandlers.EditorStateChangedEventArgs"/> instance containing the event data.</param>
        private void Editor_EditorStateChanged(object sender, Base.EventHandlers.EditorStateChangedEventArgs e)
        {
            if(sender is Components.ScintillaEx editor)
            {
                var parentForm = editor.Parent as Form;
                var tabPage = mdiManager.GetTabPageAdvFromForm(parentForm);

                if (editor.OpenedFile != null)
                {
                    if (editor.IsModified)
                    {
                        tabPage.Text = Path.GetFileName(editor.OpenedFile) + "*";
                    }
                    else
                    {
                        tabPage.Text = Path.GetFileName(editor.OpenedFile);
                    }
                }
            }
        }
        #endregion
    }
}
