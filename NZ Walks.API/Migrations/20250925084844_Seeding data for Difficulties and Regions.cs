using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZ_Walks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1bfe5a7a-dc63-4862-95c2-29840d347d29"), "Easy" },
                    { new Guid("800a1ada-b582-4616-ba9d-473c9dd1b3bc"), "Medium" },
                    { new Guid("88b0109f-6c7e-4a4a-ad29-d7df9109073a"), "Heigh" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("091e60bd-844f-47e6-a675-2ba12248a4d4"), "NZ-MB", "Marlborough", "https://picsum.photos/id/20/2500/1667" },
                    { new Guid("10064c86-6d6f-466a-854b-0ed8ae8bf928"), "NZ-C", "Canterbury", "https://picsum.photos/id/22/2500/1667" },
                    { new Guid("3390fc2c-2bc1-40ce-9ec8-755338ee1d4c"), "NZ-NS", "Nelson", "https://picsum.photos/id/19/2500/1667" },
                    { new Guid("3497b1cc-d0d7-4f09-a57e-a55cf30166b9"), "NZ-T", "Taranaki", "https://picsum.photos/id/16/2500/1667" },
                    { new Guid("4b2b2bf3-ed64-471b-940e-e70df2693cca"), "NZ-N", "Northland", "https://picsum.photos/id/10/2500/1667" },
                    { new Guid("5494c18a-1fbf-40e2-82d6-87c7af6d0460"), "NZ-W", "Waikato", "https://picsum.photos/id/12/2500/1667" },
                    { new Guid("62e4c92c-4482-4b3e-ab4b-a2394b69509f"), "NZ-M", "Manawatu-Wanganui", "https://picsum.photos/id/17/2500/1667" },
                    { new Guid("6f6a4160-46dd-41f9-919c-1be39412b321"), "NZ-WC", "West Coast", "https://picsum.photos/id/21/2500/1667" },
                    { new Guid("86b70ec5-540e-4479-826f-4eac1ef41a62"), "NZ-A", "Auckland", "https://picsum.photos/id/11/2500/1667" },
                    { new Guid("a552f961-2409-4ef5-8851-d9abcd26e289"), "NZ-S", "Southland", "https://picsum.photos/id/24/2500/1667" },
                    { new Guid("c0b7f81a-d615-470d-998e-dbc4541a9faa"), "NZ-G", "Gisborne", "https://picsum.photos/id/14/2500/1667" },
                    { new Guid("cb6b437f-e406-4fc1-b841-1c3769af8ebc"), "NZ-WG", "Wellington", "https://picsum.photos/id/18/2500/1667" },
                    { new Guid("d8c8f4cf-6964-4d4b-a6a7-1c1cbecb3e79"), "NZ-O", "Otago", "https://picsum.photos/id/23/2500/1667" },
                    { new Guid("f28646ca-9331-40cf-a525-fe2abe7c6829"), "NZ-H", "Hawke's Bay", "https://picsum.photos/id/15/2500/1667" },
                    { new Guid("f4c674b6-be9f-4d3c-a2c0-b10465d5a470"), "NZ-B", "Bay of Plenty", "https://picsum.photos/id/13/2500/1667" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1bfe5a7a-dc63-4862-95c2-29840d347d29"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("800a1ada-b582-4616-ba9d-473c9dd1b3bc"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("88b0109f-6c7e-4a4a-ad29-d7df9109073a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("091e60bd-844f-47e6-a675-2ba12248a4d4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("10064c86-6d6f-466a-854b-0ed8ae8bf928"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3390fc2c-2bc1-40ce-9ec8-755338ee1d4c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3497b1cc-d0d7-4f09-a57e-a55cf30166b9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b2b2bf3-ed64-471b-940e-e70df2693cca"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5494c18a-1fbf-40e2-82d6-87c7af6d0460"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("62e4c92c-4482-4b3e-ab4b-a2394b69509f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6f6a4160-46dd-41f9-919c-1be39412b321"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("86b70ec5-540e-4479-826f-4eac1ef41a62"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a552f961-2409-4ef5-8851-d9abcd26e289"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c0b7f81a-d615-470d-998e-dbc4541a9faa"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cb6b437f-e406-4fc1-b841-1c3769af8ebc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d8c8f4cf-6964-4d4b-a6a7-1c1cbecb3e79"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f28646ca-9331-40cf-a525-fe2abe7c6829"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f4c674b6-be9f-4d3c-a2c0-b10465d5a470"));
        }
    }
}
