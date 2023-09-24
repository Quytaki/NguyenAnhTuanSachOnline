using System.Data.Linq;

namespace NguyenAnhTuanSachOnline
{
    public partial class DataClasses1DataContext : DataContext
    {
        public Table<SACH> SACHs;
        public Table<TACGIA> TACGIAs;
        public Table<ADMIN> ADMINes; 
        public Table<CHUDE> CHUDEes;
        public Table<CHITIETDATHANG> CHITIETDATHANGes;
        public Table<DONDATHANG> DONDATHANGes;
        public Table<KHACHHANG> KHACHHANGes;
        public Table<NHAXUATBAN> NHAXUATBANes;
        public Table<VIETSACH> VIETSACHs;

        public DataClasses1DataContext() : base("Data Source=ACERNITRO5;Initial Catalog=SachOnline;Integrated Security=True")
        {
            SACHs = GetTable<SACH>();
            TACGIAs = GetTable<TACGIA>();  
            ADMINes = GetTable<ADMIN>();
            CHUDEes = GetTable<CHUDE>();
            CHITIETDATHANGes = GetTable<CHITIETDATHANG>();
            DONDATHANGes = GetTable<DONDATHANG>();
            KHACHHANGes = GetTable<KHACHHANG>();
            NHAXUATBANes = GetTable<NHAXUATBAN>();
            VIETSACHs = GetTable<VIETSACH>();
        }
    }
}
