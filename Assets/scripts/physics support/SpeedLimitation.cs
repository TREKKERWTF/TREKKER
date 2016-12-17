using UnityEngine;
using System.Collections;


public class SpeedLimitation : MonoBehaviour {
	public float maxWalkSpeed = 3;
	public float maxDropSpeed=6;
	protected Rigidbody2D rigidBody2d;
	void Awake(){
		rigidBody2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (rigidBody2d) {
			Vector2 velocity = rigidBody2d.velocity;
			float spx = velocity.x;
			float spy = velocity.y;
			if (spx > maxWalkSpeed) {
				velocity.x = maxWalkSpeed;
				rigidBody2d.velocity = velocity;
			}
			if (spx < -maxWalkSpeed) {
				velocity.x = -maxWalkSpeed;
				rigidBody2d.velocity = velocity;
			}
			if (spy < -maxDropSpeed) {
				velocity.y = -maxDropSpeed;
				rigidBody2d.velocity = velocity;
			}
//			print (rigidBody2d.velocity);
		}
	}
}
