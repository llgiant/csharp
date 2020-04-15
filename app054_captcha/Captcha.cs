using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

enum Extension
{
    None = 0,
    Gif = 1,
    Jpeg = 2,
    Png = 3
}
class Captcha
{
    #region Class Fields
    static Random rnd = new Random();
    //Холст изображения
    private static Bitmap _image = new Bitmap(400, 150, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    //Объект для рисования
    private static Graphics _graphic = Graphics.FromImage(_image);
    //Контур для записи в объект _graphic
    private GraphicsPath _path = null;
    //Формат сохранения изображения(Png,Gif,Jpeg,Bmp)
    private Extension _extension = Extension.None;
    //использовать ли цифры (определяется пользователем)
    private bool _useNumbers = false;
    //ручка для обводки контуров
    private Pen _pen = new Pen(Color.Black, 1);
    //Создаем паттерны линий ручки
    private float[] _myPattern = new float[] { 10, 4, 10, 4 };
    //Шрифт
    private FontFamily _family = new FontFamily("Times New Roman");
    //количество символов выбранных пользователем
    private int _letterCount = 0;
    //Прямоугольник - плашка
    private Rectangle _layoutRect = new Rectangle();
    //Строка для добавления символа
    private string _imageStr = "";
    //Объект для вращения path
    private Matrix _rotateMatrix = new Matrix();
    #endregion

    public Captcha(bool useNumbers, int LetterCount, Extension extension)
    {
        if (extension < 0 || extension > (Extension)3) { throw new Exception("Расширение должнобыть в диапазоне от 0 до 3"); }
        _extension = extension;

        // Задаем паттерны пунктиров и промежутков для ручки
        _pen.DashStyle = DashStyle.Custom;
        _pen.DashPattern = _myPattern;
        _useNumbers = useNumbers;
        if (LetterCount < 4 || LetterCount > 7) { throw new Exception("Количество символов должно быть в диапазоне от 4 до 7"); }
        _letterCount = LetterCount;

        // Сглаживаем 
        _graphic.SmoothingMode = SmoothingMode.AntiAlias;
        //Заливаем белым фоном область изображения
        _graphic.FillRectangle(Brushes.White, new Rectangle(0, 0, 400, 150));
        // Формат строки выравнивание строки по центру и по высоте по центру
        StringFormat stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;
        int index = 0;
        do
        {

            if (index == 0)
            {
                // Посев окружностей
                int randLines = rnd.Next(5, 11);
                for (int i = 0; i < randLines; i++)
                {
                    _path = new GraphicsPath();
                    _layoutRect = CreatRectForCircle();

                    // Добавляем окружность в path
                    _path.StartFigure();
                    _path.AddEllipse(_layoutRect);
                    _path.CloseAllFigures();

                    // Вращаем path           
                    RotatePath(_path, _layoutRect, -45, 46);

                    // Рандомно либо обводим инструментом Pen границы области Path либо заливаем сплошным цветом область path 
                    if (rnd.Next(2) == 1) { _pen.Color = GetRandomColor(); _graphic.DrawPath(_pen, _path); }
                    else { _graphic.FillPath(PickBrush(1), _path); }
                }

                //Посев линий
                randLines = rnd.Next(10, 16);
                for (int i = 0; i < randLines; i++)
                {
                    _pen.Color = GetRandomColor();
                    if (rnd.Next(2) == 1) { _graphic.DrawLine(_pen, new Point(rnd.Next(5, 196), rnd.Next(5, 71)), new Point(rnd.Next(205, 396), rnd.Next(80, 146))); }
                    else { { _graphic.DrawLine(_pen, new Point(rnd.Next(205, 396), rnd.Next(5, 71)), new Point(rnd.Next(5, 196), rnd.Next(80, 146))); } }
                }

                //Посев точек
                randLines = rnd.Next(6000, 12000);
                for (int i = 0; i < randLines; i++)
                {
                    int temp = rnd.Next(4);
                    _pen.Color = GetRandomColor();

                    //изображение условно делится на 4 прямоугольника где рандомно проставляются точки глиф
                    if (temp == 0) { _graphic.FillRectangle(PickBrush(0), rnd.Next(5, 200), rnd.Next(5, 70), 1, 1); }
                    else if (temp == 1) { _graphic.FillRectangle(PickBrush(0), rnd.Next(200, 396), rnd.Next(5, 70), 1, 1); }
                    else if (temp == 2) { _graphic.FillRectangle(PickBrush(0), rnd.Next(5, 200), rnd.Next(70, 146), 1, 1); }
                    else if (temp == 3) { _graphic.FillRectangle(PickBrush(0), rnd.Next(200, 396), rnd.Next(70, 146), 1, 1); }
                }
            }
            #region Отрисовка символов
            _path = new GraphicsPath();
            if (!_useNumbers) { _imageStr = getRandomSymbol(); }
            else { _imageStr = getRandomSymbol(); }
            _layoutRect = new Rectangle();
            _layoutRect.Width = _image.Width / _letterCount;
            _layoutRect.Height = _image.Height;
            _layoutRect.X = (_image.Width / _letterCount) * index + rnd.Next(-3, 3);
            _layoutRect.Y = rnd.Next(-5, 5);

            //Добавляем string в path
            _path.StartFigure();
            _path.AddString(_imageStr, _family, (int)(FontStyle.Bold | FontStyle.Italic), rnd.Next(80, 90), _layoutRect, stringFormat);
            _path.CloseAllFigures();

            // Вращаем path
            RotatePath(_path, _layoutRect, -20, 21);

            // Заливаем сплошным цветом path
            _graphic.FillPath(PickBrush(1), _path);
            _pen.Color = GetRandomColor();
            _graphic.DrawPath(_pen, _path);
            #endregion
            index++;
        }
        while (index < _letterCount);

        //Сохранение изображения в файл 
        _image.Save(@"C:\Users\llgiant\OneDrive\Dev\bitmap.bmp",
       ImageFormat.Bmp);
    }

    #region Functions
    //Получаю случайную цветную кисть(0-без проозрачности 1-есть прозрачность от 180 до 255)
    private Brush PickBrush(int transparancy)
    {
        if (transparancy == 1) { return new SolidBrush(Color.FromArgb(rnd.Next(125, 165), GetRandomColor())); }
        return new SolidBrush(GetRandomColor());
    }

    //Получаю случайный цвет
    private Color GetRandomColor()
    {
        int random = rnd.Next(3);
        if (random == 0) { return Color.FromArgb(255, rnd.Next(200, 230), rnd.Next(200, 230)); }
        else if (random == 1) { return Color.FromArgb(rnd.Next(200, 230), 255, rnd.Next(200, 230)); }
        else { return Color.FromArgb(rnd.Next(200, 230), rnd.Next(200, 230), 255); }
    }

    //Символ для отрисовки и для последующей заливки 
    private string getRandomSymbol()
    {
        string strLetters = "abcdefghijklmnopqrstuvwxyz";
        string strNumbers = "0123456789";

        if (_useNumbers)
        {
            //Должна присутствовать цифра
            if (rnd.Next(4) < 3)
            {
                return getRandomSymbol(strLetters, strNumbers);
            }
            else
            {
                return strNumbers[rnd.Next(strNumbers.Length)].ToString();
            }
        }
        else
        {
            return getRandomSymbol(strLetters, strNumbers);
        }
    }
    private string getRandomSymbol(string strLetters, string strNumbers)
    {
        if (rnd.Next(2) == 1) { return strNumbers[rnd.Next(strNumbers.Length)].ToString().ToUpper(); }
        else { return strLetters[rnd.Next(strLetters.Length)].ToString(); }
    }

    //Создаю прямоугольник для посева окружностей
    private Rectangle CreatRectForCircle()
    {
        Rectangle rect = new Rectangle();
        rect.X = rnd.Next(10, 190);
        rect.Y = rnd.Next(10, 70);
        rect.Width = rnd.Next(205, _image.Width - rect.X);
        rect.Height = rnd.Next(80, _image.Height - rect.Y);
        return rect;
    }
    #endregion

    #region Methods
    private void RotatePath(GraphicsPath path, Rectangle rect, int angleA, int angleB)
    {
        Point centerPlajka = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        _rotateMatrix = new Matrix();
        _rotateMatrix.RotateAt(rnd.Next(angleA, angleB), new Point(centerPlajka.X + rnd.Next(-5, 5), centerPlajka.Y + rnd.Next(-5, 5)));
        path.Transform(_rotateMatrix);
    }
    #endregion
}

