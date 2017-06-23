﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\DefaultTypeMap.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DefaultTypeMap : DefaultTypeMapBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Reflection;\r\n\r\nnamespace ");
            
            #line 8 "D:\Projects\Genie\Genie\Templates\Dapper\DefaultTypeMap.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper\r\n{\r\n    /// <summary>\r\n    /// Represents default type mapping strategy u" +
                    "sed by Dapper\r\n    /// </summary>\r\n    public sealed class DefaultTypeMap : SqlM" +
                    "apper.ITypeMap\r\n    {\r\n        private readonly List<FieldInfo> _fields;\r\n      " +
                    "  private readonly Type _type;\r\n\r\n        /// <summary>\r\n        /// Creates def" +
                    "ault type map\r\n        /// </summary>\r\n        /// <param name=\"type\">Entity typ" +
                    "e</param>\r\n        public DefaultTypeMap(Type type)\r\n        {\r\n            if (" +
                    "type == null)\r\n                throw new ArgumentNullException(nameof(type));\r\n\r" +
                    "\n            _fields = GetSettableFields(type);\r\n            Properties = GetSet" +
                    "tableProps(type);\r\n            _type = type;\r\n        }\r\n#if COREFX\r\n        sta" +
                    "tic bool IsParameterMatch(ParameterInfo[] x, ParameterInfo[] y)\r\n        {\r\n    " +
                    "        if (ReferenceEquals(x, y)) return true;\r\n            if (x == null || y " +
                    "== null) return false;\r\n            if (x.Length != y.Length) return false;\r\n   " +
                    "         for (int i = 0; i < x.Length; i++)\r\n                if (x[i].ParameterT" +
                    "ype != y[i].ParameterType) return false;\r\n            return true;\r\n        }\r\n#" +
                    "endif\r\n        internal static MethodInfo GetPropertySetter(PropertyInfo propert" +
                    "yInfo, Type type)\r\n        {\r\n            if (propertyInfo.DeclaringType == type" +
                    ") return propertyInfo.GetSetMethod(true);\r\n#if COREFX\r\n            return proper" +
                    "tyInfo.DeclaringType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic " +
                    "| BindingFlags.Instance)\r\n                    .Single(x => x.Name == propertyInf" +
                    "o.Name\r\n                        && x.PropertyType == propertyInfo.PropertyType\r\n" +
                    "                        && IsParameterMatch(x.GetIndexParameters(), propertyInfo" +
                    ".GetIndexParameters())\r\n                        ).GetSetMethod(true);\r\n#else\r\n  " +
                    "          return propertyInfo.DeclaringType.GetProperty(\r\n                   pro" +
                    "pertyInfo.Name,\r\n                   BindingFlags.Public | BindingFlags.NonPublic" +
                    " | BindingFlags.Instance,\r\n                   Type.DefaultBinder,\r\n             " +
                    "      propertyInfo.PropertyType,\r\n                   propertyInfo.GetIndexParame" +
                    "ters().Select(p => p.ParameterType).ToArray(),\r\n                   null).GetSetM" +
                    "ethod(true);\r\n#endif\r\n        }\r\n\r\n        internal static List<PropertyInfo> Ge" +
                    "tSettableProps(Type t)\r\n        {\r\n            return t\r\n                  .GetP" +
                    "roperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)\r" +
                    "\n                  .Where(p => GetPropertySetter(p, t) != null)\r\n               " +
                    "   .ToList();\r\n        }\r\n\r\n        internal static List<FieldInfo> GetSettableF" +
                    "ields(Type t)\r\n        {\r\n            return t.GetFields(BindingFlags.Public | B" +
                    "indingFlags.NonPublic | BindingFlags.Instance).ToList();\r\n        }\r\n\r\n        /" +
                    "// <summary>\r\n        /// Finds best constructor\r\n        /// </summary>\r\n      " +
                    "  /// <param name=\"names\">DataReader column names</param>\r\n        /// <param na" +
                    "me=\"types\">DataReader column types</param>\r\n        /// <returns>Matching constr" +
                    "uctor or default one</returns>\r\n        public ConstructorInfo FindConstructor(s" +
                    "tring[] names, Type[] types)\r\n        {\r\n            var constructors = _type.Ge" +
                    "tConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPubl" +
                    "ic);\r\n            foreach (ConstructorInfo ctor in constructors.OrderBy(c => c.I" +
                    "sPublic ? 0 : (c.IsPrivate ? 2 : 1)).ThenBy(c => c.GetParameters().Length))\r\n   " +
                    "         {\r\n                ParameterInfo[] ctorParameters = ctor.GetParameters(" +
                    ");\r\n                if (ctorParameters.Length == 0)\r\n                    return " +
                    "ctor;\r\n\r\n                if (ctorParameters.Length != types.Length)\r\n           " +
                    "         continue;\r\n\r\n                int i = 0;\r\n                for (; i < cto" +
                    "rParameters.Length; i++)\r\n                {\r\n                    if (!String.Equ" +
                    "als(ctorParameters[i].Name, names[i], StringComparison.OrdinalIgnoreCase))\r\n    " +
                    "                    break;\r\n                    if (types[i] == typeof(byte[]) &" +
                    "& ctorParameters[i].ParameterType.FullName == SqlMapper.LinqBinary)\r\n           " +
                    "             continue;\r\n                    var unboxedType = Nullable.GetUnderl" +
                    "yingType(ctorParameters[i].ParameterType) ?? ctorParameters[i].ParameterType;\r\n " +
                    "                   if ((unboxedType != types[i] && !SqlMapper.HasTypeHandler(unb" +
                    "oxedType))\r\n                        && !(unboxedType.IsEnum() && Enum.GetUnderly" +
                    "ingType(unboxedType) == types[i])\r\n                        && !(unboxedType == t" +
                    "ypeof(char) && types[i] == typeof(string))\r\n                        && !(unboxed" +
                    "Type.IsEnum() && types[i] == typeof(string)))\r\n                    {\r\n          " +
                    "              break;\r\n                    }\r\n                }\r\n\r\n              " +
                    "  if (i == ctorParameters.Length)\r\n                    return ctor;\r\n           " +
                    " }\r\n\r\n            return null;\r\n        }\r\n\r\n        /// <summary>\r\n        /// " +
                    "Returns the constructor, if any, that has the ExplicitConstructorAttribute on it" +
                    ".\r\n        /// </summary>\r\n        public ConstructorInfo FindExplicitConstructo" +
                    "r()\r\n        {\r\n            var constructors = _type.GetConstructors(BindingFlag" +
                    "s.Instance | BindingFlags.Public | BindingFlags.NonPublic);\r\n#if COREFX\r\n       " +
                    "     var withAttr = constructors.Where(c => c.CustomAttributes.Any(x => x.Attrib" +
                    "uteType == typeof(ExplicitConstructorAttribute))).ToList();\r\n#else\r\n            " +
                    "var withAttr = constructors.Where(c => c.GetCustomAttributes(typeof(ExplicitCons" +
                    "tructorAttribute), true).Length > 0).ToList();\r\n#endif\r\n\r\n            if (withAt" +
                    "tr.Count() == 1)\r\n            {\r\n                return withAttr[0];\r\n          " +
                    "  }\r\n\r\n            return null;\r\n        }\r\n\r\n        /// <summary>\r\n        ///" +
                    " Gets mapping for constructor parameter\r\n        /// </summary>\r\n        /// <pa" +
                    "ram name=\"constructor\">Constructor to resolve</param>\r\n        /// <param name=\"" +
                    "columnName\">DataReader column name</param>\r\n        /// <returns>Mapping impleme" +
                    "ntation</returns>\r\n        public SqlMapper.IMemberMap GetConstructorParameter(C" +
                    "onstructorInfo constructor, string columnName)\r\n        {\r\n            var param" +
                    "eters = constructor.GetParameters();\r\n\r\n            return new SimpleMemberMap(c" +
                    "olumnName, parameters.FirstOrDefault(p => string.Equals(p.Name, columnName, Stri" +
                    "ngComparison.OrdinalIgnoreCase)));\r\n        }\r\n\r\n        /// <summary>\r\n        " +
                    "/// Gets member mapping for column\r\n        /// </summary>\r\n        /// <param n" +
                    "ame=\"columnName\">DataReader column name</param>\r\n        /// <returns>Mapping im" +
                    "plementation</returns>\r\n        public SqlMapper.IMemberMap GetMember(string col" +
                    "umnName)\r\n        {\r\n            var property = Properties.FirstOrDefault(p => s" +
                    "tring.Equals(p.Name, columnName, StringComparison.Ordinal))\r\n               ?? P" +
                    "roperties.FirstOrDefault(p => string.Equals(p.Name, columnName, StringComparison" +
                    ".OrdinalIgnoreCase));\r\n\r\n            if (property == null && MatchNamesWithUnder" +
                    "scores)\r\n            {\r\n                property = Properties.FirstOrDefault(p =" +
                    "> string.Equals(p.Name, columnName.Replace(\"_\", \"\"), StringComparison.Ordinal))\r" +
                    "\n                    ?? Properties.FirstOrDefault(p => string.Equals(p.Name, col" +
                    "umnName.Replace(\"_\", \"\"), StringComparison.OrdinalIgnoreCase));\r\n            }\r\n" +
                    "\r\n            if (property != null)\r\n                return new SimpleMemberMap(" +
                    "columnName, property);\r\n\r\n            // roslyn automatically implemented proper" +
                    "ties, in particular for get-only properties: <{Name}>k__BackingField;\r\n         " +
                    "   var backingFieldName = \"<\" + columnName + \">k__BackingField\";\r\n\r\n            " +
                    "// preference order is:\r\n            // exact match over underscre match, exact " +
                    "case over wrong case, backing fields over regular fields, match-inc-underscores " +
                    "over match-exc-underscores\r\n            var field = _fields.FirstOrDefault(p => " +
                    "string.Equals(p.Name, columnName, StringComparison.Ordinal))\r\n                ??" +
                    " _fields.FirstOrDefault(p => string.Equals(p.Name, backingFieldName, StringCompa" +
                    "rison.Ordinal))\r\n                ?? _fields.FirstOrDefault(p => string.Equals(p." +
                    "Name, columnName, StringComparison.OrdinalIgnoreCase))\r\n                ?? _fiel" +
                    "ds.FirstOrDefault(p => string.Equals(p.Name, backingFieldName, StringComparison." +
                    "OrdinalIgnoreCase));\r\n\r\n            if (field == null && MatchNamesWithUnderscor" +
                    "es)\r\n            {\r\n                var effectiveColumnName = columnName.Replace" +
                    "(\"_\", \"\");\r\n                backingFieldName = \"<\" + effectiveColumnName + \">k__" +
                    "BackingField\";\r\n\r\n                field = _fields.FirstOrDefault(p => string.Equ" +
                    "als(p.Name, effectiveColumnName, StringComparison.Ordinal))\r\n                   " +
                    " ?? _fields.FirstOrDefault(p => string.Equals(p.Name, backingFieldName, StringCo" +
                    "mparison.Ordinal))\r\n                    ?? _fields.FirstOrDefault(p => string.Eq" +
                    "uals(p.Name, effectiveColumnName, StringComparison.OrdinalIgnoreCase))\r\n        " +
                    "            ?? _fields.FirstOrDefault(p => string.Equals(p.Name, backingFieldNam" +
                    "e, StringComparison.OrdinalIgnoreCase));\r\n            }\r\n\r\n            if (field" +
                    " != null)\r\n                return new SimpleMemberMap(columnName, field);\r\n\r\n   " +
                    "         return null;\r\n        }\r\n        /// <summary>\r\n        /// Should colu" +
                    "mn names like User_Id be allowed to match properties/fields like UserId ?\r\n     " +
                    "   /// </summary>\r\n        public static bool MatchNamesWithUnderscores { get; s" +
                    "et; }\r\n\r\n        /// <summary>\r\n        /// The settable properties for this typ" +
                    "emap\r\n        /// </summary>\r\n        public List<PropertyInfo> Properties { get" +
                    "; }\r\n    }\r\n}");
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
    public class DefaultTypeMapBase
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
