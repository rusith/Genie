﻿namespace Genie.Templates.Infrastructure.Filters.Concrete
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Filters\Concrete\QueryMaker.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class QueryMaker : QueryMakerBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Linq;\r\n\r\nnamespace ");
            
            #line 5 "D:\Projects\Genie\Genie\Templates\Infrastructure\Filters\Concrete\QueryMaker.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Concrete\r\n{\r\n    internal static class QueryMaker\r\n    {\r" +
                    "\n        internal static string EqualsTo(string propertyName, object value, bool" +
                    " quoted)\r\n        {\r\n            return string.Format(\"[{0}] = {2}{1}{2}\", prope" +
                    "rtyName, value, quoted ? \"\'\":\"\");\r\n        }\r\n\r\n        internal static string N" +
                    "otEquals(string propertyName, object value, bool quoted)\r\n        {\r\n           " +
                    " return string.Format(\"[{0}] != {2}{1}{2}\", propertyName, value, quoted ? \"\'\" : " +
                    "\"\");\r\n        }\r\n\r\n        internal static string Contains(string propertyName, " +
                    "object value)\r\n        {\r\n            return string.Format(\"[{0}] LIKE \'%{1}%\'\"," +
                    " propertyName, value);\r\n        }\r\n\r\n        internal static string NotContains(" +
                    "string propertyName, object value)\r\n        {\r\n            return string.Format(" +
                    "\"[{0}] NOT LIKE \'%{1}%\'\", propertyName, value);\r\n        }\r\n\r\n        internal s" +
                    "tatic string StartsWith(string propertyName, object value)\r\n        {\r\n         " +
                    "   return string.Format(\"[{0}] LIKE \'{1}%\'\", propertyName, value);\r\n        }\r\n\r" +
                    "\n        internal static string NotStartsWith(string propertyName, object value)" +
                    "\r\n        {\r\n            return string.Format(\"[{0}] NOT LIKE \'{1}%\'\", propertyN" +
                    "ame, value);\r\n        }\r\n\r\n        internal static string EndsWith(string proper" +
                    "tyName, object value)\r\n        {\r\n            return string.Format(\"[{0}] LIKE \'" +
                    "%{1}\'\", propertyName, value);\r\n        } \r\n\r\n        internal static string NotE" +
                    "ndsWith(string propertyName, object value)\r\n        {\r\n            return string" +
                    ".Format(\"[{0}] NOT LIKE \'%{1}\'\", propertyName, value);\r\n        }\r\n\r\n        int" +
                    "ernal static string IsEmpty(string propertyName)\r\n        {\r\n            return " +
                    "string.Format(\"[{0}] = \'\'\", propertyName);\r\n        }\r\n\r\n        internal static" +
                    " string IsNotEmpty(string propertyName)\r\n        {\r\n            return string.Fo" +
                    "rmat(\"[{0}] != \'\'\", propertyName);\r\n        }\r\n\r\n        internal static string " +
                    "IsNull(string propertyName)\r\n        {\r\n            return string.Format(\"[{0}] " +
                    "IS NULL\", propertyName);\r\n        }\r\n\r\n        internal static string IsNotNull(" +
                    "string propertyName)\r\n        {\r\n            return string.Format(\"[{0}] IS NOT " +
                    "NULL\", propertyName);\r\n        }\r\n\r\n        internal static string GreaterThan(s" +
                    "tring propertyName, object value, bool quoted)\r\n        {\r\n            return st" +
                    "ring.Format(\"[{0}] > {2}{1}{2}\", propertyName, value, quoted ? \"\'\" : \"\");\r\n     " +
                    "   }\r\n\r\n        internal static string LessThan(string propertyName, object valu" +
                    "e, bool quoted)\r\n        {\r\n            return string.Format(\"[{0}] < {2}{1}{2}\"" +
                    ", propertyName, value, quoted ? \"\'\" : \"\");\r\n        }\r\n\r\n        internal static" +
                    " string GreaterThanOrEquals(string propertyName, object value, bool quoted)\r\n   " +
                    "     {\r\n            return string.Format(\"[{0}] >= {2}{1}{2}\", propertyName, val" +
                    "ue, quoted ? \"\'\" : \"\");\r\n        }\r\n\r\n        internal static string LessThanOrE" +
                    "quals(string propertyName, object value, bool quoted)\r\n        {\r\n            re" +
                    "turn string.Format(\"[{0}] <= {2}{1}{2}\", propertyName, value, quoted ? \"\'\" : \"\")" +
                    ";\r\n        }\r\n\r\n        internal static string Between(string propertyName, obje" +
                    "ct from, object to, bool quoted)\r\n        {\r\n            return string.Format(\"(" +
                    "[{0}] >= {2}{1}{2} AND [{0}] <= {2}{3}{2})\", propertyName, from, quoted ? \"\'\" : " +
                    "\"\", to);\r\n        }\r\n\r\n        internal static string IsTrue(string propertyName" +
                    ")\r\n        {\r\n            return string.Format(\"[{0}] = 1\", propertyName);\r\n    " +
                    "    }\r\n\r\n        internal static string IsFalse(string propertyName)\r\n        {\r" +
                    "\n            return string.Format(\"[{0}] = 0\", propertyName);\r\n        }\r\n\r\n    " +
                    "    internal static string In(string propertyName, object[] values, bool quoted)" +
                    "\r\n        {\r\n            return string.Format(\"[{0}] IN({1})\", propertyName, val" +
                    "ues.Aggregate(\"\", (c, n) => c + string.Format(\",{1}{0}{1}\", n, quoted ? \"\'\" : \"\"" +
                    ")).TrimStart(\',\'));\r\n        }\r\n\r\n        internal static string NotIn(string pr" +
                    "opertyName, object[] values, bool quoted)\r\n        {\r\n            return string." +
                    "Format(\"[{0}] NOT IN({1})\", propertyName, values.Aggregate(\"\", (c, n) => c + str" +
                    "ing.Format(\",{1}{0}{1}\", n, quoted ? \"\'\" : \"\")).TrimStart(\',\'));\r\n        }\r\n   " +
                    " }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class QueryMakerBase
    {
        #region Fields

        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;

        #endregion

        #region Properties

        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }

        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }

        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }

        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }

        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }

        #endregion

        #region Transform-time helpers

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }

        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }

        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }

        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }

        #endregion

        #region ToString Helpers

        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;

            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }

            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }

        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();

        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }

        #endregion
    }
    #endregion
}
