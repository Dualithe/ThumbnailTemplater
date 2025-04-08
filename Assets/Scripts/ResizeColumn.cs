using UnityEngine;
using UnityEngine.UI;

public class ResizeColumn : MonoBehaviour
{
    private int cellSize = 60;
    public Slider slider;
    public GridLayoutGroup grid;
    
    public void changeCellSizeX()
    {
        Vector2 newCellSize = new Vector2(grid.cellSize.x, slider.value * cellSize); 
        grid.cellSize = newCellSize;
    }
    
    public void changeCellSizeY()
    {
        Vector2 newCellSize = new Vector2(slider.value * cellSize, grid.cellSize.y); 
        grid.cellSize = newCellSize;
    }
}    

