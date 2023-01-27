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
    public float time;
    public LayerMask desiredLayers;
    public ParticleSystemSimulationSpace space;

    private bulletHellSpawner bulletSystem;
    private GameObject currentBulletGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
