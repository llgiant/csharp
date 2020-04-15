using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

class Program
{
    static Random rnd = new Random();
    static void Main()
    {
        appBegin:
        #region
        //        Console.InputEncoding = System.Text.Encoding.UTF8;
        //        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //        Console.WriteLine("========================================================================");
        //        Console.WriteLine("Что будет делать программа?");
        //        Console.WriteLine("========================================================================");
        //        Console.WriteLine();
        //        appBegin:

        //        // Массив Цветов
        //        Color[] colors = new Color[] {Color.AliceBlue,       
        //Color.Yellow,
        //Color.YellowGreen
        // };
        //        //Количество букв
        //        int letterCount = 7;
        //        //Присутствие цифр
        //        bool useNumbers = true;
        //        Pen pen = new Pen(Color.Red, 1);

        //        //Создаем паттерны линий ручки
        //        float[] myPattern = new float[] { 16, 4, 10, 5 };
        //        pen.DashStyle = DashStyle.Custom;
        //        pen.DashPattern = myPattern;

        //        //Создаем изображение
        //        Bitmap image = new Bitmap(400, 150, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        //        Graphics graphic = Graphics.FromImage(image);
        //        //Сглаживаем
        //        graphic.SmoothingMode = SmoothingMode.AntiAlias;
        //        //Заливаем белым фоном область изображения
        //        graphic.FillRectangle(Brushes.White, new Rectangle(0, 0, 400, 150));

        //        FontFamily family = new FontFamily("Times New Roman");

        //        string str = "ABCDEFGHIGKLMNOPQRSTUVWXYZ0123456789";
        //        string imageStr = "";



        //        Rectangle layoutRect = new Rectangle();


        //        StringFormat stringFormat = new StringFormat();
        //        stringFormat.Alignment = StringAlignment.Center;
        //        stringFormat.LineAlignment = StringAlignment.Center;

        //        for (int i = 0; i < letterCount; i++)
        //        {
        //            GraphicsPath path = new GraphicsPath();

        //            if (!useNumbers) { imageStr += str[rnd.Next(str.Length - 10)].ToString(); }
        //            else { imageStr = str[rnd.Next(str.Length)].ToString(); }
        //            layoutRect = new Rectangle();
        //            layoutRect.Width = image.Width / letterCount;
        //            layoutRect.Height = image.Height;
        //            layoutRect.X = (image.Width / letterCount) * i + rnd.Next(-3, 3);
        //            layoutRect.Y = rnd.Next(-5, 5);

        //            //Добавляем string в path
        //            path.StartFigure();

        //            path.AddString(imageStr, family, (int)(FontStyle.Bold | FontStyle.Italic), rnd.Next(80, 90), layoutRect, stringFormat);
        //            path.CloseAllFigures();


        //            Point centerPlajka = new Point(layoutRect.X + layoutRect.Width / 2, layoutRect.Y + layoutRect.Height / 2);
        //            // Вращаем path
        //            Matrix rotateMatrix = new Matrix();
        //            rotateMatrix.RotateAt(rnd.Next(-20, 21), new Point(centerPlajka.X + rnd.Next(-5, 5), centerPlajka.Y + rnd.Next(-5, 5)));
        //            path.Transform(rotateMatrix);

        //            // Заливаем сплошным цветом path
        //            graphic.FillPath(PickTransparantBrush(), path);

        //            pen.Color = Color.FromArgb(rnd.Next(0,255), rnd.Next(0, 255), rnd.Next(0, 255));
        //            graphic.DrawPath(pen, path);
        //        }

        //        //Посев линий
        //        int randLines = rnd.Next(10, 16);
        //        for (int i = 0; i < randLines; i++)
        //        {
        //            pen.Color = colors[rnd.Next(colors.Length)];
        //            graphic.DrawLine(pen, new Point(rnd.Next(400), rnd.Next(150)), new Point(rnd.Next(400), rnd.Next(150)));
        //        }
        //        //Посев точек
        //        randLines = rnd.Next(50, 101);
        //        for (int i = 0; i < randLines; i++)
        //        {
        //            pen.Color = colors[rnd.Next(colors.Length)];
        //            graphic.FillRectangle(PickBrush(), rnd.Next(400), rnd.Next(150), 1, 1);
        //        }
        //        //Посев окружносткей
        //        randLines = rnd.Next(5, 11);
        //        for (int i = 0; i < randLines; i++)
        //        {
        //            Rectangle rect = CreatRect(0);
        //            pen.Color = colors[rnd.Next(colors.Length)];
        //            if (rnd.Next(2) == 1) { rect = CreatRect(1); }
        //            if (rnd.Next(5) < 3) { graphic.DrawEllipse(pen, rect); }
        //            else { graphic.FillEllipse(PickrandomlyTransparantBrush(), rect); }
        //        }

        //        Rectangle CreatRect(int shape)
        //        {
        //            if (shape < 0 || shape > 1) { throw new Exception("Приямоугольник должен быть прваильным или не правильным"); }

        //            if (shape == 0)
        //            {
        //                Rectangle rect = new Rectangle();
        //                rect.X = rnd.Next(350);
        //                rect.Y = rnd.Next(140);
        //                rect.Width = rnd.Next(400);
        //                rect.Height = rect.Width;
        //                return rect;
        //            }
        //            else { return new Rectangle(CreatPoint(), CreatSize()); }
        //        }

        //        Point CreatPoint() { return new Point(rnd.Next(400), rnd.Next(150)); }
        //        Size CreatSize() { return new Size(rnd.Next(400), rnd.Next(150)); }

        //        Brush PickTransparantBrush()
        //        {
        //            Color color = colors[rnd.Next(colors.Length)];
        //            SolidBrush myBrush = new SolidBrush(color);
        //            myBrush.Color = Color.FromArgb(rnd.Next(200, 255), color);
        //            return myBrush;
        //        }

        //        Brush PickrandomlyTransparantBrush()
        //        {
        //            Color color = colors[rnd.Next(colors.Length)];
        //            SolidBrush myBrush = new SolidBrush(color);
        //            myBrush.Color = Color.FromArgb(rnd.Next(60), color);
        //            return myBrush;
        //        }

        //        Brush PickBrush()
        //        {
        //            Color color = colors[rnd.Next(colors.Length)];
        //            SolidBrush myBrush = new SolidBrush(color);
        //            myBrush.Color = Color.FromArgb(255, color);
        //            return myBrush;
        //        }

        //        image.Save(@"C:\Users\llgiant\OneDrive\Dev\bitmap.png",
        //       System.Drawing.Imaging.ImageFormat.Png);
        #endregion

        bool goon = true;
        do
        {
            Captcha captcha = new Captcha(true, 4, Extension.Gif);
            if (Console.ReadLine().Trim().ToLower() == "n") { goon = false; }
        }
        while (goon);



        appExit:
        Console.WriteLine();
        Console.WriteLine("========================================================================");
        Console.WriteLine("Выйти из программы [y/n]?");
        if (Console.ReadLine().Trim().ToLower() == "n") { goto appBegin; }
    }
}
