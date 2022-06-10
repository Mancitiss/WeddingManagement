create DATABASE WEDDINGMANAGEMENT

use WEDDINGMANAGEMENT


create table ACCOUNT(
	Id bigint primary key,
	Username nvarchar(64),
	Pw nvarchar(1000),
	Priority smallint,
	Name nvarchar(100),
	Identification varchar(20),
)

create table LOBBY_TYPE
(
	IdLobbyType varchar(21) primary key,	--Khóa chisnhh (LT)
	LobbyName nvarchar(100) not null,
	MinTablePrice bigint,
	Available int,
)
insert into LOBBY_TYPE values('LT0000000000000000001', N'A', 1000000, 1)
insert into LOBBY_TYPE values('LT0000000000000000002', N'B', 1100000, 1)
insert into LOBBY_TYPE values('LT0000000000000000003', N'C', 1200000, 1)
insert into LOBBY_TYPE values('LT0000000000000000004', N'D', 1400000, 1)
insert into LOBBY_TYPE values('LT0000000000000000005', N'E', 1600000, 1)

create table LOBBY
(
	IdLobby varchar(21) primary key,	--//Khóa chisnhh (LO)
	IdLobbyType varchar(21) not null,
	LobbyName nvarchar(40) not null,
	MaxTable int,
	Available int,
	Note nvarchar(1000),
	constraint FK_IdLobbyType foreign key (IdLobbyType) references LOBBY_TYPE (IdLobbyType),
)
insert into LOBBY values('LB0000000000000000001', 'LT0000000000000000001', N'Sảnh A1', 20, 1, N'')
insert into LOBBY values('LB0000000000000000002', 'LT0000000000000000002', N'Sảnh B1', 25, 1, N'')
insert into LOBBY values('LB0000000000000000003', 'LT0000000000000000003', N'Sảnh C1', 30, 1, N'')
insert into LOBBY values('LB0000000000000000004', 'LT0000000000000000004', N'Sảnh D1', 40, 1, N'')
insert into LOBBY values('LB0000000000000000005', 'LT0000000000000000005', N'Sảnh E1', 50, 1, N'')
insert into LOBBY values('LB0000000000000000006', 'LT0000000000000000005', N'Sảnh E2', 45, 1, N'')
insert into LOBBY values('LB0000000000000000007', 'LT0000000000000000004', N'Sảnh D2', 35, 1, N'')
insert into LOBBY values('LB0000000000000000008', 'LT0000000000000000003', N'Sảnh C2', 30, 1, N'')
insert into LOBBY values('LB0000000000000000009', 'LT0000000000000000002', N'Sảnh B2', 25, 1, N'')
insert into LOBBY values('LB0000000000000000010', 'LT0000000000000000001', N'Sảnh A2', 20, 1, N'')

create table SHIFT
(
	IdShift varchar(21) primary key,	--//Khóa chisnhh (SH)
	Available int,
	ShiftName nvarchar(20),
	Starting time,
	Ending time,
)
insert into SHIFT values('SH0000000000000000001', 1, N'Trưa', '12:00', '16:00')
insert into SHIFT values('SH0000000000000000002', 1, N'Tối', '17:00', '22:00')

 create table WEDDING_INFOR
 (
	IdWedding varchar(21) primary key,	--//Khóa chisnhh (WD)
	IdLobby varchar(21) not null,
	IdShift varchar(21),
	BookingDate datetime,
	WeddingDate datetime,
	PhoneNumber varchar(10),
	GroomName nvarchar(100),
	BrideName nvarchar(100),
	AmountOfTable int,
	AmountOfContingencyTable int,
	TablePrice bigint,
	Deposit bigint,
	Available int,
	Representative nvarchar(100) not null,
	constraint FK_IdLobby foreign key (IdLobby) references LOBBY (IdLobby),
	constraint FK_IdShift foreign key (IdShift) references SHIFT (IdShift),
 )
 set dateformat dmy;
 INSERT INTO WEDDING_INFOR VALUES ('WD0000000000000000001', 'LB0000000000000000002', 'SH0000000000000000001', '12/5/2022', '20/5/2022', '0978425162',
 N'Nguyễn Minh Quân', N'Hồ Ngọc Trúc Anh', 50, 3, null, 120000000, 1, N'Hồ Nhật Anh')

 delete from WEDDING_INFOR
