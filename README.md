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
 Scene LoadData: Khi vào game sẽ hiển thị một màn hình chờ để khởi tạo tài nguyên game. Màn hình chờ được thiết kế bằng đồ hoạ 2D nằm trong canvas. Các tài nguyên, script được load trong scene ListResource, Poolterrain, Poolother.
  - Poolterrain gồm các đối tượng khung cảnh, môi trường trong game như cây cối, toà nhà, đường phố,... mà nhân vật chạy.
  - Poolother gồm các coin mà nhân vật nhặt được.
  - ListResource gồm 
  Các lớp trên thực chất là khởi tạo các đối tượng cần sử dụng nên rất tốn thời gian và tài nguyên. Chúng đều có Dontdestroyonload(mội phương thức của class Objects trong unity giúp các đối tượng không bị loại bỏ khi tải scene) để tiếp tục sử dụng trong scene gameplay.
  Chỉ có PoolOtther là không khởi tạo tài nguyên vì đây là lớp chỉ chứa coin và vật phẩm ăn được, sẽ được khởi tạo khi ăn trong game sau.
  image.png
  image.png
  image.png
* Ui trong unity được thiết kế bằng canvas. Mọi unity thì đều nằm trong lớp canvas và unity hỗ trợ rất tốt Ui bằng nhiều chức năng, lựa chọn thiết kế cho người dùng. Trong game có một vài Ui quan trọng như màn hình loadgame(đã nói ở trên), màn hình menu trong scene maingame(FormGameMenu), FormGameplay, FormGameMenu, ContainAchievement, ContainShopItem, ...
* Ui FormGameMenu: Menu hiện thị tất cả các feature của game. Người chơi có thể lựa chọn nhân vật, mua item trong shop, kiểm tra nhiệm vụ, chỉnh sửa một số cài đặt game,...
image.png
* Ui FormGamePlay: Một Ui hiển thị trong màn hình chơi game. Ui này hiển thị vật phẩm có thể dùng, số vàng kiểm được, số điểm hiện tại, phím dừng game, ...
<<<<<<< HEAD
image.png
* Ui ContainAchievement: Hiển thị bảng điểm sau khi thua bao gổm điểm số chơi được, vàng kiếm được,... và một hoạt ảnh nhân vật thua game. Tuy nhiên do đã bỏ phần facebook và chplay cùng một số tính năng thưởng khác liên quan đến quảng cáo nên phần này chỉ đơn giản là xử lí điểm số và nhân vật.
image.png
 Nếu nhân vật chết hay trạng thái showScorePlay thì tạo một clone nhân vật. Clone này không có rigid body với model là arrested để hiện thị trạng thái thua game.
 Nếu được mở ở màn hình menu thì chuyển animation nhân vật sang idleMenu và hiển thị điểm số cao nhất của người chơi.
 Nếu ấn play thì tạo trận chơi mới.
 image.png
=======
>>>>>>> e2fbfea1ee0b6249db1ef536aaaea90a2c0a6539
* Kẻ thù trong game được thiết kế trong file EnemyCOntrollers.cs.
 - Một số đặc tính của kẻ thù:
   - Không bị ảnh hưởng bởi thanh chắn như nhân vật.
   - Sẽ đi theo và nhại theo hoạt ảnh nhảy của nhân vật.
   image.png
   - Sử dụng hàm update để xử lí khi người chơi tạo ra các sự kiện:
     - Khi khởi đầu game từ màn hình menu sẽ có trạng thái nghỉ(idle) và hiện hoạt ảnh tuy nhiên camera chính không chiếu vào nên người chơi sẽ không thấy. khi ấn nút start kẻ thù sẽ mặc định tiến gần tới nhân vật(gọi hàm MoveNearFarFollow)
     - Sẽ chạy chậm hơn nhân vật một khoảng và sau khi chạy một thời gian mà người chơi không vấp phải các chướng ngại nhỏ hay bị va đập với tường khi người chơi cố tình hay vô ý lướt quá sang trái hay phải khi đừng cạnh rìa, sẽ lùi xa một khoảng(gọi đến hàm RunMoveNearFarFollow) và rơi vào trạng thái nghỉ(idle) và ẩn hoạt ảnh.
     - Khi người chơi bị vấp phải các chướng ngại nhỏ sẽ tiến gần vào nhân vật(gọi đến hàm MoveNearFarFollow) và nếu người chơi vấp tiếp vào các chướng ngại nhỏ thì người chơi sẽ thua, sẽ có thêm hoạt ảnh "attack" bắt nhân vật.
     image.png

