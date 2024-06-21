Create database DoAn3_NguyenVanCuong
go
use DoAn3_NguyenVanCuong
go

create table NguoiDung
(
	TaiKhoan varchar(15) primary key,
	HoTen nvarchar(30),
	DiaChi nvarchar(50),
	Phone nvarchar(15),
	email nvarchar(20),
	MatKhau nvarchar(50),
	Confirm_MatKhau nvarchar(50),
)
go
Create table KhachHang
(
	MaKH varchar(50)primary key,
	TenKH nvarchar(50),
	DiaChi nvarchar(50),
	SoDT nvarchar(10),
)
go
create table LoaiSanPham
(
	MaLoaiSP varchar(15) primary key,
	TenLoaiSP nvarchar(50)
)
go
create table ThuongHieu
(
	MaThuongHieu varchar(15) primary key,
	TenThuongHieu nvarchar(50),
	GioiThieu nvarchar(MAX)
)
go 
create table NhaCungCap
(
	MaNCC varchar(15) primary key,
	TenNCC nvarchar(50),
	DiaChi nvarchar(50),
	SDT char(13)
)
go
Create table SanPham
(
	MaSP varchar(15)primary key,
	TenSP nvarchar(MAX),
	MoTa nvarchar(max),
	SoLuong int,
	DonGia int,
	MaLoaiSP varchar(15) foreign key (MaLoaiSP) references LoaiSanPham(MaLoaiSP) on delete cascade, 
	MaThuongHieu varchar(15) foreign key (MaThuongHieu) references ThuongHieu(MaThuongHieu) on delete cascade, 
	Anh nvarchar(max),
	
)
go
create table KhuyenMai
(
	MaKM  varchar(15) primary key,
	TenSPKM nvarchar(50),
	GiaKM int ,
	Anh nvarchar(MAX),
	giamgia int ,
	MaSP varchar(15) Foreign key references SanPham(MaSP) on delete cascade on update cascade,
	NgayBD nvarchar(20),
	NgyKT nvarchar(20),
)
go

Create table HDN
(
	MaHDN int primary key identity,
	MaNV varchar(15) Foreign key references NguoiDung(TaiKhoan) on delete cascade on update cascade,
	MaNCC varchar(15) foreign key (MaNCC) references NhaCungCap(MaNCC) on delete cascade, 
	MaSP varchar(15) Foreign key references SanPham(MaSP) on delete cascade on update cascade,
	NgayNhap nvarchar(50)  , 
	SoLuong int,
	DonGia int,
)
go
Create table DonHang
(
	
	MaDH int primary key identity,
	NgayDat nvarchar(50),
	DiaChi nvarchar(max),
	MaKH varchar(50) Foreign key references KhachHang(MaKH) on delete cascade on update cascade,
	MaNV varchar(15) Foreign key references NguoiDung(TaiKhoan) on delete cascade on update cascade,
	HoTen nvarchar(50),
	Email nvarchar(50),
	Phone nvarchar(10),
	TongTien int ,
)
go
Create table CTDonHang
(
	MaDH int,
	Foreign key(MaDH) references DonHang(MaDH) on delete cascade,
	MaSP varchar(15) Foreign key references SanPham(MaSP) on delete cascade on update cascade,
	primary key (MaDH,MaSP),
	SoLuong int,
	GiaTien int,
)
--create table LoaiTinTuc
--(
--	MaLoaiTinTuc varchar(15) primary key,
--	TenLoaiTin nvarchar(50)
--)
go
create table TinTuc 
(
	MaTinTuc varchar(15) primary key,
	TieuDe nvarchar(50),
	NoiDung nvarchar(Max),
	NgayDang nvarchar(50) ,
	MaNV varchar(15) Foreign key references NguoiDung(TaiKhoan) on delete cascade on update cascade,
	Anh nvarchar(max)

)
go

-----------------------------------------Nhà cung cấp ---------------------------------------

insert into NhaCungCap values('NCC01',N'Công ty may mặc',N'114 Lê Trọng Tấn Quận Tân Phú','0123456789')



-----------------------------------------nguoi dung---------------------------------------------
---Tài khoản admin ------------------
insert into NguoiDung values('Admin',N'Admin',N'Thái bình',N'014725836',N'Admin@gmail.com',N'Admin',N'Admin')
---Tài khoản khách hàng ----------
insert into NguoiDung values('cuongtt2002',N'Nguyễn Văn Cường',N'Thái bình',N'012583694',N'cuong31139@gmail.com',N'123456',N'123456')

