using UnityEngine;

public class ControlableChara : MonoBehaviour, ISelectable
{
    public SelectionCircle selectionObj;
    public Color selectionColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        selectionObj.Show();
        Debug.Log(name + " selected");
    }
    
    public void Diselect()
    {
        selectionObj.Hide();
        Debug.Log(name + " diselected");
    }
}