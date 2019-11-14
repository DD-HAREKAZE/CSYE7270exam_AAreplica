using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject pinPrefab;
    public GameObject specialPinPrefab;
    public bool isSpecialPin;
    public int remainingSP;
    public GameObject background;

    public Text isSpecialPinText;
    public Text SPNum;

    public GameObject particleSystem;

    public Shader newShader;


    Color SuperPinBlue = new Color(0.578125f, 0.609375f, 0.89453125f, 1);
    Color SpawnPointBlack = new Color(0, 0, 0, 1);

    void Start() 
    {
        isSpecialPin = false;
        remainingSP = 3;
    }

	void Update ()
	{
        SPNum.text = remainingSP.ToString();
        if (remainingSP <= 0) 
        {
            isSpecialPin = false;
        }
		if (Input.GetButtonDown("Fire1"))
		{
            if (isSpecialPin == false) { SpawnPin(); }
            else 
            {
                if (remainingSP > 0) 
                {
                    //fire a special pin!
                    remainingSP = remainingSP - 1;
                    SpawnSpecialPin(); 
                    //end fire a special pin!
                    background.GetComponent<SpriteRenderer>().material.shader=newShader;
                    Debug.Log(background.GetComponent<SpriteRenderer>().material.shader.ToString());
                }
                
            }
			
		}
        if (Input.GetButtonDown("Fire2"))
        {
            isSpecialPin = !isSpecialPin;
            
        }
        switch (isSpecialPin) 
        {
            case true:
                isSpecialPinText.color = Color.red;
                isSpecialPinText.text = "Yes";
                this.gameObject.GetComponent<SpriteRenderer>().color = SuperPinBlue;
                break;
            case false:
                isSpecialPinText.color = Color.black;
                isSpecialPinText.text = "No";
                this.gameObject.GetComponent<SpriteRenderer>().color = SpawnPointBlack;
                break;
        }
	}

	void SpawnPin ()
	{
		Instantiate(pinPrefab, transform.position, transform.rotation);
	}

    void SpawnSpecialPin()
    {
        Instantiate(specialPinPrefab, transform.position, transform.rotation);
        Vector3 collisionPoint = new Vector3();
        collisionPoint = transform.position;
        Quaternion c_rotation = new Quaternion();
        GameObject _Explode = Instantiate(particleSystem, collisionPoint, c_rotation);
        FindObjectOfType<audioManager>().Play("fire");
    }

}
