using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHCl : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem_Bubbles;
    [SerializeField] ParticleSystem particleSystem_Bubbles_InLiquid;
    [SerializeField] ParticleSystem particleSystem_smoke;
    [SerializeField] ParticleSystem particleSystem_Bubbles_Glass_Trough;
    [SerializeField] ParticleSystem particleSystem_Bubbles_Glass_Trough__InLiquid;
    [System.NonSerialized] public static bool IsDone;
    [System.NonSerialized] public static bool IsDoneZn;
    LiquidSystem liquidSystem;

    [System.NonSerialized] public static float emissionValue_Bubbles;
    [System.NonSerialized] public static float emissionValue_Bubbles_InLiquid;
    [System.NonSerialized] public static float emissionValue_Smoke;
    [System.NonSerialized] public static float emissionValue_Bubbles_Glass_Trough;
    [System.NonSerialized] public static float Max_emissionValue_Bubbles_Glass_Trough;
    [System.NonSerialized] public static float emissionValue_Bubbles_Glass_Trough__InLiquid;
    [System.NonSerialized] public static float Max_emissionValue_Bubbles_Glass_Trough__InLiquid;

    ParticleSystem.EmissionModule emission_bubbles;
    ParticleSystem.EmissionModule emission_Bubbles_InLiquid;
    ParticleSystem.EmissionModule emission_smoke;
    ParticleSystem.EmissionModule emission_Bubbles_Glass_Trough;
    ParticleSystem.EmissionModule emission_Bubbles_Glass_Trough__InLiquid;
    [System.NonSerialized] public static bool IsChanged;
    private void Start()
    {
        liquidSystem = GetComponent<LiquidSystem>();
        emission_bubbles = particleSystem_Bubbles.emission;
        emission_Bubbles_InLiquid = particleSystem_Bubbles_InLiquid.emission;
        emission_smoke  = particleSystem_smoke.emission;

        emission_Bubbles_Glass_Trough = particleSystem_Bubbles_Glass_Trough.emission;
        emission_Bubbles_Glass_Trough__InLiquid = particleSystem_Bubbles_Glass_Trough__InLiquid.emission;
    }

    private void Update()
    {
        if (!IsDone && IsDoneZn && liquidSystem.available>0)
        {
            particleSystem_Bubbles.Play();
            particleSystem_Bubbles_InLiquid.Play();
            particleSystem_smoke.Play();
            IsDone = true;
        }
        if (IsDone && IsChanged)
        {

            emission_bubbles.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles);
            emission_Bubbles_InLiquid.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles_InLiquid);
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

        if (IsDone && DetectSockets.IsSocket && emissionValue_Bubbles_Glass_Trough__InLiquid < Max_emissionValue_Bubbles_Glass_Trough__InLiquid)
        {
            emissionValue_Bubbles_Glass_Trough__InLiquid += Time.deltaTime;
            emission_Bubbles_Glass_Trough__InLiquid.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles_Glass_Trough__InLiquid);
        }
        else if(emissionValue_Bubbles_Glass_Trough__InLiquid>0)
        { 
            emissionValue_Bubbles_Glass_Trough__InLiquid -= Time.deltaTime*100;
            emission_Bubbles_Glass_Trough__InLiquid.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles_Glass_Trough__InLiquid);


        }
    }
    public static void IncreseEmission(float v) 
    {
        emissionValue_Bubbles += v;
        emissionValue_Bubbles_InLiquid += v;
        emissionValue_Smoke += v;
        Max_emissionValue_Bubbles_Glass_Trough += v;
        Max_emissionValue_Bubbles_Glass_Trough__InLiquid += v;
        IsChanged = true;
    }
    

}
