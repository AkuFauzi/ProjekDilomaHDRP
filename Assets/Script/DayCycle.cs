using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DayCycle : MonoBehaviour
{
    public Light matahari;

    [Range(0, 24)]
    public float waktu;

    public float startJam = 6;
    public float kelipatanWaktu = 0.5f;

    public GameObject localVolumetricFog;
    public GameObject bulan;


    // Start is called before the first frame update
    void Start()
    {
        waktu = startJam;
    }

    // Update is called once per frame
    void Update()
    {

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

        if (waktu >= 9)
        {
            localVolumetricFog.gameObject.SetActive(false);
        }
        if (waktu >= 18)
        {

            bulan.SetActive(true);
            localVolumetricFog.gameObject.SetActive(true);
        }
        else if (waktu >= 5)
        {
            matahari.gameObject.SetActive(true);
            bulan.SetActive(false);
        }
        else if (waktu >= 19)
        {
            matahari.gameObject.SetActive(false);
        }
    }

    private void kabut()
    {
        //localVolumetricFog.
    }
}
