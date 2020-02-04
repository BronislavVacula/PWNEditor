using System;
using System.Windows.Forms;

namespace Base.Helpers
{
    public class ControlHelper
    {
        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static T CreatePanel<T>(Control parent, object parameter = null) where T : UserControl
        {
            T panel;

            if (parameter == null)
                panel = (T)Activator.CreateInstance(typeof(T));
            else
                panel = (T)Activator.CreateInstance(typeof(T), parameter);

            panel.Parent = parent;
            panel.Visible = true;

            return panel;
        }

        /// <summary>
        /// Determines whether the specified type of control contains control.
        /// </summary>
        /// <param name="typeOfControl">The type of control.</param>
        /// <param name="controls">The controls.</param>
        /// <returns>
        ///   <c>true</c> if the specified type of control contains control; otherwise, <c>false</c>.
        /// </returns>
        public static object GetControl(Type typeOfControl, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Controls.Count > 0)
                {
                    var foundObject = GetControl(typeOfControl, control.Controls);

                    if (foundObject != null)
                        return foundObject;
                }

                if (control.GetType() == typeOfControl)
                {
                    return control;
                }
            }

            return null;
        }

        /// <summary>
        /// Dispose hidden controls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controls">The controls.</param>
        public static void DisposeHiddenControls<T>(Control.ControlCollection controls) where T: Control
        {
            foreach (Control control in controls)
            {
                if (control.Controls.Count > 0)
                {
                    DisposeHiddenControls<T>(control.Controls);
                }

                if (control is T item)
                {
                    if (item.Visible == false)
                    {
                        item.Dispose();
                    }
                }
            }
        }
    }
}
