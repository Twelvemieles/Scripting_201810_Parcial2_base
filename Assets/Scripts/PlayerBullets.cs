using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : Bullet {
    private float pos;
    public override void Efectobala()
    {
        //destruirEnemigo

    }
    // Use this for initialization
    void Start () {
        pos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        pos += 0.2f;
        transform.position = new Vector3(transform.position.x,pos,transform.position.z) ;
	}
}
