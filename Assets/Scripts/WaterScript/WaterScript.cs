using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.CompareTag("Player")) {
			PlayerDamage pd = target.GetComponent<PlayerDamage>();
			if (pd != null) {
				pd.DealDamage();
			}
		}
	}

} // class