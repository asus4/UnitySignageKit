using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	IEnumerator Start() {
		// Wait  for GL initailizing
		yield return new WaitForSeconds(1.0f);
		SignageKitPlugin.WindowPosition(10, 10, 500, 400);
		yield return new WaitForSeconds(1.0f);
		// Easy enable
		SignageKitPlugin.AllEnable();
		SignageKitPlugin.FullAllScreen();
	}
	
	void OnDisable() {
		// Easy disable
		SignageKitPlugin.AllDisable();
	}
	
	void OnGUI() {
		if(GUILayout.Button("Full At Window 0")) {
			SignageKitPlugin.FullAtScreen(0);
		}
		
		if(GUILayout.Button("Full At Window 1")) {
			SignageKitPlugin.FullAtScreen(1);
		}
		
		if(GUILayout.Button("Full All Screens")) {
			SignageKitPlugin.FullAllScreen();
		}
		
		if(GUILayout.Button("Custom Window Size")) {
			SignageKitPlugin.WindowPosition(10, 10, 500, 400);
		}
	}
	
}