create table  MENU
(
	IdDishes varchar(21) primary key,	--//Khóa chisnhh (MN)
	DishesName nvarchar(100),
	DishesPrice bigint,
	Note nvarchar(100),
	Available int,
)
insert into MENU values('MN0000000000000000001', N'đùi gà rán', 100000, N'', 1)
insert into MENU values('MN0000000000000000002', N'cánh gà chiên', 100000, N'', 1)
insert into MENU values('MN0000000000000000003', N'thịt gà', 200000, N'', 1)
insert into MENU values('MN0000000000000000004', N'cơm sườn', 50000, N'', 1)
insert into MENU values('MN0000000000000000005', N'bún bò', 50000, N'', 1)
insert into MENU values('MN0000000000000000006', N'phở', 50000, N'', 1)
insert into MENU values('MN0000000000000000007', N'hủ tiếu', 50000, N'', 1)
insert into MENU values('MN0000000000000000008', N'bánh canh', 50000, N'', 1)
insert into MENU values('MN0000000000000000009', N'cơm sườn bò', 50000, N'', 1)
insert into MENU values('MN0000000000000000010', N'cơm sườn gà', 40000, N'', 1)
insert into MENU values('MN0000000000000000011', N'khoai tây chiên', 30000, N'', 1)
insert into MENU values('MN0000000000000000012', N'cơm chiên dương châu', 50000, N'', 1)
insert into MENU values('MN0000000000000000013', N'trà sữa', 50000, N'', 1)
insert into MENU values('MN0000000000000000014', N'trà đào', 50000, N'', 1)
insert into MENU values('MN0000000000000000015', N'nước chanh', 20000, N'', 1)
insert into MENU values('MN0000000000000000016', N'nước cam ép', 30000, N'', 1)
insert into MENU values('MN0000000000000000017', N'nước ngọt', 30000, N'', 1)
insert into MENU values('MN0000000000000000018', N'nước lọc', 10000, N'', 1)
insert into MENU values('MN0000000000000000019', N'bánh gạo', 10000, N'', 1)
insert into MENU values('MN0000000000000000020', N'bánh snack Oishi', 50000, N'', 1)
insert into MENU values('MN0000000000000000021', N'lẩu thường', 50000, N'', 1)
insert into MENU values('MN0000000000000000022', N'lẩu vip', 100000, N'', 1)
insert into MENU values('MN0000000000000000023', N'bánh tráng', 10000, N'', 1)
insert into MENU values('MN0000000000000000024', N'xôi đậu đỏ', 20000, N'', 1)
insert into MENU values('MN0000000000000000025', N'xôi đậu đen', 10000, N'', 1)
insert into MENU values('MN0000000000000000026', N'chuối', 10000, N'', 1)
insert into MENU values('MN0000000000000000027', N'cá nóc', 2000000, N'', 1)
insert into MENU values('MN0000000000000000028', N'gà đông tảo', 2000000, N'', 1)
insert into MENU values('MN0000000000000000029', N'tôm hùm', 3000000, N'', 1)
insert into MENU values('MN0000000000000000030', N'cua hoàng đế', 4000000, N'', 1)
insert into MENU values('MN0000000000000000031', N'yến sào', 10000000, N'', 1)
insert into MENU values('MN0000000000000000032', N'nước yến', 500000, N'', 1)
insert into MENU values('MN0000000000000000033', N'thịt cừu', 1000000, N'', 1)
insert into MENU values('MN0000000000000000034', N'đậu hà lan', 10000, N'', 1)
insert into MENU values('MN0000000000000000035', N'đậu phộng', 10000, N'', 1)
insert into MENU values('MN0000000000000000036', N'mì', 20000, N'', 1)
insert into MENU values('MN0000000000000000037', N'mì gói', 5000, N'', 1)
insert into MENU values('MN0000000000000000038', N'mì xào', 30000, N'', 1)
insert into MENU values('MN0000000000000000039', N'cá basa', 50000, N'', 1)
insert into MENU values('MN0000000000000000040', N'cá basa phi lê', 100000, N'', 1)
insert into MENU values('MN0000000000000000041', N'cá basa phi lê chiên giòn', 150000, N'', 1)
insert into MENU values('MN0000000000000000042', N'canh khổ qua', 10000, N'', 1)
insert into MENU values('MN0000000000000000043', N'canh chua cá lóc', 20000, N'', 1)
insert into MENU values('MN0000000000000000044', N'cá lóc', 50000, N'', 1)
insert into MENU values('MN0000000000000000045', N'cá khô', 10000, N'', 1)
insert into MENU values('MN0000000000000000046', N'táo', 10000, N'', 1)
insert into MENU values('MN0000000000000000047', N'cà chua', 10000, N'', 1)
insert into MENU values('MN0000000000000000048', N'dưa hấu', 80000, N'', 1)
insert into MENU values('MN0000000000000000049', N'cà rốt', 10000, N'', 1)
insert into MENU values('MN0000000000000000050', N'dừa', 30000, N'', 1)
insert into MENU values('MN0000000000000000051', N'nước dừa', 20000, N'', 1)
insert into MENU values('MN0000000000000000052', N'trứng gà luộc', 20000, N'', 1)
insert into MENU values('MN0000000000000000053', N'trứng lòng dào', 20000, N'', 1)
insert into MENU values('MN0000000000000000054', N'cà chua xào trứng', 20000, N'', 1)
insert into MENU values('MN0000000000000000055', N'giá xào cà chua', 20000, N'', 1)
insert into MENU values('MN0000000000000000056', N'giá xào đậu tương', 20000, N'', 1)
insert into MENU values('MN0000000000000000057', N'giá xào đậu ve', 20000, N'', 1)
insert into MENU values('MN0000000000000000058', N'gà chiên mắm', 50000, N'', 1)
insert into MENU values('MN0000000000000000059', N'da gà chiên mắm', 20000, N'', 1)
insert into MENU values('MN0000000000000000060', N'gà chiên lắc phô mai', 50000, N'', 1)
insert into MENU values('MN0000000000000000061', N'gỏi gan bò', 50000, N'', 1)
insert into MENU values('MN0000000000000000062', N'gỏi bì heo', 50000, N'', 1)
insert into MENU values('MN0000000000000000063', N'gà luộc', 100000, N'', 1)
insert into MENU values('MN0000000000000000064', N'chân gà xảo xả ớt', 80000, N'', 1)
insert into MENU values('MN0000000000000000065', N'chân gà rút xương', 130000, N'', 1)
insert into MENU values('MN0000000000000000066', N'thịt kho tàu', 100000, N'', 1)
insert into MENU values('MN0000000000000000067', N'bì heo xào xả ớt', 100000, N'', 1)
insert into MENU values('MN0000000000000000068', N'bún xào chay', 50000, N'', 1)
insert into MENU values('MN0000000000000000069', N'bún đỏ', 40000, N'', 1)
insert into MENU values('MN0000000000000000070', N'bún xào thịt bò', 90000, N'', 1)
insert into MENU values('MN0000000000000000071', N'bún riêu cua', 80000, N'', 1)
insert into MENU values('MN0000000000000000072', N'bún giò heo', 70000, N'', 1)
insert into MENU values('MN0000000000000000073', N'bún cá', 60000, N'', 1)
insert into MENU values('MN0000000000000000074', N'bánh canh cá dằm', 85000, N'', 1)
insert into MENU values('MN0000000000000000075', N'bánh cuốn', 20000, N'', 1)
insert into MENU values('MN0000000000000000076', N'bánh cuốn nóng', 30000, N'', 1)
insert into MENU values('MN0000000000000000077', N'bánh ướt', 40000, N'', 1)
insert into MENU values('MN0000000000000000078', N'bánh tráng trộn bơ tỏi', 30000, N'', 1)
insert into MENU values('MN0000000000000000079', N'phô mai que', 35000, N'', 1)
insert into MENU values('MN0000000000000000080', N'gà chiên coca', 40000, N'', 1)
insert into MENU values('MN0000000000000000081', N'tôm xào xả ớt', 60000, N'', 1)
insert into MENU values('MN0000000000000000082', N'mực xào', 70000, N'', 1)
insert into MENU values('MN0000000000000000083', N'mực chiên giòn', 80000, N'', 1)
insert into MENU values('MN0000000000000000084', N'cá Ro chiên xù', 69000, N'', 1)
insert into MENU values('MN0000000000000000085', N'Cá Ro', 6969696969, N'', 1)
insert into MENU values('MN0000000000000000086', N'cá chép chiên mắm ớt', 100000, N'', 1)
insert into MENU values('MN0000000000000000087', N'thịt nướng', 90000, N'', 1)
insert into MENU values('MN0000000000000000088', N'cá nướng', 100000, N'', 1)
insert into MENU values('MN0000000000000000089', N'mực nướng', 110000, N'', 1)
insert into MENU values('MN0000000000000000090', N'cá viên chiên', 20000, N'', 1)
insert into MENU values('MN0000000000000000091', N'bánh đúc nóng', 20000, N'', 1)
insert into MENU values('MN0000000000000000092', N'bánh mì', 10000, N'', 1)
insert into MENU values('MN0000000000000000093', N'bánh mì trứng', 15000, N'', 1)
insert into MENU values('MN0000000000000000094', N'bánh mì kem trứng sữa', 30000, N'', 1)
insert into MENU values('MN0000000000000000095', N'bánh mì gà', 30000, N'', 1)
insert into MENU values('MN0000000000000000096', N'bánh mì que', 20000, N'', 1)
insert into MENU values('MN0000000000000000097', N'cơm cà ri', 50000, N'', 1)
insert into MENU values('MN0000000000000000098', N'canh khổ qua nhồi thịt', 100000, N'', 1)
insert into MENU values('MN0000000000000000099', N'khổ qua xào cá', 80000, N'', 1)
insert into MENU values('MN0000000000000000100', N'cơm cuộn', 69000, N'', 1)

