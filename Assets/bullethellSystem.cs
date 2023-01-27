using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethellSystem : MonoBehaviour
{

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
    public float timeToDestroy;
    public LayerMask desiredLayers;
    public ParticleSystemSimulationSpace space;
    public GameObject parentObject;
    public int stage;
    public Vector3 spawnOffset;

    private bool deletedFlag = true;

    private bulletHellSpawner bulletSystem;
    private GameObject currentBulletGenerator;
    // Start is called before the first frame update
    public void PlaceBulletHellGenerator(int parentStage)
    {
        if (parentStage == stage)
        {
            deletedFlag = true;
            currentBulletGenerator = new GameObject("bulletHellPlaceholder");
            var parentPos = parentObject.transform.position;
            parentPos.x -= 0.8f;
            currentBulletGenerator.transform.position = parentPos;
            bulletSystem = currentBulletGenerator.AddComponent<bulletHellSpawner>();
            bulletSystem.Initialize(columns, bulletSpeed, texture, color, lifetime, firerate, bulletSize, angle, material, spinSpeed, false, desiredLayers, space, spawnOffset);
            bulletSystem.isShooting = true;
        }
        else
        {
            deletedFlag = true;
        }
    }

    // Update is called once per frame
    public void DestroyBulletHellGenerator(int parentStage)
    {
        if (deletedFlag)
        {
            if (bulletSystem) { 
            bulletSystem.isShooting = false;
            }
            StartCoroutine(showStageAnnouncerFor(40));
            deletedFlag = false;
        }
    }

    IEnumerator showStageAnnouncerFor(float timeBeforeHidden) //time in seconds
    {
        yield return new WaitForSeconds(timeBeforeHidden);
        Destroy(currentBulletGenerator);
        yield return null;
    }
}
