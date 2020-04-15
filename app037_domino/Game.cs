using System;
using System.Collections.Generic;
using System.IO;

public enum GameMode
{
    Simple = 0,
    Hard = 1
}
public enum Stopka
{
    Bazar = 0,
    Player1 = 1,
    Player2 = 2,
    Table = 3
}

class Game : ISerialize
{
    #region " Локальные переменные "
    private Random rnd = new Random();
    bool _isTaken = false;
    private Player _currentPlayer = null; // Поле устанавливает
    private Player _winner = null;
    private bool _isFinal = false;
    private Player _player1 = null;
    private Player _player2 = null;
    private GameMode _gameMode = GameMode.Simple;
    private List<Bone> _nativeList = new List<Bone>()
    {   new Bone(0,0),
        new Bone(0,1), new Bone(1,1),
        new Bone(0,2), new Bone(1,2), new Bone(2,2),
        new Bone(0,3), new Bone(1,3), new Bone(2,3), new Bone(3,3),
        new Bone(0,4), new Bone(1,4), new Bone(2,4), new Bone(3,4), new Bone(4,4),
        new Bone(0,5), new Bone(1,5), new Bone(2,5), new Bone(3,5), new Bone(4,5), new Bone(5,5),
        new Bone(0,6), new Bone(1,6), new Bone(2,6), new Bone(3,6), new Bone(4,6), new Bone(5,6), new Bone(6,6)
    };

    Dictionary<Stopka, List<Bone>> Bones = new Dictionary<Stopka, List<Bone>>()
        {
            { Stopka.Bazar, new List<Bone>() },
            { Stopka.Player1, new List<Bone>() },
            { Stopka.Player2, new List<Bone>() },
            { Stopka.Table, new List<Bone>() }
        };

    #endregion;

    //Конструктор принимает 3 параметра 1 игрок 2 игрок и режим игры
    #region Конструкторы
    public Game() : this(new Player(), new Player(), GameMode.Simple) { }
    public Game(Player player1, Player player2) : this(player1, player2, GameMode.Simple) { }
    public Game(Player player1, Player player2, GameMode gameMode)
    {
        _player1 = player1 ?? throw new ArgumentNullException("player1");
        _player2 = player2 ?? throw new ArgumentNullException("player2");
        GameMode = gameMode;

        #region РАЗДАЧА КОСТЕЙ
        Bone addedBone;
        int index;
        Stopka filledStopka;
        Stopka startplayer = Stopka.Player1;
        int min = 100;
        do
        {
            index = rnd.Next(0, _nativeList.Count);
            addedBone = _nativeList[index];
            if (rnd.Next(0, 2) == 1) { addedBone.Rotate(); }
            if (_nativeList.Count > 21) { filledStopka = Stopka.Player1; }
            else if (_nativeList.Count > 14) { filledStopka = Stopka.Player2; }
            else { filledStopka = Stopka.Bazar; }
            if (filledStopka != Stopka.Bazar && !addedBone.isDouble && min > addedBone.Rank) { min = addedBone.Rank; startplayer = filledStopka; }
            Bones[filledStopka].Add(addedBone);
            _nativeList.RemoveAt(index);
        } while (_nativeList.Count > 0);
        CurrentPlayer = _player1;

        #endregion
    }
    #endregion

    #region " Свойства "
    public GameMode GameMode
    {
        get { return _gameMode; }
        set
        {
            if (value < 0 || value > (GameMode)1) { throw new Exception("В игре всего два уровня 0 - легкий и 1 - сложный"); }
            _gameMode = value;
        }
    }
    public Player Player1 { get { return _player1; } set { if (value == null) { throw new Exception("Player1"); } _player1 = value; } }
    public Player Player2 { get { return _player2; } set { if (value == null) { throw new Exception("Player2"); } _player2 = value; } }
    public Player CurrentPlayer { get { return _currentPlayer; } set { if (value == null) { throw new Exception("CurrentPlayer"); } _currentPlayer = value; } }
    public Player Winner { get { return _winner; } }
    public Player Loser
    {
        get
        {
            if (_winner == Player1) { return Player2; }
            else if (_winner == Player2) { return Player1; }
            return null;
        }
    }
    public bool IsFinal { get { return _isFinal; } }
    #endregion

