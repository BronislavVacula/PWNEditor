using System;
using System.Windows.Forms;

namespace Base.Helpers
{
    public class ControlHelper
    {
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
    }
}
