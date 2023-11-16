using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class ModifyLanguagesConfiguration24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 1, null, "Not Specified", "Not Specified" },
                    { 2, "aa-DJ", "Afar (Djibouti)", "Afar (Djibouti)" },
                    { 3, "aa-ER", "Afar (Eritrea)", "Afar (Eritrea)" },
                    { 4, "aa-ET", "Afar (Ethiopia)", "Afar (Ethiopia)" },
                    { 5, "af-NA", "Afrikaans (Namibia)", "Afrikaans (Namibië)" },
                    { 6, "af-ZA", "Afrikaans (South Africa)", "Afrikaans (Suid-Afrika)" },
                    { 7, "agq-CM", "Aghem (Cameroon)", "Aghem (Kàmàlûŋ)" },
                    { 8, "ak-GH", "Akan (Ghana)", "Akan (Gaana)" },
                    { 9, "am-ET", "Amharic (Ethiopia)", "አማርኛ (ኢትዮጵያ)" },
                    { 10, "ar-001", "Arabic (World)", "العربية (العالم)" },
                    { 11, "ar-AE", "Arabic (United Arab Emirates)", "العربية (الإمارات العربية المتحدة)" },
                    { 12, "ar-BH", "Arabic (Bahrain)", "العربية (البحرين)" },
                    { 13, "ar-DJ", "Arabic (Djibouti)", "العربية (جيبوتي)" },
                    { 14, "ar-DZ", "Arabic (Algeria)", "العربية (الجزائر)" },
                    { 15, "ar-EG", "Arabic (Egypt)", "العربية (مصر)" },
                    { 16, "ar-ER", "Arabic (Eritrea)", "العربية (إريتريا)" },
                    { 17, "ar-IL", "Arabic (Israel)", "العربية (إسرائيل)" },
                    { 18, "ar-IQ", "Arabic (Iraq)", "العربية (العراق)" },
                    { 19, "ar-JO", "Arabic (Jordan)", "العربية (الأردن)" },
                    { 20, "ar-KM", "Arabic (Comoros)", "العربية (جزر القمر)" },
                    { 21, "ar-KW", "Arabic (Kuwait)", "العربية (الكويت)" },
                    { 22, "ar-LB", "Arabic (Lebanon)", "العربية (لبنان)" },
                    { 23, "ar-LY", "Arabic (Libya)", "العربية (ليبيا)" },
                    { 24, "ar-MA", "Arabic (Morocco)", "العربية (المغرب)" },
                    { 25, "ar-MR", "Arabic (Mauritania)", "العربية (موريتانيا)" },
                    { 26, "ar-OM", "Arabic (Oman)", "العربية (عُمان)" },
                    { 27, "ar-PS", "Arabic (Palestinian Authority)", "العربية (السلطة الفلسطينية)" },
                    { 28, "ar-QA", "Arabic (Qatar)", "العربية (قطر)" },
                    { 29, "ar-SA", "Arabic (Saudi Arabia)", "العربية (المملكة العربية السعودية)" },
                    { 30, "ar-SD", "Arabic (Sudan)", "العربية (السودان)" },
                    { 31, "ar-SO", "Arabic (Somalia)", "العربية (الصومال)" },
                    { 32, "ar-SS", "Arabic (South Sudan)", "العربية (جنوب السودان)" },
                    { 33, "ar-SY", "Arabic (Syria)", "العربية (سوريا)" },
                    { 34, "ar-TD", "Arabic (Chad)", "العربية (تشاد)" },
                    { 35, "ar-TN", "Arabic (Tunisia)", "العربية (تونس)" },
                    { 36, "ar-YE", "Arabic (Yemen)", "العربية (اليمن)" },
                    { 37, "arn-CL", "Mapuche (Chile)", "Mapuche (Chile)" },
                    { 38, "as-IN", "Assamese (India)", "অসমীয়া (ভাৰত)" },
                    { 39, "asa-TZ", "Asu (Tanzania)", "Kipare (Tadhania)" },
                    { 40, "ast-ES", "Asturian (Spain)", "asturianu (España)" },
                    { 41, "az-Cyrl-AZ", "Azerbaijani (Cyrillic, Azerbaijan)", "азәрбајҹан (Кирил, Азәрбајҹан)" },
                    { 42, "az-Latn-AZ", "Azerbaijani (Latin, Azerbaijan)", "azərbaycan (latın, Azərbaycan)" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 43, "ba-RU", "Bashkir (Russia)", "Bashkir (Russia)" },
                    { 44, "bas-CM", "Basaa (Cameroon)", "Ɓàsàa (Kàmɛ̀rûn)" },
                    { 45, "be-BY", "Belarusian (Belarus)", "беларуская (Беларусь)" },
                    { 46, "bem-ZM", "Bemba (Zambia)", "Ichibemba (Zambia)" },
                    { 47, "bez-TZ", "Bena (Tanzania)", "Hibena (Hutanzania)" },
                    { 48, "bg-BG", "Bulgarian (Bulgaria)", "български (България)" },
                    { 49, "bm-ML", "Bamanankan (Mali)", "bamanakan (Mali)" },
                    { 50, "bn-BD", "Bangla (Bangladesh)", "বাংলা (বাংলাদেশ)" }
                });
        }
    }
}
