using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    // Start is called before the first frame update
    float radian=0;
    [SerializeField]
    int health;
    float temp =0f;
    CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
            health = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(radian) * 0.0125f);
        radian += 0.05f;
        if (radian > 6.7)
            radian = 0;
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }
    public void damage()
    {
        if(Time.time > temp)
        health--;
        temp =Time.time +0.1f;
    }
}
