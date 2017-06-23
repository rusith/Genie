﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\DapperRow.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DapperRow : DapperRowBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections;\r\nusing System.Collections.Generic;\r\nusin" +
                    "g System.Linq;\r\n\r\nnamespace ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Dapper\DapperRow.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper\r\n{\r\n    partial class SqlMapper\r\n    {\r\n        private sealed class Dapp" +
                    "erRow\r\n            : System.Dynamic.IDynamicMetaObjectProvider\r\n            , ID" +
                    "ictionary<string, object>\r\n        {\r\n            readonly DapperTable table;\r\n " +
                    "           object[] values;\r\n\r\n            public DapperRow(DapperTable table, o" +
                    "bject[] values)\r\n            {\r\n                if (table == null) throw new Arg" +
                    "umentNullException(nameof(table));\r\n                if (values == null) throw ne" +
                    "w ArgumentNullException(nameof(values));\r\n                this.table = table;\r\n " +
                    "               this.values = values;\r\n            }\r\n            private sealed " +
                    "class DeadValue\r\n            {\r\n                public static readonly DeadValue" +
                    " Default = new DeadValue();\r\n                private DeadValue() { }\r\n          " +
                    "  }\r\n            int ICollection<KeyValuePair<string, object>>.Count\r\n          " +
                    "  {\r\n                get\r\n                {\r\n                    int count = 0;\r" +
                    "\n                    for (int i = 0; i < values.Length; i++)\r\n                  " +
                    "  {\r\n                        if (!(values[i] is DeadValue)) count++;\r\n          " +
                    "          }\r\n                    return count;\r\n                }\r\n            }" +
                    "\r\n\r\n            public bool TryGetValue(string name, out object value)\r\n        " +
                    "    {\r\n                var index = table.IndexOfName(name);\r\n                if " +
                    "(index < 0)\r\n                { // doesn\'t exist\r\n                    value = nul" +
                    "l;\r\n                    return false;\r\n                }\r\n                // exi" +
                    "sts, **even if** we don\'t have a value; consider table rows heterogeneous\r\n     " +
                    "           value = index < values.Length ? values[index] : null;\r\n              " +
                    "  if (value is DeadValue)\r\n                { // pretend it isn\'t here\r\n         " +
                    "           value = null;\r\n                    return false;\r\n                }\r\n" +
                    "                return true;\r\n            }\r\n\r\n            public override strin" +
                    "g ToString()\r\n            {\r\n                var sb = GetStringBuilder().Append(" +
                    "\"{DapperRow\");\r\n                foreach (var kv in this)\r\n                {\r\n   " +
                    "                 var value = kv.Value;\r\n                    sb.Append(\", \").Appe" +
                    "nd(kv.Key);\r\n                    if (value != null)\r\n                    {\r\n    " +
                    "                    sb.Append(\" = \'\").Append(kv.Value).Append(\'\\\'\');\r\n          " +
                    "          }\r\n                    else\r\n                    {\r\n                  " +
                    "      sb.Append(\" = NULL\");\r\n                    }\r\n                }\r\n\r\n       " +
                    "         return sb.Append(\'}\').__ToStringRecycle();\r\n            }\r\n\r\n          " +
                    "  System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.Get" +
                    "MetaObject(\r\n                System.Linq.Expressions.Expression parameter)\r\n    " +
                    "        {\r\n                return new DapperRowMetaObject(parameter, System.Dyna" +
                    "mic.BindingRestrictions.Empty, this);\r\n            }\r\n\r\n            public IEnum" +
                    "erator<KeyValuePair<string, object>> GetEnumerator()\r\n            {\r\n           " +
                    "     var names = table.FieldNames;\r\n                for (var i = 0; i < names.Le" +
                    "ngth; i++)\r\n                {\r\n                    object value = i < values.Len" +
                    "gth ? values[i] : null;\r\n                    if (!(value is DeadValue))\r\n       " +
                    "             {\r\n                        yield return new KeyValuePair<string, ob" +
                    "ject>(names[i], value);\r\n                    }\r\n                }\r\n            }" +
                    "\r\n\r\n            IEnumerator IEnumerable.GetEnumerator()\r\n            {\r\n        " +
                    "        return GetEnumerator();\r\n            }\r\n\r\n            #region Implementa" +
                    "tion of ICollection<KeyValuePair<string,object>>\r\n\r\n            void ICollection" +
                    "<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)\r\n         " +
                    "   {\r\n                IDictionary<string, object> dic = this;\r\n                d" +
                    "ic.Add(item.Key, item.Value);\r\n            }\r\n\r\n            void ICollection<Key" +
                    "ValuePair<string, object>>.Clear()\r\n            { // removes values for **this r" +
                    "ow**, but doesn\'t change the fundamental table\r\n                for (int i = 0; " +
                    "i < values.Length; i++)\r\n                    values[i] = DeadValue.Default;\r\n   " +
                    "         }\r\n\r\n            bool ICollection<KeyValuePair<string, object>>.Contain" +
                    "s(KeyValuePair<string, object> item)\r\n            {\r\n                object valu" +
                    "e;\r\n                return TryGetValue(item.Key, out value) && Equals(value, ite" +
                    "m.Value);\r\n            }\r\n\r\n            void ICollection<KeyValuePair<string, ob" +
                    "ject>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)\r\n           " +
                    " {\r\n                foreach (var kv in this)\r\n                {\r\n               " +
                    "     array[arrayIndex++] = kv; // if they didn\'t leave enough space; not our fau" +
                    "lt\r\n                }\r\n            }\r\n\r\n            bool ICollection<KeyValuePai" +
                    "r<string, object>>.Remove(KeyValuePair<string, object> item)\r\n            {\r\n   " +
                    "             IDictionary<string, object> dic = this;\r\n                return dic" +
                    ".Remove(item.Key);\r\n            }\r\n\r\n            bool ICollection<KeyValuePair<s" +
                    "tring, object>>.IsReadOnly => false;\r\n            #endregion\r\n\r\n            #reg" +
                    "ion Implementation of IDictionary<string,object>\r\n\r\n            bool IDictionary" +
                    "<string, object>.ContainsKey(string key)\r\n            {\r\n                int ind" +
                    "ex = table.IndexOfName(key);\r\n                if (index < 0 || index >= values.L" +
                    "ength || values[index] is DeadValue) return false;\r\n                return true;" +
                    "\r\n            }\r\n\r\n            void IDictionary<string, object>.Add(string key, " +
                    "object value)\r\n            {\r\n                SetValue(key, value, true);\r\n     " +
                    "       }\r\n\r\n            bool IDictionary<string, object>.Remove(string key)\r\n   " +
                    "         {\r\n                int index = table.IndexOfName(key);\r\n               " +
                    " if (index < 0 || index >= values.Length || values[index] is DeadValue) return f" +
                    "alse;\r\n                values[index] = DeadValue.Default;\r\n                retur" +
                    "n true;\r\n            }\r\n\r\n            object IDictionary<string, object>.this[st" +
                    "ring key]\r\n            {\r\n                get { object val; TryGetValue(key, out" +
                    " val); return val; }\r\n                set { SetValue(key, value, false); }\r\n    " +
                    "        }\r\n\r\n            public object SetValue(string key, object value)\r\n     " +
                    "       {\r\n                return SetValue(key, value, false);\r\n            }\r\n\r\n" +
                    "            private object SetValue(string key, object value, bool isAdd)\r\n     " +
                    "       {\r\n                if (key == null) throw new ArgumentNullException(nameo" +
                    "f(key));\r\n                int index = table.IndexOfName(key);\r\n                i" +
                    "f (index < 0)\r\n                {\r\n                    index = table.AddField(key" +
                    ");\r\n                }\r\n                else if (isAdd && index < values.Length &" +
                    "& !(values[index] is DeadValue))\r\n                {\r\n                    // then" +
                    " semantically, this value already exists\r\n                    throw new Argument" +
                    "Exception(\"An item with the same key has already been added\", nameof(key));\r\n   " +
                    "             }\r\n                int oldLength = values.Length;\r\n                " +
                    "if (oldLength <= index)\r\n                {\r\n                    // we\'ll assume " +
                    "they\'re doing lots of things, and\r\n                    // grow it to the full wi" +
                    "dth of the table\r\n                    Array.Resize(ref values, table.FieldCount)" +
                    ";\r\n                    for (int i = oldLength; i < values.Length; i++)\r\n        " +
                    "            {\r\n                        values[i] = DeadValue.Default;\r\n         " +
                    "           }\r\n                }\r\n                return values[index] = value;\r\n" +
                    "            }\r\n\r\n            ICollection<string> IDictionary<string, object>.Key" +
                    "s\r\n            {\r\n                get { return this.Select(kv => kv.Key).ToArray" +
                    "(); }\r\n            }\r\n\r\n            ICollection<object> IDictionary<string, obje" +
                    "ct>.Values\r\n            {\r\n                get { return this.Select(kv => kv.Val" +
                    "ue).ToArray(); }\r\n            }\r\n\r\n            #endregion\r\n        }\r\n    }\r\n}");
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
    public class DapperRowBase
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
