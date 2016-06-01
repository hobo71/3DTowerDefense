using UnityEngine;
using System.Collections;

public class ObjectSelector : MonoBehaviour {

	public Material selectedMaterial;
	public Material unselectedMaterial;

	private GameObject selectedGameObject;
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f)) {
				GameObject temp = hit.transform.gameObject;
				if (temp.layer == LayerMask.NameToLayer("SelectableObjects")) {
					selectObject(temp);
				}
			}
		}
		if (Input.GetMouseButtonDown(1)) {
			if (selectedGameObject != null) {
				selectedGameObject.GetComponent<Renderer>().material = unselectedMaterial;
				selectedGameObject = null;
			}
		}
	}

	void selectObject(GameObject go) {
		if (selectedGameObject == go) {
			// At first: Do nothing
		} else {
			if (selectedGameObject != null) {
				selectedGameObject.GetComponent<Renderer>().material = unselectedMaterial;
			}
			selectedGameObject = go;
			selectedGameObject.GetComponent<Renderer>().material = selectedMaterial;
		}
	}

}