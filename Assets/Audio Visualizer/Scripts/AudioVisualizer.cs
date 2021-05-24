using UnityEngine;
using System.Collections;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    private AudioSource AS;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    private float[] bufferDecreases = new float[8];

    private float[] freqBandHeight = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    public static float amplitude, amplitudeBuffer;
    private float amplitudeHighest;
    
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumData();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    void GetAmplitude()
    {
        float currAmplitude = 0;
        float currAmplitudeBuffer = 0;

        for (int i = 0; i < 8; i++)
        {
            currAmplitude += audioBand[i];
            currAmplitudeBuffer += audioBandBuffer[i];
        }

        if (currAmplitude > amplitudeHighest)
        {
            amplitudeHighest = currAmplitude;
        }

        amplitude = Mathf.Clamp01(currAmplitude / amplitudeHighest);
        amplitudeBuffer = Mathf.Clamp01(currAmplitudeBuffer / amplitudeHighest);
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHeight[i])
            {
                freqBandHeight[i] = freqBand[i];
            }

            audioBand[i] = (freqBand[i] / freqBandHeight[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHeight[i]);
        }
    }

    void GetSpectrumData()
    {
        AS.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; ++i)
        {
            if (freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecreases[i] = 0.005f;
            }

            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecreases[i];
                bufferDecreases[i] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int) Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }
}
