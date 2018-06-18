using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	private float fireWait = 0.06f;
	private float nextFire;
	private Vector3 offset = Vector3.zero;
	private Vector3 oriPos;

	public Vector3 rotOffset;
	public Vector3 oriRot;

	public GameObject playerNeck;

	public float recoilValue;

	private float timeOfShot;
	// Use this for initialization
	void Start () {
	
		oriPos = transform.localPosition;

		//oriRot = transform.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
	
		//recoilValue = Mathf.Lerp(recoilValue,0, Time.deltaTime * 4 );
		recoilValue = Mathf.Lerp(recoilValue,0, Time.time - timeOfShot);

		//playerNeck.transform.eulerAngles = oriRot + rotOffset;

		//rotOffset = Vector3.Lerp(rotOffset,Vector3.zero,0.1f);
		rotOffset = Vector3.zero;
		offset.z = Mathf.Clamp(offset.z, -0.25f, 0);

		transform.localPosition = oriPos + offset;

		//offset = Vector3.Lerp(offset,Vector3.zero,0.1f);
		offset = Vector3.Lerp(offset,Vector3.zero,Time.time - timeOfShot);

		if(Input.GetButton("Fire1") && Time.time > nextFire){

			timeOfShot=Time.time;

			recoilValue += 3f;

			offset += new Vector3(0,0,-0.2f);

			//rotOffset += new Vector3(1,0,0);
			rotOffset = new Vector3(1,0,0);
			nextFire = Time.time + fireWait;
		}

		
		recoilValue = Mathf.Clamp(recoilValue,0,70);

	}
}
