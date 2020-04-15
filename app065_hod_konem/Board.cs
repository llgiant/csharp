using System;
using System.Collections.Generic;
using System.Text;

class Board
{
    Random rnd = new Random();
    //список пройденных клеток
    private Dictionary<string, Cell> _cells = new Dictionary<string, Cell>();
    private Cell _usedCell;
    public Board()
    {
        //Заполняю словарь клеток по принципу <string имя_клетки, Cell клетка>
        for (byte row = 1; row < 11; row++)
        {
            for (byte col = 1; col < 11; col++)
            {
                _cells.Add(row + col.ToString(), new Cell(row, col));
            }
        }
        Cells = _cells;
    }
    //Все клетки
    public Dictionary<string, Cell> Cells { get; }
    public List<Cell> UsedCells { get; set; } = new List<Cell>();


    public void CheckCells(Cell usedCell)
    {
        //Локальная статическая переменная
        _usedCell = usedCell;
        //Безуспешная клетка
        string blockedName;

        //счетчик заполненных потенциальных клеток - ходов в usedCell.StepCells списке
        int count = 0;

        //счетчик свободных клеток
        //byte index = 0;

        //прохожусь по списку имен клеток - ходов и определяю следующую клетку для хода если пустая
        foreach (string nextCell in _usedCell.StepCells)
        {
            if (_cells[nextCell].IsEmpty && !_usedCell.BlockList.Contains(nextCell))
            {
                //Определяю следующую клетку - ход
                _usedCell = _cells[nextCell];

                //Добавляю закрытую клетку в список закрытых клеток
                UsedCells.Add(_usedCell);

                //меняю значение стартовой клетки с пустой на закрытую
                _usedCell.IsEmpty = false;

                //Console.WriteLine(Image(_usedCell.Name));

                CheckCells(_usedCell);
                // Console.WriteLine(Image(_usedCell.Name));
                count = _usedCell.StepCells.IndexOf(nextCell);
            }

            count++;
            //если нет пустой возвращаюсь к предыдущей клетке и ее списку потенциальных пустых клеток - ходов
            if (count == _usedCell.StepCells.Count)
            {
                blockedName = _usedCell.Name;
                _usedCell.IsEmpty = true;
                _usedCell.BlockList.Clear();
                UsedCells.Remove(_usedCell);
                _usedCell = UsedCells[UsedCells.Count - 1];
                _usedCell.BlockList.Add(blockedName);
                return;
            }
        }
    }


    //отрисовка
    public string Image(string usedCell)
    {
        string strBoard = "";
        //strMap += $"           Игрок: {_player.Name}                       \n";
        strBoard += "                                            \n";
        strBoard += "     1   2   3   4   5   6   7   8   9   10 \n";
        strBoard += "   ╋━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━╇━━━┫\n";

        string[] letters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        int rowIndex = 1;
        string cellKey;
        Cell cell;
        foreach (string number in letters)
        {
            if (number != "10") { strBoard += " " + number + " ┃"; }
            else { strBoard += " " + number + "┃"; }

            for (int columnIndex = 1; columnIndex < 11; columnIndex++)
            {
                cellKey = number + columnIndex;
                cell = _cells[cellKey];

                if (cell.IsEmpty) { strBoard += "   "; }
                else
                {
                    if (cellKey != usedCell) { strBoard += " ■ "; }
                    else { strBoard += " O "; }
                }
                if (columnIndex == 10) { strBoard += "┃\n"; }
                else { strBoard += "│"; }
            }
            if (rowIndex == 10) { strBoard += "   ┻━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┷━━━┛\n"; }
            else { strBoard += "   ╉───┼───┼───┼───┼───┼───┼───┼───┼───┼───┨\n"; }
            rowIndex++;
        }
        return strBoard;
    }
}

