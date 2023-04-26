using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTube : MonoBehaviour
{
    [SerializeField] GameObject Zn_peice;
    [SerializeField] Vector3 pos;
    [System.NonSerialized] public bool IsDone;
    [System.NonSerialized] public static int numZn;
    //public static List<GameObject> _gameObjects = new List<GameObject>();

    private void Start()
    {
        pos = gameObject.transform.position;
        //_gameObjects.Add(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsDone && other.gameObject.tag == "TubeBottom") 
        {
            GameObject zn = Instantiate(Zn_peice, pos, Quaternion.identity);
            zn.transform.SetParent(gameObject.transform.parent);
            numZn++;
            IsDone = true;
        }
    }
}
