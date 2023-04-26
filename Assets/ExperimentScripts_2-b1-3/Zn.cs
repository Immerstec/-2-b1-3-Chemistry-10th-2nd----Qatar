using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zn : MonoBehaviour
{
    DetectTube detectTube;

    private void Start()
    {
        detectTube = GetComponent<DetectTube>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectTube.IsDone && DetectHCl.IsDone)
        {
            if (transform.localScale.x > 0.03)
                transform.localScale -= Vector3.one * (Time.deltaTime/10);
            else
                gameObject.SetActive(false);
        
        }
        
    }
}
