using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

[System.Serializable]
public class TopInfo {
    public string User_name;
    public string User_rating_all;
    public string User_rating_week;
    public string User_rating_all_rank_pos;
    public string User_rating_week_rank_pos;

    public string User_country;
    public int Server_time;

    public User_r[] top_all = new User_r[10];
    public User_r[] top_week = new User_r[10];

}

[System.Serializable]
public class User_r {
    public string name;
    public string rating;
    public string country;
}

public class DB : MonoBehaviour {
    public GameObject SpecialOffer;
    public GameObject buttonOfeer;
    public GameObject Window_bonus;
    public AdsManager _adsManager;
    public GameObject InfoFirstStart;
    public GameObject Active_reward;
    public GameObject Disabled_reward;
    public Info info_top_panel;
    TopInfo top = new TopInfo ();
    public GameObject TopUI_obj;
    public string reward;
    public string DR_adress;
    const string words = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want
    public string Generate_seed () {
        int charAmount = 16; //set those to the minimum and maximum length of your string
        string seed = "";
        for (int i = 0; i < charAmount; i++) {
            seed += words[Random.Range (0, words.Length)];
        }
        seed += "_" + CalculateMD5Hash (System.DateTime.Now.ToString ("hh:mm:ss"));
        return seed;
    }
    public string Generate_random_name () {
        int charAmount = 5; //set those to the minimum and maximum length of your string
        string random_name = "USER_";
        for (int i = 0; i < charAmount; i++) {
            random_name += words[Random.Range (0, words.Length)];
        }
        //  seed += "_" + CalculateMD5Hash (System.DateTime.Now.ToString ("hh:mm:ss"));
        return random_name;
    }

    private readonly string URL = "http://azbukagames.ru/";

