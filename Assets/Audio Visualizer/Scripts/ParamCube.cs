using System;
using UnityEngine;
using System.Collections;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMuliplier;
    private Material material;

    private void Awake()
    {
        material = GetComponentInChildren<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x,
            (AudioVisualizer.bandBuffer[band] * scaleMuliplier) + startScale, transform.localScale.z);
        Color color = new Color(AudioVisualizer.audioBandBuffer[band], AudioVisualizer.audioBandBuffer[band],
            AudioVisualizer.audioBandBuffer[band]);
        material.SetColor("EmissionColor", color);
    }
}
