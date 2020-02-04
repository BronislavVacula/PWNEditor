using System.Windows.Forms;

namespace Base.Entities
{
    public class PanelEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>
        /// The control.
        /// </value>
        public UserControl Control { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelEntity"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="control">The control.</param>
        public PanelEntity(string name, UserControl control)
        {
            Name = name;
            Control = control;
        }
    }
}
