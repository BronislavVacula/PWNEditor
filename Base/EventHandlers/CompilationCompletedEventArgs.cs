using Base.Enums;
using System;
using System.Collections.Generic;

namespace Base.EventHandlers
{
    public class CompilationCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        public string File { get; private set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public CompilationStatus Status { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<string> Errors { get; private set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationCompletedEventArgs"/> class.
        /// </summary>
        public CompilationCompletedEventArgs(string filePath, CompilationStatus status, List<string> errors)
        {
            File = filePath;
            Status = status;
            Errors = errors;
        }
    }
}
