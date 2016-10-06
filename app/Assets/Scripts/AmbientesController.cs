using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientesController : MonoBehaviour {

	List<GameObject> ambientes;
	int posicionActual = 0;

	void Start(){
		ambientes = new List<GameObject>();
		foreach(Transform t in GetComponentsInChildren<Transform>()){
			if(t.name == "Grass" || t.name == "Desert" || t.name == "Snow"){
				print("-------------------- Se agrego " + t.name);
				ambientes.Add(t.gameObject);
				t.gameObject.SetActive(false);
			}
		}
		ambientes[posicionActual].SetActive(true);
	}

	public void CambiarAmbiente(){
		ambientes[posicionActual].SetActive(false);
		posicionActual = (posicionActual + 1) % ambientes.Count;
		ambientes[posicionActual].SetActive(true);
	}
}
