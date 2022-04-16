-- Nhan vien
use APIMOVIES
go
--Tai khoan
Insert into dbo.TB_NGUOIDUNG (TENDANGNHAP, LOAITAIKHOAN, MATKHAU) values('Admin', 'Admin', 'Admin')
go
-- db loaiphim
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'Phim Hoạt Hình')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'Action')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'Drama')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'Adventure')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'magic')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'horror')
insert into TB_LOAIPHIM(TENLOAIPHIM) values(N'romantic')
go
-- db phim
-- db phim
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://4.bp.blogspot.com/-TnjEoVOSD8g/W21pjXRwKFI/AAAAAAAAB0Q/l0nP21iIercBgGwIsD5p4qzBFN8eeCOXgCLcBGAs/s1600/ABMylCv.png',N'Doraemon: Nobita và Đảo giấu vàng, Doraemon: Đảo kho báu của Nobita 2018 Phim Doraemon: Nobita và Đảo giấu vàng “Mình sẽ tìm ra Đảo kho báu!”… Quyết tâm thực hiện kế hoạch sau khi hùng hồn tuyên bố với nhóm bạn Jaian, Suneo và Shizuka nhờ có kho báu "Bản đồ kho báu" của Doraemon, Nobita đã tìm được một hòn đảo mới bất ngờ xuất hiện giữa Thái Bình Dương ... Nobita và các bạn bắt đầu cuộc phiêu lưu của mình.',N'120',N'Nobita Và Đảo Giấu Vàng',N'English',2019,7.00,N'https://www.youtube.com/watch?v=iUP2PPGfVPk')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.5cb122df04b46aacc8f185e4540a4fad?rik=Wt8podFbRuucDQ&pid=ImgRaw&r=0',N'Sau những sự kiện tàn khốc của Avengers: Infinity War (2018), vũ trụ đang dần tàn lụi. Với sự giúp đỡ của các đồng minh còn lại, các Avengers tập hợp một lần nữa để đảo ngược hành động của Thanos và khôi phục lại sự cân bằng cho vũ trụ.',N'120',N'Avengers: Hồi kết',N'English',2019,7.00,N'https://www.youtube.com/watch?v=TcMBFSGVi1c')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://ghienreview.com/wp-content/uploads/2020/07/Ghien-review-Nha-tu-Shawshank-1024x576.jpg',N'Nhà Tù Shawshank kể về Andy Dufresne là một nhân viên ngân hàng trẻ và thành công mà cuộc sống thay đổi mạnh khi ông bị kết tội và bị kết án tù chung thân vì tội giết vợ và người yêu của mình.',N'120',N'Nhà tù Shawshank',N'English',2019,8.00,N'https://www.youtube.com/watch?v=P9mwtI82k6E')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://storage.googleapis.com/cuoituan/2020/02/bo-gia%20_1581939817.jpeg',N'Phim Bố Già được chuyển thể từ tiểu thuyết cùng tên của nhà văn Mario Puzo. Vito Corleone là ông trùm khét tiếng nhất tại Mỹ lúc bấy giờ. Tuy nhiên, con trai út của ông - Michael sau khi trở về từ Thế chiến II quyết định không tham gia bất cứ phi vụ gì của gia đình. Nhưng trong đám cưới của con gái Vito, một trận chiến khốc liệt nổ ra trong thế giới tội phạm, Michael chứng kiến cha mình bị bọn mafia đối đầu ám sát. ',N'120',N'Bố già',N'English',2019,7.00,N'https://www.youtube.com/watch?v=UaVTIH8mujA')

insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.41d0ab7883112bc0dc205bd8c5d76f41?rik=YSEK9QtXqIeH6A&pid=ImgRaw&r=0',N'The Dark Knight là phần tiếp theo của Batman Begins kể về thành phố Gotham bị đảo lộn do hàng loạt vụ giết người xảy ra mà không tìm ra hung thủ. Kẻ đứng sau tất cả âm mưu đen tối này là Joker (Heath Ledger), kẻ được các băng đảng trong thành phố thuê để trừ khử Người Dơi.',N'120',N'Kỵ sĩ bóng đêm',N'English',2019,7.00,N'https://www.youtube.com/watch?v=u34gHaRiBIU')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.dca4ae66579d6bc5c9155859c831fbfd?rik=erC707gDjm7PGA&pid=ImgRaw&r=0',N'Sự trở lại của nhà vua - The Lord of the Rings : The Return of the King là bộ phim điện ảnh phiêu lưu kỳ ảo của Mỹ, và cũng là phần phim kết thúc của bộ ba phim Chúa tể những chiếc nhẫn của đạo diễn Peter Jackson.',N'120',N'Sự trở lại của nhà vua',N'English',2019,7.00,N'https://www.youtube.com/watch?v=-rQVS2ug01M')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://lineadirectaportal.com/u/fotografias/m/2020/6/25/f800x450-33019_84465_5050.jpg',N'Dom Cobb không phải là một đạo chích tầm thường, anh ta là bực thầy về đánh cắp, có thể xâm nhập vào cõi vô thức của bất kỳ người nào để đánh cắp những bí mật thầm kín nhất của người đó. Muốn thực hiện chuyện này, anh ta bước vào những giấc mơ của người đó. “Chúng ta tạo ra thế giới của giấc mơ. Chúng ta đưa đối tượng vào thế giới giấc mơ đó và đối tượng sẽ phun ra hết những bí mật, rồi chúng ta sẽ đánh cắp các bí mật đó.” ',N'120',N' Kẻ đánh cắp giấc mơ',N'English',2019,7.00,N'https://www.youtube.com/watch?v=y2TCjYiTGIo')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'http://cdn.tgdd.vn/Files/2020/12/26/1316294/review-phim-the-conjuring-2-2016-am-anh-kinh-hoang-la-cau-chuyen-co-that-202012270000188291.jpg',N'Khác với phong cách nhà ma ám trong hai phần phim trước, The Conjuring mùa mới mang đến tính hình sự sâu sắc hơn khi khai thác một trong những vụ án kinh điển của lịch sử toà án Mỹ.',N'120',N'The Conjuring 2',N'English',2019,7.00,N'https://www.youtube.com/watch?v=MAH2FJ4hGgs')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://tinhte.vn/store/2017/04/4019997_out10.jpg',N'Get Out) là một bộ phim điện ảnh kinh dị Mỹ[3][4][5] được biên kịch, sản xuất và đạo diễn bởi Jordan Peele, và đây đồng thời cũng là tác phẩm điện ảnh đầu tay của anh. Phim có sự tham gia của Daniel Kaluuya, Allison Williams, Bradley Whitford, Caleb Landry Jones, Stephen Root, Lakeith Stanfield và Catherine Keener, nội dung xoay quanh một cặp đôi khác sắc tộc yêu nhau và những sự thật khủng khiếp ẩn sâu trong gia đình của cô gái.',N'120',N'Get out',N'English',2019,8.00,N'https://www.youtube.com/watch?v=DzfpyUB60YY')

insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://nguoinoitieng.tv/images/nnt/96/2/bbw8.jpg',N'câu chuyện về những cô cậu bé của nhóm The Losers Club. Lúc này các cô cậu bé đã trưởng thành và đối mặt với vô số vấn đề trong cuộc sống. Chưa dừng lại ở đó, ám ảnh ma hề Pennywise cứ 27 năm lại xuất hiện một lần tại thị trấn Derry buộc 7 cô cậu bé ngày nào phải tiếp tục cuốn vào cuộc chạm trán tiếp theo giữa hai bên thiện và ác.',N'120',N'IT',N'English',2019,7.00,N'https://www.youtube.com/watch?v=FnCdOQsX5kc')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://cdnmedia.thethaovanhoa.vn/2013/07/31/14/02/image-Custom.jpg',N'The Shining là một bộ phim kinh dị tâm lý được đạo diễn bởi Stanley Kubrick, kịch bản được viết bởi Diane Johnson cùng với sự tham gia của các diễn viên Jack Nicholson, Shelley Duvall, Danny Lloyd và Scatman Crothers. Phim dựa trên cuốn tiểu thuyết cùng tên của nhà văn Stephen King. ',N'120',N'The Shining',N'English',2019,8.00,N'https://www.youtube.com/watch?v=S014oGZiSdI')

insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.5b5e370e1b45c8a08f4e4b126a903400?rik=QGUBTMJLnKzSDg&riu=http%3a%2f%2f1.bp.blogspot.com%2f-qOlUdRjumWA%2fVIRcHC0knjI%2fAAAAAAAAMj8%2f2h11MpTHkq0%2fs1600%2fthe-conjuring-movie-poster.jpg&ehk=mLCNnuHZ07b7nCq6zUn674SieraDS062qNnNrbf5f84%3d&risl=&pid=ImgRaw&r=0',N'Khác với phong cách nhà ma ám trong hai phần phim trước, The Conjuring mùa mới mang đến tính hình sự sâu sắc hơn khi khai thác một trong những vụ án kinh điển của lịch sử toà án Mỹ.',N'120',N'The Conjuring',N'English',2019,7.00,N'https://www.youtube.com/watch?v=rtL9k9oaT4Q')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.791d1d71c1dc2494366aeb1416542cf0?rik=69P%2fmsfkecPUVQ&pid=ImgRaw&r=0',N'After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school.',N'120',N'Inside Out',N'English',2019,7.00,N'https://www.youtube.com/watch?v=yRUAzGQ3nSY')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://i.kinja-img.com/gawker-media/image/upload/c_fill,f_auto,fl_progressive,g_center,h_675,pg_1,q_80,w_1200/bay1oaim43zmrpfyaezs.png',N'Phim Hàng Xóm Của Tôi Là Totoro Gia đình ông Kusakabe chuyển về vùng nông thôn sinh sống. Ở căn nhà mới mà họ chuyển tới bị đồn là có ma ám. ',N'120',N'My Neighbor Totoro',N'English',2019,7.00,N'https://www.youtube.com/watch?v=92a7Hj0ijLs')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.457a086750dad3d00ee639d334226699?rik=opneqBBdIj5SbQ&riu=http%3a%2f%2fwallpapers.com%2fimages%2fhigh%2fhowls-moving-castle-hd-wallpaper-nfnoz17nylnt45gd.jpg&ehk=Z1BgtB%2fr43Je7a%2bog%2bGX4uzmo4EDrKoM6O0xv7MGWig%3d&risl=&pid=ImgRaw&r=0',N'When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.',N'120',N'Howl Moving Castle',N'English',2019,7.00,N'https://www.youtube.com/watch?v=iwROgK94zcM')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://i.pinimg.com/originals/7a/53/e6/7a53e63b2555056cb8f7fd99ab8bbf32.jpg',N'Vút Bay - Up kể về Carl Fredricksen đã dành cả cuộc đời mình để mơ khám phá thế giới và trải nghiệm cuộc sống một cách trọn vẹn nhất. Nhưng ở tuổi 78, cuộc sống dường như đã trôi qua anh ta, cho đến khi một sự xoay chuyển của số phận (và một Nhà thám hiểm Hoang dã 8 tuổi kiên trì tên là Russell) cho anh ta một hợp đồng mới về cuộc sống.',N'120',N'Up',N'English',2019,7.00,N'https://www.youtube.com/watch?v=ORFWdXl_zJ4')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://www.teerasej.com/wp-content/uploads/2019/12/Klaus-2019-Banner.jpg',N'A simple act of kindness always sparks another, even in a frozen, faraway place. When Smeerensburgs new postman, Jesper, befriends toymaker Klaus, their gifts melt an age-old feud and deliver a sleigh full of holiday traditions.',N'120',N'Klaus',N'English',2019,7.00,N'https://www.youtube.com/watch?v=taE3PwurhYM')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://th.bing.com/th/id/R.906f88289bff82cfc2b533dc77e061d6?rik=GFtZAAF2UdJ4MQ&pid=ImgRaw&r=0',N'Nishimiya Shoko là một cô bé khiếm thính bẩm sinh. Khi học tiểu học, Shoko bị cậu bé Ishida Shoya bắt nạt. Sau đó, cô bé đột ngột chuyển trường. Từ đó, Shoya bị mang danh là “kẻ xấu tính chuyên bắt nạt”, bị bạn bè xa lánh. Nhiều năm sau, cả hai trở thành những học sinh trung học. Shoya gặp lại Shoko lần nữa. Cậu bé quyết định cố gắng để bù đắp những tổn thương ngày xưa của cô bạn gái. Thế nhưng, mọi thứ liệu có diễn ra như ý nguyện của cậu?',N'120',N'A Silent Voice',N'English',2019,7.00,N'https://www.youtube.com/watch?v=nfK6UgLra7g')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://is3-ssl.mzstatic.com/image/thumb/Video113/v4/ad/3d/76/ad3d7610-68ce-a500-bfac-9d602e896f88/PrincessMononoke_iTunes_16x9_3840x2160.png/1600x900.jpg',N'Bị trúng lời nguyền chết chóc, vị hoàng tử lên đường tìm cách hóa giải, để rồi rơi vào cuộc chiến giữa một thị trấn khai thác mỏ và các loài động vật trong rừng.',N'120',N'Princess Mononoke',N'English',2019,7.00,N'https://www.youtube.com/watch?v=4OiMOHRDs14')
insert into TB_PHIM(Anh,MOTAPHIM,THOILUONG,TENPHIM,NGONNGU,NAM,DANHGIAPHIM,DUONGDAN) values(N'https://img2.thuthuatphanmem.vn/uploads/2018/12/30/hinh-nen-anime-your-name_110749826.jpg',N'Mitsuha là cô nữ sinh sống tại vùng quê yên bình trong một thị trấn nhỏ được bao bọc xung quanh bởi núi rừng, cô có một cô em gái và gia đình cô kế thừa nghi lễ truyền thống của đền Shinto. Sau khi mẹ cô mất thì cha của cô không chịu nối nghiệp gia đình mà quyết định theo con đường chính trị. Cuộc sống thôn quê êm đềm khiến Mitsuha cảm thấy buồn tẻ và chán nản khi ở đây chẳng có bóng đèn sáng nguyên đêm, hiệu sách hay quán cà phê cũng không có, tàu chỉ đến mỗi 2 tiếng còn các cửa hàng thì 9 giờ đã đóng cửa. Cô từng mơ ước kiếp sau có thể trở thành chàng trai Tokyo thành thị.',N'120',N'Your name',N'English',2019,7.00,N'https://www.youtube.com/results?search_query=trailer+your+name')
go

