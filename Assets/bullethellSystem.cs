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

    private bulletHellSpawner bulletSystem;
    private GameObject currentBulletGenerator;
    // Start is called before the first frame update
    public void PlaceBulletHellGenerator()
    {
        currentBulletGenerator = new GameObject("bulletHellPlaceholder");
        currentBulletGenerator.transform.position = parentObject.transform.position;
        bulletSystem = currentBulletGenerator.AddComponent<bulletHellSpawner>();
        bulletSystem.Initialize(columns, bulletSpeed, texture, color, lifetime, firerate, bulletSize, angle, material, spinSpeed, false, desiredLayers, space);
        bulletSystem.isShooting = true;
    }

    // Update is called once per frame
    public void DestroyBulletHellGenerator()
    {
        bulletSystem.isShooting = false;
        StartCoroutine(showStageAnnouncerFor(40));
    }

    IEnumerator showStageAnnouncerFor(float timeBeforeHidden) //time in seconds
    {
        yield return new WaitForSeconds(timeBeforeHidden);
        Destroy(currentBulletGenerator);
        yield return null;
    }
}
