using UnityEngine;
using System.Collections;

public class ActivateCamera : MonoBehaviour {

	void Start(){
//		Vector3 scale = transform.localScale;
//		scale.x = 22;
//		scale.y = 12;
//		transform.localScale = scale;

		WebCamTexture cam = new WebCamTexture();
		renderer.material.mainTexture = cam;
		//renderer.material.shader = Shader.Find("Mobile/Unlit (Supports Lightmap)");
		cam.Play();
	}
}
