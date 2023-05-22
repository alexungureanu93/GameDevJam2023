using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFollowMouse : MonoBehaviour {

	public Transform Player;
	public Transform Sword;

	public float distanceSword = 1f;
	public float heightSword = 0.7f;
	public float speedSword = 10f;

	void Update () {
		Vector3 pos = GetMousePosition();
		Vector3 offset = new Vector3(0, heightSword, 0);
		Vector3 targetPosition = offset + Player.position + (Vector3.ClampMagnitude(pos - Player.position,distanceSword));//(Vector3.Normalize(
		Vector3.MoveTowards(transform.position, targetPosition, speedSword * Time.deltaTime);
		//float angle = Vector2.SignedAngle(Vector2.right, pos - Player.position);
		//      Sword.eulerAngles = new Vector3(0, 0, angle);
	}

  public static Vector2 GetMousePosition() {
		if (Camera.main == null) {
			return(Vector2.zero);
		}
		return(Camera.main.ScreenToWorldPoint (Input.mousePosition));
	}
}
