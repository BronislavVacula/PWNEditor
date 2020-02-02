using System;

namespace Base.EventHandlers
{
    /// <summary>
    /// Event arguments for [insert include request].
    /// </summary>
    public class InsertIncludeRequestEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the include.
        /// </summary>
        /// <value>
        /// The include.
        /// </value>
        public string Include { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertIncludeRequestEventArgs" /> class.
        /// </summary>
        /// <param name="include">The include.</param>
        public InsertIncludeRequestEventArgs(string include)
        {
            Include = include;
        }
    }
}
