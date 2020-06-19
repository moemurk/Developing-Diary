using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LargePad : MonoBehaviour
{
	public List<Figure> figureLarge;
	public List<GameObject> nineStatus;
	public Canvas largePadScreen;
	public GameObject figureItem;
	public GameObject selectedFigure;
	public LittlePad lp;


    public int UploadFigure(Figure fii){
    	if (figureLarge.Contains(fii)){
			return 0;
		}
		figureLarge.Add(fii);
		GameObject tmp = null;
		foreach(GameObject number in nineStatus){
			if(number.GetComponent<FigureItem>().f == null){
				tmp = number;
				break;
			}
		}
		if (tmp == null){
			return 0;
		}
		GameObject image = largePadScreen.gameObject.transform.GetChild(0).gameObject;
		//GameObject tmp = Instantiate(figureItem, image.transform);
		//tmp.GetComponent<RectTransform>().sizeDelta = new Vector2 (100f,100f);
		tmp.GetComponent<Image>().sprite = fii.img;
		tmp.GetComponent<FigureItem>().f = fii;
		var tmpColor = tmp.GetComponent<Image>().color;
		tmpColor.a = 1f;
		tmpColor.r = 1f;
		tmpColor.g = 1f;
		tmpColor.b = 1f;
		tmp.GetComponent<Image>().color = tmpColor;
		//tmp.AddComponent<ButtonDetact>();
		//tmp.GetComponent<ButtonDetact>().lpp = this;
		return 1;
    }

    public void Start(){
    	selectedFigure = null;

    }

    public void Transport(GameObject item){
    	//when click, call this function
    	if (selectedFigure == null){
    		selectedFigure = item;
    		item.transform.Translate(-0.05f*Vector3.forward);
    	}
    	else if (selectedFigure == item){
    		if (item.GetComponent<FigureItem>().f == null){
    			item.transform.Translate(0.05f*Vector3.forward);
    			selectedFigure = null;
    			return;
    		}
    		lp.DownloadFigure(item.GetComponent<FigureItem>().f);
    		item.GetComponent<Image>().sprite = null;
    		figureLarge.Remove(item.GetComponent<FigureItem>().f);
    		item.GetComponent<FigureItem>().f = null;
    		item.transform.Translate(0.05f*Vector3.forward);
    		//selectedFigure.transform.Translate(0.05f*Vector3.forward);
    		var tmpColor = item.GetComponent<Image>().color;
    		tmpColor.a = 0.4039f;
    		tmpColor.r = 0.9150f;
    		tmpColor.g = 0f;
    		tmpColor.b = 0.0535f;
    		item.GetComponent<Image>().color = tmpColor;
    		selectedFigure = null;
    	}
    	else {
    		//item.transform.Translate(-0.05f*Vector3.forward);
    		selectedFigure.transform.Translate(0.05f*Vector3.forward);
    		Sprite sprite_n = selectedFigure.GetComponent<Image>().sprite;
    		selectedFigure.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
    		item.GetComponent<Image>().sprite = sprite_n;
    		Figure f_n = selectedFigure.GetComponent<FigureItem>().f;
    		selectedFigure.GetComponent<FigureItem>().f = item.GetComponent<FigureItem>().f;
    		item.GetComponent<FigureItem>().f = f_n;
    		Color color = selectedFigure.GetComponent<Image>().color;
    		selectedFigure.GetComponent<Image>().color = item.GetComponent<Image>().color;
    		item.GetComponent<Image>().color = color;
    		selectedFigure = null;
    	}
    }

}
