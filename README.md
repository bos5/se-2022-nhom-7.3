Nhóm 7.3 làm về game unity subway surfers

LoadData*
    MainCamera: LoadDataGame.cs:
                CallNotifications.cs:
                GetCountryPlayer.cs:
    Canvas:
        AllCharacters: LoadController.cs
        PanelEffect: RunEffectPanel.cs
    ListResources:  ListCharacterUse.cs
                    Purchaser.cs
                    LoadListEnemy.cs
                    Recorder.cs
                    ListResourcesGame.cs
        CanvasDebug:
            Background:
                TextDebug:DebugController.cs
    FBController: FacebookController.cs            
    PoolTerrains: CreatePoolTerrains.cs
    PoolOthers: HighItemsController.cs
        ListHighCoins:
            PreCoinC: ItemInformation.cs
        ListHighItems:
            PreCableB: ItemInformation.cs
                Quad: RotateQuads.cs
            PreChestBox: ItemInformation.cs
                Quad: RotateQuads.cs
            PreHoverboardB: ItemInformation.cs
                Quad: RotateQuads.cs:
                Item:
                    HOVERBOARD: AddChangeMesh.cs
            PreJetpackB: ItemInformation.cs
                Quad: RotateQuads.cs
            PreKey: ItemInformation.cs
                Quad: RotateQuads.cs
            PreMagnetB: ItemInformation.cs
                Quad: RotateQuads.cs
            PreScoreDouble: ItemInformation.cs
                Quad: RotateQuads.cs
            PreSneaker: ItemInformation.cs
                Quad: RotateQuads.cs
            PreMissions: ItemInformation.cs
                Quad: RotateQuads.cs
            PreChallenge: ItemInformation.cs
                Quad: RotateQuads.cs
        ListParEatCoins:
            EffectEatCoin: PlayParticle.cs
        ListParEatItems:
            EffectEatItem: PlayParticle.cs



