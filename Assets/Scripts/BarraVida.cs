using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour {

	private Image ren;
	private float vida, scale;
	public Vector3 color;
	public Color maxHPColor = new Color (255/255f,63/255f, 63/255f);
	public Color minHPColor = new Color (64/255f, 137/255f, 255/255f);

	// Use this for initialization
	void Start () {
		ren = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F))
			SystemVar.SystemVar.vidaPlayer -= 1f;
		vida = SystemVar.SystemVar.vidaPlayer;
		//Debug.Log (vida);

		scale = ren.fillAmount;
		scale = (vida / 500f);
		ren.fillAmount = scale;

		//Debug.Log (this.transform.localScale);


		ren.color = Color.Lerp (maxHPColor, minHPColor, (vida/500f));
	}
}
