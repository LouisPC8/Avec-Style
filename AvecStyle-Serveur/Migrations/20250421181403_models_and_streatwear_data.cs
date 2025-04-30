using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvecStyle_Serveur.Migrations
{
    /// <inheritdoc />
    public partial class models_and_streatwear_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    ShopURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Shape = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "Category", "Gender", "ImageURL", "Shape", "ShopURL", "Style" },
                values: new object[,]
                {
                    { 1, 3, false, "https://qcstreetwear.ca/cdn/shop/files/b509a3888ea40764925e24d68a180c0b_1296x.jpg?v=1700172125", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/acrylic-pull-on-moonstruck", "streetwear" },
                    { 2, 3, false, "https://qcstreetwear.ca/cdn/shop/files/unnamedcopie_1296x.jpg?v=1729428533", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/beanie-las-vegas-raiders-black", "streetwear" },
                    { 3, 3, false, "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2023-07-09a12.51.15_1296x.png?v=1689624458", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/boston-red-sox-mvp-cap-black-grey", "streetwear" },
                    { 4, 3, false, "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2023-06-04a09.00.39_1296x.png?v=1686158853", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/chicago-bulls-47-mvp-black", "streetwear" },
                    { 5, 3, false, "https://qcstreetwear.ca/cdn/shop/files/TB0A61GB001PrimaryHighRes_1296x.png?v=1730417891", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cross-body-bag-black", "streetwear" },
                    { 6, 3, false, "https://qcstreetwear.ca/cdn/shop/files/Captured_ecran2024-05-09a16.56.11_1296x.png?v=1715288228", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cotton-twill-army-cap-beige", "streetwear" },
                    { 7, 3, false, "https://qcstreetwear.ca/cdn/shop/files/WHC200BDLarge_1296x.png?v=1732455734", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/cuffed-knit-beanie-brown", "streetwear" },
                    { 8, 3, false, "https://qcstreetwear.ca/cdn/shop/products/Captured_ecran2020-05-25a14.34.04_1296x.png?v=1590431662", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/copy-of-dad-hat-ny-state-of-mind-radiant-brand-navy", "streetwear" },
                    { 9, 3, false, "https://qcstreetwear.ca/cdn/shop/files/unnamed_5_b2127b26-d76e-48f7-bd05-faec6d081271_1296x.jpg?v=1729174716", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/mlb-los-angeles-dodgers-black-sand-47-captain", "streetwear" },
                    { 10, 3, false, "https://qcstreetwear.ca/cdn/shop/files/TB0A61HK001PrimaryHighRes_1296x.png?v=1740699932", 3, "https://qcstreetwear.ca/collections/casquettes-et-tuques/products/timberpack-sling-bag", "streetwear" },
                    { 11, 0, false, "https://qcstreetwear.ca/cdn/shop/files/100075508B0002_1296x.jpg?v=1713555412", 3, "https://qcstreetwear.ca/collections/hauts-et-t-shirts-pour-hommes/products/above-the-rim-collage-t-shirt-black", "streetwear" },
                    { 12, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/bart-lean-mock-v2.jpg?v=1556866422&width=1200", 3, "https://www.streetwearofficial.com/products/bart-lean", "streetwear" },
                    { 13, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/00004529763C71D0_X.jpg?v=1560582957&width=800", 3, "https://www.streetwearofficial.com/products/raheem-toon-tee", "streetwear" },
                    { 14, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/white-blank-new_04878970-3515-4f50-b6a4-73f0a8e28026.jpg?v=1561789729&width=1200", 3, "https://www.streetwearofficial.com/products/flying-kickz", "streetwear" },
                    { 15, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/Screen_Shot_2018-11-30_at_7.59.48_PM.png?v=1569155394&width=800", 3, "https://www.streetwearofficial.com/products/hype-kid", "streetwear" },
                    { 16, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/0000332056712060_X.jpg?v=1560582988&width=1000", 3, "https://www.streetwearofficial.com/products/big-jmpmn-tee", "streetwear" },
                    { 17, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/RK_0011_Screen_Shot_2017-07-06_at_12.24.28_PM_4e956761-a560-4c51-ae0d-38e09e7f983d.jpg?v=1560582953&width=1200", 3, "https://www.streetwearofficial.com/products/mj-bear-tee", "streetwear" },
                    { 18, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/0000284886248163_X.jpg?v=1568959690&width=1000", 3, "https://www.streetwearofficial.com/products/mj-mag-tee", "streetwear" },
                    { 19, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/jh-robber-navy.jpg?v=1561792355&width=1600", 3, "https://www.streetwearofficial.com/products/jh-robber", "streetwear" },
                    { 20, 0, false, "https://www.streetwearofficial.com/cdn/shop/products/110_a8631b08-0e66-4a7e-a4c7-8c6a3c954854.jpg?v=1583438263&width=1200", 3, "https://www.streetwearofficial.com/products/smooth-criminal", "streetwear" },
                    { 21, 1, false, "https://boutique-streetwear.com/cdn/shop/files/JEAN-VINTAGE-ULTRA_300x.jpg?v=1695643181", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/jean-vintage-ultra", "streetwear" },
                    { 22, 1, false, "https://boutique-streetwear.com/cdn/shop/files/PANTALON-CARGO-CAMO_300x.jpg?v=1695470160", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/pantalon-cargo-camo", "streetwear" },
                    { 23, 1, false, "https://boutique-streetwear.com/cdn/shop/files/PANTALON-DE-SURVETEMENT-ANTHRACITE_300x.jpg?v=1695389552", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/pantalon-de-survetement-anthracite", "streetwear" },
                    { 24, 1, false, "https://boutique-streetwear.com/cdn/shop/files/JEAN-TROUE-HOODED_300x.jpg?v=1692117909", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/jean-troue-hooded", "streetwear" },
                    { 25, 1, false, "https://boutique-streetwear.com/cdn/shop/products/JEAN-CARGO-STREETWEAR_300x.jpg?v=1673743547", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/jean-cargo-pockets", "streetwear" },
                    { 26, 1, false, "https://boutique-streetwear.com/cdn/shop/products/SHORT-CARGO-NOIR_300x.png?v=1660680298", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/short-cargo-en-coton-noir", "streetwear" },
                    { 27, 1, false, "https://boutique-streetwear.com/cdn/shop/products/SHORT-AVEC-CEINTURE_300x.png?v=1660781444", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/short-en-polyester-avec-ceinture-beige", "streetwear" },
                    { 28, 1, false, "https://boutique-streetwear.com/cdn/shop/products/SHORT-SKATE_300x.png?v=1660752589", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/short-en-polyester-style-skate-noir", "streetwear" },
                    { 29, 1, false, "https://boutique-streetwear.com/cdn/shop/products/JOGGING-POLYESTER_c75f6678-a7a9-4d17-8ff2-5be70fd379f0_300x.png?v=1660569232", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/jogging-polyester-vert", "streetwear" },
                    { 30, 1, false, "https://boutique-streetwear.com/cdn/shop/products/PANTALON-CARGO-TECHNIQUE-FLUO_300x.png?v=1660229064", 3, "https://boutique-streetwear.com/collections/pantalons-streetwear/products/pantalon-cargo-fluo", "streetwear" },
                    { 31, 2, false, "https://nrml.ca/cdn/shop/files/SFTM1.png?crop=center&height=1000&v=1740683845&width=1800", 3, "https://nrml.ca/collections/all/products/adistar-cushion-song-for-the-mute-releases-march-13", "streetwear" },
                    { 32, 2, false, "https://nrml.ca/cdn/shop/files/YOTS4.jpg?crop=center&height=1000&v=1741892424&width=1800", 3, "https://nrml.ca/collections/all/products/dunk-low-retro-year-of-the-snake", "streetwear" },
                    { 33, 2, false, "https://nrml.ca/cdn/shop/files/BO2.jpg?crop=center&height=1000&v=1742566656&width=1800", 3, "https://nrml.ca/collections/all/products/740-triple-black", "streetwear" },
                    { 34, 2, false, "https://nrml.ca/cdn/shop/files/ADV.jpg?crop=center&height=1000&v=1742910732&width=1800", 3, "https://nrml.ca/collections/all/products/samba-adv-preloved-ink-price-tbd", "streetwear" },
                    { 35, 2, false, "https://nrml.ca/cdn/shop/files/M10000.jpg?crop=center&height=1000&v=1744389766&width=1800", 3, "https://nrml.ca/collections/all/products/m1000-black-silver-metallic", "streetwear" },
                    { 36, 2, false, "https://nrml.ca/cdn/shop/files/rare_9478dd14-75a4-44f6-84b3-f0a29d1f630c.jpg?crop=center&height=1000&v=1743530232&width=1800", 3, "https://nrml.ca/collections/all/products/air-jordan-1-retro-high-og-rare-air-april-5", "streetwear" },
                    { 37, 2, false, "https://nrml.ca/cdn/shop/files/ADIFOM.png?crop=center&height=1000&v=1744226432&width=1800", 3, "https://nrml.ca/collections/all/products/adifom-iiinfinity-mule-crystal-sand", "streetwear" },
                    { 38, 2, false, "https://nrml.ca/cdn/shop/files/OBSI.jpg?crop=center&height=1000&v=1743774042&width=1800", 3, "https://nrml.ca/collections/all/products/air-jordan-1-retro-low-og-obsidian-release-april-12", "streetwear" },
                    { 39, 2, false, "https://nrml.ca/cdn/shop/files/RCF.jpg?crop=center&height=1000&v=1744736500&width=1800", 3, "https://nrml.ca/collections/all/products/1906r-black-dark-silver-metallic", "streetwear" },
                    { 40, 2, false, "https://nrml.ca/cdn/shop/files/WHTCLOT.jpg?crop=center&height=1000&v=1744743482&width=1800", 3, "https://nrml.ca/collections/all/products/adidas-gazelle-crepe-x-clot-crew-white-release-apr-19", "streetwear" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
