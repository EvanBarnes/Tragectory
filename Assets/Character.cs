using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool a;
    private bool d;
    private bool w;
    private bool s;
    
    public Object prefab1;
    public Transform tr1;
    private Vector3 v31;
    private Quaternion qt1;
    private float relmousex;
    private float relmousey;
    private float mousex;
    private float mousey;
    public bool check = false;
    public Vector4 v41;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //moveChar();
        shoot();
        moveChar();
        
        


    }
    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            v31[0] = transform.position.x;
            v31[1] = transform.position.y;

            GameObject bullet = Instantiate(prefab1, v31, qt1) as GameObject;
            Physics.IgnoreCollision(bullet.transform.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    //checks for key presses
    void moveChar() {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * 4);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 4);
        }

    }
    
}
;