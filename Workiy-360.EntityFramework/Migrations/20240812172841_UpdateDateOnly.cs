using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workiy_360.EntityFramework.Migrations
{
    public partial class UpdateDateOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact_type",
                columns: table => new
                {
                    TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TYPE_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TYPE_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_information",
                columns: table => new
                {
                    PK_EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: true),
                    PREFIX = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FIRST_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FATHER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATE_OF_BIRTH = table.Column<DateOnly>(type: "date", nullable: true),
                    AGE = table.Column<int>(type: "int", nullable: true),
                    GENDER = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BLOOD_GROUP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MARITAL_STATUS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MOBILE_NO = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PERSONAL_MAIL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PK_EMPLOYEE_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_additional_info",
                columns: table => new
                {
                    ADD_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    ADD_GROUP_TYPE = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADD_GROUP_NAME = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADD_GROUP_LINK = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ADD_INFO_ID);
                    table.ForeignKey(
                        name: "employee_additional_info_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_administrative_information",
                columns: table => new
                {
                    ADMIN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    SALARY_ID = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BENEFIT = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ADMIN_ID);
                    table.ForeignKey(
                        name: "employee_administrative_information_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_contact_details",
                columns: table => new
                {
                    CONTACT_PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    EMERGENCY_CON_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RELATION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CON_NUM = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CONTACT_PK_ID);
                    table.ForeignKey(
                        name: "employee_contact_details_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                    table.ForeignKey(
                        name: "employee_contact_details_ibfk_2",
                        column: x => x.TYPE_ID,
                        principalTable: "contact_type",
                        principalColumn: "TYPE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_educational_details",
                columns: table => new
                {
                    EDUCATIONAL_PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    DEGREE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NAME_OF_THE_DEGREE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MAJOR = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INSTITUTE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YEAR_OF_COMPLETION = table.Column<DateOnly>(type: "date", nullable: true),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.EDUCATIONAL_PK_ID);
                    table.ForeignKey(
                        name: "employee_educational_details_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_experience_details",
                columns: table => new
                {
                    EXP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    COMPANY_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESIGNATION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    START_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    END_DATE = table.Column<DateOnly>(type: "date", nullable: true),
                    DURATION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KEY_ROLE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OTHER_INFO = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.EXP_ID);
                    table.ForeignKey(
                        name: "employee_experience_details_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_hr_info",
                columns: table => new
                {
                    HR_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    HR_GP_NAME = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HR_GP_LINK = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.HR_INFO_ID);
                    table.ForeignKey(
                        name: "employee_hr_info_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_job_information",
                columns: table => new
                {
                    JOB_PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    JOB_TITLE_DESIGNATION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DEPARTMENT = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATE_OF_JOINING = table.Column<DateOnly>(type: "date", nullable: true),
                    STATUS = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    REPORTING_MANAGER = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WORK_LOCATION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_MAIL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.JOB_PK_ID);
                    table.ForeignKey(
                        name: "employee_job_information_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_nationality_document",
                columns: table => new
                {
                    NAT_PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    NATIONALITY_GP_NAME = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NATIONALITY_GP_NUMBER = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NATIONALITY_GP_LINK = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.NAT_PK_ID);
                    table.ForeignKey(
                        name: "employee_nationality_document_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_support_document",
                columns: table => new
                {
                    SUP_DOC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    EDU_GRP_NAME = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EDU_GRP_LINK = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SUP_DOC_ID);
                    table.ForeignKey(
                        name: "employee_support_document_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employment_status_updates",
                columns: table => new
                {
                    STAT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LAST_WDAY = table.Column<DateOnly>(type: "date", nullable: true),
                    RL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATUS_IND = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.STAT_ID);
                    table.ForeignKey(
                        name: "employment_status_updates_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "user_info",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    ROLE = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.User_ID);
                    table.ForeignKey(
                        name: "user_info_ibfk_1",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "employee_address_details",
                columns: table => new
                {
                    ADDRESS_PK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CONTACT_FK_ID = table.Column<int>(type: "int", nullable: true),
                    FK_ID = table.Column<int>(type: "int", nullable: true),
                    ADDRESS_TYPE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS_1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS_2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PINCODE = table.Column<int>(type: "int", nullable: true),
                    AREA = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CITY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STATE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COUNTRY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ADDRESS_PK_ID);
                    table.ForeignKey(
                        name: "employee_address_details_ibfk_1",
                        column: x => x.CONTACT_FK_ID,
                        principalTable: "employee_contact_details",
                        principalColumn: "CONTACT_PK_ID");
                    table.ForeignKey(
                        name: "employee_address_details_ibfk_2",
                        column: x => x.FK_ID,
                        principalTable: "employee_information",
                        principalColumn: "PK_EMPLOYEE_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "FK_ID",
                table: "employee_additional_info",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "CONTACT_FK_ID",
                table: "employee_address_details",
                column: "CONTACT_FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID1",
                table: "employee_address_details",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID2",
                table: "employee_administrative_information",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID3",
                table: "employee_contact_details",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "TYPE_ID",
                table: "employee_contact_details",
                column: "TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID4",
                table: "employee_educational_details",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID5",
                table: "employee_experience_details",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID6",
                table: "employee_hr_info",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID7",
                table: "employee_job_information",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID8",
                table: "employee_nationality_document",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID9",
                table: "employee_support_document",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID10",
                table: "employment_status_updates",
                column: "FK_ID");

            migrationBuilder.CreateIndex(
                name: "FK_ID11",
                table: "user_info",
                column: "FK_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_additional_info");

            migrationBuilder.DropTable(
                name: "employee_address_details");

            migrationBuilder.DropTable(
                name: "employee_administrative_information");

            migrationBuilder.DropTable(
                name: "employee_educational_details");

            migrationBuilder.DropTable(
                name: "employee_experience_details");

            migrationBuilder.DropTable(
                name: "employee_hr_info");

            migrationBuilder.DropTable(
                name: "employee_job_information");

            migrationBuilder.DropTable(
                name: "employee_nationality_document");

            migrationBuilder.DropTable(
                name: "employee_support_document");

            migrationBuilder.DropTable(
                name: "employment_status_updates");

            migrationBuilder.DropTable(
                name: "user_info");

            migrationBuilder.DropTable(
                name: "employee_contact_details");

            migrationBuilder.DropTable(
                name: "employee_information");

            migrationBuilder.DropTable(
                name: "contact_type");
        }
    }
}
