using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BangazonAPI.Migrations
{
    public partial class Dept2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId1",
                table: "Employee",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId1",
                table: "Employee",
                column: "DepartmentId1",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
