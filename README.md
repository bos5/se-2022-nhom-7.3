Nhóm 7.3 làm về game unity subway surfers

* Game features:
    -   Game này là phỏng theo subway surfers, đóng vai 1 nhân vật di chuyển liên tục trên đường thẳng theo 1 trong 3 đường ray và cố gắng né tránh các chướng ngại vật để đạt điểm cao, đồng thời nhặt vàng và các vật phẩm giúp ích.
    -   Bảng xếp hạng người chơi điểm cao.
    -   Cửa hàng để mua vật phẩm (key, coin, ....) và mua các nhân vật khác.
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
  - ListResource gồm nhân vật, audio,kẻ thù.
  Các lớp trên thực chất là khởi tạo các đối tượng cần sử dụng nên rất tốn thời gian và tài nguyên. Chúng đều có Dontdestroyonload(mội phương thức của class Objects trong unity giúp các đối tượng không bị loại bỏ khi tải scene) để tiếp tục sử dụng trong scene gameplay.
  ![image](https://user-images.githubusercontent.com/91232320/219077884-4ebaf451-8526-4ad0-8f8f-2fb2ba7c4dab.png)
  ![image](https://user-images.githubusercontent.com/91232320/219078084-d31c35a5-48a7-4d9e-a9e7-68a4cee02027.png)
  ![image](https://user-images.githubusercontent.com/91232320/219078398-64f23e67-c665-451c-913b-1945e8b8e615.png)

* Ui trong unity được thiết kế bằng canvas. Mọi unity thì đều nằm trong lớp canvas và unity hỗ trợ rất tốt Ui bằng nhiều chức năng, lựa chọn thiết kế cho người dùng. Trong game có một vài Ui quan trọng như màn hình loadgame(đã nói ở trên), màn hình menu trong scene maingame(FormGameMenu), FormGameplay, FormGameMenu, ContainAchievement, ContainShopItem, ...
* Ui FormGameMenu: Menu hiện thị tất cả các feature của game. Người chơi có thể lựa chọn nhân vật, mua item trong shop, kiểm tra nhiệm vụ, chỉnh sửa một số cài đặt game,...
![image](https://user-images.githubusercontent.com/91232320/219078791-4c994307-4651-41d9-9ff1-993cbe5d6405.png)
* Ui FormGamePlay: Một Ui hiển thị trong màn hình chơi game. Ui này hiển thị vật phẩm có thể dùng, số vàng kiểm được, số điểm hiện tại, phím dừng game, ...
![image](https://user-images.githubusercontent.com/91232320/219078940-be9439a4-246d-4d1f-bd15-8f269ed17cfa.png)
* Ui ContainAchievement: Hiển thị bảng điểm sau khi thua bao gổm điểm số chơi được, vàng kiếm được,... và một hoạt ảnh nhân vật thua game. Tuy nhiên do đã bỏ phần facebook và chplay cùng một số tính năng thưởng khác liên quan đến quảng cáo nên phần này chỉ đơn giản là xử lí điểm số và nhân vật.
![image](https://user-images.githubusercontent.com/91232320/219079293-78a69969-39a2-4b9b-8713-0172348b7a4b.png)
 Nếu nhân vật chết hay trạng thái showScorePlay thì tạo một clone nhân vật. Clone này không có rigid body với model là arrested để hiện thị trạng thái thua game.
 Nếu được mở ở màn hình menu thì chuyển animation nhân vật sang idleMenu và hiển thị điểm số cao nhất của người chơi.
 Nếu ấn play thì tạo trận chơi mới.
 ![image](https://user-images.githubusercontent.com/91232320/219079528-3cb11e5f-923d-4c7e-ab80-5145df866b1e.png)

* Kẻ thù trong game được thiết kế trong file EnemyCOntrollers.cs.
 - Một số đặc tính của kẻ thù:
   - Không bị ảnh hưởng bởi thanh chắn như nhân vật.
   - Sẽ đi theo và nhại theo hoạt ảnh nhảy của nhân vật.
   - Sử dụng hàm update để xử lí khi người chơi tạo ra các sự kiện:
     - Khi khởi đầu game từ màn hình menu sẽ có trạng thái nghỉ(idle) và hiện hoạt ảnh tuy nhiên camera chính không chiếu vào nên người chơi sẽ không thấy. khi ấn nút start kẻ thù sẽ mặc định tiến gần tới nhân vật(gọi hàm MoveNearFarFollow)
     - Sẽ chạy chậm hơn nhân vật một khoảng và sau khi chạy một thời gian mà người chơi không vấp phải các chướng ngại nhỏ hay bị va đập với tường khi người chơi cố tình hay vô ý lướt quá sang trái hay phải khi đừng cạnh rìa, sẽ lùi xa một khoảng(gọi đến hàm RunMoveNearFarFollow) và rơi vào trạng thái nghỉ(idle) và ẩn hoạt ảnh.
     - Khi người chơi bị vấp phải các chướng ngại nhỏ sẽ tiến gần vào nhân vật(gọi đến hàm MoveNearFarFollow) và nếu người chơi vấp tiếp vào các chướng ngại nhỏ thì người chơi sẽ thua, sẽ có thêm hoạt ảnh "attack" bắt nhân vật.
    ![image](https://user-images.githubusercontent.com/91232320/219077465-b4835e52-f046-469b-a75d-9f3cc93d0ff0.png)


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
![image](https://user-images.githubusercontent.com/117577336/219064482-1029ee1e-239b-46c6-9f77-02e6b02e53fa.png)

    - Class ListCharacterUse.cs: danh sách các nhân vật và ván trượt trước khi load game
![image](https://user-images.githubusercontent.com/117577336/219064618-40febce4-5a9e-45f6-91e3-5747549f7b76.png)
![image](https://user-images.githubusercontent.com/117577336/219064718-e6e38e17-5592-43d6-b059-ea3f61085b3e.png)

    - Class ChangeImageClick.cs: Hiệu ứng chiễu đền và tạo ra các clone khi click vào nhân vật trong List nhân vật
    ![image](https://user-images.githubusercontent.com/117577336/219065373-76880fa6-5087-4361-9b6c-8b4d43c0a925.png)

    - Class HeroConstruct.cs: Tạo thanh cuộn danh sách các nhân vật và ván trượt tuần tự để người chơi chọn. 
    ![image](https://user-images.githubusercontent.com/117577336/219065497-f8fe6182-789b-477d-b779-fe2be0c9a865.png)

        Phương thức ButtonCoinHeroClick() để mua nhân vật: 
        ![image](https://user-images.githubusercontent.com/117577336/219066005-8728acb5-5ba7-4db9-9f32-3f7475f4d5f8.png)

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
        ![image](https://user-images.githubusercontent.com/117577336/219066056-846240a5-74e6-4293-8453-2fed1fc70ce9.png)

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
     ![image](https://user-images.githubusercontent.com/117577336/219072403-4c60de81-87bb-4e68-9a05-3b2bc7ffa342.png)

    - Nếu là key
        + Tăng key thêm 1
        ![image](https://user-images.githubusercontent.com/117577336/219072686-9e61e2f3-6291-4dbd-8eba-fef0e4a05c2e.png)

        
    - Nếu là skis
    ![image](https://user-images.githubusercontent.com/117577336/219072854-3235a21e-b329-4dba-9bdc-6e211874de41.png)

        + Tăng skis thêm 1
            Nếu tổng số Skis hiện tại > maxHoverboard = 10
                số Skis hiện tại = maxHoverboard = 10;
    
    - Nếu là giày
    - ![image](https://user-images.githubusercontent.com/117577336/219072978-b710fe4f-6094-4cd9-962e-f89a26094c16.png)
        + Nếu chưa sử dụng giày
            Set Model sử dụng giày trên nhân vật
        + Sử dụng giày thành true
        + Thêm bảng hiển thị thời gian sử dụng item
      ![image](https://user-images.githubusercontent.com/117577336/219073325-7a121ffc-3128-4bab-adb3-1ca0f1501a69.png)

        
    - Nếu là headStart
     ![image](https://user-images.githubusercontent.com/117577336/219073474-aad3b0ae-023b-4003-9810-0eab6328ead2.png)
        + Tăng headStart thêm 1
            Nếu tổng số headStart hiện tại > maxHeadstart = 10
                số headStart hiện tại = maxHeadstart = 10;
    
    - Nếu là mysteryBox
     ![image](https://user-images.githubusercontent.com/117577336/219073598-1dd5dd49-612e-40e0-8f3f-d00c45d9a2ad.png)
        + Tăng mysteryBox thêm 1
        
    - Nếu là nam châm
    ![image](https://user-images.githubusercontent.com/117577336/219073914-07f1965c-9457-4693-a268-18d2f5a1eee3.png)

        + Nếu chưa sử dụng nam châm 
            thêm model sử dụng nam châm trên nhân vật
            ![image](https://user-images.githubusercontent.com/117577336/219074221-d8f9e063-49ad-448f-b17f-fbe786aea112.png)
        + Thêm bảng hiển thị thời gian sử dụng item
![image](https://user-images.githubusercontent.com/117577336/219074333-3e06c6a4-d293-429d-bd7e-88a30aaed61e.png)

        + Sử dụng nam châm thành true 
        + SetAniAddMagnet(): Set các loại di chuyển khi ăn nam châm :
            Nếu đang chạy thường: chuyển kiểu chạy thành runMagnet; 
![image](https://user-images.githubusercontent.com/117577336/219074221-d8f9e063-49ad-448f-b17f-fbe786aea112.png)
            Nếu đang trượt ván:  chuyển kiểu chạy thành runSkisMagnet; 
![image](https://user-images.githubusercontent.com/117577336/219075112-7fa9654d-5d72-4cda-9f40-e0b8e1d56a0b.png)
            Nếu đang bay tên lửa:  chuyển kiểu chạy thành runRocketMagnet; 
![image](https://user-images.githubusercontent.com/117577336/219075913-c225499d-514a-4615-8eaa-f4562eaeaffa.png)
            Nếu đang bay cable: chuyển kiểu chạy thành runCableMagnet; 
![image](https://user-images.githubusercontent.com/117577336/219076663-5a2f7410-1c54-43ab-a157-9e28a824ee97.png)

    - Nếu là rocket
        + Nếu chưa sử dụng rocket 
![image](https://user-images.githubusercontent.com/117577336/219076781-3360363a-ed86-4055-97f6-962c8190a866.png)

            thêm model sử dụng rocket trên nhân vật
        + Khoảng cách với Enemy = 2 
        + Sử dụng rocket thành true  
        + Thêm bảng hiển thị thời gian sử dụng item  
![image](https://user-images.githubusercontent.com/117577336/219076820-6b630f18-72d0-49ff-b786-1a1ece84d303.png)
        + Kích hoạt hiệu ứng của item bay trên không;
        + SetAniAddRocket(): 
       Nếu đang sử dụng cable: Sử dụng Cable = false;
       Nếu đang jumper: Sử dụng Jumper = false;
       Nếu đang sử dụng nam châm chuyển kiểu chạy thành runRocketMagnet;
![image](https://user-images.githubusercontent.com/117577336/219075913-c225499d-514a-4615-8eaa-f4562eaeaffa.png)
            Những trường hợp còn lại chuyển kiểu chạy thành runRocket;
![image](https://user-images.githubusercontent.com/117577336/219076781-3360363a-ed86-4055-97f6-962c8190a866.png)
             

    - Nếu là jumper
        + Khoảng cách với Enemy = 2 
        + Sử dụng jumper thành true  
![image](https://user-images.githubusercontent.com/117577336/219084247-bde88b39-dc23-4d94-b3aa-58fb43df0c7e.png)

        + Kích hoạt hiệu ứng của item bay trên không;
        + SetAniAddJumper(): 
            Remove Progress sử dụng jetpack
            Remove Progress sử dụng hoverbike
            Ẩn đối tượng Skis khi sử dụng item jumper
            Nếu đang sử dụng cable
                RemoveCableItem(false)
            Nếu đang sử dụng cable
                RemoveJumperItem(false);
           

    - Nếu là cable
        + Nếu chưa sử dụng cable: thêm model sử dụng cable trên Hero
        + Khoảng cách với Enemy = 2 
            Sử dụng Cable = true;
        + Kích hoạt hiệu ứng của item bay trên không;
  ![image](https://user-images.githubusercontent.com/117577336/219084652-e0438746-2712-4585-a6cd-e85c7f6795b3.png)

        + SetAniAddCable()  
            Remove Progress của item jetpack
            Ẩn đối tượng Skis khi sử dụng item cable
            Nếu đang sử dụng rocket 
                Sử dụng Rocket = false;
            Nếu đang sử dụng jumper
                Sử dụng Jumper = false;
            Nếu đang sử dụng nam châm: chuyển kiểu chạy thành runCableMagnet;
![image](https://user-images.githubusercontent.com/117577336/219085065-b06c2657-31fc-4d46-a382-509d33a1f7b5.png)
            Những trường hợp còn lại:  chuyển kiểu chạy thành runCable;
 ![image](https://user-images.githubusercontent.com/117577336/219084652-e0438746-2712-4585-a6cd-e85c7f6795b3.png)
         

    - Nếu là balloon
    ![image](https://user-images.githubusercontent.com/117577336/219078045-f06677a9-de2c-4f8c-b508-b46a7dc02b17.png)

        + Remove hiệu ứng item bay
        + Thiết lập lại trang thái:không thể di chuyển sang trái phải
        ![image](https://user-images.githubusercontent.com/117577336/219078303-87294b82-fce0-4181-9c47-46a0e8aeb23c.png)

        + Khoảng cách với Enemy = 2 
        + SetAniAddBalloon():
            Remove Progress của item jetpack
            Remove Progress của item hoverbike
            Ẩn đối tượng Skis khi sử dụng item Skis
            Nếu đang sử dụng cable
                Sử dụng Cable = false;
            Nếu đang sử dụng rocket 
                Sử dụng Rocket = false;
            Nếu đang sử dụng jumper
                Sử dụng Jumper = false;
        + SetAniAfterFall(): sau khi tiếp đất 
![image](https://user-images.githubusercontent.com/117577336/219079093-345914a5-cd71-467e-b35b-887ac067f29d.png)

            Nếu đang sử dụng skis
                Nếu đang sử dụng nam châm
                chuyển kiểu chạy thành runSkisMagnet;
![image](https://user-images.githubusercontent.com/117577336/219079254-b8a7b66a-fae1-4e89-bd0e-a41ce63badb0.png)

                Nếu không sử dụng nam châm
                chuyển kiểu chạy thành runSkis;
![image](https://user-images.githubusercontent.com/117577336/219079631-975ab5de-145b-4f76-98a9-ada8ac616432.png)

            Những trường hợp còn lại: 
            Nếu đang sử dụng nam châm
            chuyển kiểu chạy thành runMagnet;
![image](https://user-images.githubusercontent.com/117577336/219079815-8f96fbab-8d41-4d0e-8e88-43458c129220.png)

            Nếu không sử dụng nam châm
              chuyển kiểu chạy thành runNormal;  
![image](https://user-images.githubusercontent.com/117577336/219079407-5062e654-fd6e-452c-9b63-9c8e0293cb1b.png)

            + Hủy bỏ sử dụng Animation sử dụng balloon 
        + Reset lại toàn bộ item trên map    
    
    - Nếu là scoreBooster
![image](https://user-images.githubusercontent.com/117577336/219077735-460b8e74-1c6b-4902-a7e5-1170b96cefc0.png)

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
    ![image](https://user-images.githubusercontent.com/117577336/219069376-8f0cd6a6-2202-4fa2-9d40-deef0510cf62.png)

    - Va chạm với vật cản đằng trước
        + Xử lý nếu có ván trượt thì không chết
            Nếu đang sử dụng skis: Thực hiện xóa tất cả vật cản xung quanh khu vực này này
    ![image](https://user-images.githubusercontent.com/117577336/219069701-50cf07a5-b374-4211-acbf-12d736cdfb23.png)

        + Nếu không sử dụng skis: Bị chết do va chạm với vật cản typeFalling
  ![image](https://user-images.githubusercontent.com/117577336/219069866-acfea101-b557-4c9c-9dc5-ec1258fbbc96.png)

    - Va chạm trái phải
        + Va chạm không bật lại 
            Nếu đang sử dụng skis: Thực hiện xóa tất cả vật cản xung quanh khu vực này này
    ![image](https://user-images.githubusercontent.com/117577336/219069701-50cf07a5-b374-4211-acbf-12d736cdfb23.png)
            Nếu không sử dụng skis: Bị chết do backScene
    ![image](https://user-images.githubusercontent.com/117577336/219070071-5b30a154-0fc2-4d78-a503-e1956e3abb5d.png)

            
        + Xử lý va chạm với vật cản đẩy lại:(Nếu đang ở bên trái rồi đi sang trái, Nếu đang ở bên phải rồi đi sang phải)
    ![image](https://user-images.githubusercontent.com/117577336/219070393-aa4ddcda-d369-439b-8c7c-3d230a036349.png)

            ColliderObjectSlowSpeed():
                Khoảng cách enemy -1
    ![image](https://user-images.githubusercontent.com/117577336/219070509-a8f575c0-febe-4f84-a766-99efadbe8f38.png)

                Nếu khoảng cách enemy = 0 -> bị tóm
                    Nếu đang sử dụng skis
                        Khoảng cách enemy = 2;
                        Trạng thái hero chuyển thành run;
    ![image](https://user-images.githubusercontent.com/117577336/219070808-4ee22b91-4592-47ce-be77-b800cafd97c1.png)

                    Nếu không sử dụng skis
                        Bị chết do cảnh sát tóm
    ![image](https://user-images.githubusercontent.com/117577336/219071107-90569aa7-51e6-489c-8319-91e9999973bc.png)

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
    
    
