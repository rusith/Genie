#region Usings

using System.Text;
using Genie.Core.Templates.Abstract;

#endregion

namespace Genie.Core.Templates
{
    public abstract class GenieTemplate : ITemplate
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        protected GenieTemplate(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public abstract string Generate();
        
        public bool External { get; set; } = false;

        protected void R(string str)
        {
            _stringBuilder.Append(str);
        }

        protected void L(string str)
        {
            _stringBuilder.AppendLine(str);
        }

        protected string E()
        {
            return _stringBuilder.ToString();
        }
    }
}