---------------------------------1 tao database----------------------------------------
CREATE DATABASE NKSLK
	ON PRIMARY
	(	Name=NKSLK_data,
		FileName='D:\NKSLK.mdf',
		Size=40MB,
		MaxSize=50MB,
		FileGrowth=10%
	)
	LOG ON
	(	Name=NKSLK_log,
		FileName='D:\DATANKSLK.ldf',
		Size=10MB,
		MaxSize=15MB,
		FileGrowth=1MB
	)
GO
USE NKSLK
GO
-------------------------------------2 sua database--------------------------------------
ALTER DATABASE NKSLK 
	MODIFY FILE ( NAME = 'NKSLK_data',
	SIZE = 45MB) 

ALTER DATABASE NKSLK 
	MODIFY FILE (NAME = 'NKSLK_log' ,
	MAXSIZE=18MB) 
--------------------------------------3,4,5 tao bang--------------------------------------------
CREATE TABLE NKSLKs(
	MaNK int IDENTITY(1,1),
	NgayThucHienKhoan date ,
	GioBatDau time ,
	GioKetThuc time ,
	NhomThucHienKhoan int ,
	CongViec int
)
GO
CREATE TABLE NHOM_THUC_HIEN_KHOAN(
	MaNhom int IDENTITY(1,1),
	SLThanhVien int
)
GO
CREATE TABLE CONG_NHAN_KHOAN(
	MaCN int not null,
	MaNhom int not null,
	ThoiGianBatDau time,
	ThoiGianKetThuc time,
)
GO
CREATE TABLE CONG_NHAN(
	MaCN int IDENTITY(1,1),
	HoTen nvarchar(50),
	NgaySinh date,
	GioiTinh nvarchar(10),
	PhongBan nvarchar(50),
	ChucVu nvarchar(50),
	QueQuan nvarchar(50)
)
GO

CREATE TABLE DAU_MUC_CV(
	MaDMCV int IDENTITY(1,1),
	MaCV int ,
	SLThucTe float,
	SoLoSP int,
	SPApDung int
) 
GO
CREATE TABLE CONG_VIEC(
	MaCV int IDENTITY(1,1),
	TenCV nvarchar(50),
	DinhMucKhoan int,
	DonViKhoan nvarchar(50),
	HeSoKhoan int,
	DinhMucLaoDong int,
	DonGia decimal
)
GO
CREATE TABLE SAN_PHAM(
	MaSP int IDENTITY(1,1) ,
	TenSP nvarchar(50),
	SoDangKi int,
	HanSuDung date,
	NgayDangKi date,
	QuyCach nvarchar(50),
	HinhAnh varchar(200)
)
GO
CREATE TABLE [dbo].[ACCOUNT](
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Email varchar(100) ,
	Password varchar(100)) 
go

CREATE TABLE [dbo].[ACCOUNT_ROLE](
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ID_ACCOUNT int ,
	ID_ROLE int )
Go
CREATE TABLE [dbo].[ROLE](
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(50)) 
GO
ALTER TABLE [dbo].[ACCOUNT_ROLE]   ADD  CONSTRAINT [FK_role] FOREIGN KEY(ID_ROLE)
REFERENCES [dbo].[ROLE] (ID)
GO
ALTER TABLE [dbo].[ACCOUNT_ROLE]   ADD  CONSTRAINT [FK_account_role] FOREIGN KEY(ID_ACCOUNT)
REFERENCES [dbo].[ACCOUNT] (ID)
GO

INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES (N'admin@gmail.com', N'123')
INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES (N'Thainam120@gmail.com', N'123456')
INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES (N'Tuan@gmail.com', N'123456')
INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES ( N'hoanghien200016@gmail.com', N'123456')
INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES ( N'hien@gmail.com', N'22012000')
INSERT [dbo].[ACCOUNT] ( [Email], [Password]) VALUES ( N'thiet@gmail.com', N'123456')
INSERT [dbo].[ROLE] ( [Name]) VALUES ( N'ADMIN')
INSERT [dbo].[ROLE] ( [Name]) VALUES ( N'WORKER')
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 1, 1)
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 2, 2)
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 3, 2)
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 4, 2)
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 5, 2)
INSERT [dbo].[ACCOUNT_ROLE] ( [ID_ACCOUNT], [ID_ROLE]) VALUES ( 6, 2)

alter table CONG_VIEC
Alter column DonGia float