-----------------------------------------tin tuc -------------------------------------------
insert into TinTuc values ('TT01',N'Tin Tức về áo  sơ mi nam ' ,N'Đây là một trong những kiểu áo truyền thống và có tính ứng dụng rất cao. Bạn có thể kết hợp chúng theo phong cách công sở hoặc
<br>-thời trang dạo phố. Thiết kế hình học vót nhọn của cổ áo giúp nó hài hòa với cravat hoặc ngay cả để cổ trơn. Tuyệt vời hơn nữa là
<br>-sơ mi cổ nhọn còn phù hợp với hầu hết tất cả các loại cổ áo veston nam hiện nay.','2015-09-23','cuongtt2002',N'so-mi-nam-caro.jpg')


insert into TinTuc values ('TT02',N'Tin Tức về quần jogger' ,N'Chiếc quần jogger thể thao đầu tiên được giới thiệu vào những năm 1920 bởi thương nhân quần áo người pháp Émile Camuset và cũng người
sáng lập Le Coq Sportif (Công ty về quần áo thể thao).  Đầu tiên những chiếc quần jogger là những chiếc quần màu xám được may đơn giản để
cho các vận động viên co duỗi và chạy thoải mái..','2020-09-28','cuongtt2003',N'quan-jogger-kaki-bo-lai.png')
-------------------------------------------------Bảng Loại Sản Phẩm ----------------------------------------------------
insert into LoaiSanPham values('L01',N'Áo thun nam')
insert into LoaiSanPham values('L02',N'Áo thun nữ')
insert into LoaiSanPham values('L03',N'Áo sơ mi nam')
insert into LoaiSanPham values('L04',N'Áo sơ mi nữ')
insert into LoaiSanPham values('L05',N'Đầm nữ')
insert into LoaiSanPham values('L06',N'Chân váy')
insert into LoaiSanPham values('L07',N'Quần short nữ')
insert into LoaiSanPham values('L08',N'Quần jean nữ')
insert into LoaiSanPham values('L09',N'Quần thun nữ')
insert into LoaiSanPham values('L10',N'Quần jogger nữ')
insert into LoaiSanPham values('L11',N'Quần short nam')
insert into LoaiSanPham values('L12',N'Quần kaki nam')
insert into LoaiSanPham values('L13',N'Quần jean nam')
insert into LoaiSanPham values('L14',N'Quần tây nam')
insert into LoaiSanPham values('L15',N'Quần jogger nam')


----------------------------------------------------- Bảng Khách hàng --------------------------------------------------------
insert into KhachHang values('cuongtt2002',N'Nguyễn Văn Cường ',N'Thái Bình ',N'0147258369')
insert into KhachHang values('cuongtt2003',N'Nguyễn Văn Công',N'Nam Định  ',N'0147258369')
insert into KhachHang values('cuongtt2004',N'Phạm Hải Long ',N'Hải Dương ',N'0147258369')
insert into KhachHang values('cuongtt2005',N'Phạm Việt Kiều ',N'Hưng Yên ',N'0147255369')
insert into KhachHang values('cuongtt2006',N'Trần Thị Nhật Lệ ',N'hà Nội ',N'0147258399')
insert into KhachHang values('cuongtt2007',N'Nguyễn Hải Dương ',N'Thái Bình ',N'014725886')
insert into KhachHang values('cuongtt2008',N'Nguyễn Thanh Tùng ',N'Hưng Yên ',N'0387258369')
insert into KhachHang values('cuongtt2009',N'Bùi Anh Tuấn ',N'Thái Bình ',N'0146258369')
insert into KhachHang values('cuongtt2010',N'Nguyễn Thị Vân Anh ',N'Thái Bình ',N'038225897')
insert into KhachHang values('cuongtt2011',N'Phạm Đức Thắng ',N'Cà Mau',N'024725836')
insert into KhachHang values('cuongtt2012',N'Tô Đức Thắng ',N'YEeeb Bái',N'044725837')

-------------------------------- Bảng Thương Hiệu---------------------------------------
insert into ThuongHieu values('TH01',N'CHANEL',N'Chanel chắc hẳn là cái tên không còn xa lạ gì dù chàng có là ""tín đồ thời trang hay không .Bởi thương hiệu đến từ Pháp này vô cùng nổi tiếng với nhiều sản phẩm khác nhau từ nước hoa , quần áo ,túi xanh hay một số loại mỹ phẩm 
<br>- Hướng đén phong cách thời trang thời thượng và đẳng cấp do đó các mẫu quần áo của Chanel được làm hoàn toàn từ chất liệu cao cấp cùng công nghệ may tinh xảo nhất .Bởi đó khó có ai có thể cưỡng lại sức hút toát ra từ các sản phẩm thời trang của thương hiệu này 
<br>-Đăc biệt , Chanel thường xuyên tổ chức các show diễn thời trang đỉnh cao thu hút rất nhiều nhà thiết kế trẻ ,tài năng để ra mắt bộ sưu tập mới của họ .Nhờ đó ,thương hiệu này ngày càng được nhiều người biết đén và trở thành số 1 trong làng thời trang thế giới')
insert into ThuongHieu values('TH02',N'GUCCI',N'Là một trong những biểu tượng thời trang co cấp của ý và pháp với những sản phẩm thời trang xa xỉ bậc nhất.Trong đó hai dòng sản phẩm thời trang nam và nữ chủ đạo là The House of Gucci với các mẫu thiết kế độc nhất và thời thượng 
<br>-Ngoài ra .Gucci cũng vô cùng nổi tiếng với các dòng túi sách , đồng hồ , kính mắt , phụ kiện thời trang hàng hiệu bậc nhất hiện nay ')
insert into ThuongHieu values('TH03',N'LOUIS VUITTON',N'là một trong những cái tên vàng trong làng thời trang của pháp ,LOUIS VUITTON không chỉ đơn giản là một thương hiệu thời trang xa xỉ mà nó còn là tượng đài của thời trang thế giới 
<br>-Được thành lập từ năm 1854 cho đến nay LOUIS VUITTON đã trở nên vô cùng nổi tiếng trên toàn thế giới và là một trong những thương hiệu thời trang cao cấp giá trị nhất .Không chỉ có những sản phẩm thời trang của nữ mà LOUIS VUITTON cũng có cho mình những bộ sưu tập thời trang nam chất nhất , được nhiều ngôi sao đón nhận 
<br>- Đặc biệt điều tạo nên sức hút khó cưỡng của thương hiệu thời trang nổi tiếng này là trang phục đều mang phong cách thời thượng , mới lạ và tinh xảo đến từng chi tiết nhỏ 
<br>- Cũng như nhiều thương hiệu thời trang hàng hiệu , cao cấp khác thì LOUIS VUITTON cũng đang ngày càng mở rộng ra các lĩnh vực khác như túi xách , nước hoa ,.....')
insert into ThuongHieu values('TH04',N'DIOR',N'Được thành lập bởi nhà thiết kế tài ba Christian vào năm 1946 và cho đến nay nó đã trở thành thương hiệu thời trang nổi tiếng cao cấp bậc nhất tại pháp và được toàn thế giới công nhận .
<br>- Đối với các dòng sản phẩm thời trang của Dior , khó cí ai cưỡng lại sức hút của nó bởi phong cách Haute Couture đặc trưng đậm tính kiến trúc và sự quyến rũ 
<br>- Nếu Dior Womanswear là một trong những sản phẩm cao cấp dành cho phái nữ đầy quý phái , sang trọng thì Dior Homme là dòng sản phẩm dành cho nam mang thiết kế tối giản ,tinh xảo và vô cùng thanh lịch ')
insert into ThuongHieu values('TH05',N'HERMES',N'HERMES cũng được biết đến là một trong những thương hiệu thời trang xa xỉ do người pháp thành lập từ năm 1837 khởi nguồn từ một cửa hàng bán vật dụng dành cho ngựa .Chính điều này đã tạo nên logo hình chiếc xe ngựa kéo quen thuộc của thương hiệu này 
<br>-Ngày nay , hermes đã trở thành đế chế thời trang khổng lồ của thế giới với những mẫu thời trang đẳng cấp và trang trọng nhất .Điểm độc đáo tạo nên sự nổi tiếng của thương hiệu thời trang nổi tiếng này là tất cả các sản phẩm đều được quan tâm đầu tư kỹ lưỡng trong quá trình sản xuất 
<br>-Đăc biệt với nhiều sản phẩm thời trang được làm hoàn toàn thủ công từ một người thợ duy nhất đẻ đảm bảo tính thống nhất và riêng biệt của sản phẩm .Nhờ đó , hermes là một trong những thương hiệu thời trang được nhiều ngôi sao nổi tiếng thế giới lựa chọn và sử dụng nhất tính đến 2021')
insert into ThuongHieu values('TH06',N'DOLCE & GABBANA',N'Là một thương hiệu thời trang nổi tiếng về hàng cao cấp của ý được thành lập bởi chính hai nhà thiết kế này vào năm 1985 
<br>-cũng nhờ được thành lập bởi hai nhà thiết kế tài hoa và có tầm ảnh hưởng lớn đến xu hướng thời trang bấy giờ nên thương hiệu này thực sự đem đến những mẫu thiết kế đẳng cấp , tinh tế mà hiếm thương hiệu nào làm được 
<br>-Do đó ,DOLCE & GABBANA được rất nhiều ngôi sao Hollywood tin dùng và ưa chuộng mỗi khi có dịp dự các sự kiện lớn như : Madonna , Monica Bellucci ,...')
insert into ThuongHieu values('TH07',N'VERSACE',N'Là một biểu tượng thời trang cao cấp bậc nhất của ý , Thương hiệu đã khiến cả thế giới phải ngưỡng mộ và trầm trồ nhờ đem đến những sản phẩm thời trang chất lượng , xa xỉ nhất theo phong cách độc đáo , sang trọng và vô cùng ấn tượng 
<br>-Đối với ai yêu thích và là tín đồ của thời trang xa xỉ thế giới chắc hẳn đều nhận thấy họa tiết của các trang phục mang thương hiệu Versace của nghệ thuật Hy lạp cổ đại với màu sắc , chất liệu , nét cổ điển và tính nghệ thuật điển hình , hình khố mới lạ ')
insert into ThuongHieu values('TH08',N'PRADA',N'Là hãng thời trang danh giá nhất của nước ý đặc trưng với phong cách sang trọng , quý phái và thời thượng nên Prada đang ngày càng phát triển và định hướng trở thành thượng hiệu đỉnh cao của làng thời trang 
<br>-Cũng giống như nhiều thương hiệu thời trang nổi tiếng khác prada chia sản phẩm thành 2 dòng thời trng nam và nữ đẻ đáp ứng nhu cầu của khách hàng trên toàn thế giới .Đặc trưng của dòng sản phẩm này mang tính nghệ thuật cao có sự kết hợp nét cổ điển và hiện đại 
<br>- Do đó ,Prada cũng vẫn luôn tạo ra nét khác biệt mạnh mẽ giữa các thương hiệu thời trang khác ')
insert into ThuongHieu values('TH09',N'BURBERRY',N'Được coi là niềm tự hào của thời trang cao cấp Anh Quốc với lịch sử hình thành lâu đời nhất trên thế giới 
<br>- Mặc dù ngày nay thương hiệu này đã cho ra mắt nhiều bộ sưu tập với những thiết kế ấn tượng và thời thượng nhất nhưng một đặc trưng và độc quyền trong phong cách thời trang của thương hiệu này , khiến người ta nhớ mãi là họa tiết sọc caro đơn giản nhưng vô cùng tinh tế trang nhã 
<br>- Và chính họa tiết này cũng là cảm hứng thiết kế cho những sản phẩm thời trang khác như đông hồ , mũ , ... của Burberry cho đến tận ngày nay  ')
insert into ThuongHieu values('TH10',N'ARMANI',N'Là một trong những thương hiệu thời trang nổi tiếng của ý có tốc độ phát triển nhanh nhất ,Armani đang ngày càng khẳng định được tiếng tăm của mình trên thị trường thời trang cao cấp của thế giới 
<br>- Với những mẫu thời trang nam nữ hướng đến sự tối giản , tinh tế và có tính ứng dụng cao ,Armani đã chinh phục được nhiều nhà thiết kế nổi tiếng khác và nhiều ngôi sao nổi tiếng trên thế giới 
<br>-Không chỉ nổi tiếng về các sản phẩm thời trang mà đồng hồ , mỹ phẩm , đồ nội thất cũng là một trong những mặt hàng làm nên tên tuổi của thương hiệu này ')
insert into ThuongHieu values('TH11',N'RALPH LAUREN',N'Thương hiệu thời trang nổi tiếng Ralph Lauren được thành lập 1967 bởi nhà thiết kế người mỹ 
<br>- Do đó các mẫu thời trang của thương hiệu này mang phong cách vừa sang trọng , vừa phóng khoáng và cổ điển đúng theo gu của người Mỹ 
<br>-Đặc biệt RALPH LAUREN còn được biết đến giống như cha` đẻ của biểu tượng Polo ngày nay nhờ bộ sưu tập thời trang giành cho nữ giới mang phong cách trang phục cổ điển của nam giới vào năm 1969 ')
insert into ThuongHieu values('TH12',N'GIVENCHY',N'Là thương hiệu thời trang do chính nhà thiết kế trẻ tài năng người pháp gốc ý cùng tên sáng lập năm 1952
<br>-Tồn tại giữa kinh đô thời trang Paris với nhiều thương hiệu thời trang nổi tiếng và xa xỉ bậc nhất trên thế giớI nhưng GIVENCHY vẫn không hề kém cạnh mà đã tạo dựng cho mình được phong cách thời trang cao cấp khác biệt 
<br>-Các sản phẩm thời trang của GIVENCHY đều hướng tới tôn vinh nét đẹp hiện đại và đầy cá tính , sang trọng nhưng năng động của cả phái nam lẫn phái nữ .Nhờ đó , thương hiệu này đã nhanh chóng gia nhập đế chế thời trang hùng mạnh của thế giới một cách nhanh chóng ')
insert into ThuongHieu values('TH13',N'FENDI',N'Là thương hiệu thời trang nổi tiếng của ý do Edoardo và Adele Fendi sáng lập chuyên về các sản phẩm thời trang cao cấp , nước hoa , giày dép và các phụ kiện thời trang khác 
<br>-Trong đó ấn tượng nhất của các mẫu thời trang của thương hiệu này đều được làm từ da và lông thú - hai chất liệu cao cấp và xa xỉ hàng đầu .Bởi thế , mỗi khi các bộ sưu tập của thương hiệu này được tung ra thị trường luôn tạo ra cơn sốt thời trang đối với nhiều ngôi sao hàng đầu trên thế giới 
<br>- Cũng chính chất liệu này đem đến cho các dòng thời trang của FENDI phong cách sang trọng , quý phái mà thanh lịch hiếm có ')
insert into ThuongHieu values('TH14',N'Yves Saint Laurent',N'Yves Saint Laurent là một trong những thương hiệu thời trang cao cấp nhất của kinh độ thời trang Paris được nhà thiết kế huyền thoại Yves Saint Laurent và đối tác của ông là Piere Berge sáng lập năm 1962
<br>-Ngay từ những ngày đầu tiên ra mắt thời trang thế giới Yves Saint Laurent đã khiến cả thế giới thời trang phải sửng sốt và ngạc nhiên vì những mẫu thời trang nam nữ được thiết kế vô cùng tỉ mỉ , tinh xảo và nghệ thuật 
<br>-Không chỉ dừng lại thương hiệu thời trang nổi tiếng mà ngày nay Yves Saint Laurent cũng được biến đén là thương hiệu của các dòng mỹ phẩm cao cấp , xa xỉ được nhiều ngôi sao và giới thượng lưu trên thế giới ưa chuộng ')
insert into ThuongHieu values('TH15',N'Bottega Veneta',N'Một cái tên đình đám khác của những thương hiệu thời trang nổi tiếng thế giới được ưa chuộng không kém là bottega Veneta - thương hiệu cao cấp của ý 
<br>-Với những kỹ thuật tác chế thủ công lâu đời và tinh xảo giúp cho các mẫu thiết kế của thương hiệu này chứa đựng một phong cách rất riêng biệt , mang đậm đặc trưng nước ý :đơn giản ,tinh tế và thời thượng  ')


-------------------------------- Bảng Sản Phẩm ---------------------------------------
--01---
insert into SanPham values('SP01',N'ÁO THUN NAM NGẮN TAY CỔ TRỤ',N'ÁO THUN NAM NGẮN TAY CỔ TRỤ THUN COTTON SỌC NGANG PHỐI 2 MÀU ĐẸP MẮT<br>Chất liệu: Vải 100% thun cotton mềm mịn, thấm hút mồ hôi tốt',145,110000,'L01','TH01',N'ao-thun-nam-ngan-tay.jpg')
insert into SanPham values('SP02',N'ÁO THUN NAM NGẮN TAY CỔ TRỤ',N'ÁO THUN NAM CỔ TRỤ NGẮN TAY VIỀN CỔ IN LOGO MẪU MỚI<br>Chất liệu: Vải 100% thun cotton mềm mịn, thấm hút mồ hôi tốt',42,155000,'L01','TH01',N'ao-thun-nam-co-tru-ngan-tay.jpg')
insert into SanPham values('SP03',N'ÁO THUN NAM HÌNH HỔ 3D',N'ÁO THUN NAM HÌNH HỔ 3D: Chất vải thun 3D mịn lạnh, thấm hút mồ hôi nhanh giúp các chàng luôn thoải mái khi vận động, chơi các trò chơi thể thao, thể chất. Bên cạnh đó là thiết kế mạnh mẽ với hình hổ ấn tượng mang đến cho các chàng sự sang trọng, trẻ trung  để các chàng luôn sẵn sàng xuất hiện trước các nàng mà không lo thiếu sự thu hút.<br>Chất liệu: VẢI THUN 3D CO GIÃN CAO CẤP',78,155000,'L01','TH01',N'ao-thun-nam-hinh-ho-3d.jpg')
--03--
insert into SanPham values('SP04',N'SƠ MI NAM HÀN QUỐC TRẺ TRUNG',N'SƠ MI NAM HÀN QUỐC TRẺ TRUNG: Chất vải dày dặn cao cấp, đặc biệt với những sọc nhỏ tinh tế cùng dáng áo chuẩn để các chàng tự tin khoe dáng. Bên cạnh đó là chất màu lên tông chuẩn để các chàng lựa chọn phong cách cho mình thật thoải mái. Ngoài ra, với thiết kế tay dài thanh lịch, chiếc áo sẽ là bạn đồng hành cùng các chàng trai trong những ngày lên công tay hay trong những buổi gặp khách hàng.<br>Chất liệu: VẢI KAKI MỀM',85,240000,'L03','TH03',N'so-mi-nam-han-quoc.jpg')
insert into SanPham values('SP05',N'SƠ MI NAM CARO Ô LỚN',N'SƠ MI NAM CARO Ô LỚN: Chất vải kate dày dặn cao cấp, dáng áo chuẩn để các chàng tự tin khoe dáng. Bên cạnh đó là họa tiết caro ôn lớn đối xứng sang trọng nhưng không kém phần tươi trẻ kết hợp với thiết kế tay dài thanh lịch, chiếc áo sẽ là bạn đồng hành cùng các chàng trai trong những ngày lên công ty hay trong những buổi gặp khách hàng.<br>Chất liệu: VẢI KATE DÀY MỊN',73,220000,'L03','TH03',N'so-mi-nam-caro.jpg')
insert into SanPham values('SP06',N'ÁO SƠ MI NAM LOANG MÀU THỜI THƯỢNG',N'ÁO SƠ MI NAM LOANG MÀU THỜI THƯỢNG: Chất vải dày dặn cao cấp, dáng áo chuẩn để các chàng tự tin khoe dáng. Bên cạnh đó là chất màu lên tông chuẩn để các chàng lựa chọn phong cách cho mình thật thoải mái. Ngoài ra, với thiết kế tay dài thanh lịch nhưng không mất đi sự trẻ trung pha chút nổi loạn với việc kết hợp màu loang mới mẻ.<br>Chất liệu: KATE BÓNG CAO CẤP',14,235000,'L03','TH03',N'ao-so-mi-nam-loang-mau.jpg')
--11--
insert into SanPham values('SP07',N'QUẦN SHORT JEANS CÓ KHUY ĐỘC ĐÁO',N'QUẦN SHORT JEANS CÓ KHUY ĐỘC ĐÁO: Chất vải jeans cao cấp xuất khẩu vừa dày dặn, nhẹ mịn vừa co giãn vừa phải giúp người mang dế chịu, tự tin. Bên cạnh đó còn là thiết kế trẻ trung, năng động và đầy độc đáo với khuy sản phẩm lạ mắt.<br>Chất liệu: VẢI JEANS CAO CẤP XUẤT KHẨU',58,180000,'L11','TH11',N'quan-short-jeans-co-khuy.jpg')
insert into SanPham values('SP08',N'QUẦN ĐÙI NAM SỐ 69 CAO CẤP',N'QUẦN ĐÙI NAM SỐ 69 CAO CẤP: Thiết kế trẻ trung, năng động với thiết kế săn lai ống giúp các trai trông năng động hơn. Bên cạnh đó chất vải jenas dày dặn mang đến sự tự tin cho các chàng trong việc hoạt động vui chơi mà không lo các sự cố khó xửa xảy ra.<br>Chất liệu: VẢI JEANS CAO CẤP XUẤT KHẨU',185,185000,'L11','TH11',N'quan-dui-nam-so-69-cao-cap.jpg')
insert into SanPham values('SP09',N'QUẦN SHORT JEANS NAM KẾT HỢP HỌA TIẾT CHIBI',N'QUẦN SHORT JEANS NAM KẾT HỢP HỌA TIẾT CHIBI ĐÁNG YÊU: Chất vải jeans cao cấp nhập khẩu Thái Lan mang đến cho người mặc sự thoải mái và tin tưởng bởi chất vải dày dặn, mịn nhẹ. bên cạnh đó ngoài những nét cắt rách táo bạo là họa tiết chibi mang đến sự trẻ trung, nắng động cho người mang.<br>Chất liệu: VẢI JEANS NHẬP KHẨU THÁI LAN',17,180000,'L11','TH11',N'quan-short-jeans-nam.jpg')
--13--
insert into SanPham values('SP10',N'QUẦN JEANS NAM CAO CẤP THIẾT KẾ KẾT HỢP VẢI MẪU',N'QUẦN JEANS NAM CAO CẤP THIẾT KẾ KẾT HỢP VẢI MẪU: Chất vải cao cấp xuất khẩu dày dặn, lên form chuẩn dáng để các chàng thoải mái khoe body. Bên cạnh đó là thiết kế phong cách đường phố mạnh mẽ, phá cách với những nét cắt, xước táo bạo, độc đáo mà chỉ riêng sản phẩm có.<br>Chất liệu: VẢI JEANS NAM CAO CẤP NHẬP KHẨU',24,265000,'L13','TH13',N'quan-jeans-nam-cao-cap.jpg')
insert into SanPham values('SP11',N'QUẦN JEANS NAM NHẤN GỐI TRÁI TINH TẾ',N'QUẦN JEANS NAM NHẤN GỐI TRÁI TINH TẾ: Chất vải cao cấp xuất khẩu dày dặn, lên form chuẩn dáng để các chàng thoải mái khoe body. Bên cạnh đó là thiết kế phong cách đường phố mạnh mẽ, phá cách với những nét cắt, xước táo bạo, độc đáo mà chỉ riêng sản phẩm có.<br>Chất liệu: VẢI JEANS NHẬP KHẨU HÀN QUỐC',28,270000,'L13','TH13',N'quan-jeans-nam-nhan-goi-trai.jpg')
insert into SanPham values('SP12',N'QUẦN JEAN NAM PHONG CÁC ĐƯỜNG PHỐ MỚI',N'QUẦN JEAN NAM PHONG CÁC ĐƯỜNG PHỐ MỚI: Thiết kế phá cách, theo xu hướng đường phố đem đến cho các chàng trai sự năng động, pha chút nổi loạn làm các chàng trai trông thật sự nổi bật cũng như tự tin thể hiện phong cách của bản thân trong mọi cuộc vui.<br>Chất liệu: VẢI JEANS CAO CẤP XUẤT KHẨU',27,265000,'L13','TH13',N'quan-jean-nam.jpg')
--12
insert into SanPham values('SP13',N'QUẦN KAKI LƯNG PHỐI DÂY SỌC QK005 MÀU XANH ĐEN',N'Sớ vải dệt xéo nổi lên khá lạ mắt tạo nên một sản phẩm dày dặn, bền bỉ và ít nhăn, chất liệu cao cấp mang đến sự thoáng mát, thấm hút mồ hôi cao.
<br>- Quần co giãn nhẹ  nhờ có thành phần spandex giúp người mặc cảm thấy thoải mái, dễ chịu hơn.
<br>- Sản phẩm được xử lý wash mềm, đốt lông nên đảm bảo hạn chế co rút, xù lông và bền màu.
<br>- Phần phối dây dệt sọc ở lưng quần làm điểm nhấn mới lạ đầy ấn tượng nhưng vẫn giữ được nét thanh lịch, thời thượng cho phái mạnh.<br>Chất liệu: Khaki 98% cotton 2% spandex twill stretch.',89,355000,'L12','TH12',N'quan-kaki-nam-lung-phoi-day-soc.png')
insert into SanPham values('SP14',N'QUẦN KAKI LƯNG PHỐI DÂY SỌC QK005 MÀU CÀ PHÊ',N'Sớ vải dệt xéo nổi lên khá lạ mắt tạo nên một sản phẩm dày dặn, bền bỉ và ít nhăn, chất liệu cao cấp mang đến sự thoáng mát, thấm hút mồ hôi cao.
<br>- Quần co giãn nhẹ  nhờ có thành phần spandex giúp người mặc cảm thấy thoải mái, dễ chịu hơn.
<br>- Sản phẩm được xử lý wash mềm, đốt lông nên đảm bảo hạn chế co rút, xù lông và bền màu.
<br>- Phần phối dây dệt sọc ở lưng quần làm điểm nhấn mới lạ đầy ấn tượng nhưng vẫn giữ được nét thanh lịch, thời thượng cho phái mạnh.<br>Chất liệu: Khaki 98% cotton 2% spandex twill stretch.',20,355000,'L12','TH12',N'quan-kaki-nam.png')
insert into SanPham values('SP15',N'QUẦN KAKI CÓ NẮP TÚI SAU QK003 MÀU XÁM',N'Mềm mại, độ bền cao, hút ẩm và thấm hút mồ hôi tốt. Thiết kế căn bản dễ mix&match nhiều dạng quần áo và phong cách.<br>Chất liệu: 98% cotton, 2% spandex.',86,310000,'L12','TH12',N'quan-nam-kaki-co-nap-tui-sau.png')
--14
insert into SanPham values('SP16',N'QUẦN TÂY NAZAFU QT006 MÀU XANH ĐEN',N'Chất vải mềm mại, độ bền cao, hút ẩm và thấm hút mồ hôi tốt. Họa tiết kẻ caro Glen plaid rất "đa dụng", thanh nhã. <br>Chất liệu: 73% polyester, 26% rayon, 1% spandex.',43,427000,'L14','TH14',N'quan-tay-nazafu.png')
insert into SanPham values('SP17',N'QUẦN TÂY CĂN BẢN FORM SLIMFIT QT015',N'Quần slimfit tôn dáng thon gọn trong thiết kế trơn căn bản. Chất liệu thấm hút tốt, độ bền cao tạo cảm giác thoải mái cho người mặc.<br>Chất liệu: 68% polyester,rayon 29%, 3% spandex.',47,382000,'L14','TH14',N'quan-tay-phoi-day-det.png')
insert into SanPham values('SP18',N'QUẦN TÂY XẾP LY FORM SLIMFIT QT007 MÀU XÁM CHUỘT ĐẬM',N'Chống nhăn, co dãn nhẹ. Thiết kế trên chất vải bóng mịn, sở hữu độ bền màu cao tạo phong thái lịch thiệp và tinh tế cho người mặc.<br>Chất liệu: 83% polyester, 15% rayon, 2% spandex.',48,346000,'L14','TH14',N'quan-tay-xep-ly-form.png')

---------------------------------------------------------------------
--15
insert into SanPham values('SP19',N'QUẦN JOGGER LƯNG THUN CÀI NÚT J004 MÀU XÁM XANH',N'Mềm mịn, có độ rũ nhẹ. Độ bền màu cao, thấm hút mồ hôi tốt. Co giãn nhẹ, hạn chế nhăn tạo cảm giác thoải mái tối đa trong mọi hoạt động<br>Chất liệu: 83% polyester, 15% rayon, 2% spandex.',25,337000,'L15','TH15',N'quan-tay-lung-thun-cai-nut.png')
insert into SanPham values('SP20',N'QUẦN JOGGER JEAN J13 MÀU XANH ĐEN',N'Đậm chất jeans nhưng là jogger năng động & cá tính. Jogger đơn giản với thiết kế bo lưng & bo lai mới tạo điểm nhấn cho quần luôn thoải mái, trẻ trung, jogger thực sự thuộc về các chàng trai ưu thích sự di chuyển.<br>Chất liệu: 98% cotton, 2% spandex',76,400000,'L15','TH15',N'quan-jogger-jean-mau-xanh-bien.jpg')
insert into SanPham values('SP21',N'QUẦN JOGGER TÚI ĐẮP J001 MÀU ĐEN',N'Co giãn vừa phải, bền màu, ít nhăn. Form dáng thoải mái, năng động với 2 túi đắp bên hông quần tạo phong thái trẻ trung và phóng khoáng.<br>Chất liệu: 65% polyester, 32% rayon, 3% spandex.',86,346000,'L15','TH15',N'quan-jogger-kaki-bo-lai.png')
--02--
insert into SanPham values('SP22',N'ÁO THUN NỮ TRẺ TRUNG MỚI',N'ÁO THUN NỮ TRẺ TRUNG MỚI: Với thiết kế trẻ trung với viền màu nổi bật cùng hình ảnh bắt mắt bên cạnh đó là chất vải cao cấp, lên màu, lên dáng chuẩn như các cô gái muốn giúp các nàng luôn tự tin tỏa sáng và thoải mái khi mang dù cho là cả ngày dài hoạt động.<br>Chất liệu: VẢI DA CÁ CAO CẤP',17,125000,'L02','TH02',N'ao-thun-nu-tre-trung-moi.jpg')
insert into SanPham values('SP23',N'ÁO THUN NỮ HIỆN ĐẠI CAO CẤP',N'ÁO THUN NỮ HIỆN ĐẠI CAO CẤP: Thiết kế hiện đại với kiểu tay phồng nhún viền tinh tế, bắt mắt bên cạnh đó là chất vải thun dày dặn cao cấp không chỉ lên màu chuẩn mà còn lên dáng chuẩn như các nàng muốn giúp các nàng luôn tự tin tỏa sáng và thoải mái khi mang dù cho là cả ngày dài hoạt động.<br>Chất liệu: VẢI THUN CAO CẤP DÀY DẶN',33,140000,'L02','TH02',N'ao-thun-nu-hien-dai-cao-cap.jpg')
insert into SanPham values('SP24',N'ÁO THUN NỮ SỌC MÀU NĂNG ĐỘNG',N'ÁO THUN NỮ SỌC MÀU NĂNG ĐỘNG: Thiết kế hiện đại với những sọc màu bắt mắt, sự kết hợp những màu sắc nổi bật đi cùng nhau tạo nên sự khác biệt mang phong cách Hàn Quốc bên cạnh đó là chất vải cao cấp, lên màu, lên dáng chuẩn như ming muốn giúp các nàng luôn tự tin tỏa sáng và thoải mái khi mang dù cho là cả ngày dài hoạt động.<br>Chất liệu: VẢI NHŨ NHẬP KHẨU',113,140000,'L02','TH02',N'ao-thun-nu-soc-mau-nang-dong.jpg')
--04--
insert into SanPham values('SP25',N'SƠ MI NỮ KIỂU CỔ VUÔNG HIỆN ĐẠI',N'SƠ MI NỮ KIỂU CỔ VUÔNG HIỆN ĐẠI: Chất vải voan mềm mịn cùng với chất len gân co giãn mang đến vẻ đẹp dịu dàng nữ tính cùng sự thoải mái, dễ chịu khi hoạt động cả ngày dài. Đặc biệt là thiết kế hiện đại, mang nét gợi cảm giúp người mang nổi bật với nét đẹp hiện đại thời thượng.<br>Chất liệu: VẢI VOAN MỀM KẾT HỢP LEN GÂN MỎNG',124,210000,'L04','TH04',N'so-mi-nu-kieu-co-vuong-hien-dai.jpg')
insert into SanPham values('SP26',N'ÁO SƠ MI NỮ SỌC TAY LỬNG THIẾT KẾ ĐỘC ĐÁO',N'ÁO SƠ MI NỮ SỌC TAY LỬNG THIẾT KẾ ĐỘC ĐÁO: Chất liệu kate mềm mịn cao cấp thướt tha, nhẹ nhàng, dễ chịu. Kiểu dáng áo cổ bẻ, tay lửng thời trang, mang nền vải sọc vân nhỏ đậm chất lịch sự cho bạn gái thêm phần trang nhã, lịch sự và đầy nữ tính. Chiếc áo không chỉ thích hợp cho những ngày đến cơ quan, công sở mà còn là một sự lựa chọn khá hoàn hảo cho những buổi đầu hẹn hò khi muôn xuất hiện với hình ảnh trang nhã.<br>Chất liệu: VẢI KATE MỀM NHẸ CAO CẤP',88,220000,'L04','TH04',N'ao-so-mi-nu-soc-tay-lung.jpg')
insert into SanPham values('SP27',N'ÁO SƠ MI NỮ TRƠN FROM ÁO ĐỘC ĐÁO',N'ÁO SƠ MI NỮ TRƠN FROM ÁO ĐỘC ĐÁO: Với chất vải kate cao cấp mềm mịn và thoáng khí giúp người mang thoải mái khi hoạt động cả ngày dù trong thời tiết nắng nóng. Bên cạnh đó là from áo độc đáo mang tới vẻ đẹp cá tính, hiện đại giúp các nàng trông thật nổi bật trong mọi cuộc vui.<br>Chất liệu: VẢI KATE CAO CẤP',139,210000,'L04','TH04',N'ao-so-mi-nu-tron-from-ao.jpg')
--05--
insert into SanPham values('SP28',N'ĐẦM NỮ CỔ CHỮ U XẺ TÀ SÀNH ĐIỆU',N'ĐẦM NỮ CỔ CHỮ U XẺ TÀ SÀNH ĐIỆU: Với chất vải cao cấp nhập khẩu từ Thái Lan, vải dày dặn, thấm hút mồ hôi tốt. Bên cạnh đó thiết kế sang trọng với cổ chữ U và xẻ tà quyến rũ giúp người mặc trông thật trẻ trung năng động và đầy tự tin. <br>Chất liệu: VẢI KATE CO GIÃN NHẬP KHẨU THÁI LAN',140,240000,'L05','TH05',N'dam-nu-co-chu-u-xe-ta-sanh-dieu.jpg')
insert into SanPham values('SP29',N'ĐẦM HOA 2 LỚP XẾP EO MS 48B8245',N'Đầm 2 lớp dáng chữ A, cổ tròn. Xếp nếp ở mặt trước phần eo. Tay lỡ. Cài bằng khóa kéo ẩn sau lưng. Vải họa tiết hoa thu hút. Kiểu dáng chữ A, ôm nhẹ với độ dài trên gối cùng phần tay lỡ giúp che đi hầu hết các khuyết điểm cơ thể. Bên cạnh đó chất liệu thô co giãn nhẹ, bền màu, ít nhăn mang lại cảm giác thoải mái khi mặc. <br>Chất liệu: Thô',150,100000,'L05','TH05',N'damhoa2lop.jpg')
insert into SanPham values('SP30',N'ĐẦM LỤA CHẤM BI 2 LỚP MS 48M4844',N'Đầm lụa chấm bi, cổ chữ V vạt trước đáp chéo được xếp nếp tinh tế, tay ngắn. Dáng ôm. Eo chiết kèm đai cùng màu. Gấu sau xẻ. Cài bằng khóa kéo ẩn sau lưng. Những đường xếp ly ở phần chân váy giúp che được hết những khuyết điểm của cô nàng mảnh khảnh và mang đến sự tinh nghịch, trẻ trung, phá cách mà không kém phần quyến rũ cho phái đẹp. <br>Chất liệu: Lụa',75,345000,'L05','TH05',N'damluachambi.jpg')
--06
insert into SanPham values('SP31',N'Chân Váy Jean Rách',N'Màu sắc: Đen - Trắng. Kiểu dáng: Chất kaki jeans Co giãn, dày dặn, không xù lông và có thể giặt máy. Size : Size: S (dưới 45kg), M(46-50kg), L(51-55kg). Mục đích sử dụng: dạo phố. đi chơi, đi học hoặc đi làm',119,200000,'L06','TH06',N'chan-vay-jean-rach.jpg')
insert into SanPham values('SP32',N'Chân Váy Jean Ngắn',N'Màu sắc: Đen - Trắng. Kiểu dáng: Chất kaki jeans Co giãn, dày dặn, không xù lông và có thể giặt máy. Size : Size: S (dưới 45kg), M(46-50kg), L(51-55kg). Mục đích sử dụng: dạo phố. đi chơi, đi học hoặc đi làm',129,200000,'L06','TH06',N'chan-vay-jean-om.jpg')
insert into SanPham values('SP33',N'Chân Váy Xếp Ly',N'Những chiếc Chân Váy Xếp Ly mềm mại với chiều dài trên gối là lựa chọn dành riêng cho các quý cô yêu thích phong cách lãng mạn. Vì sao ư? vì chúng đơn giản nhưng không hề nhàm chán, kín đáo nhưng lại quyến rũ một cách lạ thường. Sự bắt cặp quá đỗi hoàn hảo này là bởi những đường ly thanh mảnh mềm mại đến tinh tế sẽ khiến cho các quý cô trông thật duyên dáng và chiều dài chỉ đến ngang bắp chân sẽ khiến cho mỗi bước đi trông thật uyển chuyển và gợi cảm. Chiếc váy chính là món đồ có thể kết hợp ăn ý cùng áo len chui đầu, áo phông, sơ mi dáng rộng và một đôi giày/sandals cao gót thanh mảnh.',144,200000,'L06','TH06',N'chan-vay-xep-ly.png')
--07
insert into SanPham values('SP34',N'SHORT LƯNG THUN VIỀN SỌC',N'Mix- Max phối cùng các kiểu áo thun thời trang, croptop phá cách, áo ba lỗ mát mẻ. Lưng thun dây rút tạo cảm giác thoải mái và tự tin cho người mặc. Short viền sọc là style đầy mới mẻ dành cho tủ đồ ngày hè của bạn gái.',145,100000,'L07','TH07',N'quan-shorrt-nu-lung-thun-vien-soc.png')
insert into SanPham values('SP35',N'Quần Short Jean Nhung',N'Quần Short Jean Rách Nhung cách điệu với thiết kế chuẩn form co giãn, đẹp mắt, dễ thương, kiểu dáng đơn giản. Dáng quần vừa vặn nhiều vóc người. Có thể kết hợp cùng nhiều thiết kế áo kiểu khác nhau.',112,150000,'L07','TH07',N'quan-shorrt-nu-lung-thun-vien-soc.png')
insert into SanPham values('SP36',N'Quần Short 2 Túi Lai V',N'Mix- Max phối cùng các kiểu áo thun thời trang, croptop phá cách, áo ba lỗ mát mẻ. Lưng thun dây rút tạo cảm giác thoải mái và tự tin cho người mặc. Short viền sọc là style đầy mới mẻ dành cho tủ đồ ngày hè của bạn gái.',149,159000,'L07','TH07',N'quan-short-2-tui-lai.png')
--08--
insert into SanPham values('SP37',N'QUẦN JEANS NỮ ỐNG SUÔNG CÁCH ĐIỆU CÁ TÍNH',N'QUẦN JEANS NỮ ỐNG SUÔNG CÁCH ĐIỆU CÁ TÍNH: Với những cô nàng đã cực kỳ đam mê với mẫu quần ống suông nhưng thấy nhàm chán với mẫu basic ban đầu thì chắc chắn sản phẩm sẽ làm các nàng hài lòng với sự nhấn nhá, cách điệu với đường cắt dứt khoác, mạnh mẽ lần lượt tại hông và bắp chân. Đặc biệt là ống quần với thiết kế cắt thuần túy tại nên những tua rua tự nhiên mang đến sự năng động cho các nàng.<br>Chất liệu: VẢI JEANS DÀY MỊN',220,178000,'L08','TH08',N'quan-jeans-nu-ong-suong-cach-dieu-ca-tinh.jpg')
insert into SanPham values('SP38',N'QUẦN JEANS NỮ NHẤN CHỮ ĐÙI CÁ TÍNH',N'QUẦN JEANS NỮ NHẤN CHỮ ĐÙI CÁ TÍNH : Chất vải jeans cao cấp, tuyển chọn đảm bảo được form quần và màu lên chuẩn cùng với thiết kế hiện đại kèm theo sự trẻ trung thanh lịch để các cô gái luôn có thể tự tin diện ở mọi nơi mà không lo rằng sẽ không phù hợp và chắc chắn là các cô gái sẽ thật tỏa sáng, nổi bật với phong cách nhẹ nhàng.<br>Chất liệu: VẢI JEANS DÀY DẶN XUẤT KHẨU',218,105000,'L08','TH08',N'quan-jeans-nu-nhan-chu-dui-ca-tinh.jpg')
insert into SanPham values('SP39',N'QUẦN JEANS NỮ WASH ỐNG ĐỘC ĐÁO',N'QUẦN JEANS NỮ WASH ỐNG ĐỘC ĐÁO: Chất liệu vải jeans dày dặn cao cấp, chắc chắn cho bạn yên tâm khi hoạt động mạnh, có khả năng thấm hút các giọt mồ hôi và co giãn tốt. Kiểu dáng thiết kế ống ôm sang trọng, khoe dáng, luôn luôn được những bạn gái yêu mến trong mọi phong cách thời trang.<br>Chất liệu: VẢI JEANS CHẤT LIỆU CAO CẤP',25,104000,'L08','TH08',N'quan-jeans-nu-wash-ong-doc-dao.jpg')
--09
insert into SanPham values('SP40',N'QUẦN JOGGER DÂY KÉO NỮ XANH BIỂN',N'Phối quần jogger nữ với Áo crop top là item thời trang không thể thiếu trong tủ đồ hè của bạn gái. Chiếc áo cá tính này cũng là “người bạn thân” với quần jogger nữ. Cách phối đồ với quần jogger nữ và áo crop top không chỉ mang đến vẻ đẹp khoẻ khoắn, trẻ trung mà còn giúp các nàng khoe khéo vòng eo “con kiến” của mình.',140,160000,'L09','TH09',N'quan-jogger-day-keo-nu-xanh-than.jpg')
insert into SanPham values('SP42',N'QUẦN JOGGER KAKI NỮ XÁM TRẮNG',N'Phối quần jogger nữ với Áo crop top là item thời trang không thể thiếu trong tủ đồ hè của bạn gái. Chiếc áo cá tính này cũng là “người bạn thân” với quần jogger nữ. Cách phối đồ với quần jogger nữ và áo crop top không chỉ mang đến vẻ đẹp khoẻ khoắn, trẻ trung mà còn giúp các nàng khoe khéo vòng eo “con kiến” của mình.',222,109000,'L09','TH09',N'quan-jogger-kaki-nu-xam-trang.jpg')
insert into SanPham values('SP43',N'QUẦN JOGGER NỮ CÓ KHÓA GỐI KAKI ĐEN',N'Phối quần jogger nữ với Áo crop top là item thời trang không thể thiếu trong tủ đồ hè của bạn gái. Chiếc áo cá tính này cũng là “người bạn thân” với quần jogger nữ. Cách phối đồ với quần jogger nữ và áo crop top không chỉ mang đến vẻ đẹp khoẻ khoắn, trẻ trung mà còn giúp các nàng khoe khéo vòng eo “con kiến” của mình.',170000,100000,'L09','TH09',N'quan-jogger-nu-co-khoa.jpg')


------------------------------Khuyen Mai ----------------------------------------------------------
--1--
insert into KhuyenMai values('KM01',N'ÁO THUN NAM NGẮN TAY CỔ TRỤ',110000,N'ao-thun-nam-ngan-tay.jpg',50,'SP01',N'2020-06-05',N'2020-12-05')
--2--
insert into KhuyenMai values('KM02',N'ÁO THUN NỮ TRẺ TRUNG MỚI',125000,N'ao-thun-nu-tre-trung-moi.jpg',70,'SP22',N'2020-06-05',N'2020-12-05')
--3--
insert into KhuyenMai values('KM03',N'SƠ MI NAM HÀN QUỐC TRẺ TRUNG',240000,N'so-mi-nam-han-quoc.jpg',40,'SP04',N'2020-06-05',N'2020-12-05')
--4--
insert into KhuyenMai values('KM04',N'SƠ MI NỮ KIỂU CỔ VUÔNG HIỆN ĐẠI',210000,N'so-mi-nu-kieu-co-vuong-hien-dai.jpg',40,'SP25',N'2020-06-05',N'2020-12-05')
--5---
insert into KhuyenMai values('KM05',N'ĐẦM NỮ CỔ CHỮ U XẺ TÀ SÀNH ĐIỆU',240000,N'dam-nu-co-chu-u-xe-ta-sanh-dieu.jpg',60,'SP28',N'2020-06-05',N'2020-12-05')
--6--
insert into KhuyenMai values('KM06',N'Chân Váy Jean Rách',200000,N'chan-vay-jean-rach.jpg',45,'SP31',N'2020-06-05',N'2020-12-05')
--7--
insert into KhuyenMai values('KM07',N'SHORT LƯNG THUN VIỀN SỌC',100000,N'quan-shorrt-nu-lung-thun-vien-soc.png',48,'SP34',N'2020-06-05',N'2020-12-05')
--8--
insert into KhuyenMai values('KM08',N'QUẦN JEANS NỮ ỐNG SUÔNG CÁCH ĐIỆU CÁ TÍNH',65000,N'quan-jeans-nu-ong-suong-cach-dieu-ca-tinh.jpg',65,'SP37',N'2020-06-05',N'2020-12-05')
--9--
insert into KhuyenMai values('KM09',N'QUẦN JOGGER DÂY KÉO NỮ XANH BIỂN',68000,N'quan-jogger-day-keo-nu-xanh-than.jpg',58,'SP40',N'2020-06-05',N'2020-12-05')
--11--
insert into KhuyenMai values('KM11',N'QUẦN SHORT JEANS CÓ KHUY ĐỘC ĐÁO',56000,N'quan-short-jeans-co-khuy.jpg',65,'SP07',N'2020-06-05',N'2020-12-05')
---12--
insert into KhuyenMai values('KM12',N'QUẦN KAKI LƯNG PHỐI DÂY SỌC QK005 MÀU XANH ĐEN',67000,N'quan-kaki-nam-lung-phoi-day-soc.png',42,'SP13',N'2020-06-05',N'2020-12-05')
--13--
insert into KhuyenMai values('KM13',N'QUẦN JEANS NAM CAO CẤP THIẾT KẾ KẾT HỢP VẢI MẪU',40000,N'quan-jeans-nam-cao-cap.jpg',43,'SP10',N'2020-06-05',N'2020-12-05')
--14---
insert into KhuyenMai values('KM14',N'QUẦN TÂY NAZAFU QT006 MÀU XANH ĐEN',45000,N'quan-tay-nazafu.png',47,'SP16',N'2020-06-05',N'2020-12-05')
--15---
insert into KhuyenMai values('KM15',N'QUẦN JOGGER LƯNG THUN CÀI NÚT J004 MÀU XÁM XANH',48000,N'quan-tay-lung-thun-cai-nut.png',52,'SP19',N'2020-06-05',N'2020-12-05')


---HDN------------------
insert into HDN values('cuongtt2002','NCC01','SP01',N'2020-05-21',5,10000)

