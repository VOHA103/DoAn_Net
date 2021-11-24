
use master
go

if exists(select *from sysdatabases where name='QLPHONGTRO')
drop database QLPHONGTRO
go



create database QLPHONGTRO
go
use QLPHONGTRO
go


create table LOAIPHONG(
MALOAI char(10) primary key,
TENLOAI nvarchar(20),
GIAPHONG float,
GHICHU nvarchar(100),
)
go

CREATE TABLE PHONG
(
MAPHONG char(10) PRIMARY KEY,
MALOAI char(10),
TENPHONG NVARCHAR(50),
TRANGTHAI char(20),
CONSTRAINT FK_P_LP FOREIGN KEY(MALOAI) REFERENCES LOAIPHONG(MALOAI)
)
go

create table KHACHHANG(
MAKHACHHANG char(10) primary key,
TENKHACHHANG nvarchar(50),
DIACHI nvarchar(150),
CMND nchar(20),
SDT nchar(11)
)
go

create table HOPDONG(
SOHOPDONG char(20) primary key,
MAPHONG char(10),
TIENCOC int,
NGAYTHUE datetime,
NGAYTRA datetime,
CONSTRAINT FK_HD_P FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG)
)
go

create table DICHVU(
MADICHVU char(10) primary key,
TENDICHVU nvarchar(50),
GIATIEN int,
GHICHU nvarchar(200)
)
go


create table HOADON(
MAHOADON int identity(1,1)  primary key,
MAPHONG char(10),
TONGTIEN int,
THANG_THANHTOAN datetime,
CONSTRAINT FK_HD_P2 FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG)
)
go

create table CTHD(
MAHOADON int,
MADICHVU char(10),
MAKHACHHANG char(10),
SOLUONG int,
THANHTIEN int,
CONSTRAINT PK_CTHD PRIMARY KEY(MAHOADON,MADICHVU,MAKHACHHANG),
CONSTRAINT FK_HD_KH FOREIGN KEY(MAKHACHHANG) REFERENCES KHACHHANG(MAKHACHHANG),
CONSTRAINT FK_CTHD_HD FOREIGN KEY(MAHOADON) REFERENCES HOADON(MAHOADON),
CONSTRAINT FK_CTHD_DV FOREIGN KEY(MADICHVU) REFERENCES DICHVU(MADICHVU)
)
go

create table TAIKHOAN(
TAIKHOAN char(20) primary key,
MATKHAU char(50),
PHANQUYEN int,
)
go

--select distinct(MAKHACHHANG) from CTHD where MAHOADON='3'
--user:admin pass:admin
insert into TAIKHOAN values('admin','21232f297a57a5a743894a0e4a801fc3',1);
insert into TAIKHOAN values('Hà','202cb962ac59075b964b07152d234b70',0);
insert into TAIKHOAN values('Huyền ','202cb962ac59075b964b07152d234b70',0);

--select * from TAIKHOAN where TAIKHOAN='admin'
go

----INSERT DATA
--TbLoaiPhong(MaLoai, TenLoai, GiaPhong, GhiChu)
insert into LOAIPHONG  values ('L001', N'Phòng đơn', 1500000, null);
insert into LOAIPHONG 	values   ('L002', N'Nhà nguyên căn',3000000,null);

go

--TbPhong(MaPhong, MaLoai, TenPhong,TrangThai)
insert into PHONG values ('P001', 'L001',N'Phòng Số 1', N'Đã Thuê');
insert into PHONG values ('P002','L002',N'Phòng Số 2', N'Đã thuê');
insert into PHONG values ('P003','L002',N'Phòng Số 4',null);
insert into PHONG values ('P004','L002',N'Phòng Số 3',null);
go

--TbKhachHang(MaKhachHang,TenKhachHang,DiaChi,CMND,SDT)
insert into KHACHHANG values ('KH001', N'Nguyễn Thị Ngọc',N'906 Trường Chinh, Tân Bình,TPHCM','927345678125','0347524568');
insert into KHACHHANG values('KH002',N'Nguyễn Ngọc Phương',N'873 Lê Hồng Phông, Q5, TPHCM','918590387193','0347924197');
insert into KHACHHANG values ('KH003', N'Võ Thị Thu Hà',N'Bình Định','9185903871890' ,'0328090646');
go

--TbHopDong(SoHopDong, MaPhong, TienCoc, NgayThue, NgayTra)
SET DATEFORMAT dmy
insert into HOPDONG values ('HD001', 'P001',3000000,'10/10/2019',null);
insert into HOPDONG values('HD002','P002', 5000000, '1/2/2018', null );
insert into HOPDONG values('HD003','P002', 5000000, '1/2/2019', null );
go

--TbDichVu(MaDichVu,TenDichVu,GiaTien,GhiChu)
insert into DICHVU values ('DV001', N'Điện',3000, null); 
insert into DICHVU values('DV002',N'Nước',7000, null );
insert into DICHVU values('DV003',N'Internet',100000, null);
insert into DICHVU values('DV004', N'Rác',15000, null);
go

--TbHoaDon(MaHoaDon,MaPhong,TongTien,ThangThanhToan)
insert into HOADON values ('P001',1605000,1);
insert into HOADON values('P002',3153000,1);
insert into HOADON values ('P003',null,null);
go

select*from HOADON

--tbChiTietHoaDon(MaHoaDon,MaDichVu,MaKhachHang,SoLuong,ThanhTien)
insert into CTHD values ('1','DV001','KH001',20,60000)	;
insert into CTHD values('1','DV002','KH001',5,30000)	;
insert into CTHD values('1','DV004','KH001',null,15000)	;
insert into CTHD values('2','DV001','KH002',25,100000)	;
insert into CTHD values('2','DV002','KH002',4,28000)	;
insert into CTHD values('2','DV003','KH002',null,100000);
insert into CTHD values('2','DV004','KH002',null,15000)	;
insert into CTHD values ('3','DV001','KH001',20,60000);

go
--select * from HOADON
--delete from CTHD where MADICHVU='' and MAHOADON=''
--update HOADON set THANG_THANHTOAN='2' where MAHOADON='1'
--select * from PHONG
--select * from HOPDONG
--update HOPDONG set NGAYTRA='' where SOHOPDONG=''
--update PHONG set TRANGTHAI = N'Đã Thuê' where MAPHONG='P002'
--select KHACHHANG.* from HOADON,CTHD,KHACHHANG where KHACHHANG.MAKHACHHANG=CTHD.MAKHACHHANG and CTHD.MAHOADON=HOADON.MAHOADON and MAPHONG='P002'
--select TENPHONG,SOHOPDONG,TIENCOC from PHONG,HOPDONG where PHONG.MAPHONG=HOPDONG.MAPHONG and PHONG.MAPHONG='P002'
--select TENPHONG from PHONG where MAPHONG='P002'
go

--select*from tenkhach ,tedv,soluong ,thanhtien
go

create view View_HD_PHONG
as
select  MAHOADON,TENPHONG,TONGTIEN,THANG_THANHTOAN
from HOADON hd,PHONG p
where hd.MAPHONG=p.MAPHONG

go
select*from CTHD
go

--select*from DICHVU
--select*from KHACHHANG
--select*from PHONG
--select*from LOAIPHONG

--select*from CTHD
go

create view View_CTHD_TT
as
select kh.TENKHACHHANG,dv.TENDICHVU,ct.SOLUONG,ct.THANHTIEN
from DICHVU dv,KHACHHANG kh,CTHD ct
where dv.MADICHVU=ct.MADICHVU and kh.MAKHACHHANG=ct.MAKHACHHANG
go
---////////////////////////////////////