----------------------------6 tao khoa chinh, khoa ngoai va them dieu kien-------------------
ALTER TABLE NKSLKs
ALTER COLUMN MaNK int NOT NULL 
ALTER TABLE NKSLKs
ALTER COLUMN NgayThucHienKhoan date NOT NULL
ALTER TABLE NHOM_THUC_HIEN_KHOAN
ALTER COLUMN MaNhom int NOT NULL
ALTER TABLE DAU_MUC_CV
ALTER COLUMN MaDMCV int NOT NULL
ALTER TABLE DAU_MUC_CV
ALTER COLUMN MaCV int NOT NULL
ALTER TABLE CONG_VIEC
ALTER COLUMN MaCV int NOT NULL
ALTER TABLE CONG_NHAN_KHOAN
ALTER COLUMN MaCN int NOT NULL
ALTER TABLE CONG_NHAN_KHOAN
ALTER COLUMN MaNhom int NOT NULL
ALTER TABLE CONG_NHAN
ALTER COLUMN MaCN int NOT NULL
ALTER TABLE SAN_PHAM
ALTER COLUMN MaSP int NOT NULL
GO

ALTER TABLE NKSLKs
ADD CONSTRAINT PK_NKSLK PRIMARY KEY (MaNK) 
ALTER TABLE NHOM_THUC_HIEN_KHOAN
ADD CONSTRAINT PK_NHOM_THUC_HIEN_KHOAN PRIMARY KEY (MaNhom)
ALTER TABLE DAU_MUC_CV
ADD CONSTRAINT PK_DAU_MUC_CV PRIMARY KEY (MaDMCV)
ALTER TABLE CONG_VIEC
ADD CONSTRAINT PK_CONG_VIEC PRIMARY KEY (MaCV)
ALTER TABLE CONG_NHAN
ADD CONSTRAINT PK_CONG_NHAN PRIMARY KEY (MaCN)
ALTER TABLE SAN_PHAM
ADD CONSTRAINT PK_SAN_PHAM PRIMARY KEY (MaSP)
GO
ALTER TABLE CONG_NHAN_KHOAN
ADD CONSTRAINT PK_CONG_NHAN_KHOAN PRIMARY KEY (MaCN,MaNhom)
GO

ALTER TABLE [dbo].[CONG_NHAN_KHOAN]   ADD  CONSTRAINT [FK_CONG_NHAN_KHOAN_CONG_NHAN] FOREIGN KEY([MaCN])
REFERENCES [dbo].[CONG_NHAN] ([MaCN])
GO

ALTER TABLE [dbo].[CONG_NHAN_KHOAN]   ADD  CONSTRAINT [FK_CONG_NHAN_KHOAN_NHOM_THUC_HIEN_KHOAN] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NHOM_THUC_HIEN_KHOAN] ([MaNhom])
GO
ALTER TABLE [dbo].[DAU_MUC_CV]   ADD  CONSTRAINT [FK_DAU_MUC_CV_CONG_VIEC] FOREIGN KEY([MaCV])
REFERENCES [dbo].[CONG_VIEC] ([MaCV])
GO
ALTER TABLE [dbo].[DAU_MUC_CV]   ADD  CONSTRAINT [FK_DAU_MUC_CV_SAN_PHAM] FOREIGN KEY([SPApDung])
REFERENCES [dbo].[SAN_PHAM] ([MaSP])
GO

ALTER TABLE [dbo].[NKSLKs]   ADD  CONSTRAINT [FK_NKSLK_DAU_MUC_CV] FOREIGN KEY([CongViec])
REFERENCES [dbo].[DAU_MUC_CV] ([MaDMCV])
GO

ALTER TABLE [dbo].[NKSLKs]   ADD  CONSTRAINT [FK_NKSLK_NHOM_THUC_HIEN_KHOAN] FOREIGN KEY([NhomThucHienKhoan])
REFERENCES [dbo].[NHOM_THUC_HIEN_KHOAN] ([MaNhom])
GO

ALTER TABLE SAN_PHAM
	ADD	
	CONSTRAINT UNQ_SanPham_TenSP UNIQUE(TenSP),
	CONSTRAINT CHK_SanPham_HSD CHECK(HanSuDung >NgayDangKi)
GO
ALTER TABLE CONG_VIEC
	ADD	CONSTRAINT CHK_CV_ADMLD CHECK(DinhMucKhoan>0)
GO

ALTER TABLE CONG_VIEC
  ALTER COLUMN DonGia float;
