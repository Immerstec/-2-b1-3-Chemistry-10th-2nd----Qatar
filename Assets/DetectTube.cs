using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTube : MonoBehaviour
{
    [SerializeField] GameObject Zn_peice;
    [SerializeField] Vector3 pos;
    bool IsDone;
    private void Start()
    {
        pos = gameObject.transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsDone && other.gameObject.tag == "TubeBottom") 
        {
            GameObject zn = Instantiate(Zn_peice, pos, Quaternion.identity);
            zn.transform.SetParent(gameObject.transform.parent);
            IsDone = true;
        }
    }
}
