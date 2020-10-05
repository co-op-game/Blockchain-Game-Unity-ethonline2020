using UnityEngine;

public class BillBoard : MonoBehaviour {


	public Camera localcam;
	void Update () {
		transform.LookAt (localcam.transform);

		//needs to be updated to local active camera.


	}

}
