using UnityEngine;
using System.Collections;

public class Recoil : MonoBehaviour {

	public Gun gunScript;
	private Quaternion oriRot;

	// Use this for initialization
	void Start () {
	
		oriRot = transform.localRotation;

	}
	
	// Update is called once per frame
	void Update () {
	

		Quaternion recoilQua = Quaternion.AngleAxis(-gunScript.recoilValue,Vector3.right);

		transform.localRotation = oriRot * recoilQua;

	}
}
