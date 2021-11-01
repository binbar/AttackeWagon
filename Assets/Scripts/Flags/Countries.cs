using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countries : MonoBehaviour {

    // public string c;

    // Start is called before the first frame update
    public GameObject Countrie_obj; //Префаб флага

    public GameObject FlagsPlace; //Место куда добавлять флаги
    public GameObject FlagsTab; //Окно с выбором флага

    public List<CountryDataSet> AllCountries = new List<CountryDataSet> ();
    //public Sprite spriteTest;
    public DB DB_script;
    public Info Info_script;
    //Установить флаг по тегу
    public void SetFalgByTag (string Tag_Flag) {
        Debug.Log ("Установлен флаг с тегом " + Tag_Flag);
        PlayerPrefs.SetString ("Player_Flag", "" + Tag_Flag);
        DB_script.SetCountry (Tag_Flag);
        Info_script.Draw_flag ();
        FlagsTab.SetActive(false);
    }

    //Заспавнить ячейку с флагом("кнопку")
    void SpawnFlagBar (string Tag_Flag, string NameCountry) {

        GameObject Spawned_Countrie_obj = Instantiate (Countrie_obj, FlagsPlace.transform);

        //* Спрайт ////////
        //    Sprite sprite = Resources.Load<Sprite> ("Countries/" + Tag_Flag); //Берем флаг(картинку) из ресурсов(файлов)
        Sprite sprite = CountrySprite (Tag_Flag);

        if (sprite == null) {
            Debug.Log ("Ошибка где название государства= " + NameCountry + "  ТЕГ= " + Tag_Flag); //Проверка есть ли картинка флага
        }
        Spawned_Countrie_obj.gameObject.transform.GetChild (0).GetComponent<Image> ().sprite = sprite; //Установка картинки
        //* Спрайт ////////
        Spawned_Countrie_obj.gameObject.transform.GetChild (1).GetComponent<Text> ().text = "" + NameCountry; //Название страны

        Spawned_Countrie_obj.gameObject.transform.GetChild (2).GetComponent<Flag_Button> ().Countries_script = this; //Установка ссылки на скрипт
        Spawned_Countrie_obj.gameObject.transform.GetChild (2).GetComponent<Flag_Button> ().FlagTag = "" + Tag_Flag; //Установка тега флага

    }

    public Sprite CountrySprite (string Tag_Flag) {
        Debug.Log ("Tag_Flag:" + Tag_Flag);
        Sprite FlagImg = Resources.Load<Sprite> ("Countries/" + Tag_Flag);
        if (FlagImg == null) {
            FlagImg = Resources.Load<Sprite> ("Countries/AAAA");
        }

        return FlagImg; //Берем флаг(картинку) из ресурсов(файлов)

    }

    void Start () {

        Install_flags ();
        for (int i = 0; i < AllCountries.Count; i++) {
            SpawnFlagBar (AllCountries[i].Data[0], AllCountries[i].Data[1]); //Тег и название государства  
        }
    }

    void Install_flags () {

       // AllCountries.Add (new CountryDataSet (new string[] { "ABKHAZIA", "Abkhazia", "Абхазия" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AD", "Andorra", "Андорра", "AND", "20" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AE", "United Arab Emirates", "Объединённые Арабские Эмираты", "ARE", "784" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AF", "Afghanistan", "Афганистан", "AFG", "4" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AG", "Antigua and Barbuda", "Антигуа и Барбуда", "ATG", "28" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AI", "Anguilla", "Ангилья", "AIA", "660" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AL", "Albania", "Албания", "ALB", "8" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AM", "Armenia", "Армения", "ARM", "51" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AN", "Netherlands Antilles", "Нидерландские Антилы", "ANT", "530" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AO", "Angola", "Ангола", "AGO", "24" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AQ", "Antarctica", "Антарктида", "ATA", "10" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AR", "Argentina", "Аргентина", "ARG", "32" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AS", "American Samoa", "Американское Самоа", "ASM", "16" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AT", "Austria", "Австрия", "AUT", "40" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AU", "Australia", "Австралия", "AUS", "36" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AW", "Aruba", "Аруба", "ABW", "533" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AX", "Aland Islands", "Эландские острова", "ALA", "248" }));
        AllCountries.Add (new CountryDataSet (new string[] { "AZ", "Azerbaijan", "Азербайджан", "AZE", "31" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BA", "Bosnia and Herzegovina", "Босния и Герцеговина", "BIH", "70" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BB", "Barbados", "Барбадос", "BRB", "52" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BD", "Bangladesh", "Бангладеш", "BGD", "50" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BE", "Belgium", "Бельгия", "BEL", "56" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BF", "Burkina Faso", "Буркина Фасо", "BFA", "854" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BG", "Bulgaria", "Болгария", "BGR", "100" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BH", "Bahrain", "Бахрейн", "BHR", "48" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BI", "Burundi", "Бурунди", "BDI", "108" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BJ", "Benin", "Бенин", "BEN", "204" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BL", "Saint Barthelemy", "Сен-Бартельми", "BLM", "652" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BM", "Bermuda", "Бермуды", "BMU", "60" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BN", "Brunei", "Бруней", "BRN", "96" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BO", "Bolivia", "Боливия", "BOL", "68" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BR", "Brazil", "Бразилия", "BRA", "76" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BS", "Bahamas", "Багамы", "BHS", "44" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BT", "Bhutan", "Бутан", "BTN", "64" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BV", "Bouvet Island", "Остров Буве", "BVT", "74" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BW", "Botswana", "Ботсвана", "BWA", "72" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BY", "Belarus", "Беларусь", "BLR", "112" }));
        AllCountries.Add (new CountryDataSet (new string[] { "BZ", "Belize", "Белиз", "BLZ", "84" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CA", "Canada", "Канада", "CAN", "124" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CC", "Cocos (Keeling) Islands", "Кокосовые (Килинг) острова", "CCK", "166" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CD", "Congo (Democratic Republic)", "Конго (Демократическая Республика)", "COD", "180" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CF", "Central African Republic", "Центральноафриканская Республика", "CAF", "140" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CG", "Congo", "Конго", "COG", "178" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CH", "Switzerland", "Швейцария", "CHE", "756" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CI", "Cote d’Ivoire", "Кот-д’Ивуар", "CIV", "384" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CK", "Cook Islands", "Острова Кука", "COK", "184" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CL", "Chile", "Чили", "CHL", "152" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CM", "Cameroon", "Камерун", "CMR", "120" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CN", "China", "Китай", "CHN", "156" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CO", "Colombia", "Колумбия", "COL", "170" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CR", "Costa Rica", "Коста-Рика", "CRI", "188" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CU", "Cuba", "Куба", "CUB", "192" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CV", "Cape Verde", "Кабо-Верде", "CPV", "132" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CX", "Christmas Island", "Остров Рождества", "CXR", "162" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CY", "Cyprus", "Кипр", "CYP", "196" }));
        AllCountries.Add (new CountryDataSet (new string[] { "CZ", "Czech Republic", "Чехия", "CZE", "203" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DE", "Germany", "Германия", "DEU", "276" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DJ", "Djibouti", "Джибути", "DJI", "262" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DK", "Denmark", "Дания", "DNK", "208" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DM", "Dominica", "Доминика", "DMA", "212" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DO", "Dominican Republic", "Доминиканская Республика", "DOM", "214" }));
        AllCountries.Add (new CountryDataSet (new string[] { "DZ", "Algeria", "Алжир", "DZA", "12" }));
        AllCountries.Add (new CountryDataSet (new string[] { "EC", "Ecuador", "Эквадор", "ECU", "218" }));
        AllCountries.Add (new CountryDataSet (new string[] { "EE", "Estonia", "Эстония", "EST", "233" }));
        AllCountries.Add (new CountryDataSet (new string[] { "EG", "Egypt", "Египет", "EGY", "818" }));
        AllCountries.Add (new CountryDataSet (new string[] { "EH", "Western Sahara", "Западная Сахара", "ESH", "732" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ER", "Eritrea", "Эритрея", "ERI", "232" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ES-CE", "Ceuta", "Сеута" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ES-ML", "Melilla", "Мельлия" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ES", "Spain", "Испания", "ESP", "724" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ET", "Ethiopia", "Эфиопия", "ETH", "231" }));
        AllCountries.Add (new CountryDataSet (new string[] { "EU", "European Union", "Евросоюз" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FI", "Finland", "Финляндия", "FIN", "246" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FJ", "Fiji", "Фиджи", "FJI", "242" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FK", "Falkland Islands (Malvinas)", "Фолклендские острова (Мальвинские)", "FLK", "238" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FM", "Micronesia", "Микронезия", "FSM", "583" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FO", "Faroe Islands", "Фарерские острова", "FRO", "234" }));
        AllCountries.Add (new CountryDataSet (new string[] { "FR", "France", "Франция", "FRA", "250" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GA", "Gabon", "Габон", "GAB", "266" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GB", "United Kingdom", "Великобритания", "GBR", "826" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GD", "Grenada", "Гренада", "GRD", "308" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GE", "Georgia", "Грузия", "GEO", "268" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GF", "French Guiana", "Французская Гвиана", "GUF", "254" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GG", "Guernsey", "Гернси", "GGY", "831" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GH", "Ghana", "Гана", "GHA", "288" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GI", "Gibraltar", "Гибралтар", "GIB", "292" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GL", "Greenland", "Гренландия", "GRL", "304" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GM", "Gambia", "Гамбия", "GMB", "270" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GN", "Guinea", "Гвинея", "GIN", "324" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GP", "Guadeloupe", "Гваделупа", "GLP", "312" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GQ", "Equatorial Guinea", "Экваториальная Гвинея", "GNQ", "226" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GR", "Greece", "Греция", "GRC", "300" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GS", "South Georgia and the South Sandwich Islands", "Южная Джорджия и Южные Сандвичевы острова", "SGS", "239" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GT", "Guatemala", "Гватемала", "GTM", "320" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GU", "Guam", "Гуам", "GUM", "316" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GW", "Guinea-Bissau", "Гвинея-Бисау", "GNB", "624" }));
        AllCountries.Add (new CountryDataSet (new string[] { "GY", "Guyana", "Гайана", "GUY", "328" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HK", "Hong Kong", "Гонконг", "HKG", "344" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HM", "Heard Island and McDonald Islands", "Остров Херд и острова Макдональд", "HMD", "334" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HN", "Honduras", "Гондурас", "HND", "340" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HR", "Croatia", "Хорватия", "HRV", "191" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HT", "Haiti", "Гаити", "HTI", "332" }));
        AllCountries.Add (new CountryDataSet (new string[] { "HU", "Hungary", "Венгрия", "HUN", "348" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IC", "Canary Islands", "Канарские острова" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ID", "Indonesia", "Индонезия", "IDN", "360" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IE", "Ireland", "Ирландия", "IRL", "372" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IL", "Israel", "Израиль", "ISR", "376" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IM", "Isle of Man", "Остров Мэн", "IMN", "833" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IN", "India", "Индия", "IND", "356" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IO", "British Indian Ocean Territory", "Британская территория в Индийском океане", "IOT", "86" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IQ", "Iraq", "Ирак", "IRQ", "368" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IR", "Iran", "Иран", "IRN", "364" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IS", "Iceland", "Исландия", "ISL", "352" }));
        AllCountries.Add (new CountryDataSet (new string[] { "IT", "Italy", "Италия", "ITA", "380" }));
        AllCountries.Add (new CountryDataSet (new string[] { "JE", "Jersey", "Джерси", "JEY", "832" }));
        AllCountries.Add (new CountryDataSet (new string[] { "JM", "Jamaica", "Ямайка", "JAM", "388" }));
        AllCountries.Add (new CountryDataSet (new string[] { "JO", "Jordan", "Иордания", "JOR", "400" }));
        AllCountries.Add (new CountryDataSet (new string[] { "JP", "Japan", "Япония", "JPN", "392" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KE", "Kenya", "Кения", "KEN", "404" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KG", "Kyrgyzstan", "Киргизия", "KGZ", "417" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KH", "Cambodia", "Камбоджа", "KHM", "116" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KI", "Kiribati", "Кирибати", "KIR", "296" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KM", "Comoros", "Коморы", "COM", "174" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KN", "Saint Kitts and Nevis", "Сент-Китс и Невис", "KNA", "659" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KOSOVO", "Kosovo", "Косово" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KP", "North Korea", "Северная Корея", "PRK", "408" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KR", "South Korea", "Южная Корея", "KOR", "410" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KW", "Kuwait", "Кувейт", "KWT", "414" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KY", "Cayman Islands", "Острова Кайман", "CYM", "136" }));
        AllCountries.Add (new CountryDataSet (new string[] { "KZ", "Kazakhstan", "Казахстан", "KAZ", "398" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LA", "Laos", "Лаос", "LAO", "418" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LB", "Lebanon", "Ливан", "LBN", "422" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LC", "Saint Lucia", "Сент-Люсия", "LCA", "662" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LI", "Liechtenstein", "Лихтенштейн", "LIE", "438" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LK", "Sri Lanka", "Шри-Ланка", "LKA", "144" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LR", "Liberia", "Либерия", "LBR", "430" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LS", "Lesotho", "Лесото", "LSO", "426" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LT", "Lithuania", "Литва", "LTU", "440" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LU", "Luxembourg", "Люксембург", "LUX", "442" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LV", "Latvia", "Латвия", "LVA", "428" }));
        AllCountries.Add (new CountryDataSet (new string[] { "LY", "Libya", "Ливия", "LBY", "434" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MA", "Morocco", "Марокко", "MAR", "504" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MC", "Monaco", "Монако", "MCO", "492" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MD", "Moldova", "Молдова", "MDA", "498" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ME", "Montenegro", "Черногория", "MNE", "499" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MF", "Saint Martin", "Остров Святого Мартина", "MAF", "663" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MG", "Madagascar", "Мадагаскар", "MDG", "450" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MH", "Marshall Islands", "Маршалловы острова", "MHL", "584" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MK", "Macedonia", "Македония", "MKD", "807" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ML", "Mali", "Мали", "MLI", "466" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MM", "Myanmar", "Мьянма", "MMR", "104" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MN", "Mongolia", "Монголия", "MNG", "496" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MO", "Macao", "Макао", "MAC", "446" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MP", "Northern Mariana Islands", "Северные Марианские острова", "MNP", "580" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MQ", "Martinique", "Мартиника", "MTQ", "474" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MR", "Mauritania", "Мавритания", "MRT", "478" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MS", "Montserrat", "Монтсеррат", "MSR", "500" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MT", "Malta", "Мальта", "MLT", "470" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MU", "Mauritius", "Маврикий", "MUS", "480" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MV", "Maldives", "Мальдивы", "MDV", "462" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MW", "Malawi", "Малави", "MWI", "454" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MX", "Mexico", "Мексика", "MEX", "484" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MY", "Malaysia", "Малайзия", "MYS", "458" }));
        AllCountries.Add (new CountryDataSet (new string[] { "MZ", "Mozambique", "Мозамбик", "MOZ", "508" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NA", "Namibia", "Намибия", "NAM", "516" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NC", "New Caledonia", "Новая Каледония", "NCL", "540" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NE", "Niger", "Нигер", "NER", "562" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NF", "Norfolk Island", "Остров Норфолк", "NFK", "574" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NG", "Nigeria", "Нигерия", "NGA", "566" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NI", "Nicaragua", "Никарагуа", "NIC", "558" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NKR", "Nagorno-Karabakh Republic", "Нагорно-Карабахская Республика" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NL", "Netherlands", "Нидерланды", "NLD", "528" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NO", "Norway", "Норвегия", "NOR", "578" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NP", "Nepal", "Непал", "NPL", "524" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NR", "Nauru", "Науру", "NRU", "520" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NU", "Niue", "Ниуэ", "NIU", "570" }));
        AllCountries.Add (new CountryDataSet (new string[] { "NZ", "New Zealand", "Новая Зеландия", "NZL", "554" }));
        AllCountries.Add (new CountryDataSet (new string[] { "OM", "Oman", "Оман", "OMN", "512" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PA", "Panama", "Панама", "PAN", "591" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PE", "Peru", "Перу", "PER", "604" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PF", "French Polynesia", "Французская Полинезия", "PYF", "258" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PG", "Papua New Guinea", "Папуа-Новая Гвинея", "PNG", "598" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PH", "Philippines", "Филиппины", "PHL", "608" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PK", "Pakistan", "Пакистан", "PAK", "586" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PL", "Poland", "Польша", "POL", "616" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PM", "Saint Pierre and Miquelon", "Сен-Пьер и Микелон", "SPM", "666" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PN", "Pitcairn", "Питкерн", "PCN", "612" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PR", "Puerto Rico", "Пуэрто-Рико", "PRI", "630" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PS", "Palestinian Territory", "Палестинская автономия", "PSE", "275" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PT", "Portugal", "Португалия", "PRT", "620" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PW", "Palau", "Палау", "PLW", "585" }));
        AllCountries.Add (new CountryDataSet (new string[] { "PY", "Paraguay", "Парагвай", "PRY", "600" }));
        AllCountries.Add (new CountryDataSet (new string[] { "QA", "Qatar", "Катар", "QAT", "634" }));
        AllCountries.Add (new CountryDataSet (new string[] { "RE", "Reunion", "Реюньон", "REU", "638" }));
        AllCountries.Add (new CountryDataSet (new string[] { "RO", "Romania", "Румыния", "ROM", "642" }));
        AllCountries.Add (new CountryDataSet (new string[] { "RS", "Serbia", "Сербия", "SRB", "688" }));
        AllCountries.Add (new CountryDataSet (new string[] { "RU", "Russian Federation", "Россия", "RUS", "643" }));
        AllCountries.Add (new CountryDataSet (new string[] { "RW", "Rwanda", "Руанда", "RWA", "646" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SA", "Saudi Arabia", "Саудовская Аравия", "SAU", "682" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SB", "Solomon Islands", "Соломоновы острова", "SLB", "90" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SC", "Seychelles", "Сейшелы", "SYC", "690" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SD", "Sudan", "Судан", "SDN", "736" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SE", "Sweden", "Швеция", "SWE", "752" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SG", "Singapore", "Сингапур", "SGP", "702" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SH", "Saint Helena", "Святая Елена", "SHN", "654" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SI", "Slovenia", "Словения", "SVN", "705" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SJ", "Svalbard and Jan Mayen", "Шпицберген и Ян Майен", "SJM", "744" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SK", "Slovakia", "Словакия", "SVK", "703" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SL", "Sierra Leone", "Сьерра-Леоне", "SLE", "694" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SM", "San Marino", "Сан-Марино", "SMR", "674" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SN", "Senegal", "Сенегал", "SEN", "686" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SO", "Somalia", "Сомали", "SOM", "706" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SOUTH-OSSETIA", "South Ossetia", "Южная Осетия" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SR", "Suriname", "Суринам", "SUR", "740" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SS", "South Sudan", "Южный Судан", "SSD", "728" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ST", "Sao Tome and Principe", "Сан-Томе и Принсипи", "STP", "678" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SV", "El Salvador", "Эль-Сальвадор", "SLV", "222" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SY", "Syrian Arab Republic", "Сирийская Арабская Республика", "SYR", "760" }));
        AllCountries.Add (new CountryDataSet (new string[] { "SZ", "Swaziland", "Свазиленд", "SWZ", "748" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TC", "Turks and Caicos Islands", "Острова Теркс и Кайкос", "TCA", "796" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TD", "Chad", "Чад", "TCD", "148" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TF", "French Southern Territories", "Французские Южные территории", "ATF", "260" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TG", "Togo", "Того", "TGO", "768" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TH", "Thailand", "Таиланд", "THA", "764" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TJ", "Tajikistan", "Таджикистан", "TJK", "762" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TK", "Tokelau", "Токелау", "TKL", "772" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TL", "Timor-Leste", "Тимор-Лесте", "TLS", "626" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TM", "Turkmenistan", "Туркмения", "TKM", "795" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TN", "Tunisia", "Тунис", "TUN", "788" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TO", "Tonga", "Тонга", "TON", "776" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TR", "Turkey", "Турция", "TUR", "792" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TT", "Trinidad and Tobago", "Тринидад и Тобаго", "TTO", "780" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TV", "Tuvalu", "Тувалу", "TUV", "798" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TW", "Taiwan", "Тайвань", "TWN", "158" }));
        AllCountries.Add (new CountryDataSet (new string[] { "TZ", "Tanzania", "Танзания", "TZA", "834" }));
        AllCountries.Add (new CountryDataSet (new string[] { "UA", "Ukraine", "Украина", "UKR", "804" }));
        AllCountries.Add (new CountryDataSet (new string[] { "UG", "Uganda", "Уганда", "UGA", "800" }));
        AllCountries.Add (new CountryDataSet (new string[] { "UM", "United States Minor Outlying Islands", "Малые Тихоокеанские отдаленные острова Соединенных Штатов", "UMI", "581" }));
        AllCountries.Add (new CountryDataSet (new string[] { "US", "United States", "Соединенные Штаты Америки", "USA", "840" }));
        AllCountries.Add (new CountryDataSet (new string[] { "UY", "Uruguay", "Уругвай", "URY", "858" }));
        AllCountries.Add (new CountryDataSet (new string[] { "UZ", "Uzbekistan", "Узбекистан", "UZB", "860" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VA", "Holy See (Vatican)", "Папский Престол (Ватикан)", "VAT", "336" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VC", "Saint Vincent and the Grenadines", "Сент-Винсент и Гренадины", "VCT", "670" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VE", "Venezuela", "Венесуэла", "VEN", "862" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VG", "Virgin Islands (British)", "Виргинские острова (Британские)", "VGB", "92" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VI", "Virgin Islands (U.S.)", "Виргинские острова (США)", "VIR", "850" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VN", "Viet Nam", "Вьетнам", "VNM", "704" }));
        AllCountries.Add (new CountryDataSet (new string[] { "VU", "Vanuatu", "Вануату", "VUT", "548" }));
        AllCountries.Add (new CountryDataSet (new string[] { "WF", "Wallis and Futuna", "Уоллис и Футуна", "WLF", "876" }));
        AllCountries.Add (new CountryDataSet (new string[] { "WS", "Samoa", "Самоа", "WSM", "882" }));
        AllCountries.Add (new CountryDataSet (new string[] { "YE", "Yemen", "Йемен", "YEM", "887" }));
        AllCountries.Add (new CountryDataSet (new string[] { "YT", "Mayotte", "Майотта", "MYT", "175" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ZA", "South Africa", "Южная Африка", "ZAF", "710" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ZM", "Zambia", "Замбия", "ZMB", "894" }));
        AllCountries.Add (new CountryDataSet (new string[] { "ZW", "Zimbabwe", "Зимбабве", "ZWE", "716" }));

    }

    [System.Serializable]
    public class CountryDataSet {
        public string[] Data;
        public CountryDataSet (string[] Data) {
            this.Data = Data;
        }
    }

}