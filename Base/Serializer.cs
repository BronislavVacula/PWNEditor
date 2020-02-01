using System.IO;
using System.Xml.Serialization;

namespace Base
{
    public class Serializer<T>
    {
        #region Properties and fields
        /// <summary>
        /// The serializer
        /// </summary>
        private readonly XmlSerializer serializer;
        #endregion

        #region Constructor and initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Serializer{T}"/> class.
        /// </summary>
        public Serializer()
        {
            serializer = new XmlSerializer(typeof(T));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Serializes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void Serialize(T instance, string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                serializer.Serialize(tw, instance);
            }
        }

        /// <summary>
        /// Deserializes the specified file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public T Deserialize(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return (T)serializer.Deserialize(sr);
            }
        }
        #endregion
    }
}
