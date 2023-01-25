using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterMovement : MonoBehaviour
{

    public float speed;
    public float size;
    public float hp;
        
    // Start is called before the first frame update
    void Start()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x*size,localScale.y*size,localScale.z);
        hp=3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
    }

    public void DecrementHp(){
        hp -=1;
        Debug.Log(hp);
    }

    private void OnParticleCollision(GameObject other) {
        DecrementHp();
    }
}
