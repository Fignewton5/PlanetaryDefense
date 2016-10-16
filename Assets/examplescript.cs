using UnityEngine;
using System.Collections;

public class examplescript : MonoBehaviour {

	IEnumerator Start() {
		StartCoroutine("DoSomething", 2.0F);
		yield return new WaitForSeconds(3);
		StopCoroutine("DoSomething");
	}
	IEnumerator DoSomething(float someParameter) {
		int n = 0;
		while (true) {
			print("DoSomething Loop" + "" + n);
			n++;
			yield return true;
		}
	}
}
