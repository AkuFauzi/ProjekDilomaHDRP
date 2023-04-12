using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public NPCController npc;
    public TextMeshProUGUI textPopup;
    public GameObject popup;

    public string[] kalimatPopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Popup();
    }

    void Popup()
    {
        if(npc.idNPC == 1)
        {
            popup.SetActive(true);
            textPopup.text = kalimatPopup[1];
        }
        else if(npc.idNPC == 2)
        {
            textPopup.text = kalimatPopup[2];
        }
        else if (npc.idNPC == 3)
        {
            textPopup.text = kalimatPopup[3];
        }
    }
}
