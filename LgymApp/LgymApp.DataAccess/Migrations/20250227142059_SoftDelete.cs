using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LgymApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TrainingResult");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingResult");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingResult");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TrainingResult");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainingResult");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TrainingPlan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecommendedNumberOfReps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecommendedNumberOfReps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RecommendedNumberOfReps");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RecommendedNumberOfReps");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RecommendedNumberOfReps");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MainRecord");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MainRecord");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainRecord");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MainRecord");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MainRecord");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ExerciseScore");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExerciseScore");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseScore");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ExerciseScore");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExerciseScore");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BodyPartMeasurement");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BodyPartMeasurement");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BodyPartMeasurement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BodyPartMeasurement");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BodyPartMeasurement");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Exercise",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Exercise");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TrainingResult",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TrainingResult",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingResult",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TrainingResult",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "TrainingResult",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TrainingPlan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "TrainingPlan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingPlan",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TrainingPlan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "TrainingPlan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecommendedNumberOfReps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "RecommendedNumberOfReps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RecommendedNumberOfReps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RecommendedNumberOfReps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "RecommendedNumberOfReps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Plan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Plan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Plan",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Plan",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Plan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MainRecord",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "MainRecord",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainRecord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MainRecord",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "MainRecord",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ExerciseScore",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "ExerciseScore",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseScore",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExerciseScore",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "ExerciseScore",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Exercise",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Exercise",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exercise",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Exercise",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Exercise",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BodyPartMeasurement",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "BodyPartMeasurement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BodyPartMeasurement",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BodyPartMeasurement",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "BodyPartMeasurement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
