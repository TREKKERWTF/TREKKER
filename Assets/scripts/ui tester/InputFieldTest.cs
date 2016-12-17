using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum TraceType{
	walk,
	crouch,
	drop
}

public class InputFieldTest : MonoBehaviour {
	public TraceType traceType = TraceType.walk;
	public PlayerSpeedLimitation player;
	InputField field;
	// Use this for initialization
	void Start () {
		field = GetComponent<InputField> ();
		float startValue=0;
		switch (traceType) {
		case TraceType.walk:
			{
				startValue = player.maxWalkSpeed;
				break;
			}
		case TraceType.drop:
			{
				startValue = player.maxDropSpeed;
				break;
			}
		case TraceType.crouch:
			{
				startValue = player.maxCrouchSpeed;
				break;
			}
		default:
			{
				break;
			}
		}
		field.text = startValue.ToString ();
	}
	public void onSubmit(){
		float v = float.Parse (field.text);
		switch (traceType) {
		case TraceType.walk:
			{
				 player.maxWalkSpeed=v;
				break;
			}
		case TraceType.drop:
			{
				player.maxDropSpeed=v;
				break;
			}
		case TraceType.crouch:
			{
				player.maxCrouchSpeed=v;
				break;
			}
		default:
			{
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
