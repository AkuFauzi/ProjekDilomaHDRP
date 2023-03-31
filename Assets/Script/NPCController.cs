using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Dialog dialog;
    public int idNPC;
    public GameObject buttonInteract;
    public GameObject dialogBox;



    private void Start()
    {
        buttonInteract.SetActive(false);
        dialogBox.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        buttonInteract.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogManager>().MulaiDialog(dialog);
            dialogBox.SetActive(true);
            buttonInteract.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        buttonInteract.SetActive(false);
    }

}
