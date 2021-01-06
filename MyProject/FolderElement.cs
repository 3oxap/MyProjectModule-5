using System.Configuration;

namespace MyProject
{
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("folderType", IsKey =true)]
        public string FolderType
        {
            get { return (string)base["folderType"]; }
            set { base["folderType"] = value; }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }

        [ConfigurationProperty("counter")]
        public int counter
        {
            get { return (int)base["counter"]; }
            set { base["counter"] =value; }
        }
    }
}