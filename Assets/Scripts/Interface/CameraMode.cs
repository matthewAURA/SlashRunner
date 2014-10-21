using UnityEngine;
using System.Collections;

public class CameraMode : MonoBehaviour {

//	public bool cameraMode;
	public GameObject cube;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera");

		if (PlayerPrefs.GetInt ("CameraMode")==1) {
			//cameraMode = true;	
			Vector3 cubePos = new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y,82);
//			Vector3 cubeRot = new Vector3(mainCamera.transform.rotation.x,mainCamera.transform.rotation.y,180);
			Quaternion cubeRot = new Quaternion(mainCamera.transform.rotation.x,mainCamera.transform.rotation.y,180,0);
			(Instantiate(cube,cubePos,cubeRot) as GameObject).transform.parent = mainCamera.transform;

//			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			cube.transform.position = new Vector3(0, 0, 82);
//			cube.transform.localScale = new Vector3(45,30,1);
//			cube.transform.parent = GameObject.Find("Main Camera").transform;
		} else {
			//cameraMode = false;		
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (cameraMode);
	}
}
