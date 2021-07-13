using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnChannelScript : MonoBehaviour
{
    Button btnchannel;

    // Start is called before the first frame update
    void Start()
    {
        btnchannel = GetComponent<Button>();
        btnchannel.onClick.AddListener(OpenURL);
    }

    void Update()
    {
        btnchannel.enabled = EvriusScript.run2;
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCHG97pTUmGuwyhOOawv_LCA");
    }
}
