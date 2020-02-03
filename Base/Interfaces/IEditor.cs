namespace Base.Interfaces
{
    public interface IEditor
    {
        /// <summary>
        /// Gets the opened file.
        /// </summary>
        /// <value>
        /// The opened file.
        /// </value>
        string OpenedFile { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is template.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is template; otherwise, <c>false</c>.
        /// </value>
        bool IsTemplate { get; }
    }
}
