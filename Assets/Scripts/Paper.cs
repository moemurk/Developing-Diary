using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paper", menuName = "Paper")]
public class Paper : ScriptableObject
{
    public string title, ab;
    public List<Figure> figures;
}
