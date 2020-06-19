using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittlePad : MonoBehaviour
{
	public List<Figure> figureLittle;
	public Canvas littlePadScreen;
	public GameObject figureItem;
	public LargePad lpp;

	public void DownloadFigure(Figure fi){
		if (figureLittle.Contains(fi)){
			return;
		}
		figureLittle.Add(fi);
		GameObject image = littlePadScreen.gameObject.transform.GetChild(0).GetChild(0).gameObject;
		GameObject tmp = Instantiate(figureItem, image.transform);
		tmp.GetComponent<RectTransform>().sizeDelta = new Vector2 (100f, 100f);
        tmp.GetComponent<Image>().sprite = fi.img;
        tmp.GetComponent<FigureItem>().f = fi;
        tmp.GetComponent<Button>().onClick.AddListener(() => { 
        	if (lpp.UploadFigure(fi) == 1){
        		Destroy(tmp);
        		figureLittle.Remove(fi);
        	}
        	 });
        	}

	}