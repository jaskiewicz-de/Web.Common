namespace Net.DevDone.Web.Common
{
    using System.Collections.Generic;
    using System.IO;

    public interface IHTMLNode
    {
        void GetChildHTML(StringWriter strWriter);
        void GetHTML(StringWriter strWriter);
        HTMLNode NewChild(string tag);
        HTMLNode NewChild(string tag, string val);
        HTMLNode NewChild(string tag, string val, Dictionary<string, string> attrs);
        void SetTag(string tag);
        void SetVal(string val);
    }
}