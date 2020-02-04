using System;
using System.Collections.Generic;

namespace Base.Entities.Tools.CodeGenerator
{
    public class CodeGeneratorEntity
    {
        #region Properties and fields
        /// <summary>
        /// The variables
        /// </summary>
        public List<string> Variables = new List<string>();

        /// <summary>
        /// The functions
        /// </summary>
        public List<string> Functions = new List<string>();

        /// <summary>
        /// The embedded code
        /// </summary>
        public List<EmbeddedCodeEntity> EmbeddedCode = new List<EmbeddedCodeEntity>();
        #endregion

        #region Methods
        /// <summary>
        /// Gets the variables string.
        /// </summary>
        /// <returns></returns>
        public string GetVariablesString()
        {
            string result = "";

            foreach (var variable in Variables)
            {
                result += variable + Environment.NewLine;
            }

            return result;
        }

        /// <summary>
        /// Gets the functions string.
        /// </summary>
        /// <returns></returns>
        public string GetFunctionsString()
        {
            string result = "";

            for (int i = 0; i < Functions.Count; i++)
            {
                result += Functions[i] + Environment.NewLine;

                if (i != Functions.Count - 1)
                {
                    result += Environment.NewLine;
                }
            }

            return result;
        }
        #endregion
    }
}
