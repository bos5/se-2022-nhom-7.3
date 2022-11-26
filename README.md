Nhóm 7.3 làm về game unity subway surfers

* Game features:
    -   Game này là phỏng theo subway surfers, đóng vai 1 nhân vật di chuyển liên tục trên đường thẳng theo 1 trong 3 đường ray và cố gắng né tránh các chướng ngại vật để đạt điểm cao, đồng thời nhặt vàng và các vật phẩm giúp ích.
    -   Bảng xếp hạng người chơi điểm cao.
    -   Cửa hàng để mua vật phẩm (key, coin, ....) và mua các nhân vật khác.
    -   Các vật phẩm ăn được khi  đang chơi (jetpack, supersneaker, coin magnet, 2x multiplier, hoverbike, hoverboard).
    -   Chế độ nhiều người chơi (online).
    -   Kẻ thù : 1 ông cảnh sát truy đuổi.
    -   Nhiệm vụ : nhặt các item; thử thách : nhặt các chữ cái.
    -   Kết nối với facebook để mời bạn bè chơi cùng, đua top điểm cùng bạn bè,...
    -   Đổi ngôn ngữ.
    -   Bật/tắt nhạc nền, âm thanh; điều chỉnh độ nhạy, mức độ các hiệu ứng; thoát game.

* Game goal: kiếm nhiều vàng để mở khóa tất cả nhân vật, mua các vật phẩm hỗ trợ để đạt được điểm càng cao càng tốt.
* Objectives: - Victory objective : không thực sự có (tự tạo cho bản thân 1 mục tiêu : mở khóa hết nhân vật; đạt điểm cao nhất thế giới;...)
              - Progression Objectives : các nhiệm vụ, thử thách, các dấu mốc nhỏ trong trò chơi.
              - Beneficial Objectives : ăn vàng hoặc hoàn thành nhiệm vụ, thử thách để có các vật phẩm giúp ích cho quá trình chơi.
              - Challenge Objectives : những thứ khó hoàn thành trong trò chơi. 

* Kẻ thù trong game được thiết kế trong file EnemyCOntrollers.cs.
 - Một số đặc tính của kẻ thù:
   - Không bị ảnh hưởng bởi thanh chắn như nhân vật.
   - Sẽ đi theo và nhại theo hoạt ảnh nhảy của nhân vật.
   - Sử dụng hàm update để xử lí khi người chơi tạo ra các sự kiện:
     - Khi khởi đầu game từ màn hình menu sẽ có trạng thái nghỉ(idle) và hiện hoạt ảnh tuy nhiên camera chính không chiếu vào nên người chơi sẽ không thấy. khi ấn nút start kẻ thù sẽ mặc định tiến gần tới nhân vật(gọi hàm MoveNearFarFollow)
     - Sẽ chạy chậm hơn nhân vật một khoảng và sau khi chạy một thời gian mà người chơi không vấp phải các chướng ngại nhỏ hay bị va đập với tường khi người chơi cố tình hay vô ý lướt quá sang trái hay phải khi đừng cạnh rìa, sẽ lùi xa một khoảng(gọi đến hàm RunMoveNearFarFollow) và rơi vào trạng thái nghỉ(idle) và ẩn hoạt ảnh.
     - Khi người chơi bị vấp phải các chướng ngại nhỏ sẽ tiến gần vào nhân vật(gọi đến hàm MoveNearFarFollow) và nếu người chơi vấp tiếp vào các chướng ngại nhỏ thì người chơi sẽ thua, sẽ có thêm hoạt ảnh "attack" bắt nhân vật.