GO
----------------------------------------7,8 them du lieu------------------------------------------                                        
--------------- insert công nhân(20)
INSERT INTO CONG_NHAN(HoTen, NgaySinh,GioiTinh, PhongBan, ChucVu, QueQuan)
--5 data khác nhau
     VALUES 
	 	 	(N'Hoàng  Ngọc Anh','1972-10-28',N'Nữ',N'Phòng quản lý',N'Nhân viên',N'Phú Thọ'),
			(N'Nguyễn Văn Dũng','1968-09-26','Nam',N'Phòng Kho',N'Quản lý kho',N'Nam Định'),
	 	 	(N'Hoàng  Ngọc Linh','1973-10-28',N'Nữ',N'Phòng quản lý',N'Nhân viên',N'Phú Thọ'),
			(N'Nguyễn Văn Tuân','1968-10-26','Nam',N'Phòng Kho',N'Quản lý kho',N'Nam Định'),
	 		(N'Nguyễn Văn Đăng','1973-11-28',N'Nữ',N'Phòng quản lý',N'Nhân viên',N'Phú Thọ'),
			(N'Đoàn Anh Quân','1968-10-26','Nam',N'Phòng Kho',N'Quản lý kho',N'Nam Định'),
			(N'Kiều Trung Anh','1968-10-27','Nam',N'Phòng Kho',N'Nhân viên',N'Bắc Giang'),
			(N'Đặng Thị Hằng','1998-09-26',N'Nữ',N'Ban giám đốc',N'Tổng giám đốc',N'Hà Tĩnh'),
			(N'Lê Anh Quân','1995-11-10','Nam',N'Ban giám đốc',N'Phó giám đốc',N'Hà Nội'),
			(N'Hoàng Thị Hiên','1998-11-28',N'Nữ',N'Ban giám đốc',N'Phó giám đốc',N'Phú Thọ'),
			(N'Đoàn Anh Quân','1997-10-26','Nam',N'Phòng Kho',N'Quản lý kho',N'Nam Định'),
			(N'Kiều Trung Anh','1996-10-27','Nam',N'Phòng Kho',N'Nhân viên',N'Bắc Giang'),
--5 data quequan = null
			(N'Nguyễn Đức Trung','1995-10-26','Nam',N'Phòng Kho',N'Nhân viên',null),
			(N'Nguyễn Xuân Minh','1999-12-10','Nam',N'Phòng Kho',N'Nhân viên',null),
			(N'Phạm Văn Vũ','1999-11-11','Nam',N'Phòng Kho',N'Nhân viên',null),
			(N'Trần Văn Nguyên','1999-10-26','Nam',N'Phòng Kho',N'Phó quản lý kho',null),
			(N'Đàm Vĩnh Tùng','1990-10-26','Nam',N'Phòng Kho',N'Nhân viên',null),
--5 data ngaynamsinh= null
			(N'Trần Văn Nam',null,'Nam',N'Phòng quản lý',N'Quản lý công việc',N'Thanh Hóa'),
			(N'Vũ Hưng',null,'Nam',N'Phòng quản lý',N'Nhân viên',N'Hà Tĩnh'),
			(N'Nguyễn Văn Thịnh',null,'Nam',N'Phòng quản lý',N'Nhân viên',N'Nghệ An'),
			(N'Trần Văn',null,'Nam',N'Phòng quản lý',N'Nhân viên',N'Huế'),
			(N'Đàm Thị Na',null,N'Nữ',N'Phòng quản lý',N'Nhân viên',N'Đà Nẵng'),
--5 data hoten trung nhau
			(N'Nguyễn Văn Hải','1998-01-01','Nam',N'Phòng quản lý',N'Nhân viên',N'Tp HCM'),
			(N'Nguyễn Văn Hải','1997-01-01','Nam',N'Phòng quản lý',N'Nhân viên',N'Cà Mau'),
			(N'Nguyễn Văn Hải','1999-04-05','Nam',N'Phòng quản lý',N'Nhân viên',N'Bình Dương'),
			(N'Nguyễn Văn Hải','1991-07-07','Nam',N'Phòng quản lý',N'Nhân viên',N'Phú Quốc'),
			(N'Nguyễn Văn Hải','1993-01-05','Nam',N'Ban Tài chính',N'Quản lý tài chính',N'Phan Thiết'),
--5 data quequan trung nhau
			(N'Nguyễn Tùng Sơn','1980-01-01','Nam',N'Ban Tài chính',N'Nhân viên',N'Quảng Bình'),
			(N'Lê Tùng Sơn','1981-01-01','Nam',N'Ban Tài chính',N'Nhân viên',N'Quảng Bình'),
			(N'Trần Tùng Sơn','1982-04-05','Nam',N'Phòng bảo vệ',N'Nhân viên',N'Quảng Bình'),
			(N'Vũ Tùng Sơn','1983-07-07','Nam',N'Phòng bảo vệ',N'Nhân viên',N'Quảng Bình'),
			(N'Quách Tùng Sơn','1984-01-05','Nam',N'Phòng bảo vệ',N'Nhân viên',N'Quảng Bình')
