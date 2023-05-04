using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public Camera kamera;
    public NPCController npc;
    public TextMeshPro textPopup;
    public GameObject popup;

    public string[] kalimatPopup;
    // Start is called before the first frame update
    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = kamera.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Popup();
        //PosisiText();
    }

    private void OnTriggerExit(Collider other)
    {
        popup.SetActive(false);
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
            popup.SetActive(true);
            textPopup.text = kalimatPopup[2];
        }
        else if (npc.idNPC == 3)
        {
            popup.SetActive(true);
            textPopup.text = kalimatPopup[3];
        }
    }
}
