using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialSMSData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cost = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    Credits = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    GLH = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ExamBoard = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ParentalEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MobileTelephoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IsEmergencyContact = table.Column<bool>(type: "bit", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressPostcode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MobileTelephoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    HomeTelephoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsLookedAfterChild = table.Column<bool>(type: "bit", nullable: false),
                    IsCareLeaver = table.Column<bool>(type: "bit", nullable: false),
                    HasAdditionalNeeds = table.Column<bool>(type: "bit", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressPostcode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NiNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Credits = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    GLH = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Module_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intervention",
                columns: table => new
                {
                    InterventionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervention", x => x.InterventionId);
                    table.ForeignKey(
                        name: "FK_Intervention_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_StudentId",
                table: "Intervention",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CourseId",
                table: "Module",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervention");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
