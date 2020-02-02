using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.IO;
using System.Windows.Forms;

namespace PawnoEditor.Forms
{
    public partial class fmMain : RibbonForm
    {
        #region Properties and fields
        /// <summary>
        /// The tab control
        /// </summary>
        private TabControlAdv tabControl;
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
            var solutionPanel = CreatePanel<Controls.Panels.ucWorkspaceBrowser>("Solution files");
            var skinsPanel = CreatePanel<Controls.Panels.ucImageList>("Skins", "Skins");
            var carsPanel = CreatePanel<Controls.Panels.ucImageList>("Cars", "Cars");
            var pickupsPanel = CreatePanel<Controls.Panels.ucImageList>("Pickups", "Pickups");

            var includesPanel = CreatePanel<Controls.Panels.ucIncludeList>("Includes");
            var colorPickerPanel = CreatePanel<Controls.Panels.ucColorPicker>("Color picker");

            //Dock settings
            dockingManager.DockControl(solutionPanel, this, DockingStyle.Left, 250); 
            dockingManager.DockControl(carsPanel, solutionPanel, DockingStyle.Bottom, 250, true);
            dockingManager.DockControl(pickupsPanel, carsPanel, DockingStyle.Tabbed, 250, true);
            dockingManager.DockControl(skinsPanel, carsPanel, DockingStyle.Tabbed, 250, true);

            dockingManager.DockControl(includesPanel, this, DockingStyle.Right, 250);
            dockingManager.DockControl(colorPickerPanel, includesPanel, DockingStyle.Bottom, 250);

            //Events
            includesPanel.InsertIncludeRequest += IncludesPanel_InsertIncludeRequest;
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
        /// Creates the file.
        /// </summary>
        private void CreateFile(string filePath = null)
        {
            Components.ScintillaEx editor = new Components.ScintillaEx()
            {
                Parent = this,
                Dock = DockStyle.Fill,
            };

            if (filePath == null)
            {
                editor.OpenTemplate(Path.GetDirectoryName(Application.ExecutablePath));

                CreateFile(editor, "New.pwn");
            }
            else
            {
                editor.OpenFile(filePath);

                CreateFile(editor, Path.GetFileName(filePath));
            }
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
                    if(control is Components.ScintillaEx editor)
                    {
                        return editor;
                    }
                }
            }

            return null;
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateFile(openFileDialog.FileName);
            }
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
                    if(selectedEditor != null)
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
        #endregion
    }
}