--tạo db cho bảng trung gian phim
insert into TB_Phim_LoaiPhim values(N'1',N'1')
insert into TB_Phim_LoaiPhim values(N'2',N'2')
insert into TB_Phim_LoaiPhim values(N'2',N'3')
insert into TB_Phim_LoaiPhim values(N'2',N'4')
insert into TB_Phim_LoaiPhim values(N'13',N'1')
insert into TB_Phim_LoaiPhim values(N'14',N'1')
insert into TB_Phim_LoaiPhim values(N'15',N'1')
insert into TB_Phim_LoaiPhim values(N'16',N'1')
insert into TB_Phim_LoaiPhim values(N'17',N'1')
insert into TB_Phim_LoaiPhim values(N'18',N'1')
insert into TB_Phim_LoaiPhim values(N'19',N'1')
insert into TB_Phim_LoaiPhim values(N'20',N'1')
insert into TB_Phim_LoaiPhim values(N'8',N'6')
insert into TB_Phim_LoaiPhim values(N'9',N'6')
insert into TB_Phim_LoaiPhim values(N'10',N'6')
insert into TB_Phim_LoaiPhim values(N'11',N'6')
insert into TB_Phim_LoaiPhim values(N'12',N'6')
insert into TB_Phim_LoaiPhim values(N'3',N'2')
insert into TB_Phim_LoaiPhim values(N'3',N'3')
insert into TB_Phim_LoaiPhim values(N'4',N'2')
insert into TB_Phim_LoaiPhim values(N'5',N'2')
insert into TB_Phim_LoaiPhim values(N'5',N'3')
insert into TB_Phim_LoaiPhim values(N'5',N'4')
insert into TB_Phim_LoaiPhim values(N'6',N'2')
insert into TB_Phim_LoaiPhim values(N'6',N'3')
insert into TB_Phim_LoaiPhim values(N'6',N'4')
insert into TB_Phim_LoaiPhim values(N'7',N'2')
insert into TB_Phim_LoaiPhim values(N'7',N'3')
insert into TB_Phim_LoaiPhim values(N'7',N'4')

