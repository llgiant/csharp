using System;
using System.Collections.Generic;
using System.Text;

class Cell
{
    List<string> _stepCellNames = new List<string>();
    List<string> _blockList = new List<string>();
    public Cell(byte row, byte col)
    {
        Row = row;
        Col = col;
        Name = Row + "" + Col;
        IsEmpty = true;
        //IsPassed = false;
        FillStepCells();
        StepCells = _stepCellNames;
        BlockList = _blockList;
    }
    public string Name { get; }
    public byte Col { get; }
    public byte Row { get; }
    public bool IsEmpty { get; set; }
    //public bool IsPassed { get; set; }
    public List<string> StepCells { get; }
    public List<string> BlockList { get; set; }

    private void FillStepCells()
    {

        if (Row - 1 > 0)
        {
            if (Col - 2 > 0) { _stepCellNames.Add((Row - 1).ToString() + (Col - 2)); }
            if (Col + 2 < 11) { _stepCellNames.Add((Row - 1).ToString() + (Col + 2)); }
        }
        if (Row - 2 > 0)
        {
            if (Col - 1 > 0) { _stepCellNames.Add((Row - 2).ToString() + (Col - 1)); }
            if (Col + 1 < 11) { _stepCellNames.Add((Row - 2).ToString() + (Col + 1)); }
        }
        if (Row + 1 < 11)
        {
            if (Col - 2 > 0) { _stepCellNames.Add((Row + 1).ToString() + (Col - 2)); }
            if (Col + 2 < 11) { _stepCellNames.Add((Row + 1).ToString() + (Col + 2)); }
            if (Row + 2 < 11)
            {
                if (Col - 1 > 0) { _stepCellNames.Add((Row + 2).ToString() + (Col - 1)); }
                if (Col + 1 < 11) { _stepCellNames.Add((Row + 2).ToString() + (Col + 1)); }
            }
        }

    }

}



