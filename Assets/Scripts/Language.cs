using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public GameObject RusImg;
    public GameObject EngImg;

    public Text[] Bonus, MainMenu, DailyQuests, Charter_Persona, Charter_Kucher, Charter_Horse, Charter_Povozka, Charter_Lodka, Charter_Povozka_winter, Charter_Train, MenuShop, WeaponShop, ExplosiveShop, Rating, Options, PanelLanguage, InfoPanelWeapon, InfoPanelExplosive, EditName, Price, Loading;
    public static string[] S_DailyQuests = new string[6];
    //public static string[] TShopHelper = new string[8];
    // public static string[] TGameCompany = new string[4];
    //public static string[] BHelperText = new string[23];
    public static string[] GameMain = new string[2];
    void Awake()
    {
        RU();//
        Words();
    }
    //Сменить язык на русский
    public void RU()
    {
        PlayerPrefs.SetString("Language", "RU");
        Words();

        //  FullMenu.BHelper(BHelperText[7]);
    }

    //Сменить язык на английский
    public void UK()
    {
        PlayerPrefs.SetString("Language", "UK");
        Words();
        //  FullMenu.BHelper(BHelperText[7]);
    }

    //Переводы
    void Words()
    {

        if (PlayerPrefs.GetString("Language") == "RU")
        {
            RusImg.SetActive(true);
            EngImg.SetActive(false);
            //Бонус
            Bonus[0].text = "Бесплатный сундук";
            Bonus[1].text = "Бесплатный сундук доступен каждый день.";
            Bonus[2].text = "Поздравляю, бонусы зачислены, ждем тебя завтра :)";

            //Главное меню
            MainMenu[0].text = "Играть ";
            MainMenu[1].text = "Ежедневные задания";
            MainMenu[2].text = "Персонаж";
            MainMenu[3].text = "Магазин";
            MainMenu[4].text = "Рейтинг";
            MainMenu[5].text = "Настройки";



            //!Ежедневные квесты
            //Первый блок
            DailyQuests[0].text = "Ежедневные задания";
            DailyQuests[1].text = "Награда:";
            DailyQuests[2].text = "Забрать";
            DailyQuests[3].text = "Награда:";
            DailyQuests[4].text = "Забрать";
            //Второй блок
            S_DailyQuests[0] = "Убить зомби";
            S_DailyQuests[1] = "Унитожить летающих обьектов";
            S_DailyQuests[2] = "Проехать растрояние";
            S_DailyQuests[3] = "Заработать золотых монет";
            S_DailyQuests[4] = "Поиграть определенное время";
            S_DailyQuests[5] = "Пройти несколько уровней";


            //![Улучшения] 
            //"Персонаж"
            Charter_Persona[0].text = "Повысить за";
            Charter_Persona[1].text = "Золотые монеты";
            Charter_Persona[2].text = "Увеличевает получение золотых монет";
            Charter_Persona[3].text = "Кристалы";
            Charter_Persona[4].text = "Увеличевает получение кристаллов";
            Charter_Persona[5].text = "Урон";
            Charter_Persona[6].text = "Дополнительный урон к любому оружию";
            Charter_Persona[7].text = "Жизнь";
            Charter_Persona[8].text = "Увеличивает количество жизни";
            Charter_Persona[9].text = "ФИО";
            Charter_Persona[10].text = "Ковалев Виктор";
            Charter_Persona[11].text = "Ковалев Виктор – родился в 1978 г. в небольшой семье фермера. Виктор был единственным ребенком в семье, так что они жили не в тягость. У него была лошадь, которую ему оставили еще в детстве, так что ему не было скучно. Их дом находился в небольшом местечке в северной части Техаса. Годы шли, и паренек закончил школу, а затем отправился в Вашингтон. Там Виктор открыл небольшое газетное издание. Какое-то время дела шли хорошо, газеты его редакции приносили неплохую прибыль. У главного героя были планы, чтобы его родители переехали к нему в Вашингтон. Но в жизни Виктор все пошло не так, как он хотел. Когда он написал письмо с просьбой переехать жить к нему, оно не успело дойти до родителей. Трагедия случилась в один из дождливых осенних дней, родители возвращались с рынка к себе на ферму на своей машине, но дорога была очень скользкая, и по непредвиденным обстоятельствам в их машину врезалась другая. Повреждения были очень сильными, и родители Виктора не смогли пережить автокатастрофу. Через год, в 1998-ом, Виктор обанкротился, т.к. его газеты перестали пользоваться спросом. Денег на жизнь в Вашингтоне не хватало, поэтому он перебрался обратно в Техас, где и продолжил родительское дело. Соскучиться в одиночестве ему не дает та самая лошадь, а также его верный друг, с которым они стали очень близки. С этих пор жизнь Виктора стала более радостной, чем раньше, ведь у него есть верные друзья. ";


            //[Улучшения] "Кучер"
            Charter_Kucher[0].text = "Повысить за";
            Charter_Kucher[1].text = "Золотые монеты";
            Charter_Kucher[2].text = "Увеличевает получение золотых монет";
            Charter_Kucher[3].text = "Кристалы";
            Charter_Kucher[4].text = "Увеличевает получение кристаллов";
            Charter_Kucher[5].text = "Скорость";
            Charter_Kucher[6].text = "Увеличевает время ускорение лошади";
            Charter_Kucher[7].text = "Сила";
            Charter_Kucher[8].text = "Увеличивает силу для очистки дороги";
            Charter_Kucher[9].text = "ФИО";
            Charter_Kucher[10].text = "Харвард Кокс";
            Charter_Kucher[11].text = "Харвард Кокс – верный друг Виктора. Родился в 1969 году в крупном городе Чикаго. Его родители очень любили этот город, в отличие от Харварда. Он всегда хотел переехать в тихую деревушку, где бы он смог заниматься своим любимым делом – фермерством. На его предложения о переезде родители всегда отвечали отказом. Харвард Кокс был не особо общительным мальчиком. У него почти не было друзей. Но его это не сильно огорчало. Дома он занимался небольшим садоводством. В школе он учился неплохо. Через несколько лет, после школы, он уехал учиться в Вашингтон (где впоследствии и познакомился с Викторам). И в свободное время от учебы он подрабатывал у него в газетной редакции. После завершения учебы Харварду недолго пришлось искать хорошую работу. Он решил заниматься тем, что всегда любил – садоводством. Он приобрел небольшую полуразрушенную ферму в деревне Виктора и переехал жить туда, там он заодно подрабатывал почтальоном. Благодаря своему трудолюбию он вернул ферму к новой жизни. В душе оставалась одна маленькая мечта – почувствовать себя в роли наездника, да и на ферме нужен хороший помощник. Денег на хорошую лошадь у него не осталось. Ему пришлось купить старую и его мечта была исполнена. Но вскоре лошадь умерла. Харвард часто писал своему другу Виктору. В одном из писем Виктор рассказал, что он хочет вернуться на свою ферму, Харвард был этому только рад. Вскоре друзья решили ухаживать за фермой семьи Ковалевых, а свою ферму Кокс продал в хорошие руки. Поскольку у Виктора была лошадь, то и Харвард смог на ней покататься. Теперь они втроем живут не разлей вода. ";


            //[Улучшения] "Конь"
            Charter_Horse[0].text = "Повысить за";
            Charter_Horse[1].text = "Скорость";
            Charter_Horse[2].text = "Увеличевает скорость у повозки";
            Charter_Horse[3].text = "Жизнь";
            Charter_Horse[4].text = "Увеличивает количество жизни";
            Charter_Horse[5].text = "ФИО";
            Charter_Horse[6].text = "Тайга";
            Charter_Horse[7].text = "Лошадь принадлежит Виктору еще с раннего детства. Ее оставил в подарок Виктору его отец. С тех пор, она верно служит своему хозяину. Она довольно-таки быстра, но долгое время ее скорость нигде не применялась. Теперь же, когда нужно быстро угонять от зомби, она может показать всю свою скорость, которой могут позавидовать многие лошади. ";


            //[Улучшения] "Повозка"
            Charter_Povozka[0].text = "Повысить за";
            Charter_Povozka[1].text = "Золотые монеты";
            Charter_Povozka[2].text = "Увеличевает получение золотых монет";
            Charter_Povozka[3].text = "Сила";
            Charter_Povozka[4].text = "Увеличивает силу у Харварда";
            Charter_Povozka[5].text = "Повозка Ковалевых";
            Charter_Povozka[6].text = "Повозка Ковалевых, на которой еще родители Виктора ездили на ярмарку, теперь служит для гонок от зомби. Она очень старая, но Виктор со своим другом успели ее подлатать. Зимой приходится сильно снижать скорость, т.к. повозка крайне неповоротлива, да и хлипкая. Не знаем, долго ли она протянет, ведь она уже вся скрипит и колеса видали дни получше. ";




            //[Улучшения] "Лодка"
            Charter_Lodka[0].text = "Повысить за";
            Charter_Lodka[1].text = "Золотые монеты";
            Charter_Lodka[2].text = "Увеличевает получение золотых монет";
            Charter_Lodka[3].text = "Сила";
            Charter_Lodka[4].text = "Увеличивает силу у Харварда";
            Charter_Lodka[5].text = "Лодка дяди Бена";
            Charter_Lodka[6].text = "У Виктора также есть дядя Бен. Он был ярым рыбаком, и эта лодка являлась членом семьи. Нередки были случаи, когда Бен всю ночь проводил в лодке и во сне признавался ей в любви… Но это уже дело дяди Бена. Интересен тот факт, что лодка теперь у Виктора, а дядя Бен исчез за пару дней до объявления о нашествии монстров. Будем надеяться, что он просто пошел в магазин за новым канатом для своей лодки. ";
            Charter_Lodka[7].text = "Навряд ли Виктор и Харвард смогут вплавь ускользнуть от зомби и отстреливаться от них. Так что приобретите лодку для прохождения следующих уровней.";
            Charter_Lodka[8].text = "Открыть";


            //[Улучшения] "Зимняя повозка"
            Charter_Povozka_winter[0].text = "Повысить за";
            Charter_Povozka_winter[1].text = "Золотые монеты";
            Charter_Povozka_winter[2].text = "Увеличивает получение золотых монет";
            Charter_Povozka_winter[3].text = "Сила";
            Charter_Povozka_winter[4].text = "Увеличивает силу у Харварда";
            Charter_Povozka_winter[5].text = "Зимняя повозка";
            Charter_Povozka_winter[6].text = "Повозка специально изготовлена для гонок от монстров в зимнее время. Главный плюс зимней повозки заключается в том, что теперь можно не мерзнуть, а в тепле и уюте можно пить горячий вкусный чай (а может и кровь своих врагов…). Внутри присутствует буржуйка и будем надеяться, что это безопасно. Внутренний интерьер обустроен по последним веяниям моды. Зомби обязаны оценить.";
            Charter_Povozka_winter[7].text = "Зимой повозка Ковалевых будет не самым лучшим транспортом, ведь она крайне неповоротлива. Купите эту повозку и сможете проходить зимние уровни!";
            Charter_Povozka_winter[8].text = "Открыть";


            //[Улучшения] "Поезд"
            Charter_Train[0].text = "Повысить за";
            Charter_Train[1].text = "Золотые монеты";
            Charter_Train[2].text = "Увеличивает получение золотых монет";
            Charter_Train[3].text = "Сила";
            Charter_Train[4].text = "Увеличивает силу у Харварда";
            Charter_Train[5].text = "Старушка Эмма";
            Charter_Train[6].text = "Вы не поверите, но во владении Виктора и Харварда теперь есть настоящий паровоз! Он точно обеспечит огромную скорость, и поэтому очень требователен в ресурсах. Хотя, уголь или древесину можно найти везде, монстрам эти ресурсы навряд ли нужны. Паровоз хоть и старый, но в отличном состоянии, видимо до нашествия зомби кто-то успел его обслужить. Возможно, что один из зомби будет тем самым машинистом, который хочет снова управлять старушкой Эммой.";
            Charter_Train[7].text = "По рельсам ни одна тележка нормально ехать точно не сможет. Да и скорость нужна гораздо больше. Идеальным вариантом будет покупка паровоза для дальнейшего прохождения.";
            Charter_Train[8].text = "Открыть";

            //!Магазин
            //*Меню
            MenuShop[0].text = "Оружие";
            MenuShop[1].text = "Взрывчатки";
            MenuShop[2].text = "Монетки";

            //*Оружие: Название
            WeaponShop[0].text = "Двустволка";
            WeaponShop[1].text = "Два ствола";
            WeaponShop[2].text = "Дробовик";
            WeaponShop[3].text = "AWP";
            WeaponShop[4].text = "AK-47";
            WeaponShop[5].text = "Базука";
            //Оружие: Патроны
            WeaponShop[6].text = "Патроны";
            WeaponShop[7].text = "Патроны";
            WeaponShop[8].text = "Патроны";
            WeaponShop[9].text = "Патроны";
            WeaponShop[10].text = "Патроны";
            WeaponShop[11].text = "Патроны";
            //Оружие: Улучшить
            WeaponShop[12].text = "Улучшить";
            WeaponShop[13].text = "Улучшить";
            WeaponShop[14].text = "Улучшить";
            WeaponShop[15].text = "Улучшить";
            WeaponShop[16].text = "Улучшить";
            WeaponShop[17].text = "Улучшить";
            //Оружие: Открыть
            WeaponShop[18].text = "Купить";
            WeaponShop[19].text = "Купить";
            WeaponShop[20].text = "Купить";
            WeaponShop[21].text = "Купить";
            WeaponShop[22].text = "Купить";


            //*Взрывчатки
            //Взрывчатки: Название
            ExplosiveShop[0].text = "Динамит";
            ExplosiveShop[1].text = "Граната";
            ExplosiveShop[2].text = "Коктейль Молотова";
            ExplosiveShop[3].text = "Мина";
            //Взрывчатки: Купить
            ExplosiveShop[4].text = "Купить";
            ExplosiveShop[5].text = "Купить";
            ExplosiveShop[6].text = "Купить";
            ExplosiveShop[7].text = "Купить";
            //Взрывчатки: Улучшить
            ExplosiveShop[8].text = "Улучшить";
            ExplosiveShop[9].text = "Улучшить";
            ExplosiveShop[10].text = "Улучшить";
            ExplosiveShop[11].text = "Улучшить";
            //Взрывчатки: Открыть
            ExplosiveShop[12].text = "Купить";
            ExplosiveShop[13].text = "Купить";
            ExplosiveShop[14].text = "Купить";
            ExplosiveShop[15].text = "Купить";

            //! Настройки
            Options[0].text = "Настройки";

            //!Выберите язык 
            PanelLanguage[0].text = "Язык";

            //! Инфо Панель
            //*Инфо оружие
            //Название
            InfoPanelWeapon[0].text = "Двустволка";
            InfoPanelWeapon[1].text = "Два ствола";
            InfoPanelWeapon[2].text = "Дробовик";
            InfoPanelWeapon[3].text = "AWP";
            InfoPanelWeapon[4].text = "AK-47";
            InfoPanelWeapon[5].text = "Базука";

            //Описание 
            InfoPanelWeapon[6].text = "Винтовка досталась Виктору от покойного отца. Отец часто бывал на охоте, и его винтовка ни разу не подводила. С тех пор прошло много лет, но двустволка стреляет почти как новая. Один патрон сразу же отстрелит голову одному зомби. Винтовка старая, но в руках Виктора с ней шутки плохи.";
            InfoPanelWeapon[7].text = "Эти два револьвера не отличаются радиусом поражения, зато они быстро стреляют. Еще одним достоинством револьверов является их обойма. Никто не знает откуда эти револьверы у Виктора. Ходят слухи, что они побывали в руках самого Аль Капоне, но кто докажет…";
            InfoPanelWeapon[8].text = "Это чудо стреляет четырьмя дробями, что увеличивает радиус поражения и количество урона. Магазин дробовика составляет 8 патрон. Идеально подходит, если на вас наступает группа монстров. Никогда до нее не было так приятно стрелять по зомби!";
            InfoPanelWeapon[9].text = "Данную винтовку наверняка знают многие. Только ее название вызывает ужас у многих, но если ее применяют на деле… В любом случае, она идеально подойдет, если на вас идет огромный зомби, которого не берет обычное оружие. По мнению монстров, это читерское оружие. Но кого это волнует?";
            InfoPanelWeapon[10].text = "Оружие-классика, которое должно быть всегда и везде. Без него стрельбу по зомби нельзя назвать стрельбой. Главное его достоинство, большой магазин и скорострельность. Ну… и из него просто классно пострелять, это же АК-47. Идеально подходит, если на вас обрушились полчища зомби.";
            InfoPanelWeapon[11].text = "Тут навряд ли нужны слова, чтобы описать данное оружие. Идеально подходит для любителей взрывов, или если за вами бежит столько зомби, что ни одно другое оружие не может справится. Не стоит увлекаться стрельбой из базуки. Понимаем, что соблазн слишком велик, но велик и шанс подорвать себя вместе с нечистью.";

            //*Взрывчатки
            //Название
            InfoPanelExplosive[0].text = "Динамит";
            InfoPanelExplosive[1].text = "Граната";
            InfoPanelExplosive[2].text = "Коктейль Молотова";
            InfoPanelExplosive[3].text = "Мина";

            //Описание
            InfoPanelExplosive[4].text = "Самый обыкновенный динамит. Особых преимуществ не имеет, но наносит дополнительный урон по монстрам. Главный его минус в том, что он не взрывается в воде. В любом случае, он будет являться подспорьем, когда закончатся патроны.";
            InfoPanelExplosive[5].text = "Данный вид гранаты проверен временем и отлично показал себя в боевых действиях. В отличие от динамита она может взрываться и под водой. Урона она так же наносит больше, соответственно и страха вызывает гораздо больше.";
            InfoPanelExplosive[6].text = "Единственный коктейль, которым можно угостить зомби. В составе смеси используется секретная формула, которую придумали суровые техасские мальчишки для усовершенствования исходного коктейля Молотова. Благодаря ей пламя горит еще дольше! Этими же мальчишками проверено и качество, они зуб дали.";
            InfoPanelExplosive[7].text = "Если на вас нападают зомби, которые умерли во время СССР, то киньте им под ноги данную мину. Это вызовет чувство ностальгии у монстров, а потом и чувство полета их конечностей. Конечно, у мины нет таких гарантий, в отличие от модифицированного коктейля Молотова, но мина СССР никогда вас не подведет и обязательно найдет своего зомби!";
            //!Ник игрока
            EditName[0].text = "Ваше имя";
            EditName[1].text = "Введите имя";
            EditName[2].text = "Сохранить";
            EditName[3].text = "Некорректный формат.";
            EditName[4].text = "Имя пользователя может содержать не менее 4-х символов в длину.";



            //! Цена
            Price[0].text = "СПЕЦПРЕДЛОЖЕНИЕ!";
            Price[1].text = "789.0 руб.";
            Price[2].text = "395.0 руб.";
            Price[3].text = "Купить";
            Price[4].text = "75.0 руб.";
            Price[5].text = "189.0 руб.";
            Price[6].text = "449.0 руб.";
            Price[7].text = "789.0 руб.";
            Price[8].text = "75.0 руб.";
            Price[9].text = "189.0 руб.";
            Price[10].text = "449.0 руб.";
            Price[11].text = "789.0 руб.";
            Price[12].text = "Play";
            Price[13].text = "Play";


            //! Подсказки

            Loading[0].text = "Нажимите на экран...";
            Loading[1].text = "Покупайте новое оружие в магазине и не забывайте его улучшать. Чтобы выбрать купленное оружие нажмите в магазине на зеленую кнопку рядом с ним.";
            Loading[2].text = "Улучшайте персонажа, чтобы получить больше золотых монет.";
            Loading[3].text = "Смотрите рекламу, чтобы получить бесплатные золотые монетки, также не забывайте про ежедневные призы. За 1 просмотр рекламы вы получите 1000 золотых монет.";
            Loading[4].text = "Цельтесь в голову, чтобы нанести больше урона.";
            Loading[5].text = "Чтобы использовать бомбу просто перенесите ее на дорогу в то место, где хотите, чтобы она взорвалась.";

            //! В сцене игры
            GameMain[0] = "";

            //!Рейтинг 
            Rating[0].text = "Топ 10 за неделю";
            Rating[1].text = "Топ 10";
        }

        if (PlayerPrefs.GetString("Language") == "UK")
        {
            RusImg.SetActive(false);
            EngImg.SetActive(true);
            //Бонус бесплатный сундук
            Bonus[0].text = "Free chest";
            Bonus[1].text = "Collect your daily gift";
            Bonus[2].text = "Congratulations, bonuses are credited, we are waiting for you tomorrow :)";

            //Главное меню
            MainMenu[0].text = "Play";
            MainMenu[1].text = "Dailt tasks";
            MainMenu[2].text = "Character";
            MainMenu[3].text = "Shop";
            MainMenu[4].text = "Rating";
            MainMenu[5].text = "Settings";

            //!Ежедневные квесты
            //Первый блок
            DailyQuests[0].text = "Daily tasks";
            DailyQuests[1].text = "Reward:";
            DailyQuests[2].text = "Collect";
            DailyQuests[3].text = "Reward:";
            DailyQuests[4].text = "Collect";
            //Второй  блок

            S_DailyQuests[0] = "Dill the zombies";
            S_DailyQuests[1] = "Destroy the flying objects";
            S_DailyQuests[2] = "Drive the distance";
            S_DailyQuests[3] = "Earn gold coins";
            S_DailyQuests[4] = "Play a certain time";
            S_DailyQuests[5] = "Complete one level";

            //![Улучшения]
            // "Персонаж"
            Charter_Persona[0].text = "Upgrade";
            Charter_Persona[1].text = "Gold";
            Charter_Persona[2].text = "Increased gold mining";
            Charter_Persona[3].text = "Crystal";
            Charter_Persona[4].text = "Increased crystal loss";
            Charter_Persona[5].text = "Damage";
            Charter_Persona[6].text = "Increased damage to all weapons";
            Charter_Persona[7].text = "Lives";
            Charter_Persona[8].text = "Increase in lives";
            Charter_Persona[9].text = "SNM";
            Charter_Persona[10].text = "Viktor Kovalev";
            Charter_Persona[11].text = "Kovalev Victor - was born in 1978 in a small family of a farmer. Victor was the only child in the family, so they did not live in burdens. He had a horse, which he was left as a child, so he was not bored. Their home was in a small place in northern Texas. Years passed, and the boy graduated from high school, and then went to Washington. There Victor opened a small newspaper publication. For a while things were going well, the newspapers of his editorial office brought good profit. The main character had plans for his parents to move to him in Washington. But in Victor’s life, everything didn’t go as he wanted. When he wrote a letter asking him to move to live with him, it did not reach his parents. The tragedy happened on one of the rainy autumn days, parents returned from the market to their farm in their car, but the road was very slippery and, due to unforeseen circumstances, another crashed into their car. The injuries were very severe, and Victor's parents could not survive the car accident. A year later, in 1998, Victor went bankrupt, because his newspapers were no longer in demand. There was not enough money for life in Washington, so he moved back to Texas, where he continued his parenting business. The same horse, as well as his faithful friend, with whom they became very close, did not let him miss him alone. Since then, Victor's life has become more joyful than before, because he has true friends.";


            //[Улучшения] "Кучер"
            Charter_Kucher[0].text = "Upgrade";
            Charter_Kucher[1].text = "Gold";
            Charter_Kucher[2].text = "Increased gold mining";
            Charter_Kucher[3].text = "Crystal";
            Charter_Kucher[4].text = "Increased crystal loss";
            Charter_Kucher[5].text = "Speed time";
            Charter_Kucher[6].text = "Increase horse running time";
            Charter_Kucher[7].text = "Power";
            Charter_Kucher[8].text = "Increase in strength to clear the road";
            Charter_Kucher[9].text = "SNM";
            Charter_Kucher[10].text = "Harward Cox";
            Charter_Kucher[11].text = "Harvard Cox is a true friend of Victor. Born in 1969 in a major city of Chicago. His parents loved this city, unlike Harvard. He always wanted to move to a quiet village, where he could be engaged in his favorite business - farming. Parents always refused to offer him a move. Harvard Cox was not a very sociable boy. He had almost no friends. But this did not upset him much. At home he was engaged in small gardening. He studied well at school. A few years after school, he went to study in Washington (where he later met Victor). And in his free time from study, he worked part-time at his newspaper editorial office. After completing his studies, Harvard did not have to look for a good job for long. He decided to do what he always loved - gardening. He acquired a small dilapidated farm in the village of Victor and moved to live there, where he also worked as a postman. Thanks to his hard work, he returned the farm to a new life. One small dream remained in my soul - to feel like a rider, and a good helper is needed on the farm. He had no money left for a good horse. He had to buy an old one and his dream was fulfilled. But soon the horse died. Harvard often wrote to his friend Victor. In one of the letters, Victor said that he wants to return to his farm, Harvard was only happy about this. Soon, friends decided to look after the farm of the Kovalev family, and Cox sold his farm in good hands. Since Victor had a horse, Harvard was able to ride it. Now the three of them live not spill water.";

            //[Улучшения] "Конь"
            Charter_Horse[0].text = "Upgrade";
            Charter_Horse[1].text = "Speed";
            Charter_Horse[2].text = "The speed of the cart increases";
            Charter_Horse[3].text = "Life";
            Charter_Horse[4].text = "Increases the amount of life";
            Charter_Horse[5].text = "SNM";
            Charter_Horse[6].text = "Taiga";
            Charter_Horse[7].text = "The horse belongs to Victor since early childhood. She was left as a gift to Victor by his father. Since then, she faithfully serves her master. It is pretty fast, but for a long time its speed was not used anywhere. Now, when you need to quickly steal from zombies, she can show all her speed, which many horses can envy.";


            //[Улучшения] "Повозка"
            Charter_Povozka[0].text = "Upgrade";
            Charter_Povozka[1].text = "Gold";
            Charter_Povozka[2].text = "Increases Gold Coins";
            Charter_Povozka[3].text = "Power";
            Charter_Povozka[4].text = "Increases Harvard Strength";
            Charter_Povozka[5].text = "Kovalev cart";
            Charter_Povozka[6].text = "The Kovalev cart, on which Victor’s parents also went to the fair, now serves as a zombie race. She is very old, but Victor and his friend managed to pat her. In winter you have to greatly reduce the speed, because the wagon is extremely slow and flimsy. We don’t know how long it will last, because it already creaks and wheels have seen better days.";



            //[Улучшения] "Лодка"
            Charter_Lodka[0].text = "Upgrade";
            Charter_Lodka[1].text = "Gold";
            Charter_Lodka[2].text = "Increases Gold Coins";
            Charter_Lodka[3].text = "Power";
            Charter_Lodka[4].text = "Increases Harvard Strength";
            Charter_Lodka[5].text = "Uncle Ben's boat";
            Charter_Lodka[6].text = "Victor also has Uncle Ben. He was an ardent fisherman, and this boat was a member of the family. There were often cases when Ben spent all night in a boat and in a dream confessed his love to her ... But this is Uncle Ben’s business. An interesting fact is that the boat is now with Victor, and Uncle Ben disappeared a couple of days before the announcement of the invasion of monsters. Let's hope that he just went to the store for a new rope for his boat.";
            Charter_Lodka[7].text = "It is unlikely that Victor and Harvard will be able to swim away from the zombies and shoot back from them. So get a boat to go through the following levels.";
            Charter_Lodka[8].text = "Open";


            //[Улучшения] "Зимняя повозка"
            Charter_Povozka_winter[0].text = "Upgrade";
            Charter_Povozka_winter[1].text = "Gold";
            Charter_Povozka_winter[2].text = "Increases Gold Coins";
            Charter_Povozka_winter[3].text = "Power";
            Charter_Povozka_winter[4].text = "Increases Harvard Strength";
            Charter_Povozka_winter[5].text = "Winter wagon";
            Charter_Povozka_winter[6].text = "The cart is specially made for racing from monsters in the winter. The main plus of the winter cart is that now you can not freeze, and in warmth and comfort you can drink hot tasty tea (and maybe the blood of your enemies ...). There is a potbelly stove inside and let's hope that it is safe. The interior is furnished according to the latest fashion trends. Zombies are required to evaluate.";
            Charter_Povozka_winter[7].text = "In winter, the Kovalevs cart will not be the best transport, because it is extremely slow. Buy this cart and you can pass the winter levels!";
            Charter_Povozka_winter[8].text = "Open";


            //[Улучшения] "Поезд"
            Charter_Train[0].text = "Upgrade";
            Charter_Train[1].text = "Gold";
            Charter_Train[2].text = "Increases Gold Coins";
            Charter_Train[3].text = "Power";
            Charter_Train[4].text = "Increases Harvard Strength";
            Charter_Train[5].text = "Old lady Emma";
            Charter_Train[6].text = "You won’t believe it, but Victor and Harvard now own a real engine! It will definitely provide tremendous speed, and therefore is very demanding in resources. Although coal or wood can be found everywhere, monsters are unlikely to need these resources. The engine, although old, but in excellent condition, apparently before the zombie invasion, someone managed to service it. It is possible that one of the zombies will be the very driver who wants to control old Emma again.";
            Charter_Train[7].text = "On the rails, not a single trolley can normally drive normally. Yes, and speed is needed much more. An ideal option would be to purchase a steam locomotive for further passage.";
            Charter_Train[8].text = "Open";

            //!Магазин
            //*Меню
            MenuShop[0].text = "Weapons";
            MenuShop[1].text = "Explosives";
            MenuShop[2].text = "Coins";

            //*Оружие: Название
            WeaponShop[0].text = "Double shotgun";
            WeaponShop[1].text = "Two guns";
            WeaponShop[2].text = "Shotgun";
            WeaponShop[3].text = "AWP";
            WeaponShop[4].text = "AK-47";
            WeaponShop[5].text = "RPG";
            //Оружие: Патроны
            WeaponShop[6].text = "Buy ammo";
            WeaponShop[7].text = "Buy ammo";
            WeaponShop[8].text = "Buy ammo";
            WeaponShop[9].text = "Buy ammo";
            WeaponShop[10].text = "Buy ammo";
            WeaponShop[11].text = "Buy ammo";
            //Оружие: Улучшить
            WeaponShop[12].text = "Upgrade";
            WeaponShop[13].text = "Upgrade";
            WeaponShop[14].text = "Upgrade";
            WeaponShop[15].text = "Upgrade";
            WeaponShop[16].text = "Upgrade";
            WeaponShop[17].text = "Upgrade";
            //Оружие: Открыть
            WeaponShop[18].text = "Buy";
            WeaponShop[19].text = "Buy";
            WeaponShop[20].text = "Buy";
            WeaponShop[21].text = "Buy";
            WeaponShop[22].text = "Buy";

            //*Взрывчатки
            //Взрывчатки: Название
            ExplosiveShop[0].text = "Dynamite";
            ExplosiveShop[1].text = "Grenade";
            ExplosiveShop[2].text = "Molotov";
            ExplosiveShop[3].text = "Mina";
            //Взрывчатки: Купить
            ExplosiveShop[4].text = "Buy ammo";
            ExplosiveShop[5].text = "Buy ammo";
            ExplosiveShop[6].text = "Buy ammo";
            ExplosiveShop[7].text = "Buy ammo";
            //Взрывчатки: Улучшить
            ExplosiveShop[8].text = "Upgrade";
            ExplosiveShop[9].text = "Upgrade";
            ExplosiveShop[10].text = "Upgrade";
            ExplosiveShop[11].text = "Upgrade";
            //Взрывчатки: Открыть
            ExplosiveShop[12].text = "Buy";
            ExplosiveShop[13].text = "Buy";
            ExplosiveShop[14].text = "Buy";
            ExplosiveShop[15].text = "Buy";

            //! Настройки
            Options[0].text = "Settings";


            //!Выберите язык 
            PanelLanguage[0].text = "Language";

            //! Инфо Панель
            //*Инфо оружие
            //Название
            InfoPanelWeapon[0].text = "Double shotgun";
            InfoPanelWeapon[1].text = "Two guns";
            InfoPanelWeapon[2].text = "Shotgun";
            InfoPanelWeapon[3].text = "AWP";
            InfoPanelWeapon[4].text = "AK-47";
            InfoPanelWeapon[5].text = "RPG";

            //Описание 
            InfoPanelWeapon[6].text = "Double-barreled went to Victor from his deceased father. Father often took his double-barreled gun for hunting. Many years have passed but the double-barreled barrel as new. Double barrel in the hands of Victor a dangerous weapon";
            InfoPanelWeapon[7].text = "These two revolvers fire faster than a double-barreled gun. Another advantage is their clip. Nobody knows where Victor got these revolvers from, but there are rumors that they belonged to Al Capone, but this is impossible to prove.";
            InfoPanelWeapon[8].text = "This miracle takes off four rounds. This increases the radius of the shot and damage. Shotgun for 8 volleys. Ideal if a group of zombies comes. It's time to shoot him. Amazing moment";
            InfoPanelWeapon[9].text = "This rifle is known to many people. Its name causes a feeling of horror on the face. An ideal weapon if you are attacked by a huge zombie that ordinary weapons cannot kill. Monsters consider this a cheating weapon, but does anyone care";
            InfoPanelWeapon[10].text = "AK-47";
            InfoPanelWeapon[11].text = "Базука";

            //*Взрывчатки
            //Название
            InfoPanelExplosive[0].text = "Dynamite";
            InfoPanelExplosive[1].text = "Grenade";
            InfoPanelExplosive[2].text = "Molotov";
            InfoPanelExplosive[3].text = "Mina";

            //Описание
            InfoPanelExplosive[4].text = "Just ordinary dynamite. It has no special advantages, but it deals additional damage to monsters. Its main disadvantage is that it does not explode in water. In any case, it will be a help when you run out of ammo.";
            InfoPanelExplosive[5].text = "This type of grenade is time-tested and has proven itself in combat. Unlike dynamite, it can also explode under water. Damage it also causes more, respectively, and fear causes much more.";
            InfoPanelExplosive[6].text = "The only cocktail you can give to a zombie. The composition of the mixture uses a secret formula that was invented by harsh Texas boys to improve the original Molotov cocktail. Thanks to it, the flame burns even longer! These same boys checked the quality, they gave a tooth.";
            InfoPanelExplosive[7].text = "If you are attacked by zombies who had died during the Soviet Union, then throw them under the feet of this mine. This will cause a feeling of nostalgia in the monsters, and then the feeling of flying their limbs. Of course, the mine has no such guarantees, unlike the modified Molotov cocktail, but the USSR mine will never let you down and will definitely find its zombie!";

            //!Ник игрока
            EditName[0].text = "Enter name";
            EditName[1].text = "Username";
            EditName[2].text = "Save";
            EditName[3].text = "Invalid format";
            EditName[4].text = "Username and should be at least 4 characters long";

            //! Цена
            Price[0].text = "Special offer!";
            Price[1].text = "11 $";
            Price[2].text = "6 $";
            Price[3].text = "Buy";
            Price[4].text = "0.98 $";
            Price[5].text = "2.45 $";
            Price[6].text = "5.9 $";
            Price[7].text = "11 $";

            Price[8].text = "0.98 $";
            Price[9].text = "2.45 $";
            Price[10].text = "5.9 $";
            Price[11].text = "11 $";
            Price[12].text = "Play";
            Price[13].text = "Play";

            //! Подсказки

            Loading[0].text = "Tap the screen...";
            Loading[1].text = "Buy new weapons in the store and do not forget to improve them. To select a purchased weapon, click the green button next to it in the store.";
            Loading[2].text = "Upgrade your character to get more gold coins.";
            Loading[3].text = "Watch the ads to get free gold coins, and don't forget about the daily prizes. You will get 1000 gold coins for 1 ad view.";
            Loading[4].text = "Aim for the head to do more damage.";
            Loading[5].text = "To use a bomb, simply move it to the road in the place where you want it to explode.";

            //! В сцене игры
            GameMain[0] = "";
            //!Рейтинг 
            Rating[0].text = "Топ 10 week";
            Rating[1].text = "Топ 10";
        }
    }
}