* Mua vật phẩm và nâng cấp item trong ShopItem: class PageShopItems.cs

    - Mua vật phẩm: 
        + Mua Coin:
       ![image](https://user-images.githubusercontent.com/117577336/219059497-290d418a-aabc-460f-ab02-99186f64261c.png)

        + Mua Keys:
        ![image](https://user-images.githubusercontent.com/117577336/219059581-39159a06-1210-4996-ac6c-d9d435ae7f67.png)

        + Mua vật phẩm sử dụng 1 lần:
        ![image](https://user-images.githubusercontent.com/117577336/219059704-f87d0586-0782-4448-b261-85b1ff370e01.png)


            Class BuyItemController.cs: để lấy ra số lượng item đang có rồi gán số lượng ra Text Total để hiển thị cho người dùng số lượng item đang có bằng các ngôn ngữ khác nhau. Code item là: 0 coin, 1 key, 2 skis, 3 mysteryBox, 4 headStart, 5 scoreBooster
            ![image](https://user-images.githubusercontent.com/117577336/219060192-9a1e4531-a7f6-41c3-9602-2fd459e7ffa1.png)
            ![image](https://user-images.githubusercontent.com/117577336/219060344-62cd37b1-44a4-4981-9800-70e50fae81d3.png)

            Class ButtonBuyItem.cs: Xử lý mua vật phẩm khi click mua. 
                Code item là: 0 coin, 1 key, 2 skis, 3 mysteryBox, 4 headStart, 5 scoreBooster.
                ![image](https://user-images.githubusercontent.com/117577336/219060652-081a8f5c-310d-4b3d-8353-8ff6e7ebd2dc.png)

                Biến textCost: lấy giá tiền của vật phẩm được tạo ở giao diện để thực hiện mua item, 
                ![image](https://user-images.githubusercontent.com/117577336/219060901-3cf00b45-a14d-44ed-a6d9-469daebd7754.png)

                biến textNote: để trả lại số lượng vật phẩm sau khi mua, 
                ![image](https://user-images.githubusercontent.com/117577336/219060990-777d7038-6927-4369-8ad1-3e7aa962cb84.png)

                biến textCoin: để trả lại số lượng coin còn lại sau khi mua.
                ![image](https://user-images.githubusercontent.com/117577336/219061112-c3d3f5c1-37f0-4dfa-b63c-8c3d8dbfdaa5.png)

                Nếu Code item là: 0 coin, 1 key thì xử lý trong app purchase
                
                Nếu Code item là: 2 skis, 4 headStart, 5 scoreBooster: 
                ![image](https://user-images.githubusercontent.com/117577336/219061363-a2580a11-7b14-4ebb-80dc-8897653b7650.png)

                    Nếu số tiền hiện tại > giá tiền vật phẩm
                        Nếu số lượng item hiện tại < số lượng item tối đa(Trong Modules.cs: maxHoverboard = 9999; maxHeadstart = 10; maxScorebooster = 7;)
                            Số lượng item hiện có + 1
                            Trừ số coin hiện tại bằng textCost và trả lại giá trị coin hiện tại là textCoin
                            Trả lại số lượng item hiện có textNote
                        Nếu số lượng item hiện tại = số lượng item tối đa
                            textNote in ra thông báo lỗi maximumNumber 
                    Nếu không đủ tiền 
                        textNote in ra thông báo lỗi không đủ tiền
                Nếu Code item là: 3 mysteryBox
                ![image](https://user-images.githubusercontent.com/117577336/219061450-ea175dec-dda6-4ca5-9c28-5378c28d8195.png)

                    Nếu số tiền hiện tại > giá tiền vật phẩm
                        Trừ số coin hiện tại bằng textCost và trả lại giá trị coin hiện tại là textCoin
                        Di chuyển đến PageOpenBox hoạt ảnh mở hộp   
                    Nếu không đủ tiền 
                        textNote in ra thông báo lỗi không đủ tiền
            ![image](https://user-images.githubusercontent.com/117577336/219061352-e47c83c3-f03b-47d2-9984-e4a7c37dd991.png)

    - Nâng cấp item (Tăng thời gian sử dụng item): 

            Class UpgradesController.cs: để tính giá tiền để nâng cấp item của mỗi level rồi in ra textCost. Code item là: 0 rocket, 1 power, 2 magnet, 3 2x, 4 cable, 5 skis. 
            ![image](https://user-images.githubusercontent.com/117577336/219061740-ad1f79aa-95c9-4b4a-9e3e-f061d68344fb.png)
![image](https://user-images.githubusercontent.com/117577336/219061853-01d1eb0e-f0f6-4f77-85c3-8dd6c70dc92f.png)

                Giá tiền được tính bằng: money = 250 * Mathf.Pow(2, (level item + 1))
                Nếu giá tiền hiện tại > 256000 thì giá tiền = 256000

            Class ButtonUpgradesItem.cs: Xử lý mua vật phẩm khi click mua. 
                Code item là: 0 rocket, 1 power, 2 magnet, 3 2x, 4 cable, 5 skis
                ![image](https://user-images.githubusercontent.com/117577336/219062013-fb8b4827-7a27-4c5a-ae71-d819db14ebef.png)

                Biến progressBox: để hiển thị hình ảnh thanh level của item, biến textCost: lấy giá tiền của vật phẩm được tạo ở giao diện để thực hiện mua nâng cấp,
                ![image](https://user-images.githubusercontent.com/117577336/219062721-b64bebdc-edf8-4f91-ba20-3ea2157bc532.png)

                biến textNote: in ra thông báo nếu lỗi, 
                ![image](https://user-images.githubusercontent.com/117577336/219062872-826d152a-90d8-4e99-8369-a710b90877b9.png)

                biến textCoin: để trả lại số lượng coin còn lại sau khi mua.
                ![image](https://user-images.githubusercontent.com/117577336/219062954-6e54d9a1-dcc2-4a13-80fc-3915f5ebbb32.png)

                    Nếu số tiền hiện tại > giá tiền nâng cấp
                        Nếu level item hiện tại < level item item tối đa(Trong Modules.cs: maxLevelItem = 10)
                            Tăng level item lên 1
                            Trừ số coin hiện tại bằng textCost và trả lại giá trị coin hiện tại là textCoin
                            Update lại giá tiền nâng cấp item trong UpgradesController.cs
                        Nếu level item hiện tại = level item item tối đa
                            textNote in ra thông báo lỗi shopMaxLevel 
                    Nếu không đủ tiền 
                        textNote in ra thông báo lỗi không đủ tiền
                        ![image](https://user-images.githubusercontent.com/117577336/219063251-75832f40-e1bd-4517-9eab-cf1f66587887.png)

                

* Mua Hero và Skis:
    - Class ListCharacterUse.cs: danh sách các nhân vật và ván trượt trước khi load game
    - Class ChangeImageClick.cs: Hiệu ứng chiễu đền và tạo ra các clone khi click vào nhân vật trong List nhân vật 
    - Class HeroConstruct.cs: Tạo thanh cuộn danh sách các nhân vật và ván trượt tuần tự để người chơi chọn. 
        Phương thức ButtonCoinHeroClick() để mua nhân vật: 
            Nếu nhân vật được chọn chưa unlock:
                Nếu số tiền hiện tại > giá tiền mua nhân vật
                    Trừ số coin hiện tại bằng giá tiền nhân vật và trả lại giá trị coin hiện tại là textCoin
                    Text giá tiền chuyển thành SELECTED
                    Thêm nhân vật vào danh sách nhan vật đã unlock
                    Nhân vật sử dụng hiện tại chuyển thành nhân vật đã chọn
                Nếu không đủ tiền 
                    In ra thông báo lỗi không đủ tiền
            Nếu nhân vật được chọn đã unlock:
                Text giá tiền chuyển thành SELECTED  
                Nhân vật sử dụng hiện tại chuyển thành nhân vật đã chọn

        Phương thức ButtonCoinSkisClick() để mua ván trượt: 
            Nếu ván trượt được chọn chưa unlock:
                Nếu số tiền hiện tại > giá tiền mua ván trượt
                    Trừ số coin hiện tại bằng giá tiền ván trượt và trả lại giá trị coin hiện tại là textCoin
                    Text giá tiền chuyển thành SELECTED
                    Thêm ván trượt vào danh sách ván trượt đã unlock
                    Ván trượt sử dụng hiện tại chuyển thành ván trượt đã chọn
                Nếu không đủ tiền 
                    In ra thông báo lỗi không đủ tiền
            Nếu ván trượt được chọn đã unlock:
                Text giá tiền chuyển thành SELECTED  
                Ván trượt sử dụng hiện tại chuyển thành ván trượt đã chọn
        
            


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
            Set Model sử dụng giày trên nhân vật
        + Sử dụng giày thành true
        + Thêm bảng hiển thị thời gian sử dụng item
        
    - Nếu là headStart
        + Tăng headStart thêm 1
            Nếu tổng số headStart hiện tại > maxHeadstart = 10
                số headStart hiện tại = maxHeadstart = 10;
    
    - Nếu là mysteryBox
        + Tăng mysteryBox thêm 1
        
    - Nếu là nam châm
        + Nếu chưa sử dụng nam châm 
            thêm model sử dụng nam châm trên nhân vật
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
        + Thêm bảng hiển thị thời gian sử dụng item
            
    - Nếu là rocket
        + Nếu chưa sử dụng rocket 
            thêm model sử dụng rocket trên nhân vật
        + Khoảng cách với Enemy = 2 
        + Sử dụng rocket thành true  
        + Thêm bảng hiển thị thời gian sử dụng item   
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
        + Sử dụng jumper thành true  
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
    ![image](https://user-images.githubusercontent.com/30952488/219052724-bce1c8ed-38d5-4931-bf7f-ce013d30a3b9.png)
    - Lớp MessageSetting.cs gọi hàm StartShowMessage() để hiện ra bảng setting.
    ![image](https://user-images.githubusercontent.com/30952488/219054450-e6ea9bad-27dd-4841-8d14-26b366744b54.png)
    ![image](https://user-images.githubusercontent.com/30952488/219052940-a64258c3-d29f-4be9-9e03-9d2727e831d0.png)
    - Bật tắt nhạc nền: 
        + ButtonVolumeBGClick() được gọi khi ta ấn vào nút:
            Thay đổi giá trị volumeBackground từ 0 thành 1 hoặc từ 1 thành 0 tùy thuộc vào giá trị ban đầu. Song song đó là đổi chữ "On" thành "Off" hoặc "Off" thành "On"
            Sau đó, vẫn cho chơi nhạc bằng hàm PlayAudioLoop() nhưng tùy vào vomlumeBackground mà ta sẽ nghe thấy nhạc hoặc không. Và lưu lại cài đặt bằng SaveSettingValue()
            ![image](https://user-images.githubusercontent.com/30952488/219053102-cd1b0b10-4a52-412e-acdb-397229a650c7.png)
    - Bật tắt âm thanh khi nhấn nút :
        + ButtonVolumeATClick() được gọi khi ta ấn nút: 
            Tương tự như bật tắt nhạc nền nhưng ko cho chơi nhạc bằng hàm PlayAudioLoop().
            ![image](https://user-images.githubusercontent.com/30952488/219053229-55d6a384-9344-4435-be10-6ceaa4dc166f.png)
    - Điều chỉnh mức độ các hiệu ứng:
        + ButtonReducedEffect() được gọi khi ta ấn nút:   
            Thay đổi giá trị reducedEffect từ 2 thành 1 hoặc 1 thành 0 hoặc 0 thành 2 và đổi giá trị text tương ứng High->Medium,Medium->Low,Low->High. Lưu lại cài đặt bằng SaveSettingValue().
            ![image](https://user-images.githubusercontent.com/30952488/219053285-c24fc108-f41d-417d-8a54-4965243a72d4.png)
    - Điều chỉnh độ nhạy:
        + SliderSensivity() được gọi khi ta di chuyển thanh:
            gọi hàm UpdateValueSensivity() trong lớp Modules để chỉnh độ nhạy. Và lưu lại cài đặt bằng hàm SaveSettingValue().
            ![image](https://user-images.githubusercontent.com/30952488/219053348-2e152148-945f-41de-8579-40489b6da56e.png)
    - Thoát game: 
        + gọi đến hàm ButtonQuitGame() khi ta nhấn nút "Quit Game":
            thoát khỏi ứng dụng bằng lệnh Application.Quit().
            ![image](https://user-images.githubusercontent.com/30952488/219053431-266ce639-ad53-4985-95c5-8eb566a01ff7.png)

* Đổi ngôn ngữ : 
    - Khi nhấn nút thì lớp MessageListLanguage sẽ gọi hàm StartShowMessage() để hiện lên bảng thông báo các ngôn ngữ có thể đổi và cờ của các nước như là nút ấn.
    ![image](https://user-images.githubusercontent.com/30952488/219054234-ce42beb7-9d4a-40ea-86da-91ba1b628b79.png)
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
            
        + Xử lý va chạm với vật cản đẩy lại:(Nếu đang ở bên trái rồi đi sang trái, Nếu đang ở bên phải rồi đi sang phải)
            ColliderObjectSlowSpeed():
                Khoảng cách enemy -1
                Nếu khoảng cách enemy = 0 -> bị tóm
                    Nếu đang sử dụng skis
                        Khoảng cách enemy = 2;
                        Trạng thái hero chuyển thành run;
                    Nếu không sử dụng skis
                        Bị chết do cảnh sát tóm
                Nếu khoảng cách enemy > 0
                    Nếu đang không sử dụng Jumper, Rocket, Cable
                        tốc độ nhân vật chậm lại

    - Xử lý va chạm vật cản (typeCollider == TypeCollider.slower)
        + gọi hàm ColliderObjectSlowSpeed():
            Khoảng cách enemy -1
            Nếu khoảng cách enemy = 0 -> bị tóm
                Nếu đang sử dụng skis
                    Khoảng cách enemy = 2;
                    Trạng thái hero chuyển thành run;
                Nếu không sử dụng skis
                    Bị chết do cảnh sát tóm 
            Nếu khoảng cách enemy > 0
                Nếu đang không sử dụng Jumper, Rocket, Cable
                    tốc độ nhân vật chậm lại

Link tải apk Android: https://drive.google.com/file/d/1pHjMz8gmM3LNHegzYs5j80MoUA-kFskM/view?usp=share_link