---------------------insert 10 data san pham
INSERT INTO SAN_PHAM(TenSP,SoDangKi,HanSuDung,QuyCach,NgayDangKi)
     VALUES
           (N'Sữa rửa mặt simple',12,'2023-01-01',N'sữa rửa mặt','2021-01-01'),
		   (N'Sữa rửa mặt Decumar',13,'2023-02-01',N'sữa rửa mặ','2021-02-01'),
		   (N'Sữa rửa mặt Cosrx',14,'2023-03-01',N'sữa rửa mặ','2021-03-01'),
		   (N'Kem chống nắng Sunplay',16,'2024-05-01',N'Kem chống nắng','2021-05-01'),
		   (N'Kem chống nắng Anessa',17,'2024-06-06',N'Kem chống nắng','2018-06-06'),
		   (N'Kem dưỡng ẩm innisfree',19,'2024-04-08',N'Kem dưỡng ẩm','2019-04-08'),
		   (N'Kem dưỡng ẩm vaseline',21,'2024-07-08',N'Kem dưỡng ẩm','2017-07-08'),
		   (N'Toner rau diếp cá',22,'2023-06-09',N'Toner','2021-06-09'),
		   (N'Toner simple',24,'2023-04-09',N'Toner','2017-04-09'),
		   (N'serum centella',26,'2023-02-09',N'serum','2018-02-09'),
		   (N'serum balance',27,'2022-01-09',N'serum','2021-01-09'),
		   (N'Sữa rửa mặt Innisfree',12,'2023-02-01',N'sữa rửa mặt','2018-05-09')
GO
-------------------insert 10 data cong viec
INSERT INTO CONG_VIEC(TenCV,DinhMucKhoan,DonViKhoan,HeSoKhoan,DinhMucLaoDong,DonGia)
     VALUES  (N'Vận chuyển trong xưởng',7,N'Thùng',5,15,null),
			 (N'Vận chuyển khách hàng',6,N'Thùng',5,13,null),
			 (N'Đóng hàng sữa rửa mặt',7,N'Thùng',6,15,null),
			 (N'Đóng hàng kem chống nắng',2,N'Thùng',5,5,null),
			 (N'Đóng hàng toner',3,N'Thùng',5,4,null),
			 (N'Đóng hàng serum',8,N'Thùng',3,11,null),
			 (N'Sản xuất SRM giai đoạn 1',8,N'Tuýp',5,20,null),
			 (N'Sản xuất Toner 1',8,N'chai',5,17,null),
			 (N'Sản xuất kem chống nắng 1',10,N'Tuýp',2,11,null),
			 (N'Sản xuất kem dưỡng ẩm 1',10,N'Hộp',5,12,null),
			 (N'Sản xuất serum 1',11,N'chai',13,16,null)
			
GO
--------insert bảng NKSLK
--10 bản ghi là NKSLK làm riêng
INSERT INTO DAU_MUC_CV(MaCV,SLThucTe, SoLoSP, SPApDung)
	VALUES  (1,10,20,1),
			(2,11,21,2),
			(3,12,22,3),
			(4,13,23,4),
			(5,14,24,5),
			(6,15,25,6),
			(7,16,26,7),
			(8,9,27,8),
			(9,10,28,9),
			(10,8,29,10)
GO

INSERT INTO [dbo].[NHOM_THUC_HIEN_KHOAN]([SLThanhVien])
     VALUES
		 (1),
		 (1),
		 (1),
		 (1),
		 (1),
		 (1),
		 (1),
		 (1),
		 (1),
		 (1)

GO
INSERT INTO [dbo].[NKSLKs]([NgayThucHienKhoan],[GioBatDau],[GioKetThuc],[NhomThucHienKhoan],[CongViec])
     VALUES
           
	 	   ('2021-07-22','14:00','22:00',8,1),
		   ('2021-08-25','22:00','06:00',9,1),
		   ('2021-06-23','22:00','06:00',10,2),  
		   ('2021-01-20','6:00','14:00',1,2),
		   ('2021-01-21','6:00','14:00',2,3),
		   ('2021-02-20','6:00','14:00',3,3),
		   ('2021-02-23','14:00','22:00',4,4),
		   ('2017-05-14','14:00','22:00',5,4),
		   ('2018-02-23','14:00','22:00',6,5),
		   ('2016-02-23','14:00','22:00',7,5)
		   
GO
INSERT INTO [dbo].[CONG_NHAN_KHOAN]([MaCN],[MaNhom],[ThoiGianBatDau] ,[ThoiGianKetThuc])
     VALUES
           
		   (1,1,'6:00','14:00'),
		   (2,2,'6:00','14:00'),
		   (3,3,'6:00','14:00'),
		   (4,4,'14:00','22:00'),
		   (5,5,'14:00','22:00'),
		   (6,6,'14:00','22:00'),
		   (7,7,'14:00','22:00'),
		   (8,8,'14:00','22:00'),
		   (9,9,'22:00','06:00'),
		   (10,10,'22:00','06:00')

GO
--10 bản ghi là NKSLK làm chung
--10 bản ghi làm chung nhưng có nhân công đi muộn 1h so mới giờ của nhóm

INSERT INTO [dbo].[NHOM_THUC_HIEN_KHOAN]([SLThanhVien])
     VALUES
		   (2),
		   (2),
		   (3),
		   (2),
		   (2),
		   (3),
		   (2),
		   (4),
		   (2),
		   (2)

