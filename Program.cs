using System;

namespace Sistem_Manajemen_Karyawan_di_Perusahaan_PBO_PR
{
    public class Karyawan
    {
        private string nama;
        private string id;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set
            {
                if (value >= 0)
                    gajiPokok = value;
                else
                    Console.WriteLine("Gaji pokok tidak sesuai!");
            }
        }

        public Karyawan(string nama, string id, double gajiPokok)
        {
            Nama = nama;
            ID = id;
            GajiPokok = gajiPokok;
        }

        public virtual double HitungGaji()
        {
            return GajiPokok;
        }

        public string GetInfo()
        {
            return $"Nama: {Nama}, ID: {ID}, Gaji Pokok: {GajiPokok:C}";
        }
    }

    public class KaryawanTetap : Karyawan
    {
        public KaryawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok + 500000;
        }
    }

    public class KaryawanKontrak : Karyawan
    {
        public KaryawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok - 200000;
        }
    }

    public class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~ Data Karyawan ~~");

            Console.Write("Masukkan jenis karyawan anda (tetap/kontrak/magang): ");
            string jenis = Console.ReadLine().ToLower();

            while (jenis != "tetap" && jenis != "kontrak" && jenis != "magang")
            {
                Console.Write("Tidak Sesuai!");
                jenis = Console.ReadLine().ToLower();
            }

            Console.Write("Masukkan nama anda: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan ID anda: ");
            string id = Console.ReadLine();

            Console.Write("Gaji Pokok anda Setiap Bulan: ");
            double gajiPokok;
            while (!double.TryParse(Console.ReadLine(), out gajiPokok) || gajiPokok < 0)
            {
                Console.Write("Gaji tidak valid");
            }

            Karyawan karyawan;

            if (jenis == "tetap")
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
            else if (jenis == "kontrak")
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
            else
                karyawan = new KaryawanMagang(nama, id, gajiPokok);

            Console.WriteLine("\nData Karyawan");
            Console.WriteLine(karyawan.GetInfo());
            Console.WriteLine($"Total Gaji yang anda terima bulan ini: {karyawan.HitungGaji():C}");

            Console.ReadLine();
        }
    }
}