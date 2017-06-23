﻿namespace Genie.Templates.Infrastructure.Repositories
{
    using Genie.Base;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class RepositoryImplementation : RepositoryImplementationBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Linq;\r\nusing ");
            
            #line 5 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Interfaces;\r\nusing ");
            
            #line 6 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Abstract.Context;\r\nusing ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete;\r\nusing ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete.Context;\r\nusing ");
            
            #line 9 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Repositories.Abstract;\r\n\r\nnamespace ");
            
            #line 11 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Repositories\r\n{\r\n\r\n    namespace Abstract\r\n    {\r\n");
            
            #line 16 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
foreach(var relation in _relations){
            
            #line default
            #line hidden
            this.Write("\t    public interface I");
            
            #line 17 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository : IRepository<");
            
            #line 17 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write(">\r\n\t    {\r\n\t\t    I");
            
            #line 19 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext Get();\r\n");
            
            #line 20 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"

        var keys= relation.Attributes.Where(a => a.IsKey).ToList();

            
            #line default
            #line hidden
            
            #line 23 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
if(keys.Count > 0){
            var keyString = keys.Aggregate("", (c,n) => c + (", " + n.DataType  + " " + n.Name.ToLower())).TrimStart(',').TrimStart(' ');

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 26 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write(" GetByKey(");
            
            #line 26 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyString));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 27 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
}
            
            #line default
            #line hidden
            this.Write("\t    }\r\n");
            
            #line 29 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 31 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
foreach(var view in _views){
            
            #line default
            #line hidden
            this.Write("\t    public interface I");
            
            #line 32 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository : IReadOnlyRepository<");
            
            #line 32 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write(">\r\n\t    {\r\n\t\t    I");
            
            #line 34 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext Get();\r\n\t    }\r\n");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n\r\n    namespace Concrete\r\n    {\r\n");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
foreach(var relation in _relations){
            
            #line default
            #line hidden
            this.Write("\t    internal class ");
            
            #line 43 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository : Repository<");
            
            #line 43 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("> , I");
            
            #line 43 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository\r\n\t    {\r\n            internal ");
            
            #line 45 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("Repository(IDapperContext context, IUnitOfWork unitOfWork) : base(context, unitOf" +
                    "Work)\r\n            {\r\n            }\r\n\r\n\t\t    public I");
            
            #line 49 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext Get() { return new ");
            
            #line 49 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext(this); }\r\n\r\n");
            
            #line 51 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"

        var keys= relation.Attributes.Where(a => a.IsKey).ToList();


            
            #line default
            #line hidden
            
            #line 55 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
if(keys.Count > 0){
            var keyString = keys.Aggregate("", (c,n) => c + (", " + n.DataType + " " + n.Name.ToLower())).TrimStart(',').TrimStart(' ');

            
            #line default
            #line hidden
            this.Write("\r\n            public ");
            
            #line 59 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(relation.Name));
            
            #line default
            #line hidden
            this.Write(" GetByKey(");
            
            #line 59 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyString));
            
            #line default
            #line hidden
            this.Write(")\r\n            {\r\n                return Get().Where\r\n");
            
            #line 62 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
var str = keys.Aggregate("", (c,n) => c + (".And." + n.Name + ".EqualsTo(" + n.Name.ToLower() + ")")).TrimStart('.').TrimStart('A').TrimStart('n').TrimStart('d');
            
            #line default
            #line hidden
            this.Write("                    ");
            
            #line 63 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(str));
            
            #line default
            #line hidden
            this.Write(".Filter().Query().FirstOrDefault();\r\n            }\r\n");
            
            #line 65 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
}
            
            #line default
            #line hidden
            this.Write("\t    }\r\n");
            
            #line 67 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 69 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
foreach(var view in _views){
            
            #line default
            #line hidden
            this.Write("\t    internal class ");
            
            #line 70 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository : ReadOnlyRepository<");
            
            #line 70 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write(">, I");
            
            #line 70 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository\r\n\t    {\r\n            internal ");
            
            #line 72 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("Repository(IDapperContext context) : base(context)\r\n            {\r\n            }\r" +
                    "\n\r\n\t\t    public I");
            
            #line 76 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext Get() { return new ");
            
            #line 76 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(view.Name));
            
            #line default
            #line hidden
            this.Write("QueryContext(this); }\r\n\t    }\r\n");
            
            #line 78 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repositories\RepositoryImplementation.tt"
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
    public class RepositoryImplementationBase
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
