using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.DesignPatterns.Creational.Builder
{
    public class Builder
    {
        public void Driver()
        {
            TestBuilder();
        }

        public void TestBuilder()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            WriteLine(builder.ToString());
        }
    }

    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var element in Elements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }
}