create table SERVICE
(
	IdService varchar(21) primary key, --//Khóa chisnhh (SV)
	ServiceName nvarchar(100),
	ServicePrice bigint,
	Note nvarchar(100),
	Available int,
)
insert into SERVICE values('SV0000000000000000001', N'bưng bàn ghế', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000002', N'treo hoa', 500000, N'', 1)
insert into SERVICE values('SV0000000000000000003', N'bơm bóng bay', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000004', N'in ấn thiệp cưới', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000005', N'thuê trang phục cưới', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000006', N'trang trí tiệc cưới', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000007', N'chụp hình quay phim', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000008', N'trang điểm ngày cưới', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000009', N'trợ lí ngày cưới', 200000, N'', 1)
insert into SERVICE values('SV0000000000000000010', N'điều phối chương trình lễ cưới', 500000, N'', 1)
insert into SERVICE values('SV0000000000000000011', N'dịch vụ âm thanh và ánh sáng ngày cưới', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000012', N'ban nhạc trình diễn', 2000000, N'', 1)
insert into SERVICE values('SV0000000000000000013', N'dịch vụ bắn pháo hoa', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000014', N'dịch vụ dọn dẹp sau tiệc cưới', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000015', N'dịch vụ đưa đón', 1000000, N'', 1)
insert into SERVICE values('SV0000000000000000016', N'dịch vụ trang trí bàn thờ gia tiên', 300000, N'', 1)
insert into SERVICE values('SV0000000000000000017', N'dịch vụ chọn mâm ngũ quả', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000018', N'dịch vụ trao đổi loại hình và phương án thực hiện', 500000, N'', 1)
insert into SERVICE values('SV0000000000000000019', N'dịch vụ tổ chức hội thảo hội nghị', 100000, N'', 1)
insert into SERVICE values('SV0000000000000000020', N'dịch vụ khác: sinh nhật, thôi nôi', 1000000, N'', 1)

create table TABLE_DETAIL
(
	IdWedding varchar(21) not null,
	IdDishes varchar(21) not null,
	AmountOfDishes int,
	TotalDishesPrice bigint,
	Note nvarchar(100),
	constraint PK_TABLE_DETAIL primary key (IdWedding,IdDishes),
	constraint FK_IdWedding foreign key (IdWedding) references WEDDING_INFOR (IdWedding),
	constraint FK_IdDishes foreign key (IdDishes) references MENU (IdDishes)
)
delete from TABLE_DETAIL;
delete from SERVICE_DETAIL;

create table SERVICE_DETAIL
(
	IdWedding varchar(21) not null,
	IdService varchar(21) not null,
	AmountOfService int,
	TotalServicePrice bigint,
	Note nvarchar(50),
	constraint PK_SERVICE_DETAIL primary key (IdWedding,IdService),
	constraint FK_Service_IdWedding foreign key (IdWedding) references WEDDING_INFOR (IdWedding),
	constraint FK_IdService foreign key (IdService) references [SERVICE] (IdService),
)

create table BILL
(
	IdBill varchar(21) primary key,   --//Khóa chisnhh(BI)=idWedding
	InvoiceDate datetime,
	TablePriceTotal bigint,
	ServicePriceTotal bigint,
	Total bigint,
	PaymentDate datetime,
	MoneyLeft bigint,
	constraint FK_Bill_IdWedding foreign key (idBill) references WEDDING_INFOR(IdWedding)
)
delete from bill;

create table REVENUE_REPORT
(
	IdReport varchar(21) primary key, --//Khóa chisnhh (RR)
	Month tinyint,
	Year int,
	RevenueTotal bigint,
)

create table REVENUE_REPORT_DT
(
	IdReport varchar(21) not null,  
	Day tinyint not null,
	DayRevenue bigint,
	Ratio float,
	AmoutOfWedding int,
	constraint PK_REVENUE_REPORT_DT primary key (IdReport,Day),
	constraint FK_IdReport foreign key (IdReport) references REVENUE_REPORT(IdReport),
)

create table PARAMETER
(
	IdParamater varchar(20) primary key,	--//Khóa chisnhh (PA)
	Value int ,
)

insert into PARAMETER values ('recruiter', 1) -- chỉ người có priority <= 1 mới có quyền thu nhận nhân viên mới
insert into PARAMETER values ('MaxTable', 50) -- 1 phòng cưới chỉ có tối đa 50 bàn
insert into PARAMETER values ('PenaltyRate', 1) -- tiền phạt trả trễ là 1% / ngày
insert into PARAMETER values ('RulesFollowing', 1) -- 1 = áp dụng tiền phạt (phía trên), 0 = không áp dụng

select * from BILL

insert into ACCOUNT (Id, Username, Pw, Priority, Name, Identification) values (0, N'123', N'123', 0, N'Quên', N'079202002149')

select * from REVENUE_REPORT


delete from REVENUE_REPORT_DT
delete from REVENUE_REPORT 