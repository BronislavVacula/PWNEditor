using System;

namespace Base.Entities
{
    public class PanelLink
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName { get; set; }

        /// <summary>
        /// Gets or sets the type of panel.
        /// </summary>
        /// <value>
        /// The type of panel.
        /// </value>
        public Type TypeOfPanel { get; set; }

        /// <summary>
        /// The paramater
        /// </summary>
        /// <value>
        /// The paramater.
        /// </value>
        public string Parameter { get; set; }
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelLink"/> class.
        /// </summary>
        /// <param name="buttonName">Name of the button.</param>
        /// <param name="typeOfPanel">The type of panel.</param>
        /// <param name="parameter">The parameter.</param>
        public PanelLink(string buttonName, Type typeOfPanel, string parameter = null)
        {
            ComponentName = buttonName;
            TypeOfPanel = typeOfPanel;
            Parameter = parameter;
        }
        #endregion
    }
}