--tạo bảng quốc gia
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'USA')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'Japan')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'England')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'India')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'Korea')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'VietNam')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'China')
Insert into TB_QUOCGIA(TENQUOCGIA) values(N'ThaiLan')

 --bảng TB_PHIM_QUOCGIA
Insert into TB_PHIM_QUOCGIA values(N'2',N'1')
Insert into TB_PHIM_QUOCGIA values(N'1',N'2')
Insert into TB_PHIM_QUOCGIA values(N'1',N'3')
Insert into TB_PHIM_QUOCGIA values(N'1',N'4')
Insert into TB_PHIM_QUOCGIA values(N'1',N'5')
Insert into TB_PHIM_QUOCGIA values(N'1',N'6')
Insert into TB_PHIM_QUOCGIA values(N'1',N'7')
Insert into TB_PHIM_QUOCGIA values(N'1',N'8')
Insert into TB_PHIM_QUOCGIA values(N'1',N'9')
Insert into TB_PHIM_QUOCGIA values(N'1',N'10')
Insert into TB_PHIM_QUOCGIA values(N'1',N'11')
Insert into TB_PHIM_QUOCGIA values(N'1',N'12')
Insert into TB_PHIM_QUOCGIA values(N'2',N'13')
Insert into TB_PHIM_QUOCGIA values(N'3',N'14')
Insert into TB_PHIM_QUOCGIA values(N'2',N'15')
Insert into TB_PHIM_QUOCGIA values(N'2',N'16')
Insert into TB_PHIM_QUOCGIA values(N'1',N'17')
Insert into TB_PHIM_QUOCGIA values(N'2',N'18')
Insert into TB_PHIM_QUOCGIA values(N'2',N'19')
Insert into TB_PHIM_QUOCGIA values(N'2',N'20')

-- bang binh luan
Insert into TB_BINHLUAN(MATAIKHOAN, MAPHIM, NOIDUNG, THOIGIAN) values(1, 1, N'Phim rất hay', '2022/04/16');
Insert into TB_BINHLUAN(MATAIKHOAN, MAPHIM, NOIDUNG, THOIGIAN) values(1, 1, N'Phim rất hay', '2022/04/16');
Insert into TB_BINHLUAN(MATAIKHOAN, MAPHIM, NOIDUNG, THOIGIAN) values(1, 2, N'Phim  hay', '2022/04/16');
Insert into TB_BINHLUAN(MATAIKHOAN, MAPHIM, NOIDUNG, THOIGIAN) values(1, 2, N'Phim rất hay', '2022/04/16');
