using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using Messeg = MyProject.Resours.Resource;
using System.Text.RegularExpressions;

namespace MyProject
{
    class Program : ConfigurationSection
    {
        public static StartupFoldersConfigSection s;
        public static Configuration cfg;
        static void Main(string[] args)
        {
            List<string> Language = new List<string> { "ru", "en" };

            cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            s = (StartupFoldersConfigSection)
                 cfg.GetSection("StartupFolders");

           

            Console.WriteLine("Ru(0) or En(1) ");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(s.FolderItems[0].Path = Language[Convert.ToInt32(Console.ReadLine())]);

            Console.WriteLine(Messeg.Hello);

            using (FileSystemWatcher watcher = new FileSystemWatcher(Directory.GetCurrentDirectory()))
            {
                watcher.NotifyFilter = NotifyFilters.FileName;

                watcher.Created += OnChanged;



                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press end");
                while (Console.ReadLine() != "end") ;

            }
        }
        private static void OnChanged(object sourse, FileSystemEventArgs e)
        {
            var file = new FileInfo(Directory.GetCurrentDirectory() + @"\" + e.Name);
            for (int i = 2; i < 4; i++)
            {
                if (Regex.IsMatch(e.Name, s.FolderItems[i].FolderType)&& File.Exists(Directory.GetCurrentDirectory() + @"\" + e.Name))
                {
                    Console.WriteLine(Messeg.Path + s.FolderItems[i].Path +" "+ s.FolderItems[i].counter +"_"+ e.Name+"| TIME: " + DateTime.Now.ToString(Messeg.Date));

                    if (File.Exists(Directory.GetCurrentDirectory() + s.FolderItems[i].Path + @"\" + e.Name))
                    {
                        file.MoveTo(Directory.GetCurrentDirectory() + s.FolderItems[i].Path + @"\" + s.FolderItems[i].counter + "_" + e.Name);
                        s.FolderItems[i].counter++;
                    }
                    else
                    {
                        file.MoveTo(Directory.GetCurrentDirectory() + s.FolderItems[i].Path + @"\" + e.Name);
                    }
                }
            }
            cfg.Save();
            ConfigurationManager.RefreshSection("StartupFolders");
        }
          
    }
}
