using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSooScript : MonoBehaviour
{
    Button btnsoo;

    // Start is called before the first frame update
    void Start()
    {
        btnsoo = GetComponent<Button>();
        btnsoo.onClick.AddListener(OpenURL);
    }

    void Update()
    {
        btnsoo.enabled = EvriusScript.run2;
    }

    public void OpenURL()
    {
        Application.OpenURL("https://vk.com/evrotgp");        
    }
}
