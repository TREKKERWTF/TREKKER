using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class PlayerSpeedLimitation : SpeedLimitation {
	public float maxCrouchSpeed=1.5f;
	public float maxRunSpeed;
	public PlayMakerFSM fsm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		FsmVariables glbv = FsmVariables.GlobalVariables;
		maxWalkSpeed = glbv.FindFsmFloat ("行走最大速度").Value;
		maxCrouchSpeed = glbv.FindFsmFloat ("下蹲最大速度").Value;
		maxRunSpeed = glbv.FindFsmFloat ("奔跑最大速度").Value;
		base.Update ();

		if (rigidBody2d) {
			Vector2 velocity = rigidBody2d.velocity;
			float spx = velocity.x;
//			float spy = velocity.y;
			if (fsm.enabled) {
				FsmBool crouch = fsm.FsmVariables.GetFsmBool ("crouch?");
				if (crouch.Value) {
//					print ("crouching");
					if (spx > maxCrouchSpeed) {
						velocity.x = maxCrouchSpeed;
						rigidBody2d.velocity = velocity;
					}
					if (spx < -maxCrouchSpeed) {
						velocity.x = -maxCrouchSpeed;
						rigidBody2d.velocity = velocity;
					}
				}
			}
		}
	}
}