khi chạy chương trình 
GameMain:
    ContainGameMain: CheckActiveMain.cs
        CamContent: 
            MainCamera: PageMainGame.cs
                        TerrainController.cs
                        CameraController.cs
                        ChangeHeightFog.cs
                        MissionsController.cs
                        ChallengeController.cs
                        RotateSkyBox.cs
                PlaceHeroResult: ColorBGWinLose.cs
                    QuadEffect: RotateQuads.cs
        Canvas: 
            BGEffectBonusRoad: DisableMe.cs
            TextEffectBonusRoad: PlayAudioOnEnable.cs
                                 DisableMe.cs
                TextGroup
                    TextBonus: Gradient.cs
                    TextRoad: Gradient.cs
            TextEffectWinLose: PlayAudioOnEnable.cs
                TextGroup
                    TextWinLose: Gradient.cs
            PanelBonus: PlayAudioOnEnable.cs
                        DisableMe.cs
                TextGroup
                    NumBonus: Gradient.cs
                    TextTitle: Gradient.cs
            FormGameMenu:
                TapToPlay: CallAniRandom.cs
                ButUploadVideo: ButtonStatus.cs
                MessageBox: 
                    ViewAdsGetSkisBox:  CooldownSkis.cs
                                        DeactiveMessageBox.cs
                    ViewAdsGetKeyBox: CooldownKey.cs
                                      DeactiveMessageBox.cs
                    GetMissionsBox: DeactiveMessageBox.cs
                    GetChallengeBox: DeactiveMessageBox.cs
                    RateAppBox: DeactiveMessageBox.cs
                                MessageRate.cs
                    ShareFacebookBox: DeactiveMessageBox.cs
                                        MessageShareFB.cs
                    InviteFacebookBox: MessageInviteFB.cs
                                        DeactiveMessageBox.cs
                    NetworkSettingBox: MessageNetwork.cs
                    RoomsSettingBox: MessageRoom.cs
                    AutoFindOpponentsBox: MessageFindOpponent.cs
            FormGamePlay:
                ButPause: ButtonStatus.cs
                PanelViewFull: RunEffectViewEnemy.cs
                    PanelViewEnemyBG:
                        PanelViewNone: AutoDisableMe.cs
                MessageBox: 
                    SaveMeBox:  MessageSaveMe.cs
                                DeactiveMessageBox.cs
                        AllContents:
                            ButtonUploadVideo: ButtonStatus.cs
                    PauseGameBox:   MessagePauseGame.cs
                                    DeactiveMessageBox.cs
                        AllContents:
                            ButtonUploadVideo: ButtonStatus.cs
                    CountTimeResume: MessageTimeCount.cs
                    BuyKeyBox: MessageBuyKeys.cs
                        Content:
                            ParentKey:InitializePurchaserButton.cs
                                ItemKey: ProductButton.cs
                                    AllElements:
                                        ButDown:ButtonDownItem.cs
                    BonusFirstBox:  DeactiveMessageBox.cs
                                    MessageBonusFirst.cs
            SettingBox: MessageSetting.cs
                        DeactiveMessageBox.cs
            ListLanguagesBox:   MessageListLanguage.cs
                                DeactiveMessageBox.cs
                AllContents: 
                    ListLanguages:
                        Content:
                            Item: ButtonLanguage.cs
            ShowResultOnlineBox: MessageResultOnline.cs
            CurvedWorld: CurvedController.cs
            NetworkController: NetworkMagnager.cs
            HeroMax(Clone): HeroController.cs
                            ShadowFixed.cs
            EnemyPolice(Clone): EnemyController.cs

    ContainHeroConstruct:
        MainCamera: PageConstructHero.cs
        Canvas:
            BackgroundContent 
                ScorePlay
                    NumScore: EffectUpScore.cs
    ContainAchievement: 
        MainCamera: PageAchievement.cs
        BackgroundContent
            BackgroundTopFriend
                TextLoading: TextLoading.cs
            BackgroundTopCountry
                TextLoading: TextLoading.cs
            BackgroundTopWorld
                TextLoading: TextLoading.cs
            BackgroundTopMultiplayer
                TextLoading: TextLoading.cs
            CoinPlay:
                NumCoin: EffectUpScore.cs
            ScorePlay:
                NumCoin: EffectUpScore.cs
    ContainShopItem:
        MainCamera: PageShopItems.cs
        Canvas: 
            BackgroundContent:
                BackgroundBuyItem:
                    ListItemBuy:
                        Content:
                            ParentCoin: InitializePurchaserButton.cs
                                ItemCoin: ProductButton.cs
                                    AllElements
                                        ButDown: ButtonDownItem.cs
                            ParentKey: InitializePurchaserButton.cs
                                ItemKey: ProductButton.cs
                                    AllElements
                                        ButDown: ButtonDownItem.cs
                            ParentSingle: 
                                ItemSkis: BuyItemController.cs
                                    AllElements
                                        ButDown: ButtonDownItem.cs
                                        ButBuy: ButtonBuyItem.cs
                                ItemMysteryBox: BuyItemController.cs
                                    AllElements
                                        ButDown: ButtonDownItem.cs
                                        ButBuy: ButtonBuyItem.cs
                                ItemHeadStart: BuyItemController.cs
                                        AllElements
                                            ButDown: ButtonDownItem.cs
                                            ButBuy: ButtonBuyItem.cs
                                ItemScoreBooster: BuyItemController.cs
                                    AllElements
                                        ButDown: ButtonDownItem.cs
                                        ButBuy: ButtonBuyItem.cs
                BackgroundUpgrades: 
                    ListItemUpgrades:
                        Content:
                            ItemJetpack: UpgradesController.cs
                                AllElements
                                    ButDown: ButtonDownItem.cs
                                    ButBuy: ButtonUpgradesItem.cs
                            ItemSuperSneakers: UpgradesController.cs
                                AllElements
                                    ButDown: ButtonDownItem.cs
                                    ButBuy: ButtonUpgradesItem.cs
                            ItemCoinMagnetItem2XMultiplier: UpgradesController.cs 
                                AllElements
                                    ButDown: ButtonDownItem.cs
                                    ButBuy: ButtonUpgradesItem.cs
                            ItemCable: UpgradesController.cs
                                AllElements
                                    ButDown: ButtonDownItem.cs
                                    ButBuy: ButtonUpgradesItem.cs
                            ItemHoverBoard: UpgradesController.cs
                                AllElements
                                    ButDown: ButtonDownItem.cs
                                    ButBuy: ButtonUpgradesItem.cs
                ScorePlay:
                    NumScore: EffectUpScore.cs
    ContainHighScore:
        MainCamera: PageHighScore.cs
            Canvas:
                TextHighScore: Gradient.cs
                    NumberHighScore: EffectUpSc ore.cs
            EffectBackground: RotateParticleSpeed.cs
    ContainOpenBox:
        MainCamera: PageOpenMysteryBox.cs
            CanvasText: 
                TextTitleItem: Gradient.cs
            QuadEffectBonus:
                QuadEffect: RotateQuads.cs

DontDestroyOnLoad
    PoolTerrains:
        Terrain: TerrainInformation.cs




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


                
