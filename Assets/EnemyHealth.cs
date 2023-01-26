using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class EnemyHealth : MonoBehaviour
{

    public float hp;
    private float maxHp;
    public int stages;
    public Image upperBar;
    public Image underBar;


    // Start is called before the first frame update
    void Start()
    {
        upperBar.enabled = true;
        underBar.enabled = true;
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp>0 && stages>1){
        upperBar.fillAmount = hp / maxHp;
        underBar.fillAmount = 1;
        }else if(hp>0){
            upperBar.fillAmount = 0;
            underBar.fillAmount = hp/maxHp;
        }
        if(hp<0 && stages>0){
            stages--;
            hp=maxHp;
        }else if(hp < 0 ){
            //todo go to new area/boss
        }
    }

    void DecrementHp(int damage){
        hp-=damage;
        if(hp<0&&stages==0){
            SceneManager.LoadScene("MainMenuScene");  
        }
    }

    private void OnParticleCollision(GameObject other) {
        DecrementHp(10);
    }
}