    //Регистрация аккаунта и подтверждение
    public void RequestRegistration () {
        WWW link_req = new WWW (URL + "reg.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player"));
        StartCoroutine (ReqRegistration (link_req));
    }

    private IEnumerator ReqRegistration (WWW request) {
        yield return request;
        //  Debug.Log ("[ReqRegistration] Ответ сервера:" + request.text);
        if (request.text == ("REGISTERED=" + PlayerPrefs.GetString ("seed_player"))) { //Если успешно зарегестрирован
            PlayerPrefs.SetString ("register", "ok"); //Записываем регистрацию чтоб не вызывать регистрацию снова
            //    Debug.Log ("Регистрация прошла успешно");
        } else {
            //     Debug.Log ("Пользователь не зарегестрирован,ошибка");
        }
    }

    public void SetName (string name) {
        Debug.Log ("SetName=" + name);
        //  Debug.Log ("Смена имени");
        WWW link_req = new WWW (URL + "name_set.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player") + "&name=" + name);
        Debug.Log ("LINK SET NAME=" + URL + "name_set.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player") + "&name=" + name);
        StartCoroutine (SetNameReq (link_req));
    }

    private IEnumerator SetNameReq (WWW request) {
        Debug.Log ("SetNameReq");
        yield return request;
        // Debug.Log ("[SetNameReq] Ответ сервера:" + request.text);
    }

    //Установка рейтинга
    public void SetRating (int rating) {

        string new_rating = Encode_string ("" + rating); //Шифрование рейтинга
        Debug.Log ("Рейтинг отослан");
        WWW link_req = new WWW (URL + "set_rating.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player") + "&rating=" + new_rating);
        StartCoroutine (SetRatingReq (link_req));
    }

    private IEnumerator SetRatingReq (WWW request) {
        yield return request;
        Debug.Log ("[SetRating] Ответ сервера:" + request.text);

    }

    //Получение имени с сервера и запись в плеер префс
    public void GetName () {
        // Debug.Log ("Получение имени с сервера и запись в плеер префс");
        WWW link_req = new WWW (URL + "name_get.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player"));
        StartCoroutine (GetNameReq (link_req));
    }

    private IEnumerator GetNameReq (WWW request) {
        yield return request;
        Debug.Log ("[GetNameReq] Ответ сервера:" + request.text);
        if (request.text != "") {
            PlayerPrefs.SetString ("User_name", "" + request.text); //Записываем регистрацию чтоб не вызывать регистрацию снова
            //    Debug.Log ("Имя получено с сервера и записано,имя=" + request.text);
        } else {
            //    Debug.Log ("Ошибка,сервер вернул пустой ответ");
        }
    }

    public void GetTop () {
        //  Debug.Log ("Получение топа с сервера");
        WWW link_req = new WWW (URL + "top_rating_and_my.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player"));
        StartCoroutine (GetTopReq (link_req));
    }

    private IEnumerator GetTopReq (WWW request) {
        yield return request;
        // Debug.Log ("[GetTopReq] Ответ сервера:" + request.text);
        top = Zconv_json_to_object (request.text);
        // Не успевает загрузить данные в корутине
        //Debug.Log ("top name=" + top.User_name);
        // Debug.Log ("top=" + top.User_rating);

        TopUI_obj.GetComponent<TopUI> ().top = top;
        TopUI_obj.GetComponent<TopUI> ().GetDataTops (); //Вызов отрисовки в другом скрипте

        foreach (User_r item in top.top_all) {
            //  Debug.Log ("####" + item.name);
        }

    }

    public string CalculateMD5Hash (string input) {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create ();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes (input);
        byte[] hash = md5.ComputeHash (inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder ();
        for (int i = 0; i < hash.Length; i++) {
            sb.Append (hash[i].ToString ("X2"));
        }
        return sb.ToString ();
    }

    public void Register () {
        if (PlayerPrefs.GetString ("seed_player") == "") {
            PlayerPrefs.SetString ("seed_player", Generate_seed ());
            //    Debug.Log ("Сид был ПУСТЫМ,теперь он создан и сохранен локально");
        }

        if (PlayerPrefs.GetString ("register") != "ok") { //Если не зарегестрировались
            //  Debug.Log ("Попытка регистрации");
            RequestRegistration ();
        } else {
            //  Debug.Log ("Вы уже зарегестрировались и подтвердили регистрацию");
        }
    }

    //Дополнительная функция для теста
    private void CopyText (string textToCopy) {
        TextEditor editor = new TextEditor {
            text = textToCopy
        };
        editor.SelectAll ();
        editor.Copy ();
    }

    public static string Zconv_object_to_json (TopInfo obj) { // Преобразовать обьект в json
        string obj_string = JsonUtility.ToJson (obj); //Сериализация в Json
        return obj_string; //Json строка
    }

    public static TopInfo Zconv_json_to_object (string text) { // Преобразовать json в обьект
        TopInfo obj = JsonUtility.FromJson<TopInfo> (text); //Десериализация в обьект
        return obj; //Возврат обьекта
    }

    /*
        [System.Serializable]
        public class TopInfo {
            public string User_name;
            public string User_rating;

            public User_r[] top_all = new User_r[10];
            public User_r[] top_week = new User_r[10];

        }

        [System.Serializable]
        public class User_r {
            public string name;
            public string rating;
        }
    */
    //   private readonly string URL = "http://azbukagames.ru/";

    public void GetDailyReward () {
        //  Debug.Log ("Получение даты");
        WWW link_req = new WWW (URL + "date.php");
        StartCoroutine (GetDailyRewardReq (link_req));
    }

    private IEnumerator GetDailyRewardReq (WWW request) {
        yield return request;
        //Debug.Log ("[GetDailyRewardReq] Ответ сервера[ДАТА]:" + request.text);
        if (request.text == "") {
            //     RewardState ("NoConnection");
            reward = "NoConnection";
        } else {
            string validate_format = request.text.Replace (".", "");
            if (isint (validate_format)) //Формат даты верный
            {
                //  Debug.Log ("OK FORMAT");
                string day = "";
                string month = "";
                string year = "";

                string stage = "D";
                for (int i = 0; i < request.text.Length; i++) {

                    if (stage == "D") {
                        if (isint (request.text[i] + "")) {
                            day += request.text[i];
                        } else {
                            //  Debug.Log ("Go TO M");
                            i++;
                            stage = "M";
                        }
                    }

                    if (stage == "M") {
                        if (isint (request.text[i] + "")) {
                            month += request.text[i];
                        } else {
                            i++;
                            stage = "Y";
                        }
                    }

                    if (stage == "Y") {
                        if (isint (request.text[i] + "")) {
                            year += request.text[i];
                        }
                    }

                }

                // Debug.Log ("Day=" + day + " Month" + month + " Year=" + year);

                string DR = "Daily_reward_" + day + "_" + month + "_" + year; //Строка с датой для проверки в плеер префс

                //"True" можно получить,"Given" нельзя получить,уже получена "NoConnection" нет интернет ссоединения
                if (PlayerPrefs.GetString (DR) != "Given") {
                    //   PlayerPrefs.SetString (DR, "Given"); //Вынести зачисление награды
                    //    RewardState ("True"); //Можно получить награду
                    reward = "True";
                    DR_adress = DR;

                    //PlayerPrefs.SetString ("SOME COIN","Given");//Выдача награды
                    //Обновить UI
                    // Debug.Log ("Ежедневная награда успешно получена");
                } else {
                    //     RewardState ("Given"); //Можно получить награду
                    reward = "Given";

                    //    Debug.Log ("Невозможно получить ежедневную награду,она уже была выдана сегодня");
                }

            } else {
                //   Debug.Log ("ERROR FORMAT");
            }
        }
        RewardState_bot_status ();
    }

    bool isint (string some_text) {
        int some_null_int_var;
        if (some_text == ".") {
            return false;
        } else {
            return Int32.TryParse (some_text, out some_null_int_var);

        }
    }

    public void RewardState () { //Кнопка
        //Выдача награды(можно получить)
        if (reward == "True") {
            //  Debug.Log ("Награда только что выдана");

            Active_reward.SetActive (false);
            Disabled_reward.SetActive (true);

            PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 350)); //Выдать монетку
            PlayerPrefs.SetInt ("Tooth", (PlayerPrefs.GetInt ("Tooth") + 100)); //Выдать зуб

            PlayerPrefs.SetString (DR_adress, "Given"); //Вынести зачисление награды
            info_top_panel.Draw_money (); //Обновить UI с валютами
            Window_bonus.SetActive (true);
        }

        //Награда получена
        if (reward == "Given") {

            // Debug.Log ("Невозможно получить ежедневную награду,она уже была выдана сегодня");
        }

        //Нет ссоединения
        if (reward == "NoConnection") {
            //  Debug.Log ("Не ссоединения с сервером");

        }
        //Идёт получение данных с сервера
        if (reward == "GettingDate") {
            //  Debug.Log ("Идёт получение данных с сервера");

        }
    }

    public void RewardState_bot_status () {
        // Debug.Log ("RewardState_bot_status#### reward=" + reward);
        //Выдача награды(можно получить)
        if (reward == "True") {
            Active_reward.SetActive (true);
            //
            //  PlayerPrefs.SetString (DR_adress, "Given"); //Вынести зачисление награды
        }

        //Награда получена
        if (reward == "Given") {
            Disabled_reward.SetActive (true);
        }

        //Нет ссоединения
        if (reward == "NoConnection") {
            Disabled_reward.SetActive (true);
        }
        //Идёт получение данных с сервера
        if (reward == "GettingDate") {

        }

    }

    //Установка страны
    public void SetCountry (string country) {
        WWW link_req = new WWW (URL + "set_country.php" + "?seed_player=" + PlayerPrefs.GetString ("seed_player") + "&country=" + country);
        StartCoroutine (SetCountryReq (link_req));
    }

    private IEnumerator SetCountryReq (WWW request) {
        yield return request;
    }

    //! Шифрование данных
    string Encode_string (string input) {
        string data = Base64Encode (input);;

        input = MD5_HASH (input);
        input = Reverse (input);
        input = MD5_HASH (input);

        data += "_" + input;
        return data;
    }

    string MD5_HASH (string input) {
        string hash = BitConverter.ToString (MD5.Create ().ComputeHash (Encoding.ASCII.GetBytes ("" + input))).Replace ("-", "");
        hash = hash.ToLower ();
        return hash;
    }

    public static string Reverse (string s) {
        char[] charArray = s.ToCharArray ();
        Array.Reverse (charArray);
        return new string (charArray);
    }

    public static string Base64Encode (string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes (plainText);
        return System.Convert.ToBase64String (plainTextBytes);
    }
    //////////////////////////////////////////////////////

    public void First_start () {
        if (PlayerPrefs.GetString ("First_start_func") != "OK") {
            Debug.Log ("Первый старт,установка параметров");
            PlayerPrefs.SetInt ("" + 6, 200); //ид 6 патронов(оружия с ид 0),200 патронов  
            PlayerPrefs.SetString ("Transport", "Povozka"); //Транспорт

            PlayerPrefs.SetString ("First_start_func", "OK");
            PlayerPrefs.SetString ("Level_" + 1, "open");
            // SetName(Generate_random_name());
            Invoke ("FirstSetName", 1f);
            InfoFirstStart.SetActive (true);
        }
    }

    void FirstSetName () {
        SetName (Generate_random_name ());
    }

    void Start () {
        Register (); //РАНЬШЕ БЫЛО ПОСЛЕ First_start() И ДО         GetName ();!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        First_start ();

        //  reward = "GettingDate";
        //  GetDailyReward();

        if (Active_reward != null) {
            reward = "GettingDate";
            GetDailyReward ();
        } else {
            //            Debug.Log ("NO main MENU");
        }

        GetName ();

        InvokeRepeating ("GetName", 2, 5F);

        // Если мы в меню
        if (!(GameObject.FindGameObjectsWithTag ("Povozka").Length > 0)) {
            if (PlayerPrefs.GetInt ("Opened_levels_AD") >= 3) {
                _adsManager.ShowInterstitial ();
                PlayerPrefs.SetInt ("Opened_levels_AD", 0);
            }

            if (PlayerPrefs.GetInt ("Opened_levels_AD") >= 3) {
                _adsManager.ShowInterstitial ();
                Debug.Log ("Показываю рекламу DB");
                PlayerPrefs.SetInt ("Opened_levels_AD", 0);
            }
            if (PlayerPrefs.GetInt ("Count_Opened_levels") >= 7) {
                SpecialOffer.SetActive (true);
                buttonOfeer.SetActive(true);
                PlayerPrefs.SetInt ("Count_Opened_levels", 0);
            }

        }


        // TopInfo top = new TopInfo ();

        //   top.User_name = "DDDDDDDDD";
        //   top.User_rating = "1000";

        //  GetTop ();

        // top.top_all[0] = new User_r { name = "test", rating = "200" };

        // top.top_all[0] = "1000";

        //  Debug.Log (Zconv_object_to_json (top));

        //   CopyText (Zconv_object_to_json (top));

        /*
                Register ();
                SetName ("1111");
                SetRating (123123);
                GetName ();
        */
        //  Clipboard.SetText ("...");

    }

}