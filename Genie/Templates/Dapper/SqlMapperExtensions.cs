﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
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
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class SqlMapperExtensions : SqlMapperExtensionsBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Concurrent;\r\nusing System.Collections.Gen" +
                    "eric;\r\nusing System.Data;\r\nusing System.Linq;\r\nusing System.Reflection;\r\nusing S" +
                    "ystem.Text;\r\nusing ");
            
            #line 10 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Models.Concrete;\r\nusing ");
            
            #line 11 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Infrastructure.Filters.Abstract;\r\n");
            
            #line 12 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
if(GenerationContext.NoDapper){
            
            #line default
            #line hidden
            this.Write("using Dapper;\r\n");
            
            #line 14 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 16 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper\r\n{\r\n\tpublic static class SqlMapperExtensions\r\n    {\r\n        public inter" +
                    "face IProxy\r\n        {\r\n            bool IsDirty { get; set; }\r\n        }\r\n\r\n\r\n " +
                    "       public class SqlWhereOrderCache\r\n        {\r\n            public string Sql" +
                    " { get; set; }\r\n            public IEnumerable<string> Where { get; set; }\r\n    " +
                    "        public IEnumerable<string> Order { get; set; }\r\n        }\r\n\r\n        pri" +
                    "vate static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<Propert" +
                    "yInfo>> KeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<" +
                    "PropertyInfo>>();\r\n        private static readonly ConcurrentDictionary<RuntimeT" +
                    "ypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<" +
                    "RuntimeTypeHandle, IEnumerable<PropertyInfo>>();\r\n        private static readonl" +
                    "y ConcurrentDictionary<RuntimeTypeHandle, string> TypeTableName = new Concurrent" +
                    "Dictionary<RuntimeTypeHandle, string>();\r\n\r\n        private static readonly Dict" +
                    "ionary<string, ISqlAdapter> AdapterDictionary = new Dictionary<string, ISqlAdapt" +
                    "er>() {\r\n                                                                       " +
                    "                  {\"sqlconnection\", new SqlServerAdapter()},\r\n                  " +
                    "                                                                      {\"npgsqlco" +
                    "nnection\", new PostgresAdapter()}\r\n                                             " +
                    "                                       };\r\n\r\n        private static IEnumerable<" +
                    "PropertyInfo> KeyPropertiesCache(Type type)\r\n        {\r\n\r\n            IEnumerabl" +
                    "e<PropertyInfo> pi;\r\n            if (KeyProperties.TryGetValue(type.TypeHandle, " +
                    "out pi))\r\n            {\r\n                return pi;\r\n            }\r\n\r\n          " +
                    "  var allProperties = TypePropertiesCache(type).ToList();\r\n            var keyPr" +
                    "operties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => a is Ke" +
                    "yAttribute)).ToList();\r\n\r\n            if (keyProperties.Count == 0)\r\n           " +
                    " {\r\n                var idProp = allProperties.FirstOrDefault(p => p.Name.ToLowe" +
                    "r() == \"id\");\r\n                if (idProp != null)\r\n                {\r\n         " +
                    "           keyProperties.Add(idProp);\r\n                }\r\n            }\r\n\r\n     " +
                    "       KeyProperties[type.TypeHandle] = keyProperties;\r\n            return keyPr" +
                    "operties;\r\n        }\r\n\r\n        private static IEnumerable<PropertyInfo> TypePro" +
                    "pertiesCache(Type type)\r\n        {\r\n            IEnumerable<PropertyInfo> pis;\r\n" +
                    "            if (TypeProperties.TryGetValue(type.TypeHandle, out pis))\r\n         " +
                    "   {\r\n                return pis;\r\n            }\r\n\r\n            var properties =" +
                    " type.GetProperties().Where(IsWriteable).ToList();\r\n            TypeProperties[t" +
                    "ype.TypeHandle] = properties;\r\n            return properties;\r\n        }\r\n\r\n    " +
                    "    public static bool IsWriteable(PropertyInfo pi)\r\n        {\r\n            var " +
                    "attributes = pi.GetCustomAttributes(typeof(WriteAttribute), false);\r\n           " +
                    " if (attributes");
            
            #line 83 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.Core ? ".Count()" : ".Length"));
            
            #line default
            #line hidden
            this.Write(" != 1)\r\n                return true;\r\n            var write = (WriteAttribute)att" +
                    "ributes");
            
            #line 85 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.Core ? ".First()" : "[0]"));
            
            #line default
            #line hidden
            this.Write(";\r\n            return write.Write;\r\n        }\r\n\r\n\t    /// <summary>\r\n\t    /// Ret" +
                    "urn all  \r\n\t    /// </summary>\r\n\t    /// <typeparam name=\"T\">Interface type to c" +
                    "reate and populate</typeparam>\r\n\t    /// <param name=\"connection\">Open SqlConnec" +
                    "tion</param>\r\n\t    /// <param name=\"query\"></param>\r\n\t    /// <returns>Entity of" +
                    " T</returns>\r\n\t    public static IEnumerable<T> Get<T>(this IDbConnection connec" +
                    "tion, IRepoQuery query)\r\n        {\r\n           return connection.Query<T>(GetRet" +
                    "riveQuery(query), transaction: query.Transaction);\r\n        }\r\n\r\n\t    /// <summa" +
                    "ry>\r\n\t    /// Returns count of rows\r\n\t    /// </summary>\r\n\t    /// <param name=\"" +
                    "connection\">Open SqlConnection</param>\r\n\t    /// <param name=\"query\"></param>\r\n\t" +
                    "    /// <returns>Entity of T</returns>\r\n\t    public static int Count(this IDbCon" +
                    "nection connection, IRepoQuery query)\r\n        {\r\n\t        return connection.Exe" +
                    "cuteScalar<int>(GetRetriveQuery(query, true), transaction: query.Transaction);\r\n" +
                    "        }\r\n\r\n\t\t/// <summary>\r\n\t    /// Returns the where clause of the resulting" +
                    " query\r\n\t    /// </summary>\r\n\t    /// <param name=\"connection\">Open SqlConnectio" +
                    "n</param>\r\n\t    /// <param name=\"query\"></param>\r\n\t    /// <returns>Entity of T<" +
                    "/returns>\r\n\t    public static string GetWhereClause(this IDbConnection connectio" +
                    "n, IRepoQuery query)\r\n\t    {\r\n\t        return GetRetriveQuery(query, false, true" +
                    ");\r\n\t    }\r\n\r\n\t    private static string GetRetriveQuery(IRepoQuery query, bool " +
                    "isCount = false, bool whereOnly = false)\r\n\t    {\r\n            var queryBuilder =" +
                    " new StringBuilder(whereOnly ? \"\" : string.Format(\"select {0} {1} from \" + query" +
                    ".Target, query.Limit != null ? \" top \" + query.Limit : \"\", isCount ? \"count(*)\" " +
                    ": \"*\"));\r\n            \r\n            var where = query.Where == null ? new Queue<" +
                    "string>() : new Queue<string>(query.Where);\r\n            var order = query.Order" +
                    " == null ? new Queue<string>() : new Queue<string>(query.Order);\r\n\r\n\t        if " +
                    "(where.Count > 0)\r\n\t        {\r\n\t            queryBuilder.Append(\" where \");\r\n\r\n\t" +
                    "            var first = true;\r\n\t            var previous = \"\";\r\n\r\n\t            w" +
                    "hile (where.Count > 0)\r\n\t            {\r\n\t                var current = where.Deq" +
                    "ueue();\r\n\r\n\t                if (AndOrOr(current))\r\n\t                {\r\n\t        " +
                    "            if (first)\r\n\t                    {\r\n\t                        first =" +
                    " false;\r\n\t                        previous = current;\r\n\t                        " +
                    "continue;\r\n\t                    }\r\n\r\n\t                    if (AndOrOr(previous))" +
                    "\r\n\t                    {\r\n\t                        previous = current;\r\n\t       " +
                    "                 continue;\r\n\t                    }\r\n\r\n\t                    previ" +
                    "ous = current;\r\n\t                    queryBuilder.Append($\" {current} \");\r\n\t    " +
                    "            }\r\n\t                else\r\n\t                {\r\n\t                    i" +
                    "f (!first && !AndOrOr(previous))\r\n\t                    {\r\n\t                     " +
                    "   queryBuilder.Append(\" and \");\r\n\t                    }\r\n\r\n\t                   " +
                    " previous = current;\r\n\t                    queryBuilder.Append($\" {current} \");\r" +
                    "\n\t                }\r\n\r\n\t                first = false;\r\n\t            }\r\n\t       " +
                    " }\r\n\r\n\t        if (whereOnly)\r\n\t            return queryBuilder.ToString();\r\n\r\n\t" +
                    "        if (order.Count > 0)\r\n\t        {\r\n\t            queryBuilder.Append(\" ord" +
                    "er by \");\r\n\t            while (order.Count > 0)\r\n\t            {\r\n\t              " +
                    "  var item = order.Dequeue();\r\n\t                queryBuilder.Append($\" {item} \")" +
                    ";\r\n\t            }\r\n\t        }\r\n\r\n\t        if (query.Page != null && query.PageSi" +
                    "ze != null)\r\n\t        {\r\n\t            queryBuilder.Append($\" OFFSET ({query.Page" +
                    " * query.PageSize}) ROWS \" + $\" FETCH NEXT {query.PageSize} ROWS ONLY \");\r\n\t    " +
                    "    }\r\n\t        else\r\n\t        {\r\n\t            if (query.Skip != null)\r\n\t       " +
                    "         queryBuilder.Append($\" OFFSET ({query.Skip}) ROWS \");\r\n\r\n\t            i" +
                    "f (query.Take != null)\r\n\t                queryBuilder.Append($\" FETCH NEXT {quer" +
                    "y.Take} ROWS ONLY \");\r\n\t        }\r\n\r\n\t        return queryBuilder.ToString();\r\n " +
                    "       }\r\n\r\n        private static bool AndOrOr(string str)\r\n\t    {\r\n\t        re" +
                    "turn str == \"and\" || str == \"or\";\r\n\t    }\r\n\r\n\r\n        private static string Get" +
                    "TableName(Type type)\r\n        {\r\n            string name;\r\n            if (TypeT" +
                    "ableName.TryGetValue(type.TypeHandle, out name)) return name;\r\n            name " +
                    "= type.Name + \"s\";\r\n            if (type.");
            
            #line 214 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.Core ? "GetTypeInfo()." : ""));
            
            #line default
            #line hidden
            this.Write("IsInterface && name.StartsWith(\"I\"))\r\n                name = name.Substring(1);\r\n" +
                    "\r\n            var tableattr = type.");
            
            #line 217 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapperExtensions.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.Core ? "GetTypeInfo()." : ""));
            
            #line default
            #line hidden
            this.Write("GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == \"TableA" +
                    "ttribute\") as\r\n                dynamic;\r\n            if (tableattr != null)\r\n   " +
                    "             name = tableattr.Name;\r\n            TypeTableName[type.TypeHandle] " +
                    "= name;\r\n            return name;\r\n        }\r\n\r\n\t    /// <summary>\r\n\t    /// Ins" +
                    "erts an entity into table \"Ts\" and returns identity id.\r\n\t    /// </summary>\r\n\t " +
                    "   /// <param name=\"connection\">Open SqlConnection</param>\r\n\t    /// <param name" +
                    "=\"entityToInsert\">Entity to insert</param>\r\n\t    /// <param name=\"transaction\"><" +
                    "/param>\r\n\t    /// <param name=\"commandTimeout\"></param>\r\n\t    /// <returns>Ident" +
                    "ity of inserted entity</returns>\r\n\t    public static long? Insert(this IDbConnec" +
                    "tion connection, BaseModel entityToInsert, IDbTransaction transaction = null, in" +
                    "t? commandTimeout = null)\r\n        {\r\n\r\n            var type = entityToInsert.Ge" +
                    "tType();\r\n\r\n            var name = GetTableName(type);\r\n\r\n            var sbColu" +
                    "mnList = new StringBuilder(null);\r\n\r\n            var allProperties = TypePropert" +
                    "iesCache(type).ToList();\r\n            var keyProperties = KeyPropertiesCache(typ" +
                    "e).ToList();\r\n            var allPropertiesExceptKey = allProperties.Except(keyP" +
                    "roperties).ToList();\r\n\r\n\t        var index = 0;\r\n\t        var lst = allPropertie" +
                    "s.Count == keyProperties.Count ? keyProperties : allPropertiesExceptKey;\r\n      " +
                    "      foreach (var property in lst)\r\n\t        {\r\n                sbColumnList.Ap" +
                    "pendFormat(\"[{0}]\", property.Name);\r\n                if (index < lst.Count() - 1" +
                    ")\r\n                    sbColumnList.Append(\", \");\r\n\t            index ++;\r\n\t    " +
                    "    }\r\n\r\n\t        index = 0;\r\n            var sbParameterList = new StringBuilde" +
                    "r(null);\r\n\r\n            foreach (var property in lst)\r\n            {\r\n          " +
                    "      sbParameterList.AppendFormat(\"@{0}\", property.Name);\r\n                if (" +
                    "index < lst.Count() - 1)\r\n                    sbParameterList.Append(\", \");\r\n   " +
                    "             index++;\r\n            }\r\n            \r\n            var adapter = Ge" +
                    "tFormatter(connection);\r\n\r\n            var id = adapter.Insert(connection, trans" +
                    "action, commandTimeout, name, sbColumnList.ToString(), sbParameterList.ToString(" +
                    "), keyProperties, entityToInsert);\r\n            return id;\r\n        }\r\n\r\n\t    //" +
                    "/ <summary>\r\n\t    /// Updates entity in table \"Ts\", checks if the entity is modi" +
                    "fied if the entity is tracked by the Get() extension.\r\n\t    /// </summary>\r\n\t   " +
                    " /// <param name=\"connection\">Open SqlConnection</param>\r\n\t    /// <param name=\"" +
                    "entityToUpdate\">Entity to be updated</param>\r\n\t    /// <param name=\"transaction\"" +
                    "></param>\r\n\t    /// <param name=\"commandTimeout\"></param>\r\n\t    /// <returns>tru" +
                    "e if updated, false if not found or not modified (tracked entities)</returns>\r\n\t" +
                    "    public static bool Update(this IDbConnection connection, BaseModel entityToU" +
                    "pdate, IDbTransaction transaction = null, int? commandTimeout = null)\r\n        {" +
                    "\r\n            if (entityToUpdate.DatabaseModelStatus != ModelStatus.Retrieved)\r\n" +
                    "                return false;\r\n\r\n            if (entityToUpdate.UpdatedPropertie" +
                    "s == null || entityToUpdate.UpdatedProperties.Count < 1)\r\n                return" +
                    " false;\r\n\r\n            var type = entityToUpdate.GetType();\r\n\r\n            var k" +
                    "eyProperties = KeyPropertiesCache(type).ToList();\r\n            if (!keyPropertie" +
                    "s.Any())\r\n                throw new ArgumentException(\"Entity must have at least" +
                    " one [Key] property\");\r\n\r\n            var name = GetTableName(type);\r\n\r\n        " +
                    "    var sb = new StringBuilder();\r\n            sb.AppendFormat(\"update {0} set \"" +
                    ", name);\r\n\r\n            var allProperties = TypePropertiesCache(type);\r\n        " +
                    "    var nonIdProps = allProperties.Where(a => !keyProperties.Contains(a) && enti" +
                    "tyToUpdate.UpdatedProperties.Contains(a.Name)).ToList(); // Only updated propert" +
                    "ies\r\n\r\n\r\n            for (var i = 0; i < nonIdProps.Count(); i++)\r\n            {" +
                    "\r\n                var property = nonIdProps.ElementAt(i);\r\n                sb.Ap" +
                    "pendFormat(\"[{0}] = @{1}\", property.Name, property.Name);\r\n                if (i" +
                    " < nonIdProps.Count() - 1)\r\n                    sb.AppendFormat(\", \");\r\n        " +
                    "    }\r\n\r\n            sb.Append(\" where \");\r\n            for (var i = 0; i < keyP" +
                    "roperties.Count(); i++)\r\n            {\r\n                var property = keyProper" +
                    "ties.ElementAt(i);\r\n                sb.AppendFormat(\"[{0}] = @{1}\", property.Nam" +
                    "e, property.Name);\r\n                if (i < keyProperties.Count() - 1)\r\n        " +
                    "            sb.AppendFormat(\" and \");\r\n            }\r\n\r\n            var updated " +
                    "= connection.Execute(sb.ToString(), entityToUpdate, commandTimeout: commandTimeo" +
                    "ut, transaction: transaction);\r\n            return updated > 0;\r\n        }\r\n\r\n\t " +
                    "   /// <summary>\r\n\t    /// Delete entity in table \"Ts\".\r\n\t    /// </summary>\r\n\t " +
                    "   /// <param name=\"connection\">Open SqlConnection</param>\r\n\t    /// <param name" +
                    "=\"entity\"></param>\r\n\t    /// <param name=\"transaction\"></param>\r\n\t    /// <param" +
                    " name=\"commandTimeout\"></param>\r\n\t    /// <returns>true if deleted, false if not" +
                    " found</returns>\r\n\t    public static bool Delete(this IDbConnection connection, " +
                    "BaseModel entity, IDbTransaction transaction = null, int? commandTimeout = null)" +
                    "\r\n        {\r\n\t        if (entity == null)\r\n\t        {\r\n                throw new" +
                    " ArgumentException(\"The entity is null, cannot delete a null entity\", \"entity\");" +
                    "\r\n            }\r\n\r\n            var type = entity.GetType();\r\n            var key" +
                    "Properties = KeyPropertiesCache(type).ToList();\r\n\r\n            if (!keyPropertie" +
                    "s.Any())\r\n                throw new ArgumentException(\"Entity must have at least" +
                    " one [Key] property\");\r\n\r\n            var name = GetTableName(type);\r\n\r\n        " +
                    "    var sb = new StringBuilder();\r\n            sb.AppendFormat(\"delete from {0} " +
                    "where \", name);\r\n\r\n            for (var i = 0; i < keyProperties.Count(); i++)\r\n" +
                    "            {\r\n                var property = keyProperties.ElementAt(i);\r\n     " +
                    "           sb.AppendFormat(\"[{0}] = @{1}\", property.Name, property.Name);\r\n     " +
                    "           if (i < keyProperties.Count() - 1)\r\n                    sb.AppendForm" +
                    "at(\" and \");\r\n            }\r\n            var deleted = connection.Execute(sb.ToS" +
                    "tring(), entity, transaction: transaction, commandTimeout: commandTimeout) > 0;\r" +
                    "\n            return deleted;\r\n        }\r\n\r\n        public static ISqlAdapter Get" +
                    "Formatter(IDbConnection connection)\r\n        {\r\n            var name = connectio" +
                    "n.GetType().Name.ToLower();\r\n            return !AdapterDictionary.ContainsKey(n" +
                    "ame) ? new SqlServerAdapter() : AdapterDictionary[name];\r\n        }\r\n    }\r\n}");
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
    public class SqlMapperExtensionsBase
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
