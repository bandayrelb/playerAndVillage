using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Animation drawBow;
    private bool isDraw = false;
    public int arrowSpeed;
    public Rigidbody arrow;
    public Transform bow;
    public Rigidbody clone;
    public Transform arrowSpawn;

	void Start () {
        drawBow = GetComponent<Animation>();
        drawBow["drawBow"].layer = 1;
        drawBow["returnBow"].layer = 2;
        drawBow["drawBow"].wrapMode = WrapMode.Once;
        drawBow["pullBowClip"].wrapMode = WrapMode.Once;
        drawBow["returnBow"].wrapMode = WrapMode.Once;
	}
	
	void Update () {

	    if(Input.GetButton("Fire1") && isDraw == false)
        {
            clone = (Rigidbody)Instantiate( arrow, arrowSpawn.position, transform.rotation );
            clone.transform.parent = transform;
            drawBow.Play( "pullBowClip" );
            drawBow.Play("drawBow");
            isDraw = true;
        }

        if(!Input.GetButton("Fire1") && isDraw == true)
        {
            clone.transform.parent = null;
            drawBow.Stop();
            drawBow.Play("bowIdle");
            drawBow.Play( "returnBow" );
            clone.constraints = RigidbodyConstraints.None;
            clone.velocity = transform.forward * arrowSpeed;
            isDraw = false;
        }
	}
}