using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJSR_dor_model_1 : MonoBehaviour
{

    public bool onGoingAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endAnimation()
    {
        Debug.Log("[puerta] !!!!! **** ANIMATION ENDS **** !!!!!");
        onGoingAnimation = false;
    }
    public void startAnimation()
    {
        Debug.Log("[puerta] !!!!! **** ANIMATION STARTS **** !!!!!");
        onGoingAnimation = true;
    }
}