    #region "Отрисовка"
    public string Draw()
    {
        string line = "";               //добавление тире 
        string strTabelBones = " ";         //содержимое базара
        string strPlayerBones = " ";        //кости текущего игрока
        string strNumbersPlayerBones = "   ";
        int index = 0;                       //индекс списка
        string opponentName = "";           //имя противника 
        int opponentCount = 0;           //количество костей противника

        List<Bone> bonesTable = Bones[Stopka.Table];
        List<Bone> bonesCurrentPlayer;

        if (_currentPlayer == _player1)
        {
            bonesCurrentPlayer = Bones[Stopka.Player1];
            opponentName = _player2.Name;
            opponentCount = Bones[Stopka.Player2].Count;
        }
        else
        {
            bonesCurrentPlayer = Bones[Stopka.Player2];
            opponentName = _player1.Name;
            opponentCount = Bones[Stopka.Player1].Count;
        }

        int maxBonesCount = bonesTable.Count >= bonesCurrentPlayer.Count ? bonesTable.Count : bonesCurrentPlayer.Count;
        do
        {
            if (bonesTable.Count > 0 && index < bonesTable.Count)
            {
                line += "------";
                strTabelBones += bonesTable[index].Image + " ";
            }
            if (index < bonesCurrentPlayer.Count)
            {
                strPlayerBones += bonesCurrentPlayer[index].Image + " ";
                strNumbersPlayerBones += index + 1 + "     ";
            }
            index++;
        }
        while (index < maxBonesCount);

        return
            $"Костей на Базаре: {Bones[Stopka.Bazar].Count}\n" +
            $"Костей у игрока {opponentName}: {opponentCount}\n" +
            "                " + line + "\n" +
            "Кости на столе: " + strTabelBones + "\n" +
            "                " + line + "\n" +
            "Кости игрока: " + strPlayerBones + "\n" +
            "              " + strNumbersPlayerBones;
    }
    #endregion

    #region Функции
    public string _step(string coords)
    {
        if (coords == "pass") { _isTaken = false; goto changePlayer; }
        if (_isTaken && _currentPlayer.Type == PlayerType.Robot) { _isTaken = false; goto changePlayer; }
        List<Bone> player1Bones = Bones[Stopka.Player1];
        List<Bone> player2Bones = Bones[Stopka.Player2];
        coords = coords.Trim().ToLower();


        List<Bone> bonesTable = Bones[Stopka.Table];
        List<Bone> bonesCurrentPlayer = _currentPlayer == _player1 ? Bones[Stopka.Player1] : Bones[Stopka.Player2];
        string tableSide = "";  //Сторона к которой нужно приложить кость, передается через параметры функции
        int boneNumber = 0;     //Порядковый номер кости в стопке игрока, передается через параметры функции
        Bone joinedBone = null;
        //если использовали TAKE 
        if (coords == "take" && _isTaken == false)
        {
            if (bonesTable.Count == 0) { return "В начале игры используйте любую кость из стопки кроме дубля"; }
            joinedBone = _take();
            _isTaken = true;

            if (_currentPlayer.Type == PlayerType.Human)
            {
                bonesCurrentPlayer.Add(joinedBone);
                return $"Игрок вытянул: [{joinedBone.Left}|{joinedBone.Right}] и кость добавлена в стопку\n{Draw()}";
            }
            else
            {
                if (!canBeJoined(joinedBone)) { bonesCurrentPlayer.Add(joinedBone); goto changePlayer; }
                tableSide = checkSide(joinedBone) == "l" ? "l" : "r";
                if (_mustRotate(joinedBone, tableSide)) { joinedBone.Rotate(); }
                goto makeStep;
            }
        }
        else if (coords == "take" && _isTaken == true) { return "Вы уже воспользовались тейком походите или пропустите ход!"; }
        // ходит человек, проверяем введенные данные
        if (_currentPlayer.Type != PlayerType.Robot)
        {
            //если пользователь ничего не ввел
            if (string.IsNullOrWhiteSpace(coords)) { return "Вы не выбрали кость и сторону"; }

            if (coords.Length > 3 || coords.Length < 1 && bonesTable.Count == 0)
            { //error
                return "Вы выбрали не подходящую кость";
            }

            try
            {
                boneNumber = int.Parse(coords.Substring(0, 1));
                tableSide = coords.Substring(coords.Length - 1);
            }
            catch
            { //error
                throw new Exception("Ошибка");
            }
            if (bonesCurrentPlayer.Count < boneNumber) { return "Такой кости нет в стопке игрока"; }
            if (!"lr".Contains(tableSide))
            { //error
            }

            joinedBone = bonesCurrentPlayer[boneNumber - 1];

            if (bonesTable.Count == 0)
            {
                if (joinedBone.isDouble) { return "Нельзя начинать игру с дублей"; }
                goto makeStep;
            }

            //проверка координаты на совпадение
            if (tableSide == "l")
            {
                if (joinedBone.Right != Bones[Stopka.Table][0].Left &&
                        joinedBone.Left != Bones[Stopka.Table][0].Left)
                { return "Координата не совпадает слева попробуйте снова"; }
            }
            else if (tableSide == "r")
            {
                if (joinedBone.Right != Bones[Stopka.Table][Bones[Stopka.Table].Count - 1].Right &&
                    joinedBone.Left != Bones[Stopka.Table][Bones[Stopka.Table].Count - 1].Right)
                { return "Координата не совпадает справа попробуйте снова"; }
            }
            if (bonesTable.Count > 0 && _mustRotate(joinedBone, tableSide)) { joinedBone.Rotate(); }
        }
        else
        {
            //Логика хода компьютера
            for (int index = 0; index <= bonesCurrentPlayer.Count - 1; index++)
            {
                joinedBone = bonesCurrentPlayer[index];
                if (bonesTable.Count != 0)
                {
                    if (canBeJoined(joinedBone))
                    {
                        tableSide = checkSide(joinedBone) == "l" ? "l" : "r";
                        boneNumber = index + 1;
                        if (_mustRotate(joinedBone, tableSide)) { joinedBone.Rotate(); }
                        goto makeStep;
                    }
                    if (_isTaken) { goto changePlayer; }
                }
                else
                {
                    if (!joinedBone.isDouble)
                    {
                        bonesTable.Add(joinedBone);
                        bonesCurrentPlayer.Remove(joinedBone);
                        goto changePlayer;
                    }
                }
            }
            if (Bones[Stopka.Bazar].Count == 0) { goto checkFinal; }
            _step("take");
            if (_isTaken) { _isTaken = false; }
            return "";
        }
        makeStep:
        if (tableSide == "l") { bonesTable.Insert(0, joinedBone); }
        else { bonesTable.Add(joinedBone); }
        if (!_isTaken && CurrentPlayer.Type == PlayerType.Robot || CurrentPlayer.Type == PlayerType.Human) { bonesCurrentPlayer.RemoveAt(boneNumber - 1); }

        checkFinal:
        if (Bones[Stopka.Bazar].Count == 0 || bonesCurrentPlayer.Count == 0 && _checkFinal())
        {
            int scopeP1 = _checkScore(player1Bones), scopeP2 = _checkScore(player2Bones);
            if (scopeP1 > scopeP2) { _winner = Player2; _isFinal = true; return ""; }
            else if (scopeP1 < scopeP2) { _winner = Player1; _isFinal = true; return ""; }
            else { _isFinal = true; _winner = null; return null; }
        }
        changePlayer:
        if (_isTaken) { _isTaken = false; }
        _currentPlayer = _currentPlayer == Player1 ? Player2 : Player1;
        return "";
    }
    #endregion

