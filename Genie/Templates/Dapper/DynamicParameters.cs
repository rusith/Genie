﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\DynamicParameters.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DynamicParameters : DynamicParametersBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;


#if COREFX
using ApplicationException = System.InvalidOperationException;
#endif


namespace ");
            
            #line 17 "D:\Projects\Genie\Genie\Templates\Dapper\DynamicParameters.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper\r\n{\r\n\r\n    /// <summary>\r\n    /// A bag of parameters that can be passed t" +
                    "o the Dapper Query and Execute methods\r\n    /// </summary>\r\n    public partial c" +
                    "lass DynamicParameters : SqlMapper.IDynamicParameters, SqlMapper.IParameterLooku" +
                    "p, SqlMapper.IParameterCallbacks\r\n    {\r\n        internal const DbType Enumerabl" +
                    "eMultiParameter = (DbType)(-1);\r\n        static Dictionary<SqlMapper.Identity, A" +
                    "ction<IDbCommand, object>> paramReaderCache = new Dictionary<SqlMapper.Identity," +
                    " Action<IDbCommand, object>>();\r\n\r\n        Dictionary<string, ParamInfo> paramet" +
                    "ers = new Dictionary<string, ParamInfo>();\r\n        List<object> templates;\r\n\r\n " +
                    "       object SqlMapper.IParameterLookup.this[string member]\r\n        {\r\n       " +
                    "     get\r\n            {\r\n                ParamInfo param;\r\n                retur" +
                    "n parameters.TryGetValue(member, out param) ? param.Value : null;\r\n            }" +
                    "\r\n        }\r\n\r\n\r\n        /// <summary>\r\n        /// construct a dynamic paramete" +
                    "r bag\r\n        /// </summary>\r\n        public DynamicParameters()\r\n        {\r\n  " +
                    "          RemoveUnused = true;\r\n        }\r\n\r\n        /// <summary>\r\n        /// " +
                    "construct a dynamic parameter bag\r\n        /// </summary>\r\n        /// <param na" +
                    "me=\"template\">can be an anonymous type or a DynamicParameters bag</param>\r\n     " +
                    "   public DynamicParameters(object template)\r\n        {\r\n            RemoveUnuse" +
                    "d = true;\r\n            AddDynamicParams(template);\r\n        }\r\n\r\n        /// <su" +
                    "mmary>\r\n        /// Append a whole object full of params to the dynamic\r\n       " +
                    " /// EG: AddDynamicParams(new {A = 1, B = 2}) // will add property A and B to th" +
                    "e dynamic\r\n        /// </summary>\r\n        /// <param name=\"param\"></param>\r\n   " +
                    "     public void AddDynamicParams(object param)\r\n        {\r\n            var obj " +
                    "= param;\r\n            if (obj != null)\r\n            {\r\n                var subDy" +
                    "namic = obj as DynamicParameters;\r\n                if (subDynamic == null)\r\n    " +
                    "            {\r\n                    var dictionary = obj as IEnumerable<KeyValueP" +
                    "air<string, object>>;\r\n                    if (dictionary == null)\r\n            " +
                    "        {\r\n                        templates = templates ?? new List<object>();\r" +
                    "\n                        templates.Add(obj);\r\n                    }\r\n           " +
                    "         else\r\n                    {\r\n                        foreach (var kvp i" +
                    "n dictionary)\r\n                        {\r\n                            Add(kvp.Ke" +
                    "y, kvp.Value, null, null, null);\r\n                        }\r\n                   " +
                    " }\r\n                }\r\n                else\r\n                {\r\n                " +
                    "    if (subDynamic.parameters != null)\r\n                    {\r\n                 " +
                    "       foreach (var kvp in subDynamic.parameters)\r\n                        {\r\n  " +
                    "                          parameters.Add(kvp.Key, kvp.Value);\r\n                 " +
                    "       }\r\n                    }\r\n\r\n                    if (subDynamic.templates " +
                    "!= null)\r\n                    {\r\n                        templates = templates ?" +
                    "? new List<object>();\r\n                        foreach (var t in subDynamic.temp" +
                    "lates)\r\n                        {\r\n                            templates.Add(t);" +
                    "\r\n                        }\r\n                    }\r\n                }\r\n         " +
                    "   }\r\n        }\r\n\r\n        /// <summary>\r\n        /// Add a parameter to this dy" +
                    "namic parameter list\r\n        /// </summary>\r\n        public void Add(string nam" +
                    "e, object value, DbType? dbType, ParameterDirection? direction, int? size)\r\n    " +
                    "    {\r\n            parameters[Clean(name)] = new ParamInfo\r\n            {\r\n     " +
                    "           Name = name,\r\n                Value = value,\r\n                Paramet" +
                    "erDirection = direction ?? ParameterDirection.Input,\r\n                DbType = d" +
                    "bType,\r\n                Size = size\r\n            };\r\n        }\r\n\r\n        /// <s" +
                    "ummary>\r\n        /// Add a parameter to this dynamic parameter list\r\n        ///" +
                    " </summary>\r\n        public void Add(\r\n            string name, object value = n" +
                    "ull, DbType? dbType = null, ParameterDirection? direction = null, int? size = nu" +
                    "ll, byte? precision = null, byte? scale = null\r\n)\r\n        {\r\n            parame" +
                    "ters[Clean(name)] = new ParamInfo\r\n            {\r\n                Name = name,\r\n" +
                    "                Value = value,\r\n                ParameterDirection = direction ?" +
                    "? ParameterDirection.Input,\r\n                DbType = dbType,\r\n                S" +
                    "ize = size,\r\n                Precision = precision,\r\n                Scale = sca" +
                    "le\r\n            };\r\n        }\r\n\r\n        static string Clean(string name)\r\n     " +
                    "   {\r\n            if (!string.IsNullOrEmpty(name))\r\n            {\r\n             " +
                    "   switch (name[0])\r\n                {\r\n                    case \'@\':\r\n         " +
                    "           case \':\':\r\n                    case \'?\':\r\n                        ret" +
                    "urn name.Substring(1);\r\n                }\r\n            }\r\n            return nam" +
                    "e;\r\n        }\r\n\r\n        void SqlMapper.IDynamicParameters.AddParameters(IDbComm" +
                    "and command, SqlMapper.Identity identity)\r\n        {\r\n            AddParameters(" +
                    "command, identity);\r\n        }\r\n\r\n        /// <summary>\r\n        /// If true, th" +
                    "e command-text is inspected and only values that are clearly used are included o" +
                    "n the connection\r\n        /// </summary>\r\n        public bool RemoveUnused { get" +
                    "; set; }\r\n\r\n        /// <summary>\r\n        /// Add all the parameters needed to " +
                    "the command just before it executes\r\n        /// </summary>\r\n        /// <param " +
                    "name=\"command\">The raw command prior to execution</param>\r\n        /// <param na" +
                    "me=\"identity\">Information about the query</param>\r\n        protected void AddPar" +
                    "ameters(IDbCommand command, SqlMapper.Identity identity)\r\n        {\r\n           " +
                    " var literals = SqlMapper.GetLiteralTokens(identity.sql);\r\n\r\n            if (tem" +
                    "plates != null)\r\n            {\r\n                foreach (var template in templat" +
                    "es)\r\n                {\r\n                    var newIdent = identity.ForDynamicPa" +
                    "rameters(template.GetType());\r\n                    Action<IDbCommand, object> ap" +
                    "pender;\r\n\r\n                    lock (paramReaderCache)\r\n                    {\r\n " +
                    "                       if (!paramReaderCache.TryGetValue(newIdent, out appender)" +
                    ")\r\n                        {\r\n                            appender = SqlMapper.C" +
                    "reateParamInfoGenerator(newIdent, true, RemoveUnused, literals);\r\n              " +
                    "              paramReaderCache[newIdent] = appender;\r\n                        }\r" +
                    "\n                    }\r\n\r\n                    appender(command, template);\r\n    " +
                    "            }\r\n\r\n                // The parameters were added to the command, bu" +
                    "t not the\r\n                // DynamicParameters until now.\r\n                fore" +
                    "ach (IDbDataParameter param in command.Parameters)\r\n                {\r\n         " +
                    "           // If someone makes a DynamicParameters with a template,\r\n           " +
                    "         // then explicitly adds a parameter of a matching name,\r\n              " +
                    "      // it will already exist in \'parameters\'.\r\n                    if (!parame" +
                    "ters.ContainsKey(param.ParameterName))\r\n                    {\r\n                 " +
                    "       parameters.Add(param.ParameterName, new ParamInfo\r\n                      " +
                    "  {\r\n                            AttachedParam = param,\r\n                       " +
                    "     CameFromTemplate = true,\r\n                            DbType = param.DbType" +
                    ",\r\n                            Name = param.ParameterName,\r\n                    " +
                    "        ParameterDirection = param.Direction,\r\n                            Size " +
                    "= param.Size,\r\n                            Value = param.Value\r\n                " +
                    "        });\r\n                    }\r\n                }\r\n\r\n                // Now " +
                    "that the parameters are added to the command, let\'s place our output callbacks\r\n" +
                    "                var tmp = outputCallbacks;\r\n                if (tmp != null)\r\n  " +
                    "              {\r\n                    foreach (var generator in tmp)\r\n           " +
                    "         {\r\n                        generator();\r\n                    }\r\n       " +
                    "         }\r\n            }\r\n\r\n            foreach (var param in parameters.Values" +
                    ")\r\n            {\r\n                if (param.CameFromTemplate) continue;\r\n\r\n     " +
                    "           var dbType = param.DbType;\r\n                var val = param.Value;\r\n " +
                    "               string name = Clean(param.Name);\r\n                var isCustomQue" +
                    "ryParameter = val is SqlMapper.ICustomQueryParameter;\r\n\r\n                SqlMapp" +
                    "er.ITypeHandler handler = null;\r\n                if (dbType == null && val != nu" +
                    "ll && !isCustomQueryParameter)\r\n                {\r\n#pragma warning disable 618\r\n" +
                    "                    dbType = SqlMapper.LookupDbType(val.GetType(), name, true, o" +
                    "ut handler);\r\n#pragma warning disable 618\r\n                }\r\n                if" +
                    " (isCustomQueryParameter)\r\n                {\r\n                    ((SqlMapper.IC" +
                    "ustomQueryParameter)val).AddParameter(command, name);\r\n                }\r\n      " +
                    "          else if (dbType == EnumerableMultiParameter)\r\n                {\r\n#prag" +
                    "ma warning disable 612, 618\r\n                    SqlMapper.PackListParameters(co" +
                    "mmand, name, val);\r\n#pragma warning restore 612, 618\r\n                }\r\n       " +
                    "         else\r\n                {\r\n\r\n                    bool add = !command.Para" +
                    "meters.Contains(name);\r\n                    IDbDataParameter p;\r\n               " +
                    "     if (add)\r\n                    {\r\n                        p = command.Create" +
                    "Parameter();\r\n                        p.ParameterName = name;\r\n                 " +
                    "   }\r\n                    else\r\n                    {\r\n                        p" +
                    " = (IDbDataParameter)command.Parameters[name];\r\n                    }\r\n\r\n       " +
                    "             p.Direction = param.ParameterDirection;\r\n                    if (ha" +
                    "ndler == null)\r\n                    {\r\n#pragma warning disable 0618\r\n           " +
                    "             p.Value = SqlMapper.SanitizeParameterValue(val);\r\n#pragma warning r" +
                    "estore 0618\r\n                        if (dbType != null && p.DbType != dbType)\r\n" +
                    "                        {\r\n                            p.DbType = dbType.Value;\r" +
                    "\n                        }\r\n                        var s = val as string;\r\n    " +
                    "                    if (s?.Length <= DbString.DefaultLength)\r\n                  " +
                    "      {\r\n                            p.Size = DbString.DefaultLength;\r\n         " +
                    "               }\r\n                        if (param.Size != null) p.Size = param" +
                    ".Size.Value;\r\n                        if (param.Precision != null) p.Precision =" +
                    " param.Precision.Value;\r\n                        if (param.Scale != null) p.Scal" +
                    "e = param.Scale.Value;\r\n                    }\r\n                    else\r\n       " +
                    "             {\r\n                        if (dbType != null) p.DbType = dbType.Va" +
                    "lue;\r\n                        if (param.Size != null) p.Size = param.Size.Value;" +
                    "\r\n                        if (param.Precision != null) p.Precision = param.Preci" +
                    "sion.Value;\r\n                        if (param.Scale != null) p.Scale = param.Sc" +
                    "ale.Value;\r\n                        handler.SetValue(p, val ?? DBNull.Value);\r\n " +
                    "                   }\r\n\r\n                    if (add)\r\n                    {\r\n   " +
                    "                     command.Parameters.Add(p);\r\n                    }\r\n        " +
                    "            param.AttachedParam = p;\r\n                }\r\n            }\r\n\r\n      " +
                    "      // note: most non-priveleged implementations would use: this.ReplaceLitera" +
                    "ls(command);\r\n            if (literals.Count != 0) SqlMapper.ReplaceLiterals(thi" +
                    "s, command, literals);\r\n        }\r\n\r\n        /// <summary>\r\n        /// All the " +
                    "names of the param in the bag, use Get to yank them out\r\n        /// </summary>\r" +
                    "\n        public IEnumerable<string> ParameterNames => parameters.Select(p => p.K" +
                    "ey);\r\n\r\n\r\n        /// <summary>\r\n        /// Get the value of a parameter\r\n     " +
                    "   /// </summary>\r\n        /// <typeparam name=\"T\"></typeparam>\r\n        /// <pa" +
                    "ram name=\"name\"></param>\r\n        /// <returns>The value, note DBNull.Value is n" +
                    "ot returned, instead the value is returned as null</returns>\r\n        public T G" +
                    "et<T>(string name)\r\n        {\r\n            var paramInfo = parameters[Clean(name" +
                    ")];\r\n            var attachedParam = paramInfo.AttachedParam;\r\n            objec" +
                    "t val = attachedParam == null ? paramInfo.Value : attachedParam.Value;\r\n        " +
                    "    if (val == DBNull.Value)\r\n            {\r\n                if (default(T) != n" +
                    "ull)\r\n                {\r\n                    throw new ApplicationException(\"Att" +
                    "empting to cast a DBNull to a non nullable type! Note that out/return parameters" +
                    " will not have updated values until the data stream completes (after the \'foreac" +
                    "h\' for Query(..., buffered: false), or after the GridReader has been disposed fo" +
                    "r QueryMultiple)\");\r\n                }\r\n                return default(T);\r\n    " +
                    "        }\r\n            return (T)val;\r\n        }\r\n\r\n        /// <summary>\r\n     " +
                    "   /// Allows you to automatically populate a target property/field from output " +
                    "parameters. It actually\r\n        /// creates an InputOutput parameter, so you ca" +
                    "n still pass data in.\r\n        /// </summary>\r\n        /// <typeparam name=\"T\"><" +
                    "/typeparam>\r\n        /// <param name=\"target\">The object whose property/field yo" +
                    "u wish to populate.</param>\r\n        /// <param name=\"expression\">A MemberExpres" +
                    "sion targeting a property/field of the target (or descendant thereof.)</param>\r\n" +
                    "        /// <param name=\"dbType\"></param>\r\n        /// <param name=\"size\">The si" +
                    "ze to set on the parameter. Defaults to 0, or DbString.DefaultLength in case of " +
                    "strings.</param>\r\n        /// <returns>The DynamicParameters instance</returns>\r" +
                    "\n        public DynamicParameters Output<T>(T target, Expression<Func<T, object>" +
                    "> expression, DbType? dbType = null, int? size = null)\r\n        {\r\n            v" +
                    "ar failMessage = \"Expression must be a property/field chain off of a(n) {0} inst" +
                    "ance\";\r\n            failMessage = string.Format(failMessage, typeof(T).Name);\r\n " +
                    "           Action @throw = () => { throw new InvalidOperationException(failMessa" +
                    "ge); };\r\n\r\n            // Is it even a MemberExpression?\r\n            var lastMe" +
                    "mberAccess = expression.Body as MemberExpression;\r\n\r\n            if (lastMemberA" +
                    "ccess == null ||\r\n                (!(lastMemberAccess.Member is PropertyInfo) &&" +
                    "\r\n                !(lastMemberAccess.Member is FieldInfo)))\r\n            {\r\n    " +
                    "            if (expression.Body.NodeType == ExpressionType.Convert &&\r\n         " +
                    "           expression.Body.Type == typeof(object) &&\r\n                    ((Unar" +
                    "yExpression)expression.Body).Operand is MemberExpression)\r\n                {\r\n  " +
                    "                  // It\'s got to be unboxed\r\n                    lastMemberAcces" +
                    "s = (MemberExpression)((UnaryExpression)expression.Body).Operand;\r\n             " +
                    "   }\r\n                else @throw();\r\n            }\r\n\r\n            // Does the c" +
                    "hain consist of MemberExpressions leading to a ParameterExpression of type T?\r\n " +
                    "           MemberExpression diving = lastMemberAccess;\r\n            // Retain a " +
                    "list of member names and the member expressions so we can rebuild the chain.\r\n  " +
                    "          List<string> names = new List<string>();\r\n            List<MemberExpre" +
                    "ssion> chain = new List<MemberExpression>();\r\n\r\n            do\r\n            {\r\n " +
                    "               // Insert the names in the right order so expression\r\n           " +
                    "     // \"Post.Author.Name\" becomes parameter \"PostAuthorName\"\r\n                n" +
                    "ames.Insert(0, diving?.Member.Name);\r\n                chain.Insert(0, diving);\r\n" +
                    "\r\n                var constant = diving?.Expression as ParameterExpression;\r\n   " +
                    "             diving = diving?.Expression as MemberExpression;\r\n\r\n               " +
                    " if (constant != null &&\r\n                    constant.Type == typeof(T))\r\n     " +
                    "           {\r\n                    break;\r\n                }\r\n                els" +
                    "e if (diving == null ||\r\n                    (!(diving.Member is PropertyInfo) &" +
                    "&\r\n                    !(diving.Member is FieldInfo)))\r\n                {\r\n     " +
                    "               @throw();\r\n                }\r\n            }\r\n            while (d" +
                    "iving != null);\r\n\r\n            var dynamicParamName = string.Join(string.Empty, " +
                    "names.ToArray());\r\n\r\n            // Before we get all emitty...\r\n            var" +
                    " lookup = string.Join(\"|\", names.ToArray());\r\n\r\n            var cache = CachedOu" +
                    "tputSetters<T>.Cache;\r\n            var setter = (Action<object, DynamicParameter" +
                    "s>)cache[lookup];\r\n            if (setter != null) goto MAKECALLBACK;\r\n\r\n       " +
                    "     // Come on let\'s build a method, let\'s build it, let\'s build it now!\r\n     " +
                    "       var dm = new DynamicMethod(\"ExpressionParam\" + Guid.NewGuid().ToString()," +
                    " null, new[] { typeof(object), GetType() }, true);\r\n            var il = dm.GetI" +
                    "LGenerator();\r\n\r\n            il.Emit(OpCodes.Ldarg_0); // [object]\r\n            " +
                    "il.Emit(OpCodes.Castclass, typeof(T));    // [T]\r\n\r\n            // Count - 1 to " +
                    "skip the last member access\r\n            var i = 0;\r\n            for (; i < (cha" +
                    "in.Count - 1); i++)\r\n            {\r\n                var member = chain[0].Member" +
                    ";\r\n\r\n                if (member is PropertyInfo)\r\n                {\r\n           " +
                    "         var get = ((PropertyInfo)member).GetGetMethod(true);\r\n                 " +
                    "   il.Emit(OpCodes.Callvirt, get); // [Member{i}]\r\n                }\r\n          " +
                    "      else // Else it must be a field!\r\n                {\r\n                    i" +
                    "l.Emit(OpCodes.Ldfld, ((FieldInfo)member)); // [Member{i}]\r\n                }\r\n " +
                    "           }\r\n\r\n            var paramGetter = GetType().GetMethod(\"Get\", new Typ" +
                    "e[] { typeof(string) }).MakeGenericMethod(lastMemberAccess.Type);\r\n\r\n           " +
                    " il.Emit(OpCodes.Ldarg_1); // [target] [DynamicParameters]\r\n            il.Emit(" +
                    "OpCodes.Ldstr, dynamicParamName); // [target] [DynamicParameters] [ParamName]\r\n " +
                    "           il.Emit(OpCodes.Callvirt, paramGetter); // [target] [value], it\'s alr" +
                    "eady typed thanks to generic method\r\n\r\n            // GET READY\r\n            var" +
                    " lastMember = lastMemberAccess.Member;\r\n            if (lastMember is PropertyIn" +
                    "fo)\r\n            {\r\n                var set = ((PropertyInfo)lastMember).GetSetM" +
                    "ethod(true);\r\n                il.Emit(OpCodes.Callvirt, set); // SET\r\n          " +
                    "  }\r\n            else\r\n            {\r\n                il.Emit(OpCodes.Stfld, ((F" +
                    "ieldInfo)lastMember)); // SET\r\n            }\r\n\r\n            il.Emit(OpCodes.Ret)" +
                    "; // GO\r\n\r\n            setter = (Action<object, DynamicParameters>)dm.CreateDele" +
                    "gate(typeof(Action<object, DynamicParameters>));\r\n            lock (cache)\r\n    " +
                    "        {\r\n                cache[lookup] = setter;\r\n            }\r\n\r\n        // " +
                    "Queue the preparation to be fired off when adding parameters to the DbCommand\r\n " +
                    "       MAKECALLBACK:\r\n            (outputCallbacks ?? (outputCallbacks = new Lis" +
                    "t<Action>())).Add(() =>\r\n            {\r\n                // Finally, prep the par" +
                    "ameter and attach the callback to it\r\n                ParamInfo parameter;\r\n    " +
                    "            var targetMemberType = lastMemberAccess?.Type;\r\n                int " +
                    "sizeToSet = (!size.HasValue && targetMemberType == typeof(string)) ? DbString.De" +
                    "faultLength : size ?? 0;\r\n\r\n                if (parameters.TryGetValue(dynamicPa" +
                    "ramName, out parameter))\r\n                {\r\n                    parameter.Param" +
                    "eterDirection = parameter.AttachedParam.Direction = ParameterDirection.InputOutp" +
                    "ut;\r\n\r\n                    if (parameter.AttachedParam.Size == 0)\r\n             " +
                    "       {\r\n                        parameter.Size = parameter.AttachedParam.Size " +
                    "= sizeToSet;\r\n                    }\r\n                }\r\n                else\r\n  " +
                    "              {\r\n                    SqlMapper.ITypeHandler handler;\r\n          " +
                    "          dbType = (!dbType.HasValue)\r\n#pragma warning disable 618\r\n            " +
                    "        ? SqlMapper.LookupDbType(targetMemberType, targetMemberType?.Name, true," +
                    " out handler)\r\n#pragma warning restore 618\r\n                    : dbType;\r\n\r\n   " +
                    "                 // CameFromTemplate property would not apply here because this " +
                    "new param\r\n                    // Still needs to be added to the command\r\n      " +
                    "              Add(dynamicParamName, expression.Compile().Invoke(target), null, P" +
                    "arameterDirection.InputOutput, sizeToSet);\r\n                }\r\n\r\n               " +
                    " parameter = parameters[dynamicParamName];\r\n                parameter.OutputCall" +
                    "back = setter;\r\n                parameter.OutputTarget = target;\r\n            })" +
                    ";\r\n\r\n            return this;\r\n        }\r\n\r\n        private List<Action> outputC" +
                    "allbacks;\r\n\r\n        void SqlMapper.IParameterCallbacks.OnCompleted()\r\n        {" +
                    "\r\n            foreach (var param in (from p in parameters select p.Value))\r\n    " +
                    "        {\r\n                param.OutputCallback?.Invoke(param.OutputTarget, this" +
                    ");\r\n            }\r\n        }\r\n    }\r\n}");
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
    public class DynamicParametersBase
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
