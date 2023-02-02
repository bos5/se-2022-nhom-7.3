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

* Game có hai scene chính:
 - LoadData: load game, khởi tạo các tài nguyên cần thiết,...
 - Gameplay: xử lý game play, cơ chế đồ hoạ, nhiệm vụ,...
 Scene LoadData: Khi vào game sẽ hiển thị một màn hình chờ để khởi tạo tài nguyên game. Màn hình chờ được thiết kế bằng đồ hoạ 2D nằm trong canvas. Các tài nguyên, script được load trong scene ListResource, Poolterrain, Poolother
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


* Xử lý nếu va chạm items
    - Nếu là đồng xu
        + Tăng coin thêm 1
        
    - Nếu là key
        + Tăng key thêm 1
        
    - Nếu là skis
        + Tăng skis thêm 1
            Nếu tổng số Skis hiện tại > maxHoverboard = 10
                số Skis hiện tại = maxHoverboard = 10;
    
    - Nếu là giày
        + Nếu chưa sử dụng giày
            thêm hình ảnh giày trái và phải trên Hero
        + Sử dụng giày thành true
        
    - Nếu là headStart
        + Tăng headStart thêm 1
            Nếu tổng số headStart hiện tại > maxHeadstart = 10
                số headStart hiện tại = maxHeadstart = 10;
    
    - Nếu là mysteryBox
        + Tăng mysteryBox thêm 1
        
    - Nếu là nam châm
        + Nếu chưa sử dụng nam châm 
                thêm model sử dụng nam châm trên Hero
        + Sử dụng nam châm thành true 
        + SetAniAddMagnet(): Set các loại di chuyển khi ăn nam châm :
            Nếu đang chạy thường: 
                chuyển kiểu chạy thành runMagnet; 
                chuyển animation thành runMagnet 
            Nếu đang trượt ván: 
                chuyển kiểu chạy thành runSkisMagnet; 
                chuyển animation thành runSkisMagnet
            Nếu đang bay tên lửa: 
                chuyển kiểu chạy thành runRocketMagnet; 
                chuyển animation thành runRocketMagnet
            Nếu đang bay cable: 
                chuyển kiểu chạy thành runCableMagnet; 
                chuyển animation thành runCableMagnet
            
    - Nếu là rocket
        + Nếu chưa sử dụng rocket 
                thêm model sử dụng rocket trên Hero
        + Khoảng cách với Enemy = 2 
        + Sử dụng rocket thành true     
        + Kích hoạt hiệu ứng của item bay trên không;
        + SetAniAddRocket(): 
            Nếu đang sử dụng cable
                Sử dụng Cable = false;
                Remove model sử dụng cable 
            Nếu đang jumper
                Sử dụng Jumper = false;
            Nếu đang sử dụng nam châm
                chuyển kiểu chạy thành runRocketMagnet;
                chuyển animation thành runRocketMagnet
            Những trường hợp còn lại: 
                chuyển kiểu chạy thành runRocket;
                chuyển animation thành runRocket
        + JumpHero(): bật nhảy

    - Nếu là jumper
        + Khoảng cách với Enemy = 2 
        + Sử dụng rocket thành true  
        + Kích hoạt hiệu ứng của item bay trên không;
        + SetAniAddJumper(): 
            Remove Progress sử dụng jetpack
            Remove Progress sử dụng hoverbike
            Ẩn đối tượng Skis khi sử dụng item jumper
            Nếu đang sử dụng cable
                RemoveCableItem(false)
            Nếu đang sử dụng cable
                RemoveJumperItem(false);
            Những trường hợp còn lại: 
                chuyển kiểu chạy thành runJumper;
                chuyển animation thành runJumper
        + JumpHero(): bật nhảy

    - Nếu là cable
        + Nếu chưa sử dụng cable 
            thêm model sử dụng cable trên Hero
        + Khoảng cách với Enemy = 2 
            Sử dụng Cable = true;
        + Kích hoạt hiệu ứng của item bay trên không;
        + SetAniAddCable()  
            Remove Progress của item jetpack
            Ẩn đối tượng Skis khi sử dụng item cable
            Nếu đang sử dụng rocket 
                Sử dụng Rocket = false;
                Remove Model sử dụng Rocket
            Nếu đang sử dụng jumper
                Sử dụng Jumper = false;
            Nếu đang sử dụng nam châm
                chuyển kiểu chạy thành runCableMagnet;
                chuyển animation thành runCableMagnet
            Những trường hợp còn lại: 
                chuyển kiểu chạy thành runCable;
                chuyển animation thành runCable
            }

        + JumpHero(): bật nhảy

    - Nếu là balloon
        + Remove hiệu ứng item bay
        + Thiết lập lại trang thái:
                không di chuyển sang trái phải
                Hero thực hiện jump
                doneBackHero = true;
        + Khoảng cách với Enemy = 2 
        + SetAniAddBalloon():
            Remove Progress của item jetpack
            Remove Progress của item hoverbike
            Ẩn đối tượng Skis khi sử dụng item Skis
            Nếu đang sử dụng cable
                Sử dụng Cable = false;
                Remove Model sử dụng Cable
            Nếu đang sử dụng rocket 
                Sử dụng Rocket = false;
                Remove Model sử dụng Rocket
            Nếu đang sử dụng jumper
                Sử dụng Jumper = false;
        + Điều chỉnh camera đi theo khi bay 
        + SetAniAfterFall(): sau khi tiếp đất 
            Nếu đang sử dụng skis
                Nếu đang sử dụng nam châm
                    chuyển kiểu chạy thành runSkisMagnet;
                Nếu không sử dụng nam châm
                    chuyển kiểu chạy thành runSkis;
            Những trường hợp còn lại: 
                Nếu đang sử dụng nam châm
                    chuyển kiểu chạy thành runMagnet;
                Nếu không sử dụng nam châm
                    chuyển kiểu chạy thành runNormal;     
        + Hủy bỏ sử dụng Animation sử dụng balloon 
        + Điều chỉnh camera đi theo
        + Reset lại toàn bộ item trên map    
    
    - Nếu là scoreBooster
        + số ScoreBooster hiện tại +1
        + Nếu số ScoreBooster hiện tại > maxScorebooster = 7
            thì số ScoreBooster hiện tại  = maxScorebooster = 7

