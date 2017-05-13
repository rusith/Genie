﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper_TypeDeserializerCache.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class SqlMapper_TypeDeserializerCache : SqlMapper_TypeDeserializerCacheBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nusin" +
                    "g System.Data;\r\nusing System.Text;\r\n\r\nnamespace Indico.DataAccess.Dapper\r\n{\r\n   " +
                    " partial class SqlMapper\r\n    {\r\n\r\n        private class TypeDeserializerCache\r\n" +
                    "        {\r\n            private TypeDeserializerCache(Type type)\r\n            {\r\n" +
                    "                this.type = type;\r\n            }\r\n            static readonly Ha" +
                    "shtable byType = new Hashtable();\r\n            private readonly Type type;\r\n    " +
                    "        internal static void Purge(Type type)\r\n            {\r\n                lo" +
                    "ck (byType)\r\n                {\r\n                    byType.Remove(type);\r\n      " +
                    "          }\r\n            }\r\n            internal static void Purge()\r\n          " +
                    "  {\r\n                lock (byType)\r\n                {\r\n                    byTyp" +
                    "e.Clear();\r\n                }\r\n            }\r\n\r\n            internal static Func" +
                    "<IDataReader, object> GetReader(Type type, IDataReader reader, int startBound, i" +
                    "nt length, bool returnNullIfFirstMissing)\r\n            {\r\n                var fo" +
                    "und = (TypeDeserializerCache)byType[type];\r\n                if (found == null)\r\n" +
                    "                {\r\n                    lock (byType)\r\n                    {\r\n   " +
                    "                     found = (TypeDeserializerCache)byType[type];\r\n             " +
                    "           if (found == null)\r\n                        {\r\n                      " +
                    "      byType[type] = found = new TypeDeserializerCache(type);\r\n                 " +
                    "       }\r\n                    }\r\n                }\r\n                return found" +
                    ".GetReader(reader, startBound, length, returnNullIfFirstMissing);\r\n            }" +
                    "\r\n            private Dictionary<DeserializerKey, Func<IDataReader, object>> rea" +
                    "ders = new Dictionary<DeserializerKey, Func<IDataReader, object>>();\r\n          " +
                    "  struct DeserializerKey : IEquatable<DeserializerKey>\r\n            {\r\n         " +
                    "       private readonly int startBound, length;\r\n                private readonl" +
                    "y bool returnNullIfFirstMissing;\r\n                private readonly IDataReader r" +
                    "eader;\r\n                private readonly string[] names;\r\n                privat" +
                    "e readonly Type[] types;\r\n                private readonly int hashCode;\r\n\r\n    " +
                    "            public DeserializerKey(int hashCode, int startBound, int length, boo" +
                    "l returnNullIfFirstMissing, IDataReader reader, bool copyDown)\r\n                " +
                    "{\r\n                    this.hashCode = hashCode;\r\n                    this.start" +
                    "Bound = startBound;\r\n                    this.length = length;\r\n                " +
                    "    this.returnNullIfFirstMissing = returnNullIfFirstMissing;\r\n\r\n               " +
                    "     if (copyDown)\r\n                    {\r\n                        this.reader =" +
                    " null;\r\n                        names = new string[length];\r\n                   " +
                    "     types = new Type[length];\r\n                        int index = startBound;\r" +
                    "\n                        for (int i = 0; i < length; i++)\r\n                     " +
                    "   {\r\n                            names[i] = reader.GetName(index);\r\n           " +
                    "                 types[i] = reader.GetFieldType(index++);\r\n                     " +
                    "   }\r\n                    }\r\n                    else\r\n                    {\r\n  " +
                    "                      this.reader = reader;\r\n                        names = nul" +
                    "l;\r\n                        types = null;\r\n                    }\r\n              " +
                    "  }\r\n\r\n                public override int GetHashCode()\r\n                {\r\n   " +
                    "                 return hashCode;\r\n                }\r\n                public ove" +
                    "rride string ToString()\r\n                { // only used in the debugger\r\n       " +
                    "             if (names != null)\r\n                    {\r\n                        " +
                    "return string.Join(\", \", names);\r\n                    }\r\n                    if " +
                    "(reader != null)\r\n                    {\r\n                        var sb = new St" +
                    "ringBuilder();\r\n                        int index = startBound;\r\n               " +
                    "         for (int i = 0; i < length; i++)\r\n                        {\r\n          " +
                    "                  if (i != 0) sb.Append(\", \");\r\n                            sb.A" +
                    "ppend(reader.GetName(index++));\r\n                        }\r\n                    " +
                    "    return sb.ToString();\r\n                    }\r\n                    return bas" +
                    "e.ToString();\r\n                }\r\n                public override bool Equals(ob" +
                    "ject obj)\r\n                {\r\n                    return obj is DeserializerKey " +
                    "&& Equals((DeserializerKey)obj);\r\n                }\r\n                public bool" +
                    " Equals(DeserializerKey other)\r\n                {\r\n                    if (this." +
                    "hashCode != other.hashCode\r\n                        || this.startBound != other." +
                    "startBound\r\n                        || this.length != other.length\r\n            " +
                    "            || this.returnNullIfFirstMissing != other.returnNullIfFirstMissing)\r" +
                    "\n                    {\r\n                        return false; // clearly differe" +
                    "nt\r\n                    }\r\n                    for (int i = 0; i < length; i++)\r" +
                    "\n                    {\r\n                        if ((this.names?[i] ?? this.read" +
                    "er?.GetName(startBound + i)) != (other.names?[i] ?? other.reader?.GetName(startB" +
                    "ound + i))\r\n                            ||\r\n                            (this.ty" +
                    "pes?[i] ?? this.reader?.GetFieldType(startBound + i)) != (other.types?[i] ?? oth" +
                    "er.reader?.GetFieldType(startBound + i))\r\n                            )\r\n       " +
                    "                 {\r\n                            return false; // different colum" +
                    "n name or type\r\n                        }\r\n                    }\r\n              " +
                    "      return true;\r\n                }\r\n            }\r\n            private Func<I" +
                    "DataReader, object> GetReader(IDataReader reader, int startBound, int length, bo" +
                    "ol returnNullIfFirstMissing)\r\n            {\r\n                if (length < 0) len" +
                    "gth = reader.FieldCount - startBound;\r\n                int hash = GetColumnHash(" +
                    "reader, startBound, length);\r\n                if (returnNullIfFirstMissing) hash" +
                    " *= -27;\r\n                // get a cheap key first: false means don\'t copy the v" +
                    "alues down\r\n                var key = new DeserializerKey(hash, startBound, leng" +
                    "th, returnNullIfFirstMissing, reader, false);\r\n                Func<IDataReader," +
                    " object> deser;\r\n                lock (readers)\r\n                {\r\n            " +
                    "        if (readers.TryGetValue(key, out deser)) return deser;\r\n                " +
                    "}\r\n                deser = GetTypeDeserializerImpl(type, reader, startBound, len" +
                    "gth, returnNullIfFirstMissing);\r\n                // get a more expensive key: tr" +
                    "ue means copy the values down so it can be used as a key later\r\n                " +
                    "key = new DeserializerKey(hash, startBound, length, returnNullIfFirstMissing, re" +
                    "ader, true);\r\n                lock (readers)\r\n                {\r\n               " +
                    "     return readers[key] = deser;\r\n                }\r\n            }\r\n        }\r\n" +
                    "\r\n    }\r\n}\r\n\r\n");
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
    public class SqlMapper_TypeDeserializerCacheBase
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
