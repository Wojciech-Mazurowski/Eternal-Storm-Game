using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHellSpawner : MonoBehaviour
{

    public ParticleSystem system;

    public int columns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    public float spinSpeed;
    private float time=0;
    public bool isShooting = false;
    public LayerMask desiredLayers;
    public ParticleSystemSimulationSpace space;

    public Vector3 spawnOffset= Vector3.zero;

    public void Initialize(int columns, float speed, Sprite texture, Color color, float lifetime, float firerate, float size, float angle, Material material, float spinSpeed, bool isShooting, LayerMask desiredLayers, ParticleSystemSimulationSpace space, Vector3 spawnOffset)
    {
       this.columns = columns;
       this.speed = speed;
       this.texture = texture;
       this.color = color;
       this.lifetime = lifetime;
       this.firerate = firerate;
       this.size = size;
       this.angle = angle;
       this.material = material;
       this.spinSpeed= spinSpeed;
       this.isShooting = isShooting;
       this.desiredLayers = desiredLayers;
       this.space = space;
        this.spawnOffset = spawnOffset;
       StartFire();
    }
    
    private void Awake()
    {
        StartFire();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * spinSpeed);
    }

    void StartFire()
    {
        angle = 360f / columns;
        for (int i = 0; i < columns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0);
            go.transform.parent = this.transform;
            var pos = this.transform.position + spawnOffset;    
            go.transform.position = pos;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

            //Modules section
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = size;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;
            mainModule.simulationSpace = space;

            var emission = system.emission; //emision module
            emission.enabled = false;

            var shape = system.shape; //shape module
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;

            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            text.enabled = true;

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.quality = ParticleSystemCollisionQuality.High;
            collision.sendCollisionMessages = true;
            collision.lifetimeLoss = 100;
            collision.collidesWith = desiredLayers;

            go.GetComponent<ParticleSystemRenderer>().sortingLayerName= "underunder";
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate); // lol

    }

    void DoEmit()
    {
        if (isShooting)
        {
            foreach (Transform child in transform)
            {
                if(child.GetComponent<ParticleSystem>()){
                system = child.GetComponent<ParticleSystem>();
                // Any parameters we assign in emitParams will override the current system's when we call Emit.
                // Here we will override the start color and size.
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.startColor = color;
                emitParams.startSize = size;
                emitParams.startLifetime = lifetime;
                system.Emit(emitParams, 10);
                }
            }
        }
    }
}
