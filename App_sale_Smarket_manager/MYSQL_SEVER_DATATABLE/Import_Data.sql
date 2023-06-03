USE QUANLYSIEUTHI

SET DATEFORMAT DMY
				
INSERT INTO NHANVIEN VALUES ('NV01',N'Ngô Anh Tồ','0255968968','1/1/2016','12/5/1980',0,N'Thu ngân','0255968968','E10ADC3949BA59ABBE56E057F20F883E',6000000,0.05)					
INSERT INTO NHANVIEN VALUES ('NV02',N'Thiều Vĩnh Tiến','0983455266','30/7/2015','16/6/1975',0,N'Chủ tiệm','admin','E10ADC3949BA59ABBE56E057F20F883E',0,0)					
INSERT INTO NHANVIEN VALUES ('NV03',N'Đoàn Thị Thanh Nhàn','0777865432','31/12/2016','17/7/2002',0,N'Tư vấn viên','0777865432','E10ADC3949BA59ABBE56E057F20F883E',6000000,0.1)					
INSERT INTO NHANVIEN VALUES ('NV04',N'Trần Nguyễn Hạnh Nguyên','0346156112','31/5/2016','30/4/2002',0,N'Kỹ thuật viên','0346156112','E10ADC3949BA59ABBE56E057F20F883E',8000000,0.1)					
INSERT INTO NHANVIEN VALUES ('NV05',N'Lê Thị Minh Ánh','0923456442','20/6/2019','2/2/2002',0,N'Kỹ thuật viên','0923456442','E10ADC3949BA59ABBE56E057F20F883E',8000000,0.12)					
INSERT INTO NHANVIEN VALUES ('NV06',N'Nguyễn Hoàng Long','0999943349','22/7/2016','6/6/2006',0,N'Lau dọn','0999943349','E10ADC3949BA59ABBE56E057F20F883E',6000000,0)	


INSERT into DTCC VALUES ('PV01',N'Đà Lạt Farm','0777 777 777','7/7/2017',N'346 Quãng Trường Dân Chủ, quận Bình Thạnh, thành phố HCM')	
INSERT into DTCC VALUES ('PV02',N'TVT','0349 654 533','12/6/2016',N'QL13, Lái Thiêu, Thuận An, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV03',N'Nhà anh Kiệt','0941 566 663','24/03/2017',N'465A QL13, Khu phố Nguyễn Trãi, P, Bình Dương 75000, Việt Nam')	
INSERT into DTCC VALUES ('PV04',N'Hòa Phát','0553 641 456','1/1/2017',N'WMRQ+7J9, Hưng Định, Thuận An, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV05',N'Nutrifarm','0986 553 511','30/12/2017',N'XM76+C2C, Chánh Nghĩa, Thủ Dầu Một, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV06',N'Long Thành đại lý','0973 865 445','9/11/2016',N'132 Đ. Nguyễn Văn Lộng, Chánh Mỹ, Thủ Dầu Một, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV07',N'Tân Châu silk','0888 453 255','10/11/2016',N'171 ĐX 082, Định Hoà, Thủ Dầu Một, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV08',N'Meow store','0917 963 445','4/5/2017',N'Số 270 Đường ĐX064, Định Hoà, Thủ Dầu Một, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV09',N'Lascode','0941 401 401','15/7/2017',N'Quốc Lộ 13, Phường Tân Định, Bến Cát, Bình Dương, Việt Nam')	
INSERT into DTCC VALUES ('PV10',N'Tiến','0777 943 585','16/8/2017',N'20 Dân Chủ, Hoà Lợi, Bến Cát, Bình Dương, Việt Nam')	

