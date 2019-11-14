using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialPin : MonoBehaviour
{
    private bool isEnd = false;
    public float speed = 3f;
    public Rigidbody2D rb;

    public GameObject particleSystem;

    System.Random random = new System.Random(1000);

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Rotator")
        {
            isEnd = true;
            Destroy(gameObject);
        }
        else if (col.tag == "Pin")
        {
            int randomNumber = Random.Range(1, 6);
            FindObjectOfType<audioManager>().Play("glass" + randomNumber);
            Debug.Log("Random glass sound source: " + randomNumber);

            Vector3 collisionPoint = new Vector3();
            collisionPoint = transform.position;
            Quaternion c_rotation = new Quaternion();
            GameObject _Explode = Instantiate(particleSystem, collisionPoint, c_rotation);

            Destroy(col.gameObject);
        }
    }


}
