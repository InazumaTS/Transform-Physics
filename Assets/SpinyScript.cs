using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinyScript : MonoBehaviour
{
    [SerializeField]
    int health;
    float temp = 0f;
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void damage()
    {
        if (Time.time > temp)
            health--;
        temp = Time.time + 0.1f;
    }
}
