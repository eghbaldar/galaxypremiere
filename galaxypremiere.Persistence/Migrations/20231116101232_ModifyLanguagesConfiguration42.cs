using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class ModifyLanguagesConfiguration42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 1, null, "Not Specified", "Not Specified" },
                    { 2, "aa", "Afar", "Afar" },
                    { 3, "af", "Afrikaans", "Afrikaans" },
                    { 4, "agq", "Aghem", "Aghem" },
                    { 5, "ak", "Akan", "Akan" },
                    { 6, "am", "Amharic", "አማርኛ" },
                    { 7, "ar", "Arabic", "العربية" },
                    { 8, "arn", "Mapuche", "Mapudungun" },
                    { 9, "as", "Assamese", "অসমীয়া" },
                    { 10, "asa", "Asu", "Kipare" },
                    { 11, "ast", "Asturian", "asturianu" },
                    { 12, "az", "Azerbaijani", "azərbaycan" },
                    { 13, "ba", "Bashkir", "Bashkir" },
                    { 14, "bas", "Basaa", "Ɓàsàa" },
                    { 15, "be", "Belarusian", "беларуская" },
                    { 16, "bem", "Bemba", "Ichibemba" },
                    { 17, "bez", "Bena", "Hibena" },
                    { 18, "bg", "Bulgarian", "български" },
                    { 19, "bm", "Bamanankan", "bamanakan" },
                    { 20, "bn", "Bangla", "বাংলা" },
                    { 21, "bo", "Tibetan", "བོད་སྐད་" },
                    { 22, "br", "Breton", "brezhoneg" },
                    { 23, "brx", "Bodo", "बड़ो" },
                    { 24, "bs", "Bosnian", "bosanski" },
                    { 25, "byn", "Blin", "Blin" },
                    { 26, "ca", "Catalan", "català" },
                    { 27, "ccp", "Chakma", "𑄌𑄋𑄴𑄟𑄳𑄦" },
                    { 28, "ce", "Chechen", "нохчийн" },
                    { 29, "ceb", "Cebuano", "Cebuano" },
                    { 30, "cgg", "Chiga", "Rukiga" },
                    { 31, "chr", "Cherokee", "ᏣᎳᎩ" },
                    { 32, "ckb", "Central Kurdish", "کوردیی ناوەندی" },
                    { 33, "co", "Corsican", "Corsican" },
                    { 34, "cs", "Czech", "čeština" },
                    { 35, "cu", "Church Slavic", "Church Slavic" },
                    { 36, "cy", "Welsh", "Cymraeg" },
                    { 37, "da", "Danish", "dansk" },
                    { 38, "dav", "Taita", "Kitaita" },
                    { 39, "de", "German", "Deutsch" },
                    { 40, "dje", "Zarma", "Zarmaciine" },
                    { 41, "dsb", "Lower Sorbian", "dolnoserbšćina" },
                    { 42, "dua", "Duala", "duálá" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 43, "dv", "Divehi", "Divehi" },
                    { 44, "dyo", "Jola-Fonyi", "joola" },
                    { 45, "dz", "Dzongkha", "རྫོང་ཁ" },
                    { 46, "ebu", "Embu", "Kĩembu" },
                    { 47, "ee", "Ewe", "Eʋegbe" },
                    { 48, "el", "Greek", "Ελληνικά" },
                    { 49, "en", "English", "English" },
                    { 50, "eo", "Esperanto", "esperanto" },
                    { 51, "es", "Spanish", "español" },
                    { 52, "et", "Estonian", "eesti" },
                    { 53, "eu", "Basque", "euskara" },
                    { 54, "ewo", "Ewondo", "ewondo" },
                    { 55, "fa", "Persian", "فارسی" },
                    { 56, "ff", "Fulah", "Pulaar" },
                    { 57, "fi", "Finnish", "suomi" },
                    { 58, "fil", "Filipino", "Filipino" },
                    { 59, "fo", "Faroese", "føroyskt" },
                    { 60, "fr", "French", "français" },
                    { 61, "fur", "Friulian", "furlan" },
                    { 62, "fy", "Western Frisian", "Frysk" },
                    { 63, "ga", "Irish", "Gaeilge" },
                    { 64, "gd", "Scottish Gaelic", "Gàidhlig" },
                    { 65, "gl", "Galician", "galego" },
                    { 66, "gn", "Guarani", "Guarani" },
                    { 67, "gsw", "Swiss German", "Schwiizertüütsch" },
                    { 68, "gu", "Gujarati", "ગુજરાતી" },
                    { 69, "guz", "Gusii", "Ekegusii" },
                    { 70, "gv", "Manx", "Gaelg" },
                    { 71, "ha", "Hausa", "Hausa" },
                    { 72, "haw", "Hawaiian", "ʻŌlelo Hawaiʻi" },
                    { 73, "he", "Hebrew", "עברית" },
                    { 74, "hi", "Hindi", "हिन्दी" },
                    { 75, "hr", "Croatian", "hrvatski" },
                    { 76, "hsb", "Upper Sorbian", "hornjoserbšćina" },
                    { 77, "hu", "Hungarian", "magyar" },
                    { 78, "hy", "Armenian", "հայերեն" },
                    { 79, "ia", "Interlingua", "interlingua" },
                    { 80, "id", "Indonesian", "Indonesia" },
                    { 81, "ig", "Igbo", "Asụsụ Igbo" },
                    { 82, "ii", "Yi", "ꆈꌠꉙ" },
                    { 83, "is", "Icelandic", "íslenska" },
                    { 84, "it", "Italian", "italiano" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 85, "iu", "Inuktitut", "Inuktitut" },
                    { 86, "ja", "Japanese", "日本語" },
                    { 87, "jgo", "Ngomba", "Ndaꞌa" },
                    { 88, "jmc", "Machame", "Kimachame" },
                    { 89, "jv", "Javanese", "Jawa" },
                    { 90, "ka", "Georgian", "ქართული" },
                    { 91, "kab", "Kabyle", "Taqbaylit" },
                    { 92, "kam", "Kamba", "Kikamba" },
                    { 93, "kde", "Makonde", "Chimakonde" },
                    { 94, "kea", "Kabuverdianu", "kabuverdianu" },
                    { 95, "khq", "Koyra Chiini", "Koyra ciini" },
                    { 96, "ki", "Kikuyu", "Gikuyu" },
                    { 97, "kk", "Kazakh", "қазақ тілі" },
                    { 98, "kkj", "Kako", "kakɔ" },
                    { 99, "kl", "Kalaallisut", "kalaallisut" },
                    { 100, "kln", "Kalenjin", "Kalenjin" },
                    { 101, "km", "Khmer", "ខ្មែរ" },
                    { 102, "kn", "Kannada", "ಕನ್ನಡ" },
                    { 103, "ko", "Korean", "한국어" },
                    { 104, "kok", "Konkani", "कोंकणी" },
                    { 105, "ks", "Kashmiri", "کٲشُر" },
                    { 106, "ksb", "Shambala", "Kishambaa" },
                    { 107, "ksf", "Bafia", "rikpa" },
                    { 108, "ksh", "Colognian", "Kölsch" },
                    { 109, "kw", "Cornish", "kernewek" },
                    { 110, "ky", "Kyrgyz", "кыргызча" },
                    { 111, "lag", "Langi", "Kɨlaangi" },
                    { 112, "lb", "Luxembourgish", "Lëtzebuergesch" },
                    { 113, "lg", "Ganda", "Luganda" },
                    { 114, "lkt", "Lakota", "Lakȟólʼiyapi" },
                    { 115, "ln", "Lingala", "lingála" },
                    { 116, "lo", "Lao", "ລາວ" },
                    { 117, "lrc", "Northern Luri", "لۊری شومالی" },
                    { 118, "lt", "Lithuanian", "lietuvių" },
                    { 119, "lu", "Luba-Katanga", "Tshiluba" },
                    { 120, "luo", "Luo", "Dholuo" },
                    { 121, "luy", "Luyia", "Luluhia" },
                    { 122, "lv", "Latvian", "latviešu" },
                    { 123, "mas", "Masai", "Maa" },
                    { 124, "mer", "Meru", "Kĩmĩrũ" },
                    { 125, "mfe", "Morisyen", "kreol morisien" },
                    { 126, "mg", "Malagasy", "Malagasy" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 127, "mgh", "Makhuwa-Meetto", "Makua" },
                    { 128, "mgo", "Metaʼ", "metaʼ" },
                    { 129, "mi", "Maori", "Māori" },
                    { 130, "mk", "Macedonian", "македонски" },
                    { 131, "ml", "Malayalam", "മലയാളം" },
                    { 132, "mn", "Mongolian", "монгол" },
                    { 133, "moh", "Mohawk", "Kanienʼkéha" },
                    { 134, "mr", "Marathi", "मराठी" },
                    { 135, "ms", "Malay", "Melayu" },
                    { 136, "mt", "Maltese", "Malti" },
                    { 137, "mua", "Mundang", "MUNDAŊ" },
                    { 138, "my", "Burmese", "မြန်မာ" },
                    { 139, "mzn", "Mazanderani", "مازرونی" },
                    { 140, "naq", "Nama", "Khoekhoegowab" },
                    { 141, "nb", "Norwegian Bokmål", "norsk bokmål" },
                    { 142, "nd", "North Ndebele", "isiNdebele" },
                    { 143, "nds", "Low German", "Low German" },
                    { 144, "ne", "Nepali", "नेपाली" },
                    { 145, "nl", "Dutch", "Nederlands" },
                    { 146, "nmg", "Kwasio", "Kwasio" },
                    { 147, "nn", "Norwegian Nynorsk", "nynorsk" },
                    { 148, "nnh", "Ngiemboon", "Shwóŋò ngiembɔɔn" },
                    { 149, "nqo", "N’Ko", "N’Ko" },
                    { 150, "nr", "South Ndebele", "South Ndebele" },
                    { 151, "nso", "Sesotho sa Leboa", "Sesotho sa Leboa" },
                    { 152, "nus", "Nuer", "Thok Nath" },
                    { 153, "nyn", "Nyankole", "Runyankore" },
                    { 154, "oc", "Occitan", "Occitan" },
                    { 155, "om", "Oromo", "Oromoo" },
                    { 156, "or", "Odia", "ଓଡ଼ିଆ" },
                    { 157, "os", "Ossetic", "ирон" },
                    { 158, "pa", "Punjabi", "ਪੰਜਾਬੀ" },
                    { 159, "pl", "Polish", "polski" },
                    { 160, "prg", "Prussian", "prūsiskan" },
                    { 161, "ps", "Pashto", "پښتو" },
                    { 162, "pt", "Portuguese", "português" },
                    { 163, "qu", "Quechua", "Runasimi" },
                    { 164, "quc", "Kʼicheʼ", "Kʼicheʼ" },
                    { 165, "rm", "Romansh", "rumantsch" },
                    { 166, "rn", "Rundi", "Ikirundi" },
                    { 167, "ro", "Romanian", "română" },
                    { 168, "rof", "Rombo", "Kihorombo" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 169, "ru", "Russian", "русский" },
                    { 170, "rw", "Kinyarwanda", "Kinyarwanda" },
                    { 171, "rwk", "Rwa", "Kiruwa" },
                    { 172, "sa", "Sanskrit", "संस्कृत भाषा" },
                    { 173, "sah", "Sakha", "саха тыла" },
                    { 174, "saq", "Samburu", "Kisampur" },
                    { 175, "sbp", "Sangu", "Ishisangu" },
                    { 176, "sd", "Sindhi", "سنڌي" },
                    { 177, "se", "Northern Sami", "davvisámegiella" },
                    { 178, "seh", "Sena", "sena" },
                    { 179, "ses", "Koyraboro Senni", "Koyraboro senni" },
                    { 180, "sg", "Sango", "Sängö" },
                    { 181, "shi", "Tachelhit", "ⵜⴰⵛⵍⵃⵉⵜ" },
                    { 182, "si", "Sinhala", "සිංහල" },
                    { 183, "sk", "Slovak", "slovenčina" },
                    { 184, "sl", "Slovenian", "slovenščina" },
                    { 185, "sma", "Southern Sami", "Åarjelsaemien gïele" },
                    { 186, "smj", "Lule Sami", "julevsámegiella" },
                    { 187, "smn", "Inari Sami", "anarâškielâ" },
                    { 188, "sms", "Skolt Sami", "Skolt Sami" },
                    { 189, "sn", "Shona", "chiShona" },
                    { 190, "so", "Somali", "Soomaali" },
                    { 191, "sq", "Albanian", "shqip" },
                    { 192, "sr", "Serbian", "српски" },
                    { 193, "ss", "siSwati", "siSwati" },
                    { 194, "ssy", "Saho", "Saho" },
                    { 195, "st", "Sesotho", "Sesotho" },
                    { 196, "sv", "Swedish", "svenska" },
                    { 197, "sw", "Kiswahili", "Kiswahili" },
                    { 198, "syr", "Syriac", "Syriac" },
                    { 199, "ta", "Tamil", "தமிழ்" },
                    { 200, "te", "Telugu", "తెలుగు" },
                    { 201, "teo", "Teso", "Kiteso" },
                    { 202, "tg", "Tajik", "тоҷикӣ" },
                    { 203, "th", "Thai", "ไทย" },
                    { 204, "ti", "Tigrinya", "ትግርኛ" },
                    { 205, "tig", "Tigre", "Tigre" },
                    { 206, "tk", "Turkmen", "türkmen dili" },
                    { 207, "tn", "Setswana", "Setswana" },
                    { 208, "to", "Tongan", "lea fakatonga" },
                    { 209, "tr", "Turkish", "Türkçe" },
                    { 210, "ts", "Xitsonga", "Xitsonga" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 211, "tt", "Tatar", "татар" },
                    { 212, "twq", "Tasawaq", "Tasawaq senni" },
                    { 213, "tzm", "Central Atlas Tamazight", "Tamaziɣt n laṭlaṣ" },
                    { 214, "ug", "Uyghur", "ئۇيغۇرچە" },
                    { 215, "uk", "Ukrainian", "українська" },
                    { 216, "ur", "Urdu", "اردو" },
                    { 217, "uz", "Uzbek", "o‘zbek" },
                    { 218, "vai", "Vai", "ꕙꔤ" },
                    { 219, "ve", "Venda", "Venda" },
                    { 220, "vi", "Vietnamese", "Tiếng Việt" },
                    { 221, "vo", "Volapük", "Volapük" },
                    { 222, "vun", "Vunjo", "Kyivunjo" },
                    { 223, "wae", "Walser", "Walser" },
                    { 224, "wal", "Wolaytta", "Wolaytta" },
                    { 225, "wo", "Wolof", "Wolof" },
                    { 226, "xh", "isiXhosa", "isiXhosa" },
                    { 227, "xog", "Soga", "Olusoga" },
                    { 228, "yav", "Yangben", "nuasue" },
                    { 229, "yi", "Yiddish", "ייִדיש" },
                    { 230, "yo", "Yoruba", "Èdè Yorùbá" },
                    { 231, "zgh", "Standard Moroccan Tamazight", "ⵜⴰⵎⴰⵣⵉⵖⵜ" },
                    { 232, "zh", "Chinese", "中文" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 232);
        }
    }
}
