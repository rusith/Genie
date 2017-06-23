﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper_IDataReader.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class SqlMapper_IDataReader : SqlMapper_IDataReaderBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Data;\r\n\r\nnamespace" +
                    " ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper_IDataReader.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper \r\n{\r\n    partial class SqlMapper\r\n    {\r\n        /// <summary>\r\n        /" +
                    "// Parses a data reader to a sequence of data of the supplied type. Used for des" +
                    "erializing a reader without a connection, etc.\r\n        /// </summary>\r\n        " +
                    "public static IEnumerable<T> Parse<T>(this IDataReader reader)\r\n        {\r\n     " +
                    "       if (reader.Read())\r\n            {\r\n                var deser = GetDeseria" +
                    "lizer(typeof(T), reader, 0, -1, false);\r\n                do\r\n                {\r\n" +
                    "                    yield return (T)deser(reader);\r\n                } while (rea" +
                    "der.Read());\r\n            }\r\n        }\r\n\r\n        /// <summary>\r\n        /// Par" +
                    "ses a data reader to a sequence of data of the supplied type (as object). Used f" +
                    "or deserializing a reader without a connection, etc.\r\n        /// </summary>\r\n  " +
                    "      public static IEnumerable<object> Parse(this IDataReader reader, Type type" +
                    ")\r\n        {\r\n            if (reader.Read())\r\n            {\r\n                var" +
                    " deser = GetDeserializer(type, reader, 0, -1, false);\r\n                do\r\n     " +
                    "           {\r\n                    yield return deser(reader);\r\n                }" +
                    " while (reader.Read());\r\n            }\r\n        }\r\n\r\n        /// <summary>\r\n    " +
                    "    /// Parses a data reader to a sequence of dynamic. Used for deserializing a " +
                    "reader without a connection, etc.\r\n        /// </summary>\r\n        public static" +
                    " IEnumerable<dynamic> Parse(this IDataReader reader)\r\n        {\r\n            if " +
                    "(reader.Read())\r\n            {\r\n                var deser = GetDapperRowDeserial" +
                    "izer(reader, 0, -1, false);\r\n                do\r\n                {\r\n            " +
                    "        yield return deser(reader);\r\n                } while (reader.Read());\r\n " +
                    "           }\r\n        }\r\n\r\n        /// <summary>\r\n        /// Gets the row parse" +
                    "r for a specific row on a data reader. This allows for type switching every row " +
                    "based on, for example, a TypeId column.\r\n        /// You could return a collecti" +
                    "on of the base type but have each more specific.\r\n        /// </summary>\r\n      " +
                    "  /// <param name=\"reader\">The data reader to get the parser for the current row" +
                    " from</param>\r\n        /// <param name=\"type\">The type to get the parser for</pa" +
                    "ram>\r\n        /// <param name=\"startIndex\">The start column index of the object " +
                    "(default 0)</param>\r\n        /// <param name=\"length\">The length of columns to r" +
                    "ead (default -1 = all fields following startIndex)</param>\r\n        /// <param n" +
                    "ame=\"returnNullIfFirstMissing\">Return null if we can\'t find the first column? (d" +
                    "efault false)</param>\r\n        /// <returns>A parser for this specific object fr" +
                    "om this row.</returns>\r\n        public static Func<IDataReader, object> GetRowPa" +
                    "rser(this IDataReader reader, Type type,\r\n            int startIndex = 0, int le" +
                    "ngth = -1, bool returnNullIfFirstMissing = false)\r\n        {\r\n            return" +
                    " GetDeserializer(type, reader, startIndex, length, returnNullIfFirstMissing);\r\n " +
                    "       }\r\n\r\n        /// <summary>\r\n        /// Gets the row parser for a specifi" +
                    "c row on a data reader. This allows for type switching every row based on, for e" +
                    "xample, a TypeId column.\r\n        /// You could return a collection of the base " +
                    "type but have each more specific.\r\n        /// </summary>\r\n        /// <param na" +
                    "me=\"reader\">The data reader to get the parser for the current row from</param>\r\n" +
                    "        /// <param name=\"concreteType\">The type to get the parser for</param>\r\n " +
                    "       /// <param name=\"startIndex\">The start column index of the object (defaul" +
                    "t 0)</param>\r\n        /// <param name=\"length\">The length of columns to read (de" +
                    "fault -1 = all fields following startIndex)</param>\r\n        /// <param name=\"re" +
                    "turnNullIfFirstMissing\">Return null if we can\'t find the first column? (default " +
                    "false)</param>\r\n        /// <returns>A parser for this specific object from this" +
                    " row.</returns>\r\n        /// <example>\r\n        /// var result = new List&lt;Bas" +
                    "eType&gt;();\r\n        /// using (var reader = connection.ExecuteReader(@\"\r\n     " +
                    "   ///   select \'abc\' as Name, 1 as Type, 3.0 as Value\r\n        ///   union all\r" +
                    "\n        ///   select \'def\' as Name, 2 as Type, 4.0 as Value\"))\r\n        /// {\r\n" +
                    "        ///     if (reader.Read())\r\n        ///     {\r\n        ///         var t" +
                    "oFoo = reader.GetRowParser&lt;BaseType&gt;(typeof(Foo));\r\n        ///         va" +
                    "r toBar = reader.GetRowParser&lt;BaseType&gt;(typeof(Bar));\r\n        ///        " +
                    " var col = reader.GetOrdinal(\"Type\");\r\n        ///         do\r\n        ///      " +
                    "   {\r\n        ///             switch (reader.GetInt32(col))\r\n        ///        " +
                    "     {\r\n        ///                 case 1:\r\n        ///                     res" +
                    "ult.Add(toFoo(reader));\r\n        ///                     break;\r\n        ///    " +
                    "             case 2:\r\n        ///                     result.Add(toBar(reader));" +
                    "\r\n        ///                     break;\r\n        ///             }\r\n        ///" +
                    "         } while (reader.Read());\r\n        ///     }\r\n        /// }\r\n        ///" +
                    "  \r\n        /// abstract class BaseType\r\n        /// {\r\n        ///     public a" +
                    "bstract int Type { get; }\r\n        /// }\r\n        /// class Foo : BaseType\r\n    " +
                    "    /// {\r\n        ///     public string Name { get; set; }\r\n        ///     pub" +
                    "lic override int Type =&gt; 1;\r\n        /// }\r\n        /// class Bar : BaseType\r" +
                    "\n        /// {\r\n        ///     public float Value { get; set; }\r\n        ///   " +
                    "  public override int Type =&gt; 2;\r\n        /// }\r\n        /// </example>\r\n    " +
                    "    public static Func<IDataReader, T> GetRowParser<T>(this IDataReader reader, " +
                    "Type concreteType = null,\r\n            int startIndex = 0, int length = -1, bool" +
                    " returnNullIfFirstMissing = false)\r\n        {\r\n            if (concreteType == n" +
                    "ull) concreteType = typeof(T);\r\n            var func = GetDeserializer(concreteT" +
                    "ype, reader, startIndex, length, returnNullIfFirstMissing);\r\n            if (con" +
                    "creteType.IsValueType)\r\n            {\r\n                return _ => (T)func(_);\r\n" +
                    "            }\r\n            else\r\n            {\r\n                return (Func<IDa" +
                    "taReader, T>)(Delegate)func;\r\n            }\r\n        }\r\n    }\r\n}\r\n");
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
    public class SqlMapper_IDataReaderBase
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
