using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Choe
{
    public class FileUtility
    {

        private static string m_DestFolderpath;
        private static string m_SourceFolderpath;
        private static string m_FileType;


        public static void FileMovesAlltoFolder()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();
            UnityEngine.Debug.Log("File Move Start !! ");

            FileInfo[] fileinfoArray = GetFileinfos();

            for (int i = 0; i < fileinfoArray.Length; i++)
            {
                FileMove(fileinfoArray[i]);
            }

            sw.Stop();
            UnityEngine.Debug.Log("Finish File Move !! : " + sw.Elapsed.ToString());
        }

        public static void FileUtilityInit(string folderpath, string destpath, string filetype)
        {
            UnityEngine.Debug.Log("Path : " + folderpath + ", " + destpath+ ", "+ filetype);
            m_SourceFolderpath = folderpath; 
            m_DestFolderpath = destpath;
             m_FileType = filetype;
        }

        private static void FileMove(FileInfo info)
        {
            string filename = info.Name;

            string movepath = Path.Combine(m_DestFolderpath, filename);
            //UnityEngine.Debug.Log("movepath : " + movepath);
            //UnityEngine.Debug.Log("FullName : " + info.FullName);
            File.Move(info.FullName, movepath);
        }

        private static bool CheckFiletypeEqual(string type)
        {
            bool result = false;

            if (m_FileType.Equals(type))
            {
                result = true;
            }
            return result;
        }

        private static FileInfo[] GetFileinfos()
        {
            DirectoryInfo folderinfo = new DirectoryInfo(m_SourceFolderpath);

            List<FileInfo> resultlist = new List<FileInfo>();

            FileInfo[] infos = folderinfo.GetFiles();
            for (int i = 0; i < infos.Length; i++)
            {
                string name = infos[i].Name;
                
                string filetype = GetFileTypetoFilename(name);

                if (CheckFiletypeEqual(filetype))
                {
                    resultlist.Add(infos[i]);
                }
            }
            return resultlist.ToArray();
        }

        private static string GetFileTypetoFilename(string name)
        {
            string[] splitname = name.Split('.');
            int lastindex = splitname.Length - 1;
            return splitname[lastindex];
        }
    }

}

