﻿namespace Genie.Templates.Infrastructure
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class Repository : RepositoryBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Data;\r\nusing Syste" +
                    "m.Linq;\r\nusing ");
            
            #line 7 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Abstract;\r\nusing ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper;\r\nusing ");
            
            #line 9 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Interfaces;\r\nusing ");
            
            #line 10 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete;\r\n\r\nnamespace ");
            
            #line 12 "D:\Projects\Genie\Genie\Templates\Infrastructure\Repository.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure\r\n{\r\n    public abstract class Repository<T> : IRepository<T>\r\n   " +
                    "     where T : BaseModel\r\n    {\r\n        public IDbConnection Conn { get; }\r\n   " +
                    "     public IDapperContext Context { get;}\r\n        public IUnitOfWork UnitOfWor" +
                    "k { get;}\r\n\r\n        protected Repository(IDapperContext context, IUnitOfWork un" +
                    "itOfWork)\r\n        {\r\n            Context = context;\r\n            Conn = Context" +
                    ".Connection;\r\n            UnitOfWork = unitOfWork;\r\n        }\r\n\r\n        public " +
                    "virtual void Add(T entity, IDbTransaction transaction = null, int? commandTimeou" +
                    "t = null)\r\n        {\r\n            if (entity == null)\r\n            {\r\n          " +
                    "      throw new ArgumentNullException(\"entity\", \"Add to DB null entity\");\r\n     " +
                    "       }\r\n            \r\n            entity.DatabaseUnitOfWork = UnitOfWork;     " +
                    "      \r\n            var operation = new Operation(OperationType.Add, entity);\r\n " +
                    "           UnitOfWork.AddOp(operation);    \r\n            entity.DatabaseModelSta" +
                    "tus = ModelStatus.ToAdd;  \r\n        }\r\n\r\n        public virtual void Add(IEnumer" +
                    "able<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)" +
                    "\r\n        {\r\n            if (entities == null)\r\n            {\r\n                t" +
                    "hrow new ArgumentNullException(\"entities\", \"Add to DB null entity\");\r\n          " +
                    "  }\r\n            \r\n            foreach(var entity in entities)\r\n                " +
                    "Add(entity, transaction, commandTimeout);\r\n        }\r\n\r\n        public virtual v" +
                    "oid Remove(T entity, IDbTransaction transaction = null, int? commandTimeout = nu" +
                    "ll)\r\n        {\r\n            if (entity == null)\r\n            {\r\n                " +
                    "throw new ArgumentNullException(\"entity\", \"Remove in DB null entity\");\r\n        " +
                    "    }\r\n            \r\n            var operation = new Operation(OperationType.Rem" +
                    "ove, entity);\r\n            UnitOfWork.AddOp(operation);\r\n        }\r\n\r\n        pu" +
                    "blic virtual void Remove(IEnumerable<T> entities, IDbTransaction transaction = n" +
                    "ull, int? commandTimeout = null)\r\n        {\r\n            if (entities == null)\r\n" +
                    "            {\r\n                throw new ArgumentNullException(\"entities\", \"Remo" +
                    "ve in DB null entity\");\r\n            }\r\n\r\n            foreach(var entity in enti" +
                    "ties)\r\n                Remove(entity, transaction, commandTimeout);\r\n        }\r\n" +
                    "\r\n        public virtual IEnumerable<T> Get(IRepoQuery query)\r\n        {\r\n      " +
                    "      var items = Conn.Get<T>(query).ToList();\r\n\r\n            foreach (var item " +
                    "in items)\r\n            {\r\n                item.DatabaseUnitOfWork = UnitOfWork;\r" +
                    "\n                item.DatabaseModelStatus = ModelStatus.Retrieved;\r\n            " +
                    "    UnitOfWork.AddObj(item);\r\n            }\r\n            return items;\r\n        " +
                    "}\r\n\r\n        public virtual int Count(IRepoQuery query)\r\n        {\r\n            " +
                    "return Conn.Count(query);\r\n        }\r\n\r\n\t\tpublic string GetWhereClause(IRepoQuer" +
                    "y query) \r\n\t\t{\r\n\t\t\treturn Conn.GetWhereClause(query);\r\n\t\t}\r\n    }\r\n}\r\n");
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
    public class RepositoryBase
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
