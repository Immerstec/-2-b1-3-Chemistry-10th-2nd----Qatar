using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHCl : MonoBehaviour
{
    LiquidSystem liquidSystem;
    [SerializeField] ParticleSystem _particleSystem;
    [System.NonSerialized] public bool IsDone;
    // Start is called before the first frame update
    void Start()
    {
        liquidSystem = GetComponent<LiquidSystem>();
    }

    private void Update()
    {
        
    }

    void HClInteract() {

        if (!IsDone)
        {
            _particleSystem.Play();
            IsDone = true;
        }

    }
}