    #region Функции
    public bool _checkFinal() // проверка на окончание игры
    {

        List<Bone> bonesBazar = Bones[Stopka.Bazar];
        List<Bone> player1Bones = Bones[Stopka.Player1];
        List<Bone> player2Bones = Bones[Stopka.Player2];

        List<Bone> bonesCurrentPlayer = _currentPlayer == _player1 ? Bones[Stopka.Player1] : Bones[Stopka.Player2];
        if (bonesCurrentPlayer.Count == 0) { return true; }
        //int maxBonesCount = player1Bones.Count >= player2Bones.Count ? player1Bones.Count : player2Bones.Count;
        if (player1Bones.Count == 0 || player2Bones.Count == 0) { return true; }
        for (int index1 = 0; index1 < player1Bones.Count; index1++)
        {
            if (canBeJoined(player1Bones[index1]) || canBeJoined(player2Bones[index1]))
            { return false; }
        }
        for (int index2 = 0; index2 < player2Bones.Count; index2++)
        {
            if (canBeJoined(player1Bones[index2]) || canBeJoined(player2Bones[index2]))
            { return false; }
        }
        //do
        //{
        //	if (canBeJoined(player1Bones[index]) || canBeJoined(player2Bones[index]))
        //	{ return false; }
        //	index++;
        //}
        //while (index < maxBonesCount);

        return true;
    }
    public int _checkScore(List<Bone> playerList)
    {
        int score = 0;
        if (playerList.Count == 0) { return score; }
        foreach (Bone bone in playerList) { score += bone.Rank; }
        return score;
    }
    public Bone _take()
    {
        int index = rnd.Next(0, Bones[Stopka.Bazar].Count);
        Bone taken = Bones[Stopka.Bazar][index];
        Bones[Stopka.Bazar].RemoveAt(index);
        return taken;
    }
    public string drawPlayerBones()
    {
        string line = "-";               //добавление тире 
        string strPlayerBones = " ";        //кости текущего игрока
        string strNumbersPlayerBones = "   "; //Номера костей в стопке игрока
        List<Bone> bonesCurrentPlayer = _currentPlayer == _player1 ? bonesCurrentPlayer = Bones[Stopka.Player1] :
            bonesCurrentPlayer = Bones[Stopka.Player2];

        for (int index = 0; index < bonesCurrentPlayer.Count; index++)
        {
            line += "------";
            strPlayerBones += bonesCurrentPlayer[index].Image + " ";
            strNumbersPlayerBones += index + 1 + "     ";
        }
        return
                line + "\n" +
                strPlayerBones + "\n" +
                strNumbersPlayerBones + "\n" +
                line;
    }
    public bool canBeJoined(Bone bone)
    {
        List<Bone> bonesTable = Bones[Stopka.Table];

        return
            bone.Right == bonesTable[0].Left ||
            bone.Left == bonesTable[0].Left ||
            bone.Right == bonesTable[bonesTable.Count - 1].Right ||
            bone.Left == bonesTable[bonesTable.Count - 1].Right;
    }
    public string checkSide(Bone bone)
    {
        List<Bone> bonesTable = Bones[Stopka.Table];
        if (bone.Right == bonesTable[0].Left || bone.Left == bonesTable[0].Left) { return "l"; }
        else if (bone.Right == bonesTable[bonesTable.Count - 1].Right || bone.Left == bonesTable[bonesTable.Count - 1].Right) { return "r"; }
        return "";
    }
    public bool _mustRotate(Bone bone, string tableSide)
    {
        List<Bone> bonesTable = Bones[Stopka.Table];
        if (tableSide == "l") { if (bone.Left == bonesTable[0].Left) { return true; } }
        else { if (bone.Right == bonesTable[bonesTable.Count - 1].Right) { return true; } }
        return false;
    }
    #endregion


