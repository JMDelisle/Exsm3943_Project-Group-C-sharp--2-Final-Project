﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class test_migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFirst = table.Column<string>(name: "Name(First)", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameLast = table.Column<string>(name: "Name(Last)", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "product category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(name: "Category Name", type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product category", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductCategoryID = table.Column<int>(name: "Product Category ID", type: "int(11)", nullable: false),
                    ProductName = table.Column<string>(name: "Product Name", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityOnHand = table.Column<int>(name: "Quantity On Hand", type: "int(11)", nullable: false),
                    Minimum = table.Column<int>(type: "int(11)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "products_ibfk_1",
                        column: x => x.ProductCategoryID,
                        principalTable: "product category",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(name: "Customer ID", type: "int(11)", nullable: false),
                    ProductCategoryID = table.Column<int>(name: "Product Category ID", type: "int(11)", nullable: false),
                    ProductNameID = table.Column<int>(name: "Product Name ID", type: "int(11)", nullable: false),
                    TimeDateofOrder = table.Column<DateTime>(name: "Time/Date of Order", type: "datetime", nullable: false),
                    QuantityOrdered = table.Column<int>(name: "Quantity Ordered", type: "int(11)", nullable: false),
                    IndividualPrice = table.Column<decimal>(name: "Individual Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ExtendedPrice = table.Column<decimal>(name: "Extended Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(name: "Total Price", type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.ID);
                    table.ForeignKey(
                        name: "transactions_ibfk_1",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "transactions_ibfk_2",
                        column: x => x.ProductCategoryID,
                        principalTable: "product category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "transactions_ibfk_3",
                        column: x => x.ProductNameID,
                        principalTable: "products",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.InsertData(
                table: "product category",
                columns: new[] { "ID", "Category Name" },
                values: new object[] { 1, "Paint" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ID", "Cost", "Minimum", "Product Category ID", "Product Name", "Quantity On Hand", "SalePrice" },
                values: new object[] { 1, 225.00m, 4, 1, "White Toner", 6, 360.000m });

            migrationBuilder.CreateIndex(
                name: "Product Category ID",
                table: "products",
                column: "Product Category ID");

            migrationBuilder.CreateIndex(
                name: "Customer ID",
                table: "transactions",
                column: "Customer ID");

            migrationBuilder.CreateIndex(
                name: "Product Category ID1",
                table: "transactions",
                column: "Product Category ID");

            migrationBuilder.CreateIndex(
                name: "Product Name ID",
                table: "transactions",
                column: "Product Name ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product category");
        }
    }
}
