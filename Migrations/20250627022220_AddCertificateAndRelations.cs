using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertificateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCertificateAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_UserId",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Certificates",
                newName: "SignatureUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Certificates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "CertificateName",
                table: "Certificates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Certificates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuingOrganization",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                table: "Certificates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Certificates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCertificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScoreOrHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCertificates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TrainingId",
                table: "Certificates",
                column: "TrainingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_CertificateId",
                table: "UserCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_UserId",
                table: "UserCertificates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Trainings_TrainingId",
                table: "Certificates",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_UserId",
                table: "Certificates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Trainings_TrainingId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Users_UserId",
                table: "Certificates");

            migrationBuilder.DropTable(
                name: "UserCertificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_TrainingId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CertificateName",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "IssuingOrganization",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "SignatureUrl",
                table: "Certificates",
                newName: "FileUrl");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Certificates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Users_UserId",
                table: "Certificates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
