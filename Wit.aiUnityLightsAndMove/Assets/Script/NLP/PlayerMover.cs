using UnityEngine;
using System;
namespace UnityHttpReq
{
	public class PlayerMover : MonoBehaviour
	{
		private static string direction = "";
		private static float value = 0F;
		private static string unit = "";

		private static bool move = false;

		public GameObject player;
		public float speed;

		public static void startMovement(string dir, float val, string U)
		{
			direction = dir;
			value = val;
			unit = U;

			if (val == 0)
				value = 10000;
			else {
				if (unit.Equals ("centimetre"))
					value = value / 100;

				if (direction.Equals ("backwards") || direction.Equals ("backwards"))
					value = -value;
			}
			move = true;
		}

		public static void stopMovement()
		{
			move = false;
		}


		void FixedUpdate()
		{
			if (move) {

				float moveHorizontal = value*100;
				float moveVertical = Input.GetAxis ("Vertical");		
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				
				Rigidbody rb = player.GetComponent<Rigidbody> ();
				rb.AddForce (movement * speed * Time.deltaTime);

			}

		}

	}
}

