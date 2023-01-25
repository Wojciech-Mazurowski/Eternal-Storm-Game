using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float moveFrequency;
    public float timerSpeed;
    
    public float speed;
    public float size;

    private Vector3 startpos;


     public Vector3 RandomPositionInBox (float width ,float height){
         return new Vector3(
             Random.Range(0f,width)+startpos.x-(width*.5f),
             Random.Range(0f,height)+startpos.y-(height*.5f),
             startpos.z);
 
     }

    // Start is called before the first frame update
    void Start()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * size, localScale.y * size, localScale.z);
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        startpos = transform.position;
    }
}
