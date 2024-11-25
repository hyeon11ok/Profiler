using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Sprite itemInfo;
    private string itemName;

    public Sprite ItemInfo {  get { return itemInfo; } }
    public string ItemName { get {  return itemName; } }

    // Start is called before the first frame update
    void Start() {
        itemName = transform.name;
        itemInfo = Resources.Load<Sprite>("Sprites/Item/" + transform.name);
    }
}
