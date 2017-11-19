using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodManager : MonoBehaviour {

	public GameObject bloodPrefab;

	public void AddBlood(Vector3 position, Quaternion rotation, Vector3 scale) {
		var blood = Instantiate(bloodPrefab, position, rotation);
		blood.transform.localScale = scale * 1.3f;
	}
}
