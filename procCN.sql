use NKSLK
alter proc getallKhoan
as
begin
select nk.MaNK, nk.NgayThucHienKhoan, nk.GioBatDau, nk.GioKetThuc, cn.MaCN, cn.HoTen, cv.MaCV, cv.TenCV
from NKSLKs nk join CONG_VIEC cv on nk.CongViec = cv.MaCV join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan = cnk.MaNhom
		join CONG_NHAN cn on cnk.MaCN = cn.MaCN
end
		select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan
--=------------------------------------1 NKSLK
alter proc Thang_CN
@thang date,
@macn int
as
begin
	select nk.*
	from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
	where nk.NgayThucHienKhoan BETWEEN @thang and DATEADD( DAY,DAY(EOMONTH(@thang)),@thang) and MaCN=@macn 

end
go
Thang_CN'2021-02-01',18


--tuần
alter proc Tuan_CN
@tuan date,
@macn int
as
begin
	select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan  
	from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
	where nk.NgayThucHienKhoan between dbo.getFirstDateOfWeek(@tuan) and dbo.getLastDateOfWeek(@tuan) and MaCN=@macn
end
go
Tuan_CN '2021-2-25', 18
02/25/2021
--toàn bộ cn
alter proc Thang
@thang date
as
begin
	select nk.*
	from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
	where nk.NgayThucHienKhoan BETWEEN @thang and DATEADD( DAY,DAY(EOMONTH(@thang)),@thang) 
end

--tuần
alter proc Tuan
@tuan date
as
begin
	select nk.* 
	from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
	where nk.NgayThucHienKhoan between dbo.getFirstDateOfWeek(@tuan) and dbo.getLastDateOfWeek(@tuan)
end
Tuan '2021-02-2'
------------------------------------------------------------------------
----------------------------công nhân

--10. Hiển thị danh mục công nhân có NKSLK được thực hiện ở ca 3

create proc Caba
as
begin
	Select cn.*,cnk.ThoiGianBatDau,cnk.ThoiGianKetThuc 
	from  CONG_NHAN_KHOAN cnk join CONG_NHAN cn on cnk.MaCN=cn.MaCN 
	Where cnk.ThoiGianBatDau>='22:00:00' and cnk.ThoiGianKetThuc<='06:00:00'
end
go


--7. Hiển thị danh mục công nhân được nhóm theo phòng ban, chức vụ
alter proc PhongBan
@phongban nvarchar(50)
as
begin
	select cn.*
	from CONG_NHAN cn 
	where cn.PhongBan=@phongban
	group  by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
	order by PhongBan
end
go
PhongBan N'Ban giám đốc'
create proc PB_CV
@phongban nvarchar(50),
@chucvu nvarchar(50)
as
begin
	select cn.*
	from CONG_NHAN cn
	where cn.ChucVu=@chucvu and cn.PhongBan=@phongban
	group  by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
	order by ChucVu
end
PB_CV N'Phòng quản lý', N'Nhân viên'
go
create proc ChucVu
@chucvu nvarchar(50)
as
begin
	select cn.*
	from CONG_NHAN cn
	where cn.ChucVu=@chucvu
	group  by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
	order by ChucVu
end
go
alter proc lstSearchNameCN
@ProName nvarchar(50)
as
begin
	select cn.*
	from CONG_NHAN cn
	where cn.HoTen  LIKE N'%' + @ProName+ '%'
	group  by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
	order by ChucVu
end
go
lstSearchNameCN N'Dũng'
create proc Tuoi
@tuoi float
as
begin
	select cn.*,DATEDIFF(DAY,NgaySinh,GETDATE()) / 365 as 'Tuoi'
	from CONG_NHAN cn
	where DATEDIFF(DAY,NgaySinh,GETDATE()) / 365=@tuoi
	group  by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
	order by ChucVu
end
go
Tuoi '48'
--8.Hiển thị danh mục công nhân chuẩn bị về hưu (còn làm việc thêm một năm, 54 đối với nam và 49 đối với nữ).
alter proc tuoivehuu
as
begin
select cn.*,DATEDIFF(DAY,NgaySinh,GETDATE()) / 365 as 'Tuổi' from CONG_NHAN cn
where (DATEDIFF(DAY,NgaySinh,GETDATE()) / 365=53 and cn.GioiTinh='Nam') or(DATEDIFF(DAY,NgaySinh,GETDATE()) / 365=48 and cn.GioiTinh=N'Nữ')
end
go

--9. Hiển thị danh mục công nhân có độ tuổi từ 30 đến 45.
create proc khoangtuoi
as
begin
select cn.*,DATEDIFF(DAY,NgaySinh,GETDATE()) / 365 as 'tuổi' from CONG_NHAN cn
where DATEDIFF(DAY,NgaySinh,GETDATE()) / 365<=45 and DATEDIFF(DAY,NgaySinh,GETDATE()) / 365>=30
end
go

create proc cnk @mank int
as
begin
Select nk.NhomThucHienKhoan,cn.HoTen,cnk.ThoiGianBatDau, cnk.ThoiGianKetThuc from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
join CONG_NHAN cn on cn.MaCN=cnk.MaCN where nk.MaNK=@mank
end
cnk 1
create proc daumuc @mank int
as
begin
select cv.TenCV,dmcv.SLThucTe,dmcv.SoLoSP,sp.TenSP from NKSLKs nk join DAU_MUC_CV dmcv on dmcv.MaDMCV=nk.CongViec
join CONG_VIEC cv on cv.MaCV=dmcv.MaCV join SAN_PHAM sp on sp.MaSP=dmcv.SPApDung
where MaNK=@mank
end
daumuc 1
create Proc [lstPB] 
as
begin
select DISTINCT PhongBan from CONG_NHAN
end

create Proc [lstCV] 
as
begin
select DISTINCT ChucVu from CONG_NHAN
end

create Proc [lstGT] 
as
begin
select DISTINCT GioiTinh from CONG_NHAN
end