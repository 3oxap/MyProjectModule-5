using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MyProject
{
    public class StartupFoldersConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("appName")]
        public string ApplicationName
        {
            get { return (string)base["appName"]; }
        }

        [ConfigurationProperty("Folders")]
        public FoldersCollection FolderItems
        {
            get { return (FoldersCollection)base["Folders"]; }
        }
    }
}