GO
INSERT INTO [dbo].[NKSLKs]([NgayThucHienKhoan],[GioBatDau],[GioKetThuc],[NhomThucHienKhoan],[CongViec])
     VALUES
		   ('2021-01-26','6:00','14:00',11,5),
		   ('2021-01-27','6:00','14:00',12,6),
		   ('2021-02-24','22:00','6:00',13,7),
		   ('2021-01-28','6:00','14:00',14,8),
		   ('2021-01-29','22:00','6:00',15,5),
		   ('2021-02-25','14:00','22:00',16,6),
		   ('2021-01-13','14:00','22:00',17,7),
		   ('2021-02-26','6:00','14:00',18,8),
		   ('2021-01-14','14:00','22:00',19,9),
		   ('2021-02-27','14:00','22:00',20,10)
		   
GO
INSERT INTO [dbo].[CONG_NHAN_KHOAN]([MaCN],[MaNhom],[ThoiGianBatDau] ,[ThoiGianKetThuc])
     VALUES
	 --5 bản ghi là NKSLK làm chung đúng giờ
		   (11,11,'6:00','14:00'),
		   (12,12,'6:00','14:00'),
		   (13,13,'22:00','6:00'),
		   (21,13,'22:00','6:00'),
		   (14,14,'6:00','14:00'),
		   (15,15,'22:00','6:00'),
		   (16,16,'14:00','22:00'),
		   (22,16,'14:00','22:00'),
		   (17,17,'14:00','22:00'),
		   (24,18,'6:00','14:00'),
	 --5 bản ghi làm chung nhưng có nhân công đi muộn 1h so mới giờ của nhóm,
		   (25,11,'07:00','14:00'),
		   (26,12,'07:00','14:00'),
		   (27,13,'23:00','06:00'),
		   (28,14,'07:00','14:00'),
		   (29,15,'23:00','05:00'),
		   (30,16,'15:00','22:00'),		   
		   (18,18,'7:00','12:00'),
		   (23,18,'7:00','14:00'),
		   (19,18,'15:00','22:00'),
		   (20,17,'15:00','21:00')
GO

CREATE TRIGGER setDonGia ON CONG_VIEC FOR INSERT,UPDATE
	AS 
	IF  UPDATE(HeSoKhoan) OR UPDATE (DinhMucKhoan) OR UPDATE (DinhMucLaoDong)
	UPDATE CONG_VIEC SET DonGia = 126360 * HeSoKhoan * (DinhMucLaoDong/DinhMucKhoan)
GO
--CÂU 9---
/*1 Hiển thị NKSLK trong tháng, tuần của một nhân viên bất kỳ.
Tuần được tính từ ngày thứ 2 đến hết ngày chủ nhật (tuần chẵn), hoặc từ
ngày 01 đến chủ nhật( nếu ngày 01 khác thứ 2) hoặc từ ngày thứ 2 
đến ngày cuối tháng(nếu ngày cuối tháng khác chủ nhật) (những 
tuần như thế gọi là tuần lẻ).*/
--tháng
select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan
from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
where nk.NgayThucHienKhoan BETWEEN '2021-02-01' and DATEADD( DAY,DAY(EOMONTH('2021-02-01')),'2021-02-01') and MaCN=18 
go
--tuần
select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan  
from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
where nk.NgayThucHienKhoan between dbo.getFirstDateOfWeek('2021-2-25') and dbo.getLastDateOfWeek('2021-2-25') and MaCN=18
go

create function getFirstDateOfWeek (@date date)
returns date
as
begin
	declare @firstDate date
	set @firstDate = DATEADD(week, DATEDIFF(week, 0, (dateadd(day, -1, @date))), 0) 
	if (MONTH(@firstDate) != MONTH(@date))
		set @firstDate = DATEADD(month, DATEDIFF(month, 0, @date), 0)
	return @firstDate
end

create function getLastDateOfWeek (@date date)
returns date
as
begin
	declare @lastDate date
	set @lastDate = DATEADD(week, DATEDIFF(week, 0, (dateadd(day,-1,@date))), 6) 
	if (MONTH(@lastDate) != MONTH(@date))
		set @lastDate = DATEADD(month, DATEDIFF(month, -1, @date), -1)
	return @lastDate
end


--2. hien thị công việc có nhiều lần khoán nhất
select  CongViec,count(CongViec) as cv 
from NKSLKs
group by CongViec
go

 declare @max int
select @max=MAX(t.cv)
from (select count(CongViec) as cv 
		from NKSLKs
		group by CongViec ) t
Select n.CongViec,c.TenCV,count(n.CongViec) as 'Số lần khoán'
from NKSLKs n join Cong_Viec c on n.CongViec=c.MaCV
group by n.CongViec,c.TenCV
having count(n.CongViec)=@max
go

 --3. hiển thị công việc có đơn giá cao nhất, nhỏ nhất
 select MAX(DonGia) as ma,MIN(DonGia) as mi 
 from CONG_VIEC
 go
 declare @max decimal(18, 0),@min decimal(18, 0)
