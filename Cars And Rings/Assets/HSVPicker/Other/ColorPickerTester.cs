using UnityEngine;

[System.Serializable]
public class array2d {
    public Renderer[] renderers;
    public int[] materialNumbers;
}

public class ColorPickerTester : MonoBehaviour 
{

    public array2d[] paintSection;
    private Renderer[] currentRenderers;
    private int[] currentMatNums;
    public ColorPicker picker;

	// Use this for initialization
	void Start () 
    {
        setPaintSection(0);

        picker.CurrentColor = currentRenderers[0].materials[0].color;

        picker.onValueChanged.AddListener(color =>
        {
            for (int i = 0; i < currentRenderers.Length; ++i)
            {
                currentRenderers[i].materials[currentMatNums[i]].color = picker.CurrentColor;
            }
        });
    }

    public void setPaintSection(int _num) {
        currentRenderers = paintSection[_num].renderers;
        currentMatNums = paintSection[_num].materialNumbers;
        picker.CurrentColor = currentRenderers[0].materials[currentMatNums[0]].color;
    }
}
