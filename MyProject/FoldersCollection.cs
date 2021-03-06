﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MyProject
{
    [ConfigurationCollection(typeof(FolderElement))]
    public class FoldersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FolderElement)element).FolderType;
        }

        public FolderElement this[int idx]
        {
            get {return (FolderElement)BaseGet(idx); }
        }

      
    }
}
