using UnityEngine;

public class textureChanger : MonoBehaviour
{
    public bool isEnemy = false;
    public Sprite idleTexture;
    public Sprite upDownTexture;
    public Sprite backTexture;
    public Sprite forwardTexture;
    private Vector3 PrevPos;
    private Vector3 NewPos;
    private Vector3 Velocity;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        PrevPos = transform.position;
        NewPos = transform.position;
    }

    void Update()
    {
        NewPos = transform.position;
        Velocity = (NewPos - PrevPos) / Time.fixedDeltaTime;
        if (isEnemy) { Velocity *= -1; }
        PrevPos = NewPos;  
        if (Mathf.Abs(Velocity.x) > Mathf.Abs(Velocity.y))
        {
            if (Velocity.x > 0)
            {
                sr.sprite = forwardTexture;
            }
            else
            {
                sr.sprite = backTexture;
            }
        }
        else if (Mathf.Abs(Velocity.y) > Mathf.Abs(Velocity.x))
        {
            sr.sprite = upDownTexture;
        }
        else
        {
            sr.sprite = idleTexture;
        }
    }
}
