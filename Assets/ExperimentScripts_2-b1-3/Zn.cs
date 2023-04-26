using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zn : MonoBehaviour
{
    DetectHCl detectHCl;
    DetectTube detectTube;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (detectTube.IsDone && detectHCl.IsDone)
        {

            transform.localScale -= Vector3.one * Time.deltaTime;
        
        
        }
    }
}
