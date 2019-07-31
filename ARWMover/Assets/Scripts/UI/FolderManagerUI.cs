using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Choe
{
    public class FolderManagerUI : MonoBehaviour
    {
        public FolderManager Manager;

        public Button Button_Exit;
        public Button Button_Move;

        public InputField FolderName_Input;
        public InputField Extension_Input;





        private void Awake()
        {
            SetButtonEvent();
        }

        private void SetButtonEvent()
        {
            Button_Exit.onClick.AddListener(()=> Manager.Exit_Action());
            Button_Move.onClick.AddListener(()=> Manager.CreateAction());
        }

    }
}
