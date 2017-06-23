﻿namespace Genie.Templates.Infrastructure.Models.Concrete.Context
{
    using Genie.Base;
    using Genie.Extensions;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ModelQueryContext : ModelQueryContextBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Data;\r\nusing System.Collections.Generic;\r\nusing ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Abstract;\r\nusing ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Abstract;\r\nusing ");
            
            #line 9 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Concrete;\r\nusing ");
            
            #line 10 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Repositories.Abstract;\r\nusing ");
            
            #line 11 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Abstract.Context;\r\n\r\nnamespace ");
            
            #line 13 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete.Context\r\n{\r\n    internal class ");
            
            #line 15 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext: BaseQueryContext, I");
            
            #line 15 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext\r\n\t{\r\n\t\tprivate I");
            
            #line 17 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext _where; \r\n\t    private I");
            
            #line 18 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("OrderContext _order;\r\n\t\tprivate readonly I");
            
            #line 19 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("Repository _repo;\r\n\r\n        public I");
            
            #line 21 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext Page(int pageSize, int page)\r\n        {\r\n            _page = page;\r\n" +
                    "            _pageSize = pageSize;\r\n            return this;\r\n        }\r\n\r\n      " +
                    "  public I");
            
            #line 28 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext Top(int limit)\r\n        {\r\n            _limit = limit;\r\n            " +
                    "return this;\r\n        }\r\n\r\n        public I");
            
            #line 34 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext Skip(int skip)\r\n        {\r\n            _skip = skip;\r\n            re" +
                    "turn this;\r\n        }\r\n\r\n        public I");
            
            #line 40 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext Take(int take)\r\n        {\r\n            _take = take;\r\n            re" +
                    "turn this;\r\n        }\r\n\t\t\r\n\t\tinternal ");
            
            #line 46 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("QueryContext(I");
            
            #line 46 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("Repository repo) { _repo = repo; }\r\n\t\t\r\n\t\tpublic I");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext Where { get { return _where ?? (_where = new ");
            
            #line 48 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("FilterContext(this)); }}\r\n        \r\n\t\tpublic I");
            
            #line 50 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("OrderContext OrderBy { get { return _order ?? (_order = new ");
            
            #line 50 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("OrderContext(this)); } }\r\n\r\n        public IEnumerable<");
            
            #line 52 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write("> Query(IDbTransaction transaction = null)\r\n\t    {\r\n\t        return _repo.Get(Get" +
                    "Query(transaction));\r\n\t    }\r\n\r\n\t    public int Count(IDbTransaction transaction" +
                    " = null)\r\n\t    {\r\n            return _repo.Count(GetQuery(transaction));\r\n\t    }" +
                    "\r\n\r\n\t\tpublic I");
            
            #line 62 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write(@"QueryContext Filter(IEnumerable<IPropertyFilter> filters) 
		{
            ProcessFilter(Where.GetFilterExpressions(), filters);
			return this;	
		}

	    private IRepoQuery GetQuery(IDbTransaction transaction)
	    {
	        return new RepoQuery
	        {
	            Target = ""[dbo].[");
            
            #line 72 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_name));
            
            #line default
            #line hidden
            this.Write(@"]"",
	            Where = _where?.GetFilterExpressions(),
	            Order = _order?.GetOrderExpressions(),
	            PageSize = _pageSize,
	            Page = _page,
	            Limit = _limit,
	            Skip = _skip,
	            Take = _take,
	            Transaction = transaction
	        };
	    }

		protected override bool? IsQuoted(ref string propertyName) 
		{
");
            
            #line 86 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
var lit = _attributes.Where(a => a.IsLiteralType).ToList();
            
            #line default
            #line hidden
            
            #line 87 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
var nonLit = _attributes.Where(a => !a.IsLiteralType).ToList();
            
            #line default
            #line hidden
            this.Write("\t\t\tswitch(propertyName.ToLower()) \r\n\t\t\t{\r\n");
            
            #line 90 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
foreach(var a in lit){
            
            #line default
            #line hidden
            this.Write("\t\t\t\tcase \"");
            
            #line 91 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(a.Name.ToLower()));
            
            #line default
            #line hidden
            this.Write("\":\r\n                    propertyName = \"");
            
            #line 92 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(a.Name));
            
            #line default
            #line hidden
            this.Write("\";\r\n                    return true;\r\n");
            
            #line 94 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
}
            
            #line default
            #line hidden
            
            #line 95 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
foreach(var a in nonLit){
            
            #line default
            #line hidden
            this.Write("\t\t\t\tcase \"");
            
            #line 96 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(a.Name.ToLower()));
            
            #line default
            #line hidden
            this.Write("\":\r\n                    propertyName = \"");
            
            #line 97 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(a.Name));
            
            #line default
            #line hidden
            this.Write("\";\r\n                    return false;\r\n");
            
            #line 99 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Context\ModelQueryContext.tt"
}
            
            #line default
            #line hidden
            this.Write("\t\t\t\tdefault: return null;\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tpublic string GetWhereClause() \r\n\t\t{\r\n\t" +
                    "\t\treturn _repo.GetWhereClause(GetQuery(null));\r\n\t\t}\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class ModelQueryContextBase
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
