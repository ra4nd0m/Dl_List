using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dl_List
{
    internal class DownloadObj
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private double inputSize;
        public string Size
        {
            get
            {
                string res = "";
                double buf;
                switch (ShownSize)
                {
                    case "Bytes":
                        res = inputSize + " B";
                    break;
                    case "KB":
                        res = Math.Round(inputSize/1024) + " KB";
                        break;
                    case "MB":
                        buf = inputSize/1024;
                        if (buf > 1024)
                            res = Math.Round(buf / 1024, 2) + " MB";
                        else
                            res = Math.Round(buf, 2) + " KB";
                        break;
                    case "GB":
                        buf = inputSize / 1024;
                        if (buf > 1024)
                        {
                            buf /= 1024;
                            switch (buf)
                            {
                                case > 1024:
                                    buf = Math.Round(buf / 1024, 2);
                                    res = buf + " GB";
                                    break;
                                default:
                                    buf = Math.Round(buf, 0);
                                    res = buf + " MB";
                                    break;
                            }
                        }
                        else
                        {
                            buf = Math.Round(buf, 3);
                            res = buf + " KB";
                        }
                                                      
                        
                        break;
                }
                return res;
            }
            set { inputSize = double.Parse(value); }
        }
        public string? Path { get; set; }
        public bool IsFile { get; set; }
        public string? FullPath { get; set; }
        public string? RootPath { get; set; }
        public static string ShownSize { get; set; } = "KB";
        public DownloadObj(string name, long size, string? path, string type, bool isFile,string? rootPath)
        {
            Name = name;
            Path = path;
            FullPath = path + "\\" + name;
            Type = type;
            IsFile = isFile;
            inputSize = size;
            RootPath = rootPath;
        }
    }
}
