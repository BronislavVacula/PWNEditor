using System.Collections.Generic;

namespace Base.Entities.Tools.CodeGenerator
{
    public class CodeGeneratorEntity
    {
        /// <summary>
        /// The variables
        /// </summary>
        public List<string> Variables = new List<string>();

        /// <summary>
        /// The functions
        /// </summary>
        public List<string> Functions = new List<string>();

        /// <summary>
        /// The methods
        /// </summary>
        public List<string> Methods = new List<string>();

        /// <summary>
        /// The embedded code
        /// </summary>
        public List<EmbeddedCodeEntity> EmbeddedCode = new List<EmbeddedCodeEntity>();
    }
}
