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
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f){  
                if(timer==0){
                    currentBulletGenerator = new GameObject("bulletHellPlaceholder");
                    currentBulletGenerator.transform.position = this.transform.position;
                    bulletSystem = currentBulletGenerator.AddComponent<bulletHellSpawner>();
                    bulletSystem.Initialize(columns,bulletSpeed,texture,color,lifetime,firerate,bulletSize,angle,material,spinSpeed,false,desiredLayers,space);
                    bulletSystem.isShooting = true;
                }

                transform.position = targetPosition;
                timer += Time.deltaTime;
                //this.GetComponent<bulletHellSpawner>().isShooting = true;
                if(timer > standByTime){
                   // this.GetComponent<bulletHellSpawner>().isShooting = false;
                    timer=0;
                    targetPosition = GetPositionInsideMovementBox();
                    bulletSystem.isShooting = false;
                    StartCoroutine(showStageAnnouncerFor(10));
            }
        }
    }

    
    IEnumerator showStageAnnouncerFor(float timeBeforeHidden) //time in seconds
    {
        yield return new WaitForSeconds(timeBeforeHidden);
            Destroy(currentBulletGenerator);
        yield return null;
    }
}
