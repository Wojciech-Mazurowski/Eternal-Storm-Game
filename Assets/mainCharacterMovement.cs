using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainCharacterMovement : MonoBehaviour
{

    public float speed;
    public float size;
    public int numberOfHearths;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart; 
        
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
        health -=1;
    }

    private void OnParticleCollision(GameObject other) {
        DecrementHp();
    }
}
