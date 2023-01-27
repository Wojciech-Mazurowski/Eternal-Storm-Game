using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    
    public float speed;
    public float size;
    public GameObject movementBoxCenter;
    public int movementXLimit;
    public int movementYLimit;
    public float standByTime;
    private Vector3 targetPosition;

    private float timer;

    public ParticleSystem system;

    public int columns;
    public float bulletSpeed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float bulletSize;
    private float angle;
    public Material material;
    public float spinSpeed;
    public float time;
    public LayerMask desiredLayers;
    public ParticleSystemSimulationSpace space;

    private bulletHellSpawner bulletSystem;
    private GameObject currentBulletGenerator;

    Vector3 GetPositionInsideMovementBox(){
        var newX = Random.Range(movementBoxCenter.transform.position.x-movementXLimit,movementBoxCenter.transform.position.x+movementXLimit);
        var newY = Random.Range(movementBoxCenter.transform.position.y-movementYLimit,movementBoxCenter.transform.position.y+movementYLimit);
        return new Vector3(newX,newY,transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * size, localScale.y * size, localScale.z);
        targetPosition = GetPositionInsideMovementBox();
    }

    // Update is called once per frame
    void Update()
    {
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        var generators = GetComponents<bullethellSystem>();
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f){  
                if(timer==0){
               
                foreach (var generator in generators)
                {
                    generator.PlaceBulletHellGenerator();
                }
            }
                transform.position = targetPosition;
                timer += Time.deltaTime;
            //place generator
            
                if(timer > standByTime){
                Debug.Log("AAAA");
                    timer=0;
                    targetPosition = GetPositionInsideMovementBox();
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                foreach (var generator in generators)
                {
                    generator.DestroyBulletHellGenerator();
                }

            }
        }
    }

    
    
}
