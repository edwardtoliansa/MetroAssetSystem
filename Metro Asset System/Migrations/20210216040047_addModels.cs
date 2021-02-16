﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro_Asset_System.Migrations
{
    public partial class addModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Asset",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AssetStatus = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Asset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 4, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Pinalty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowPinalty = table.Column<int>(nullable: false),
                    MiddlePinalty = table.Column<int>(nullable: false),
                    HighPinalty = table.Column<int>(nullable: false),
                    LostPinalty = table.Column<int>(nullable: false),
                    AssetId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Pinalty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false),
                    RequesterId = table.Column<string>(maxLength: 7, nullable: false),
                    RequesterManagerId = table.Column<string>(maxLength: 15, nullable: false),
                    ProcurementManagerId = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 11, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    ManagerId = table.Column<string>(maxLength: 11, nullable: true),
                    DepartmentId = table.Column<string>(maxLength: 4, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_ItemRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    AssetId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_ItemRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_ItemRequest_TB_M_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TB_M_Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 11, nullable: false),
                    Username = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_RequestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(maxLength: 20, nullable: true),
                    Date = table.Column<string>(nullable: false),
                    RequestId = table.Column<string>(maxLength: 10, nullable: false),
                    EmployeeId = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_RequestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_RequestDetail_TB_M_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Invoice",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 8, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<string>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    ProcurementEmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Invoice_TB_M_Employee_ProcurementEmployeeId",
                        column: x => x.ProcurementEmployeeId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_PinaltyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<string>(nullable: false),
                    Pinalty = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_PinaltyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_PinaltyHistory_TB_T_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "TB_T_Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_DepartmentId",
                table: "TB_M_Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_ManagerId",
                table: "TB_M_Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_PinaltyHistory_InvoiceId",
                table: "TB_M_PinaltyHistory",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_RequestDetail_EmployeeId",
                table: "TB_M_RequestDetail",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Invoice_ProcurementEmployeeId",
                table: "TB_T_Invoice",
                column: "ProcurementEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_ItemRequest_RequestId",
                table: "TB_T_ItemRequest",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Asset");

            migrationBuilder.DropTable(
                name: "TB_M_Category");

            migrationBuilder.DropTable(
                name: "TB_M_Pinalty");

            migrationBuilder.DropTable(
                name: "TB_M_PinaltyHistory");

            migrationBuilder.DropTable(
                name: "TB_M_RequestDetail");

            migrationBuilder.DropTable(
                name: "TB_T_ItemRequest");

            migrationBuilder.DropTable(
                name: "TB_T_Invoice");

            migrationBuilder.DropTable(
                name: "TB_M_Request");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Department");
        }
    }
}
