﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Managament_Library_v2._0.EF;

namespace Managament_Library_v2._0.DAO
{
    public class Sach
    {
        LibraryDataContext data = new LibraryDataContext();
        public DataTable loadTuaSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from TUASACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["matuasach"].ColumnName = "Mã tựa sách";
            dt.Columns["tentuasach"].ColumnName = "Tên tựa sách";
            dt.Columns["tacgia"].ColumnName = "Tác giả";
            dt.Columns["gioithieu"].ColumnName = "Giới thiệu";
            return dt;
        }

        public DataTable loadDauSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from DAUSACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["matuasach"].ColumnName = "Mã tựa sách";
            dt.Columns["ngonngu"].ColumnName = "Ngôn ngữ";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            dt.DefaultView.Sort = "Mã tựa sách";
            return dt;
        }

        public DataTable loadCuonSach()
        {
            DataProvider.openConnect();
            SqlDataAdapter da = new SqlDataAdapter("select* from CUONSACH", DataProvider.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns["macuonsach"].ColumnName = "Mã cuốn sách";
            dt.Columns["madausach"].ColumnName = "Mã đầu sách";
            dt.Columns["tinhtrang"].ColumnName = "Tình trạng";
            dt.DefaultView.Sort = "Mã đầu sách";
            return dt;
        }

        public void suaDauSach(DAUSACH ds)
        {
            var temp = data.DAUSACHes.Find(ds.madausach);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(ds);
                data.SaveChanges();
            }
        }

        public DAUSACH timDauSach(DAUSACH ds)
        {
            return data.DAUSACHes.Find(ds.madausach);
        }

        public void suaCuonSach(CUONSACH cs)
        {
            var temp = data.CUONSACHes.Find(cs.macuonsach);

            if (temp != null)
            {
                data.Entry(temp).CurrentValues.SetValues(cs);
                data.SaveChanges();
            }
        }

        public CUONSACH timCuonSach(CUONSACH cs)
        {
            return data.CUONSACHes.Find(cs.macuonsach);
        }

    }
}