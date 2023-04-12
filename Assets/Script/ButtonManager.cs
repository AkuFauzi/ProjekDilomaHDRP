using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    public GameObject option;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionUI(bool active)
    {
        if (active)
        {
            option.SetActive(true);
        }
        else if (!active)
        {
            option.SetActive(false);
        }
    }



    public void Play(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
