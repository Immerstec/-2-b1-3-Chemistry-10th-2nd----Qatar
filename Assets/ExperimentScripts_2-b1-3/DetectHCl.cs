using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHCl : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem_bubbles;
    [SerializeField] ParticleSystem _particleSystem_smoke;
    [System.NonSerialized] public static bool IsDone;
    [System.NonSerialized] public static bool IsDoneZn;
    LiquidSystem liquidSystem;
    private void Start()
    {
        liquidSystem = GetComponent<LiquidSystem>();
    }

    private void Update()
    {
        if (!IsDone && IsDoneZn && liquidSystem.available>0)
        {
            _particleSystem_bubbles.Play();
            _particleSystem_smoke.Play();
            IsDone = true;
        }
    }


}
