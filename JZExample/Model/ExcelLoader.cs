using System;
using System.IO;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;


namespace JZExample.Model
{
    public class ExcelLoader
    {
        public IEnumerable<BatchInfo> Load(string path)
        {
            var extension = Path.GetExtension(path).ToLower();
            if (string.IsNullOrEmpty(extension))
            {
                return null;
            }

            if(extension == ".xlsx")
            {
                var workbook = new XSSFWorkbook();
                return Load(workbook);
            }

            if(extension == ".xls")
            {
                var workbook = new HSSFWorkbook();
                return Load(workbook);
            }

            return null;
        }

        private IEnumerable<BatchInfo> Load(IWorkbook workbook)
        {
            if(null == workbook)
            {
                return null;
            }

            var sheet = workbook.GetSheetAt(0);
            if(null == sheet)
            {
                return null;
            }

            var batchInfoList = new List<BatchInfo>();
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null) //null is when the row only contains empty cells 
                {
                    if(row.Cells.Count > 0)
                    {
                        var bi = new BatchInfo()
                        {
                            SerinalNo = row.Cells[0].StringCellValue,
                            QRCodeContent = row.Cells[1].StringCellValue
                        };
                        batchInfoList.Add(bi);
                    }
                    
                }
            }
            return batchInfoList;
        }
    }
}
