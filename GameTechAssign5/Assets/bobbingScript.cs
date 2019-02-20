using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingScript : MonoBehaviour
{
    public float maxAmount;
    public float startingYposition;
    public float deltaAmount;
    // Update is called once per frame
    void Awake(){
      startingYposition = transform.position.y;
    }
    void Update()
    {
      transform.position += new Vector3(0, deltaAmount, 0);

      if(transform.position.y > startingYposition + maxAmount){ //below
        Debug.Log("Hello back down");
        deltaAmount = -deltaAmount;
      }else if(transform.position.y < startingYposition - maxAmount){
        Debug.Log("Hello back up");
        deltaAmount = -deltaAmount;
      }

    }
}
