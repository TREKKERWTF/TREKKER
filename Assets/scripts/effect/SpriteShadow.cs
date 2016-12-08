using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class SpriteShadow : MonoBehaviour {
	public ShadowCastingMode castShadow=ShadowCastingMode.Off;
	public bool receiveShadow=false;
	SpriteRenderer sprr;
	void Awake(){
		sprr = GetComponent<SpriteRenderer> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable()  
	{  
		sprr.shadowCastingMode = castShadow;
		sprr.receiveShadows = receiveShadow;
	}  
}
