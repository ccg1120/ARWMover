using System.IO ;


namespace Choe
{

    public class FolderUtility
    {

        private static string m_DestFolderPath;
        public static void FolderUtilityInit(string folderPath)
        {
            m_DestFolderPath = folderPath;
        }

        public static bool CreateFolder()
        {
            bool result = false;
            
            DirectoryInfo info = new DirectoryInfo(m_DestFolderPath);

            if (!info.Exists)
            {
                info.Create();
                UnityEngine.Debug.Log("Create Folder : " + m_DestFolderPath);
                result = true;
            }
            return result;
        }
    }
}