*  Bật/tắt nhạc nền, âm thanh; điều chỉnh độ nhạy, mức độ các hiệu ứng; thoát game:
    - Trong các lớp xử lý công việc liên quan đến âm thanh, thường có hàm PlayAudioClipFree() để xử lý dãn cách âm thanh, ko cho âm thanh chạy quá sát.
    - Lớp MessageSetting.cs gọi hàm StartShowMessage() để hiện ra bảng setting.
    - Bật tắt nhạc nền: 
        + ButtonVolumeBGClick() được gọi khi ta ấn vào nút:
            Thay đổi giá trị volumeBackground từ 0 thành 1 hoặc từ 1 thành 0 tùy thuộc vào giá trị ban đầu. Song song đó là đổi chữ "On" thành "Off" hoặc "Off" thành "On"
            Sau đó, vẫn cho chơi nhạc bằng hàm PlayAudioLoop() nhưng tùy vào vomlumeBackground mà ta sẽ nghe thấy nhạc hoặc không. Và lưu lại cài đặt bằng SaveSettingValue().
    - Bật tắt âm thanh khi nhấn nút :
        + ButtonVolumeATClick() được gọi khi ta ấn nút: 
            Tương tự như bật tắt nhạc nền nhưng ko cho chơi nhạc bằng hàm PlayAudioLoop().
    - Điều chỉnh mức độ các hiệu ứng:
        + ButtonReducedEffect() được gọi khi ta ấn nút:   
            Thay đổi giá trị reducedEffect từ 2 thành 1 hoặc 1 thành 0 hoặc 0 thành 2 và đổi giá trị text tương ứng High->Medium,Medium->Low,Low->High. Lưu lại cài đặt bằng SaveSettingValue().
    - Điều chỉnh độ nhạy:
        + SliderSensivity() được gọi khi ta di chuyển thanh:
            gọi hàm UpdateValueSensivity() trong lớp Modules để chỉnh độ nhạy. Và lưu lại cài đặt bằng hàm SaveSettingValue().
    - Thoát game: 
        + gọi đến hàm ButtonQuitGame() khi ta nhấn nút "Quit Game":
            thoát khỏi ứng dụng bằng lệnh Application.Quit().

