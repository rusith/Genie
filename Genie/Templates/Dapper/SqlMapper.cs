﻿namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class SqlMapper : SqlMapperBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using Label = System.Reflection.Emit.Label;

namespace ");
            
            #line 20 "D:\Projects\Genie\Genie\Templates\Dapper\SqlMapper.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper \r\n{\r\n    /// <summary>\r\n    /// Dapper, a light weight object mapper for " +
                    "ADO.NET\r\n    /// </summary>\r\n    public static partial class SqlMapper\r\n    {\r\n " +
                    "       static int GetColumnHash(IDataReader reader, int startBound = 0, int leng" +
                    "th = -1)\r\n        {\r\n            unchecked\r\n            {\r\n                int m" +
                    "ax = length < 0 ? reader.FieldCount : startBound + length;\r\n                int " +
                    "hash = (-37 * startBound) + max;\r\n                for (int i = startBound; i < m" +
                    "ax; i++)\r\n                {\r\n                    object tmp = reader.GetName(i);" +
                    "\r\n                    hash = -79 * ((hash * 31) + (tmp?.GetHashCode() ?? 0)) + (" +
                    "reader.GetFieldType(i)?.GetHashCode() ?? 0);\r\n                }\r\n               " +
                    " return hash;\r\n            }\r\n        }\r\n\r\n\r\n        /// <summary>\r\n        /// " +
                    "Called if the query cache is purged via PurgeQueryCache\r\n        /// </summary>\r" +
                    "\n        public static event EventHandler QueryCachePurged;\r\n        private sta" +
                    "tic void OnQueryCachePurged()\r\n        {\r\n            var handler = QueryCachePu" +
                    "rged;\r\n            handler?.Invoke(null, EventArgs.Empty);\r\n        }\r\n\r\n       " +
                    " static readonly System.Collections.Concurrent.ConcurrentDictionary<Identity, Ca" +
                    "cheInfo> _queryCache = new System.Collections.Concurrent.ConcurrentDictionary<Id" +
                    "entity, CacheInfo>();\r\n        private static void SetQueryCache(Identity key, C" +
                    "acheInfo value)\r\n        {\r\n            if (Interlocked.Increment(ref collect) =" +
                    "= COLLECT_PER_ITEMS)\r\n            {\r\n                CollectCacheGarbage();\r\n   " +
                    "         }\r\n            _queryCache[key] = value;\r\n        }\r\n\r\n        private " +
                    "static void CollectCacheGarbage()\r\n        {\r\n            try\r\n            {\r\n  " +
                    "              foreach (var pair in _queryCache)\r\n                {\r\n            " +
                    "        if (pair.Value.GetHitCount() <= COLLECT_HIT_COUNT_MIN)\r\n                " +
                    "    {\r\n                        CacheInfo cache;\r\n                        _queryC" +
                    "ache.TryRemove(pair.Key, out cache);\r\n                    }\r\n                }\r\n" +
                    "            }\r\n\r\n            finally\r\n            {\r\n                Interlocked" +
                    ".Exchange(ref collect, 0);\r\n            }\r\n        }\r\n\r\n        private const in" +
                    "t COLLECT_PER_ITEMS = 1000, COLLECT_HIT_COUNT_MIN = 0;\r\n        private static i" +
                    "nt collect;\r\n        private static bool TryGetQueryCache(Identity key, out Cach" +
                    "eInfo value)\r\n        {\r\n            if (_queryCache.TryGetValue(key, out value)" +
                    ")\r\n            {\r\n                value.RecordHit();\r\n                return tru" +
                    "e;\r\n            }\r\n            value = null;\r\n            return false;\r\n       " +
                    " }\r\n\r\n        /// <summary>\r\n        /// Purge the query cache\r\n        /// </su" +
                    "mmary>\r\n        public static void PurgeQueryCache()\r\n        {\r\n            _qu" +
                    "eryCache.Clear();\r\n            TypeDeserializerCache.Purge();\r\n            OnQue" +
                    "ryCachePurged();\r\n        }\r\n\r\n        private static void PurgeQueryCacheByType" +
                    "(Type type)\r\n        {\r\n            foreach (var entry in _queryCache)\r\n        " +
                    "    {\r\n                CacheInfo cache;\r\n                if (entry.Key.type == t" +
                    "ype)\r\n                    _queryCache.TryRemove(entry.Key, out cache);\r\n        " +
                    "    }\r\n            TypeDeserializerCache.Purge(type);\r\n        }\r\n\r\n        /// " +
                    "<summary>\r\n        /// Return a count of all the cached queries by dapper\r\n     " +
                    "   /// </summary>\r\n        /// <returns></returns>\r\n        public static int Ge" +
                    "tCachedSQLCount()\r\n        {\r\n            return _queryCache.Count;\r\n        }\r\n" +
                    "\r\n        /// <summary>\r\n        /// Return a list of all the queries cached by " +
                    "dapper\r\n        /// </summary>\r\n        /// <param name=\"ignoreHitCountAbove\"></" +
                    "param>\r\n        /// <returns></returns>\r\n        public static IEnumerable<Tuple" +
                    "<string, string, int>> GetCachedSQL(int ignoreHitCountAbove = int.MaxValue)\r\n   " +
                    "     {\r\n            var data = _queryCache.Select(pair => Tuple.Create(pair.Key." +
                    "connectionString, pair.Key.sql, pair.Value.GetHitCount()));\r\n            if (ign" +
                    "oreHitCountAbove < int.MaxValue) data = data.Where(tuple => tuple.Item3 <= ignor" +
                    "eHitCountAbove);\r\n            return data;\r\n        }\r\n\r\n        /// <summary>\r\n" +
                    "        /// Deep diagnostics only: find any hash collisions in the cache\r\n      " +
                    "  /// </summary>\r\n        /// <returns></returns>\r\n        public static IEnumer" +
                    "able<Tuple<int, int>> GetHashCollissions()\r\n        {\r\n            var counts = " +
                    "new Dictionary<int, int>();\r\n            foreach (var key in _queryCache.Keys)\r\n" +
                    "            {\r\n                int count;\r\n                if (!counts.TryGetVal" +
                    "ue(key.hashCode, out count))\r\n                {\r\n                    counts.Add(" +
                    "key.hashCode, 1);\r\n                }\r\n                else\r\n                {\r\n " +
                    "                   counts[key.hashCode] = count + 1;\r\n                }\r\n       " +
                    "     }\r\n            return from pair in counts\r\n                   where pair.Va" +
                    "lue > 1\r\n                   select Tuple.Create(pair.Key, pair.Value);\r\n\r\n      " +
                    "  }\r\n\r\n\r\n        static Dictionary<Type, DbType> typeMap;\r\n\r\n        static SqlM" +
                    "apper()\r\n        {\r\n            typeMap = new Dictionary<Type, DbType>\r\n        " +
                    "    {\r\n                [typeof(byte)] = DbType.Byte,\r\n                [typeof(sb" +
                    "yte)] = DbType.SByte,\r\n                [typeof(short)] = DbType.Int16,\r\n        " +
                    "        [typeof(ushort)] = DbType.UInt16,\r\n                [typeof(int)] = DbTyp" +
                    "e.Int32,\r\n                [typeof(uint)] = DbType.UInt32,\r\n                [type" +
                    "of(long)] = DbType.Int64,\r\n                [typeof(ulong)] = DbType.UInt64,\r\n   " +
                    "             [typeof(float)] = DbType.Single,\r\n                [typeof(double)] " +
                    "= DbType.Double,\r\n                [typeof(decimal)] = DbType.Decimal,\r\n         " +
                    "       [typeof(bool)] = DbType.Boolean,\r\n                [typeof(string)] = DbTy" +
                    "pe.String,\r\n                [typeof(char)] = DbType.StringFixedLength,\r\n        " +
                    "        [typeof(Guid)] = DbType.Guid,\r\n                [typeof(DateTime)] = DbTy" +
                    "pe.DateTime,\r\n                [typeof(DateTimeOffset)] = DbType.DateTimeOffset,\r" +
                    "\n                [typeof(TimeSpan)] = DbType.Time,\r\n                [typeof(byte" +
                    "[])] = DbType.Binary,\r\n                [typeof(byte?)] = DbType.Byte,\r\n         " +
                    "       [typeof(sbyte?)] = DbType.SByte,\r\n                [typeof(short?)] = DbTy" +
                    "pe.Int16,\r\n                [typeof(ushort?)] = DbType.UInt16,\r\n                [" +
                    "typeof(int?)] = DbType.Int32,\r\n                [typeof(uint?)] = DbType.UInt32,\r" +
                    "\n                [typeof(long?)] = DbType.Int64,\r\n                [typeof(ulong?" +
                    ")] = DbType.UInt64,\r\n                [typeof(float?)] = DbType.Single,\r\n        " +
                    "        [typeof(double?)] = DbType.Double,\r\n                [typeof(decimal?)] =" +
                    " DbType.Decimal,\r\n                [typeof(bool?)] = DbType.Boolean,\r\n           " +
                    "     [typeof(char?)] = DbType.StringFixedLength,\r\n                [typeof(Guid?)" +
                    "] = DbType.Guid,\r\n                [typeof(DateTime?)] = DbType.DateTime,\r\n      " +
                    "          [typeof(DateTimeOffset?)] = DbType.DateTimeOffset,\r\n                [t" +
                    "ypeof(TimeSpan?)] = DbType.Time,\r\n                [typeof(object)] = DbType.Obje" +
                    "ct\r\n            };\r\n            ResetTypeHandlers(false);\r\n        }\r\n\r\n        " +
                    "/// <summary>\r\n        /// Clear the registered type handlers\r\n        /// </sum" +
                    "mary>\r\n        public static void ResetTypeHandlers()\r\n        {\r\n            Re" +
                    "setTypeHandlers(true);\r\n        }\r\n        private static void ResetTypeHandlers" +
                    "(bool clone)\r\n        {\r\n            typeHandlers = new Dictionary<Type, ITypeHa" +
                    "ndler>();\r\n#if !COREFX\r\n            AddTypeHandlerImpl(typeof(DataTable), new Da" +
                    "taTableHandler(), clone);\r\n            try // see https://github.com/StackExchan" +
                    "ge/dapper-dot-net/issues/424\r\n            {\r\n                AddSqlDataRecordsTy" +
                    "peHandler(clone);\r\n            }\r\n            catch { }\r\n#endif\r\n            Add" +
                    "TypeHandlerImpl(typeof(XmlDocument), new XmlDocumentHandler(), clone);\r\n        " +
                    "    AddTypeHandlerImpl(typeof(XDocument), new XDocumentHandler(), clone);\r\n     " +
                    "       AddTypeHandlerImpl(typeof(XElement), new XElementHandler(), clone);\r\n\r\n  " +
                    "          allowedCommandBehaviors = DefaultAllowedCommandBehaviors;\r\n        }\r\n" +
                    "#if !COREFX\r\n        [MethodImpl(MethodImplOptions.NoInlining)]\r\n        private" +
                    " static void AddSqlDataRecordsTypeHandler(bool clone)\r\n        {\r\n            Ad" +
                    "dTypeHandlerImpl(typeof(IEnumerable<Microsoft.SqlServer.Server.SqlDataRecord>), " +
                    "new SqlDataRecordHandler(), clone);\r\n        }\r\n#endif\r\n\r\n        /// <summary>\r" +
                    "\n        /// Configure the specified type to be mapped to a given db-type\r\n     " +
                    "   /// </summary>\r\n        public static void AddTypeMap(Type type, DbType dbTyp" +
                    "e)\r\n        {\r\n            // use clone, mutate, replace to avoid threading issu" +
                    "es\r\n            var snapshot = typeMap;\r\n\r\n            DbType oldValue;\r\n       " +
                    "     if (snapshot.TryGetValue(type, out oldValue) && oldValue == dbType) return;" +
                    " // nothing to do\r\n\r\n            var newCopy = new Dictionary<Type, DbType>(snap" +
                    "shot) { [type] = dbType };\r\n            typeMap = newCopy;\r\n        }\r\n\r\n       " +
                    " /// <summary>\r\n        /// Configure the specified type to be processed by a cu" +
                    "stom handler\r\n        /// </summary>\r\n        public static void AddTypeHandler(" +
                    "Type type, ITypeHandler handler)\r\n        {\r\n            AddTypeHandlerImpl(type" +
                    ", handler, true);\r\n        }\r\n\r\n        internal static bool HasTypeHandler(Type" +
                    " type)\r\n        {\r\n            return typeHandlers.ContainsKey(type);\r\n        }" +
                    "\r\n\r\n        /// <summary>\r\n        /// Configure the specified type to be proces" +
                    "sed by a custom handler\r\n        /// </summary>\r\n        public static void AddT" +
                    "ypeHandlerImpl(Type type, ITypeHandler handler, bool clone)\r\n        {\r\n        " +
                    "    if (type == null) throw new ArgumentNullException(\"type\");\r\n\r\n            Ty" +
                    "pe secondary = null;\r\n            if (type.IsValueType)\r\n            {\r\n        " +
                    "        var underlying = Nullable.GetUnderlyingType(type);\r\n                if (" +
                    "underlying == null)\r\n                {\r\n                    secondary = typeof(N" +
                    "ullable<>).MakeGenericType(type); // the Nullable<T>\r\n                    // typ" +
                    "e is already the T\r\n                }\r\n                else\r\n                {\r\n" +
                    "                    secondary = type; // the Nullable<T>\r\n                    ty" +
                    "pe = underlying; // the T\r\n                }\r\n            }\r\n\r\n            var s" +
                    "napshot = typeHandlers;\r\n            ITypeHandler oldValue;\r\n            if (sna" +
                    "pshot.TryGetValue(type, out oldValue) && handler == oldValue) return; // nothing" +
                    " to do\r\n\r\n            var newCopy = clone ? new Dictionary<Type, ITypeHandler>(s" +
                    "napshot) : snapshot;\r\n\r\n#pragma warning disable 618\r\n            typeof(TypeHand" +
                    "lerCache<>).MakeGenericType(type).GetMethod(nameof(TypeHandlerCache<int>.SetHand" +
                    "ler), BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new object[] { " +
                    "handler });\r\n            if (secondary != null)\r\n            {\r\n                " +
                    "typeof(TypeHandlerCache<>).MakeGenericType(secondary).GetMethod(nameof(TypeHandl" +
                    "erCache<int>.SetHandler), BindingFlags.Static | BindingFlags.NonPublic).Invoke(n" +
                    "ull, new object[] { handler });\r\n            }\r\n#pragma warning restore 618\r\n   " +
                    "         if (handler == null)\r\n            {\r\n                newCopy.Remove(typ" +
                    "e);\r\n                if (secondary != null) newCopy.Remove(secondary);\r\n        " +
                    "    }\r\n            else\r\n            {\r\n                newCopy[type] = handler;" +
                    "\r\n                if (secondary != null) newCopy[secondary] = handler;\r\n        " +
                    "    }\r\n            typeHandlers = newCopy;\r\n        }\r\n\r\n        /// <summary>\r\n" +
                    "        /// Configure the specified type to be processed by a custom handler\r\n  " +
                    "      /// </summary>\r\n        public static void AddTypeHandler<T>(TypeHandler<T" +
                    "> handler)\r\n        {\r\n            AddTypeHandlerImpl(typeof(T), handler, true);" +
                    "\r\n        }\r\n\r\n        private static Dictionary<Type, ITypeHandler> typeHandler" +
                    "s;\r\n\r\n        internal const string LinqBinary = \"System.Data.Linq.Binary\";\r\n\r\n " +
                    "       private const string ObsoleteInternalUsageOnly = \"This method is for inte" +
                    "rnal use only\";\r\n\r\n        /// <summary>\r\n        /// Get the DbType that maps t" +
                    "o a given value\r\n        /// </summary>\r\n        [Obsolete(ObsoleteInternalUsage" +
                    "Only, false)]\r\n#if !COREFX\r\n        [Browsable(false)]\r\n#endif\r\n        [EditorB" +
                    "rowsable(EditorBrowsableState.Never)]\r\n        public static DbType GetDbType(ob" +
                    "ject value)\r\n        {\r\n            if (value == null || value is DBNull) return" +
                    " DbType.Object;\r\n\r\n            ITypeHandler handler;\r\n            return LookupD" +
                    "bType(value.GetType(), \"n/a\", false, out handler);\r\n\r\n        }\r\n\r\n        /// <" +
                    "summary>\r\n        /// OBSOLETE: For internal usage only. Lookup the DbType and h" +
                    "andler for a given Type and member\r\n        /// </summary>\r\n        [Obsolete(Ob" +
                    "soleteInternalUsageOnly, false)]\r\n#if !COREFX\r\n        [Browsable(false)]\r\n#endi" +
                    "f\r\n        [EditorBrowsable(EditorBrowsableState.Never)]\r\n        public static " +
                    "DbType LookupDbType(Type type, string name, bool demand, out ITypeHandler handle" +
                    "r)\r\n        {\r\n            DbType dbType;\r\n            handler = null;\r\n        " +
                    "    var nullUnderlyingType = Nullable.GetUnderlyingType(type);\r\n            if (" +
                    "nullUnderlyingType != null) type = nullUnderlyingType;\r\n            if (type.IsE" +
                    "num && !typeMap.ContainsKey(type))\r\n            {\r\n                type = Enum.G" +
                    "etUnderlyingType(type);\r\n            }\r\n            if (typeMap.TryGetValue(type" +
                    ", out dbType))\r\n            {\r\n                return dbType;\r\n            }\r\n  " +
                    "          if (type.FullName == LinqBinary)\r\n            {\r\n                retur" +
                    "n DbType.Binary;\r\n            }\r\n            if (typeHandlers.TryGetValue(type, " +
                    "out handler))\r\n            {\r\n                return DbType.Object;\r\n           " +
                    " }\r\n            if (typeof(IEnumerable).IsAssignableFrom(type))\r\n            {\r\n" +
                    "                return DynamicParameters.EnumerableMultiParameter;\r\n            " +
                    "}\r\n\r\n#if !COREFX\r\n            switch (type.FullName)\r\n            {\r\n           " +
                    "     case \"Microsoft.SqlServer.Types.SqlGeography\":\r\n                    AddType" +
                    "Handler(type, handler = new UdtTypeHandler(\"geography\"));\r\n                    r" +
                    "eturn DbType.Object;\r\n                case \"Microsoft.SqlServer.Types.SqlGeometr" +
                    "y\":\r\n                    AddTypeHandler(type, handler = new UdtTypeHandler(\"geom" +
                    "etry\"));\r\n                    return DbType.Object;\r\n                case \"Micro" +
                    "soft.SqlServer.Types.SqlHierarchyId\":\r\n                    AddTypeHandler(type, " +
                    "handler = new UdtTypeHandler(\"hierarchyid\"));\r\n                    return DbType" +
                    ".Object;\r\n            }\r\n#endif\r\n            if (demand)\r\n                throw " +
                    "new NotSupportedException($\"The member {name} of type {type.FullName} cannot be " +
                    "used as a parameter value\");\r\n            return DbType.Object;\r\n\r\n        }\r\n\r\n" +
                    "\r\n\r\n        /// <summary>\r\n        /// Obtains the data as a list; if it is *alr" +
                    "eady* a list, the original object is returned without\r\n        /// any duplicati" +
                    "on; otherwise, ToList() is invoked.\r\n        /// </summary>\r\n        public stat" +
                    "ic List<T> AsList<T>(this IEnumerable<T> source)\r\n        {\r\n            return " +
                    "(source == null || source is List<T>) ? (List<T>)source : source.ToList();\r\n    " +
                    "    }\r\n\r\n        /// <summary>\r\n        /// Execute parameterized SQL\r\n        /" +
                    "// </summary>\r\n        /// <returns>Number of rows affected</returns>\r\n        p" +
                    "ublic static int Execute(\r\n            this IDbConnection cnn, string sql, objec" +
                    "t param = null, IDbTransaction transaction = null, int? commandTimeout = null, C" +
                    "ommandType? commandType = null\r\n        )\r\n        {\r\n            var command = " +
                    "new CommandDefinition(sql, param, transaction, commandTimeout, commandType, Comm" +
                    "andFlags.Buffered);\r\n            return ExecuteImpl(cnn, ref command);\r\n        " +
                    "}\r\n        /// <summary>\r\n        /// Execute parameterized SQL\r\n        /// </s" +
                    "ummary>\r\n        /// <returns>Number of rows affected</returns>\r\n        public " +
                    "static int Execute(this IDbConnection cnn, CommandDefinition command)\r\n        {" +
                    "\r\n            return ExecuteImpl(cnn, ref command);\r\n        }\r\n\r\n\r\n        /// " +
                    "<summary>\r\n        /// Execute parameterized SQL that selects a single value\r\n  " +
                    "      /// </summary>\r\n        /// <returns>The first cell selected</returns>\r\n  " +
                    "      public static object ExecuteScalar(\r\n            this IDbConnection cnn, s" +
                    "tring sql, object param = null, IDbTransaction transaction = null, int? commandT" +
                    "imeout = null, CommandType? commandType = null\r\n        )\r\n        {\r\n          " +
                    "  var command = new CommandDefinition(sql, param, transaction, commandTimeout, c" +
                    "ommandType, CommandFlags.Buffered);\r\n            return ExecuteScalarImpl<object" +
                    ">(cnn, ref command);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Execute pa" +
                    "rameterized SQL that selects a single value\r\n        /// </summary>\r\n        ///" +
                    " <returns>The first cell selected</returns>\r\n        public static T ExecuteScal" +
                    "ar<T>(\r\n            this IDbConnection cnn, string sql, object param = null, IDb" +
                    "Transaction transaction = null, int? commandTimeout = null, CommandType? command" +
                    "Type = null\r\n        )\r\n        {\r\n            var command = new CommandDefiniti" +
                    "on(sql, param, transaction, commandTimeout, commandType, CommandFlags.Buffered);" +
                    "\r\n            return ExecuteScalarImpl<T>(cnn, ref command);\r\n        }\r\n\r\n     " +
                    "   /// <summary>\r\n        /// Execute parameterized SQL that selects a single va" +
                    "lue\r\n        /// </summary>\r\n        /// <returns>The first cell selected</retur" +
                    "ns>\r\n        public static object ExecuteScalar(this IDbConnection cnn, CommandD" +
                    "efinition command)\r\n        {\r\n            return ExecuteScalarImpl<object>(cnn," +
                    " ref command);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Execute paramete" +
                    "rized SQL that selects a single value\r\n        /// </summary>\r\n        /// <retu" +
                    "rns>The first cell selected</returns>\r\n        public static T ExecuteScalar<T>(" +
                    "this IDbConnection cnn, CommandDefinition command)\r\n        {\r\n            retur" +
                    "n ExecuteScalarImpl<T>(cnn, ref command);\r\n        }\r\n\r\n        private static I" +
                    "Enumerable GetMultiExec(object param)\r\n        {\r\n            return (param is I" +
                    "Enumerable &&\r\n                    !(param is string ||\r\n                      p" +
                    "aram is IEnumerable<KeyValuePair<string, object>> ||\r\n                      para" +
                    "m is IDynamicParameters)\r\n                ) ? (IEnumerable)param : null;\r\n      " +
                    "  }\r\n\r\n        private static int ExecuteImpl(this IDbConnection cnn, ref Comman" +
                    "dDefinition command)\r\n        {\r\n            object param = command.Parameters;\r" +
                    "\n            IEnumerable multiExec = GetMultiExec(param);\r\n            Identity " +
                    "identity;\r\n            CacheInfo info = null;\r\n            if (multiExec != null" +
                    ")\r\n            {\r\n#if ASYNC\r\n                if((command.Flags & CommandFlags.Pi" +
                    "pelined) != 0)\r\n                {\r\n                    // this includes all the " +
                    "code for concurrent/overlapped query\r\n                    return ExecuteMultiImp" +
                    "lAsync(cnn, command, multiExec).Result;\r\n                }\r\n#endif\r\n            " +
                    "    bool isFirst = true;\r\n                int total = 0;\r\n                bool w" +
                    "asClosed = cnn.State == ConnectionState.Closed;\r\n                try\r\n          " +
                    "      {\r\n                    if (wasClosed) cnn.Open();\r\n                    usi" +
                    "ng (var cmd = command.SetupCommand(cnn, null))\r\n                    {\r\n         " +
                    "               string masterSql = null;\r\n                        foreach (var ob" +
                    "j in multiExec)\r\n                        {\r\n                            if (isFi" +
                    "rst)\r\n                            {\r\n                                masterSql =" +
                    " cmd.CommandText;\r\n                                isFirst = false;\r\n           " +
                    "                     identity = new Identity(command.CommandText, cmd.CommandTyp" +
                    "e, cnn, null, obj.GetType(), null);\r\n                                info = GetC" +
                    "acheInfo(identity, obj, command.AddToCache);\r\n                            }\r\n   " +
                    "                         else\r\n                            {\r\n                  " +
                    "              cmd.CommandText = masterSql; // because we do magic replaces on \"i" +
                    "n\" etc\r\n                                cmd.Parameters.Clear(); // current code " +
                    "is Add-tastic\r\n                            }\r\n                            info.P" +
                    "aramReader(cmd, obj);\r\n                            total += cmd.ExecuteNonQuery(" +
                    ");\r\n                        }\r\n                    }\r\n                    comman" +
                    "d.OnCompleted();\r\n                }\r\n                finally\r\n                {\r" +
                    "\n                    if (wasClosed) cnn.Close();\r\n                }\r\n           " +
                    "     return total;\r\n            }\r\n\r\n            // nice and simple\r\n           " +
                    " if (param != null)\r\n            {\r\n                identity = new Identity(comm" +
                    "and.CommandText, command.CommandType, cnn, null, param.GetType(), null);\r\n      " +
                    "          info = GetCacheInfo(identity, param, command.AddToCache);\r\n           " +
                    " }\r\n            return ExecuteCommand(cnn, ref command, param == null ? null : i" +
                    "nfo.ParamReader);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Execute param" +
                    "eterized SQL and return an <see cref=\"IDataReader\"/>\r\n        /// </summary>\r\n  " +
                    "      /// <returns>An <see cref=\"IDataReader\"/> that can be used to iterate over" +
                    " the results of the SQL query.</returns>\r\n        /// <remarks>\r\n        /// Thi" +
                    "s is typically used when the results of a query are not processed by Dapper, for" +
                    " example, used to fill a <see cref=\"DataTable\"/>\r\n        /// or <see cref=\"T:Da" +
                    "taSet\"/>.\r\n        /// </remarks>\r\n        /// <example>\r\n        /// <code>\r\n  " +
                    "      /// <![CDATA[\r\n        /// DataTable table = new DataTable(\"MyTable\");\r\n  " +
                    "      /// using (var reader = ExecuteReader(cnn, sql, param))\r\n        /// {\r\n  " +
                    "      ///     table.Load(reader);\r\n        /// }\r\n        /// ]]>\r\n        /// <" +
                    "/code>\r\n        /// </example>\r\n        public static IDataReader ExecuteReader(" +
                    "\r\n            this IDbConnection cnn, string sql, object param = null, IDbTransa" +
                    "ction transaction = null, int? commandTimeout = null, CommandType? commandType =" +
                    " null\r\n)\r\n        {\r\n            var command = new CommandDefinition(sql, param," +
                    " transaction, commandTimeout, commandType, CommandFlags.Buffered);\r\n            " +
                    "IDbCommand dbcmd;\r\n            var reader = ExecuteReaderImpl(cnn, ref command, " +
                    "CommandBehavior.Default, out dbcmd);\r\n            return new WrappedReader(dbcmd" +
                    ", reader);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Execute parameterize" +
                    "d SQL and return an <see cref=\"IDataReader\"/>\r\n        /// </summary>\r\n        /" +
                    "// <returns>An <see cref=\"IDataReader\"/> that can be used to iterate over the re" +
                    "sults of the SQL query.</returns>\r\n        /// <remarks>\r\n        /// This is ty" +
                    "pically used when the results of a query are not processed by Dapper, for exampl" +
                    "e, used to fill a <see cref=\"DataTable\"/>\r\n        /// or <see cref=\"T:DataSet\"/" +
                    ">.\r\n        /// </remarks>\r\n        public static IDataReader ExecuteReader(this" +
                    " IDbConnection cnn, CommandDefinition command)\r\n        {\r\n            IDbComman" +
                    "d dbcmd;\r\n            var reader = ExecuteReaderImpl(cnn, ref command, CommandBe" +
                    "havior.Default, out dbcmd);\r\n            return new WrappedReader(dbcmd, reader)" +
                    ";\r\n        }\r\n        /// <summary>\r\n        /// Execute parameterized SQL and r" +
                    "eturn an <see cref=\"IDataReader\"/>\r\n        /// </summary>\r\n        /// <returns" +
                    ">An <see cref=\"IDataReader\"/> that can be used to iterate over the results of th" +
                    "e SQL query.</returns>\r\n        /// <remarks>\r\n        /// This is typically use" +
                    "d when the results of a query are not processed by Dapper, for example, used to " +
                    "fill a <see cref=\"DataTable\"/>\r\n        /// or <see cref=\"T:DataSet\"/>.\r\n       " +
                    " /// </remarks>\r\n        public static IDataReader ExecuteReader(this IDbConnect" +
                    "ion cnn, CommandDefinition command, CommandBehavior commandBehavior)\r\n        {\r" +
                    "\n            IDbCommand dbcmd;\r\n            var reader = ExecuteReaderImpl(cnn, " +
                    "ref command, commandBehavior, out dbcmd);\r\n            return new WrappedReader(" +
                    "dbcmd, reader);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Return a sequen" +
                    "ce of dynamic objects with properties matching the columns\r\n        /// </summar" +
                    "y>\r\n        /// <remarks>Note: each row can be accessed via \"dynamic\", or by cas" +
                    "ting to an IDictionary&lt;string,object&gt;</remarks>\r\n        public static IEn" +
                    "umerable<dynamic> Query(this IDbConnection cnn, string sql, object param = null," +
                    " IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = " +
                    "null, CommandType? commandType = null)\r\n        {\r\n            return Query<Dapp" +
                    "erRow>(cnn, sql, param as object, transaction, buffered, commandTimeout, command" +
                    "Type);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Return a dynamic object " +
                    "with properties matching the columns\r\n        /// </summary>\r\n        /// <remar" +
                    "ks>Note: the row can be accessed via \"dynamic\", or by casting to an IDictionary&" +
                    "lt;string,object&gt;</remarks>\r\n        public static dynamic QueryFirst(this ID" +
                    "bConnection cnn, string sql, object param = null, IDbTransaction transaction = n" +
                    "ull, int? commandTimeout = null, CommandType? commandType = null)\r\n        {\r\n  " +
                    "          return QueryFirst<DapperRow>(cnn, sql, param as object, transaction, c" +
                    "ommandTimeout, commandType);\r\n        }\r\n        /// <summary>\r\n        /// Retu" +
                    "rn a dynamic object with properties matching the columns\r\n        /// </summary>" +
                    "\r\n        /// <remarks>Note: the row can be accessed via \"dynamic\", or by castin" +
                    "g to an IDictionary&lt;string,object&gt;</remarks>\r\n        public static dynami" +
                    "c QueryFirstOrDefault(this IDbConnection cnn, string sql, object param = null, I" +
                    "DbTransaction transaction = null, int? commandTimeout = null, CommandType? comma" +
                    "ndType = null)\r\n        {\r\n            return QueryFirstOrDefault<DapperRow>(cnn" +
                    ", sql, param as object, transaction, commandTimeout, commandType);\r\n        }\r\n " +
                    "       /// <summary>\r\n        /// Return a dynamic object with properties matchi" +
                    "ng the columns\r\n        /// </summary>\r\n        /// <remarks>Note: the row can b" +
                    "e accessed via \"dynamic\", or by casting to an IDictionary&lt;string,object&gt;</" +
                    "remarks>\r\n        public static dynamic QuerySingle(this IDbConnection cnn, stri" +
                    "ng sql, object param = null, IDbTransaction transaction = null, int? commandTime" +
                    "out = null, CommandType? commandType = null)\r\n        {\r\n            return Quer" +
                    "ySingle<DapperRow>(cnn, sql, param as object, transaction, commandTimeout, comma" +
                    "ndType);\r\n        }\r\n        /// <summary>\r\n        /// Return a dynamic object " +
                    "with properties matching the columns\r\n        /// </summary>\r\n        /// <remar" +
                    "ks>Note: the row can be accessed via \"dynamic\", or by casting to an IDictionary&" +
                    "lt;string,object&gt;</remarks>\r\n        public static dynamic QuerySingleOrDefau" +
                    "lt(this IDbConnection cnn, string sql, object param = null, IDbTransaction trans" +
                    "action = null, int? commandTimeout = null, CommandType? commandType = null)\r\n   " +
                    "     {\r\n            return QuerySingleOrDefault<DapperRow>(cnn, sql, param as ob" +
                    "ject, transaction, commandTimeout, commandType);\r\n        }\r\n\r\n        /// <summ" +
                    "ary>\r\n        /// Executes a query, returning the data typed as per T\r\n        /" +
                    "// </summary>\r\n        /// <returns>A sequence of data of the supplied type; if " +
                    "a basic type (int, string, etc) is queried then the data from the first column i" +
                    "n assumed, otherwise an instance is\r\n        /// created per row, and a direct c" +
                    "olumn-name===member-name mapping is assumed (case insensitive).\r\n        /// </r" +
                    "eturns>\r\n        public static IEnumerable<T> Query<T>(\r\n            this IDbCon" +
                    "nection cnn, string sql, object param = null, IDbTransaction transaction = null," +
                    " bool buffered = true, int? commandTimeout = null, CommandType? commandType = nu" +
                    "ll\r\n        )\r\n        {\r\n            var command = new CommandDefinition(sql, p" +
                    "aram, transaction, commandTimeout, commandType, buffered ? CommandFlags.Buffered" +
                    " : CommandFlags.None);\r\n            var data = QueryImpl<T>(cnn, command, typeof" +
                    "(T));\r\n            return command.Buffered ? data.ToList() : data;\r\n        }\r\n\r" +
                    "\n        /// <summary>\r\n        /// Executes a single-row query, returning the d" +
                    "ata typed as per T\r\n        /// </summary>\r\n        /// <returns>A sequence of d" +
                    "ata of the supplied type; if a basic type (int, string, etc) is queried then the" +
                    " data from the first column in assumed, otherwise an instance is\r\n        /// cr" +
                    "eated per row, and a direct column-name===member-name mapping is assumed (case i" +
                    "nsensitive).\r\n        /// </returns>\r\n        public static T QueryFirst<T>(\r\n  " +
                    "          this IDbConnection cnn, string sql, object param = null, IDbTransactio" +
                    "n transaction = null, int? commandTimeout = null, CommandType? commandType = nul" +
                    "l\r\n        )\r\n        {\r\n            var command = new CommandDefinition(sql, pa" +
                    "ram, transaction, commandTimeout, commandType, CommandFlags.None);\r\n            " +
                    "return QueryRowImpl<T>(cnn, Row.First, ref command, typeof(T));\r\n        }\r\n    " +
                    "    /// <summary>\r\n        /// Executes a single-row query, returning the data t" +
                    "yped as per T\r\n        /// </summary>\r\n        /// <returns>A sequence of data o" +
                    "f the supplied type; if a basic type (int, string, etc) is queried then the data" +
                    " from the first column in assumed, otherwise an instance is\r\n        /// created" +
                    " per row, and a direct column-name===member-name mapping is assumed (case insens" +
                    "itive).\r\n        /// </returns>\r\n        public static T QueryFirstOrDefault<T>(" +
                    "\r\n            this IDbConnection cnn, string sql, object param = null, IDbTransa" +
                    "ction transaction = null, int? commandTimeout = null, CommandType? commandType =" +
                    " null\r\n        )\r\n        {\r\n            var command = new CommandDefinition(sql" +
                    ", param, transaction, commandTimeout, commandType, CommandFlags.None);\r\n        " +
                    "    return QueryRowImpl<T>(cnn, Row.FirstOrDefault, ref command, typeof(T));\r\n  " +
                    "      }\r\n        /// <summary>\r\n        /// Executes a single-row query, returni" +
                    "ng the data typed as per T\r\n        /// </summary>\r\n        /// <returns>A seque" +
                    "nce of data of the supplied type; if a basic type (int, string, etc) is queried " +
                    "then the data from the first column in assumed, otherwise an instance is\r\n      " +
                    "  /// created per row, and a direct column-name===member-name mapping is assumed" +
                    " (case insensitive).\r\n        /// </returns>\r\n        public static T QuerySingl" +
                    "e<T>(\r\n            this IDbConnection cnn, string sql, object param = null, IDbT" +
                    "ransaction transaction = null, int? commandTimeout = null, CommandType? commandT" +
                    "ype = null\r\n        )\r\n        {\r\n            var command = new CommandDefinitio" +
                    "n(sql, param, transaction, commandTimeout, commandType, CommandFlags.None);\r\n   " +
                    "         return QueryRowImpl<T>(cnn, Row.Single, ref command, typeof(T));\r\n     " +
                    "   }\r\n        /// <summary>\r\n        /// Executes a single-row query, returning " +
                    "the data typed as per T\r\n        /// </summary>\r\n        /// <returns>A sequence" +
                    " of data of the supplied type; if a basic type (int, string, etc) is queried the" +
                    "n the data from the first column in assumed, otherwise an instance is\r\n        /" +
                    "// created per row, and a direct column-name===member-name mapping is assumed (c" +
                    "ase insensitive).\r\n        /// </returns>\r\n        public static T QuerySingleOr" +
                    "Default<T>(\r\n            this IDbConnection cnn, string sql, object param = null" +
                    ", IDbTransaction transaction = null, int? commandTimeout = null, CommandType? co" +
                    "mmandType = null\r\n        )\r\n        {\r\n            var command = new CommandDef" +
                    "inition(sql, param, transaction, commandTimeout, commandType, CommandFlags.None)" +
                    ";\r\n            return QueryRowImpl<T>(cnn, Row.SingleOrDefault, ref command, typ" +
                    "eof(T));\r\n        }\r\n\r\n        /// <summary>\r\n        /// Executes a single-row " +
                    "query, returning the data typed as per the Type suggested\r\n        /// </summary" +
                    ">\r\n        /// <returns>A sequence of data of the supplied type; if a basic type" +
                    " (int, string, etc) is queried then the data from the first column in assumed, o" +
                    "therwise an instance is\r\n        /// created per row, and a direct column-name==" +
                    "=member-name mapping is assumed (case insensitive).\r\n        /// </returns>\r\n   " +
                    "     public static IEnumerable<object> Query(\r\n            this IDbConnection cn" +
                    "n, Type type, string sql, object param = null, IDbTransaction transaction = null" +
                    ", bool buffered = true, int? commandTimeout = null, CommandType? commandType = n" +
                    "ull\r\n        )\r\n        {\r\n            if (type == null) throw new ArgumentNullE" +
                    "xception(nameof(type));\r\n            var command = new CommandDefinition(sql, pa" +
                    "ram, transaction, commandTimeout, commandType, buffered ? CommandFlags.Buffered " +
                    ": CommandFlags.None);\r\n            var data = QueryImpl<object>(cnn, command, ty" +
                    "pe);\r\n            return command.Buffered ? data.ToList() : data;\r\n        }\r\n  " +
                    "      /// <summary>\r\n        /// Executes a single-row query, returning the data" +
                    " typed as per the Type suggested\r\n        /// </summary>\r\n        /// <returns>A" +
                    " sequence of data of the supplied type; if a basic type (int, string, etc) is qu" +
                    "eried then the data from the first column in assumed, otherwise an instance is\r\n" +
                    "        /// created per row, and a direct column-name===member-name mapping is a" +
                    "ssumed (case insensitive).\r\n        /// </returns>\r\n        public static object" +
                    " QueryFirst(\r\n            this IDbConnection cnn, Type type, string sql, object " +
                    "param = null, IDbTransaction transaction = null, int? commandTimeout = null, Com" +
                    "mandType? commandType = null\r\n        )\r\n        {\r\n            if (type == null" +
                    ") throw new ArgumentNullException(nameof(type));\r\n            var command = new " +
                    "CommandDefinition(sql, param, transaction, commandTimeout, commandType, CommandF" +
                    "lags.None);\r\n            return QueryRowImpl<object>(cnn, Row.First, ref command" +
                    ", type);\r\n        }\r\n        /// <summary>\r\n        /// Executes a single-row qu" +
                    "ery, returning the data typed as per the Type suggested\r\n        /// </summary>\r" +
                    "\n        /// <returns>A sequence of data of the supplied type; if a basic type (" +
                    "int, string, etc) is queried then the data from the first column in assumed, oth" +
                    "erwise an instance is\r\n        /// created per row, and a direct column-name===m" +
                    "ember-name mapping is assumed (case insensitive).\r\n        /// </returns>\r\n     " +
                    "   public static object QueryFirstOrDefault(\r\n            this IDbConnection cnn" +
                    ", Type type, string sql, object param = null, IDbTransaction transaction = null," +
                    " int? commandTimeout = null, CommandType? commandType = null\r\n        )\r\n       " +
                    " {\r\n            if (type == null) throw new ArgumentNullException(nameof(type));" +
                    "\r\n            var command = new CommandDefinition(sql, param, transaction, comma" +
                    "ndTimeout, commandType, CommandFlags.None);\r\n            return QueryRowImpl<obj" +
                    "ect>(cnn, Row.FirstOrDefault, ref command, type);\r\n        }\r\n        /// <summa" +
                    "ry>\r\n        /// Executes a single-row query, returning the data typed as per th" +
                    "e Type suggested\r\n        /// </summary>\r\n        /// <returns>A sequence of dat" +
                    "a of the supplied type; if a basic type (int, string, etc) is queried then the d" +
                    "ata from the first column in assumed, otherwise an instance is\r\n        /// crea" +
                    "ted per row, and a direct column-name===member-name mapping is assumed (case ins" +
                    "ensitive).\r\n        /// </returns>\r\n        public static object QuerySingle(\r\n " +
                    "           this IDbConnection cnn, Type type, string sql, object param = null, I" +
                    "DbTransaction transaction = null, int? commandTimeout = null, CommandType? comma" +
                    "ndType = null\r\n        )\r\n        {\r\n            if (type == null) throw new Arg" +
                    "umentNullException(nameof(type));\r\n            var command = new CommandDefiniti" +
                    "on(sql, param, transaction, commandTimeout, commandType, CommandFlags.None);\r\n  " +
                    "          return QueryRowImpl<object>(cnn, Row.Single, ref command, type);\r\n    " +
                    "    }\r\n        /// <summary>\r\n        /// Executes a single-row query, returning" +
                    " the data typed as per the Type suggested\r\n        /// </summary>\r\n        /// <" +
                    "returns>A sequence of data of the supplied type; if a basic type (int, string, e" +
                    "tc) is queried then the data from the first column in assumed, otherwise an inst" +
                    "ance is\r\n        /// created per row, and a direct column-name===member-name map" +
                    "ping is assumed (case insensitive).\r\n        /// </returns>\r\n        public stat" +
                    "ic object QuerySingleOrDefault(\r\n            this IDbConnection cnn, Type type, " +
                    "string sql, object param = null, IDbTransaction transaction = null, int? command" +
                    "Timeout = null, CommandType? commandType = null\r\n        )\r\n        {\r\n         " +
                    "   if (type == null) throw new ArgumentNullException(nameof(type));\r\n           " +
                    " var command = new CommandDefinition(sql, param, transaction, commandTimeout, co" +
                    "mmandType, CommandFlags.None);\r\n            return QueryRowImpl<object>(cnn, Row" +
                    ".SingleOrDefault, ref command, type);\r\n        }\r\n        /// <summary>\r\n       " +
                    " /// Executes a query, returning the data typed as per T\r\n        /// </summary>" +
                    "\r\n        /// <remarks>the dynamic param may seem a bit odd, but this works arou" +
                    "nd a major usability issue in vs, if it is Object vs completion gets annoying. E" +
                    "g type new [space] get new object</remarks>\r\n        /// <returns>A sequence of " +
                    "data of the supplied type; if a basic type (int, string, etc) is queried then th" +
                    "e data from the first column in assumed, otherwise an instance is\r\n        /// c" +
                    "reated per row, and a direct column-name===member-name mapping is assumed (case " +
                    "insensitive).\r\n        /// </returns>\r\n        public static IEnumerable<T> Quer" +
                    "y<T>(this IDbConnection cnn, CommandDefinition command)\r\n        {\r\n            " +
                    "var data = QueryImpl<T>(cnn, command, typeof(T));\r\n            return command.Bu" +
                    "ffered ? data.ToList() : data;\r\n        }\r\n\r\n        /// <summary>\r\n        /// " +
                    "Executes a query, returning the data typed as per T\r\n        /// </summary>\r\n   " +
                    "     /// <remarks>the dynamic param may seem a bit odd, but this works around a " +
                    "major usability issue in vs, if it is Object vs completion gets annoying. Eg typ" +
                    "e new [space] get new object</remarks>\r\n        /// <returns>A single instance o" +
                    "r null of the supplied type; if a basic type (int, string, etc) is queried then " +
                    "the data from the first column in assumed, otherwise an instance is\r\n        ///" +
                    " created per row, and a direct column-name===member-name mapping is assumed (cas" +
                    "e insensitive).\r\n        /// </returns>\r\n        public static T QueryFirst<T>(t" +
                    "his IDbConnection cnn, CommandDefinition command)\r\n        {\r\n            return" +
                    " QueryRowImpl<T>(cnn, Row.First, ref command, typeof(T));\r\n        }\r\n        //" +
                    "/ <summary>\r\n        /// Executes a query, returning the data typed as per T\r\n  " +
                    "      /// </summary>\r\n        /// <remarks>the dynamic param may seem a bit odd," +
                    " but this works around a major usability issue in vs, if it is Object vs complet" +
                    "ion gets annoying. Eg type new [space] get new object</remarks>\r\n        /// <re" +
                    "turns>A single or null instance of the supplied type; if a basic type (int, stri" +
                    "ng, etc) is queried then the data from the first column in assumed, otherwise an" +
                    " instance is\r\n        /// created per row, and a direct column-name===member-nam" +
                    "e mapping is assumed (case insensitive).\r\n        /// </returns>\r\n        public" +
                    " static T QueryFirstOrDefault<T>(this IDbConnection cnn, CommandDefinition comma" +
                    "nd)\r\n        {\r\n            return QueryRowImpl<T>(cnn, Row.FirstOrDefault, ref " +
                    "command, typeof(T));\r\n        }\r\n        /// <summary>\r\n        /// Executes a q" +
                    "uery, returning the data typed as per T\r\n        /// </summary>\r\n        /// <re" +
                    "marks>the dynamic param may seem a bit odd, but this works around a major usabil" +
                    "ity issue in vs, if it is Object vs completion gets annoying. Eg type new [space" +
                    "] get new object</remarks>\r\n        /// <returns>A single instance of the suppli" +
                    "ed type; if a basic type (int, string, etc) is queried then the data from the fi" +
                    "rst column in assumed, otherwise an instance is\r\n        /// created per row, an" +
                    "d a direct column-name===member-name mapping is assumed (case insensitive).\r\n   " +
                    "     /// </returns>\r\n        public static T QuerySingle<T>(this IDbConnection c" +
                    "nn, CommandDefinition command)\r\n        {\r\n            return QueryRowImpl<T>(cn" +
                    "n, Row.Single, ref command, typeof(T));\r\n        }\r\n        /// <summary>\r\n     " +
                    "   /// Executes a query, returning the data typed as per T\r\n        /// </summar" +
                    "y>\r\n        /// <remarks>the dynamic param may seem a bit odd, but this works ar" +
                    "ound a major usability issue in vs, if it is Object vs completion gets annoying." +
                    " Eg type new [space] get new object</remarks>\r\n        /// <returns>A single ins" +
                    "tance of the supplied type; if a basic type (int, string, etc) is queried then t" +
                    "he data from the first column in assumed, otherwise an instance is\r\n        /// " +
                    "created per row, and a direct column-name===member-name mapping is assumed (case" +
                    " insensitive).\r\n        /// </returns>\r\n        public static T QuerySingleOrDef" +
                    "ault<T>(this IDbConnection cnn, CommandDefinition command)\r\n        {\r\n         " +
                    "   return QueryRowImpl<T>(cnn, Row.SingleOrDefault, ref command, typeof(T));\r\n  " +
                    "      }\r\n\r\n\r\n        /// <summary>\r\n        /// Execute a command that returns m" +
                    "ultiple result sets, and access each in turn\r\n        /// </summary>\r\n        pu" +
                    "blic static GridReader QueryMultiple(\r\n            this IDbConnection cnn, strin" +
                    "g sql, object param = null, IDbTransaction transaction = null, int? commandTimeo" +
                    "ut = null, CommandType? commandType = null\r\n        )\r\n        {\r\n            va" +
                    "r command = new CommandDefinition(sql, param, transaction, commandTimeout, comma" +
                    "ndType, CommandFlags.Buffered);\r\n            return QueryMultipleImpl(cnn, ref c" +
                    "ommand);\r\n        }\r\n        /// <summary>\r\n        /// Execute a command that r" +
                    "eturns multiple result sets, and access each in turn\r\n        /// </summary>\r\n  " +
                    "      public static GridReader QueryMultiple(this IDbConnection cnn, CommandDefi" +
                    "nition command)\r\n        {\r\n            return QueryMultipleImpl(cnn, ref comman" +
                    "d);\r\n        }\r\n\r\n        private static GridReader QueryMultipleImpl(this IDbCo" +
                    "nnection cnn, ref CommandDefinition command)\r\n        {\r\n            object para" +
                    "m = command.Parameters;\r\n            Identity identity = new Identity(command.Co" +
                    "mmandText, command.CommandType, cnn, typeof(GridReader), param?.GetType(), null)" +
                    ";\r\n            CacheInfo info = GetCacheInfo(identity, param, command.AddToCache" +
                    ");\r\n\r\n            IDbCommand cmd = null;\r\n            IDataReader reader = null;" +
                    "\r\n            bool wasClosed = cnn.State == ConnectionState.Closed;\r\n           " +
                    " try\r\n            {\r\n                if (wasClosed) cnn.Open();\r\n               " +
                    " cmd = command.SetupCommand(cnn, info.ParamReader);\r\n                reader = Ex" +
                    "ecuteReaderWithFlagsFallback(cmd, wasClosed, CommandBehavior.SequentialAccess);\r" +
                    "\n\r\n                var result = new GridReader(cmd, reader, identity, command.Pa" +
                    "rameters as DynamicParameters, command.AddToCache);\r\n                cmd = null;" +
                    " // now owned by result\r\n                wasClosed = false; // *if* the connecti" +
                    "on was closed and we got this far, then we now have a reader\r\n                //" +
                    " with the CloseConnection flag, so the reader will deal with the connection; we\r" +
                    "\n                // still need something in the \"finally\" to ensure that broken " +
                    "SQL still results\r\n                // in the connection closing itself\r\n        " +
                    "        return result;\r\n            }\r\n            catch\r\n            {\r\n       " +
                    "         if (reader != null)\r\n                {\r\n                    if (!reader" +
                    ".IsClosed) try { cmd?.Cancel(); }\r\n                        catch { /* don\'t spoi" +
                    "l the existing exception */ }\r\n                    reader.Dispose();\r\n          " +
                    "      }\r\n                cmd?.Dispose();\r\n                if (wasClosed) cnn.Clo" +
                    "se();\r\n                throw;\r\n            }\r\n        }\r\n        private static " +
                    "IDataReader ExecuteReaderWithFlagsFallback(IDbCommand cmd, bool wasClosed, Comma" +
                    "ndBehavior behavior)\r\n        {\r\n            try\r\n            {\r\n               " +
                    " return cmd.ExecuteReader(GetBehavior(wasClosed, behavior));\r\n            }\r\n   " +
                    "         catch (ArgumentException ex)\r\n            { // thanks, Sqlite!\r\n       " +
                    "         if (DisableCommandBehaviorOptimizations(behavior, ex))\r\n               " +
                    " {\r\n                    // we can retry; this time it will have different flags\r" +
                    "\n                    return cmd.ExecuteReader(GetBehavior(wasClosed, behavior));" +
                    "\r\n                }\r\n                throw;\r\n            }\r\n        }\r\n        p" +
                    "rivate static IEnumerable<T> QueryImpl<T>(this IDbConnection cnn, CommandDefinit" +
                    "ion command, Type effectiveType)\r\n        {\r\n            object param = command." +
                    "Parameters;\r\n            var identity = new Identity(command.CommandText, comman" +
                    "d.CommandType, cnn, effectiveType, param?.GetType(), null);\r\n            var inf" +
                    "o = GetCacheInfo(identity, param, command.AddToCache);\r\n\r\n            IDbCommand" +
                    " cmd = null;\r\n            IDataReader reader = null;\r\n\r\n            bool wasClos" +
                    "ed = cnn.State == ConnectionState.Closed;\r\n            try\r\n            {\r\n     " +
                    "           cmd = command.SetupCommand(cnn, info.ParamReader);\r\n\r\n               " +
                    " if (wasClosed) cnn.Open();\r\n                reader = ExecuteReaderWithFlagsFall" +
                    "back(cmd, wasClosed, CommandBehavior.SequentialAccess | CommandBehavior.SingleRe" +
                    "sult);\r\n                wasClosed = false; // *if* the connection was closed and" +
                    " we got this far, then we now have a reader\r\n                // with the CloseCo" +
                    "nnection flag, so the reader will deal with the connection; we\r\n                " +
                    "// still need something in the \"finally\" to ensure that broken SQL still results" +
                    "\r\n                // in the connection closing itself\r\n                var tuple" +
                    " = info.Deserializer;\r\n                int hash = GetColumnHash(reader);\r\n      " +
                    "          if (tuple.Func == null || tuple.Hash != hash)\r\n                {\r\n    " +
                    "                if (reader.FieldCount == 0) //https://code.google.com/p/dapper-d" +
                    "ot-net/issues/detail?id=57\r\n                        yield break;\r\n              " +
                    "      tuple = info.Deserializer = new DeserializerState(hash, GetDeserializer(ef" +
                    "fectiveType, reader, 0, -1, false));\r\n                    if (command.AddToCache" +
                    ") SetQueryCache(identity, info);\r\n                }\r\n\r\n                var func " +
                    "= tuple.Func;\r\n                var convertToType = Nullable.GetUnderlyingType(ef" +
                    "fectiveType) ?? effectiveType;\r\n                while (reader.Read())\r\n         " +
                    "       {\r\n                    object val = func(reader);\r\n                    if" +
                    " (val == null || val is T)\r\n                    {\r\n                        yield" +
                    " return (T)val;\r\n                    }\r\n                    else\r\n              " +
                    "      {\r\n                        yield return (T)Convert.ChangeType(val, convert" +
                    "ToType, CultureInfo.InvariantCulture);\r\n                    }\r\n                }" +
                    "\r\n                while (reader.NextResult()) { }\r\n                // happy path" +
                    "; close the reader cleanly - no\r\n                // need for \"Cancel\" etc\r\n     " +
                    "           reader.Dispose();\r\n                reader = null;\r\n\r\n                " +
                    "command.OnCompleted();\r\n            }\r\n            finally\r\n            {\r\n     " +
                    "           if (reader != null)\r\n                {\r\n                    if (!read" +
                    "er.IsClosed) try { cmd.Cancel(); }\r\n                        catch { /* don\'t spo" +
                    "il the existing exception */ }\r\n                    reader.Dispose();\r\n         " +
                    "       }\r\n                if (wasClosed) cnn.Close();\r\n                cmd?.Disp" +
                    "ose();\r\n            }\r\n        }\r\n\r\n        [Flags]\r\n        internal enum Row\r\n" +
                    "        {\r\n            First = 0,\r\n            FirstOrDefault = 1, //  &FirstOrD" +
                    "efault != 0: allow zero rows\r\n            Single = 2, // & Single != 0: demand a" +
                    "t least one row\r\n            SingleOrDefault = 3\r\n        }\r\n        static read" +
                    "only int[] ErrTwoRows = new int[2], ErrZeroRows = new int[0];\r\n        static vo" +
                    "id ThrowMultipleRows(Row row)\r\n        {\r\n            switch (row)\r\n            " +
                    "{  // get the standard exception from the runtime\r\n                case Row.Sing" +
                    "le: ErrTwoRows.Single(); break;\r\n                case Row.SingleOrDefault: ErrTw" +
                    "oRows.SingleOrDefault(); break;\r\n                default: throw new InvalidOpera" +
                    "tionException();\r\n            }\r\n        }\r\n        static void ThrowZeroRows(Ro" +
                    "w row)\r\n        {\r\n            switch (row)\r\n            { // get the standard e" +
                    "xception from the runtime\r\n                case Row.First: ErrZeroRows.First(); " +
                    "break;\r\n                case Row.Single: ErrZeroRows.Single(); break;\r\n         " +
                    "       default: throw new InvalidOperationException();\r\n            }\r\n        }" +
                    "\r\n        private static T QueryRowImpl<T>(IDbConnection cnn, Row row, ref Comma" +
                    "ndDefinition command, Type effectiveType)\r\n        {\r\n            object param =" +
                    " command.Parameters;\r\n            var identity = new Identity(command.CommandTex" +
                    "t, command.CommandType, cnn, effectiveType, param?.GetType(), null);\r\n          " +
                    "  var info = GetCacheInfo(identity, param, command.AddToCache);\r\n\r\n            I" +
                    "DbCommand cmd = null;\r\n            IDataReader reader = null;\r\n\r\n            boo" +
                    "l wasClosed = cnn.State == ConnectionState.Closed;\r\n            try\r\n           " +
                    " {\r\n                cmd = command.SetupCommand(cnn, info.ParamReader);\r\n\r\n      " +
                    "          if (wasClosed) cnn.Open();\r\n                reader = ExecuteReaderWith" +
                    "FlagsFallback(cmd, wasClosed, (row & Row.Single) != 0\r\n                    ? Com" +
                    "mandBehavior.SequentialAccess | CommandBehavior.SingleResult // need to allow mu" +
                    "ltiple rows, to check fail condition\r\n                    : CommandBehavior.Sequ" +
                    "entialAccess | CommandBehavior.SingleResult | CommandBehavior.SingleRow);\r\n     " +
                    "           wasClosed = false; // *if* the connection was closed and we got this " +
                    "far, then we now have a reader\r\n\r\n                T result = default(T);\r\n      " +
                    "          if (reader.Read() && reader.FieldCount != 0)\r\n                {\r\n     " +
                    "               // with the CloseConnection flag, so the reader will deal with th" +
                    "e connection; we\r\n                    // still need something in the \"finally\" t" +
                    "o ensure that broken SQL still results\r\n                    // in the connection" +
                    " closing itself\r\n                    var tuple = info.Deserializer;\r\n           " +
                    "         int hash = GetColumnHash(reader);\r\n                    if (tuple.Func =" +
                    "= null || tuple.Hash != hash)\r\n                    {\r\n                        tu" +
                    "ple = info.Deserializer = new DeserializerState(hash, GetDeserializer(effectiveT" +
                    "ype, reader, 0, -1, false));\r\n                        if (command.AddToCache) Se" +
                    "tQueryCache(identity, info);\r\n                    }\r\n\r\n                    var f" +
                    "unc = tuple.Func;\r\n                    object val = func(reader);\r\n             " +
                    "       if (val == null || val is T)\r\n                    {\r\n                    " +
                    "    result = (T)val;\r\n                    }\r\n                    else\r\n         " +
                    "           {\r\n                        var convertToType = Nullable.GetUnderlying" +
                    "Type(effectiveType) ?? effectiveType;\r\n                        result = (T)Conve" +
                    "rt.ChangeType(val, convertToType, CultureInfo.InvariantCulture);\r\n              " +
                    "      }\r\n                    if ((row & Row.Single) != 0 && reader.Read()) Throw" +
                    "MultipleRows(row);\r\n                    while (reader.Read()) { }\r\n             " +
                    "   }\r\n                else if ((row & Row.FirstOrDefault) == 0) // demanding a r" +
                    "ow, and don\'t have one\r\n                {\r\n                    ThrowZeroRows(row" +
                    ");\r\n                }\r\n                while (reader.NextResult()) { }\r\n        " +
                    "        // happy path; close the reader cleanly - no\r\n                // need fo" +
                    "r \"Cancel\" etc\r\n                reader.Dispose();\r\n                reader = null" +
                    ";\r\n\r\n                command.OnCompleted();\r\n                return result;\r\n   " +
                    "         }\r\n            finally\r\n            {\r\n                if (reader != nu" +
                    "ll)\r\n                {\r\n                    if (!reader.IsClosed) try { cmd.Canc" +
                    "el(); }\r\n                        catch { /* don\'t spoil the existing exception *" +
                    "/ }\r\n                    reader.Dispose();\r\n                }\r\n                i" +
                    "f (wasClosed) cnn.Close();\r\n                cmd?.Dispose();\r\n            }\r\n    " +
                    "    }\r\n\r\n        /// <summary>\r\n        /// Maps a query to objects\r\n        ///" +
                    " </summary>\r\n        /// <typeparam name=\"TFirst\">The first type in the record s" +
                    "et</typeparam>\r\n        /// <typeparam name=\"TSecond\">The second type in the rec" +
                    "ord set</typeparam>\r\n        /// <typeparam name=\"TReturn\">The return type</type" +
                    "param>\r\n        /// <param name=\"cnn\"></param>\r\n        /// <param name=\"sql\"></" +
                    "param>\r\n        /// <param name=\"map\"></param>\r\n        /// <param name=\"param\">" +
                    "</param>\r\n        /// <param name=\"transaction\"></param>\r\n        /// <param nam" +
                    "e=\"buffered\"></param>\r\n        /// <param name=\"splitOn\">The Field we should spl" +
                    "it and read the second object from (default: id)</param>\r\n        /// <param nam" +
                    "e=\"commandTimeout\">Number of seconds before command execution timeout</param>\r\n " +
                    "       /// <param name=\"commandType\">Is it a stored proc or a batch?</param>\r\n  " +
                    "      /// <returns></returns>\r\n        public static IEnumerable<TReturn> Query<" +
                    "TFirst, TSecond, TReturn>(\r\n            this IDbConnection cnn, string sql, Func" +
                    "<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction " +
                    "= null, bool buffered = true, string splitOn = \"Id\", int? commandTimeout = null," +
                    " CommandType? commandType = null\r\n        )\r\n        {\r\n            return Multi" +
                    "Map<TFirst, TSecond, DontMap, DontMap, DontMap, DontMap, DontMap, TReturn>(cnn, " +
                    "sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);\r\n" +
                    "        }\r\n\r\n        /// <summary>\r\n        /// Maps a query to objects\r\n       " +
                    " /// </summary>\r\n        /// <typeparam name=\"TFirst\"></typeparam>\r\n        /// " +
                    "<typeparam name=\"TSecond\"></typeparam>\r\n        /// <typeparam name=\"TThird\"></t" +
                    "ypeparam>\r\n        /// <typeparam name=\"TReturn\"></typeparam>\r\n        /// <para" +
                    "m name=\"cnn\"></param>\r\n        /// <param name=\"sql\"></param>\r\n        /// <para" +
                    "m name=\"map\"></param>\r\n        /// <param name=\"param\"></param>\r\n        /// <pa" +
                    "ram name=\"transaction\"></param>\r\n        /// <param name=\"buffered\"></param>\r\n  " +
                    "      /// <param name=\"splitOn\">The Field we should split and read the second ob" +
                    "ject from (default: id)</param>\r\n        /// <param name=\"commandTimeout\">Number" +
                    " of seconds before command execution timeout</param>\r\n        /// <param name=\"c" +
                    "ommandType\"></param>\r\n        /// <returns></returns>\r\n        public static IEn" +
                    "umerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(\r\n            this IDb" +
                    "Connection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, object p" +
                    "aram = null, IDbTransaction transaction = null, bool buffered = true, string spl" +
                    "itOn = \"Id\", int? commandTimeout = null, CommandType? commandType = null\r\n      " +
                    "  )\r\n        {\r\n            return MultiMap<TFirst, TSecond, TThird, DontMap, Do" +
                    "ntMap, DontMap, DontMap, TReturn>(cnn, sql, map, param, transaction, buffered, s" +
                    "plitOn, commandTimeout, commandType);\r\n        }\r\n\r\n        /// <summary>\r\n     " +
                    "   /// Perform a multi mapping query with 4 input parameters\r\n        /// </summ" +
                    "ary>\r\n        /// <typeparam name=\"TFirst\"></typeparam>\r\n        /// <typeparam " +
                    "name=\"TSecond\"></typeparam>\r\n        /// <typeparam name=\"TThird\"></typeparam>\r\n" +
                    "        /// <typeparam name=\"TFourth\"></typeparam>\r\n        /// <typeparam name=" +
                    "\"TReturn\"></typeparam>\r\n        /// <param name=\"cnn\"></param>\r\n        /// <par" +
                    "am name=\"sql\"></param>\r\n        /// <param name=\"map\"></param>\r\n        /// <par" +
                    "am name=\"param\"></param>\r\n        /// <param name=\"transaction\"></param>\r\n      " +
                    "  /// <param name=\"buffered\"></param>\r\n        /// <param name=\"splitOn\"></param" +
                    ">\r\n        /// <param name=\"commandTimeout\"></param>\r\n        /// <param name=\"c" +
                    "ommandType\"></param>\r\n        /// <returns></returns>\r\n        public static IEn" +
                    "umerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(\r\n           " +
                    " this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TRet" +
                    "urn> map, object param = null, IDbTransaction transaction = null, bool buffered " +
                    "= true, string splitOn = \"Id\", int? commandTimeout = null, CommandType? commandT" +
                    "ype = null\r\n        )\r\n        {\r\n            return MultiMap<TFirst, TSecond, T" +
                    "Third, TFourth, DontMap, DontMap, DontMap, TReturn>(cnn, sql, map, param, transa" +
                    "ction, buffered, splitOn, commandTimeout, commandType);\r\n        }\r\n\r\n        //" +
                    "/ <summary>\r\n        /// Perform a multi mapping query with 5 input parameters\r\n" +
                    "        /// </summary>\r\n        /// <typeparam name=\"TFirst\"></typeparam>\r\n     " +
                    "   /// <typeparam name=\"TSecond\"></typeparam>\r\n        /// <typeparam name=\"TThi" +
                    "rd\"></typeparam>\r\n        /// <typeparam name=\"TFourth\"></typeparam>\r\n        //" +
                    "/ <typeparam name=\"TFifth\"></typeparam>\r\n        /// <typeparam name=\"TReturn\"><" +
                    "/typeparam>\r\n        /// <param name=\"cnn\"></param>\r\n        /// <param name=\"sq" +
                    "l\"></param>\r\n        /// <param name=\"map\"></param>\r\n        /// <param name=\"pa" +
                    "ram\"></param>\r\n        /// <param name=\"transaction\"></param>\r\n        /// <para" +
                    "m name=\"buffered\"></param>\r\n        /// <param name=\"splitOn\"></param>\r\n        " +
                    "/// <param name=\"commandTimeout\"></param>\r\n        /// <param name=\"commandType\"" +
                    "></param>\r\n        /// <returns></returns>\r\n        public static IEnumerable<TR" +
                    "eturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(\r\n            th" +
                    "is IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth," +
                    " TReturn> map, object param = null, IDbTransaction transaction = null, bool buff" +
                    "ered = true, string splitOn = \"Id\", int? commandTimeout = null, CommandType? com" +
                    "mandType = null\r\n)\r\n        {\r\n            return MultiMap<TFirst, TSecond, TThi" +
                    "rd, TFourth, TFifth, DontMap, DontMap, TReturn>(cnn, sql, map, param, transactio" +
                    "n, buffered, splitOn, commandTimeout, commandType);\r\n        }\r\n\r\n        /// <s" +
                    "ummary>\r\n        /// Perform a multi mapping query with 6 input parameters\r\n    " +
                    "    /// </summary>\r\n        /// <typeparam name=\"TFirst\"></typeparam>\r\n        /" +
                    "// <typeparam name=\"TSecond\"></typeparam>\r\n        /// <typeparam name=\"TThird\">" +
                    "</typeparam>\r\n        /// <typeparam name=\"TFourth\"></typeparam>\r\n        /// <t" +
                    "ypeparam name=\"TFifth\"></typeparam>\r\n        /// <typeparam name=\"TSixth\"></type" +
                    "param>\r\n        /// <typeparam name=\"TReturn\"></typeparam>\r\n        /// <param n" +
                    "ame=\"cnn\"></param>\r\n        /// <param name=\"sql\"></param>\r\n        /// <param n" +
                    "ame=\"map\"></param>\r\n        /// <param name=\"param\"></param>\r\n        /// <param" +
                    " name=\"transaction\"></param>\r\n        /// <param name=\"buffered\"></param>\r\n     " +
                    "   /// <param name=\"splitOn\"></param>\r\n        /// <param name=\"commandTimeout\">" +
                    "</param>\r\n        /// <param name=\"commandType\"></param>\r\n        /// <returns><" +
                    "/returns>\r\n        public static IEnumerable<TReturn> Query<TFirst, TSecond, TTh" +
                    "ird, TFourth, TFifth, TSixth, TReturn>(\r\n            this IDbConnection cnn, str" +
                    "ing sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, ob" +
                    "ject param = null, IDbTransaction transaction = null, bool buffered = true, stri" +
                    "ng splitOn = \"Id\", int? commandTimeout = null, CommandType? commandType = null\r\n" +
                    ")\r\n        {\r\n            return MultiMap<TFirst, TSecond, TThird, TFourth, TFif" +
                    "th, TSixth, DontMap, TReturn>(cnn, sql, map, param, transaction, buffered, split" +
                    "On, commandTimeout, commandType);\r\n        }\r\n\r\n\r\n        /// <summary>\r\n       " +
                    " /// Perform a multi mapping query with 7 input parameters\r\n        /// </summar" +
                    "y>\r\n        /// <typeparam name=\"TFirst\"></typeparam>\r\n        /// <typeparam na" +
                    "me=\"TSecond\"></typeparam>\r\n        /// <typeparam name=\"TThird\"></typeparam>\r\n  " +
                    "      /// <typeparam name=\"TFourth\"></typeparam>\r\n        /// <typeparam name=\"T" +
                    "Fifth\"></typeparam>\r\n        /// <typeparam name=\"TSixth\"></typeparam>\r\n        " +
                    "/// <typeparam name=\"TSeventh\"></typeparam>\r\n        /// <typeparam name=\"TRetur" +
                    "n\"></typeparam>\r\n        /// <param name=\"cnn\"></param>\r\n        /// <param name" +
                    "=\"sql\"></param>\r\n        /// <param name=\"map\"></param>\r\n        /// <param name" +
                    "=\"param\"></param>\r\n        /// <param name=\"transaction\"></param>\r\n        /// <" +
                    "param name=\"buffered\"></param>\r\n        /// <param name=\"splitOn\"></param>\r\n    " +
                    "    /// <param name=\"commandTimeout\"></param>\r\n        /// <param name=\"commandT" +
                    "ype\"></param>\r\n        /// <returns></returns>\r\n        public static IEnumerabl" +
                    "e<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TRe" +
                    "turn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth," +
                    " TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction tra" +
                    "nsaction = null, bool buffered = true, string splitOn = \"Id\", int? commandTimeou" +
                    "t = null, CommandType? commandType = null)\r\n        {\r\n            return MultiM" +
                    "ap<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(cnn, sql" +
                    ", map, param, transaction, buffered, splitOn, commandTimeout, commandType);\r\n   " +
                    "     }\r\n\r\n        /// <summary>\r\n        /// Perform a multi mapping query with " +
                    "arbitrary input parameters\r\n        /// </summary>\r\n        /// <typeparam name=" +
                    "\"TReturn\">The return type</typeparam>\r\n        /// <param name=\"cnn\"></param>\r\n " +
                    "       /// <param name=\"sql\"></param>\r\n        /// <param name=\"types\">array of " +
                    "types in the record set</param>\r\n        /// <param name=\"map\"></param>\r\n       " +
                    " /// <param name=\"param\"></param>\r\n        /// <param name=\"transaction\"></param" +
                    ">\r\n        /// <param name=\"buffered\"></param>\r\n        /// <param name=\"splitOn" +
                    "\">The Field we should split and read the second object from (default: id)</param" +
                    ">\r\n        /// <param name=\"commandTimeout\">Number of seconds before command exe" +
                    "cution timeout</param>\r\n        /// <param name=\"commandType\">Is it a stored pro" +
                    "c or a batch?</param>\r\n        /// <returns></returns>\r\n        public static IE" +
                    "numerable<TReturn> Query<TReturn>(this IDbConnection cnn, string sql, Type[] typ" +
                    "es, Func<object[], TReturn> map, object param = null, IDbTransaction transaction" +
                    " = null, bool buffered = true, string splitOn = \"Id\", int? commandTimeout = null" +
                    ", CommandType? commandType = null)\r\n        {\r\n            var command = new Com" +
                    "mandDefinition(sql, param, transaction, commandTimeout, commandType, buffered ? " +
                    "CommandFlags.Buffered : CommandFlags.None);\r\n            var results = MultiMapI" +
                    "mpl<TReturn>(cnn, command, types, map, splitOn, null, null, true);\r\n            " +
                    "return buffered ? results.ToList() : results;\r\n        }\r\n\r\n        static IEnum" +
                    "erable<TReturn> MultiMap<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeve" +
                    "nth, TReturn>(\r\n            this IDbConnection cnn, string sql, Delegate map, ob" +
                    "ject param, IDbTransaction transaction, bool buffered, string splitOn, int? comm" +
                    "andTimeout, CommandType? commandType)\r\n        {\r\n            var command = new " +
                    "CommandDefinition(sql, param, transaction, commandTimeout, commandType, buffered" +
                    " ? CommandFlags.Buffered : CommandFlags.None);\r\n            var results = MultiM" +
                    "apImpl<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(cnn," +
                    " command, map, splitOn, null, null, true);\r\n            return buffered ? result" +
                    "s.ToList() : results;\r\n        }\r\n\r\n        static IEnumerable<TReturn> MultiMap" +
                    "Impl<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this I" +
                    "DbConnection cnn, CommandDefinition command, Delegate map, string splitOn, IData" +
                    "Reader reader, Identity identity, bool finalize)\r\n        {\r\n            object " +
                    "param = command.Parameters;\r\n            identity = identity ?? new Identity(com" +
                    "mand.CommandText, command.CommandType, cnn, typeof(TFirst), param?.GetType(), ne" +
                    "w[] { typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(T" +
                    "Fifth), typeof(TSixth), typeof(TSeventh) });\r\n            CacheInfo cinfo = GetC" +
                    "acheInfo(identity, param, command.AddToCache);\r\n\r\n            IDbCommand ownedCo" +
                    "mmand = null;\r\n            IDataReader ownedReader = null;\r\n\r\n            bool w" +
                    "asClosed = cnn != null && cnn.State == ConnectionState.Closed;\r\n            try\r" +
                    "\n            {\r\n                if (reader == null)\r\n                {\r\n        " +
                    "            ownedCommand = command.SetupCommand(cnn, cinfo.ParamReader);\r\n      " +
                    "              if (wasClosed) cnn.Open();\r\n                    ownedReader = Exec" +
                    "uteReaderWithFlagsFallback(ownedCommand, wasClosed, CommandBehavior.SequentialAc" +
                    "cess | CommandBehavior.SingleResult);\r\n                    reader = ownedReader;" +
                    "\r\n                }\r\n                DeserializerState deserializer = default(De" +
                    "serializerState);\r\n                Func<IDataReader, object>[] otherDeserializer" +
                    "s;\r\n\r\n                int hash = GetColumnHash(reader);\r\n                if ((de" +
                    "serializer = cinfo.Deserializer).Func == null || (otherDeserializers = cinfo.Oth" +
                    "erDeserializers) == null || hash != deserializer.Hash)\r\n                {\r\n     " +
                    "               var deserializers = GenerateDeserializers(new[] { typeof(TFirst)," +
                    " typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth" +
                    "), typeof(TSeventh) }, splitOn, reader);\r\n                    deserializer = cin" +
                    "fo.Deserializer = new DeserializerState(hash, deserializers[0]);\r\n              " +
                    "      otherDeserializers = cinfo.OtherDeserializers = deserializers.Skip(1).ToAr" +
                    "ray();\r\n                    if (command.AddToCache) SetQueryCache(identity, cinf" +
                    "o);\r\n                }\r\n\r\n                Func<IDataReader, TReturn> mapIt = Gen" +
                    "erateMapper<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>" +
                    "(deserializer.Func, otherDeserializers, map);\r\n\r\n                if (mapIt != nu" +
                    "ll)\r\n                {\r\n                    while (reader.Read())\r\n             " +
                    "       {\r\n                        yield return mapIt(reader);\r\n                 " +
                    "   }\r\n                    if (finalize)\r\n                    {\r\n                " +
                    "        while (reader.NextResult()) { }\r\n                        command.OnCompl" +
                    "eted();\r\n                    }\r\n                }\r\n            }\r\n            fi" +
                    "nally\r\n            {\r\n                try\r\n                {\r\n                  " +
                    "  ownedReader?.Dispose();\r\n                }\r\n                finally\r\n         " +
                    "       {\r\n                    ownedCommand?.Dispose();\r\n                    if (" +
                    "wasClosed) cnn.Close();\r\n                }\r\n            }\r\n        }\r\n        co" +
                    "nst CommandBehavior DefaultAllowedCommandBehaviors = ~((CommandBehavior)0);\r\n   " +
                    "     static CommandBehavior allowedCommandBehaviors = DefaultAllowedCommandBehav" +
                    "iors;\r\n        private static bool DisableCommandBehaviorOptimizations(CommandBe" +
                    "havior behavior, Exception ex)\r\n        {\r\n            if (allowedCommandBehavio" +
                    "rs == DefaultAllowedCommandBehaviors\r\n                && (behavior & (CommandBeh" +
                    "avior.SingleResult | CommandBehavior.SingleRow)) != 0)\r\n            {\r\n         " +
                    "       if (ex.Message.Contains(nameof(CommandBehavior.SingleResult))\r\n          " +
                    "          || ex.Message.Contains(nameof(CommandBehavior.SingleRow)))\r\n          " +
                    "      { // some providers just just allow these, so: try again without them and " +
                    "stop issuing them\r\n                    allowedCommandBehaviors = ~(CommandBehavi" +
                    "or.SingleResult | CommandBehavior.SingleRow);\r\n                    return true;\r" +
                    "\n                }\r\n            }\r\n            return false;\r\n        }\r\n       " +
                    " private static CommandBehavior GetBehavior(bool close, CommandBehavior @default" +
                    ")\r\n        {\r\n            return (close ? (@default | CommandBehavior.CloseConne" +
                    "ction) : @default) & allowedCommandBehaviors;\r\n        }\r\n        static IEnumer" +
                    "able<TReturn> MultiMapImpl<TReturn>(this IDbConnection cnn, CommandDefinition co" +
                    "mmand, Type[] types, Func<object[], TReturn> map, string splitOn, IDataReader re" +
                    "ader, Identity identity, bool finalize)\r\n        {\r\n            if (types.Length" +
                    " < 1)\r\n            {\r\n                throw new ArgumentException(\"you must prov" +
                    "ide at least one type to deserialize\");\r\n            }\r\n\r\n            object par" +
                    "am = command.Parameters;\r\n            identity = identity ?? new Identity(comman" +
                    "d.CommandText, command.CommandType, cnn, types[0], param?.GetType(), types);\r\n  " +
                    "          CacheInfo cinfo = GetCacheInfo(identity, param, command.AddToCache);\r\n" +
                    "\r\n            IDbCommand ownedCommand = null;\r\n            IDataReader ownedRead" +
                    "er = null;\r\n\r\n            bool wasClosed = cnn != null && cnn.State == Connectio" +
                    "nState.Closed;\r\n            try\r\n            {\r\n                if (reader == nu" +
                    "ll)\r\n                {\r\n                    ownedCommand = command.SetupCommand(" +
                    "cnn, cinfo.ParamReader);\r\n                    if (wasClosed) cnn.Open();\r\n      " +
                    "              ownedReader = ExecuteReaderWithFlagsFallback(ownedCommand, wasClos" +
                    "ed, CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);\r\n         " +
                    "           reader = ownedReader;\r\n                }\r\n                Deserialize" +
                    "rState deserializer;\r\n                Func<IDataReader, object>[] otherDeseriali" +
                    "zers;\r\n\r\n                int hash = GetColumnHash(reader);\r\n                if (" +
                    "(deserializer = cinfo.Deserializer).Func == null || (otherDeserializers = cinfo." +
                    "OtherDeserializers) == null || hash != deserializer.Hash)\r\n                {\r\n  " +
                    "                  var deserializers = GenerateDeserializers(types, splitOn, read" +
                    "er);\r\n                    deserializer = cinfo.Deserializer = new DeserializerSt" +
                    "ate(hash, deserializers[0]);\r\n                    otherDeserializers = cinfo.Oth" +
                    "erDeserializers = deserializers.Skip(1).ToArray();\r\n                    SetQuery" +
                    "Cache(identity, cinfo);\r\n                }\r\n\r\n                Func<IDataReader, " +
                    "TReturn> mapIt = GenerateMapper(types.Length, deserializer.Func, otherDeserializ" +
                    "ers, map);\r\n\r\n                if (mapIt != null)\r\n                {\r\n           " +
                    "         while (reader.Read())\r\n                    {\r\n                        y" +
                    "ield return mapIt(reader);\r\n                    }\r\n                    if (final" +
                    "ize)\r\n                    {\r\n                        while (reader.NextResult())" +
                    " { }\r\n                        command.OnCompleted();\r\n                    }\r\n   " +
                    "             }\r\n            }\r\n            finally\r\n            {\r\n             " +
                    "   try\r\n                {\r\n                    ownedReader?.Dispose();\r\n        " +
                    "        }\r\n                finally\r\n                {\r\n                    owned" +
                    "Command?.Dispose();\r\n                    if (wasClosed) cnn.Close();\r\n          " +
                    "      }\r\n            }\r\n        }\r\n\r\n        private static Func<IDataReader, TR" +
                    "eturn> GenerateMapper<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh" +
                    ", TReturn>(Func<IDataReader, object> deserializer, Func<IDataReader, object>[] o" +
                    "therDeserializers, object map)\r\n        {\r\n            switch (otherDeserializer" +
                    "s.Length)\r\n            {\r\n                case 1:\r\n                    return r " +
                    "=> ((Func<TFirst, TSecond, TReturn>)map)((TFirst)deserializer(r), (TSecond)other" +
                    "Deserializers[0](r));\r\n                case 2:\r\n                    return r => " +
                    "((Func<TFirst, TSecond, TThird, TReturn>)map)((TFirst)deserializer(r), (TSecond)" +
                    "otherDeserializers[0](r), (TThird)otherDeserializers[1](r));\r\n                ca" +
                    "se 3:\r\n                    return r => ((Func<TFirst, TSecond, TThird, TFourth, " +
                    "TReturn>)map)((TFirst)deserializer(r), (TSecond)otherDeserializers[0](r), (TThir" +
                    "d)otherDeserializers[1](r), (TFourth)otherDeserializers[2](r));\r\n               " +
                    " case 4:\r\n                    return r => ((Func<TFirst, TSecond, TThird, TFourt" +
                    "h, TFifth, TReturn>)map)((TFirst)deserializer(r), (TSecond)otherDeserializers[0]" +
                    "(r), (TThird)otherDeserializers[1](r), (TFourth)otherDeserializers[2](r), (TFift" +
                    "h)otherDeserializers[3](r));\r\n                case 5:\r\n                    retur" +
                    "n r => ((Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>)map)((T" +
                    "First)deserializer(r), (TSecond)otherDeserializers[0](r), (TThird)otherDeseriali" +
                    "zers[1](r), (TFourth)otherDeserializers[2](r), (TFifth)otherDeserializers[3](r)," +
                    " (TSixth)otherDeserializers[4](r));\r\n                case 6:\r\n                  " +
                    "  return r => ((Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh," +
                    " TReturn>)map)((TFirst)deserializer(r), (TSecond)otherDeserializers[0](r), (TThi" +
                    "rd)otherDeserializers[1](r), (TFourth)otherDeserializers[2](r), (TFifth)otherDes" +
                    "erializers[3](r), (TSixth)otherDeserializers[4](r), (TSeventh)otherDeserializers" +
                    "[5](r));\r\n                default:\r\n                    throw new NotSupportedEx" +
                    "ception();\r\n            }\r\n        }\r\n\r\n        private static Func<IDataReader," +
                    " TReturn> GenerateMapper<TReturn>(int length, Func<IDataReader, object> deserial" +
                    "izer, Func<IDataReader, object>[] otherDeserializers, Func<object[], TReturn> ma" +
                    "p)\r\n        {\r\n            return r =>\r\n            {\r\n                var objec" +
                    "ts = new object[length];\r\n                objects[0] = deserializer(r);\r\n\r\n     " +
                    "           for (var i = 1; i < length; ++i)\r\n                {\r\n                " +
                    "    objects[i] = otherDeserializers[i - 1](r);\r\n                }\r\n\r\n           " +
                    "     return map(objects);\r\n            };\r\n        }\r\n\r\n        private static F" +
                    "unc<IDataReader, object>[] GenerateDeserializers(Type[] types, string splitOn, I" +
                    "DataReader reader)\r\n        {\r\n            var deserializers = new List<Func<IDa" +
                    "taReader, object>>();\r\n            var splits = splitOn.Split(\',\').Select(s => s" +
                    ".Trim()).ToArray();\r\n            bool isMultiSplit = splits.Length > 1;\r\n       " +
                    "     if (types.First() == typeof(object))\r\n            {\r\n                // we " +
                    "go left to right for dynamic multi-mapping so that the madness of TestMultiMappi" +
                    "ngVariations\r\n                // is supported\r\n                bool first = true" +
                    ";\r\n                int currentPos = 0;\r\n                int splitIdx = 0;\r\n     " +
                    "           string currentSplit = splits[splitIdx];\r\n                foreach (var" +
                    " type in types)\r\n                {\r\n                    if (type == typeof(DontM" +
                    "ap))\r\n                    {\r\n                        break;\r\n                   " +
                    " }\r\n\r\n                    int splitPoint = GetNextSplitDynamic(currentPos, curre" +
                    "ntSplit, reader);\r\n                    if (isMultiSplit && splitIdx < splits.Len" +
                    "gth - 1)\r\n                    {\r\n                        currentSplit = splits[+" +
                    "+splitIdx];\r\n                    }\r\n                    deserializers.Add((GetDe" +
                    "serializer(type, reader, currentPos, splitPoint - currentPos, !first)));\r\n      " +
                    "              currentPos = splitPoint;\r\n                    first = false;\r\n    " +
                    "            }\r\n            }\r\n            else\r\n            {\r\n                /" +
                    "/ in this we go right to left through the data reader in order to cope with prop" +
                    "erties that are\r\n                // named the same as a subsequent primary key t" +
                    "hat we split on\r\n                int currentPos = reader.FieldCount;\r\n          " +
                    "      int splitIdx = splits.Length - 1;\r\n                var currentSplit = spli" +
                    "ts[splitIdx];\r\n                for (var typeIdx = types.Length - 1; typeIdx >= 0" +
                    "; --typeIdx)\r\n                {\r\n                    var type = types[typeIdx];\r" +
                    "\n                    if (type == typeof(DontMap))\r\n                    {\r\n      " +
                    "                  continue;\r\n                    }\r\n\r\n                    int sp" +
                    "litPoint = 0;\r\n                    if (typeIdx > 0)\r\n                    {\r\n    " +
                    "                    splitPoint = GetNextSplit(currentPos, currentSplit, reader);" +
                    "\r\n                        if (isMultiSplit && splitIdx > 0)\r\n                   " +
                    "     {\r\n                            currentSplit = splits[--splitIdx];\r\n        " +
                    "                }\r\n                    }\r\n\r\n                    deserializers.Ad" +
                    "d((GetDeserializer(type, reader, splitPoint, currentPos - splitPoint, typeIdx > " +
                    "0)));\r\n                    currentPos = splitPoint;\r\n                }\r\n\r\n      " +
                    "          deserializers.Reverse();\r\n\r\n            }\r\n            return deserial" +
                    "izers.ToArray();\r\n        }\r\n\r\n        private static int GetNextSplitDynamic(in" +
                    "t startIdx, string splitOn, IDataReader reader)\r\n        {\r\n            if (star" +
                    "tIdx == reader.FieldCount)\r\n            {\r\n                throw MultiMapExcepti" +
                    "on(reader);\r\n            }\r\n\r\n            if (splitOn == \"*\")\r\n            {\r\n  " +
                    "              return ++startIdx;\r\n            }\r\n\r\n            for (var i = star" +
                    "tIdx + 1; i < reader.FieldCount; ++i)\r\n            {\r\n                if (string" +
                    ".Equals(splitOn, reader.GetName(i), StringComparison.OrdinalIgnoreCase))\r\n      " +
                    "          {\r\n                    return i;\r\n                }\r\n            }\r\n\r\n" +
                    "            return reader.FieldCount;\r\n        }\r\n\r\n        private static int G" +
                    "etNextSplit(int startIdx, string splitOn, IDataReader reader)\r\n        {\r\n      " +
                    "      if (splitOn == \"*\")\r\n            {\r\n                return --startIdx;\r\n  " +
                    "          }\r\n\r\n            for (var i = startIdx - 1; i > 0; --i)\r\n            {" +
                    "\r\n                if (string.Equals(splitOn, reader.GetName(i), StringComparison" +
                    ".OrdinalIgnoreCase))\r\n                {\r\n                    return i;\r\n        " +
                    "        }\r\n            }\r\n\r\n            throw MultiMapException(reader);\r\n      " +
                    "  }\r\n\r\n        private static CacheInfo GetCacheInfo(Identity identity, object e" +
                    "xampleParameters, bool addToCache)\r\n        {\r\n            CacheInfo info;\r\n    " +
                    "        if (!TryGetQueryCache(identity, out info))\r\n            {\r\n             " +
                    "   if (GetMultiExec(exampleParameters) != null)\r\n                {\r\n            " +
                    "        throw new InvalidOperationException(\"An enumerable sequence of parameter" +
                    "s (arrays, lists, etc) is not allowed in this context\");\r\n                }\r\n   " +
                    "             info = new CacheInfo();\r\n                if (identity.parametersTyp" +
                    "e != null)\r\n                {\r\n                    Action<IDbCommand, object> re" +
                    "ader;\r\n                    if (exampleParameters is IDynamicParameters)\r\n       " +
                    "             {\r\n                        reader = (cmd, obj) => { ((IDynamicParam" +
                    "eters)obj).AddParameters(cmd, identity); };\r\n                    }\r\n            " +
                    "        else if (exampleParameters is IEnumerable<KeyValuePair<string, object>>)" +
                    "\r\n                    {\r\n                        reader = (cmd, obj) =>\r\n       " +
                    "                 {\r\n                            IDynamicParameters mapped = new " +
                    "DynamicParameters(obj);\r\n                            mapped.AddParameters(cmd, i" +
                    "dentity);\r\n                        };\r\n                    }\r\n                  " +
                    "  else\r\n                    {\r\n                        var literals = GetLiteral" +
                    "Tokens(identity.sql);\r\n                        reader = CreateParamInfoGenerator" +
                    "(identity, false, true, literals);\r\n                    }\r\n                    i" +
                    "f ((identity.commandType == null || identity.commandType == CommandType.Text) &&" +
                    " ShouldPassByPosition(identity.sql))\r\n                    {\r\n                   " +
                    "     var tail = reader;\r\n                        reader = (cmd, obj) =>\r\n       " +
                    "                 {\r\n                            tail(cmd, obj);\r\n               " +
                    "             PassByPosition(cmd);\r\n                        };\r\n                 " +
                    "   }\r\n                    info.ParamReader = reader;\r\n                }\r\n       " +
                    "         if (addToCache) SetQueryCache(identity, info);\r\n            }\r\n        " +
                    "    return info;\r\n        }\r\n\r\n        private static bool ShouldPassByPosition(" +
                    "string sql)\r\n        {\r\n            return sql != null && sql.IndexOf(\'?\') >= 0 " +
                    "&& pseudoPositional.IsMatch(sql);\r\n        }\r\n\r\n        private static void Pass" +
                    "ByPosition(IDbCommand cmd)\r\n        {\r\n            if (cmd.Parameters.Count == 0" +
                    ") return;\r\n\r\n            Dictionary<string, IDbDataParameter> parameters = new D" +
                    "ictionary<string, IDbDataParameter>(StringComparer.Ordinal);\r\n\r\n            fore" +
                    "ach (IDbDataParameter param in cmd.Parameters)\r\n            {\r\n                i" +
                    "f (!string.IsNullOrEmpty(param.ParameterName)) parameters[param.ParameterName] =" +
                    " param;\r\n            }\r\n            HashSet<string> consumed = new HashSet<strin" +
                    "g>(StringComparer.Ordinal);\r\n            bool firstMatch = true;\r\n            cm" +
                    "d.CommandText = pseudoPositional.Replace(cmd.CommandText, match =>\r\n            " +
                    "{\r\n                string key = match.Groups[1].Value;\r\n                IDbDataP" +
                    "arameter param;\r\n                if (!consumed.Add(key))\r\n                {\r\n   " +
                    "                 throw new InvalidOperationException(\"When passing parameters by" +
                    " position, each parameter can only be referenced once\");\r\n                }\r\n   " +
                    "             else if (parameters.TryGetValue(key, out param))\r\n                {" +
                    "\r\n                    if (firstMatch)\r\n                    {\r\n                  " +
                    "      firstMatch = false;\r\n                        cmd.Parameters.Clear(); // on" +
                    "ly clear if we are pretty positive that we\'ve found this pattern successfully\r\n " +
                    "                   }\r\n                    // if found, return the anonymous toke" +
                    "n \"?\"\r\n                    cmd.Parameters.Add(param);\r\n                    param" +
                    "eters.Remove(key);\r\n                    consumed.Add(key);\r\n                    " +
                    "return \"?\";\r\n                }\r\n                else\r\n                {\r\n       " +
                    "             // otherwise, leave alone for simple debugging\r\n                   " +
                    " return match.Value;\r\n                }\r\n            });\r\n        }\r\n\r\n        p" +
                    "rivate static Func<IDataReader, object> GetDeserializer(Type type, IDataReader r" +
                    "eader, int startBound, int length, bool returnNullIfFirstMissing)\r\n        {\r\n\r\n" +
                    "            // dynamic is passed in as Object ... by c# design\r\n            if (" +
                    "type == typeof(object)\r\n                || type == typeof(DapperRow))\r\n         " +
                    "   {\r\n                return GetDapperRowDeserializer(reader, startBound, length" +
                    ", returnNullIfFirstMissing);\r\n            }\r\n            Type underlyingType = n" +
                    "ull;\r\n            if (!(typeMap.ContainsKey(type) || type.IsEnum || type.FullNam" +
                    "e == LinqBinary ||\r\n                (type.IsValueType && (underlyingType = Nulla" +
                    "ble.GetUnderlyingType(type)) != null && underlyingType.IsEnum)))\r\n            {\r" +
                    "\n                ITypeHandler handler;\r\n                if (typeHandlers.TryGetV" +
                    "alue(type, out handler))\r\n                {\r\n                    return GetHandl" +
                    "erDeserializer(handler, type, startBound);\r\n                }\r\n                r" +
                    "eturn GetTypeDeserializer(type, reader, startBound, length, returnNullIfFirstMis" +
                    "sing);\r\n            }\r\n            return GetStructDeserializer(type, underlying" +
                    "Type ?? type, startBound);\r\n        }\r\n        private static Func<IDataReader, " +
                    "object> GetHandlerDeserializer(ITypeHandler handler, Type type, int startBound)\r" +
                    "\n        {\r\n            return reader => handler.Parse(type, reader.GetValue(sta" +
                    "rtBound));\r\n        }\r\n\r\n\r\n        private static Exception MultiMapException(ID" +
                    "ataRecord reader)\r\n        {\r\n            bool hasFields = false;\r\n            t" +
                    "ry\r\n            {\r\n                hasFields = reader != null && reader.FieldCou" +
                    "nt != 0;\r\n            }\r\n            catch { }\r\n            if (hasFields)\r\n    " +
                    "            return new ArgumentException(\"When using the multi-mapping APIs ensu" +
                    "re you set the splitOn param if you have keys other than Id\", \"splitOn\");\r\n     " +
                    "       else\r\n                return new InvalidOperationException(\"No columns we" +
                    "re selected\");\r\n        }\r\n\r\n        internal static Func<IDataReader, object> G" +
                    "etDapperRowDeserializer(IDataRecord reader, int startBound, int length, bool ret" +
                    "urnNullIfFirstMissing)\r\n        {\r\n            var fieldCount = reader.FieldCoun" +
                    "t;\r\n            if (length == -1)\r\n            {\r\n                length = field" +
                    "Count - startBound;\r\n            }\r\n\r\n            if (fieldCount <= startBound)\r" +
                    "\n            {\r\n                throw MultiMapException(reader);\r\n            }\r" +
                    "\n\r\n            var effectiveFieldCount = Math.Min(fieldCount - startBound, lengt" +
                    "h);\r\n\r\n            DapperTable table = null;\r\n\r\n            return\r\n            " +
                    "    r =>\r\n                {\r\n                    if (table == null)\r\n           " +
                    "         {\r\n                        string[] names = new string[effectiveFieldCo" +
                    "unt];\r\n                        for (int i = 0; i < effectiveFieldCount; i++)\r\n  " +
                    "                      {\r\n                            names[i] = r.GetName(i + st" +
                    "artBound);\r\n                        }\r\n                        table = new Dappe" +
                    "rTable(names);\r\n                    }\r\n\r\n                    var values = new ob" +
                    "ject[effectiveFieldCount];\r\n\r\n                    if (returnNullIfFirstMissing)\r" +
                    "\n                    {\r\n                        values[0] = r.GetValue(startBoun" +
                    "d);\r\n                        if (values[0] is DBNull)\r\n                        {" +
                    "\r\n                            return null;\r\n                        }\r\n         " +
                    "           }\r\n\r\n                    if (startBound == 0)\r\n                    {\r" +
                    "\n                        for (int i = 0; i < values.Length; i++)\r\n              " +
                    "          {\r\n                            object val = r.GetValue(i);\r\n          " +
                    "                  values[i] = val is DBNull ? null : val;\r\n                     " +
                    "   }\r\n                    }\r\n                    else\r\n                    {\r\n  " +
                    "                      var begin = returnNullIfFirstMissing ? 1 : 0;\r\n           " +
                    "             for (var iter = begin; iter < effectiveFieldCount; ++iter)\r\n       " +
                    "                 {\r\n                            object obj = r.GetValue(iter + s" +
                    "tartBound);\r\n                            values[iter] = obj is DBNull ? null : o" +
                    "bj;\r\n                        }\r\n                    }\r\n                    retur" +
                    "n new DapperRow(table, values);\r\n                };\r\n        }\r\n        /// <sum" +
                    "mary>\r\n        /// Internal use only\r\n        /// </summary>\r\n        /// <param" +
                    " name=\"value\"></param>\r\n        /// <returns></returns>\r\n#if !COREFX\r\n        [B" +
                    "rowsable(false)]\r\n#endif\r\n        [EditorBrowsable(EditorBrowsableState.Never)]\r" +
                    "\n        [Obsolete(ObsoleteInternalUsageOnly, false)]\r\n        public static cha" +
                    "r ReadChar(object value)\r\n        {\r\n            if (value == null || value is D" +
                    "BNull) throw new ArgumentNullException(nameof(value));\r\n            string s = v" +
                    "alue as string;\r\n            if (s == null || s.Length != 1) throw new ArgumentE" +
                    "xception(\"A single-character was expected\", nameof(value));\r\n            return " +
                    "s[0];\r\n        }\r\n\r\n        /// <summary>\r\n        /// Internal use only\r\n      " +
                    "  /// </summary>\r\n#if !COREFX\r\n        [Browsable(false)]\r\n#endif\r\n        [Edit" +
                    "orBrowsable(EditorBrowsableState.Never)]\r\n        [Obsolete(ObsoleteInternalUsag" +
                    "eOnly, false)]\r\n        public static char? ReadNullableChar(object value)\r\n    " +
                    "    {\r\n            if (value == null || value is DBNull) return null;\r\n         " +
                    "   string s = value as string;\r\n            if (s == null || s.Length != 1) thro" +
                    "w new ArgumentException(\"A single-character was expected\", nameof(value));\r\n    " +
                    "        return s[0];\r\n        }\r\n\r\n\r\n        /// <summary>\r\n        /// Internal" +
                    " use only\r\n        /// </summary>\r\n#if !COREFX\r\n        [Browsable(false)]\r\n#end" +
                    "if\r\n        [EditorBrowsable(EditorBrowsableState.Never)]\r\n        [Obsolete(Obs" +
                    "oleteInternalUsageOnly, true)]\r\n        public static IDbDataParameter FindOrAdd" +
                    "Parameter(IDataParameterCollection parameters, IDbCommand command, string name)\r" +
                    "\n        {\r\n            IDbDataParameter result;\r\n            if (parameters.Con" +
                    "tains(name))\r\n            {\r\n                result = (IDbDataParameter)paramete" +
                    "rs[name];\r\n            }\r\n            else\r\n            {\r\n                resul" +
                    "t = command.CreateParameter();\r\n                result.ParameterName = name;\r\n  " +
                    "              parameters.Add(result);\r\n            }\r\n            return result;" +
                    "\r\n        }\r\n\r\n        internal static int GetListPaddingExtraCount(int count)\r\n" +
                    "        {\r\n            switch (count)\r\n            {\r\n                case 0:\r\n " +
                    "               case 1:\r\n                case 2:\r\n                case 3:\r\n      " +
                    "          case 4:\r\n                case 5:\r\n                    return 0; // no " +
                    "padding\r\n            }\r\n            if (count < 0) return 0;\r\n\r\n            int " +
                    "padFactor;\r\n            if (count <= 150) padFactor = 10;\r\n            else if (" +
                    "count <= 750) padFactor = 50;\r\n            else if (count <= 2000) padFactor = 1" +
                    "00; // note: max param count for SQL Server\r\n            else if (count <= 2070)" +
                    " padFactor = 10; // try not to over-pad as we approach that limit\r\n            e" +
                    "lse if (count <= 2100) return 0; // just don\'t pad between 2070 and 2100, to min" +
                    "imize the crazy\r\n            else padFactor = 200; // above that, all bets are o" +
                    "ff!\r\n\r\n            // if we have 17, factor = 10; 17 % 10 = 7, we need 3 more\r\n " +
                    "           int intoBlock = count % padFactor;\r\n            return intoBlock == 0" +
                    " ? 0 : (padFactor - intoBlock);\r\n        }\r\n\r\n        private static string GetI" +
                    "nListRegex(string name, bool byPosition) => byPosition\r\n            ? (@\"(\\?)\" +" +
                    " Regex.Escape(name) + @\"\\?(?!\\w)(\\s+(?i)unknown(?-i))?\")\r\n            : (@\"([?@:" +
                    "]\" + Regex.Escape(name) + @\")(?!\\w)(\\s+(?i)unknown(?-i))?\");\r\n        /// <summa" +
                    "ry>\r\n        /// Internal use only\r\n        /// </summary>\r\n#if !COREFX\r\n       " +
                    " [Browsable(false)]\r\n#endif\r\n        [EditorBrowsable(EditorBrowsableState.Never" +
                    ")]\r\n        [Obsolete(ObsoleteInternalUsageOnly, false)]\r\n        public static " +
                    "void PackListParameters(IDbCommand command, string namePrefix, object value)\r\n  " +
                    "      {\r\n            // initially we tried TVP, however it performs quite poorly" +
                    ".\r\n            // keep in mind SQL support up to 2000 params easily in sp_execut" +
                    "esql, needing more is rare\r\n\r\n            if (FeatureSupport.Get(command.Connect" +
                    "ion).Arrays)\r\n            {\r\n                var arrayParm = command.CreateParam" +
                    "eter();\r\n                arrayParm.Value = SanitizeParameterValue(value);\r\n     " +
                    "           arrayParm.ParameterName = namePrefix;\r\n                command.Parame" +
                    "ters.Add(arrayParm);\r\n            }\r\n            else\r\n            {\r\n          " +
                    "      bool byPosition = ShouldPassByPosition(command.CommandText);\r\n            " +
                    "    var list = value as IEnumerable;\r\n                var count = 0;\r\n          " +
                    "      bool isString = value is IEnumerable<string>;\r\n                bool isDbSt" +
                    "ring = value is IEnumerable<DbString>;\r\n                DbType dbType = 0;\r\n\r\n  " +
                    "              int splitAt = SqlMapper.Settings.InListStringSplitCount;\r\n        " +
                    "        bool viaSplit = splitAt >= 0\r\n                    && TryStringSplit(ref " +
                    "list, splitAt, namePrefix, command, byPosition);\r\n\r\n                if (list != " +
                    "null && !viaSplit)\r\n                {\r\n                    object lastValue = nu" +
                    "ll;\r\n                    foreach (var item in list)\r\n                    {\r\n    " +
                    "                    if (++count == 1) // first item: fetch some type info\r\n     " +
                    "                   {\r\n                            if (item == null)\r\n           " +
                    "                 {\r\n                                throw new NotSupportedExcept" +
                    "ion(\"The first item in a list-expansion cannot be null\");\r\n                     " +
                    "       }\r\n                            if (!isDbString)\r\n                        " +
                    "    {\r\n                                ITypeHandler handler;\r\n                  " +
                    "              dbType = LookupDbType(item.GetType(), \"\", true, out handler);\r\n   " +
                    "                         }\r\n                        }\r\n                        v" +
                    "ar nextName = namePrefix + count.ToString();\r\n                        if (isDbSt" +
                    "ring && item as DbString != null)\r\n                        {\r\n                  " +
                    "          var str = item as DbString;\r\n                            str.AddParame" +
                    "ter(command, nextName);\r\n                        }\r\n                        else" +
                    "\r\n                        {\r\n                            var listParam = command" +
                    ".CreateParameter();\r\n                            listParam.ParameterName = nextN" +
                    "ame;\r\n                            if (isString)\r\n                            {\r\n" +
                    "                                listParam.Size = DbString.DefaultLength;\r\n      " +
                    "                          if (item != null && ((string)item).Length > DbString.D" +
                    "efaultLength)\r\n                                {\r\n                              " +
                    "      listParam.Size = -1;\r\n                                }\r\n                 " +
                    "           }\r\n\r\n                            var tmp = listParam.Value = Sanitize" +
                    "ParameterValue(item);\r\n                            if (tmp != null && !(tmp is D" +
                    "BNull))\r\n                                lastValue = tmp; // only interested in " +
                    "non-trivial values for padding\r\n\r\n                            if (listParam.DbTy" +
                    "pe != dbType)\r\n                            {\r\n                                li" +
                    "stParam.DbType = dbType;\r\n                            }\r\n                       " +
                    "     command.Parameters.Add(listParam);\r\n                        }\r\n            " +
                    "        }\r\n                    if (Settings.PadListExpansions && !isDbString && " +
                    "lastValue != null)\r\n                    {\r\n                        int padCount " +
                    "= GetListPaddingExtraCount(count);\r\n                        for (int i = 0; i < " +
                    "padCount; i++)\r\n                        {\r\n                            count++;\r" +
                    "\n                            var padParam = command.CreateParameter();\r\n        " +
                    "                    padParam.ParameterName = namePrefix + count.ToString();\r\n   " +
                    "                         if (isString) padParam.Size = DbString.DefaultLength;\r\n" +
                    "                            padParam.DbType = dbType;\r\n                         " +
                    "   padParam.Value = lastValue;\r\n                            command.Parameters.A" +
                    "dd(padParam);\r\n                        }\r\n                    }\r\n               " +
                    " }\r\n\r\n\r\n                if (viaSplit)\r\n                {\r\n                    //" +
                    " already done\r\n                }\r\n                else\r\n                {\r\n     " +
                    "               var regexIncludingUnknown = GetInListRegex(namePrefix, byPosition" +
                    ");\r\n                    if (count == 0)\r\n                    {\r\n                " +
                    "        command.CommandText = Regex.Replace(command.CommandText, regexIncludingU" +
                    "nknown, match =>\r\n                        {\r\n                            var var" +
                    "iableName = match.Groups[1].Value;\r\n                            if (match.Groups" +
                    "[2].Success)\r\n                            {\r\n                                // " +
                    "looks like an optimize hint; leave it alone!\r\n                                re" +
                    "turn match.Value;\r\n                            }\r\n                            el" +
                    "se\r\n                            {\r\n                                return \"(SELE" +
                    "CT \" + variableName + \" WHERE 1 = 0)\";\r\n                            }\r\n         " +
                    "               }, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOption" +
                    "s.CultureInvariant);\r\n                        var dummyParam = command.CreatePar" +
                    "ameter();\r\n                        dummyParam.ParameterName = namePrefix;\r\n     " +
                    "                   dummyParam.Value = DBNull.Value;\r\n                        com" +
                    "mand.Parameters.Add(dummyParam);\r\n                    }\r\n                    els" +
                    "e\r\n                    {\r\n                        command.CommandText = Regex.Re" +
                    "place(command.CommandText, regexIncludingUnknown, match =>\r\n                    " +
                    "    {\r\n                            var variableName = match.Groups[1].Value;\r\n  " +
                    "                          if (match.Groups[2].Success)\r\n                        " +
                    "    {\r\n                                // looks like an optimize hint; expand it" +
                    "\r\n                                var suffix = match.Groups[2].Value;\r\n\r\n       " +
                    "                         var sb = GetStringBuilder().Append(variableName).Append" +
                    "(1).Append(suffix);\r\n                                for (int i = 2; i <= count;" +
                    " i++)\r\n                                {\r\n                                    sb" +
                    ".Append(\',\').Append(variableName).Append(i).Append(suffix);\r\n                   " +
                    "             }\r\n                                return sb.__ToStringRecycle();\r\n" +
                    "                            }\r\n                            else\r\n               " +
                    "             {\r\n\r\n                                var sb = GetStringBuilder().Ap" +
                    "pend(\'(\').Append(variableName);\r\n                                if (!byPosition" +
                    ") sb.Append(1);\r\n                                for (int i = 2; i <= count; i++" +
                    ")\r\n                                {\r\n                                    sb.App" +
                    "end(\',\').Append(variableName);\r\n                                    if (!byPosit" +
                    "ion) sb.Append(i);\r\n                                }\r\n                         " +
                    "       return sb.Append(\')\').__ToStringRecycle();\r\n                            }" +
                    "\r\n                        }, RegexOptions.IgnoreCase | RegexOptions.Multiline | " +
                    "RegexOptions.CultureInvariant);\r\n                    }\r\n                }\r\n     " +
                    "       }\r\n        }\r\n\r\n        private static bool TryStringSplit(ref IEnumerabl" +
                    "e list, int splitAt, string namePrefix, IDbCommand command, bool byPosition)\r\n  " +
                    "      {\r\n            if (list == null || splitAt < 0) return false;\r\n           " +
                    " if (list is IEnumerable<int>) return TryStringSplit<int>(ref list, splitAt, nam" +
                    "ePrefix, command, \"int\", byPosition,\r\n                (sb, i) => sb.Append(i.ToS" +
                    "tring(CultureInfo.InvariantCulture)));\r\n            if (list is IEnumerable<long" +
                    ">) return TryStringSplit<long>(ref list, splitAt, namePrefix, command, \"bigint\"," +
                    " byPosition,\r\n                (sb, i) => sb.Append(i.ToString(CultureInfo.Invari" +
                    "antCulture)));\r\n            if (list is IEnumerable<short>) return TryStringSpli" +
                    "t<short>(ref list, splitAt, namePrefix, command, \"smallint\", byPosition,\r\n      " +
                    "          (sb, i) => sb.Append(i.ToString(CultureInfo.InvariantCulture)));\r\n    " +
                    "        if (list is IEnumerable<byte>) return TryStringSplit<byte>(ref list, spl" +
                    "itAt, namePrefix, command, \"tinyint\", byPosition,\r\n                (sb, i) => sb" +
                    ".Append(i.ToString(CultureInfo.InvariantCulture)));\r\n            return false;\r\n" +
                    "        }\r\n        private static bool TryStringSplit<T>(ref IEnumerable list, i" +
                    "nt splitAt, string namePrefix, IDbCommand command, string colType, bool byPositi" +
                    "on,\r\n            Action<StringBuilder, T> append)\r\n        {\r\n            IColle" +
                    "ction<T> typed = list as ICollection<T>;\r\n            if (typed == null)\r\n      " +
                    "      {\r\n                typed = ((IEnumerable<T>)list).ToList();\r\n             " +
                    "   list = typed; // because we still need to be able to iterate it, even if we f" +
                    "ail here\r\n            }\r\n            if (typed.Count < splitAt) return false;\r\n\r" +
                    "\n            string varName = null;\r\n            var regexIncludingUnknown = Get" +
                    "InListRegex(namePrefix, byPosition);\r\n            var sql = Regex.Replace(comman" +
                    "d.CommandText, regexIncludingUnknown, match =>\r\n            {\r\n                v" +
                    "ar variableName = match.Groups[1].Value;\r\n                if (match.Groups[2].Su" +
                    "ccess)\r\n                {\r\n                    // looks like an optimize hint; l" +
                    "eave it alone!\r\n                    return match.Value;\r\n                }\r\n    " +
                    "            else\r\n                {\r\n                    varName = variableName;" +
                    "\r\n                    return \"(select cast([value] as \" + colType + \") from stri" +
                    "ng_split(\" + variableName + \",\',\'))\";\r\n                }\r\n            }, RegexOp" +
                    "tions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);\r\n   " +
                    "         if (varName == null) return false; // couldn\'t resolve the var!\r\n\r\n    " +
                    "        command.CommandText = sql;\r\n            var concatenatedParam = command." +
                    "CreateParameter();\r\n            concatenatedParam.ParameterName = namePrefix;\r\n " +
                    "           concatenatedParam.DbType = DbType.AnsiString;\r\n            concatenat" +
                    "edParam.Size = -1;\r\n            string val;\r\n            using (var iter = typed" +
                    ".GetEnumerator())\r\n            {\r\n                if (iter.MoveNext())\r\n        " +
                    "        {\r\n                    var sb = GetStringBuilder();\r\n                   " +
                    " append(sb, iter.Current);\r\n                    while (iter.MoveNext())\r\n       " +
                    "             {\r\n                        append(sb.Append(\',\'), iter.Current);\r\n " +
                    "                   }\r\n                    val = sb.ToString();\r\n                " +
                    "}\r\n                else\r\n                {\r\n                    val = \"\";\r\n     " +
                    "           }\r\n            }\r\n            concatenatedParam.Value = val;\r\n       " +
                    "     command.Parameters.Add(concatenatedParam);\r\n            return true;\r\n     " +
                    "   }\r\n\r\n        /// <summary>\r\n        /// OBSOLETE: For internal usage only. Sa" +
                    "nitizes the paramter value with proper type casting.\r\n        /// </summary>\r\n  " +
                    "      [Obsolete(ObsoleteInternalUsageOnly, false)]\r\n        public static object" +
                    " SanitizeParameterValue(object value)\r\n        {\r\n            if (value == null)" +
                    " return DBNull.Value;\r\n            if (value is Enum)\r\n            {\r\n          " +
                    "      TypeCode typeCode;\r\n                if (value is IConvertible)\r\n          " +
                    "      {\r\n                    typeCode = ((IConvertible)value).GetTypeCode();\r\n  " +
                    "              }\r\n                else\r\n                {\r\n                    ty" +
                    "peCode = TypeExtensions.GetTypeCode(Enum.GetUnderlyingType(value.GetType()));\r\n " +
                    "               }\r\n                switch (typeCode)\r\n                {\r\n        " +
                    "            case TypeCode.Byte: return (byte)value;\r\n                    case Ty" +
                    "peCode.SByte: return (sbyte)value;\r\n                    case TypeCode.Int16: ret" +
                    "urn (short)value;\r\n                    case TypeCode.Int32: return (int)value;\r\n" +
                    "                    case TypeCode.Int64: return (long)value;\r\n                  " +
                    "  case TypeCode.UInt16: return (ushort)value;\r\n                    case TypeCode" +
                    ".UInt32: return (uint)value;\r\n                    case TypeCode.UInt64: return (" +
                    "ulong)value;\r\n                }\r\n            }\r\n            return value;\r\n     " +
                    "   }\r\n        private static IEnumerable<PropertyInfo> FilterParameters(IEnumera" +
                    "ble<PropertyInfo> parameters, string sql)\r\n        {\r\n            return paramet" +
                    "ers.Where(p => Regex.IsMatch(sql, @\"[?@:]\" + p.Name + \"([^a-z0-9_]+|$)\", RegexOp" +
                    "tions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant));\r\n  " +
                    "      }\r\n\r\n        // look for ? / @ / : *by itself*\r\n        static readonly Re" +
                    "gex smellsLikeOleDb = new Regex(@\"(?<![a-z0-9@_])[?@:](?![a-z0-9@_])\", RegexOpti" +
                    "ons.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexO" +
                    "ptions.Compiled),\r\n            literalTokens = new Regex(@\"(?<![a-z0-9_])\\{=([a-" +
                    "z0-9_]+)\\}\", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Cul" +
                    "tureInvariant | RegexOptions.Compiled),\r\n            pseudoPositional = new Rege" +
                    "x(@\"\\?([a-z_][a-z0-9_]*)\\?\", RegexOptions.IgnoreCase | RegexOptions.CultureInvar" +
                    "iant | RegexOptions.Compiled);\r\n\r\n\r\n\r\n        /// <summary>\r\n        /// Replace" +
                    " all literal tokens with their text form\r\n        /// </summary>\r\n        public" +
                    " static void ReplaceLiterals(this IParameterLookup parameters, IDbCommand comman" +
                    "d)\r\n        {\r\n            var tokens = GetLiteralTokens(command.CommandText);\r\n" +
                    "            if (tokens.Count != 0) ReplaceLiterals(parameters, command, tokens);" +
                    "\r\n        }\r\n\r\n        internal static readonly MethodInfo format = typeof(SqlMa" +
                    "pper).GetMethod(\"Format\", BindingFlags.Public | BindingFlags.Static);\r\n        /" +
                    "// <summary>\r\n        /// Convert numeric values to their string form for SQL li" +
                    "teral purposes\r\n        /// </summary>\r\n        [Obsolete(ObsoleteInternalUsageO" +
                    "nly)]\r\n        public static string Format(object value)\r\n        {\r\n           " +
                    " if (value == null)\r\n            {\r\n                return \"null\";\r\n            " +
                    "}\r\n            else\r\n            {\r\n                switch (TypeExtensions.GetTy" +
                    "peCode(value.GetType()))\r\n                {\r\n#if !COREFX\r\n                    ca" +
                    "se TypeCode.DBNull:\r\n                        return \"null\";\r\n#endif\r\n           " +
                    "         case TypeCode.Boolean:\r\n                        return ((bool)value) ? " +
                    "\"1\" : \"0\";\r\n                    case TypeCode.Byte:\r\n                        ret" +
                    "urn ((byte)value).ToString(CultureInfo.InvariantCulture);\r\n                    c" +
                    "ase TypeCode.SByte:\r\n                        return ((sbyte)value).ToString(Cult" +
                    "ureInfo.InvariantCulture);\r\n                    case TypeCode.UInt16:\r\n         " +
                    "               return ((ushort)value).ToString(CultureInfo.InvariantCulture);\r\n " +
                    "                   case TypeCode.Int16:\r\n                        return ((short)" +
                    "value).ToString(CultureInfo.InvariantCulture);\r\n                    case TypeCod" +
                    "e.UInt32:\r\n                        return ((uint)value).ToString(CultureInfo.Inv" +
                    "ariantCulture);\r\n                    case TypeCode.Int32:\r\n                     " +
                    "   return ((int)value).ToString(CultureInfo.InvariantCulture);\r\n                " +
                    "    case TypeCode.UInt64:\r\n                        return ((ulong)value).ToStrin" +
                    "g(CultureInfo.InvariantCulture);\r\n                    case TypeCode.Int64:\r\n    " +
                    "                    return ((long)value).ToString(CultureInfo.InvariantCulture);" +
                    "\r\n                    case TypeCode.Single:\r\n                        return ((fl" +
                    "oat)value).ToString(CultureInfo.InvariantCulture);\r\n                    case Typ" +
                    "eCode.Double:\r\n                        return ((double)value).ToString(CultureIn" +
                    "fo.InvariantCulture);\r\n                    case TypeCode.Decimal:\r\n             " +
                    "           return ((decimal)value).ToString(CultureInfo.InvariantCulture);\r\n    " +
                    "                default:\r\n                        var multiExec = GetMultiExec(v" +
                    "alue);\r\n                        if (multiExec != null)\r\n                        " +
                    "{\r\n                            StringBuilder sb = null;\r\n                       " +
                    "     bool first = true;\r\n                            foreach (object subval in m" +
                    "ultiExec)\r\n                            {\r\n                                if (fi" +
                    "rst)\r\n                                {\r\n                                    sb " +
                    "= GetStringBuilder().Append(\'(\');\r\n                                    first = f" +
                    "alse;\r\n                                }\r\n                                else\r\n" +
                    "                                {\r\n                                    sb.Append" +
                    "(\',\');\r\n                                }\r\n                                sb.Ap" +
                    "pend(Format(subval));\r\n                            }\r\n                          " +
                    "  if (first)\r\n                            {\r\n                                ret" +
                    "urn \"(select null where 1=0)\";\r\n                            }\r\n                 " +
                    "           else\r\n                            {\r\n                                " +
                    "return sb.Append(\')\').__ToStringRecycle();\r\n                            }\r\n     " +
                    "                   }\r\n                        throw new NotSupportedException(va" +
                    "lue.GetType().Name);\r\n                }\r\n            }\r\n        }\r\n\r\n\r\n        i" +
                    "nternal static void ReplaceLiterals(IParameterLookup parameters, IDbCommand comm" +
                    "and, IList<LiteralToken> tokens)\r\n        {\r\n            var sql = command.Comma" +
                    "ndText;\r\n            foreach (var token in tokens)\r\n            {\r\n             " +
                    "   object value = parameters[token.Member];\r\n#pragma warning disable 0618\r\n     " +
                    "           string text = Format(value);\r\n#pragma warning restore 0618\r\n         " +
                    "       sql = sql.Replace(token.Token, text);\r\n            }\r\n            command" +
                    ".CommandText = sql;\r\n        }\r\n\r\n        internal static IList<LiteralToken> Ge" +
                    "tLiteralTokens(string sql)\r\n        {\r\n            if (string.IsNullOrEmpty(sql)" +
                    ") return LiteralToken.None;\r\n            if (!literalTokens.IsMatch(sql)) return" +
                    " LiteralToken.None;\r\n\r\n            var matches = literalTokens.Matches(sql);\r\n  " +
                    "          var found = new HashSet<string>(StringComparer.Ordinal);\r\n            " +
                    "List<LiteralToken> list = new List<LiteralToken>(matches.Count);\r\n            fo" +
                    "reach (Match match in matches)\r\n            {\r\n                string token = ma" +
                    "tch.Value;\r\n                if (found.Add(match.Value))\r\n                {\r\n    " +
                    "                list.Add(new LiteralToken(token, match.Groups[1].Value));\r\n     " +
                    "           }\r\n            }\r\n            return list.Count == 0 ? LiteralToken.N" +
                    "one : list;\r\n        }\r\n\r\n        /// <summary>\r\n        /// Internal use only\r\n" +
                    "        /// </summary>\r\n        public static Action<IDbCommand, object> CreateP" +
                    "aramInfoGenerator(Identity identity, bool checkForDuplicates, bool removeUnused)" +
                    "\r\n        {\r\n            return CreateParamInfoGenerator(identity, checkForDupli" +
                    "cates, removeUnused, GetLiteralTokens(identity.sql));\r\n        }\r\n\r\n        inte" +
                    "rnal static Action<IDbCommand, object> CreateParamInfoGenerator(Identity identit" +
                    "y, bool checkForDuplicates, bool removeUnused, IList<LiteralToken> literals)\r\n  " +
                    "      {\r\n            Type type = identity.parametersType;\r\n\r\n            bool fi" +
                    "lterParams = false;\r\n            if (removeUnused && identity.commandType.GetVal" +
                    "ueOrDefault(CommandType.Text) == CommandType.Text)\r\n            {\r\n             " +
                    "   filterParams = !smellsLikeOleDb.IsMatch(identity.sql);\r\n            }\r\n      " +
                    "      var dm = new DynamicMethod(\"ParamInfo\" + Guid.NewGuid().ToString(), null, " +
                    "new[] { typeof(IDbCommand), typeof(object) }, type, true);\r\n\r\n            var il" +
                    " = dm.GetILGenerator();\r\n\r\n            bool isStruct = type.IsValueType();\r\n    " +
                    "        bool haveInt32Arg1 = false;\r\n            il.Emit(OpCodes.Ldarg_1); // st" +
                    "ack is now [untyped-param]\r\n            if (isStruct)\r\n            {\r\n          " +
                    "      il.DeclareLocal(type.MakePointerType());\r\n                il.Emit(OpCodes." +
                    "Unbox, type); // stack is now [typed-param]\r\n            }\r\n            else\r\n  " +
                    "          {\r\n                il.DeclareLocal(type); // 0\r\n                il.Emi" +
                    "t(OpCodes.Castclass, type); // stack is now [typed-param]\r\n            }\r\n      " +
                    "      il.Emit(OpCodes.Stloc_0);// stack is now empty\r\n\r\n            il.Emit(OpCo" +
                    "des.Ldarg_0); // stack is now [command]\r\n            il.EmitCall(OpCodes.Callvir" +
                    "t, typeof(IDbCommand).GetProperty(nameof(IDbCommand.Parameters)).GetGetMethod()," +
                    " null); // stack is now [parameters]\r\n\r\n            var propsArr = type.GetPrope" +
                    "rties().Where(p => p.GetIndexParameters().Length == 0).ToArray();\r\n            v" +
                    "ar ctors = type.GetConstructors();\r\n            ParameterInfo[] ctorParams;\r\n   " +
                    "         IEnumerable<PropertyInfo> props = null;\r\n            // try to detect t" +
                    "uple patterns, e.g. anon-types, and use that to choose the order\r\n            //" +
                    " otherwise: alphabetical\r\n            if (ctors.Length == 1 && propsArr.Length =" +
                    "= (ctorParams = ctors[0].GetParameters()).Length)\r\n            {\r\n              " +
                    "  // check if reflection was kind enough to put everything in the right order fo" +
                    "r us\r\n                bool ok = true;\r\n                for (int i = 0; i < props" +
                    "Arr.Length; i++)\r\n                {\r\n                    if (!string.Equals(prop" +
                    "sArr[i].Name, ctorParams[i].Name, StringComparison.OrdinalIgnoreCase))\r\n        " +
                    "            {\r\n                        ok = false;\r\n                        brea" +
                    "k;\r\n                    }\r\n                }\r\n                if (ok)\r\n         " +
                    "       {\r\n                    // pre-sorted; the reflection gods have smiled upo" +
                    "n us\r\n                    props = propsArr;\r\n                }\r\n                " +
                    "else\r\n                { // might still all be accounted for; check the hard way\r" +
                    "\n                    var positionByName = new Dictionary<string, int>(StringComp" +
                    "arer.OrdinalIgnoreCase);\r\n                    foreach (var param in ctorParams)\r" +
                    "\n                    {\r\n                        positionByName[param.Name] = par" +
                    "am.Position;\r\n                    }\r\n                    if (positionByName.Coun" +
                    "t == propsArr.Length)\r\n                    {\r\n                        int[] posi" +
                    "tions = new int[propsArr.Length];\r\n                        ok = true;\r\n         " +
                    "               for (int i = 0; i < propsArr.Length; i++)\r\n                      " +
                    "  {\r\n                            int pos;\r\n                            if (!posi" +
                    "tionByName.TryGetValue(propsArr[i].Name, out pos))\r\n                            " +
                    "{\r\n                                ok = false;\r\n                                " +
                    "break;\r\n                            }\r\n                            positions[i] " +
                    "= pos;\r\n                        }\r\n                        if (ok)\r\n            " +
                    "            {\r\n                            Array.Sort(positions, propsArr);\r\n   " +
                    "                         props = propsArr;\r\n                        }\r\n         " +
                    "           }\r\n                }\r\n            }\r\n            if (props == null) p" +
                    "rops = propsArr.OrderBy(x => x.Name);\r\n            if (filterParams)\r\n          " +
                    "  {\r\n                props = FilterParameters(props, identity.sql);\r\n           " +
                    " }\r\n\r\n            var callOpCode = isStruct ? OpCodes.Call : OpCodes.Callvirt;\r\n" +
                    "            foreach (var prop in props)\r\n            {\r\n                if (type" +
                    "of(ICustomQueryParameter).IsAssignableFrom(prop.PropertyType))\r\n                " +
                    "{\r\n                    il.Emit(OpCodes.Ldloc_0); // stack is now [parameters] [t" +
                    "yped-param]\r\n                    il.Emit(callOpCode, prop.GetGetMethod()); // st" +
                    "ack is [parameters] [custom]\r\n                    il.Emit(OpCodes.Ldarg_0); // s" +
                    "tack is now [parameters] [custom] [command]\r\n                    il.Emit(OpCodes" +
                    ".Ldstr, prop.Name); // stack is now [parameters] [custom] [command] [name]\r\n    " +
                    "                il.EmitCall(OpCodes.Callvirt, prop.PropertyType.GetMethod(nameof" +
                    "(ICustomQueryParameter.AddParameter)), null); // stack is now [parameters]\r\n    " +
                    "                continue;\r\n                }\r\n                ITypeHandler handl" +
                    "er;\r\n#pragma warning disable 618\r\n                DbType dbType = LookupDbType(p" +
                    "rop.PropertyType, prop.Name, true, out handler);\r\n#pragma warning restore 618\r\n " +
                    "               if (dbType == DynamicParameters.EnumerableMultiParameter)\r\n      " +
                    "          {\r\n                    // this actually represents special handling fo" +
                    "r list types;\r\n                    il.Emit(OpCodes.Ldarg_0); // stack is now [pa" +
                    "rameters] [command]\r\n                    il.Emit(OpCodes.Ldstr, prop.Name); // s" +
                    "tack is now [parameters] [command] [name]\r\n                    il.Emit(OpCodes.L" +
                    "dloc_0); // stack is now [parameters] [command] [name] [typed-param]\r\n          " +
                    "          il.Emit(callOpCode, prop.GetGetMethod()); // stack is [parameters] [co" +
                    "mmand] [name] [typed-value]\r\n                    if (prop.PropertyType.IsValueTy" +
                    "pe())\r\n                    {\r\n                        il.Emit(OpCodes.Box, prop." +
                    "PropertyType); // stack is [parameters] [command] [name] [boxed-value]\r\n        " +
                    "            }\r\n                    il.EmitCall(OpCodes.Call, typeof(SqlMapper).G" +
                    "etMethod(nameof(SqlMapper.PackListParameters)), null); // stack is [parameters]\r" +
                    "\n                    continue;\r\n                }\r\n                il.Emit(OpCod" +
                    "es.Dup); // stack is now [parameters] [parameters]\r\n\r\n                il.Emit(Op" +
                    "Codes.Ldarg_0); // stack is now [parameters] [parameters] [command]\r\n\r\n         " +
                    "       if (checkForDuplicates)\r\n                {\r\n                    // need t" +
                    "o be a little careful about adding; use a utility method\r\n                    il" +
                    ".Emit(OpCodes.Ldstr, prop.Name); // stack is now [parameters] [parameters] [comm" +
                    "and] [name]\r\n                    il.EmitCall(OpCodes.Call, typeof(SqlMapper).Get" +
                    "Method(nameof(SqlMapper.FindOrAddParameter)), null); // stack is [parameters] [p" +
                    "arameter]\r\n                }\r\n                else\r\n                {\r\n         " +
                    "           // no risk of duplicates; just blindly add\r\n                    il.Em" +
                    "itCall(OpCodes.Callvirt, typeof(IDbCommand).GetMethod(nameof(IDbCommand.CreatePa" +
                    "rameter)), null);// stack is now [parameters] [parameters] [parameter]\r\n\r\n      " +
                    "              il.Emit(OpCodes.Dup);// stack is now [parameters] [parameters] [pa" +
                    "rameter] [parameter]\r\n                    il.Emit(OpCodes.Ldstr, prop.Name); // " +
                    "stack is now [parameters] [parameters] [parameter] [parameter] [name]\r\n         " +
                    "           il.EmitCall(OpCodes.Callvirt, typeof(IDataParameter).GetProperty(name" +
                    "of(IDataParameter.ParameterName)).GetSetMethod(), null);// stack is now [paramet" +
                    "ers] [parameters] [parameter]\r\n                }\r\n                if (dbType != " +
                    "DbType.Time && handler == null) // https://connect.microsoft.com/VisualStudio/fe" +
                    "edback/details/381934/sqlparameter-dbtype-dbtype-time-sets-the-parameter-to-sqld" +
                    "btype-datetime-instead-of-sqldbtype-time\r\n                {\r\n                   " +
                    " il.Emit(OpCodes.Dup);// stack is now [parameters] [[parameters]] [parameter] [p" +
                    "arameter]\r\n                    if (dbType == DbType.Object && prop.PropertyType " +
                    "== typeof(object)) // includes dynamic\r\n                    {\r\n                 " +
                    "       // look it up from the param value\r\n                        il.Emit(OpCod" +
                    "es.Ldloc_0); // stack is now [parameters] [[parameters]] [parameter] [parameter]" +
                    " [typed-param]\r\n                        il.Emit(callOpCode, prop.GetGetMethod())" +
                    "; // stack is [parameters] [[parameters]] [parameter] [parameter] [object-value]" +
                    "\r\n                        il.Emit(OpCodes.Call, typeof(SqlMapper).GetMethod(name" +
                    "of(SqlMapper.GetDbType), BindingFlags.Static | BindingFlags.Public)); // stack i" +
                    "s now [parameters] [[parameters]] [parameter] [parameter] [db-type]\r\n           " +
                    "         }\r\n                    else\r\n                    {\r\n                   " +
                    "     // constant value; nice and simple\r\n                        EmitInt32(il, (" +
                    "int)dbType);// stack is now [parameters] [[parameters]] [parameter] [parameter] " +
                    "[db-type]\r\n                    }\r\n                    il.EmitCall(OpCodes.Callvi" +
                    "rt, typeof(IDataParameter).GetProperty(nameof(IDataParameter.DbType)).GetSetMeth" +
                    "od(), null);// stack is now [parameters] [[parameters]] [parameter]\r\n           " +
                    "     }\r\n\r\n                il.Emit(OpCodes.Dup);// stack is now [parameters] [[pa" +
                    "rameters]] [parameter] [parameter]\r\n                EmitInt32(il, (int)Parameter" +
                    "Direction.Input);// stack is now [parameters] [[parameters]] [parameter] [parame" +
                    "ter] [dir]\r\n                il.EmitCall(OpCodes.Callvirt, typeof(IDataParameter)" +
                    ".GetProperty(nameof(IDataParameter.Direction)).GetSetMethod(), null);// stack is" +
                    " now [parameters] [[parameters]] [parameter]\r\n\r\n                il.Emit(OpCodes." +
                    "Dup);// stack is now [parameters] [[parameters]] [parameter] [parameter]\r\n      " +
                    "          il.Emit(OpCodes.Ldloc_0); // stack is now [parameters] [[parameters]] " +
                    "[parameter] [parameter] [typed-param]\r\n                il.Emit(callOpCode, prop." +
                    "GetGetMethod()); // stack is [parameters] [[parameters]] [parameter] [parameter]" +
                    " [typed-value]\r\n                bool checkForNull;\r\n                if (prop.Pro" +
                    "pertyType.IsValueType())\r\n                {\r\n                    var propType = " +
                    "prop.PropertyType;\r\n                    var nullType = Nullable.GetUnderlyingTyp" +
                    "e(propType);\r\n                    bool callSanitize = false;\r\n\r\n                " +
                    "    if ((nullType ?? propType).IsEnum())\r\n                    {\r\n               " +
                    "         if (nullType != null)\r\n                        {\r\n                     " +
                    "       // Nullable<SomeEnum>; we want to box as the underlying type; that\'s just" +
                    " *hard*; for\r\n                            // simplicity, box as Nullable<SomeEnu" +
                    "m> and call SanitizeParameterValue\r\n                            callSanitize = c" +
                    "heckForNull = true;\r\n                        }\r\n                        else\r\n  " +
                    "                      {\r\n                            checkForNull = false;\r\n    " +
                    "                        // non-nullable enum; we can do that! just box to the wr" +
                    "ong type! (no, really)\r\n                            switch (TypeExtensions.GetTy" +
                    "peCode(Enum.GetUnderlyingType(propType)))\r\n                            {\r\n      " +
                    "                          case TypeCode.Byte: propType = typeof(byte); break;\r\n " +
                    "                               case TypeCode.SByte: propType = typeof(sbyte); br" +
                    "eak;\r\n                                case TypeCode.Int16: propType = typeof(sho" +
                    "rt); break;\r\n                                case TypeCode.Int32: propType = typ" +
                    "eof(int); break;\r\n                                case TypeCode.Int64: propType " +
                    "= typeof(long); break;\r\n                                case TypeCode.UInt16: pr" +
                    "opType = typeof(ushort); break;\r\n                                case TypeCode.U" +
                    "Int32: propType = typeof(uint); break;\r\n                                case Typ" +
                    "eCode.UInt64: propType = typeof(ulong); break;\r\n                            }\r\n " +
                    "                       }\r\n                    }\r\n                    else\r\n     " +
                    "               {\r\n                        checkForNull = nullType != null;\r\n    " +
                    "                }\r\n                    il.Emit(OpCodes.Box, propType); // stack " +
                    "is [parameters] [[parameters]] [parameter] [parameter] [boxed-value]\r\n          " +
                    "          if (callSanitize)\r\n                    {\r\n                        chec" +
                    "kForNull = false; // handled by sanitize\r\n                        il.EmitCall(Op" +
                    "Codes.Call, typeof(SqlMapper).GetMethod(nameof(SanitizeParameterValue)), null);\r" +
                    "\n                        // stack is [parameters] [[parameters]] [parameter] [pa" +
                    "rameter] [boxed-value]\r\n                    }\r\n                }\r\n              " +
                    "  else\r\n                {\r\n                    checkForNull = true; // if not a " +
                    "value-type, need to check\r\n                }\r\n                if (checkForNull)\r" +
                    "\n                {\r\n                    if ((dbType == DbType.String || dbType =" +
                    "= DbType.AnsiString) && !haveInt32Arg1)\r\n                    {\r\n                " +
                    "        il.DeclareLocal(typeof(int));\r\n                        haveInt32Arg1 = t" +
                    "rue;\r\n                    }\r\n                    // relative stack: [boxed value" +
                    "]\r\n                    il.Emit(OpCodes.Dup);// relative stack: [boxed value] [bo" +
                    "xed value]\r\n                    Label notNull = il.DefineLabel();\r\n             " +
                    "       Label? allDone = (dbType == DbType.String || dbType == DbType.AnsiString)" +
                    " ? il.DefineLabel() : (Label?)null;\r\n                    il.Emit(OpCodes.Brtrue_" +
                    "S, notNull);\r\n                    // relative stack [boxed value = null]\r\n      " +
                    "              il.Emit(OpCodes.Pop); // relative stack empty\r\n                   " +
                    " il.Emit(OpCodes.Ldsfld, typeof(DBNull).GetField(nameof(DBNull.Value))); // rela" +
                    "tive stack [DBNull]\r\n                    if (dbType == DbType.String || dbType =" +
                    "= DbType.AnsiString)\r\n                    {\r\n                        EmitInt32(i" +
                    "l, 0);\r\n                        il.Emit(OpCodes.Stloc_1);\r\n                    }" +
                    "\r\n                    if (allDone != null) il.Emit(OpCodes.Br_S, allDone.Value);" +
                    "\r\n                    il.MarkLabel(notNull);\r\n                    if (prop.Prope" +
                    "rtyType == typeof(string))\r\n                    {\r\n                        il.Em" +
                    "it(OpCodes.Dup); // [string] [string]\r\n                        il.EmitCall(OpCod" +
                    "es.Callvirt, typeof(string).GetProperty(nameof(string.Length)).GetGetMethod(), n" +
                    "ull); // [string] [length]\r\n                        EmitInt32(il, DbString.Defau" +
                    "ltLength); // [string] [length] [4000]\r\n                        il.Emit(OpCodes." +
                    "Cgt); // [string] [0 or 1]\r\n                        Label isLong = il.DefineLabe" +
                    "l(), lenDone = il.DefineLabel();\r\n                        il.Emit(OpCodes.Brtrue" +
                    "_S, isLong);\r\n                        EmitInt32(il, DbString.DefaultLength); // " +
                    "[string] [4000]\r\n                        il.Emit(OpCodes.Br_S, lenDone);\r\n      " +
                    "                  il.MarkLabel(isLong);\r\n                        EmitInt32(il, -" +
                    "1); // [string] [-1]\r\n                        il.MarkLabel(lenDone);\r\n          " +
                    "              il.Emit(OpCodes.Stloc_1); // [string]\r\n                    }\r\n    " +
                    "                if (prop.PropertyType.FullName == LinqBinary)\r\n                 " +
                    "   {\r\n                        il.EmitCall(OpCodes.Callvirt, prop.PropertyType.Ge" +
                    "tMethod(\"ToArray\", BindingFlags.Public | BindingFlags.Instance), null);\r\n       " +
                    "             }\r\n                    if (allDone != null) il.MarkLabel(allDone.Va" +
                    "lue);\r\n                    // relative stack [boxed value or DBNull]\r\n          " +
                    "      }\r\n\r\n                if (handler != null)\r\n                {\r\n#pragma warn" +
                    "ing disable 618\r\n                    il.Emit(OpCodes.Call, typeof(TypeHandlerCac" +
                    "he<>).MakeGenericType(prop.PropertyType).GetMethod(nameof(TypeHandlerCache<int>." +
                    "SetValue))); // stack is now [parameters] [[parameters]] [parameter]\r\n#pragma wa" +
                    "rning restore 618\r\n                }\r\n                else\r\n                {\r\n " +
                    "                   il.EmitCall(OpCodes.Callvirt, typeof(IDataParameter).GetPrope" +
                    "rty(nameof(IDataParameter.Value)).GetSetMethod(), null);// stack is now [paramet" +
                    "ers] [[parameters]] [parameter]\r\n                }\r\n\r\n                if (prop.P" +
                    "ropertyType == typeof(string))\r\n                {\r\n                    var endOf" +
                    "Size = il.DefineLabel();\r\n                    // don\'t set if 0\r\n               " +
                    "     il.Emit(OpCodes.Ldloc_1); // [parameters] [[parameters]] [parameter] [size]" +
                    "\r\n                    il.Emit(OpCodes.Brfalse_S, endOfSize); // [parameters] [[p" +
                    "arameters]] [parameter]\r\n\r\n                    il.Emit(OpCodes.Dup);// stack is " +
                    "now [parameters] [[parameters]] [parameter] [parameter]\r\n                    il." +
                    "Emit(OpCodes.Ldloc_1); // stack is now [parameters] [[parameters]] [parameter] [" +
                    "parameter] [size]\r\n                    il.EmitCall(OpCodes.Callvirt, typeof(IDbD" +
                    "ataParameter).GetProperty(nameof(IDbDataParameter.Size)).GetSetMethod(), null); " +
                    "// stack is now [parameters] [[parameters]] [parameter]\r\n\r\n                    i" +
                    "l.MarkLabel(endOfSize);\r\n                }\r\n                if (checkForDuplicat" +
                    "es)\r\n                {\r\n                    // stack is now [parameters] [parame" +
                    "ter]\r\n                    il.Emit(OpCodes.Pop); // don\'t need parameter any more" +
                    "\r\n                }\r\n                else\r\n                {\r\n                  " +
                    "  // stack is now [parameters] [parameters] [parameter]\r\n                    // " +
                    "blindly add\r\n                    il.EmitCall(OpCodes.Callvirt, typeof(IList).Get" +
                    "Method(nameof(IList.Add)), null); // stack is now [parameters]\r\n                " +
                    "    il.Emit(OpCodes.Pop); // IList.Add returns the new index (int); we don\'t car" +
                    "e\r\n                }\r\n            }\r\n\r\n            // stack is currently [parame" +
                    "ters]\r\n            il.Emit(OpCodes.Pop); // stack is now empty\r\n\r\n            if" +
                    " (literals.Count != 0 && propsArr != null)\r\n            {\r\n                il.Em" +
                    "it(OpCodes.Ldarg_0); // command\r\n                il.Emit(OpCodes.Ldarg_0); // co" +
                    "mmand, command\r\n                var cmdText = typeof(IDbCommand).GetProperty(nam" +
                    "eof(IDbCommand.CommandText));\r\n                il.EmitCall(OpCodes.Callvirt, cmd" +
                    "Text.GetGetMethod(), null); // command, sql\r\n                Dictionary<Type, Lo" +
                    "calBuilder> locals = null;\r\n                LocalBuilder local = null;\r\n        " +
                    "        foreach (var literal in literals)\r\n                {\r\n                  " +
                    "  // find the best member, preferring case-sensitive\r\n                    Proper" +
                    "tyInfo exact = null, fallback = null;\r\n                    string huntName = lit" +
                    "eral.Member;\r\n                    for (int i = 0; i < propsArr.Length; i++)\r\n   " +
                    "                 {\r\n                        string thisName = propsArr[i].Name;\r" +
                    "\n                        if (string.Equals(thisName, huntName, StringComparison." +
                    "OrdinalIgnoreCase))\r\n                        {\r\n                            fall" +
                    "back = propsArr[i];\r\n                            if (string.Equals(thisName, hun" +
                    "tName, StringComparison.Ordinal))\r\n                            {\r\n              " +
                    "                  exact = fallback;\r\n                                break;\r\n   " +
                    "                         }\r\n                        }\r\n                    }\r\n  " +
                    "                  var prop = exact ?? fallback;\r\n\r\n                    if (prop " +
                    "!= null)\r\n                    {\r\n                        il.Emit(OpCodes.Ldstr, " +
                    "literal.Token);\r\n                        il.Emit(OpCodes.Ldloc_0); // command, s" +
                    "ql, typed parameter\r\n                        il.EmitCall(callOpCode, prop.GetGet" +
                    "Method(), null); // command, sql, typed value\r\n                        Type prop" +
                    "Type = prop.PropertyType;\r\n                        var typeCode = TypeExtensions" +
                    ".GetTypeCode(propType);\r\n                        switch (typeCode)\r\n            " +
                    "            {\r\n                            case TypeCode.Boolean:\r\n             " +
                    "                   Label ifTrue = il.DefineLabel(), allDone = il.DefineLabel();\r" +
                    "\n                                il.Emit(OpCodes.Brtrue_S, ifTrue);\r\n           " +
                    "                     il.Emit(OpCodes.Ldstr, \"0\");\r\n                             " +
                    "   il.Emit(OpCodes.Br_S, allDone);\r\n                                il.MarkLabel" +
                    "(ifTrue);\r\n                                il.Emit(OpCodes.Ldstr, \"1\");\r\n       " +
                    "                         il.MarkLabel(allDone);\r\n                               " +
                    " break;\r\n                            case TypeCode.Byte:\r\n                      " +
                    "      case TypeCode.SByte:\r\n                            case TypeCode.UInt16:\r\n " +
                    "                           case TypeCode.Int16:\r\n                            cas" +
                    "e TypeCode.UInt32:\r\n                            case TypeCode.Int32:\r\n          " +
                    "                  case TypeCode.UInt64:\r\n                            case TypeCo" +
                    "de.Int64:\r\n                            case TypeCode.Single:\r\n                  " +
                    "          case TypeCode.Double:\r\n                            case TypeCode.Decim" +
                    "al:\r\n                                // need to stloc, ldloca, call\r\n           " +
                    "                     // re-use existing locals (both the last known, and via a d" +
                    "ictionary)\r\n                                var convert = GetToString(typeCode);" +
                    "\r\n                                if (local == null || local.LocalType != propTy" +
                    "pe)\r\n                                {\r\n                                    if (" +
                    "locals == null)\r\n                                    {\r\n                        " +
                    "                locals = new Dictionary<Type, LocalBuilder>();\r\n                " +
                    "                        local = null;\r\n                                    }\r\n  " +
                    "                                  else\r\n                                    {\r\n " +
                    "                                       if (!locals.TryGetValue(propType, out loc" +
                    "al)) local = null;\r\n                                    }\r\n                     " +
                    "               if (local == null)\r\n                                    {\r\n      " +
                    "                                  local = il.DeclareLocal(propType);\r\n          " +
                    "                              locals.Add(propType, local);\r\n                    " +
                    "                }\r\n                                }\r\n                          " +
                    "      il.Emit(OpCodes.Stloc, local); // command, sql\r\n                          " +
                    "      il.Emit(OpCodes.Ldloca, local); // command, sql, ref-to-value\r\n           " +
                    "                     il.EmitCall(OpCodes.Call, InvariantCulture, null); // comma" +
                    "nd, sql, ref-to-value, culture\r\n                                il.EmitCall(OpCo" +
                    "des.Call, convert, null); // command, sql, string value\r\n                       " +
                    "         break;\r\n                            default:\r\n                         " +
                    "       if (propType.IsValueType()) il.Emit(OpCodes.Box, propType); // command, s" +
                    "ql, object value\r\n                                il.EmitCall(OpCodes.Call, form" +
                    "at, null); // command, sql, string value\r\n                                break;" +
                    "\r\n\r\n                        }\r\n                        il.EmitCall(OpCodes.Callv" +
                    "irt, StringReplace, null);\r\n                    }\r\n                }\r\n          " +
                    "      il.EmitCall(OpCodes.Callvirt, cmdText.GetSetMethod(), null); // empty\r\n   " +
                    "         }\r\n\r\n            il.Emit(OpCodes.Ret);\r\n            return (Action<IDbC" +
                    "ommand, object>)dm.CreateDelegate(typeof(Action<IDbCommand, object>));\r\n        " +
                    "}\r\n        static readonly Dictionary<TypeCode, MethodInfo> toStrings = new[]\r\n " +
                    "       {\r\n            typeof(bool), typeof(sbyte), typeof(byte), typeof(ushort)," +
                    " typeof(short),\r\n            typeof(uint), typeof(int), typeof(ulong), typeof(lo" +
                    "ng), typeof(float), typeof(double), typeof(decimal)\r\n        }.ToDictionary(x =>" +
                    " TypeExtensions.GetTypeCode(x), x => x.GetPublicInstanceMethod(nameof(object.ToS" +
                    "tring), new[] { typeof(IFormatProvider) }));\r\n        static MethodInfo GetToStr" +
                    "ing(TypeCode typeCode)\r\n        {\r\n            MethodInfo method;\r\n            r" +
                    "eturn toStrings.TryGetValue(typeCode, out method) ? method : null;\r\n        }\r\n " +
                    "       static readonly MethodInfo StringReplace = typeof(string).GetPublicInstan" +
                    "ceMethod(nameof(string.Replace), new Type[] { typeof(string), typeof(string) })," +
                    "\r\n            InvariantCulture = typeof(CultureInfo).GetProperty(nameof(CultureI" +
                    "nfo.InvariantCulture), BindingFlags.Public | BindingFlags.Static).GetGetMethod()" +
                    ";\r\n\r\n        private static int ExecuteCommand(IDbConnection cnn, ref CommandDef" +
                    "inition command, Action<IDbCommand, object> paramReader)\r\n        {\r\n           " +
                    " IDbCommand cmd = null;\r\n            bool wasClosed = cnn.State == ConnectionSta" +
                    "te.Closed;\r\n            try\r\n            {\r\n                cmd = command.SetupC" +
                    "ommand(cnn, paramReader);\r\n                if (wasClosed) cnn.Open();\r\n         " +
                    "       int result = cmd.ExecuteNonQuery();\r\n                command.OnCompleted(" +
                    ");\r\n                return result;\r\n            }\r\n            finally\r\n        " +
                    "    {\r\n                if (wasClosed) cnn.Close();\r\n                cmd?.Dispose" +
                    "();\r\n            }\r\n        }\r\n\r\n        private static T ExecuteScalarImpl<T>(I" +
                    "DbConnection cnn, ref CommandDefinition command)\r\n        {\r\n            Action<" +
                    "IDbCommand, object> paramReader = null;\r\n            object param = command.Para" +
                    "meters;\r\n            if (param != null)\r\n            {\r\n                var iden" +
                    "tity = new Identity(command.CommandText, command.CommandType, cnn, null, param.G" +
                    "etType(), null);\r\n                paramReader = GetCacheInfo(identity, command.P" +
                    "arameters, command.AddToCache).ParamReader;\r\n            }\r\n\r\n            IDbCom" +
                    "mand cmd = null;\r\n            bool wasClosed = cnn.State == ConnectionState.Clos" +
                    "ed;\r\n            object result;\r\n            try\r\n            {\r\n               " +
                    " cmd = command.SetupCommand(cnn, paramReader);\r\n                if (wasClosed) c" +
                    "nn.Open();\r\n                result = cmd.ExecuteScalar();\r\n                comma" +
                    "nd.OnCompleted();\r\n            }\r\n            finally\r\n            {\r\n          " +
                    "      if (wasClosed) cnn.Close();\r\n                cmd?.Dispose();\r\n            " +
                    "}\r\n            return Parse<T>(result);\r\n        }\r\n\r\n        private static IDa" +
                    "taReader ExecuteReaderImpl(IDbConnection cnn, ref CommandDefinition command, Com" +
                    "mandBehavior commandBehavior, out IDbCommand cmd)\r\n        {\r\n            Action" +
                    "<IDbCommand, object> paramReader = GetParameterReader(cnn, ref command);\r\n      " +
                    "      cmd = null;\r\n            bool wasClosed = cnn.State == ConnectionState.Clo" +
                    "sed, disposeCommand = true;\r\n            try\r\n            {\r\n                cmd" +
                    " = command.SetupCommand(cnn, paramReader);\r\n                if (wasClosed) cnn.O" +
                    "pen();\r\n                var reader = ExecuteReaderWithFlagsFallback(cmd, wasClos" +
                    "ed, commandBehavior);\r\n                wasClosed = false; // don\'t dispose befor" +
                    "e giving it to them!\r\n                disposeCommand = false;\r\n                /" +
                    "/ note: command.FireOutputCallbacks(); would be useless here; parameters come at" +
                    " the **end** of the TDS stream\r\n                return reader;\r\n            }\r\n " +
                    "           finally\r\n            {\r\n                if (wasClosed) cnn.Close();\r\n" +
                    "                if (cmd != null && disposeCommand) cmd.Dispose();\r\n            }" +
                    "\r\n        }\r\n\r\n        private static Action<IDbCommand, object> GetParameterRea" +
                    "der(IDbConnection cnn, ref CommandDefinition command)\r\n        {\r\n            ob" +
                    "ject param = command.Parameters;\r\n            IEnumerable multiExec = GetMultiEx" +
                    "ec(param);\r\n            CacheInfo info = null;\r\n            if (multiExec != nul" +
                    "l)\r\n            {\r\n                throw new NotSupportedException(\"MultiExec is" +
                    " not supported by ExecuteReader\");\r\n            }\r\n\r\n            // nice and sim" +
                    "ple\r\n            if (param != null)\r\n            {\r\n                var identity" +
                    " = new Identity(command.CommandText, command.CommandType, cnn, null, param.GetTy" +
                    "pe(), null);\r\n                info = GetCacheInfo(identity, param, command.AddTo" +
                    "Cache);\r\n            }\r\n            var paramReader = info?.ParamReader;\r\n      " +
                    "      return paramReader;\r\n        }\r\n\r\n        private static Func<IDataReader," +
                    " object> GetStructDeserializer(Type type, Type effectiveType, int index)\r\n      " +
                    "  {\r\n            // no point using special per-type handling here; it boils down" +
                    " to the same, plus not all are supported anyway (see: SqlDataReader.GetChar - no" +
                    "t supported!)\r\n#pragma warning disable 618\r\n            if (type == typeof(char)" +
                    ")\r\n            { // this *does* need special handling, though\r\n                r" +
                    "eturn r => ReadChar(r.GetValue(index));\r\n            }\r\n            if (type == " +
                    "typeof(char?))\r\n            {\r\n                return r => ReadNullableChar(r.Ge" +
                    "tValue(index));\r\n            }\r\n            if (type.FullName == LinqBinary)\r\n  " +
                    "          {\r\n                return r => Activator.CreateInstance(type, r.GetVal" +
                    "ue(index));\r\n            }\r\n#pragma warning restore 618\r\n\r\n            if (effec" +
                    "tiveType.IsEnum())\r\n            {   // assume the value is returned as the corre" +
                    "ct type (int/byte/etc), but box back to the typed enum\r\n                return r" +
                    " =>\r\n                {\r\n                    var val = r.GetValue(index);\r\n      " +
                    "              if (val is float || val is double || val is decimal)\r\n            " +
                    "        {\r\n                        val = Convert.ChangeType(val, Enum.GetUnderly" +
                    "ingType(effectiveType), CultureInfo.InvariantCulture);\r\n                    }\r\n " +
                    "                   return val is DBNull ? null : Enum.ToObject(effectiveType, va" +
                    "l);\r\n                };\r\n            }\r\n            ITypeHandler handler;\r\n     " +
                    "       if (typeHandlers.TryGetValue(type, out handler))\r\n            {\r\n        " +
                    "        return r =>\r\n                {\r\n                    var val = r.GetValue" +
                    "(index);\r\n                    return val is DBNull ? null : handler.Parse(type, " +
                    "val);\r\n                };\r\n            }\r\n            return r =>\r\n            {" +
                    "\r\n                var val = r.GetValue(index);\r\n                return val is DB" +
                    "Null ? null : val;\r\n            };\r\n        }\r\n\r\n        private static T Parse<" +
                    "T>(object value)\r\n        {\r\n            if (value == null || value is DBNull) r" +
                    "eturn default(T);\r\n            if (value is T) return (T)value;\r\n            var" +
                    " type = typeof(T);\r\n            type = Nullable.GetUnderlyingType(type) ?? type;" +
                    "\r\n            if (type.IsEnum())\r\n            {\r\n                if (value is fl" +
                    "oat || value is double || value is decimal)\r\n                {\r\n                " +
                    "    value = Convert.ChangeType(value, Enum.GetUnderlyingType(type), CultureInfo." +
                    "InvariantCulture);\r\n                }\r\n                return (T)Enum.ToObject(t" +
                    "ype, value);\r\n            }\r\n            ITypeHandler handler;\r\n            if (" +
                    "typeHandlers.TryGetValue(type, out handler))\r\n            {\r\n                ret" +
                    "urn (T)handler.Parse(type, value);\r\n            }\r\n            return (T)Convert" +
                    ".ChangeType(value, type, CultureInfo.InvariantCulture);\r\n        }\r\n\r\n        st" +
                    "atic readonly MethodInfo\r\n                    enumParse = typeof(Enum).GetMethod" +
                    "(nameof(Enum.Parse), new Type[] { typeof(Type), typeof(string), typeof(bool) })," +
                    "\r\n                    getItem = typeof(IDataRecord).GetProperties(BindingFlags.I" +
                    "nstance | BindingFlags.Public)\r\n                        .Where(p => p.GetIndexPa" +
                    "rameters().Any() && p.GetIndexParameters()[0].ParameterType == typeof(int))\r\n   " +
                    "                     .Select(p => p.GetGetMethod()).First();\r\n\r\n        /// <sum" +
                    "mary>\r\n        /// Gets type-map for the given type\r\n        /// </summary>\r\n   " +
                    "     /// <returns>Type map instance, default is to create new instance of Defaul" +
                    "tTypeMap</returns>\r\n        public static Func<Type, ITypeMap> TypeMapProvider =" +
                    " (Type type) => new DefaultTypeMap(type);\r\n\r\n        /// <summary>\r\n        /// " +
                    "Gets type-map for the given type\r\n        /// </summary>\r\n        /// <returns>T" +
                    "ype map implementation, DefaultTypeMap instance if no override present</returns>" +
                    "\r\n        public static ITypeMap GetTypeMap(Type type)\r\n        {\r\n            i" +
                    "f (type == null) throw new ArgumentNullException(nameof(type));\r\n            var" +
                    " map = (ITypeMap)_typeMaps[type];\r\n            if (map == null)\r\n            {\r\n" +
                    "                lock (_typeMaps)\r\n                {   // double-checked; store t" +
                    "his to avoid reflection next time we see this type\r\n                    // since" +
                    " multiple queries commonly use the same domain-entity/DTO/view-model type\r\n     " +
                    "               map = (ITypeMap)_typeMaps[type];\r\n\r\n                    if (map =" +
                    "= null)\r\n                    {\r\n                        map = TypeMapProvider(ty" +
                    "pe);\r\n                        _typeMaps[type] = map;\r\n                    }\r\n   " +
                    "             }\r\n            }\r\n            return map;\r\n        }\r\n\r\n        // " +
                    "use Hashtable to get free lockless reading\r\n        private static readonly Hash" +
                    "table _typeMaps = new Hashtable();\r\n\r\n        /// <summary>\r\n        /// Set cus" +
                    "tom mapping for type deserializers\r\n        /// </summary>\r\n        /// <param n" +
                    "ame=\"type\">Entity type to override</param>\r\n        /// <param name=\"map\">Mappin" +
                    "g rules impementation, null to remove custom map</param>\r\n        public static " +
                    "void SetTypeMap(Type type, ITypeMap map)\r\n        {\r\n            if (type == nul" +
                    "l)\r\n                throw new ArgumentNullException(nameof(type));\r\n\r\n          " +
                    "  if (map == null || map is DefaultTypeMap)\r\n            {\r\n                lock" +
                    " (_typeMaps)\r\n                {\r\n                    _typeMaps.Remove(type);\r\n  " +
                    "              }\r\n            }\r\n            else\r\n            {\r\n               " +
                    " lock (_typeMaps)\r\n                {\r\n                    _typeMaps[type] = map;" +
                    "\r\n                }\r\n            }\r\n\r\n            PurgeQueryCacheByType(type);\r\n" +
                    "        }\r\n\r\n        /// <summary>\r\n        /// Internal use only\r\n        /// <" +
                    "/summary>\r\n        /// <param name=\"type\"></param>\r\n        /// <param name=\"rea" +
                    "der\"></param>\r\n        /// <param name=\"startBound\"></param>\r\n        /// <param" +
                    " name=\"length\"></param>\r\n        /// <param name=\"returnNullIfFirstMissing\"></pa" +
                    "ram>\r\n        /// <returns></returns>\r\n        public static Func<IDataReader, o" +
                    "bject> GetTypeDeserializer(\r\n            Type type, IDataReader reader, int star" +
                    "tBound = 0, int length = -1, bool returnNullIfFirstMissing = false\r\n        )\r\n " +
                    "       {\r\n            return TypeDeserializerCache.GetReader(type, reader, start" +
                    "Bound, length, returnNullIfFirstMissing);\r\n        }\r\n        static LocalBuilde" +
                    "r GetTempLocal(ILGenerator il, ref Dictionary<Type, LocalBuilder> locals, Type t" +
                    "ype, bool initAndLoad)\r\n        {\r\n            if (type == null) throw new Argum" +
                    "entNullException(nameof(type));\r\n            if (locals == null) locals = new Di" +
                    "ctionary<Type, LocalBuilder>();\r\n            LocalBuilder found;\r\n            if" +
                    " (!locals.TryGetValue(type, out found))\r\n            {\r\n                found = " +
                    "il.DeclareLocal(type);\r\n                locals.Add(type, found);\r\n            }\r" +
                    "\n            if (initAndLoad)\r\n            {\r\n                il.Emit(OpCodes.Ld" +
                    "loca, (short)found.LocalIndex);\r\n                il.Emit(OpCodes.Initobj, type);" +
                    "\r\n                il.Emit(OpCodes.Ldloca, (short)found.LocalIndex);\r\n           " +
                    "     il.Emit(OpCodes.Ldobj, type);\r\n            }\r\n            return found;\r\n  " +
                    "      }\r\n        private static Func<IDataReader, object> GetTypeDeserializerImp" +
                    "l(\r\n            Type type, IDataReader reader, int startBound = 0, int length = " +
                    "-1, bool returnNullIfFirstMissing = false\r\n        )\r\n        {\r\n            var" +
                    " returnType = type.IsValueType() ? typeof(object) : type;\r\n            var dm = " +
                    "new DynamicMethod(\"Deserialize\" + Guid.NewGuid().ToString(), returnType, new[] {" +
                    " typeof(IDataReader) }, type, true);\r\n            var il = dm.GetILGenerator();\r" +
                    "\n            il.DeclareLocal(typeof(int));\r\n            il.DeclareLocal(type);\r\n" +
                    "            il.Emit(OpCodes.Ldc_I4_0);\r\n            il.Emit(OpCodes.Stloc_0);\r\n\r" +
                    "\n            if (length == -1)\r\n            {\r\n                length = reader.F" +
                    "ieldCount - startBound;\r\n            }\r\n\r\n            if (reader.FieldCount <= s" +
                    "tartBound)\r\n            {\r\n                throw MultiMapException(reader);\r\n   " +
                    "         }\r\n\r\n            var names = Enumerable.Range(startBound, length).Selec" +
                    "t(i => reader.GetName(i)).ToArray();\r\n\r\n            ITypeMap typeMap = GetTypeMa" +
                    "p(type);\r\n\r\n            int index = startBound;\r\n\r\n            ConstructorInfo s" +
                    "pecializedConstructor = null;\r\n\r\n#if !COREFX\r\n            bool supportInitialize" +
                    " = false;\r\n#endif\r\n            Dictionary<Type, LocalBuilder> structLocals = nul" +
                    "l;\r\n            if (type.IsValueType())\r\n            {\r\n                il.Emit(" +
                    "OpCodes.Ldloca_S, (byte)1);\r\n                il.Emit(OpCodes.Initobj, type);\r\n  " +
                    "          }\r\n            else\r\n            {\r\n                var types = new Ty" +
                    "pe[length];\r\n                for (int i = startBound; i < startBound + length; i" +
                    "++)\r\n                {\r\n                    types[i - startBound] = reader.GetFi" +
                    "eldType(i);\r\n                }\r\n\r\n                var explicitConstr = typeMap.F" +
                    "indExplicitConstructor();\r\n                if (explicitConstr != null)\r\n        " +
                    "        {\r\n                    var consPs = explicitConstr.GetParameters();\r\n   " +
                    "                 foreach (var p in consPs)\r\n                    {\r\n             " +
                    "           if (!p.ParameterType.IsValueType())\r\n                        {\r\n     " +
                    "                       il.Emit(OpCodes.Ldnull);\r\n                        }\r\n    " +
                    "                    else\r\n                        {\r\n                           " +
                    " GetTempLocal(il, ref structLocals, p.ParameterType, true);\r\n                   " +
                    "     }\r\n                    }\r\n\r\n                    il.Emit(OpCodes.Newobj, exp" +
                    "licitConstr);\r\n                    il.Emit(OpCodes.Stloc_1);\r\n#if !COREFX\r\n     " +
                    "               supportInitialize = typeof(ISupportInitialize).IsAssignableFrom(t" +
                    "ype);\r\n                    if (supportInitialize)\r\n                    {\r\n      " +
                    "                  il.Emit(OpCodes.Ldloc_1);\r\n                        il.EmitCall" +
                    "(OpCodes.Callvirt, typeof(ISupportInitialize).GetMethod(nameof(ISupportInitializ" +
                    "e.BeginInit)), null);\r\n                    }\r\n#endif\r\n                }\r\n       " +
                    "         else\r\n                {\r\n                    var ctor = typeMap.FindCon" +
                    "structor(names, types);\r\n                    if (ctor == null)\r\n                " +
                    "    {\r\n                        string proposedTypes = \"(\" + string.Join(\", \", ty" +
                    "pes.Select((t, i) => t.FullName + \" \" + names[i]).ToArray()) + \")\";\r\n           " +
                    "             throw new InvalidOperationException($\"A parameterless default const" +
                    "ructor or one matching signature {proposedTypes} is required for {type.FullName}" +
                    " materialization\");\r\n                    }\r\n\r\n                    if (ctor.GetPa" +
                    "rameters().Length == 0)\r\n                    {\r\n                        il.Emit(" +
                    "OpCodes.Newobj, ctor);\r\n                        il.Emit(OpCodes.Stloc_1);\r\n#if !" +
                    "COREFX\r\n                        supportInitialize = typeof(ISupportInitialize).I" +
                    "sAssignableFrom(type);\r\n                        if (supportInitialize)\r\n        " +
                    "                {\r\n                            il.Emit(OpCodes.Ldloc_1);\r\n      " +
                    "                      il.EmitCall(OpCodes.Callvirt, typeof(ISupportInitialize).G" +
                    "etMethod(nameof(ISupportInitialize.BeginInit)), null);\r\n                        " +
                    "}\r\n#endif\r\n                    }\r\n                    else\r\n                    " +
                    "{\r\n                        specializedConstructor = ctor;\r\n                    }" +
                    "\r\n                }\r\n            }\r\n\r\n            il.BeginExceptionBlock();\r\n   " +
                    "         if (type.IsValueType())\r\n            {\r\n                il.Emit(OpCodes" +
                    ".Ldloca_S, (byte)1);// [target]\r\n            }\r\n            else if (specialized" +
                    "Constructor == null)\r\n            {\r\n                il.Emit(OpCodes.Ldloc_1);//" +
                    " [target]\r\n            }\r\n\r\n            var members = (specializedConstructor !=" +
                    " null\r\n                ? names.Select(n => typeMap.GetConstructorParameter(speci" +
                    "alizedConstructor, n))\r\n                : names.Select(n => typeMap.GetMember(n)" +
                    ")).ToList();\r\n\r\n            // stack is now [target]\r\n\r\n            bool first =" +
                    " true;\r\n            var allDone = il.DefineLabel();\r\n            int enumDeclare" +
                    "Local = -1, valueCopyLocal = il.DeclareLocal(typeof(object)).LocalIndex;\r\n      " +
                    "      bool applyNullSetting = Settings.ApplyNullValues;\r\n            foreach (va" +
                    "r item in members)\r\n            {\r\n                if (item != null)\r\n          " +
                    "      {\r\n                    if (specializedConstructor == null)\r\n              " +
                    "          il.Emit(OpCodes.Dup); // stack is now [target][target]\r\n              " +
                    "      Label isDbNullLabel = il.DefineLabel();\r\n                    Label finishL" +
                    "abel = il.DefineLabel();\r\n\r\n                    il.Emit(OpCodes.Ldarg_0); // sta" +
                    "ck is now [target][target][reader]\r\n                    EmitInt32(il, index); //" +
                    " stack is now [target][target][reader][index]\r\n                    il.Emit(OpCod" +
                    "es.Dup);// stack is now [target][target][reader][index][index]\r\n                " +
                    "    il.Emit(OpCodes.Stloc_0);// stack is now [target][target][reader][index]\r\n  " +
                    "                  il.Emit(OpCodes.Callvirt, getItem); // stack is now [target][t" +
                    "arget][value-as-object]\r\n                    il.Emit(OpCodes.Dup); // stack is n" +
                    "ow [target][target][value-as-object][value-as-object]\r\n                    Store" +
                    "Local(il, valueCopyLocal);\r\n                    Type colType = reader.GetFieldTy" +
                    "pe(index);\r\n                    Type memberType = item.MemberType;\r\n\r\n          " +
                    "          if (memberType == typeof(char) || memberType == typeof(char?))\r\n      " +
                    "              {\r\n                        il.EmitCall(OpCodes.Call, typeof(SqlMap" +
                    "per).GetMethod(\r\n                            memberType == typeof(char) ? nameof" +
                    "(SqlMapper.ReadChar) : nameof(SqlMapper.ReadNullableChar), BindingFlags.Static |" +
                    " BindingFlags.Public), null); // stack is now [target][target][typed-value]\r\n   " +
                    "                 }\r\n                    else\r\n                    {\r\n           " +
                    "             il.Emit(OpCodes.Dup); // stack is now [target][target][value][value" +
                    "]\r\n                        il.Emit(OpCodes.Isinst, typeof(DBNull)); // stack is " +
                    "now [target][target][value-as-object][DBNull or null]\r\n                        i" +
                    "l.Emit(OpCodes.Brtrue_S, isDbNullLabel); // stack is now [target][target][value-" +
                    "as-object]\r\n\r\n                        // unbox nullable enums as the primitive, " +
                    "i.e. byte etc\r\n\r\n                        var nullUnderlyingType = Nullable.GetUn" +
                    "derlyingType(memberType);\r\n                        var unboxType = nullUnderlyin" +
                    "gType != null && nullUnderlyingType.IsEnum() ? nullUnderlyingType : memberType;\r" +
                    "\n\r\n                        if (unboxType.IsEnum())\r\n                        {\r\n " +
                    "                           Type numericType = Enum.GetUnderlyingType(unboxType);" +
                    "\r\n                            if (colType == typeof(string))\r\n                  " +
                    "          {\r\n                                if (enumDeclareLocal == -1)\r\n      " +
                    "                          {\r\n                                    enumDeclareLoca" +
                    "l = il.DeclareLocal(typeof(string)).LocalIndex;\r\n                               " +
                    " }\r\n                                il.Emit(OpCodes.Castclass, typeof(string)); " +
                    "// stack is now [target][target][string]\r\n                                StoreL" +
                    "ocal(il, enumDeclareLocal); // stack is now [target][target]\r\n                  " +
                    "              il.Emit(OpCodes.Ldtoken, unboxType); // stack is now [target][targ" +
                    "et][enum-type-token]\r\n                                il.EmitCall(OpCodes.Call, " +
                    "typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle)), null);// stack is now [t" +
                    "arget][target][enum-type]\r\n                                LoadLocal(il, enumDec" +
                    "lareLocal); // stack is now [target][target][enum-type][string]\r\n               " +
                    "                 il.Emit(OpCodes.Ldc_I4_1); // stack is now [target][target][enu" +
                    "m-type][string][true]\r\n                                il.EmitCall(OpCodes.Call," +
                    " enumParse, null); // stack is now [target][target][enum-as-object]\r\n           " +
                    "                     il.Emit(OpCodes.Unbox_Any, unboxType); // stack is now [tar" +
                    "get][target][typed-value]\r\n                            }\r\n                      " +
                    "      else\r\n                            {\r\n                                Flexi" +
                    "bleConvertBoxedFromHeadOfStack(il, colType, unboxType, numericType);\r\n          " +
                    "                  }\r\n\r\n                            if (nullUnderlyingType != nul" +
                    "l)\r\n                            {\r\n                                il.Emit(OpCod" +
                    "es.Newobj, memberType.GetConstructor(new[] { nullUnderlyingType })); // stack is" +
                    " now [target][target][typed-value]\r\n                            }\r\n             " +
                    "           }\r\n                        else if (memberType.FullName == LinqBinary" +
                    ")\r\n                        {\r\n                            il.Emit(OpCodes.Unbox_" +
                    "Any, typeof(byte[])); // stack is now [target][target][byte-array]\r\n            " +
                    "                il.Emit(OpCodes.Newobj, memberType.GetConstructor(new Type[] { t" +
                    "ypeof(byte[]) }));// stack is now [target][target][binary]\r\n                    " +
                    "    }\r\n                        else\r\n                        {\r\n                " +
                    "            TypeCode dataTypeCode = TypeExtensions.GetTypeCode(colType), unboxTy" +
                    "peCode = TypeExtensions.GetTypeCode(unboxType);\r\n                            boo" +
                    "l hasTypeHandler;\r\n                            if ((hasTypeHandler = typeHandler" +
                    "s.ContainsKey(unboxType)) || colType == unboxType || dataTypeCode == unboxTypeCo" +
                    "de || dataTypeCode == TypeExtensions.GetTypeCode(nullUnderlyingType))\r\n         " +
                    "                   {\r\n                                if (hasTypeHandler)\r\n     " +
                    "                           {\r\n#pragma warning disable 618\r\n                     " +
                    "               il.EmitCall(OpCodes.Call, typeof(TypeHandlerCache<>).MakeGenericT" +
                    "ype(unboxType).GetMethod(nameof(TypeHandlerCache<int>.Parse)), null); // stack i" +
                    "s now [target][target][typed-value]\r\n#pragma warning restore 618\r\n              " +
                    "                  }\r\n                                else\r\n                     " +
                    "           {\r\n                                    il.Emit(OpCodes.Unbox_Any, unb" +
                    "oxType); // stack is now [target][target][typed-value]\r\n                        " +
                    "        }\r\n                            }\r\n                            else\r\n    " +
                    "                        {\r\n                                // not a direct match" +
                    "; need to tweak the unbox\r\n                                FlexibleConvertBoxedF" +
                    "romHeadOfStack(il, colType, nullUnderlyingType ?? unboxType, null);\r\n           " +
                    "                     if (nullUnderlyingType != null)\r\n                          " +
                    "      {\r\n                                    il.Emit(OpCodes.Newobj, unboxType.G" +
                    "etConstructor(new[] { nullUnderlyingType })); // stack is now [target][target][t" +
                    "yped-value]\r\n                                }\r\n                            }\r\n " +
                    "                       }\r\n                    }\r\n                    if (special" +
                    "izedConstructor == null)\r\n                    {\r\n                        // Stor" +
                    "e the value in the property/field\r\n                        if (item.Property != " +
                    "null)\r\n                        {\r\n                            il.Emit(type.IsVal" +
                    "ueType() ? OpCodes.Call : OpCodes.Callvirt, DefaultTypeMap.GetPropertySetter(ite" +
                    "m.Property, type));\r\n                        }\r\n                        else\r\n  " +
                    "                      {\r\n                            il.Emit(OpCodes.Stfld, item" +
                    ".Field); // stack is now [target]\r\n                        }\r\n                  " +
                    "  }\r\n\r\n                    il.Emit(OpCodes.Br_S, finishLabel); // stack is now [" +
                    "target]\r\n\r\n                    il.MarkLabel(isDbNullLabel); // incoming stack: [" +
                    "target][target][value]\r\n                    if (specializedConstructor != null)\r" +
                    "\n                    {\r\n                        il.Emit(OpCodes.Pop);\r\n         " +
                    "               if (item.MemberType.IsValueType())\r\n                        {\r\n  " +
                    "                          int localIndex = il.DeclareLocal(item.MemberType).Loca" +
                    "lIndex;\r\n                            LoadLocalAddress(il, localIndex);\r\n        " +
                    "                    il.Emit(OpCodes.Initobj, item.MemberType);\r\n                " +
                    "            LoadLocal(il, localIndex);\r\n                        }\r\n             " +
                    "           else\r\n                        {\r\n                            il.Emit(" +
                    "OpCodes.Ldnull);\r\n                        }\r\n                    }\r\n            " +
                    "        else if (applyNullSetting && (!memberType.IsValueType() || Nullable.GetU" +
                    "nderlyingType(memberType) != null))\r\n                    {\r\n                    " +
                    "    il.Emit(OpCodes.Pop); // stack is now [target][target]\r\n                    " +
                    "    // can load a null with this value\r\n                        if (memberType.I" +
                    "sValueType())\r\n                        { // must be Nullable<T> for some T\r\n    " +
                    "                        GetTempLocal(il, ref structLocals, memberType, true); //" +
                    " stack is now [target][target][null]\r\n                        }\r\n               " +
                    "         else\r\n                        { // regular reference-type\r\n            " +
                    "                il.Emit(OpCodes.Ldnull); // stack is now [target][target][null]\r" +
                    "\n                        }\r\n\r\n                        // Store the value in the " +
                    "property/field\r\n                        if (item.Property != null)\r\n            " +
                    "            {\r\n                            il.Emit(type.IsValueType() ? OpCodes." +
                    "Call : OpCodes.Callvirt, DefaultTypeMap.GetPropertySetter(item.Property, type));" +
                    "\r\n                            // stack is now [target]\r\n                        " +
                    "}\r\n                        else\r\n                        {\r\n                    " +
                    "        il.Emit(OpCodes.Stfld, item.Field); // stack is now [target]\r\n          " +
                    "              }\r\n                    }\r\n                    else\r\n              " +
                    "      {\r\n                        il.Emit(OpCodes.Pop); // stack is now [target][" +
                    "target]\r\n                        il.Emit(OpCodes.Pop); // stack is now [target]\r" +
                    "\n                    }\r\n\r\n                    if (first && returnNullIfFirstMiss" +
                    "ing)\r\n                    {\r\n                        il.Emit(OpCodes.Pop);\r\n    " +
                    "                    il.Emit(OpCodes.Ldnull); // stack is now [null]\r\n           " +
                    "             il.Emit(OpCodes.Stloc_1);\r\n                        il.Emit(OpCodes." +
                    "Br, allDone);\r\n                    }\r\n\r\n                    il.MarkLabel(finishL" +
                    "abel);\r\n                }\r\n                first = false;\r\n                index" +
                    " += 1;\r\n            }\r\n            if (type.IsValueType())\r\n            {\r\n     " +
                    "           il.Emit(OpCodes.Pop);\r\n            }\r\n            else\r\n            {" +
                    "\r\n                if (specializedConstructor != null)\r\n                {\r\n      " +
                    "              il.Emit(OpCodes.Newobj, specializedConstructor);\r\n                " +
                    "}\r\n                il.Emit(OpCodes.Stloc_1); // stack is empty\r\n#if !COREFX\r\n   " +
                    "             if (supportInitialize)\r\n                {\r\n                    il.E" +
                    "mit(OpCodes.Ldloc_1);\r\n                    il.EmitCall(OpCodes.Callvirt, typeof(" +
                    "ISupportInitialize).GetMethod(nameof(ISupportInitialize.EndInit)), null);\r\n     " +
                    "           }\r\n#endif\r\n            }\r\n            il.MarkLabel(allDone);\r\n       " +
                    "     il.BeginCatchBlock(typeof(Exception)); // stack is Exception\r\n            i" +
                    "l.Emit(OpCodes.Ldloc_0); // stack is Exception, index\r\n            il.Emit(OpCod" +
                    "es.Ldarg_0); // stack is Exception, index, reader\r\n            LoadLocal(il, val" +
                    "ueCopyLocal); // stack is Exception, index, reader, value\r\n            il.EmitCa" +
                    "ll(OpCodes.Call, typeof(SqlMapper).GetMethod(nameof(SqlMapper.ThrowDataException" +
                    ")), null);\r\n            il.EndExceptionBlock();\r\n\r\n            il.Emit(OpCodes.L" +
                    "dloc_1); // stack is [rval]\r\n            if (type.IsValueType())\r\n            {\r" +
                    "\n                il.Emit(OpCodes.Box, type);\r\n            }\r\n            il.Emit" +
                    "(OpCodes.Ret);\r\n\r\n            var funcType = System.Linq.Expressions.Expression." +
                    "GetFuncType(typeof(IDataReader), returnType);\r\n            return (Func<IDataRea" +
                    "der, object>)dm.CreateDelegate(funcType);\r\n        }\r\n\r\n        private static v" +
                    "oid FlexibleConvertBoxedFromHeadOfStack(ILGenerator il, Type from, Type to, Type" +
                    " via)\r\n        {\r\n            MethodInfo op;\r\n            if (from == (via ?? to" +
                    "))\r\n            {\r\n                il.Emit(OpCodes.Unbox_Any, to); // stack is n" +
                    "ow [target][target][typed-value]\r\n            }\r\n            else if ((op = GetO" +
                    "perator(from, to)) != null)\r\n            {\r\n                // this is handy for" +
                    " things like decimal <===> double\r\n                il.Emit(OpCodes.Unbox_Any, fr" +
                    "om); // stack is now [target][target][data-typed-value]\r\n                il.Emit" +
                    "(OpCodes.Call, op); // stack is now [target][target][typed-value]\r\n            }" +
                    "\r\n            else\r\n            {\r\n                bool handled = false;\r\n      " +
                    "          OpCode opCode = default(OpCode);\r\n                switch (TypeExtensio" +
                    "ns.GetTypeCode(from))\r\n                {\r\n                    case TypeCode.Bool" +
                    "ean:\r\n                    case TypeCode.Byte:\r\n                    case TypeCode" +
                    ".SByte:\r\n                    case TypeCode.Int16:\r\n                    case Type" +
                    "Code.UInt16:\r\n                    case TypeCode.Int32:\r\n                    case" +
                    " TypeCode.UInt32:\r\n                    case TypeCode.Int64:\r\n                   " +
                    " case TypeCode.UInt64:\r\n                    case TypeCode.Single:\r\n             " +
                    "       case TypeCode.Double:\r\n                        handled = true;\r\n         " +
                    "               switch (TypeExtensions.GetTypeCode(via ?? to))\r\n                 " +
                    "       {\r\n                            case TypeCode.Byte:\r\n                     " +
                    "           opCode = OpCodes.Conv_Ovf_I1_Un; break;\r\n                            " +
                    "case TypeCode.SByte:\r\n                                opCode = OpCodes.Conv_Ovf_" +
                    "I1; break;\r\n                            case TypeCode.UInt16:\r\n                 " +
                    "               opCode = OpCodes.Conv_Ovf_I2_Un; break;\r\n                        " +
                    "    case TypeCode.Int16:\r\n                                opCode = OpCodes.Conv_" +
                    "Ovf_I2; break;\r\n                            case TypeCode.UInt32:\r\n             " +
                    "                   opCode = OpCodes.Conv_Ovf_I4_Un; break;\r\n                    " +
                    "        case TypeCode.Boolean: // boolean is basically an int, at least at this " +
                    "level\r\n                            case TypeCode.Int32:\r\n                       " +
                    "         opCode = OpCodes.Conv_Ovf_I4; break;\r\n                            case " +
                    "TypeCode.UInt64:\r\n                                opCode = OpCodes.Conv_Ovf_I8_U" +
                    "n; break;\r\n                            case TypeCode.Int64:\r\n                   " +
                    "             opCode = OpCodes.Conv_Ovf_I8; break;\r\n                            c" +
                    "ase TypeCode.Single:\r\n                                opCode = OpCodes.Conv_R4; " +
                    "break;\r\n                            case TypeCode.Double:\r\n                     " +
                    "           opCode = OpCodes.Conv_R8; break;\r\n                            default" +
                    ":\r\n                                handled = false;\r\n                           " +
                    "     break;\r\n                        }\r\n                        break;\r\n        " +
                    "        }\r\n                if (handled)\r\n                {\r\n                    " +
                    "il.Emit(OpCodes.Unbox_Any, from); // stack is now [target][target][col-typed-val" +
                    "ue]\r\n                    il.Emit(opCode); // stack is now [target][target][typed" +
                    "-value]\r\n                    if (to == typeof(bool))\r\n                    { // c" +
                    "ompare to zero; I checked \"csc\" - this is the trick it uses; nice\r\n             " +
                    "           il.Emit(OpCodes.Ldc_I4_0);\r\n                        il.Emit(OpCodes.C" +
                    "eq);\r\n                        il.Emit(OpCodes.Ldc_I4_0);\r\n                      " +
                    "  il.Emit(OpCodes.Ceq);\r\n                    }\r\n                }\r\n             " +
                    "   else\r\n                {\r\n                    il.Emit(OpCodes.Ldtoken, via ?? " +
                    "to); // stack is now [target][target][value][member-type-token]\r\n               " +
                    "     il.EmitCall(OpCodes.Call, typeof(Type).GetMethod(nameof(Type.GetTypeFromHan" +
                    "dle)), null); // stack is now [target][target][value][member-type]\r\n            " +
                    "        il.EmitCall(OpCodes.Call, typeof(Convert).GetMethod(nameof(Convert.Chang" +
                    "eType), new Type[] { typeof(object), typeof(Type) }), null); // stack is now [ta" +
                    "rget][target][boxed-member-type-value]\r\n                    il.Emit(OpCodes.Unbo" +
                    "x_Any, to); // stack is now [target][target][typed-value]\r\n                }\r\n  " +
                    "          }\r\n        }\r\n\r\n        static MethodInfo GetOperator(Type from, Type " +
                    "to)\r\n        {\r\n            if (to == null) return null;\r\n            MethodInfo" +
                    "[] fromMethods, toMethods;\r\n            return ResolveOperator(fromMethods = fro" +
                    "m.GetMethods(BindingFlags.Static | BindingFlags.Public), from, to, \"op_Implicit\"" +
                    ")\r\n                ?? ResolveOperator(toMethods = to.GetMethods(BindingFlags.Sta" +
                    "tic | BindingFlags.Public), from, to, \"op_Implicit\")\r\n                ?? Resolve" +
                    "Operator(fromMethods, from, to, \"op_Explicit\")\r\n                ?? ResolveOperat" +
                    "or(toMethods, from, to, \"op_Explicit\");\r\n        }\r\n\r\n        static MethodInfo " +
                    "ResolveOperator(MethodInfo[] methods, Type from, Type to, string name)\r\n        " +
                    "{\r\n            for (int i = 0; i < methods.Length; i++)\r\n            {\r\n        " +
                    "        if (methods[i].Name != name || methods[i].ReturnType != to) continue;\r\n " +
                    "               var args = methods[i].GetParameters();\r\n                if (args." +
                    "Length != 1 || args[0].ParameterType != from) continue;\r\n                return " +
                    "methods[i];\r\n            }\r\n            return null;\r\n        }\r\n\r\n        priva" +
                    "te static void LoadLocal(ILGenerator il, int index)\r\n        {\r\n            if (" +
                    "index < 0 || index >= short.MaxValue) throw new ArgumentNullException(nameof(ind" +
                    "ex));\r\n            switch (index)\r\n            {\r\n                case 0: il.Emi" +
                    "t(OpCodes.Ldloc_0); break;\r\n                case 1: il.Emit(OpCodes.Ldloc_1); br" +
                    "eak;\r\n                case 2: il.Emit(OpCodes.Ldloc_2); break;\r\n                " +
                    "case 3: il.Emit(OpCodes.Ldloc_3); break;\r\n                default:\r\n            " +
                    "        if (index <= 255)\r\n                    {\r\n                        il.Emi" +
                    "t(OpCodes.Ldloc_S, (byte)index);\r\n                    }\r\n                    els" +
                    "e\r\n                    {\r\n                        il.Emit(OpCodes.Ldloc, (short)" +
                    "index);\r\n                    }\r\n                    break;\r\n            }\r\n     " +
                    "   }\r\n        private static void StoreLocal(ILGenerator il, int index)\r\n       " +
                    " {\r\n            if (index < 0 || index >= short.MaxValue) throw new ArgumentNull" +
                    "Exception(nameof(index));\r\n            switch (index)\r\n            {\r\n          " +
                    "      case 0: il.Emit(OpCodes.Stloc_0); break;\r\n                case 1: il.Emit(" +
                    "OpCodes.Stloc_1); break;\r\n                case 2: il.Emit(OpCodes.Stloc_2); brea" +
                    "k;\r\n                case 3: il.Emit(OpCodes.Stloc_3); break;\r\n                de" +
                    "fault:\r\n                    if (index <= 255)\r\n                    {\r\n          " +
                    "              il.Emit(OpCodes.Stloc_S, (byte)index);\r\n                    }\r\n   " +
                    "                 else\r\n                    {\r\n                        il.Emit(Op" +
                    "Codes.Stloc, (short)index);\r\n                    }\r\n                    break;\r\n" +
                    "            }\r\n        }\r\n\r\n        private static void LoadLocalAddress(ILGener" +
                    "ator il, int index)\r\n        {\r\n            if (index < 0 || index >= short.MaxV" +
                    "alue) throw new ArgumentNullException(nameof(index));\r\n\r\n            if (index <" +
                    "= 255)\r\n            {\r\n                il.Emit(OpCodes.Ldloca_S, (byte)index);\r\n" +
                    "            }\r\n            else\r\n            {\r\n                il.Emit(OpCodes." +
                    "Ldloca, (short)index);\r\n            }\r\n        }\r\n\r\n        /// <summary>\r\n     " +
                    "   /// Throws a data exception, only used internally\r\n        /// </summary>\r\n  " +
                    "      [Obsolete(ObsoleteInternalUsageOnly, false)]\r\n        public static void T" +
                    "hrowDataException(Exception ex, int index, IDataReader reader, object value)\r\n  " +
                    "      {\r\n            Exception toThrow;\r\n            try\r\n            {\r\n       " +
                    "         string name = \"(n/a)\", formattedValue = \"(n/a)\";\r\n                if (r" +
                    "eader != null && index >= 0 && index < reader.FieldCount)\r\n                {\r\n  " +
                    "                  name = reader.GetName(index);\r\n                    try\r\n      " +
                    "              {\r\n                        if (value == null || value is DBNull)\r\n" +
                    "                        {\r\n                            formattedValue = \"<null>\"" +
                    ";\r\n                        }\r\n                        else\r\n                    " +
                    "    {\r\n                            formattedValue = Convert.ToString(value) + \" " +
                    "- \" + TypeExtensions.GetTypeCode(value.GetType());\r\n                        }\r\n " +
                    "                   }\r\n                    catch (Exception valEx)\r\n             " +
                    "       {\r\n                        formattedValue = valEx.Message;\r\n             " +
                    "       }\r\n                }\r\n                toThrow = new DataException($\"Error" +
                    " parsing column {index} ({name}={formattedValue})\", ex);\r\n            }\r\n       " +
                    "     catch\r\n            { // throw the **original** exception, wrapped as DataEx" +
                    "ception\r\n                toThrow = new DataException(ex.Message, ex);\r\n         " +
                    "   }\r\n            throw toThrow;\r\n        }\r\n\r\n        private static void EmitI" +
                    "nt32(ILGenerator il, int value)\r\n        {\r\n            switch (value)\r\n        " +
                    "    {\r\n                case -1: il.Emit(OpCodes.Ldc_I4_M1); break;\r\n            " +
                    "    case 0: il.Emit(OpCodes.Ldc_I4_0); break;\r\n                case 1: il.Emit(O" +
                    "pCodes.Ldc_I4_1); break;\r\n                case 2: il.Emit(OpCodes.Ldc_I4_2); bre" +
                    "ak;\r\n                case 3: il.Emit(OpCodes.Ldc_I4_3); break;\r\n                " +
                    "case 4: il.Emit(OpCodes.Ldc_I4_4); break;\r\n                case 5: il.Emit(OpCod" +
                    "es.Ldc_I4_5); break;\r\n                case 6: il.Emit(OpCodes.Ldc_I4_6); break;\r" +
                    "\n                case 7: il.Emit(OpCodes.Ldc_I4_7); break;\r\n                case" +
                    " 8: il.Emit(OpCodes.Ldc_I4_8); break;\r\n                default:\r\n               " +
                    "     if (value >= -128 && value <= 127)\r\n                    {\r\n                " +
                    "        il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);\r\n                    }\r\n       " +
                    "             else\r\n                    {\r\n                        il.Emit(OpCode" +
                    "s.Ldc_I4, value);\r\n                    }\r\n                    break;\r\n          " +
                    "  }\r\n        }\r\n\r\n        /// <summary>\r\n        /// How should connection strin" +
                    "gs be compared for equivalence? Defaults to StringComparer.Ordinal.\r\n        ///" +
                    " Providing a custom implementation can be useful for allowing multi-tenancy data" +
                    "bases with identical\r\n        /// schema to share strategies. Note that usual eq" +
                    "uivalence rules apply: any equivalent connection strings\r\n        /// <b>MUST</b" +
                    "> yield the same hash-code.\r\n        /// </summary>\r\n        public static IEqua" +
                    "lityComparer<string> ConnectionStringComparer\r\n        {\r\n            get { retu" +
                    "rn connectionStringComparer; }\r\n            set { connectionStringComparer = val" +
                    "ue ?? StringComparer.Ordinal; }\r\n        }\r\n        private static IEqualityComp" +
                    "arer<string> connectionStringComparer = StringComparer.Ordinal;\r\n\r\n#if !COREFX\r\n" +
                    "        /// <summary>\r\n        /// Key used to indicate the type name associated" +
                    " with a DataTable\r\n        /// </summary>\r\n        private const string DataTabl" +
                    "eTypeNameKey = \"dapper:TypeName\";\r\n\r\n        /// <summary>\r\n        /// Used to " +
                    "pass a DataTable as a TableValuedParameter\r\n        /// </summary>\r\n        publ" +
                    "ic static ICustomQueryParameter AsTableValuedParameter(this DataTable table, str" +
                    "ing typeName = null)\r\n        {\r\n            return new TableValuedParameter(tab" +
                    "le, typeName);\r\n        }\r\n\r\n        /// <summary>\r\n        /// Associate a Data" +
                    "Table with a type name\r\n        /// </summary>\r\n        public static void SetTy" +
                    "peName(this DataTable table, string typeName)\r\n        {\r\n            if (table " +
                    "!= null)\r\n            {\r\n                if (string.IsNullOrEmpty(typeName))\r\n  " +
                    "                  table.ExtendedProperties.Remove(DataTableTypeNameKey);\r\n      " +
                    "          else\r\n                    table.ExtendedProperties[DataTableTypeNameKe" +
                    "y] = typeName;\r\n            }\r\n        }\r\n\r\n        /// <summary>\r\n        /// F" +
                    "etch the type name associated with a DataTable\r\n        /// </summary>\r\n        " +
                    "public static string GetTypeName(this DataTable table)\r\n        {\r\n            r" +
                    "eturn table?.ExtendedProperties[DataTableTypeNameKey] as string;\r\n        }\r\n\r\n " +
                    "       /// <summary>\r\n        /// Used to pass a IEnumerable&lt;SqlDataRecord&gt" +
                    "; as a TableValuedParameter\r\n        /// </summary>\r\n        public static ICust" +
                    "omQueryParameter AsTableValuedParameter(this IEnumerable<Microsoft.SqlServer.Ser" +
                    "ver.SqlDataRecord> list, string typeName = null)\r\n        {\r\n            return " +
                    "new SqlDataRecordListTVPParameter(list, typeName);\r\n        }\r\n\r\n#endif\r\n\r\n     " +
                    "   // one per thread\r\n        [ThreadStatic]\r\n        private static StringBuild" +
                    "er perThreadStringBuilderCache;\r\n        private static StringBuilder GetStringB" +
                    "uilder()\r\n        {\r\n            var tmp = perThreadStringBuilderCache;\r\n       " +
                    "     if (tmp != null)\r\n            {\r\n                perThreadStringBuilderCach" +
                    "e = null;\r\n                tmp.Length = 0;\r\n                return tmp;\r\n       " +
                    "     }\r\n            return new StringBuilder();\r\n        }\r\n\r\n        private st" +
                    "atic string __ToStringRecycle(this StringBuilder obj)\r\n        {\r\n            if" +
                    " (obj == null) return \"\";\r\n            var s = obj.ToString();\r\n            if (" +
                    "perThreadStringBuilderCache == null)\r\n            {\r\n                perThreadSt" +
                    "ringBuilderCache = obj;\r\n            }\r\n            return s;\r\n        }\r\n    }\r" +
                    "\n}");
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
    public class SqlMapperBase
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
