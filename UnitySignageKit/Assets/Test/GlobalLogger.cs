using UnityEngine;
using System.Collections.Generic;

namespace Debugger {
	/// <summary>
	/// Global GUI Logger.
	/// </summary>
	[RequireComponent(typeof(GUIText))]
	[AddComponentMenu("Debugger/GlobalLogger")]
	public class GlobalLogger : MonoBehaviour {
		
		[SerializeField]
		int linesCount = 20;
		
		GUIText gui;
		Queue<string> logQueue;
		
		void OnEnable() {
			logQueue = new Queue<string>();
			gui = GetComponent<GUIText>();
			
			// 
			Application.RegisterLogCallback(LogCallback);
		}
		
		void OnDisable() {
			Application.RegisterLogCallback(null);
		}
		
		
		// delegate for Log
		void LogCallback (string condition, string stackTrace, LogType type) {
			
			if(type == LogType.Warning) {
				// yellow color
				condition = "<color=#ffff00ff>" + condition + "</color>";
			}
			else if(type == LogType.Error || type == LogType.Exception) {
				// red color
				condition = "<color=#ff0000ff>" + condition + "</color>";
			}
			
			logQueue.Enqueue(condition + "\n");
			
			while(logQueue.Count > linesCount) {
				logQueue.Dequeue();
			}
			
			string logs = "====LOG====\n";
			foreach(string str in logQueue) {
				logs += str;
			}
			
			gui.text = logs;
		}
	}
}
