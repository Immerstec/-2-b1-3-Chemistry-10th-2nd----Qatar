using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectH2 : MonoBehaviour
{
    [System.NonSerialized] public bool IsDetectedH2;
    [SerializeField] ParticleSystem _particleSystem_Explosion;
    bool InH2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (InH2 && DetectSockets.Isbubble) 
        {
            if (DetectHCl.emissionValue_Bubbles_Glass_Trough > 20)
            {
                ParticleSystem.EmissionModule emission = _particleSystem_Explosion.emission;
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(DetectHCl.emissionValue_Bubbles_Glass_Trough);
                _particleSystem_Explosion.Play();
                IsDetectedH2 = true;
                DetectHCl.emissionValue_Bubbles_Glass_Trough = 0;
                DetectHCl.emission_Bubbles_Glass_Trough.rateOverTime = new ParticleSystem.MinMaxCurve(0);

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!InH2 && other.gameObject.tag == "H2" )
        {
            InH2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (InH2 && other.gameObject.tag == "H2")
        {
            InH2 = false;
        }
    }
}
