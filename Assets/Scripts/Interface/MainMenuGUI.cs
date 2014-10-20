using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class MainMenuGUI : MonoBehaviour {
    public GUISkin GuiSkin;
    public GUISkin SignInButtonGuiSkin;
    public Texture2D GooglePlusTex;
    public Texture2D SignInBarTex;
    public AudioClip UiBeepFx;
    private static bool sAutoAuthenticate = true;


    // void Beep() {
    //     AudioSource.PlayClipAtPoint(UiBeepFx, Vector3.zero);
    // }

    void Start() {
        // if this is the first time we're running, bring up the sign in flow
        if (sAutoAuthenticate) {
            GameManager.Instance.Authenticate();
            sAutoAuthenticate = false;
        }
    }

    void OnGUI() {
        
    }
}
