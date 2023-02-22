using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "media");

            migrationBuilder.CreateTable(
                name: "images",
                schema: "media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barbers_images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "media",
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "media",
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_statusId",
                        column: x => x.statusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TimeToMake = table.Column<TimeSpan>(type: "time", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_images_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "media",
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Places",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 1, "average user" });

            migrationBuilder.InsertData(
                schema: "media",
                table: "images",
                columns: new[] { "Id", "Alt", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, "classic haircut", "./images/classic_haircut.jpg" },
                    { 2, null, "mustache and beard trim", "./images/beard_mustache.jpg" },
                    { 3, null, "hair washing and styling", "./images/styling.jpg" },
                    { 4, null, "children's haircut", "../images/child_haircut.jpg" },
                    { 5, null, "camouflage hair", "./images/camouflage.jpg" },
                    { 6, null, "french crop", "../images/The-French-Crop.jpg" },
                    { 7, null, "slick back", "../images/The-Slick-Back-Hairstyle.jpg" },
                    { 8, null, "side part", "../images/The-Side-Part.jpg" },
                    { 9, null, "circle beard", "../images/circle_beard.jpg" },
                    { 10, null, "royale beard", "../images/royale_beard.jpg" },
                    { 11, null, "styling hair", "../images/styling_hair.jpg" },
                    { 12, null, "hair washing", "../images/hair_washing.jpg" },
                    { 13, null, "tapered sides with side swept fringe", "../images/Tapered-Sides-with-Side-Swept-Fringe.jpg" },
                    { 14, null, "high fade with hard side part", "../images/High-Fade-with-Hard-Side-Part.jpg" },
                    { 15, null, "camouflage hair", "../images/Camouflage-Hair-men.jpg" },
                    { 16, null, "camouflage beard", "../images/men-hair-styles-beard-styles.jpg" },
                    { 17, null, "camouflage beard", "./images/camouflage.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Description", "Experience", "ImageId", "Name", "Position", "Rate" },
                values: new object[,]
                {
                    { 1, "I like to communicate with customers", 1, 17, "Bob", "Barber", 4.5 },
                    { 2, "I like to communicate with customers", 3, 17, "David", "Barber", 3.5 },
                    { 3, "I like to communicate with customers", 5, 17, "Tom", "Barber", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageId", "Name" },
                values: new object[,]
                {
                    { 1, "haircut using hair clipper and scissors", 1, "classic haircut" },
                    { 2, "combing, cutting mustaches and beards", 2, "mustache and beard trim" },
                    { 3, "washing and styling your hair, mostache or beard", 3, "hair washing and styling" },
                    { 4, "classic haircut using hair clipper and scissors for children", 4, "children's haircut" },
                    { 5, "painting the beard, hair or mustache borders", 5, "camouflage hair, beard and mustache" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CategoryId", "Description", "ImageId", "Name", "Price", "TimeToMake" },
                values: new object[,]
                {
                    { 1, 1, "The French Crop is classically famous because it is so simple. There isn’t much hair to distract from your face, hence why it has worked so well for many generations; it is minimalist. Synonymous with the ‘Caesar Cut’, the French crop boasts shorter sides with similarly cut locks up top. Incredibly versatile, this is a balanced haircut because there is not too much distinction between the hair up top and the hair on the sides of the head.", 6, "french crop", 100, new TimeSpan(0, 1, 0, 0, 0) },
                    { 2, 1, "Slicked back hair is sleek and a statement, but it is still nonetheless classic. It does work well when the hair has grown out but is also just as easy to achieve with an undercut. Our ultimate style inspiration for slicked back tresses? Johnny Depp in Cry Baby, where Depp’s strands were combed back with a glossy finish.", 7, "slick back", 90, new TimeSpan(0, 0, 50, 0, 0) },
                    { 3, 1, "Whether it is the side parts of the Twenties, Forties, Sixties, or contemporary versions that you identify with, the side part may just well be the most versatile and iconic classic hairstyle of all time. Ultra-refined or texturized adaptations are great, and these versions highlight the beauty of this hairstyle – it can look as mature or as youthful as you want.", 8, "side part", 110, new TimeSpan(0, 1, 10, 0, 0) },
                    { 4, 2, "A chin patch and a mustache that forms a circle.", 9, "circle beard", 60, new TimeSpan(0, 0, 30, 0, 0) },
                    { 5, 2, "A mustache anchored by a chin strip.", 10, "royale beard", 65, new TimeSpan(0, 0, 35, 0, 0) },
                    { 6, 3, "Use any style with your hair.", 11, "styling hair", 6, new TimeSpan(0, 0, 5, 0, 0) },
                    { 7, 3, "Usual hair washing.", 12, "hair washing", 5, new TimeSpan(0, 0, 5, 0, 0) },
                    { 8, 4, "Tapered sides are great for kids haircuts if you don’t want a very short fade. Plus, a side swept fringe can be an easy hairstyle even your little boy can style himself.", 13, "tapered sides with side swept fringe", 75, new TimeSpan(0, 0, 55, 0, 0) },
                    { 9, 4, "Boys fade haircuts keep the sides clean, short and simple, while a hard side part adds a classy yet cool hairstyle on top.", 14, "high fade with hard side part", 85, new TimeSpan(0, 1, 0, 0, 0) },
                    { 10, 5, "Hide your bald.", 15, "camouflage hair", 90, new TimeSpan(0, 0, 20, 0, 0) },
                    { 11, 5, "Make a great boards for your beard.", 16, "camouflage beard", 60, new TimeSpan(0, 0, 10, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barbers_ImageId",
                table: "Barbers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BarberId",
                table: "Orders",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlaceId",
                table: "Orders",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_statusId",
                table: "Users",
                column: "statusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "images",
                schema: "media");
        }
    }
}
