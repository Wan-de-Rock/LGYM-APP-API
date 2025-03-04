using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LgymApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nickname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    hashed_password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "body_part_measurement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    body_part = table.Column<int>(type: "integer", nullable: false),
                    weight_unit = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_body_part_measurement", x => x.id);
                    table.ForeignKey(
                        name: "fk_body_part_measurement_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    body_part = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "plan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    number_of_training_days = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plan", x => x.id);
                    table.ForeignKey(
                        name: "fk_plan_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "main_record",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    weight_unit = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_main_record", x => x.id);
                    table.ForeignKey(
                        name: "fk_main_record_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_main_record_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_plan",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    plan_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training_plan", x => x.id);
                    table.ForeignKey(
                        name: "fk_training_plan_plan_plan_id",
                        column: x => x.plan_id,
                        principalTable: "plan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recommended_number_of_reps",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    series = table.Column<int>(type: "integer", nullable: false),
                    repeats = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    training_plan_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recommended_number_of_reps", x => x.id);
                    table.ForeignKey(
                        name: "fk_recommended_number_of_reps_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recommended_number_of_reps_training_plan_training_plan_id",
                        column: x => x.training_plan_id,
                        principalTable: "training_plan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "training_result",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    training_plan_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training_result", x => x.id);
                    table.ForeignKey(
                        name: "fk_training_result_training_plan_training_plan_id",
                        column: x => x.training_plan_id,
                        principalTable: "training_plan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_training_result_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercise_score",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    training_id = table.Column<Guid>(type: "uuid", nullable: false),
                    repeats = table.Column<double>(type: "double precision", nullable: false),
                    series = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    weight_unit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_score", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_score_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exercise_score_training_result_training_id",
                        column: x => x.training_id,
                        principalTable: "training_result",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exercise_score_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_body_part_measurement_user_id",
                table: "body_part_measurement",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_user_id",
                table: "exercise",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_score_exercise_id",
                table: "exercise_score",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_score_training_id",
                table: "exercise_score",
                column: "training_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_score_user_id",
                table: "exercise_score",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_main_record_exercise_id",
                table: "main_record",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_main_record_user_id",
                table: "main_record",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_plan_user_id",
                table: "plan",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_recommended_number_of_reps_exercise_id",
                table: "recommended_number_of_reps",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_recommended_number_of_reps_training_plan_id",
                table: "recommended_number_of_reps",
                column: "training_plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_training_plan_plan_id",
                table: "training_plan",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_training_result_training_plan_id",
                table: "training_result",
                column: "training_plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_training_result_user_id",
                table: "training_result",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "body_part_measurement");

            migrationBuilder.DropTable(
                name: "exercise_score");

            migrationBuilder.DropTable(
                name: "main_record");

            migrationBuilder.DropTable(
                name: "recommended_number_of_reps");

            migrationBuilder.DropTable(
                name: "training_result");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "training_plan");

            migrationBuilder.DropTable(
                name: "plan");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
