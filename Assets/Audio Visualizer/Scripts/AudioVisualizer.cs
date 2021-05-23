using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    private AudioSource AS;
    public static float[] samples = new float[512];
    
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumData();
    }

    void GetSpectrumData()
    {
        AS.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