* Mua vật phẩm trong ShopItem
    - Buy Item
        + Buy Coin:

        + Buy Key:
        
        + Buy Single use:
            Đối với ItemSkis, ItemHeadStart, ItemScoreBooster: Gán file BuyItemController.cs truyền vào codeItem: 2.ItemSkis, 4.ItemHeadStart,5.ItemScoreBooster

                textTotal trong BuyItemController.cs Là số lượng item đang có

                Tạo 1 text Total truyền vào là textTotal để in ra màn hình số lượng item đang có

                *Button Buy Item:
                    Tạo Text Value nhâp vào là giá tiền của item

                    Tạo Text Note là infoBuy của item

                    ButDown:
                        Gán file ButtonDownItem.cs và truyền vào kích thước, thời gian show ra vùng infoBuy và ButBuy 
                        Tạo Button gọi hàm ButtonDownItem.ButtonClick(): Nếu click vào button sẽ show ra infoBuy và ButBuy của item 

                    ButBuy: 
                        Gán file ButtonBuyItem.cs và truyền vào 
                            codeItem: 2.ItemSkis, 4.ItemHeadStart, 5.ItemScoreBooster
                            textCost: Value (giá tiền)
                            textNote: Total (số lượng item đã có)
                            textCoin: NumCoin (Tổng số lượng coin hiện có)

                        Tạo Button gọi hàm ButtonBuyItem.ButtonClick(): 
                            Nếu đủ tiền mua: 
                                Nếu số lượng item hiện tại < số lượng item tối đa(Trong Modules.cs: maxHoverboard = 9999; maxHeadstart = 10; maxScorebooster = 7;)
                                    Số lượng item hiện có + 1
                                    Trừ số coin hiện tại bằng textCost
                                Nếu số lượng item hiện tại > số lượng item tối đa
                                    textNote.text = AllLanguages.shopMaxNumber[Modules.indexLanguage] để in ra thông báo lỗi maximumNumber với ngôn ngữ đã thiết lập
                            Nếu không đủ tiền 
                                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage] để in ra lỗi không đủ tiền với các ngôn ngữ

            Đối với ItemMysteryBox: Gán file BuyItemController.cs truyền vào codeItem: 3.ItemMysteryBox

                textTotal trong BuyItemController.cs: textTotal.text = AllLanguages.shopUseRight[iLang] là thông báo sử dụng ngay sau khi mua với các ngôn ngữ

                Tạo 1 text Total truyền vào là textTotal để in ra màn hình thông báo sử dụng ngay sau khi mua

                *Button Buy ItemMysteryBox:
                    Tạo Text Value nhâp vào là giá tiền của item
                    Tạo Text Note là infoBuy của item

                    ButDown:
                        Gán file ButtonDownItem.cs và truyền vào kích thước, thời gian show ra vùng infoBuy và ButBuy 
                        Tạo Button gọi hàm ButtonDownItem.ButtonClick(): Nếu click vào button sẽ show ra infoBuy và ButBuy của item 

                    ButBuy: 
                        Gán file ButtonBuyItem.cs và truyền vào 
                            codeItem: 3.ItemMysteryBox
                            textCost: Value (giá tiền)
                            textNote: Total (thông báo sử dụng ngay sau khi mua)
                            textCoin: NumCoin (Tổng số lượng coin hiện có)
                        Tạo Button gọi hàm ButtonBuyItem.ButtonClick(): 
                            Nếu đủ tiền mua: 
                                Trừ số coin hiện tại bằng textCost
                                Mở ItemMysteryBox trong phần ContainOpenBox
                            Nếu không đủ tiền 
                                textNote.text = AllLanguages.shopNotEnough[Modules.indexLanguage] để in ra lỗi không đủ tiền với các ngôn ngữ

    - Upgrade item: Tăng thời gian sử dụng item
        + Đối với ItemJetpack, ItemSuperSneakers, ItemCoinMagnet, Item2XMultiplier, ItemCable, ItemHoverBoard: 
            Gán file UpgradesController.cs và truyền vào codeItem: 0.ItemJetpack, 1.ItemSuperSneakers, 2.ItemCoinMagnet, 3.Item2XMultiplier, 4.ItemCable, 5.ItemHoverBoard

        + Button Buy Item:
            Tạo Text Value truyền vào là textCost trong UpgradesController.cs là giá tiền để upgrade item:
            Đối với ItemJetpack:
                money = 250 * Mathf.Pow(2, (Modules.levelUpgradeRocket + 1));
                    (string dataLevelRocket = SaveLoadData.LoadData("SaveLevelRocket", true);
                    if (dataLevelRocket == "") dataLevelRocket = "0";// Nếu là lần đầu upgrade
                    levelUpgradeRocket = IntParseFast(dataLevelRocket);)
            Tương tự với levelUpgradePower, levelUpgradeMagnet, levelUpgradeXPoint , levelUpgradeCable , levelUpgradeSkis đối với ItemSuperSneakers, ItemCoinMagnet, Item2XMultiplier, ItemCable, ItemHoverBoard

            Tạo Text Note là infoBuy của item

            Tạo Image Level truyền vào là progressBox trong UpgradesController.cs để biểu diễn Lever của item bằng hình ảnh
                    
            ButDown:
                Gán file ButtonDownItem.cs và truyền vào kích thước, thời gian show ra vùng infoBuy và ButBuy 
                Tạo Button gọi hàm ButtonDownItem.ButtonClick(): Nếu click vào button sẽ show ra infoBuy và ButBuy của item 

            ButBuy: 
                Gán file ButtonUpgradesItem.cs và truyền vào 
                    codeItem: 0.ItemJetpack, 1.ItemSuperSneakers, 2.ItemCoinMagnet, 3.Item2XMultiplier, 4.ItemCable, 5.ItemHoverBoard
                    progressBox: Lever (lever hiện tại của item)
                    textCost: Value (giá tiền)
                    textCoin: NumCoin (Tổng số lượng coin hiện có)

                Tạo Button gọi hàm ButtonUpgradesItem.ButtonClick(): 
                    Nếu đủ tiền mua: 
                        Nếu Lever item hiện tại < max LevelItem(Trong Modules.cs: maxLevelItem = 10)
                            Lever item +1
                            Trừ số coin hiện tại bằng textCost
                            UpgradesControllerLoadDataNow(): Load lại data để cập nhật Lever của item bằng hình ảnh 
                            return new Vector2(timeUseRocket.x + timeAddPerLevel * levelUpgradeRocket, timeUseRocket.y + timeAddPerLevel * levelUpgradeRocket): tăng thời gian sử dụng item timeAddPerLevel = 3f
                        Nếu Lever item hiện tại < max LevelItem
                            ShowError(AllLanguages.shopMaxLevel[Modules.indexLanguage]) để in ra thông báo lỗi shopMaxLevel với ngôn ngữ đã thiết lập
                    Nếu không đủ tiền 
                        ShowError(AllLanguages.shopNotEnough[Modules.indexLanguage]) để in ra lỗi không đủ tiền với các ngôn ngữ

