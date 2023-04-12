using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quizz : MonoBehaviour
{
    public static Quizz instance;

    public TextMeshProUGUI textSoal;
    public TextMeshProUGUI textJawaban;

    [Serializable]
    public struct Pertanyaan
    {
        public string textPertanyaan;
        public string A, B, C;
    }

    public List<Pertanyaan> PertanyaanList; 

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
}
