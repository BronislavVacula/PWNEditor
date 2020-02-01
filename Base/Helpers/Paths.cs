using System.Collections.Generic;
using System.IO;

namespace Base.Helpers
{
    public class Paths
    {
        #region Singleton
        /// <summary>
        /// The instace
        /// </summary>
        private static Paths mInstace;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Paths Instance
        {
            get
            {
                if(mInstace == null)
                    mInstace = new Paths();

                return mInstace;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Paths"/> class from being created.
        /// </summary>
        private Paths() { }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the template path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string GetTemplatePath(string name)
        {
            return $"\\Templates\\{name}.pe";
        }

        /// <summary>
        /// Gets all templates.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllTemplates()
        {
            return Directory.GetFiles("\\Templates\\", "*.pe", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Determines whether [is file template] [the specified file path].
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        ///   <c>true</c> if [is file template] [the specified file path]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFileTemplate(string filePath)
        {
            return Path.GetDirectoryName(filePath).EndsWith("\\Templates\\") && Path.GetExtension(filePath) == ".pe";
        }
        #endregion
    }
}
