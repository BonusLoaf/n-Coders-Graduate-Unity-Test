using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{

    Rigidbody2D rigidbody;
    public GameObject cannon;
    public GameObject cannonEnd;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        basicMovement();
        cannonAim();
        shoot();

    }

    void basicMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector2(-100, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector2(100, 0));
        }

        rigidbody.velocity = new Vector2(0, 0);
    }

    void cannonAim()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cannon.transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cannon.transform.Rotate(new Vector3(0, 0, -0.1f));
        }
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, cannon.transform.position, cannon.transform.rotation);
        }
    }

}
