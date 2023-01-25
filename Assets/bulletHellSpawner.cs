 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHellSpawner : MonoBehaviour
{

    public ParticleSystem system;


    public int colums;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    public float angle;
    public Material material;
    public float spinSpeed;
    private float time;
    public bool isShooting = false;

    private void Awake(){
       
            StartFire();
    }

    private void Update() {
        
    }

    private void FixedUpdate() 
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0,0,time*spinSpeed);
    }

    void StartFire()
    {
        angle = 360f / colums;
        for(int i=0; i<colums;i++)
        {
        // A simple particle material with no texture.
        Material particleMaterial = material;

        // Create a green Particle System.
        var go = new GameObject("Particle System");
        go.transform.Rotate(angle * i, 90, 0); 
        go.transform.parent = this.transform;
        go.transform.position = this.transform.position;
        system = go.AddComponent<ParticleSystem>();
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;

        
        //Modules section
        var mainModule = system.main;
        mainModule.startColor = Color.green;
        mainModule.startSize = size;
        mainModule.startSpeed = speed;
        mainModule.maxParticles = 100000;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

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
        //collision.bounce = 0;

        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f , firerate); // lol

    }

    void DoEmit()
    {
        if(isShooting){
        foreach(Transform child in transform)
        {
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

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("A");
    }

}
