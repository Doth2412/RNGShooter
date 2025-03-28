using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
	public RawImage img;
	public float x, y;

	// Update is called once per frame
	void Update()
	{
		img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
	}
}
