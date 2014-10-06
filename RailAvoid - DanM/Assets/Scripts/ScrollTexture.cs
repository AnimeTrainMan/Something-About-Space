using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour
{
	public Vector2 scrollSpeed = Vector2.one;
	private Material not;

	void Start(){
		not = renderer.material;
	}

	// Update is called once per frame
	void Update () {
		not.mainTextureOffset += scrollSpeed * Time.deltaTime;
	}
}
