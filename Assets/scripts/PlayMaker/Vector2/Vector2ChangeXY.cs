using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory(ActionCategory.Vector2)]
public class Vector2ChangeXY : FsmStateAction
{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The vector2 to change")]
		public FsmVector2 vector2;
		public override void Reset()
		{
			vector2 = null;
		}
	// Code that runs on entering the state.
	public override void OnEnter()
	{
			float d = vector2.Value.x;
			Vector2 v = vector2.Value;
			v.x= v.y;
			v.y = d;
			vector2.Value = v;
		Finish();
	}


}

}