INSERT into KHACHHANG VALUES ('RC01',N'Trần Triệu Thiên',N'Huế','0913 762 178','2/6/2023',6620000, 'NOR')
INSERT into KHACHHANG VALUES ('RC02',N'Trần Nhật Tân',N'Khu phố 6, KTX khu A ĐHQG HCM','0913 333 333','2/2/2023',15920000,'VIP')
INSERT into KHACHHANG VALUES ('RC03',N'Trương Gia Mẫn',N'Bình Dương','01111 222 333 ','2/4/2023',10000,'NOR')
INSERT into KHACHHANG VALUES ('RC04',N'Nguyễn Đình Đức Thịnh',N'Bình Phước','0888 666 666','2/2/2023',30478000,'VIP')
INSERT into KHACHHANG VALUES ('RC05',N'Cao Anh Khoa',N'Khu phố 6, KTX khu A ĐHQG HCM','0941 654 321','1/4/2023',1950400,'NOR')
INSERT into KHACHHANG VALUES ('RC06',N'Nguyễn Thùy Bích Ngọc',N'Bình Thạnh','0902 182 003','20/10/2018',212353400,'VIP')

INSERT into CALAMVIEC VALUES ('C1S',N'Monday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C1C',N'Monday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C1T',N'Monday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C2S',N'Tuesday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C2C',N'Tuesday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C2T',N'Tuesday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C3S',N'Wednesday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C3C',N'Wednesday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C3T',N'Wednesday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C4S',N'Thursday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C4C',N'Thursday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C4T',N'Thursday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C5S',N'Friday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C5C',N'Friday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C5T',N'Friday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C6S',N'Saturday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C6C',N'Saturday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C6T',N'Saturday','17:30:00','21:00:00')				
INSERT into CALAMVIEC VALUES ('C0S',N'Sunday','7:30:00','11:00:00')				
INSERT into CALAMVIEC VALUES ('C0C',N'Sunday','13:30:00','17:00:00')				
INSERT into CALAMVIEC VALUES ('C0T',N'Sunday','17:30:00','21:00:00')				

insert into LOAISP values ('RCTC',N'Rau củ - trái cây',null)
insert into LOAISP values ('TCTH',N'Thịt, cá, trứng, hải sản',null)
insert into LOAISP values ('TACB',N'Thức ăn chế biến',null)
insert into LOAISP values ('TPDM',N'Thực phẩm đông - mát',null)
insert into LOAISP values ('BKS',N'Bánh kẹo, snack',null)
insert into LOAISP values ('SSPS',N'Sữa - sản phẩm từ sữa',null)
insert into LOAISP values ('TU',N'Thức uống',null)
insert into LOAISP values ('TPK',N'Thực phẩm khô',null)

INSERT INTO SANPHAM VALUES ('RCTC0001',N'Rau càng cua',N'RCTC',N'Anh ba Long Anh',N'Việt Nam',4000,2000,N'gam',119,50,N' Hàng bán trong ngày.')	
INSERT INTO SANPHAM VALUES ('RCTC0002',N'Cam Ai Cập',N'RCTC',N'Đà Lạt farm',N'Việt Nam',150000,130000,N'kg',100,20,N' Hàng bán trong ngày.')
INSERT INTO SANPHAM VALUES ('RCTC0003',N'Ỏi Đà Lạt',N'RCTC',N'Đà Lạt farm',N'Việt Nam',40000,30000,N'gam',100,20,N' Hàng bán trong ngày.')
INSERT INTO SANPHAM VALUES ('TCTHC0001',N'Nạc vai heo',N'TCTH',N'TVT',N'Malaysia',70000,44000,N'kg',120,20,N' Hàng bán trong ngày.')
INSERT INTO SANPHAM VALUES ('TCTHC0002',N'Ba chỉ heo',N'TCTH',N'TVT',N'Malaysia',50000,35000,N'kg',130,20,N' Hàng bán trong ngày.')
INSERT INTO SANPHAM VALUES ('TACB001',N'Hạt điều',N'TACB',N'Meow store',N'Mỹ',70000,50000,N'kg',120,20,N' Điều này ngon.')
INSERT INTO SANPHAM VALUES ('TACB002',N'Trà mướp đắng',N'TACB',N'Meow store',N'Mỹ',4500,2000,N'gam',120,20,N' Trà này ngon.')
INSERT INTO SANPHAM VALUES ('TACB003',N'Trà lài',N'TACB',N'Meow store',N'Mỹ',40000,30000,N'gm',120,20,N' Điều này ngon.')





