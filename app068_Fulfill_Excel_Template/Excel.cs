using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace app068_Fulfill_Excel_Template
{

    class Excel
    {
        private string templatePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Template\\" + "example.xlsx";
        private string savePath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Result\\" + "example.xlsx";
        
        _Application excel = new Application();
        Workbook wb;
        Worksheet ws;

        public void WriteDataToFile(Client client)
        {
            try
            {
                //открываю документ 
                wb = excel.Workbooks.Open(templatePath);
            }
            catch (Exception)
            {
                throw new Exception("Ошибка открытия файла");
            }

            ws = (Worksheet)excel.Worksheets[1];

            ws.Cells[3, 2] = client.ID;
            ws.Cells[4, 4] = client.ID;

            ws.Cells[4, 2] = client.Name;
            ws.Cells[4, 5] = client.Name;

            ws.Cells[5, 2] = client.Birthdate.ToString("dd.MM.yyyy");
            ws.Cells[4, 6] = client.Birthdate.ToString("dd.MM.yyyy");

            ws.Cells[6, 2] = client.PhoneNumber;
            ws.Cells[4, 7] = client.PhoneNumber;

            ws.Cells[7, 2] = client.Address;
            ws.Cells[4, 8] = client.Address;

            ws.Cells[8, 2] = client.SocialNumber;
            ws.Cells[4, 9] = client.SocialNumber;
        }

        public void SaveAs()
        {
            try
            {
                wb.SaveAs(savePath);
            }
            catch (System.Exception)
            {
                throw new Exception("Ошибка сохранения Файла");                
            }
            //Закрываю workbook
            wb.Close(true);

            //Закрываю документ excel
            excel.Quit();             
        }
    }
}