select @max=t.ma,@min=t.mi
from (select MAX(DonGia) as ma,MIN(DonGia) as mi from CONG_VIEC) t
select c.MaCV,c.TenCV,c.HeSoKhoan,c.DonViKhoan,c.DinhMucLaoDong,c.DinhMucKhoan,DonGia  from CONG_VIEC c
where c.DonGia=@max or c.DonGia=@min

--4. Hiển thị thông tin công việc có đơn giá lớn hơn, nhỏ hơn đơn giá trung bình của cả danh mục công việc.
select AVG(DonGia) as a 
from CONG_VIEC
go
declare @tb decimal(18, 0)
select @tb=t.a
from (select AVG(DonGia) as a from CONG_VIEC ) t
select c.MaCV,c.TenCV,c.HeSoKhoan,c.DonViKhoan,c.DinhMucLaoDong,c.DinhMucKhoan,c.DonGia 
from CONG_VIEC c
where  c.DonGia>@tb 
go
--5.  Hiển thị danh mục sản phẩm có ngày đăng ký trước ngày 15/08/2019.

select sp.* 
from SAN_PHAM sp 
where sp.NgayDangKi<='2019-08-15'
go
-- 6 . Hiển thị danh mục các sản phẩm có hạn sử dụng trên 1 năm từ ngày sản xuất.
select sp.MaSP,sp.TenSP,sp.QuyCach,DATEDIFF(DAY,'2019-07-07',HanSuDung) / 365 AS 'số năm sử dụng'
from SAN_PHAM sp
where DATEDIFF(DAY,'2019-07-07',HanSuDung) / 365>1
go
--7. Hiển thị danh mục công nhân được nhóm theo phòng ban, chức vụ
select cn.*
from CONG_NHAN cn
group by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
order by PhongBan
go
select cn.*
from CONG_NHAN cn
group by cn.MaCN,cn.HoTen,cn.GioiTinh,cn.ChucVu,cn.PhongBan,cn.QueQuan,cn.NgaySinh
order by ChucVu
go

--8.iển thị danh mục công nhân chuẩn bị về hưu (còn làm việc thêm một năm, 54 đối với nam và 49 đối với nữ).
select cn.*,DATEDIFF(DAY,NgaySinh,GETDATE()) / 365 as 'Tuổi' from CONG_NHAN cn
where (DATEDIFF(DAY,NgaySinh,GETDATE()) / 365=53 and cn.GioiTinh='True') or(DATEDIFF(DAY,NgaySinh,GETDATE()) / 365=48 and cn.GioiTinh='False')
go

--9. Hiển thị danh mục công nhân có độ tuổi từ 30 đến 45.
select cn.*,DATEDIFF(DAY,NgaySinh,GETDATE()) / 365 as 'tuổi' from CONG_NHAN cn
where DATEDIFF(DAY,NgaySinh,GETDATE()) / 365<=45 and DATEDIFF(DAY,NgaySinh,GETDATE()) / 365>=30
go

--10. Hiển thị danh mục công nhân có NKSLK được thực hiện ở ca 3
Select cn.*,cnk.ThoiGianBatDau,cnk.ThoiGianKetThuc 
from  CONG_NHAN_KHOAN cnk join CONG_NHAN cn on cnk.MaCN=cn.MaCN 
Where cnk.ThoiGianBatDau>='22:00:00' and cnk.ThoiGianKetThuc<='06:00:00'
go

--11.Hiển thị danh mục NKSLK của toàn bộ công nhân trong nhà máy theo tuần, tháng.

--tháng
select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan
from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
where nk.NgayThucHienKhoan BETWEEN '2021-02-01' and DATEADD( DAY,DAY(EOMONTH('2021-02-01')),'2021-02-01')
go
--tuần
select nk.NgayThucHienKhoan,cnk.MaCN,nk.NhomThucHienKhoan  
from NKSLKs nk join CONG_NHAN_KHOAN cnk on nk.NhomThucHienKhoan=cnk.MaNhom
where nk.NgayThucHienKhoan between dbo.getFirstDateOfWeek('2021-2-25') and dbo.getLastDateOfWeek('2021-2-25')
go

--12. Hiển thị bảng lương sản phẩm của toàn bộ công nhân trong nhà máy, theo tuần, theo tháng
--( Lương được tính của 1 công nhân = tổng toàn bộ (sản lượng thực sự làm được * đơn giá của mã công việc đó) 
--nếu công việc đó được làm riêng, còn nếu làm chung thì 
--lương được hưởng của công nhân đó trong công việc chung = tổng 
--toàn bộ (sản lượng thưc sự làm được * đơn giá của mã công việc 
--đó)* thời gian của cá nhân đó làm việc trong nhóm/ tổng thời gian 
--tham gia vào ca của cả nhóm

Create VIEW v_ThoiGianCaNhan AS 
SELECT a.MaNK, b.MaNhom, c.MaCN, c.HoTen, a.NgayThucHienKhoan,
IIF(DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) > 0, CAST(DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) AS FLOAT), 
CAST((DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) + 24) AS FLOAT)) AS 'ThoiGianCaNhan'
FROM NKSLKs AS a, CONG_NHAN_KHOAN as b, CONG_NHAN AS c
WHERE a.NhomThucHienKhoan = b.MaNhom AND b.MaCN = c.MaCN 
GO
--DROP VIEW dbo.v_ThoiGianCaNhan
GO


