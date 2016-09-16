// Copyright (c) 2016 Lukasz Jaskiewicz. All Rights Reserved
// Licenced under the European Union Public Licence 1.1 (EUPL v.1.1)
// See licence.txt in the project root for licence information
// Written by Lukasz Jaskiewicz (lukasz@jaskiewicz.de)

namespace Net.DevDone.Web.Common
{
    using System.IO;

    using NodeAttrs = System.Collections.Generic.Dictionary<string, string>;
    using NodeChilds = System.Collections.Generic.List<HTMLNode>;

    /// <summary>
    /// Helper class for generating HTML code.
    /// </summary>
    public class HTMLNode
    {
        private string Tag;
        private string Val;
        private NodeAttrs Attrs;
        private NodeChilds Childs;

        private HTMLNode()
        {
        }

        public HTMLNode(string tag)
        {
            Childs = new NodeChilds();
            Attrs = new NodeAttrs();
            Tag = tag;
        }

        public HTMLNode(string tag, string val)
        {
            Childs = new NodeChilds();
            Attrs = new NodeAttrs();
            Tag = tag;
            Val = val;
        }

        public HTMLNode(string tag, string val, NodeAttrs attrs)
        {
            Childs = new NodeChilds();
            Attrs = new NodeAttrs();
            Tag = tag;
            Val = val;
            Attrs = attrs;
        }

        public void SetVal(string val)
        {
            Val = val;
        }

        public void SetTag(string tag)
        {
            Tag = tag;
        }

        public HTMLNode NewChild(string tag)
        {
            HTMLNode child = new HTMLNode(tag);
            Childs.Add(child); return child;
        }

        public HTMLNode NewChild(string tag, string val)
        {
            HTMLNode child = new HTMLNode(tag, val);
            Childs.Add(child);
            return child;
        }

        public HTMLNode NewChild(string tag, string val, NodeAttrs attrs)
        {
            HTMLNode child = new HTMLNode(tag, val, attrs);
            Childs.Add(child);
            return child;
        }

        public void GetHTML(StringWriter strWriter)
        {
            if (Childs.Count == 0
                && string.IsNullOrEmpty(Val))
            {
                strWriter.Write("<" + Tag + AddAttrs() + " />");
            }
            else
            {
                strWriter.Write("<" + Tag + AddAttrs() + ">");

                if (string.IsNullOrEmpty(Val))
                {
                    GetChildHTML(strWriter);
                }
                else
                {
                    strWriter.Write(Val);
                }

                strWriter.Write("</" + Tag + ">");
            }
        }

        private string AddAttrs()
        {
            StringWriter attrs = new StringWriter();

            foreach (var attr in Attrs)
            {
                attrs.Write(" " + attr.Key + "=\"" + attr.Value + "\"");
            }

            return attrs.ToString();
        }

        public void GetChildHTML(StringWriter strWriter)
        {
            foreach (var item in Childs)
            {
                item.GetHTML(strWriter);
            }
        }
    }
}