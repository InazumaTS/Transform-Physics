using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovementController : MonoBehaviour
{
    // Start is called before the first frame update
    CapsuleCollider2D capsuleCollider;
    [SerializeField]
    private LayerMask platformLayerMask;
    float temp =0;
    int counter = 8;
    [SerializeField]
    float speed = 0;
    [SerializeField]
    float radian = 0;
    float rocket_radian = 0;
    [SerializeField]
    float dist = 10 ;
    bool flag = false;
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isCeiling();
        isWalled();
        if(!isGrounded() && radian<=1 && radian >0 && flag !=true) //Up trajectory
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(radian) * (dist * Time.deltaTime));
            radian -= 0.03f;
        }
        if (!isGrounded() && flag != false) //Up Rocket trajectory
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(rocket_radian) * (6 * Time.deltaTime));
            rocket_radian -= 0.05f;
            if (rocket_radian <= 0)
                radian = rocket_radian;
        }
        else if(!isGrounded() && radian <= 0) //Fall code
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(radian) * (dist* Time.deltaTime));
            radian -= 0.035f;
        }
        if (radian <=-1 && !isGrounded()) //Gravity cap
        {
            radian = -1;
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(radian) * (dist*Time.deltaTime));
            
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded())//Jump code
        {
            flag = false;
            radian = 1;
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(radian) * (dist*Time.deltaTime));
            temp = Time.time + 0.25f;
            counter = 8;
        }
        if (Input.GetKey(KeyCode.Space) && !isGrounded() && Time.time >= temp && counter !=0)//Rocket Stall code
        {
            rocket_radian = 1;
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(rocket_radian) * (6 * Time.deltaTime));
            temp = Time.time + 0.15f;
            counter--;
            flag = true;
        }
        if(Input.GetKey(KeyCode.A))//Left movement
        {
            transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime), transform.position.y);
            if (speed > -7.5)
                speed -= 0.2f;
        }
        if (Input.GetKey(KeyCode.D))//Right movement
        {
            transform.position = new Vector2(transform.position.x+(speed*Time.deltaTime),transform.position.y);
            if (speed < 7.5)
                speed += 0.2f;
        }
        if (speed != 0 && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) //friction
        {
            
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            if (speed > 0)
            {
                speed -= 0.1f;
            }
            if (speed < 0)
                speed += 0.1f;
            if (speed < 0.1f && speed > -0.1f)
            {
                speed = 0;
            }
        }


    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.down, capsuleCollider.bounds.extents.y + 0.1f, platformLayerMask);
        if (raycastHit.collider!=null)
        {
            if(transform.position.y <= raycastHit.collider.transform.position.y + raycastHit.collider.transform.localScale.y)
            transform.position = new Vector2(transform.position.x, raycastHit.collider.transform.position.y + raycastHit.collider.transform.localScale.y+0.1f);
        }
        return raycastHit.collider !=null;
    }

    private void isWalled()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.left, capsuleCollider.bounds.extents.x + 0.05f, platformLayerMask);
        if(raycastHit.collider!=null)
        {
            if (transform.position.x <= raycastHit.collider.transform.position.x + raycastHit.collider.transform.localScale.x)
            {
                speed = 0;
                transform.position = new Vector2(raycastHit.collider.transform.position.x + raycastHit.collider.transform.localScale.x +0.05f , transform.position.y);
            }
        }
        RaycastHit2D raycastHit2 = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.right, capsuleCollider.bounds.extents.x + 0.05f, platformLayerMask);
        if (raycastHit2.collider != null)
        {
            if (transform.position.x <= raycastHit2.collider.transform.position.x + raycastHit2.collider.transform.localScale.x)
            {
                speed = 0;
                transform.position = new Vector2(raycastHit2.collider.transform.position.x - raycastHit2.collider.transform.localScale.x -0.05f, transform.position.y);
            }
        }

    }
    private void isCeiling()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.up, capsuleCollider.bounds.extents.y + 0.1f, platformLayerMask);
        if (raycastHit.collider != null)
        {
            if (transform.position.y >= raycastHit.collider.transform.position.y + raycastHit.collider.transform.localScale.y)
                transform.position = new Vector2(transform.position.x, raycastHit.collider.transform.position.y - raycastHit.collider.transform.localScale.y - 0.1f);
        }
    }
}
