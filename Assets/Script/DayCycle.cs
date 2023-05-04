using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DayCycle : MonoBehaviour
{
    public Light matahari;
    public LocalVolumetricFog fog;

    [Range(0, 150)]
    public float tinggiKabut;

    [Range(0, 24)]
    public float waktu;

    public float startJam = 6;
    public float kelipatanWaktu = 0.5f;
    public float kecKabut = 10f;

    public GameObject localVolumetricFog;
    public GameObject bulan;

    public LocalVolumetricFog tebalFog;


    // Start is called before the first frame update
    void Start()
    {
        tinggiKabut = 35;
        waktu = startJam;
    }

    // Update is called once per frame
    void Update()
    {
        kabut();
        UpdateHari();
    }

    private void OnValidate()
    {
        //UpdateHari();
    }

    private void UpdateHari()
    {
        waktu += Time.deltaTime * kelipatanWaktu;
        if (waktu >= 24) waktu = 0;

        float alpha = waktu / 24.0f;
        float rotasiMatahari = math.lerp(-90, 270, alpha);
        matahari.transform.rotation = Quaternion.Euler(rotasiMatahari, 0, 0);

        /*if (waktu >= 9)
        {
            //localVolumetricFog.gameObject.SetActive(false);
            tinggiKabut = 35 *Time.deltaTime * kecKabut;
        }
        if (waktu >= 18)
        {
            tinggiKabut = Time.deltaTime * waktu * 5;
            localVolumetricFog.gameObject.SetActive(true);
        }*/
    }

    private void kabut()
    {
        tebalFog.parameters.meanFreePath = tinggiKabut;
        //if(waktu >= 8)
        //{
        //    if (kabutMenipis == true)
        //    {
        //        tinggiKabut = waktu * 12;
        //    }
        //    if (tinggiKabut >= 150)
        //    {
        //        kabutMenipis = false;
               
        //    }
            
        //}
        //else if (waktu >= 18)
        //{
        //    tinggiKabut = tinggiKabut + waktu * -12;
        //}
        //if(tinggiKabut == 35)
        //{
        //    kabutMenipis = true;
        //}

        //
        float speed = 15;
        if (waktu >= 18)
        {

            if (tinggiKabut >= 35)
            {
                tinggiKabut -= speed * Time.deltaTime;
            }

        }
        else if (waktu >= 8)
        {
            if (tinggiKabut <= 150)
            {
                tinggiKabut += speed * Time.deltaTime;
            }

        }
        else if (waktu >= 0)
        {
            if (tinggiKabut >= 35)
            {
                tinggiKabut -= speed * Time.deltaTime;
            }
        }

    }



    bool kabutMenipis;

    
}
