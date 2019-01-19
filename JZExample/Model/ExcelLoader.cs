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
                var workbook = new XSSFWorkbook(path);
                return Load(workbook);
            }

            if(extension == ".xls")
            {
                using(var stream = File.OpenRead(path))
                {
                    var workbook = new HSSFWorkbook(stream);
                    return Load(workbook);
                }
                
            }

            return null;
        }

        private IEnumerable<BatchInfo> Load(IWorkbook workbook)
        {
            if(null == workbook)
            {
                return null;
            }

            if(workbook.NumberOfSheets <= 0)
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
                if(IsPossibleData(row))
                {
                    var bi = new BatchInfo()
                    {
                        SerinalNo = (int)row.Cells[0].NumericCellValue,
                        QRCodeContent = row.Cells[1].StringCellValue
                    };
                    batchInfoList.Add(bi);
                }
            }
            return batchInfoList;
        }

        private bool IsPossibleData(IRow row)
        {
            return row != null && row.Cells.Count >= 2 &&
                    row.Cells[0].CellType == CellType.Numeric &&
                    row.Cells[1].CellType == CellType.String;
        }
    }
}
