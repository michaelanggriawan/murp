using System;
using System.Windows;
using System.Windows.Controls;


namespace MURP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddOrEdit : Window
    {
        private Core.Base.DataSource<Models.izinDosen> DataSource;

        public AddOrEdit(Core.Base.DataSource<Models.izinDosen> ds)
        {
            InitializeComponent();
            DataSource = ds;

            var kdDosenDs = new DataSources.Dosen();
            kdDosenDs.AssignTable(kode_dosen);
            kdDosenDs.Load();

            var semesterDs = new DataSources.Semester();
            semesterDs.AssignTable(semester);
            semesterDs.Load();

            var kelasDs = new DataSources.Kelas();
            kelasDs.AssignTable(kelas);
            kelasDs.Load();

            var prodiDs = new DataSources.Prodi();
            prodiDs.AssignTable(prodi);
            prodiDs.Load();

            var mataKuliahDs = new DataSources.MataKuliah();
            mataKuliahDs.AssignTable(mataKuliah);
            mataKuliahDs.Load();

            var dosenDs = new DataSources.Dosen();
            dosenDs.AssignTable(namaDosen);
            dosenDs.Load();
        }




        public void btn1_Click(object sender, EventArgs e)
        {

            Models.Kelas KLS = kelas.SelectedItem as Models.Kelas;
            Models.MataKuliah MK = mataKuliah.SelectedItem as Models.MataKuliah;
            Models.Prodi PR = prodi.SelectedItem as Models.Prodi;
            Models.Dosen DS = kode_dosen.SelectedItem as Models.Dosen;
            Models.Semester SM = semester.SelectedItem as Models.Semester;
            Models.izinDosen dosen = new Models.izinDosen()
            {
                kdDosen = DS.kdDosen,
                nmDosen = namaDosen.Text,
                idSemester = SM.idSemester,
                idKelas = KLS.idKelas,
                kdProdi = PR.kdProdi,
                kdMataKuliah = MK.kdMataKuliah,
                tglPengajuanIzin = DateTime.Parse(tanggallzin.Text).ToString("yyyy.MM.dd"),
                jamPengajuanIzin = jamPengajuanIzin.Text,
                alasanIzin = alasanIzin.Text
            };

            DataSource.Add(
                dosen
           );
            Close();
        }

        private void Btn1_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Kode_dosen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
