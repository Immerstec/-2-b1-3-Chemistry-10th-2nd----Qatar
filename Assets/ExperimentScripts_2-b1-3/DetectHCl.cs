using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHCl : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem_Bubbles;
    [SerializeField] ParticleSystem particleSystem_smoke;
    [SerializeField] ParticleSystem particleSystem_Bubbles_Glass_Trough;
    [System.NonSerialized] public static bool IsDone;
    [System.NonSerialized] public static bool IsDoneZn;
    LiquidSystem liquidSystem;
    [System.NonSerialized] public static float emissionValue_Smoke;
    [System.NonSerialized] public static float emissionValue_Bubbles;
    [System.NonSerialized] public static float emissionValue_Bubbles_Glass_Trough;
    [System.NonSerialized] public static float Max_emissionValue_Bubbles_Glass_Trough;
    ParticleSystem.EmissionModule emission_bubbles;
    ParticleSystem.EmissionModule emission_smoke;
    ParticleSystem.EmissionModule emission_Bubbles_Glass_Trough;
    [System.NonSerialized] public static bool IsChanged;
    private void Start()
    {
        liquidSystem = GetComponent<LiquidSystem>();
        emission_bubbles = particleSystem_smoke.emission;
        emission_smoke = particleSystem_Bubbles.emission;
        emission_Bubbles_Glass_Trough = particleSystem_Bubbles_Glass_Trough.emission;
    }

    private void Update()
    {
        if (!IsDone && IsDoneZn && liquidSystem.available>0)
        {
            particleSystem_Bubbles.Play();
            particleSystem_smoke.Play();
            IsDone = true;
        }
        if (IsDone && IsChanged)
        {

            emission_bubbles.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles);
            emission_smoke.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Smoke);
            IsChanged = false;
            //emissionValue_Bubbles -= Time.deltaTime;
            //emissionValue_Smoke -= Time.deltaTime;
            //reactionSuppressionTime += Time.deltaTime * 20;
        }
        if (IsDone && DetectSockets.IsSocket && emissionValue_Bubbles_Glass_Trough < Max_emissionValue_Bubbles_Glass_Trough)
        {
            emissionValue_Bubbles_Glass_Trough+=Time.deltaTime;
            emission_Bubbles_Glass_Trough.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles_Glass_Trough);
        }
    }
    public static void IncreseEmission(float v) 
    {
        emissionValue_Smoke += v;
        emissionValue_Bubbles += v;
        Max_emissionValue_Bubbles_Glass_Trough += v;
        IsChanged = true;
    }
    

}