* Mua Hero và Skis trong HeroConstruct
    - BuyHero:
        + Thay đổi hình ảnh miêu tả Hero trong InfoObjectSelected: 
            Trong ListObjectSelect tạo các ItemTempHero gán file ChangeImageClick.cs truyền vào codeObject ứng với id của các Hero

            Trong ItemTempHero tạo Button gọi hàm ChangeImageClick.ButtonClick(string nameFunction) với nameFunction truyền vào là ButtonHeroClick( trong PageConstructHero.ButtonHeroClick(string codeHero) với codeHero truyền vào là codeObject ) 

            Nếu click vào vùng ItemTempHero sẽ gọi hàm ChangeImageClick.ButtonClick(): InfoObjectSelected sẽ thay đổi thành hình ảnh Hero ứng với codeHero ở vùng ItemTempHero
                codeHeroChoose trong PageConstructHero.cs ở MainCamera sẽ có giá trị là codeObject ứng với id của các Hero
                Text trong InfoText sẽ thay đổi theo textNoteHero (trong PageConstructHero.cs ở MainCamera textNoteHero.text = AllLanguages.heroInfoHero[heroNow.noteHero][Modules.indexLanguage] sẽ có giá trị là heroInfoHero ứng với id của các Hero) để in ra thông tin của Hero

        + Button Buy Hero
            ButtonBuy tạo Button gọi hàm PageConstructHero.ButtonCoinHeroClick()

            Tạo Text là giá tiền của Hero

            Trong MainCamera file PageConstructHero.cs truyền vào textValueHero.text là Text

            Nếu Hero chưa unlock
                Nếu đủ tiền mua thì mua hero: 
                    Trừ số tiền hiện tại bằng textValueHero
                    textValueHero.text = AllLanguages.heroSelected[Modules.indexLanguage] đặt textValueHero.text thành heroSelected với ngôn ngữ thiết lập
                    Thêm Hero đã mua vào list các Hero đã unlock
                    Click heroSelected đặt nhân vật sử dụng codeHeroUse là nhân vật đã chọn codeHeroChoose
                Nếu không đủ tiền thì gọi hàm ShowMessageErrorHero(AllLanguages.heroNotEnough[Modules.indexLanguage]) để in ra lỗi với ngôn ngữ thiết lập 
            Nếu Hero đã unlock: 
                    textValueHero.text thành heroSelected  
                    Click heroSelected đặt nhân vật đã chọn codeHeroChoose thành nhân vật sử dụng codeHeroUse 

    - BuySkis:
        + Thay đổi hình ảnh miêu tả Skis trong InfoObjectSelected: 
            Trong ListObjectSelect tạo các ItemTempSkis gán file ChangeImageClick.cs truyền vào codeObject ứng với id của các Skis

            Trong ItemTempSkis tạo Button gọi hàm ChangeImageClick.ButtonClick(string nameFunction) với nameFunction truyền vào là ButtonSkisClick( trong PageConstructHero.ButtonSkisClick(string codeSkis) với codeSkis truyền vào là codeObject ) 

            Nếu click vào vùng ItemTempSkis sẽ gọi hàm ChangeImageClick.ButtonClick(): InfoObjectSelected sẽ thay đổi thành hình ảnh Skis ứng với codeSkis ở vùng ItemTempSkis
                codeSkisChoose trong PageConstructHero.cs ở MainCamera sẽ có giá trị là codeObject ứng với id của các Skis
                Text trong InfoText sẽ thay đổi theo textNoteSkis (trong PageConstructHero.cs ở MainCamera textNoteSkis.text = AllLanguages.heroInfoHoverboard[heroNow.noteHero][Modules.indexLanguage] sẽ có giá trị là heroInfoHoverboard ứng với id của các Hero) để in ra thông tin của Skis

        + Button Buy Skis
            ButtonBuy tạo Button gọi hàm PageConstructHero.ButtonCoinSkisClick()

            Tạo Text là giá tiền của Skis

            Trong MainCamera file PageConstructHero.cs truyền vào textValueSkis.text là Text

            Nếu Skis chưa unlock
                Nếu đủ tiền mua thì mua Skis: 
                    Trừ số tiền hiện tại bằng textValueSkis
                    textValueSkis.text = AllLanguages.heroSelected[Modules.indexLanguage] đặt textValueSkis.text thành heroSelected với ngôn ngữ thiết lập
                    Thêm Skis đã mua vào list các Hero đã unlock
                    Click heroSelected đặt nhân vật sử dụng codeSkisChoose là nhân vật đã chọn codeSkisUse
                Nếu không đủ tiền thì gọi hàm ShowMessageErrorHero(AllLanguages.heroNotEnough[Modules.indexLanguage]) để in ra lỗi với ngôn ngữ thiết lập 
            Nếu Skis đã unlock: 
                    textValueSkis.text thành heroSelected  
                    Click heroSelected đặt Skis đã chọn codeSkisChoose thành Skis sử dụng codeSkisUse  