* Đổi ngôn ngữ : 
    - Khi nhấn nút thì lớp MessageListLanguage sẽ gọi hàm StartShowMessage() để hiện lên bảng thông báo các ngôn ngữ có thể đổi và cờ của các nước như là nút ấn.
    - Nếu muốn thay đổi thì chọn cờ nước tương ứng, khi đó ta sẽ gọi hàm ChangeLanguage() với tham số là số nguyên biểu diễn ngôn ngữ mà ta đã chọn :
            public void ChangeLanguage(int indexLang)
        {
            Modules.indexLanguage = indexLang;
            Modules.SaveSettingValue();  
            settingBox.GetComponent<MessageSetting>().StartShowMessage();
            pauseBox.GetComponent<MessagePauseGame>().UpdateLanguages();
            Camera.main.GetComponent<PageMainGame>().ChangeAllLanguage();
            CloseListLanguage();
        }
    - Đầu tiên, biến chứa ngôn ngữ mặc định trong Modules sẽ được thay bằng ngôn ngữ ta nhập. Sau đó, được lưu lại bằng hàm SaveSettingValue(). Và settingBox sẽ được hiện lên lại với câu lệnh settingBox.GetComponent<MessageSetting>().StartShowMessage() với ngôn ngữ mới. Tiếp đến là hộp thoại pause game khi đang chơi được cập nhật ngôn ngữ mới. Và cuối cùng là các thành phần còn lại (các cửa sổ, các màn hình khác,... ) được cập nhật ngôn ngữ mới.

* Xử lý va chạm
    - Nếu đang sử dụng Jumper, Rocket, Cable: thì không bị va chạm

    - Va chạm với vật cản đằng trước
        + Xử lý nếu có ván trượt thì không chết
            Nếu đang sử dụng skis: Thực hiện xóa tất cả vật cản xung quanh khu vực này này
        + Nếu không sử dụng skis: Bị chết do va chạm với vật cản typeFalling
  
    - Va chạm trái phải
        + Va chạm không bật lại 
            Nếu đang sử dụng skis: Thực hiện xóa tất cả vật cản xung quanh khu vực này này
            Nếu không sử dụng skis: Bị chết do backScene
        + Xử lý va chạm với vật cản đẩy lại
            Nếu đang ở bên trái
                nếu đi sang trái
            Nếu đang ở bên phải
                nếu đi sang trái
            ColliderObjectSlowSpeed():
                Khoảng cách enemy -1
                Nếu khoảng cách enemy = 0 -> bị tóm
                    Nếu đang sử dụng skis
                        Khoảng cách enemy = 2;
                        Trạng thái hero chuyển thành run;
                    Nếu không sử dụng skis
                        Bị chết do policeCatch
                Nếu khoảng cách enemy > 0
                    Nếu đang không sử dụng Jumper, Rocket, Cable
                        tốc độ nhân vật chậm lại

    - Xử lý va chạm vật cản typeCollider == TypeCollider.slower
        + gọi hàm ColliderObjectSlowSpeed():
            Khoảng cách enemy -1
            Nếu khoảng cách enemy = 0 -> bị tóm
                Nếu đang sử dụng skis
                    Khoảng cách enemy = 2;
                    Trạng thái hero chuyển thành run;
                Nếu không sử dụng skis
                    Bị chết do policeCatch
            Nếu khoảng cách enemy > 0
                Nếu đang không sử dụng Jumper, Rocket, Cable
                    tốc độ nhân vật chậm lại

