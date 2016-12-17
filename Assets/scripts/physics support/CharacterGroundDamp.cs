using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;
using DataType;

public class CharacterGroundDamp : MonoBehaviour {
	public PlayMakerFSM dataHolder;
	public PlayMakerFSM whereHolder;
	public PlayMakerFSM movementHolder;
	Rigidbody2D rigid;
	// Use this for initialization
	void OnEnable() {
//		PlayMakerFSM[] fsms = GetComponents<PlayMakerFSM> ();
//		foreach (PlayMakerFSM fsm in fsms) {
//			if (fsm.FsmName == "platform friction") {
//				dataHolder = fsm;
//			}
//
//			if (fsm.FsmName == "where detector") {
//				whereHolder = fsm;
//			}
//		}
		rigid=GetComponent<Rigidbody2D>();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		FsmEnum fe= whereHolder.FsmVariables.FindFsmEnum ("ground type");
		GroundType gt = (GroundType)fe.Value;
		if (whereHolder.FsmVariables.FindFsmBool ("on ground?").Value&&gt==GroundType.Platform) {
			if (!movementHolder.FsmVariables.GetFsmBool ("accelerate?").Value||!movementHolder.enabled) {
				//逼停中
//				print ("force stop");
				float friction=dataHolder.FsmVariables.FindFsmFloat("friction").Value;
				Vector2 normal = dataHolder.FsmVariables.FindFsmVector2 ("touch normal").Value;
				float c = 1;
				if (1 - Mathf.Abs (normal.y) > 0.02f) {
					c = Mathf.Abs (normal.y);
				}
//				print (c);
				Vector2 v = rigid.velocity;
				v=Vector2.MoveTowards (v, Vector2.zero, friction/c);
				rigid.velocity = v;
				if (rigid.velocity == Vector2.zero) {
					rigid.Sleep ();
				}
//				print (rigid.velocity);

			}
			
//			print ("on ground");
		} else {
//			print ("on air");
		}

	}
}
