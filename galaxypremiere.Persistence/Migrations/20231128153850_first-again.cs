using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace galaxypremiere.Persistence.Migrations
{
    public partial class firstagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameNative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Provider = table.Column<byte>(type: "tinyint", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersActionsLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryKeyValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Successful = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersActionsLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersActionsLog_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoveryEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vimeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imdb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersAddress_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneId = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInformation_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersInRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    RolesId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInRoles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLoginLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLoginLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLoginLog_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 0, null, true, "Not Specified" },
                    { 2, 93, null, true, "Afghanistan" },
                    { 3, 358, null, true, "Åland Islands" },
                    { 4, 355, null, true, "Albania" },
                    { 5, 213, null, true, "Algeria" },
                    { 6, 1, null, true, "American Samoa" },
                    { 7, 376, null, true, "Andorra" },
                    { 8, 244, null, true, "Angola" },
                    { 9, 1, null, true, "Anguilla" },
                    { 10, 1, null, true, "Antigua and Barbuda" },
                    { 11, 54, null, true, "Argentina" },
                    { 12, 374, null, true, "Armenia" },
                    { 13, 297, null, true, "Aruba" },
                    { 14, 61, null, true, "Australia" },
                    { 15, 43, null, true, "Austria" },
                    { 16, 994, null, true, "Azerbaijan" },
                    { 17, 1, null, true, "Bahamas" },
                    { 18, 973, null, true, "Bahrain" },
                    { 19, 880, null, true, "Bangladesh" },
                    { 20, 1, null, true, "Barbados" },
                    { 21, 375, null, true, "Belarus" },
                    { 22, 32, null, true, "Belgium" },
                    { 23, 501, null, true, "Belize" },
                    { 24, 229, null, true, "Benin" },
                    { 25, 1, null, true, "Bermuda" },
                    { 26, 975, null, true, "Bhutan" },
                    { 27, 591, null, true, "Bolivia" },
                    { 28, 599, null, true, "Bonaire, Sint Eustatius and Saba" },
                    { 29, 387, null, true, "Bosnia and Herzegovina" },
                    { 30, 267, null, true, "Botswana" },
                    { 31, 55, null, true, "Brazil" },
                    { 32, 246, null, true, "British Indian Ocean Territory" },
                    { 33, 1, null, true, "British Virgin Islands" },
                    { 34, 673, null, true, "Brunei" },
                    { 35, 359, null, true, "Bulgaria" },
                    { 36, 226, null, true, "Burkina Faso" },
                    { 37, 257, null, true, "Burundi" },
                    { 38, 238, null, true, "Cabo Verde" },
                    { 39, 855, null, true, "Cambodia" },
                    { 40, 237, null, true, "Cameroon" },
                    { 41, 1, null, true, "Canada" },
                    { 42, 0, null, true, "Caribbean" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 43, 1, null, true, "Cayman Islands" },
                    { 44, 236, null, true, "Central African Republic" },
                    { 45, 235, null, true, "Chad" },
                    { 46, 56, null, true, "Chile" },
                    { 47, 86, null, true, "China" },
                    { 48, 61, null, true, "Christmas Island" },
                    { 49, 61, null, true, "Cocos (Keeling) Islands" },
                    { 50, 57, null, true, "Colombia" },
                    { 51, 269, null, true, "Comoros" },
                    { 52, 242, null, true, "Congo" },
                    { 53, 243, null, true, "Congo (DRC)" },
                    { 54, 682, null, true, "Cook Islands" },
                    { 55, 506, null, true, "Costa Rica" },
                    { 56, 225, null, true, "Côte d’Ivoire" },
                    { 57, 385, null, true, "Croatia" },
                    { 58, 53, null, true, "Cuba" },
                    { 59, 599, null, true, "Curaçao" },
                    { 60, 357, null, true, "Cyprus" },
                    { 61, 420, null, true, "Czechia" },
                    { 62, 45, null, true, "Denmark" },
                    { 63, 253, null, true, "Djibouti" },
                    { 64, 1, null, true, "Dominica" },
                    { 65, 1, null, true, "Dominican Republic" },
                    { 66, 593, null, true, "Ecuador" },
                    { 67, 20, null, true, "Egypt" },
                    { 68, 503, null, true, "El Salvador" },
                    { 69, 240, null, true, "Equatorial Guinea" },
                    { 70, 291, null, true, "Eritrea" },
                    { 71, 372, null, true, "Estonia" },
                    { 72, 251, null, true, "Ethiopia" },
                    { 73, 0, null, true, "Europe" },
                    { 74, 500, null, true, "Falkland Islands" },
                    { 75, 298, null, true, "Faroe Islands" },
                    { 76, 679, null, true, "Fiji" },
                    { 77, 358, null, true, "Finland" },
                    { 78, 33, null, true, "France" },
                    { 79, 594, null, true, "French Guiana" },
                    { 80, 689, null, true, "French Polynesia" },
                    { 81, 241, null, true, "Gabon" },
                    { 82, 220, null, true, "Gambia" },
                    { 83, 995, null, true, "Georgia" },
                    { 84, 49, null, true, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 85, 233, null, true, "Ghana" },
                    { 86, 350, null, true, "Gibraltar" },
                    { 87, 30, null, true, "Greece" },
                    { 88, 299, null, true, "Greenland" },
                    { 89, 1, null, true, "Grenada" },
                    { 90, 590, null, true, "Guadeloupe" },
                    { 91, 1, null, true, "Guam" },
                    { 92, 502, null, true, "Guatemala" },
                    { 93, 44, null, true, "Guernsey" },
                    { 94, 224, null, true, "Guinea" },
                    { 95, 245, null, true, "Guinea-Bissau" },
                    { 96, 592, null, true, "Guyana" },
                    { 97, 509, null, true, "Haiti" },
                    { 98, 504, null, true, "Honduras" },
                    { 99, 852, null, true, "Hong Kong SAR" },
                    { 100, 36, null, true, "Hungary" },
                    { 101, 354, null, true, "Iceland" },
                    { 102, 91, null, true, "India" },
                    { 103, 62, null, true, "Indonesia" },
                    { 104, 98, null, true, "Iran" },
                    { 105, 964, null, true, "Iraq" },
                    { 106, 353, null, true, "Ireland" },
                    { 107, 44, null, true, "Isle of Man" },
                    { 108, 972, null, true, "Israel" },
                    { 109, 39, null, true, "Italy" },
                    { 110, 1, null, true, "Jamaica" },
                    { 111, 81, null, true, "Japan" },
                    { 112, 44, null, true, "Jersey" },
                    { 113, 962, null, true, "Jordan" },
                    { 114, 7, null, true, "Kazakhstan" },
                    { 115, 254, null, true, "Kenya" },
                    { 116, 686, null, true, "Kiribati" },
                    { 117, 82, null, true, "Korea" },
                    { 118, 383, null, true, "Kosovo" },
                    { 119, 965, null, true, "Kuwait" },
                    { 120, 996, null, true, "Kyrgyzstan" },
                    { 121, 856, null, true, "Laos" },
                    { 122, 0, null, true, "Latin America" },
                    { 123, 371, null, true, "Latvia" },
                    { 124, 961, null, true, "Lebanon" },
                    { 125, 266, null, true, "Lesotho" },
                    { 126, 231, null, true, "Liberia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 127, 218, null, true, "Libya" },
                    { 128, 423, null, true, "Liechtenstein" },
                    { 129, 370, null, true, "Lithuania" },
                    { 130, 352, null, true, "Luxembourg" },
                    { 131, 853, null, true, "Macao SAR" },
                    { 132, 389, null, true, "Macedonia, FYRO" },
                    { 133, 261, null, true, "Madagascar" },
                    { 134, 265, null, true, "Malawi" },
                    { 135, 60, null, true, "Malaysia" },
                    { 136, 960, null, true, "Maldives" },
                    { 137, 223, null, true, "Mali" },
                    { 138, 356, null, true, "Malta" },
                    { 139, 692, null, true, "Marshall Islands" },
                    { 140, 596, null, true, "Martinique" },
                    { 141, 222, null, true, "Mauritania" },
                    { 142, 230, null, true, "Mauritius" },
                    { 143, 262, null, true, "Mayotte" },
                    { 144, 52, null, true, "Mexico" },
                    { 145, 691, null, true, "Micronesia" },
                    { 146, 373, null, true, "Moldova" },
                    { 147, 377, null, true, "Monaco" },
                    { 148, 976, null, true, "Mongolia" },
                    { 149, 382, null, true, "Montenegro" },
                    { 150, 1, null, true, "Montserrat" },
                    { 151, 212, null, true, "Morocco" },
                    { 152, 258, null, true, "Mozambique" },
                    { 153, 95, null, true, "Myanmar" },
                    { 154, 264, null, true, "Namibia" },
                    { 155, 674, null, true, "Nauru" },
                    { 156, 977, null, true, "Nepal" },
                    { 157, 31, null, true, "Netherlands" },
                    { 158, 687, null, true, "New Caledonia" },
                    { 159, 64, null, true, "New Zealand" },
                    { 160, 505, null, true, "Nicaragua" },
                    { 161, 227, null, true, "Niger" },
                    { 162, 234, null, true, "Nigeria" },
                    { 163, 683, null, true, "Niue" },
                    { 164, 672, null, true, "Norfolk Island" },
                    { 165, 850, null, true, "North Korea" },
                    { 166, 1, null, true, "Northern Mariana Islands" },
                    { 167, 47, null, true, "Norway" },
                    { 168, 968, null, true, "Oman" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 169, 92, null, true, "Pakistan" },
                    { 170, 680, null, true, "Palau" },
                    { 171, 970, null, true, "Palestinian Authority" },
                    { 172, 507, null, true, "Panama" },
                    { 173, 675, null, true, "Papua New Guinea" },
                    { 174, 595, null, true, "Paraguay" },
                    { 175, 51, null, true, "Peru" },
                    { 176, 63, null, true, "Philippines" },
                    { 177, 0, null, true, "Pitcairn Islands" },
                    { 178, 48, null, true, "Poland" },
                    { 179, 351, null, true, "Portugal" },
                    { 180, 1, null, true, "Puerto Rico" },
                    { 181, 974, null, true, "Qatar" },
                    { 182, 262, null, true, "Réunion" },
                    { 183, 40, null, true, "Romania" },
                    { 184, 7, null, true, "Russia" },
                    { 185, 250, null, true, "Rwanda" },
                    { 186, 590, null, true, "Saint Barthélemy" },
                    { 187, 1, null, true, "Saint Kitts and Nevis" },
                    { 188, 1, null, true, "Saint Lucia" },
                    { 189, 590, null, true, "Saint Martin" },
                    { 190, 508, null, true, "Saint Pierre and Miquelon" },
                    { 191, 1, null, true, "Saint Vincent and the Grenadines" },
                    { 192, 685, null, true, "Samoa" },
                    { 193, 378, null, true, "San Marino" },
                    { 194, 239, null, true, "São Tomé and Príncipe" },
                    { 195, 966, null, true, "Saudi Arabia" },
                    { 196, 221, null, true, "Senegal" },
                    { 197, 381, null, true, "Serbia" },
                    { 198, 248, null, true, "Seychelles" },
                    { 199, 232, null, true, "Sierra Leone" },
                    { 200, 65, null, true, "Singapore" },
                    { 201, 1, null, true, "Sint Maarten" },
                    { 202, 421, null, true, "Slovakia" },
                    { 203, 386, null, true, "Slovenia" },
                    { 204, 677, null, true, "Solomon Islands" },
                    { 205, 252, null, true, "Somalia" },
                    { 206, 27, null, true, "South Africa" },
                    { 207, 211, null, true, "South Sudan" },
                    { 208, 34, null, true, "Spain" },
                    { 209, 94, null, true, "Sri Lanka" },
                    { 210, 290, null, true, "St Helena, Ascension, Tristan da Cunha" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IP", "IsActive", "Name" },
                values: new object[,]
                {
                    { 211, 249, null, true, "Sudan" },
                    { 212, 597, null, true, "Suriname" },
                    { 213, 47, null, true, "Svalbard and Jan Mayen" },
                    { 214, 268, null, true, "Swaziland" },
                    { 215, 46, null, true, "Sweden" },
                    { 216, 41, null, true, "Switzerland" },
                    { 217, 963, null, true, "Syria" },
                    { 218, 886, null, true, "Taiwan" },
                    { 219, 992, null, true, "Tajikistan" },
                    { 220, 255, null, true, "Tanzania" },
                    { 221, 66, null, true, "Thailand" },
                    { 222, 670, null, true, "Timor-Leste" },
                    { 223, 228, null, true, "Togo" },
                    { 224, 690, null, true, "Tokelau" },
                    { 225, 676, null, true, "Tonga" },
                    { 226, 1, null, true, "Trinidad and Tobago" },
                    { 227, 216, null, true, "Tunisia" },
                    { 228, 90, null, true, "Turkey" },
                    { 229, 993, null, true, "Turkmenistan" },
                    { 230, 1, null, true, "Turks and Caicos Islands" },
                    { 231, 688, null, true, "Tuvalu" },
                    { 232, 0, null, true, "U.S. Outlying Islands" },
                    { 233, 1, null, true, "U.S. Virgin Islands" },
                    { 234, 256, null, true, "Uganda" },
                    { 235, 380, null, true, "Ukraine" },
                    { 236, 971, null, true, "United Arab Emirates" },
                    { 237, 44, null, true, "United Kingdom" },
                    { 238, 1, null, true, "United States" },
                    { 239, 598, null, true, "Uruguay" },
                    { 240, 998, null, true, "Uzbekistan" },
                    { 241, 678, null, true, "Vanuatu" },
                    { 242, 39, null, true, "Vatican City" },
                    { 243, 58, null, true, "Venezuela" },
                    { 244, 84, null, true, "Vietnam" },
                    { 245, 681, null, true, "Wallis and Futuna" },
                    { 246, 0, null, true, "World" },
                    { 247, 967, null, true, "Yemen" },
                    { 248, 260, null, true, "Zambia" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
                    { 1, null, "Not Specified", "Not Specified" },
                    { 2, "aa", "Afar", "Afar" },
                    { 3, "af", "Afrikaans", "Afrikaans" },
                    { 4, "agq", "Aghem", "Aghem" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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
                    { 42, "dua", "Duala", "duálá" },
                    { 43, "dv", "Divehi", "Divehi" },
                    { 44, "dyo", "Jola-Fonyi", "joola" },
                    { 45, "dz", "Dzongkha", "རྫོང་ཁ" },
                    { 46, "ebu", "Embu", "Kĩembu" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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
                    { 84, "it", "Italian", "italiano" },
                    { 85, "iu", "Inuktitut", "Inuktitut" },
                    { 86, "ja", "Japanese", "日本語" },
                    { 87, "jgo", "Ngomba", "Ndaꞌa" },
                    { 88, "jmc", "Machame", "Kimachame" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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
                    { 126, "mg", "Malagasy", "Malagasy" },
                    { 127, "mgh", "Makhuwa-Meetto", "Makua" },
                    { 128, "mgo", "Metaʼ", "metaʼ" },
                    { 129, "mi", "Maori", "Māori" },
                    { 130, "mk", "Macedonian", "македонски" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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
                    { 168, "rof", "Rombo", "Kihorombo" },
                    { 169, "ru", "Russian", "русский" },
                    { 170, "rw", "Kinyarwanda", "Kinyarwanda" },
                    { 171, "rwk", "Rwa", "Kiruwa" },
                    { 172, "sa", "Sanskrit", "संस्कृत भाषा" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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
                    { 210, "ts", "Xitsonga", "Xitsonga" },
                    { 211, "tt", "Tatar", "татар" },
                    { 212, "twq", "Tasawaq", "Tasawaq senni" },
                    { 213, "tzm", "Central Atlas Tamazight", "Tamaziɣt n laṭlaṣ" },
                    { 214, "ug", "Uyghur", "ئۇيغۇرچە" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCountryCode", "NameEnglish", "NameNative" },
                values: new object[,]
                {
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "King" },
                    { (byte)2, "SuperAdmin" },
                    { (byte)3, "Admin" },
                    { (byte)4, "Client" },
                    { (byte)5, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersActionsLog_UsersId",
                table: "UsersActionsLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAddress_UsersId",
                table: "UsersAddress",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInformation_UsersId",
                table: "UsersInformation",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_RolesId",
                table: "UsersInRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInRoles_UsersId",
                table: "UsersInRoles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLoginLog_UsersId",
                table: "UsersLoginLog",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "UsersActionsLog");

            migrationBuilder.DropTable(
                name: "UsersAddress");

            migrationBuilder.DropTable(
                name: "UsersInformation");

            migrationBuilder.DropTable(
                name: "UsersInRoles");

            migrationBuilder.DropTable(
                name: "UsersLoginLog");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
