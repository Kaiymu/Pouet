using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItemTriggers : MonoBehaviour {
    [MenuItem("Custom Objects/Clickable text")]
    private static void CreateLookAt() {
        Object o = Resources.Load("Prefabs/Clickable/ClickableText");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Clickable audio")]
    private static void CreateMovingObject() {
        Object o = Resources.Load("Prefabs/Clickable/ClickableAudio");
        InstantiateObject(o);
    }

    private static void InstantiateObject(Object o) {
        GameObject g = Instantiate(o, Vector3.zero, Quaternion.identity) as GameObject;

        if (SelectParentObject() != null)
            g.transform.parent = SelectParentObject().transform;

        FocusObject(g);
    }

    private static void FocusObject(GameObject g) {
        GameObject[] gArray = new GameObject[1];
        gArray[0] = g;
        Selection.objects = gArray;
    }

    private static GameObject SelectParentObject() {
        return Selection.activeObject as GameObject;
    }
}