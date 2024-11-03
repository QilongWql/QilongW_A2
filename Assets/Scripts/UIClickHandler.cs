using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 引入事件系统命名空间  
using UnityEngine.UI; // 引入UI命名空间  
  
public class UIClickHandler : MonoBehaviour, IPointerClickHandler // 实现IPointerClickHandler接口  
{  
    // 引用Canvas（可选，但推荐）  
    // 你可以通过编辑器拖放引用，或者通过代码查找Canvas  
    public Canvas canvas;  
  
    // 你可以在编辑器中设置这些引用，或者通过代码查找它们  
    // [SerializeField] private Text textElement;  
    // [SerializeField] private GameObject panelElement;  
  
    // Unity在检测到点击事件时会自动调用此方法  
    public void OnPointerClick(PointerEventData eventData)  
    {  
        // 如果你已经通过编辑器设置了引用，则可以直接使用它们  
        // 如果你没有设置引用，则需要通过代码查找它们，如下所示：  
  
        // 如果通过编辑器设置了canvas引用，则使用它  
        if (canvas != null)  
        {  
            // 查找Text元素并隐藏它（禁用Text组件或隐藏整个GameObject）  
            Transform textTransform = canvas.transform.Find("TextElement");  
            if (textTransform != null && textTransform.GetComponent<Text>() != null)  
            {  
                textTransform.GetComponent<Text>().enabled = false; // 或者使用 textTransform.gameObject.SetActive(false);  
            }  
  
            // 查找Panel元素并隐藏它（隐藏整个GameObject）  
            Transform panelTransform = canvas.transform.Find("PanelElement");  
            if (panelTransform != null)  
            {  
                panelTransform.gameObject.SetActive(false);  
            }  
        }  
        // 如果你没有设置canvas引用，则需要通过其他方式获取它，例如通过FindObjectOfType<Canvas>()  
        // 但这通常不推荐，因为它可能在场景中有多个Canvas时导致问题。  
    }  
  
    // 你可以在Start或Awake方法中设置引用（如果你选择不在编辑器中设置它们）  
    // void Start()  
    // {  
    //     // 例如，通过Find方法查找Canvas（不推荐，因为依赖于Canvas的名称）  
    //     // canvas = GameObject.Find("CanvasName").GetComponent<Canvas>();  
    //     // 或者通过FindObjectOfType方法查找（不推荐，因为可能返回多个结果）  
    //     // canvas = FindObjectOfType<Canvas>();  
    // }  
}