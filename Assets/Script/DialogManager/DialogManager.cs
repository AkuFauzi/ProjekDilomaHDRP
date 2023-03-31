using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Queue<string> kalimatDialog;
    public TextMeshProUGUI textNama, textKalimat;
    // Start is called before the first frame update
    void Start()
    {
        kalimatDialog = new Queue<string>();
    }
    public void MulaiDialog(Dialog dialog)
    {
        textNama.text = dialog.name;
        print("Mulai berbicara" + dialog.name);

        kalimatDialog.Clear();

        foreach (string kalimat in dialog.kalimat)
        {
            kalimatDialog.Enqueue(kalimat);
        }

        DisplayKalimatSelanjutnya();
    }
    public void DisplayKalimatSelanjutnya()
    {
        if(kalimatDialog.Count == 0)
        {
            DialogSelesai();
            return;
        }

        string kalimat = kalimatDialog.Dequeue();
        textKalimat.text = kalimat;
        print(kalimat);
    }

    public void DialogSelesai()
    {
        print("Selesai");
        FindObjectOfType<NPCController>().dialogBox.gameObject.SetActive(false);
    }
}