-------VIEW TỔNG THỜI GIAN MỘT NHÓM LÀM VIỆC
CREATE VIEW v_ThoiGianNhom AS
SELECT a.MaNK, a.MaNhom, CAST(SUM(a.ThoiGianCaNhan) AS FLOAT) AS 'TongThoiGian'
FROM dbo.v_ThoiGianCaNhan AS a
GROUP BY a.MaNK, a.MaNhom
GO
--DROP VIEW dbo.v_ThoiGianNhom
GO


------VIEW TỶ LỆ THỜI GIAN CÁ NHÂN / THỜI GIAN NHÓM
create VIEW v_TyLe AS
SELECT a.MaNK, a.MaNhom, a.MaCN,a.HoTen, a.NgayThucHienKhoan, ROUND(a.ThoiGianCaNhan/b.TongThoiGian, 2) AS 'TyLe'
FROM dbo.v_ThoiGianCaNhan AS a, dbo.v_ThoiGianNhom AS b
WHERE  a.MaNhom = b.MaNhom
GO
--DROP VIEW dbo.v_TyLe


-------VIEW SẢN LƯỢNG THỰC SỰ LÀM ĐƯỢC * ĐƠN GIÁ MÃ CÔNG VIỆC
CREATE VIEW v_TongToanBo AS
SELECT a.MaNK, b.MaNhom, c.SLThucTe*d.DonGia  as TongToanBo
FROM NKSLKs AS a, CONG_NHAN_KHOAN AS b, DAU_MUC_CV AS c, CONG_VIEC AS d
WHERE  a.NhomThucHienKhoan = b.MaNhom AND c.MaCV = d.MaCV
GO
--DROP VIEW dbo.v_TongToanBo


------TẠO VIEW VỚI THÔNG TIN (THỜI GIAN CÁ NHÂN/THỜI GIAN NHÓM) VÀ (SẢN LƯỢNG THỰC SỰ * ĐƠN GIÁ)
create VIEW v_Luong AS
SELECT a.MaCN, a.TyLe * b.TongToanBo AS 'Luong', a.NgayThucHienKhoan, a.HoTen
FROM dbo.v_TyLe AS a, dbo.v_TongToanBo AS b
WHERE a.MaNhom = b.MaNhom 
GO
--DROP VIEW dbo.v_Luong


------PROC TÍNH TOÁN LƯƠNG SP THEO TUẦN (****)
create PROC LuongSP_Tuan
@Ngay DATETIME
AS
BEGIN
	SELECT MaCN, SUM(Luong) AS 'Luong',HoTen, NgayThucHienKhoan
	FROM dbo.v_Luong
	where NgayThucHienKhoan between dbo.getFirstDateOfWeek(@Ngay) and dbo.getLastDateOfWeek(@Ngay)
	GROUP BY MaCN,HoTen,NgayThucHienKhoan
	ORDER BY MaCN
END
GO
--DROP PROC dbo.LuongSP_Tuan

EXEC dbo.LuongSP_Tuan @Ngay = '2021-01-29'
GO
------PROC TÍNH TOÁN LƯƠNG SP THEO TUẦN (****)
CREATE PROC LuongSP_Thang
@Ngay DATETIME
AS
BEGIN
	SELECT MaCN, SUM(Luong) AS 'Luong',HoTen, NgayThucHienKhoan
	FROM dbo.v_Luong
	where NgayThucHienKhoan BETWEEN (@Ngay) and DATEADD( DAY,DAY(EOMONTH(@Ngay)),@Ngay) 
	GROUP BY MaCN,HoTen,NgayThucHienKhoan
	ORDER BY MaCN
END
GO
EXEC dbo.LuongSP_Thang @Ngay = '2021-01-20'
-- Tất cả các ngày
CREATE PROC AllLuongSP_Tuan
AS
BEGIN
SELECT MaCN, SUM(Luong) AS 'Luong',HoTen, NgayThucHienKhoan
	FROM dbo.v_Luong
	GROUP BY MaCN,HoTen,NgayThucHienKhoan
	ORDER BY MaCN
END
GO

