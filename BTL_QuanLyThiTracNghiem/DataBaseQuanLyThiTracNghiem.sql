Create Database quanLyThiTracNghiem;
//sua sql
Use quanLyThiTracNghiem;
--11-222
Create Table tblSinhVien
(
sMaSinhVien Varchar(8) Primary Key,
sTenSinhVien Nvarchar(20) null,
sQueQuan Nvarchar(15) null,
dNgaySinh Datetime null,
sMatKhau varchar(8)
);

 drop table tblSinhVien
Create Table tblCauHoiThi
(
iMaCauhoiTHi int Primary Key,
sDeThi Nvarchar(150) null,
sDapAn1 Nvarchar(150) null,
sDapAn2 Nvarchar(150) null,
sDapAn3 Nvarchar(150) null,
sDapAn4 Nvarchar(150) null,
sDapAnDung Nvarchar(6) null
);

Create Table tblGiangVien
( 
sMaGiangVien varchar(8) Primary Key,
sTenGiangVien Nvarchar(25) null,
sBoMon Nvarchar(30) null,
);

Create Table tblBaiThi
(
sMaBaiThi varchar(8) Primary Key,
sMaSinhVien varchar(8),
dNgayThi Datetime,
sMaGiangVien varchar(8)
);

Alter Table tblBaiThi add Foreign Key (sMaSinhVien) References tblSinhVien (sMaSinhVien);
Alter Table tblBaiThi add Foreign Key (sMaGiangVien) References tblGiangVien (sMaGiangVien);

Create Table tblChiTietBaiThi
(
sMaBaiThi varchar(8) not null,
iMaCauHoiThi int not null,
sCauTraLoi varchar(4) null,
Constraint chiTietBaiThi_pk Primary Key (sMaBaithi, iMaCauHoiThi)
);


Alter Table tblChiTietBaiThi add Foreign Key (sMaBaiThi) References tblBaiThi (sMaBaiThi);
Alter Table tblChiTietBaiThi add Foreign Key (iMaCauHoiThi) References tblCauHoiThi (iMaCauHoiThi);

insert into tblSinhVien values ('sv01',N'Nguyễn Văn Nam',N'Hà Nội',04/04/1998,'sv01');
insert into tblSinhVien values ('sv02',N'Nguyễn Nam Sơn',N'Hà Nội',07/04/1998,'sv02');
insert into tblSinhVien values ('sv03',N'Nguyễn Lan Hương',N'Hà Nội',04/04/1998,'sv03');
insert into tblSinhVien values ('sv04',N'Nguyễn Văn Ka',N'Hà Nội',04/04/1998,'sv04');
insert into tblSinhVien values ('sv05',N'Nguyễn Văn Lâm',N'Hà Nội',04/04/1998,'sv05');
insert into tblSinhVien values ('sv06',N'Nguyễn Văn Hà',N'Hà Nội',04/04/1998,'sv06');
insert into tblSinhVien values ('sv07',N'Nguyễn Huyền',N'Hà Nội',04/04/1998,'sv07');

select * from tblsinhvien;

insert into tblGiangVien values ('gv1',N'Nguyễn Thị HÀ',N'Phần mềm');
insert into tblGiangVien values ('gv2',N'Nguyễn Thị Xuân',N'Cơ bản');
insert into tblGiangVien values ('gv3',N'Nguyễn Anh Tùng',N'Phần mềm');


select * from tblGiangVien;

insert into tblCauHoiThi values (1,N'Câu 1',81,84,56,21,N'A');
insert into tblCauHoiThi values (2,N'Câu 2',81,84,56,21,N'A');
insert into tblCauHoiThi values (3,N'Câu 3',81,84,56,21,N'A');
insert into tblCauHoiThi values (4,N'Câu 4',81,84,56,21,N'A');
insert into tblCauHoiThi values (5,N'Câu 5',81,84,56,21,N'A');
insert into tblCauHoiThi values (6,N'Câu 6',81,84,56,21,N'A');
insert into tblCauHoiThi values (7,N'Câu 7',81,84,56,21,N'A');
insert into tblCauHoiThi values (8,N'Câu 8',81,84,56,21,N'A');
insert into tblCauHoiThi values (9,N'Câu 9',81,84,56,21,N'A');
insert into tblCauHoiThi values (10,N'Câu 10',81,84,56,21,N'A');
insert into tblCauHoiThi values (11,N'Câu 11',81,84,56,21,N'A');
insert into tblCauHoiThi values (12,N'Câu 12',81,84,56,21,N'A');
insert into tblCauHoiThi values (13,N'Câu 13',81,84,56,21,N'A');
insert into tblCauHoiThi values (14,N'Câu 14',81,84,56,21,N'A');

insert into tblCauHoiThi values (1,N'Câu 1',81,84,56,21,N'A');
insert into tblCauHoiThi values (1,N'Câu 1',81,84,56,21,N'A');
insert into tblCauHoiThi values (1,N'Câu 1',81,84,56,21,N'A');
insert into tblCauHoiThi values (1,N'Câu 1',81,84,56,21,N'A');

select * from tblcauhoithi

insert into tblBaiThi values ('BT01','sv01','04/04/2018','gv1');
insert into tblBaiThi values ('BT03','sv02','04/04/2018','gv1');
insert into tblBaiThi values ('BT02','sv03','04/04/2018','gv2');
insert into tblBaiThi values ('BT04','sv04','04/04/2018','gv3');

select * from tblBaiThi;

