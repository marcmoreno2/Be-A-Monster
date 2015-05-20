using UnityEngine;
using System.Collections;

public class csAjusteGUI : MonoBehaviour {

	public Vector2 ResolucionGUI;
	public Vector2 CentroGUI;
	
	private float oldWidth,oldHeight,temp,escala;
	private Quaternion rotacion  = Quaternion.identity;
	private Vector2 oldResolucion;
	private Vector2 oldCentro;
	private Vector2 centro = new Vector2();

	void guiUpdate(){		
		
		if(Screen.width/ResolucionGUI.x>Screen.height/ResolucionGUI.y){
			
			escala = Screen.height / ResolucionGUI.y; //Mantenemos relacion de aspecto respecto a la altura
			temp = Screen.width/escala; //Ancho real
			centro.x = (CentroGUI.x/ResolucionGUI.x*temp-CentroGUI.x)*escala;
			centro.y = 0;
			
		} else {
			
			escala = Screen.width / ResolucionGUI.x; //Mantenemos relacion de aspecto respecto a la anchura
			temp = Screen.height/escala; //Altura real
			centro.x = 0;
			centro.y = (CentroGUI.y/ResolucionGUI.y*temp-CentroGUI.y)*escala;
			
		}
		
		Gui.matrix = Matrix4x4.TRS(new Vector3(centro.x,centro.y,0),rotacion,new Vector3(escala,escala,1));
		Gui.matrixScale = Matrix4x4.Scale(new Vector3(Screen.width/ResolucionGUI.x,Screen.height/ResolucionGUI.y,1));		
		
	}

	void Awake () {

		guiUpdate();
		oldWidth = Screen.width;
		oldHeight = Screen.height;
		oldResolucion = ResolucionGUI;
		oldCentro = CentroGUI;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(oldWidth!=Screen.width || oldHeight!=Screen.height
		   || oldResolucion!=ResolucionGUI || oldCentro!=CentroGUI){
			
			guiUpdate();
			oldWidth = Screen.width;
			oldHeight = Screen.height;
			oldResolucion = ResolucionGUI;
			oldCentro = CentroGUI;
			
		}

	}
}

static public class Gui{ //Globales

	static public Matrix4x4 matrix; //Mantener aspecto
	static public Matrix4x4 matrixScale; //No mantener aspecto

}
