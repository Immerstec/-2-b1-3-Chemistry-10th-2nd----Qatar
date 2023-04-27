using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zn : MonoBehaviour
{
    DetectTube detectTube;
    float ZnValue = 50;
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
                transform.localScale -= Vector3.one * (Time.deltaTime / 100);
            else
            {
                float v = -(Time.deltaTime*10);
                ZnValue += v;
                if(ZnValue>0)
                    DetectHCl.ChangeEmission(v);
                else
                {
                    DetectTube.numActiveZn--;
                    gameObject.SetActive(false);

                }
            }
        }
        
    }
}
