using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory(ActionCategory.Physics2D)]
public class Coliision2DEventWithoutTag : FsmStateAction
{

		//[Tooltip("The type of collision to detect.")]
		public Collision2DType collision;



		[Tooltip("Event to send if a collision is detected.")]
		public FsmEvent sendEvent;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the GameObject that collided with the Owner of this FSM.")]
		public FsmGameObject storeCollider;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the force of the collision. NOTE: Use Get Collision 2D Info to get more info about the collision.")]
		public FsmFloat storeForce;

		public override void Reset()
		{
			collision = Collision2DType.OnCollisionEnter2D;
			sendEvent = null;
			storeCollider = null;
			storeForce = null;
		}

		public override void OnPreprocess()
		{
			switch (collision)
			{
			case Collision2DType.OnCollisionEnter2D:
				Fsm.HandleCollisionEnter2D = true;
				break;
			case Collision2DType.OnCollisionStay2D:
				Fsm.HandleCollisionStay2D = true;
				break;
			case Collision2DType.OnCollisionExit2D:
				Fsm.HandleCollisionExit2D = true;
				break;
			case Collision2DType.OnParticleCollision:
				Fsm.HandleParticleCollision = true;
				break;
			}

		}

		void StoreCollisionInfo(Collision2D collisionInfo)
		{
			storeCollider.Value = collisionInfo.gameObject;
			storeForce.Value = collisionInfo.relativeVelocity.magnitude;
		}

		public override void DoCollisionEnter2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionEnter2D)
			{
				
					StoreCollisionInfo(collisionInfo);
					Fsm.Event(sendEvent);

			}
		}

		public override void DoCollisionStay2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionStay2D)
			{
				
					StoreCollisionInfo(collisionInfo);
					Fsm.Event(sendEvent);

			}
		}

		public override void DoCollisionExit2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionExit2D)
			{
				
					StoreCollisionInfo(collisionInfo);
					Fsm.Event(sendEvent);

			}
		}

		public override void DoParticleCollision(GameObject other)
		{
			if (collision == Collision2DType.OnParticleCollision)
			{
				
					if (storeCollider != null)
						storeCollider.Value = other;

					storeForce.Value = 0f; //TODO: impact force?
					Fsm.Event(sendEvent);

			}
		}

		public override string ErrorCheck()
		{
			return ActionHelpers.CheckOwnerPhysics2dSetup(Owner);
		}


}

}
