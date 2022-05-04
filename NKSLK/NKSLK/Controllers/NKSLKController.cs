using NKSLK.Models.DAO;
using NKSLK.Models.DAO.NhatKy;
using NKSLK.Models.DTO;
using NKSLK.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKSLK.Controllers
{
    public class NKSLKController : Controller
    {
        private Model1 db = new Model1();
        // GET: NKSLK
        public ActionResult Index( string Thang, string Tuan, string CN,int pageNum = 1, int pageSize = 10)
        {
            ViewBag.Thang = Thang;
            ViewBag.Tuan = Tuan;
            ViewBag.CN = CN;
            NKSLKDAO dao = new NKSLKDAO();
            
            if (!string.IsNullOrEmpty(Thang) && string.IsNullOrEmpty(Tuan) && !string.IsNullOrEmpty(CN))
            {
                return View(dao.lstSearchByThang(Thang, Convert.ToInt32(CN), pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(Thang) && !string.IsNullOrEmpty(Tuan) && !string.IsNullOrEmpty(CN))
            {
                return View(dao.lstSearchByTuan(Tuan, Convert.ToInt32(CN), pageNum, pageSize));
            }
            if (!string.IsNullOrEmpty(Thang) && string.IsNullOrEmpty(Tuan) && string.IsNullOrEmpty(CN))
            {
                return View(dao.lstSearchAllByThang(Thang, pageNum, pageSize));
            }
            if (string.IsNullOrEmpty(Thang) && !string.IsNullOrEmpty(Tuan) && string.IsNullOrEmpty(CN))
            {
                return View(dao.lstSearchAllByTuan(Tuan, pageNum, pageSize));
            }

            return View(dao.lstjoin(pageNum, pageSize));
        }

        public ActionResult Create()
        {
            NKSLKDAO dao = new NKSLKDAO();
            CongviecDAO d = new CongviecDAO();
            ViewBag.macv = d.ListCongviec();
            SanphamDAO da = new SanphamDAO();
            ViewBag.spad = da.ListSanpham();
            CongnhanDAO dai = new CongnhanDAO();
            ViewBag.macn = dai.ListCongnhan();
            return View();
        }
        [HttpPost]
        public ActionResult Create(NKSLKs a, string sltv, string sltt, string slsp, string spad, string macv, string macn, string tgbd, string tgkt)
        {
            //thêm dữ liệu vào bảng đầu mục công việc
            DAU_MUC_CV daumuccv = new DAU_MUC_CV();
            daumuccv.MaCV = Convert.ToInt32(macv);
            daumuccv.SLThucTe = Convert.ToDouble(sltt);
            daumuccv.SoLoSP = Convert.ToInt32(slsp);
            daumuccv.SPApDung = Convert.ToInt32(spad);
            db.DAU_MUC_CV.Add(daumuccv);
            db.SaveChanges();

            // thêm dữ liệu vào bảng nhóm thực hiện khoán           
            NHOM_THUC_HIEN_KHOAN nhomthk = new NHOM_THUC_HIEN_KHOAN();
            nhomthk.SLThanhVien = Convert.ToInt32(sltv);
            db.NHOM_THUC_HIEN_KHOAN.Add(nhomthk);
            db.SaveChanges();

            // thêm dữ liệu vào bảng nhật ký
            NKSLKs nkslk = new NKSLKs();
            nkslk.NgayThucHienKhoan = a.NgayThucHienKhoan;
            nkslk.GioBatDau = a.GioBatDau;
            nkslk.GioKetThuc = a.GioKetThuc;
            nkslk.NhomThucHienKhoan = nhomthk.MaNhom;
            nkslk.CongViec = daumuccv.MaDMCV;
            db.NKSLKs.Add(nkslk);
            db.SaveChanges();

            //Thêm dữ liệu vào bảng công nhân khoán
            CONG_NHAN_KHOAN cnk = new CONG_NHAN_KHOAN();
            cnk.MaNhom = nhomthk.MaNhom;
            cnk.MaCN = Convert.ToInt32(macn);
            cnk.ThoiGianBatDau = Convert.ToDateTime(tgbd);
            cnk.ThoiGianKetThuc = Convert.ToDateTime(tgkt);
            db.CONG_NHAN_KHOAN.Add(cnk);
            db.SaveChanges();
            // them san pham vao db
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(nkslk);
            }
        }
    
    public ActionResult Edit(int id)
        {
            List<NKSLKs> ls = new List<NKSLKs>();
            NKSLKDAO dao = new NKSLKDAO();
            NKSLKs nk = dao.FindNKSLKByID(id);
            return View(nk);
        }

        [HttpPost]
        public ActionResult Edit(NKSLKs nk, int id)
        {
            NKSLKDAO dao = new NKSLKDAO();
            NKSLKs nKSLK = dao.FindNKSLKByID(id);
            nKSLK.NgayThucHienKhoan = nk.NgayThucHienKhoan;
            nKSLK.GioBatDau = nk.GioBatDau;
            nKSLK.GioKetThuc = nk.GioKetThuc;
            nKSLK.NhomThucHienKhoan = nk.NhomThucHienKhoan;
            nKSLK.CongViec = nk.CongViec;
            if (ModelState.IsValid)
            {
                NKSLKDAO d = new NKSLKDAO();
                d.Edit(nKSLK);
                return RedirectToAction("Index");
            }
            else
            {
                return View(nKSLK);
            }
        }
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            NKSLKDAO dao = new NKSLKDAO();
            NKSLKs sp = dao.FindNKSLKByID(id);
            return View(sp);
        }
        public ActionResult cnk(int id)
        {
            CNKDAO dao = new CNKDAO();
            CNKDTO cn = dao.Congnhankhoan(id);
            return View(cn);
        }
        public ActionResult daumuc(int id)
        {
            DauMucDAO dao = new DauMucDAO();
            DauMucDTO dm = dao.daumuc(id);
            return View(dm);
        }
        // delete

        [HttpPost]
        public string Delete(int id)
        {
            NKSLKDAO dao = new NKSLKDAO();
            NKSLKs nk = dao.FindNKSLKByID(id);
            if (nk != null)
            {
                dao.Delete(id);
            }
            return "OK";
        }

    }
}