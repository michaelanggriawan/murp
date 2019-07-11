using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace MURP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : TemplateWindow
    {
        private DataSources.izinDosen ds;
        public MainWindow()
        {
            InitializeComponent();
            ds = new DataSources.izinDosen();
            ds.AssignTable(table);
            ds.Load();

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit g = new AddOrEdit(ds);
            g.Activate();
            g.Show();
        }




        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            var DeletedGrade = table.SelectedItem as Models.izinDosen;
            var ConfirmationResult = MessageBox.Show(
                "Apakah anda ingin menghapus grade ini?",
                "Hapus grade",
                MessageBoxButton.YesNo
            );
            if (ConfirmationResult == MessageBoxResult.Yes)
            {
                ds.Delete(DeletedGrade);
            }
        }

        private void Grade_Edit(object sender, EventArgs e)
        {
            var EditedGrade = table.SelectedItem as Models.izinDosen;
            ds.Update(EditedGrade);
        }

        //Refresh 
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ds = new DataSources.izinDosen();
            ds.AssignTable(table);
            ds.Load();
        }

        private void ExcelClick(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < table.Columns.Count - 2; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                //sheet1.Cells[1, j + 1].Font.Bold = true;
                //sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = table.Columns[j].Header;
            }
            for (int i = 0; i < table.Columns.Count - 2; i++)
            {
                for (int j = 0; j < table.Items.Count; j++)
                {
                    TextBlock b = table.Columns[i].GetCellContent(table.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
        private void ApprovalClick(object sender, RoutedEventArgs e)
        {
            Core.Db.OpenConn();
            foreach (Models.izinDosen ID in table.Items)
            {
                ID.isChecked = false;
                Core.Db.Insert("approvalIzinDosen", new Dictionary<string, object>()
                {
                    {"izinDosen", ID.izindosen },
                    {"status", ID.isChecked ? "approved" : "unapproved" },
                    {"tglApproval", ID.tglPengajuanIzin }
                });


            }

            MessageBox.Show("Submit Success");
        }

    }
}
