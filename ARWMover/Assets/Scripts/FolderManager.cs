using System.Collections;
using System.IO;
using UnityEngine;

namespace Choe
{
    public class FolderManager : MonoBehaviour
    {
        [SerializeField]
        private string m_DestFolderName;

        [SerializeField]
        private string m_SourceFolderPath;
        [SerializeField]
        private string m_DestFolderPath;
        [SerializeField]
        private string m_FileType;


        private void Start()
        {
            FolderManagerInit();
            CreateAction();
        }
        public void FolderManagerInit()
        {
            m_DestFolderPath = Path.Combine(m_SourceFolderPath, m_DestFolderName);
            FolderUtility.FolderUtilityInit(m_DestFolderPath);
            FileUtility.FileUtilityInit(m_SourceFolderPath, m_DestFolderPath, m_FileType);

        }

        public void CreateAction()
        {
            if (FolderUtility.CreateFolder())
            {
                //TODO : 파일을 바로 옮긴다.
                Debug.Log("Create!! ");
                FileUtility.FileMovesAlltoFolder();
            }
            else
            {
                //TODO : 파일을 옮길지 물어본다.
                Debug.Log("NO Create!! ");
            }
        }

    }
}