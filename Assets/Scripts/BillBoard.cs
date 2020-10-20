using UnityEngine;

public class BillBoard : MonoBehaviour {

	void Update () {
		if(Camera.current != null)
		{
			transform.LookAt(Camera.current.transform);
		}
	}

}
