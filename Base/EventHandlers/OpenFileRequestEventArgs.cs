using System;

namespace Base.EventHandlers
{
    public class OpenFileRequestEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileRequestEventArgs"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public OpenFileRequestEventArgs(string path)
        {
            Path = path;
        }
    }
}
