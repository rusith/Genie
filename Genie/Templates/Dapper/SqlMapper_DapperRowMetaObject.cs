﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper_DapperRowMetaObject.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class SqlMapper_DapperRowMetaObject : SqlMapper_DapperRowMetaObjectBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Reflection;\r\n\r\nnam" +
                    "espace ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper_DapperRowMetaObject.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper \r\n{\r\n    partial class SqlMapper\r\n    {\r\n        sealed class DapperRowMe" +
                    "taObject : System.Dynamic.DynamicMetaObject\r\n        {\r\n            static reado" +
                    "nly MethodInfo getValueMethod = typeof(IDictionary<string, object>).GetProperty(" +
                    "\"Item\").GetGetMethod();\r\n            static readonly MethodInfo setValueMethod =" +
                    " typeof(DapperRow).GetMethod(\"SetValue\", new Type[] { typeof(string), typeof(obj" +
                    "ect) });\r\n\r\n            public DapperRowMetaObject(\r\n                System.Linq" +
                    ".Expressions.Expression expression,\r\n                System.Dynamic.BindingRestr" +
                    "ictions restrictions\r\n                )\r\n                : base(expression, rest" +
                    "rictions)\r\n            {\r\n            }\r\n\r\n            public DapperRowMetaObjec" +
                    "t(\r\n                System.Linq.Expressions.Expression expression,\r\n            " +
                    "    System.Dynamic.BindingRestrictions restrictions,\r\n                object val" +
                    "ue\r\n                )\r\n                : base(expression, restrictions, value)\r\n" +
                    "            {\r\n            }\r\n\r\n            System.Dynamic.DynamicMetaObject Cal" +
                    "lMethod(\r\n                MethodInfo method,\r\n                System.Linq.Expres" +
                    "sions.Expression[] parameters\r\n                )\r\n            {\r\n               " +
                    " var callMethod = new System.Dynamic.DynamicMetaObject(\r\n                    Sys" +
                    "tem.Linq.Expressions.Expression.Call(\r\n                        System.Linq.Expre" +
                    "ssions.Expression.Convert(Expression, LimitType),\r\n                        metho" +
                    "d,\r\n                        parameters),\r\n                    System.Dynamic.Bin" +
                    "dingRestrictions.GetTypeRestriction(Expression, LimitType)\r\n                    " +
                    ");\r\n                return callMethod;\r\n            }\r\n\r\n            public over" +
                    "ride System.Dynamic.DynamicMetaObject BindGetMember(System.Dynamic.GetMemberBind" +
                    "er binder)\r\n            {\r\n                var parameters = new System.Linq.Expr" +
                    "essions.Expression[]\r\n                                     {\r\n                  " +
                    "                       System.Linq.Expressions.Expression.Constant(binder.Name)\r" +
                    "\n                                     };\r\n\r\n                var callMethod = Cal" +
                    "lMethod(getValueMethod, parameters);\r\n\r\n                return callMethod;\r\n    " +
                    "        }\r\n\r\n            // Needed for Visual basic dynamic support\r\n           " +
                    " public override System.Dynamic.DynamicMetaObject BindInvokeMember(System.Dynami" +
                    "c.InvokeMemberBinder binder, System.Dynamic.DynamicMetaObject[] args)\r\n         " +
                    "   {\r\n                var parameters = new System.Linq.Expressions.Expression[]\r" +
                    "\n                                     {\r\n                                       " +
                    "  System.Linq.Expressions.Expression.Constant(binder.Name)\r\n                    " +
                    "                 };\r\n\r\n                var callMethod = CallMethod(getValueMetho" +
                    "d, parameters);\r\n\r\n                return callMethod;\r\n            }\r\n\r\n        " +
                    "    public override System.Dynamic.DynamicMetaObject BindSetMember(System.Dynami" +
                    "c.SetMemberBinder binder, System.Dynamic.DynamicMetaObject value)\r\n            {" +
                    "\r\n                var parameters = new System.Linq.Expressions.Expression[]\r\n   " +
                    "                                  {\r\n                                         Sy" +
                    "stem.Linq.Expressions.Expression.Constant(binder.Name),\r\n                       " +
                    "                  value.Expression,\r\n                                     };\r\n\r\n" +
                    "                var callMethod = CallMethod(setValueMethod, parameters);\r\n\r\n    " +
                    "            return callMethod;\r\n            }\r\n        }\r\n    }\r\n}\r\n");
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
    public class SqlMapper_DapperRowMetaObjectBase
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
