﻿namespace Genie.Templates.Infrastructure.Models.Abstract.Context
{
    using Genie.Base;
    using Genie.Extensions;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class IModelFilterContext : IModelFilterContextBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using ");
            
            #line 5 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Abstract;\r\n\r\nnamespace ");
            
            #line 7 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Abstract.Context\r\n{\r\n\tpublic interface I");
            
            #line 9 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext : IFilterContext\r\n\t{\r\n");
            
            #line 11 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
foreach(var atd in _attributes){
            
            #line default
            #line hidden
            
            #line 12 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
if(atd.DataType == "string"){
            
            #line default
            #line hidden
            this.Write("\t    IStringFilter<I");
            
            #line 13 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext,I");
            
            #line 13 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext> ");
            
            #line 13 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write(" { get; }\r\n");
            
            #line 14 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
} else if(atd.DataType == "int" || atd.DataType == "int?" || atd.DataType == "double" || atd.DataType == "double?" || atd.DataType == "decimal" || atd.DataType == "decimal?" || atd.DataType == "long" || atd.DataType == "long?" ){
            
            #line default
            #line hidden
            this.Write("\t\tINumberFilter<I");
            
            #line 15 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext,I");
            
            #line 15 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext> ");
            
            #line 15 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write(" { get; }\r\n");
            
            #line 16 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
}else if(atd.DataType == "DateTime" || atd.DataType == "DateTime?"){
            
            #line default
            #line hidden
            this.Write("\t    IDateFilter<I");
            
            #line 17 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext,I");
            
            #line 17 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext> ");
            
            #line 17 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write(" { get; }\r\n");
            
            #line 18 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
}else if(atd.DataType == "bool" || atd.DataType == "bool?"){
            
            #line default
            #line hidden
            this.Write("\t    IBoolFilter<I");
            
            #line 19 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext,I");
            
            #line 19 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext> ");
            
            #line 19 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write(" { get; }\r\n");
            
            #line 20 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
}
            
            #line default
            #line hidden
            
            #line 21 "F:\Projects\Genie\Genie\Templates\Infrastructure\Models\Abstract\Context\IModelFilterContext.tt"
}
            
            #line default
            #line hidden
            this.Write("    }\r\n}");
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
    public class IModelFilterContextBase
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
