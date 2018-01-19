using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

namespace Ryan
{
    public class CreateName : NetworkBehaviour
    {
        [SyncVar(hook = "OnSyncMyName")]
        public string myName;

        void OnSyncMyNameHook(string value)
        {
            myName = value;
            GetComponentInChildren<TextMesh>().text = value;
        }

        [Command]
        void CmdSetName(string name)
        {
            if (!isLocalPlayer)
                return;

            myName = name;
        }

        void ChangeName(string name)
        {
            CmdSetName(name);
        }
         
        
        // Update is called once per frame
        void Update()
        {
        }
    }
}