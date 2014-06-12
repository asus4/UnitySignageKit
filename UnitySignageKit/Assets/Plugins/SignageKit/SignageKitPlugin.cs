using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SignageKitPlugin {
	
	/// <summary>
	/// Easy setup for Signage.
	/// </summary>
	static public void AllEnable() {
		if(Application.platform == RuntimePlatform.OSXPlayer) {
			Application.runInBackground = true;
			Screen.showCursor = false;
			Caffeine(true);
			MenuShow(false);
			WindowBarShow(false);
			SetFrontScreen(true);
		}
		else {
			Debug.Log("SignageKitPlugin.AllEnable don't run in Editor");
		}
	}
	
	static public void AllDisable() {
		if(Application.platform == RuntimePlatform.OSXPlayer) {
			Application.runInBackground = false;
			Screen.showCursor = true;
			Caffeine(false);
			MenuShow(true);
			WindowBarShow(true);
			SetFrontScreen(false);
		}
		else {
			Debug.Log("SignageKitPlugin.AllDisable don't run in Editor");
		}
	}
	
	/// <summary>
	/// Caffeine, if true, application Never sleep, Never run screensaver
	/// </summary>
	/// <param name="enable">If set to <c>true</c> enable.</param>
	static public void Caffeine(bool enable) {
		#if UNITY_STANDALONE_OSX
		unity_littleCaffeine(enable);
		#endif
	}
	
	/// <summary>
	/// Toggle native window title bar
	/// </summary>
	/// <param name="show">If set to <c>true</c> show.</param>
	static public void WindowBarShow(bool show) {
		#if UNITY_STANDALONE_OSX
		unity_windowBarShow(show);
		#endif
	}
	
	/// <summary>
	/// Toggle native menu bar
	/// </summary>
	/// <param name="show">If set to <c>true</c> show.</param>
	static public void MenuShow(bool show) {
		#if UNITY_STANDALONE_OSX
		unity_menuShow(show);
		#endif
	}
	
	/// <summary>
	/// Set window position, size
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <param name="w">The width.</param>
	/// <param name="h">The height.</param>
	static public void WindowPosition(float x, float y, float w, float h) {
		#if UNITY_STANDALONE_OSX
		unity_windowPosition(x, y, w, h);
		#endif
	}
	
	/// <summary>
	///  Set window priority. When true, Application become front than Docs, Any popups
	/// </summary>
	/// <param name="front">If set to <c>true</c> front.</param>
	static public void SetFrontScreen(bool front) {
		#if UNITY_STANDALONE_OSX
		unity_setFrontScreen(front);
		#endif
	}
	
	/// <summary>
	/// Fullscreen
	/// </summary>
	/// <param name="index">Screen Index.</param>
	static public void FullAtScreen(uint index) {
		#if UNITY_STANDALONE_OSX
		unity_fullAtScreen(index);
		#endif
	}
	
	/// <summary>
	/// Become fullscreen, however multiscreen
	/// </summary>
	static public void FullAllScreen() {
		#if UNITY_STANDALONE_OSX
		unity_fullAllScreen();
		#endif
	}

	#if UNITY_STANDALONE_OSX
	[DllImport("SignageKit")]
	private static extern void unity_littleCaffeine(bool enable);
	[DllImport("SignageKit")]
	private static extern void unity_windowBarShow(bool show);
	[DllImport("SignageKit")]
	private static extern void unity_menuShow(bool show);
	[DllImport("SignageKit")]
	private static extern void unity_windowPosition(float x, float y, float w, float h);
	[DllImport("SignageKit")]
	private static extern void unity_setFrontScreen(bool front);
	[DllImport("SignageKit")]
	private static extern void unity_fullAtScreen(uint index);
	[DllImport("SignageKit")]
	private static extern void unity_fullAllScreen();
	#endif	
}