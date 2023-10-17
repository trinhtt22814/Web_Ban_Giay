using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesShop.DAL.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IDRole",
                        column: x => x.IDRole,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDBrand = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Brands_IDBrand",
                        column: x => x.IDBrand,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Categories_IDCategory",
                        column: x => x.IDCategory,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Colors_IDColor",
                        column: x => x.IDColor,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Materials_IDMaterial",
                        column: x => x.IDMaterial,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Sizes_IDSize",
                        column: x => x.IDSize,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountVouchers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountVouchers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountVouchers_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountVouchers_Vouchers_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_Carts_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    ItemDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_ProductDetails_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Carts",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_ProductDetails_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_IDOrder",
                        column: x => x.IDOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductDetails_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDescription = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderHistories_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Orders_IDOrder",
                        column: x => x.IDOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeforePrice = table.Column<int>(type: "int", nullable: false),
                    AfterPrice = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Orders_IDOrder",
                        column: x => x.IDOrder,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherDetails_Vouchers_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountVouchers_IDUser",
                table: "AccountVouchers",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_AccountVouchers_IDVoucher",
                table: "AccountVouchers",
                column: "IDVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_IDProductDetail",
                table: "CartDetails",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_IDUser",
                table: "CartDetails",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IDProductDetail",
                table: "Images",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IDOrder",
                table: "OrderDetails",
                column: "IDOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IDProductDetail",
                table: "OrderDetails",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_IdOrder",
                table: "OrderHistories",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IDUser",
                table: "Orders",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_IDOrder",
                table: "PaymentMethods",
                column: "IDOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDBrand",
                table: "ProductDetails",
                column: "IDBrand");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDCategory",
                table: "ProductDetails",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDColor",
                table: "ProductDetails",
                column: "IDColor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDMaterial",
                table: "ProductDetails",
                column: "IDMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDProduct",
                table: "ProductDetails",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IDSize",
                table: "ProductDetails",
                column: "IDSize");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IDRole",
                table: "Users",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_IDOrder",
                table: "VoucherDetails",
                column: "IDOrder");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_IDVoucher",
                table: "VoucherDetails",
                column: "IDVoucher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountVouchers");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "VoucherDetails");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}