    #region Сериализация
    public object Deserialize(BinaryReader binaryReader)
    {
        Game newGame = new Game();
        ISerialize Player1 = new Player();
        ISerialize Player2 = new Player();

        newGame.Player1 = (Player)Player1.Deserialize(binaryReader);
        newGame.Player2 = (Player)Player2.Deserialize(binaryReader);
        newGame.CurrentPlayer = binaryReader.ReadBoolean() == true ? newGame.Player1 : newGame.Player2;
        newGame.GameMode = (GameMode)binaryReader.ReadInt32();

        for (int stopaIndex = 0; stopaIndex < 4; stopaIndex++)
        {
            List<Bone> newList = newGame.Bones[(Stopka)stopaIndex];
            int length = binaryReader.ReadInt32();
            for (int i = 0; i < length; i++)
            {
                ISerialize bone = new Bone();
                newList.Add((Bone)bone.Deserialize(binaryReader));
            }
        }

        return newGame;
    }
    public void Serialize(BinaryWriter binaryWriter)
    {
        ISerialize Player1 = new Player();
        ISerialize Player2 = new Player();

        Player1.Serialize(binaryWriter);
        Player2.Serialize(binaryWriter);
        binaryWriter.Write(_currentPlayer == _player1 ? true : false);
        binaryWriter.Write((int)_gameMode);
        for (int stopaIndex = 0; stopaIndex < 4; stopaIndex++)
        {
            List<Bone> list = Bones[(Stopka)stopaIndex];
            binaryWriter.Write(list.Count);
            foreach (ISerialize bone in list)
            {
                bone.Serialize(binaryWriter);
            }
        }
    }
    #endregion

    #region Загрузка и выгрузка
    public void Save(string strFileName)
    {
        //проверка пути к файлу
        if (string.IsNullOrEmpty(strFileName)) { throw new Exception($"Путь к файлу указан не верно"); }

        //проверка на расширение файла
        if (!strFileName.EndsWith(".domino")) { throw new Exception("Расширение файла должно быть .domino"); }

        //проверка на наличие такого файла по указанному пути----------------------------------------------------------
        if (!File.Exists(strFileName)) { throw new Exception("Такого файла не существует"); }


        using (FileStream fileStream = File.OpenWrite(strFileName))
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream, System.Text.Encoding.UTF8))
            {
                Serialize(binaryWriter);
            }
        }
    }
    public static Game Load(string strFileName)
    {
        //проверка файла
        if (string.IsNullOrEmpty(strFileName)) { throw new ArgumentException("Путь к файлу указан не верно"); }
        if (!strFileName.EndsWith(".domino")) { throw new ArgumentException("Расширение файла должно быть .domino"); }
        if (!File.Exists(strFileName)) { throw new FileNotFoundException("Такого файла не существует"); }

        using (FileStream fileStream = File.OpenRead(strFileName))
        {
            using (BinaryReader binaryReader = new BinaryReader(fileStream, System.Text.Encoding.UTF8))
            {
                Game game = new Game();
                return (Game)game.Deserialize(binaryReader);
            }
        }

    }
    #endregion
}
