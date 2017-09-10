using Genie.Base.Generating.Concrete;
using Genie.Templates;

namespace Genie.Templates.Dapper
{
    internal class SqlMapper_TypeHandlerTemplate: GenieTemplate
    {
        public SqlMapper_TypeHandlerTemplate(string path) : base(path){}

public override string Generate()
{
L($@"

using System;
using System.Data;

namespace {GenerationContext.BaseNamespace}.Dapper
{{
    partial class SqlMapper
    {{
        /// <summary>
        /// Base-class for simple type-handlers
        /// </summary>
        public abstract class TypeHandler<T> : ITypeHandler
        {{
            /// <summary>
            /// Assign the value of a parameter before a command executes
            /// </summary>
            /// <param name=""parameter"">The parameter to configure</param>
            /// <param name=""value"">Parameter value</param>
            public abstract void SetValue(IDbDataParameter parameter, T value);
 
            /// <summary>
            /// Parse a database value back to a typed value
            /// </summary>
            /// <param name=""value"">The value from the database</param>
            /// <returns>The typed value</returns>
            public abstract T Parse(object value);

            void ITypeHandler.SetValue(IDbDataParameter parameter, object value)
            {{
                if (value is DBNull)
                {{
                    parameter.Value = value;
                }}
                else
                {{
                    SetValue(parameter, (T)value);
                }}
            }}

            object ITypeHandler.Parse(Type destinationType, object value)
            {{
                return Parse(value);
            }}
        }}
        /// <summary>
        /// Base-class for simple type-handlers that are based around strings
        /// </summary>
        public abstract class StringTypeHandler<T> : TypeHandler<T>
        {{
            /// <summary>
            /// Parse a string into the expected type (the string will never be null)
            /// </summary>
            protected abstract T Parse(string xml);
            /// <summary>
            /// Format an instace into a string (the instance will never be null)
            /// </summary>
            protected abstract string Format(T xml);
            /// <summary>
            /// Assign the value of a parameter before a command executes
            /// </summary>
            /// <param name=""parameter"">The parameter to configure</param>
            /// <param name=""value"">Parameter value</param>
            public override void SetValue(IDbDataParameter parameter, T value)
            {{
                parameter.Value = value == null ? (object)DBNull.Value : Format(value);
            }}
            /// <summary>
            /// Parse a database value back to a typed value
            /// </summary>
            /// <param name=""value"">The value from the database</param>
            /// <returns>The typed value</returns>
            public override T Parse(object value)
            {{
                if (value == null || value is DBNull) return default(T);
                return Parse((string)value);
            }}
        }}
    }}
}}

");

return E();
    
}
    }
}