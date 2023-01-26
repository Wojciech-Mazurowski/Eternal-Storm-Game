using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class mainCharacterMovement : MonoBehaviour
{

    public float speed;
    public float size;
    public int numberOfHearths;
    public float health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public List<ParticleCollisionEvent> collisionEvents; 
        
    // Start is called before the first frame update
    void Start()
    {
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x*size,localScale.y*size,localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

        if(Input.GetKey("z")){
            this.GetComponent<bulletHellSpawner>().isShooting = true;
        }else{
            this.GetComponent<bulletHellSpawner>().isShooting = false;
        }

        if(health > numberOfHearths){
            health = numberOfHearths;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
            if(i < numberOfHearths){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }

    public void DecrementHp(){
        health -= 1f;
        if(health==0){
             // SceneManager.LoadScene("MainMenuScene");  
        }
    }

    private void OnParticleCollision(GameObject other) {
        DecrementHp();
    }
}
