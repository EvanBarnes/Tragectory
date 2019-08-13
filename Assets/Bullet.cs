using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int count = 0;
    public int width;
    public int height;
    public GameObject tr1;
    private float relmousex;
    private float relmousey;
    public float mousex;
    public float mousey;
    public float thetarad;
    private int colcount;
    public float thetadeg;
    private bool orient;
    private float lockPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("spawned");
        width = Screen.width;
        height = Screen.height;
        mousex = Input.mousePosition.x;
        mousey = Input.mousePosition.y;

        relmousex = ((width/2 - Input.mousePosition.x));
        relmousey = ((height/2 - Input.mousePosition.y));
        thetarad = (Mathf.Atan((relmousex / relmousey)));
        thetadeg = (thetarad * (180 / Mathf.PI));
        if (relmousey > 0)
        {
            if (relmousex > 0)
            {
                //tbd quad 3
                lockPos = 180 - thetadeg;
                transform.Rotate(new Vector3(0, 0, lockPos));
            }
            else
            {
                //quadrent 4
                lockPos = 180 - thetadeg;
                transform.Rotate(new Vector3(0, 0, lockPos));
            }
        }
        else
        {
            if (relmousex > 0)
            {
                //quadrent 2
                lockPos = 0 - thetadeg;
                transform.Rotate(new Vector3(0, 0, lockPos));
            }
            else
            {
                //quadrent 1
                lockPos = 0 - thetadeg;
                transform.Rotate(new Vector3(0, 0, lockPos));
            }
        }
        if(colcount > 3)
        {
            DestroyObject(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(tr1.transform.GetComponent<Collider>(), GetComponent<Collider>());
        if (count > 60)
        {
            //Destroy(gameObject);
        }
        
        transform.Translate(Vector2.up * Time.deltaTime * 4);
    }
    void OnCollisionStay()
    {
    }
        private void OnCollisionEnter(Collision collision)
    {
       
        Debug.Log("collided");
        if (collision.gameObject.tag == "wall")
        {
            //Radians to Degrees
            colcount++;
            float f = (transform.rotation.w * (180 / Mathf.PI));
            lockPos = 180+f;
        
            transform.Rotate(new Vector3(0, 0, lockPos));
        }
        
            
        
    }
}