--13. Hiển thị số ngày công đi làm trong tháng của một công nhân bất 
--kỳ, của toàn bộ công nhân trong nhà máy (quy đổi ra công bằng 
--cách 8h tương đương 1 công, riêng ca 3 thì được nhân hệ số 1.3)
--Tính time làm việc của công nhân
ALTER VIEW v_ThoiGianLamViec AS 
SELECT  c.MaCN,c.HoTen,b.ThoiGianBatDau,a.NgayThucHienKhoan,
IIF(DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) > 0, CAST(DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) AS FLOAT), 
CAST((DATEDIFF(HOUR, b.ThoiGianBatDau, b.ThoiGianKetThuc) + 24) AS FLOAT)) AS ThoiGianLamViec
FROM NKSLKs a,  CONG_NHAN_KHOAN as b, CONG_NHAN AS c
WHERE  a.NhomThucHienKhoan=b.MaNhom and b.MaCN = c.MaCN 
GO
--Tính tỉ lệ
ALTER VIEW v_TL AS
SELECT a.MaCN,a.HoTen,a.ThoiGianBatDau,a.NgayThucHienKhoan,IIF(a.ThoiGianBatDau<'22:00:00',CAST((a.ThoiGianLamViec/8)*1 AS FLOAT),
CAST((a.ThoiGianLamViec/8)*1.3 AS FLOAT)) AS TyLe
FROM dbo.v_ThoiGianLamViec a
GO

Create Proc CongNT  @Month INT, @Year INT
 as
 begin
 select v.MaCN,v.HoTen, CAST(SUM(v.TyLe) AS FLOAT) AS cong from v_TL v
 Where  MONTH(v.NgayThucHienKhoan)=@Month and YEAR(v.NgayThucHienKhoan)=@Year group by v.MaCN,v.HoTen
 end
 Cong_TatCaCN
	
--14. Hiển thị thông tin lương sản phẩm của công nhân có lương sản 
--phẩm cao nhất, ít nhất.

 	SELECT Top(1)  MaCN ,SUM(Luong) AS 'Lương Sản Phẩm'
	FROM dbo.v_Luong 
	GROUP BY MaCN
	Order by Sum(Luong) desc
	Go
	SELECT Top(1)  MaCN ,SUM(Luong) AS 'Lương Sản Phẩm'
	FROM dbo.v_Luong 
	GROUP BY MaCN
	Order by Sum(Luong) asc
	Go

--15. .Hiển thị danh mục công nhân có số giờ làm việc trong tuần bất kỳ
--vượt giờ công chuẩn trong tuần (44 là giờ chuẩn công nhân phải 
--làm khi tuần đó chẵn là tuần chẵn, >n (n là giờ chuẩn công nhân 
--phải làm khi tuần đó lẻ, được tính = tổng số ngày thường trong 
--tuần * 8 + 4 tiếng của ngày thứ 7, nếu tuần đó có thứ 7)
CREATE FUNCTION ThoiGianCongChuan(@Ngay DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @FirstDayOfWeek DATETIME = dbo.getFirstDateOfWeek(@Ngay)
	DECLARE @LastDayOfWeek DATETIME = dbo.getLastDateOfWeek(@Ngay)

	DECLARE @GioCongChuan INT = 0	

	WHILE(DATEDIFF(DAY, @FirstDayOfWeek, @LastDayOfWeek) >= 0)		
	BEGIN
	    IF(DATEPART(WEEKDAY, @FirstDayOfWeek) <> 1 AND DATEPART(WEEKDAY, @FirstDayOfWeek) <> 7)
			SELECT @GioCongChuan = @GioCongChuan + 8
		ELSE IF(DATEPART(WEEKDAY, @FirstDayOfWeek) = 7)
			SELECT @GioCongChuan = @GioCongChuan + 4

		SELECT @FirstDayOfWeek = DATEADD(DAY, 1, @FirstDayOfWeek)
	END

	RETURN @GioCongChuan
END
GO
--Tính vượt time công chuẩn
CREATE PROC VuotThoiGianCongChuan
@Ngay DATETIME
AS
BEGIN
	    SELECT MaCN, SUM(ThoiGianLamViecCaNhan) AS 'GioLamViec'
		FROM dbo.v_ThoiGianLamViecCaNhan
		WHERE NgayThucHienKhoan >= dbo.getFirstDateOfWeek(@Ngay) AND NgayThucHienKhoan <= dbo.getLastDateOfWeek(@Ngay)
		GROUP BY MaCN
		HAVING SUM(ThoiGianLamViecCaNhan) > dbo.ThoiGianCongChuan(@Ngay)
END
GO
--DROP PROC dbo.VuotThoiGianCongChuan
EXEC dbo.VuotThoiGianCongChuan @Ngay = '2021-01-20'


-----------------------------------------------------------
------------proc cho Chức năng khoán
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
create proc Tuan_CN
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
create proc Thang
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
Tuan '2021-07-02'
 ---------------------------proc cho chức năng Công nhân
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
lstSearchNameCN N'Nguyễn Xuân Minh'
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
