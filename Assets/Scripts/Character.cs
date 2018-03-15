using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected void OnCollisionEnter(Collision other)
    {
        int otherLayer = other.gameObject.layer;

        if (otherLayer == LayerMask.NameToLayer("Bullet"))
        {
            die();
        }

        Destroy(gameObject);
    }
    public abstract void Shoot();
    public abstract void die();

}