insert into tblChiTietBaiThi values ('BT01',1,'A');
insert into tblChiTietBaiThi values ('BT01',2,'A');
insert into tblChiTietBaiThi values ('BT01',3,'B');
insert into tblChiTietBaiThi values ('BT01',4,'C');
insert into tblChiTietBaiThi values ('BT01',5,'D');
insert into tblChiTietBaiThi values ('BT01',6,'A');
insert into tblChiTietBaiThi values ('BT01',7,'A');
insert into tblChiTietBaiThi values ('BT01',8,'A');
insert into tblChiTietBaiThi values ('BT01',9,'A');
insert into tblChiTietBaiThi values ('BT01',10,'B');

select * from tblChiTietBaiThi;


insert into tblBaiThi values ('bt1','sv01','05/04/2018','gv1');

create proc themSinhVien
@msv varchar(8),
@ten nvarchar(20),
@que nvarchar(15),
@ngaySinh datetime,
@matKhau varchar(8)
as
insert into tblSinhVien values (@msv,@ten,@que,@ngaySinh,@matKhau);

create proc suaSinhVien
@msv varchar(8),
@ten nvarchar(20),
@que nvarchar(15),
@ngaySinh datetime,
@matKhau varchar(8)
as
update tblsinhvien set sTenSinhVien = @ten, sQueQuan = @que, dNgaySinh = @ngaySinh, sMatKhau = @matKhau
where smaSinhVien = @msv;

create proc themGiangVien
@mgv varchar(8),
@ten nvarchar(25),
@boMon nvarchar(30)
as
insert into tblGiangVien values (@mgv,@ten,@boMon);

create proc themCauHoiThi
@mch int,
@deThi nvarchar(150),
@dapAn1 nvarchar(150),
@dapAn2 nvarchar(150),
@dapAn3 nvarchar(150),
@dapAn4 nvarchar(150),
@dapAnDung nvarchar(6)
as
insert into tblCauHoiThi values (@mch,@dethi,@dapAn1,@dapAn2,@dapAn3,@dapAn4,@dapAnDung);


create proc capNhatCauHoiThi
@mch int,
@deThi nvarchar(150),
@dapAn1 nvarchar(150),
@dapAn2 nvarchar(150),
@dapAn3 nvarchar(150),
@dapAn4 nvarchar(150),
@dapAnDung nvarchar(6)
as
update tblcauhoithi set sdethi = @dethi, sdapan1 = @dapan1,sDapAn2 = @dapan2, sDapAn3 = @dapAn3,
sDapAn4 = @dapAn4,sdapandung = @dapandung where iMaCauhoiTHi = @mch; 

--select count(tblcauhoithi.iMaCauhoiTHi) from tblCauHoiThi,tblChiTietBaiThi
--where tblCauHoiThi.sDapAnDung = tblChiTietBaiThi.sCauTraLoi
--and tblCauHoiThi.iMaCauhoiTHi = tblChiTietBaiThi.iMaCauHoiThi;

--select * from tblChiTietBaiThi;

--select * from tblCauHoiThi;

--thong ke diem theo sinh vien
select tblSinhVien.Stensinhvien, count(tblcauhoithi.iMaCauhoiTHi) as N'Điểm Của Bài Thi'
from tblCauHoiThi,tblChiTietBaiThi,tblBaiThi,tblsinhvien
where tblCauHoiThi.sDapAnDung = tblChiTietBaiThi.sCauTraLoi
and tblCauHoiThi.iMaCauhoiTHi = tblChiTietBaiThi.iMaCauHoiThi
and tblsinhvien.sMaSinhVien = tblBaiThi.sMaSinhVien
and tblBaiThi.sMaBaiThi = tblChiTietBaiThi.sMaBaiThi
group by tblSinhVien.Stensinhvien;

alter table tblbaithi add iDiem int;
--alter table tblbaithi drop column idiem


create proc thongTinBaiThi
as
select tblbaithi.smabaithi as 'Mã Bài Thi',tblsinhvien.smasinhvien as 'Mã Sinh Viên',tblsinhvien.stensinhvien as 'Tên SV',
tblbaithi.dNgayThi as 'Thời Gian', tblBaiThi.iDiem as 'Điểm' from tblBaiThi, tblsinhvien 
where tblsinhvien.smasinhvien = tblBaiThi.sMaSinhVien



exec thongTinBaiThi;


create proc insert_chiTietBaiThi
@maBaiThi varchar(8),
@maCauHoi int,
@cauTraLoi varchar(4)
as
insert into tblchitietbaithi values(@maBaiThi,@maCauHoi,@cauTraLoi);


create proc thongKe_theoDiem
@diemThap int,
@diemCao int
as
select tblbaithi.smabaithi as 'Mã Bài Thi',tblsinhvien.smasinhvien as 'Mã Sinh Viên',tblsinhvien.stensinhvien as 'Tên SV',
tblbaithi.dNgayThi as 'Thời Gian', tblBaiThi.iDiem as 'Điểm' from tblBaiThi, tblsinhvien 
where tblsinhvien.smasinhvien = tblBaiThi.sMaSinhVien and tblBaiThi.iDiem >= @diemThap
and tblBaiThi.iDiem <= @diemCao;

select * from tblChiTietBaiThi

select * from tblbaithi

create proc xoaBaiThi
as
begin
delete from tblbaithi;
delete from tblChiTietBaiThi;
end;

--select top 10 * from tblCauHoiThi order by NEWID();
--select top 10 * from tblcauhoithi order by newid()
--select * from tblCauHoiThi

--select * from tblSinhVien

--select * from tblBaiThi
