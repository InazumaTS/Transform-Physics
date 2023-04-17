using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class rocketGun : MonoBehaviour
{
    [SerializeField]
    private LayerMask platformLayerMask;
    CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y-0.5f);

        RaycastHit2D raycasthit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, circleCollider.bounds.extents.y + 0.1f, platformLayerMask);
        if(raycasthit.collider !=null)
        {
            if (raycasthit.collider.tag == "enemy")
            {
                GhostScript ghost = raycasthit.collider.transform.GetComponent<GhostScript>();
                if(ghost != null) 
                { 
                    ghost.damage(); 
                }
            }
            if (raycasthit.collider.tag == "enemy")
            {
                SpinyScript ghost = raycasthit.collider.transform.GetComponent<SpinyScript>();
                if (ghost != null)
                {
                    ghost.damage();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
