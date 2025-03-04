using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LgymApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_body_part_measurement_user_user_id",
                table: "body_part_measurement");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_user_user_id",
                table: "exercise");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_score_exercise_exercise_id",
                table: "exercise_score");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_score_training_result_training_id",
                table: "exercise_score");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_score_user_user_id",
                table: "exercise_score");

            migrationBuilder.DropForeignKey(
                name: "fk_main_record_exercise_exercise_id",
                table: "main_record");

            migrationBuilder.DropForeignKey(
                name: "fk_main_record_user_user_id",
                table: "main_record");

            migrationBuilder.DropForeignKey(
                name: "fk_plan_user_user_id",
                table: "plan");

            migrationBuilder.DropForeignKey(
                name: "fk_recommended_number_of_reps_exercise_exercise_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropForeignKey(
                name: "fk_recommended_number_of_reps_training_plan_training_plan_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropForeignKey(
                name: "fk_training_plan_plan_plan_id",
                table: "training_plan");

            migrationBuilder.DropForeignKey(
                name: "fk_training_result_training_plan_training_plan_id",
                table: "training_result");

            migrationBuilder.DropForeignKey(
                name: "fk_training_result_user_user_id",
                table: "training_result");

            migrationBuilder.DropIndex(
                name: "ix_recommended_number_of_reps_exercise_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_training_result",
                table: "training_result");

            migrationBuilder.DropPrimaryKey(
                name: "pk_training_plan",
                table: "training_plan");

            migrationBuilder.DropPrimaryKey(
                name: "pk_plan",
                table: "plan");

            migrationBuilder.DropPrimaryKey(
                name: "pk_main_record",
                table: "main_record");

            migrationBuilder.DropIndex(
                name: "ix_main_record_exercise_id",
                table: "main_record");

            migrationBuilder.DropPrimaryKey(
                name: "pk_exercise_score",
                table: "exercise_score");

            migrationBuilder.DropPrimaryKey(
                name: "pk_exercise",
                table: "exercise");

            migrationBuilder.DropPrimaryKey(
                name: "pk_body_part_measurement",
                table: "body_part_measurement");

            migrationBuilder.RenameTable(
                name: "training_result",
                newName: "training_results");

            migrationBuilder.RenameTable(
                name: "training_plan",
                newName: "training_plans");

            migrationBuilder.RenameTable(
                name: "plan",
                newName: "plans");

            migrationBuilder.RenameTable(
                name: "main_record",
                newName: "main_records");

            migrationBuilder.RenameTable(
                name: "exercise_score",
                newName: "exercise_scores");

            migrationBuilder.RenameTable(
                name: "exercise",
                newName: "exercises");

            migrationBuilder.RenameTable(
                name: "body_part_measurement",
                newName: "body_part_measurements");

            migrationBuilder.RenameIndex(
                name: "ix_training_result_user_id",
                table: "training_results",
                newName: "ix_training_results_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_training_result_training_plan_id",
                table: "training_results",
                newName: "ix_training_results_training_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_training_plan_plan_id",
                table: "training_plans",
                newName: "ix_training_plans_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_plan_user_id",
                table: "plans",
                newName: "ix_plans_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_main_record_user_id",
                table: "main_records",
                newName: "ix_main_records_user_id");

            migrationBuilder.RenameColumn(
                name: "training_id",
                table: "exercise_scores",
                newName: "training_result_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_score_user_id",
                table: "exercise_scores",
                newName: "ix_exercise_scores_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_score_training_id",
                table: "exercise_scores",
                newName: "ix_exercise_scores_training_result_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_score_exercise_id",
                table: "exercise_scores",
                newName: "ix_exercise_scores_exercise_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_user_id",
                table: "exercises",
                newName: "ix_exercises_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_body_part_measurement_user_id",
                table: "body_part_measurements",
                newName: "ix_body_part_measurements_user_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "training_plan_id",
                table: "recommended_number_of_reps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "recommended_number_of_reps",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "training_results",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "training_plans",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "plans",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "main_records",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "exercise_scores",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "exercises",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "exercises",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "body_part_measurements",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "pk_training_results",
                table: "training_results",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_training_plans",
                table: "training_plans",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_plans",
                table: "plans",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_main_records",
                table: "main_records",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_exercise_scores",
                table: "exercise_scores",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_exercises",
                table: "exercises",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_body_part_measurements",
                table: "body_part_measurements",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_recommended_number_of_reps_exercise_id",
                table: "recommended_number_of_reps",
                column: "exercise_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_main_records_exercise_id",
                table: "main_records",
                column: "exercise_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_body_part_measurements_user_user_id",
                table: "body_part_measurements",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_scores_exercises_exercise_id",
                table: "exercise_scores",
                column: "exercise_id",
                principalTable: "exercises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_scores_training_result_training_result_id",
                table: "exercise_scores",
                column: "training_result_id",
                principalTable: "training_results",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_scores_user_user_id",
                table: "exercise_scores",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_user_user_id",
                table: "exercises",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_main_records_exercises_exercise_id",
                table: "main_records",
                column: "exercise_id",
                principalTable: "exercises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_main_records_user_user_id",
                table: "main_records",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_plans_user_user_id",
                table: "plans",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recommended_number_of_reps_exercises_exercise_id",
                table: "recommended_number_of_reps",
                column: "exercise_id",
                principalTable: "exercises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recommended_number_of_reps_training_plans_training_plan_id",
                table: "recommended_number_of_reps",
                column: "training_plan_id",
                principalTable: "training_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_training_plans_plans_plan_id",
                table: "training_plans",
                column: "plan_id",
                principalTable: "plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_training_results_training_plans_training_plan_id",
                table: "training_results",
                column: "training_plan_id",
                principalTable: "training_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_training_results_user_user_id",
                table: "training_results",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_body_part_measurements_user_user_id",
                table: "body_part_measurements");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_scores_exercises_exercise_id",
                table: "exercise_scores");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_scores_training_result_training_result_id",
                table: "exercise_scores");

            migrationBuilder.DropForeignKey(
                name: "fk_exercise_scores_user_user_id",
                table: "exercise_scores");

            migrationBuilder.DropForeignKey(
                name: "fk_exercises_user_user_id",
                table: "exercises");

            migrationBuilder.DropForeignKey(
                name: "fk_main_records_exercises_exercise_id",
                table: "main_records");

            migrationBuilder.DropForeignKey(
                name: "fk_main_records_user_user_id",
                table: "main_records");

            migrationBuilder.DropForeignKey(
                name: "fk_plans_user_user_id",
                table: "plans");

            migrationBuilder.DropForeignKey(
                name: "fk_recommended_number_of_reps_exercises_exercise_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropForeignKey(
                name: "fk_recommended_number_of_reps_training_plans_training_plan_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropForeignKey(
                name: "fk_training_plans_plans_plan_id",
                table: "training_plans");

            migrationBuilder.DropForeignKey(
                name: "fk_training_results_training_plans_training_plan_id",
                table: "training_results");

            migrationBuilder.DropForeignKey(
                name: "fk_training_results_user_user_id",
                table: "training_results");

            migrationBuilder.DropIndex(
                name: "ix_recommended_number_of_reps_exercise_id",
                table: "recommended_number_of_reps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_training_results",
                table: "training_results");

            migrationBuilder.DropPrimaryKey(
                name: "pk_training_plans",
                table: "training_plans");

            migrationBuilder.DropPrimaryKey(
                name: "pk_plans",
                table: "plans");

            migrationBuilder.DropPrimaryKey(
                name: "pk_main_records",
                table: "main_records");

            migrationBuilder.DropIndex(
                name: "ix_main_records_exercise_id",
                table: "main_records");

            migrationBuilder.DropPrimaryKey(
                name: "pk_exercises",
                table: "exercises");

            migrationBuilder.DropPrimaryKey(
                name: "pk_exercise_scores",
                table: "exercise_scores");

            migrationBuilder.DropPrimaryKey(
                name: "pk_body_part_measurements",
                table: "body_part_measurements");

            migrationBuilder.RenameTable(
                name: "training_results",
                newName: "training_result");

            migrationBuilder.RenameTable(
                name: "training_plans",
                newName: "training_plan");

            migrationBuilder.RenameTable(
                name: "plans",
                newName: "plan");

            migrationBuilder.RenameTable(
                name: "main_records",
                newName: "main_record");

            migrationBuilder.RenameTable(
                name: "exercises",
                newName: "exercise");

            migrationBuilder.RenameTable(
                name: "exercise_scores",
                newName: "exercise_score");

            migrationBuilder.RenameTable(
                name: "body_part_measurements",
                newName: "body_part_measurement");

            migrationBuilder.RenameIndex(
                name: "ix_training_results_user_id",
                table: "training_result",
                newName: "ix_training_result_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_training_results_training_plan_id",
                table: "training_result",
                newName: "ix_training_result_training_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_training_plans_plan_id",
                table: "training_plan",
                newName: "ix_training_plan_plan_id");

            migrationBuilder.RenameIndex(
                name: "ix_plans_user_id",
                table: "plan",
                newName: "ix_plan_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_main_records_user_id",
                table: "main_record",
                newName: "ix_main_record_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercises_user_id",
                table: "exercise",
                newName: "ix_exercise_user_id");

            migrationBuilder.RenameColumn(
                name: "training_result_id",
                table: "exercise_score",
                newName: "training_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_scores_user_id",
                table: "exercise_score",
                newName: "ix_exercise_score_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_scores_training_result_id",
                table: "exercise_score",
                newName: "ix_exercise_score_training_id");

            migrationBuilder.RenameIndex(
                name: "ix_exercise_scores_exercise_id",
                table: "exercise_score",
                newName: "ix_exercise_score_exercise_id");

            migrationBuilder.RenameIndex(
                name: "ix_body_part_measurements_user_id",
                table: "body_part_measurement",
                newName: "ix_body_part_measurement_user_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "training_plan_id",
                table: "recommended_number_of_reps",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "recommended_number_of_reps",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "training_result",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "training_plan",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "plan",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "main_record",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "exercise",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "exercise",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "exercise_score",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "body_part_measurement",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "pk_training_result",
                table: "training_result",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_training_plan",
                table: "training_plan",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_plan",
                table: "plan",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_main_record",
                table: "main_record",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_exercise",
                table: "exercise",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_exercise_score",
                table: "exercise_score",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_body_part_measurement",
                table: "body_part_measurement",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_recommended_number_of_reps_exercise_id",
                table: "recommended_number_of_reps",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_main_record_exercise_id",
                table: "main_record",
                column: "exercise_id");

            migrationBuilder.AddForeignKey(
                name: "fk_body_part_measurement_user_user_id",
                table: "body_part_measurement",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_user_user_id",
                table: "exercise",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_score_exercise_exercise_id",
                table: "exercise_score",
                column: "exercise_id",
                principalTable: "exercise",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_score_training_result_training_id",
                table: "exercise_score",
                column: "training_id",
                principalTable: "training_result",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_exercise_score_user_user_id",
                table: "exercise_score",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_main_record_exercise_exercise_id",
                table: "main_record",
                column: "exercise_id",
                principalTable: "exercise",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_main_record_user_user_id",
                table: "main_record",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_plan_user_user_id",
                table: "plan",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recommended_number_of_reps_exercise_exercise_id",
                table: "recommended_number_of_reps",
                column: "exercise_id",
                principalTable: "exercise",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_recommended_number_of_reps_training_plan_training_plan_id",
                table: "recommended_number_of_reps",
                column: "training_plan_id",
                principalTable: "training_plan",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_training_plan_plan_plan_id",
                table: "training_plan",
                column: "plan_id",
                principalTable: "plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_training_result_training_plan_training_plan_id",
                table: "training_result",
                column: "training_plan_id",
                principalTable: "training_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_training_result_user_user_id",
                table: "training_result",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
