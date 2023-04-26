using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSockets : MonoBehaviour
{
    [SerializeField] CustomSocket CustomSocket_Glass_Trough;
    [SerializeField] CustomSocket CustomSocket_Test_Tube_M;
    ParticleSystem _particleSystem;
    [System.NonSerialized] public static bool Isbubble;
    [System.NonSerialized] public static bool IsSocket;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CustomSocket_Glass_Trough.wasInSoket && CustomSocket_Test_Tube_M.wasInSoket && DetectHCl.IsDone)
        {

            if (!_particleSystem.isPlaying)
            {

                _particleSystem.Play();
                Isbubble = true;
            }
            if(!IsSocket)
                IsSocket = true;

        }
        else 
        {
            if (IsSocket)
                IsSocket = false;
        }
        
    }
}
