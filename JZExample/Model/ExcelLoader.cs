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
        public Batch Load(string path)
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

        private Batch Load(IWorkbook workbook)
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

            if(sheet.LastRowNum <= 7)
            {
                return null;
            }

            var batch = new Batch();
            batch.CreateTime = DateTime.Now;

            batch.Model = GetCellValue(sheet.GetRow(1).Cells[1]);
            batch.DateProduced = GetCellValue(sheet.GetRow(2).Cells[1]);
            batch.DateExpired = GetCellValue(sheet.GetRow(3).Cells[1]);
            batch.BatchNo = GetCellValue(sheet.GetRow(4).Cells[1]);

            var batchInfoList = new List<BatchItem>();
            for (int i = 7; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if(IsPossibleData(row))
                {
                    var bi = new BatchItem()
                    {
                        SerinalNo = (int)row.Cells[0].NumericCellValue,
                        QRCodeContent = row.Cells[1].StringCellValue
                    };
                    batchInfoList.Add(bi);
                }
            }

            batch.Items = batchInfoList.ToArray();
            return batch;
        }

        private string GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Numeric:
                    return cell.NumericCellValue.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                default:
                    return null;
            }
        }

        private bool IsPossibleData(IRow row)
        {
            return row != null && row.Cells.Count >= 2 &&
                    row.Cells[0].CellType == CellType.Numeric &&
                    row.Cells[1].CellType == CellType.String;
        }
    }
}
