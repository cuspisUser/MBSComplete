﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBaseReader;
using System.Collections;
using System.Text.RegularExpressions;


namespace DosMigration
{
    class Dbf
    {
        public String getPath()
        {
            String path = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "dbf files (*.dbf)|djelat.dbf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            return path;
        }

        public Boolean getDataGrid(DataGridView dataGridView, String path, Dictionary<string, int> columns)
        {
            Boolean dbfOpened = false;

            DBaseReader.DBaseReader dBaseReader = new DBaseReader.DBaseReader();
            dataGridView.AutoGenerateColumns = false;

            if (dBaseReader.OpenDBaseDBF(path))
            {
                //bool exportData = dBaseReader.ExportData(DBaseReader.DBaseReader.ExportType.txtFile);
                //int numberOfRecords = dBaseReader.NumberOfRecords();
                //int numberOfValidRecords = dBaseReader.NumberOfValidRecords();
                //int numberOfFields = dBaseReader.NumberOfFields();
                //String fieldNames = dBaseReader.GetFieldNames();
                //bool isEncrypted = dBaseReader.GetIsEncrypted();
                //List<String> fieldsInfo = dBaseReader.GetFieldsInfo();
                List<String> records = dBaseReader.GetRecords();
                //List<String> records2 = dBaseReader.GetRecords(new List<int>());
                //List<String> unusedFields = dBaseReader.GetUnusedFields();
                //List<String> usedFields = dBaseReader.GetUsedFields();
                //List<String> usedFieldData = dBaseReader.GetUsedFieldData();
                //bool exportUsedFieldsData = dBaseReader.ExportUsedFieldsData();
                //bool exportUnusedFields = dBaseReader.ExportUnusedFields();
                //bool exportFieldData = dBaseReader.ExportFieldData();
                //Object dataAsCorrectType = dBaseReader.GetDataAsCorrectType(1, 1);

                int i = 0;

                foreach (String record in records)
                {
                    if (i++ > 0)
                    {
                        IEnumerable columnsE = columns as IEnumerable;

                        int k = 0;
                        dataGridView.Rows.Add();

                        foreach (KeyValuePair<string, int> j in columns)
                        {
                            String delimited = record.Replace("\",\"", "\"¤\"");
                            String[] row = delimited.Split('¤');
                            String cell = row[j.Value - 1];
                            cell = prepare(cell);
                            dataGridView[k++, i - 2].Value = cell;
                        }
                    }
                    else  // first column.headers
                    {
                        foreach (KeyValuePair<string, int> column in columns)
                        {
                            DataGridViewColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
                            dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
                            dataGridViewColumn.HeaderText = column.Key.ToString();
                            dataGridViewColumn.Frozen = false;
                            dataGridView.Columns.Add(dataGridViewColumn);
                        }
                    }
                }

                dbfOpened = true;
            }

            return dbfOpened;
        }

        private String prepare(String cell)
        {
            // ~ -> č
            cell = cell.Replace('~', 'č');
            // ^ -> Č
            cell = cell.Replace('^', 'Č');
            // } -> ć
            cell = cell.Replace('}', 'ć');
            // ] -> Ć
            cell = cell.Replace(']', 'Ć');
            // ` -> ž
            cell = cell.Replace('`', 'ž');
            // @ -> Ž
            cell = cell.Replace('@', 'Ž');
            // { -> š
            cell = cell.Replace('{', 'š');
            // [ -> Š
            cell = cell.Replace('[', 'Š');
            // ¦ -> đ
            cell = cell.Replace('¦', 'đ');
            // \ -> Đ
            cell = cell.Replace('\\', 'Đ');
            // remove "
            cell = cell.Trim('"');

            return cell;
        }
    }
}