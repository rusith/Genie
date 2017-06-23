﻿namespace Genie.Templates.Infrastructure.Models.Concrete
{
    using Genie.Base;
    using Genie.Extensions;
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class Relation : RelationBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Linq;\r\nusing System.Data;\r\nusing System.Collections.G" +
                    "eneric;\r\nusing ");
            
            #line 9 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper;\r\nusing ");
            
            #line 10 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Collections.Concrete;\r\nusing ");
            
            #line 11 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Collections.Abstract;\r\nusing ");
            
            #line 12 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Actions.Abstract;\r\nusing ");
            
            #line 13 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Actions.Concrete;\r\n\r\n");
            
            #line 15 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
var entity = _relation;
var name = _relation.Name;

            
            #line default
            #line hidden
            this.Write("namespace ");
            
            #line 18 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete\r\n{\r\n    [Table(\"[dbo].[");
            
            #line 20 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("]\")]\r\n    public class ");
            
            #line 21 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write(" : BaseModel\r\n    {\r\n");
            
            #line 23 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var atd in entity.Attributes){
            
            #line default
            #line hidden
            this.Write("\t\tprivate ");
            
            #line 24 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.DataType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 24 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.FieldName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 25 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 27 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var atd in
entity.ForeignKeyAttributes){
            
            #line default
            #line hidden
            this.Write("\t\tprivate ");
            
            #line 29 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingRelationName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 29 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.FieldName));
            
            #line default
            #line hidden
            this.Write("Obj;\r\n");
            
            #line 30 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 32 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var atd in entity.Attributes){
            
            #line default
            #line hidden
            
            #line 33 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
	if(atd.IsKey) {
            
            #line default
            #line hidden
            this.Write("\t\t[Key]\r\n");
            
            #line 35 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
	}
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.DataType));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write(" { get { return ");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.FieldName));
            
            #line default
            #line hidden
            this.Write("; } set { if(");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.FieldName));
            
            #line default
            #line hidden
            this.Write(" == value ) { return; }  ");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.FieldName));
            
            #line default
            #line hidden
            this.Write(" = value; __Updated(\"");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.Name));
            
            #line default
            #line hidden
            this.Write("\"); ");
            
            #line 36 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.RefPropName != null ? atd.RefPropName + " = null;" : ""));
            
            #line default
            #line hidden
            this.Write(" } }\r\n");
            
            #line 37 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 39 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var atd in entity.ForeignKeyAttributes){
            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 40 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingRelationName));
            
            #line default
            #line hidden
            this.Write(" Get");
            
            #line 40 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.Name));
            
            #line default
            #line hidden
            this.Write("(IDbTransaction transaction =null)\r\n        {\r\n            return DatabaseUnitOfW" +
                    "ork != null ? ");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.FieldName));
            
            #line default
            #line hidden
            this.Write("Obj ?? (");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.FieldName));
            
            #line default
            #line hidden
            this.Write("Obj = DatabaseUnitOfWork.");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingRelationName));
            
            #line default
            #line hidden
            this.Write("Repository.Get().Where.");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingTableColumnName));
            
            #line default
            #line hidden
            this.Write(".EqualsTo(");
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.FieldName));
            
            #line default
            #line hidden
            
            #line 42 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.DataType.EndsWith("?") ?  ".GetValueOrDefault()" : ""));
            
            #line default
            #line hidden
            this.Write(").Filter().Top(1).Query(transaction).FirstOrDefault()) : null;\r\n        }\r\n");
            
            #line 44 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 46 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var atd in entity.ForeignKeyAttributes){
            
            #line default
            #line hidden
            this.Write("\t\tpublic void Set");
            
            #line 47 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 47 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingRelationName));
            
            #line default
            #line hidden
            this.Write(" entity)\r\n        {\r\n            if (entity == null)\r\n                return;\r\n  " +
                    "          switch (entity.DatabaseModelStatus)\r\n            {\r\n                ca" +
                    "se ModelStatus.Retrieved:\r\n                    ");
            
            #line 54 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.Name));
            
            #line default
            #line hidden
            this.Write(" = entity.");
            
            #line 54 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingTableColumnName));
            
            #line default
            #line hidden
            this.Write(@";
                    break;
                case ModelStatus.ToAdd:
                    if (entity.ActionsToRunWhenAdding == null)
                        entity.ActionsToRunWhenAdding = new List<IAddAction>();
                    entity.ActionsToRunWhenAdding.Add(new AddAction(i => { ");
            
            #line 59 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingNonForeignKeyAttribute.Name));
            
            #line default
            #line hidden
            this.Write(" = ((");
            
            #line 59 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingRelationName));
            
            #line default
            #line hidden
            this.Write(") i).");
            
            #line 59 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(atd.ReferencingTableColumnName));
            
            #line default
            #line hidden
            this.Write("; }, entity));\r\n                    break;\r\n            }\r\n        }\r\n");
            
            #line 63 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 65 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var list in entity.ReferenceLists){
            
            #line default
            #line hidden
            this.Write("\t\tpublic IReferencedEntityCollection<");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferncedRelationName));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferncedRelationName.ToPlural()));
            
            #line default
            #line hidden
            this.Write("WhereThisIs");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferencedPropertyName));
            
            #line default
            #line hidden
            this.Write("(IDbTransaction transaction = null ){  return new ReferencedEntityCollection<");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferncedRelationName));
            
            #line default
            #line hidden
            this.Write(">(DatabaseUnitOfWork.");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferncedRelationName));
            
            #line default
            #line hidden
            this.Write("Repository.Get().Where.");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferencedPropertyName));
            
            #line default
            #line hidden
            this.Write(".EqualsTo(");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferencedPropertyOnThisRelation));
            
            #line default
            #line hidden
            this.Write(").Filter().Query(transaction), (i) => { ((");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferncedRelationName));
            
            #line default
            #line hidden
            this.Write(")i).");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferencedPropertyName));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 66 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(list.ReferencedPropertyOnThisRelation));
            
            #line default
            #line hidden
            this.Write(";}, this); }\r\n");
            
            #line 67 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("        internal override void SetId(object id)\r\n        {\r\n");
            
            #line 70 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
var keys = entity.Attributes.Where(e => e.IsKey);
            
            #line default
            #line hidden
            
            #line 71 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
foreach(var k in keys){
            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 72 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(k.FieldName));
            
            #line default
            #line hidden
            this.Write(" = (");
            
            #line 72 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(k.DataType));
            
            #line default
            #line hidden
            this.Write(")id;\r\n");
            
            #line 73 "D:\Projects\Genie\Genie\Templates\Infrastructure\Models\Concrete\Relation.tt"
}
            
            #line default
            #line hidden
            this.Write("        }\r\n    }\r\n}\r\n");
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
    public class RelationBase
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
