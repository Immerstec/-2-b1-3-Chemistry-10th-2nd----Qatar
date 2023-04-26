using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{


    [SerializeField] LiquidSystem liquidSystem_TestTube;
    [SerializeField] CustomSocket CustomSocket_Glass_Trough;
    [SerializeField] CustomSocket CustomSocket_Test_Tube_M;
    [SerializeField] DetectH2 detectH2;
    public int UINum = 1;

    // Update is called once per frame
    void Update()
    {

        switch (UINum)
        {
            case 1: //1.1 to 2.1
                if (liquidSystem_TestTube.available >= 200 || detectH2)
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 2: //2.1 to 3.1
                if (CustomSocket_Glass_Trough.wasInSoket) {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 3: //3.1 to 4.1
                if ( (DetectTube.numZn >= 5 && CustomSocket_Test_Tube_M.wasInSoket) || detectH2 )
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;
            case 4: //4.1 to 5.1
                if (detectH2)
                {
                    UIActivation(UINum);
                    UINum++;
                }
                break;

        }


    }
    void UIActivation(int _UINum)
    {
        gameObject.transform.GetChild(_UINum).gameObject.SetActive(false);
        gameObject.transform.GetChild(_UINum + 1).gameObject.SetActive(true);
    }
}
