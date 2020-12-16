using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class RefactorSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "d267752e-f8a3-45df-bc5b-e1e19f7353c6", "08810053-4d93-4df7-a081-c39c7f86939d" });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "72e9bb76-696d-4927-a21e-d7cdd8000e81", "4357cb03-978c-4cd8-8d26-5948cfe611ff" });

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "1efca3ea-1bcd-4b63-8876-436781430e1e");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "33fc0313-ee5e-42c1-aadd-c8586e58743c");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "42ffbe41-0640-4d0e-a32b-07d845a613cc");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "52d81df7-2732-4968-89f4-9c6a084a5519");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "5ec5a569-8f31-4c37-a3cd-a2157473cb3d");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "c248917a-012b-4044-b84d-dac703b0c290");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "e5d97972-0472-41cf-9fd7-18ff7ef63a55");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "1e4bfb42-3a65-4ab3-8064-dacf327eac8b");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "b0ec8851-4ceb-499f-ac44-4d4338748e68");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "ed2f4ce7-2cfa-4a92-9fd7-376c6f13de24");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "f33fda2e-a9fb-4f34-b97e-291dcab49059");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "150db9f3-7459-4053-a567-ef3ad504a2a6");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "629b5c0d-ceca-4334-b431-3bcb9fc9591c");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "e73e1be7-8370-4a6b-b8af-2f897847430a");

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "72e9bb76-696d-4927-a21e-d7cdd8000e81");

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "d267752e-f8a3-45df-bc5b-e1e19f7353c6");

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: "08810053-4d93-4df7-a081-c39c7f86939d");

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "33386e00-34b0-4fcd-8c08-37bda6065b27");

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f");

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: "4357cb03-978c-4cd8-8d26-5948cfe611ff");

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "3d0664a0-ffee-47f7-9a7b-b8f8813aaa97", "bfa449b2-10f2-4962-99b2-c7a26c570d31", "admin", "ADMIN" },
                    { "da56c4d0-2533-4bd5-8d3e-7146ea3f0a28", "25e5344f-4cae-419b-a84e-b4954c969944", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "a83f2088-3678-43be-b7a7-d94bf99e783e", 0, "4d17553e-4e5f-4448-b1ed-97647d61a2d1", null, false, false, null, null, "USER", "AQAAAAEAACcQAAAAENJg/vQW+ytvDEt6dyKXiPDPolsMpbA9Toy+WVSPVJjR3wMM6sarGqsyvwGtbW62Ng==", null, false, "3d78e872-e53b-4bb9-8d91-df7cd3ab362c", false, "user" },
                    { "b85a693e-5aca-4414-9e26-7a7e644586a1", 0, "75b6f325-3113-4632-bf48-0c49a76a1b95", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIDRO4mxxM4Qt1kA4c+rZDUuCHo6B38OMzASDMcAAwifVBkHyTJHKcm6O9znngz8+w==", null, false, "97b1fe8d-c806-4efd-98bc-008e53d68fd0", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { "dd14f582-9985-4d55-8206-60c9fa793b3c", "usd" },
                    { "0431b13e-bd9c-4b60-a5ee-33d341dc296f", "eur" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "name", "user_id" },
                values: new object[,]
                {
                    { "cc19109b-bddc-418f-a6c8-862d5d6148c4", "main", "a83f2088-3678-43be-b7a7-d94bf99e783e" },
                    { "063e5fe5-ae5c-4f70-9a8e-2c05f3ae35a0", "second", "a83f2088-3678-43be-b7a7-d94bf99e783e" },
                    { "5cfb6c19-4e97-47d5-8f3e-0eb581e4abf2", "admin", "b85a693e-5aca-4414-9e26-7a7e644586a1" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "da56c4d0-2533-4bd5-8d3e-7146ea3f0a28", "a83f2088-3678-43be-b7a7-d94bf99e783e" },
                    { "3d0664a0-ffee-47f7-9a7b-b8f8813aaa97", "b85a693e-5aca-4414-9e26-7a7e644586a1" }
                });

            migrationBuilder.InsertData(
                table: "commissions",
                columns: new[] { "id", "currency_id", "max_commission", "max_value", "min_commission", "operation_type", "rate", "type", "user_id", "value" },
                values: new object[,]
                {
                    { "8a163ba1-4897-4080-87b4-ec46645faf7a", "dd14f582-9985-4d55-8206-60c9fa793b3c", 0.0, 100.0, 0.0, 0, 0.0, 0, null, 1.0 },
                    { "b86d8ba8-8805-4b29-a585-1083892e0d02", "dd14f582-9985-4d55-8206-60c9fa793b3c", 0.0, 100.0, 0.0, 2, 0.0, 0, null, 1.0 },
                    { "f4d1cdae-2055-4cdb-b702-9b6bf3a5df5a", "dd14f582-9985-4d55-8206-60c9fa793b3c", 0.0, 100.0, 0.0, 1, 0.0, 0, null, 1.0 },
                    { "d9412aa4-21c9-47c0-a821-b77a24c3521e", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 10.0, 50.0, 0.5, 0, 0.10000000000000001, 1, null, 0.0 },
                    { "4190c1c3-40cc-4794-876e-2ddb90788afd", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 10.0, 50.0, 0.5, 2, 0.10000000000000001, 1, null, 0.0 },
                    { "26f91435-fd47-43de-98bf-13945cd0a655", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 10.0, 50.0, 0.5, 1, 0.10000000000000001, 1, null, 0.0 },
                    { "fbbf5787-ebd7-4980-8b86-32eacdee4c96", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 0.0, 100.0, 0.0, 0, 0.0, 0, "b85a693e-5aca-4414-9e26-7a7e644586a1", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "account_id", "currency_id", "value" },
                values: new object[,]
                {
                    { "fd9dfcf6-e555-4004-83e5-821f904d9c56", "cc19109b-bddc-418f-a6c8-862d5d6148c4", "dd14f582-9985-4d55-8206-60c9fa793b3c", 1000.0 },
                    { "3bfb64ad-c4b4-4aec-83d2-df24bd318638", "063e5fe5-ae5c-4f70-9a8e-2c05f3ae35a0", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 2000.0 },
                    { "6f3838bd-da31-477a-b84a-a6821621feb6", "5cfb6c19-4e97-47d5-8f3e-0eb581e4abf2", "dd14f582-9985-4d55-8206-60c9fa793b3c", 666.0 },
                    { "e639ec3d-9c11-4ced-9a20-287b7aaa49fd", "5cfb6c19-4e97-47d5-8f3e-0eb581e4abf2", "0431b13e-bd9c-4b60-a5ee-33d341dc296f", 1408.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "da56c4d0-2533-4bd5-8d3e-7146ea3f0a28", "a83f2088-3678-43be-b7a7-d94bf99e783e" });

            migrationBuilder.DeleteData(
                table: "asp_net_user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "3d0664a0-ffee-47f7-9a7b-b8f8813aaa97", "b85a693e-5aca-4414-9e26-7a7e644586a1" });

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "26f91435-fd47-43de-98bf-13945cd0a655");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "4190c1c3-40cc-4794-876e-2ddb90788afd");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "8a163ba1-4897-4080-87b4-ec46645faf7a");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "b86d8ba8-8805-4b29-a585-1083892e0d02");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "d9412aa4-21c9-47c0-a821-b77a24c3521e");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "f4d1cdae-2055-4cdb-b702-9b6bf3a5df5a");

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "id",
                keyValue: "fbbf5787-ebd7-4980-8b86-32eacdee4c96");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "3bfb64ad-c4b4-4aec-83d2-df24bd318638");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "6f3838bd-da31-477a-b84a-a6821621feb6");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "e639ec3d-9c11-4ced-9a20-287b7aaa49fd");

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "id",
                keyValue: "fd9dfcf6-e555-4004-83e5-821f904d9c56");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "063e5fe5-ae5c-4f70-9a8e-2c05f3ae35a0");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "5cfb6c19-4e97-47d5-8f3e-0eb581e4abf2");

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: "cc19109b-bddc-418f-a6c8-862d5d6148c4");

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "3d0664a0-ffee-47f7-9a7b-b8f8813aaa97");

            migrationBuilder.DeleteData(
                table: "asp_net_roles",
                keyColumn: "id",
                keyValue: "da56c4d0-2533-4bd5-8d3e-7146ea3f0a28");

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "0431b13e-bd9c-4b60-a5ee-33d341dc296f");

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "id",
                keyValue: "dd14f582-9985-4d55-8206-60c9fa793b3c");

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: "a83f2088-3678-43be-b7a7-d94bf99e783e");

            migrationBuilder.DeleteData(
                table: "asp_net_users",
                keyColumn: "id",
                keyValue: "b85a693e-5aca-4414-9e26-7a7e644586a1");

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "d267752e-f8a3-45df-bc5b-e1e19f7353c6", "e2b5cb1d-b820-4ead-bfec-c305ecac856c", "admin", "ADMIN" },
                    { "72e9bb76-696d-4927-a21e-d7cdd8000e81", "05483fa4-4877-40a6-bcc5-81155e5ecfc9", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "4357cb03-978c-4cd8-8d26-5948cfe611ff", 0, "79a6c335-7510-4a8a-8451-cd6f1a475d16", null, false, false, null, null, "USER", "AQAAAAEAACcQAAAAEEZVT2Db8Dg99rFEB540CRx7NTLW6PqiNpsXAqappW9BLykECq7f96EpwSf8jeAeeA==", null, false, "d6ea945b-3751-4b35-a3f5-56bd08edc86a", false, "user" },
                    { "08810053-4d93-4df7-a081-c39c7f86939d", 0, "40613831-a846-4b80-ae9f-514fa11b5aac", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEE5C3WhSQygx5SruZhrsRfkb3YU9IHk/4EkFmgm0HsT4R0RTHrUchdAhw27ZAAMyow==", null, false, "1076bdc0-b23e-46cb-815a-f167a9bf0592", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", "usd" },
                    { "33386e00-34b0-4fcd-8c08-37bda6065b27", "eur" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "name", "user_id" },
                values: new object[,]
                {
                    { "150db9f3-7459-4053-a567-ef3ad504a2a6", "main", "4357cb03-978c-4cd8-8d26-5948cfe611ff" },
                    { "629b5c0d-ceca-4334-b431-3bcb9fc9591c", "second", "4357cb03-978c-4cd8-8d26-5948cfe611ff" },
                    { "e73e1be7-8370-4a6b-b8af-2f897847430a", "admin", "4357cb03-978c-4cd8-8d26-5948cfe611ff" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "72e9bb76-696d-4927-a21e-d7cdd8000e81", "4357cb03-978c-4cd8-8d26-5948cfe611ff" },
                    { "d267752e-f8a3-45df-bc5b-e1e19f7353c6", "08810053-4d93-4df7-a081-c39c7f86939d" }
                });

            migrationBuilder.InsertData(
                table: "commissions",
                columns: new[] { "id", "currency_id", "max_commission", "max_value", "min_commission", "operation_type", "rate", "type", "user_id", "value" },
                values: new object[,]
                {
                    { "52d81df7-2732-4968-89f4-9c6a084a5519", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 0.0, 100.0, 0.0, 0, 0.0, 0, null, 1.0 },
                    { "33fc0313-ee5e-42c1-aadd-c8586e58743c", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 0.0, 100.0, 0.0, 2, 0.0, 0, null, 1.0 },
                    { "1efca3ea-1bcd-4b63-8876-436781430e1e", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 0.0, 100.0, 0.0, 1, 0.0, 0, null, 1.0 },
                    { "c248917a-012b-4044-b84d-dac703b0c290", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 0.0, 100.0, 0.0, 0, 0.0, 0, null, 1.0 },
                    { "5ec5a569-8f31-4c37-a3cd-a2157473cb3d", "33386e00-34b0-4fcd-8c08-37bda6065b27", 10.0, 50.0, 0.5, 0, 0.10000000000000001, 1, null, 0.0 },
                    { "e5d97972-0472-41cf-9fd7-18ff7ef63a55", "33386e00-34b0-4fcd-8c08-37bda6065b27", 10.0, 50.0, 0.5, 2, 0.10000000000000001, 1, null, 0.0 },
                    { "42ffbe41-0640-4d0e-a32b-07d845a613cc", "33386e00-34b0-4fcd-8c08-37bda6065b27", 10.0, 50.0, 0.5, 1, 0.10000000000000001, 1, null, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "account_id", "currency_id", "value" },
                values: new object[,]
                {
                    { "1e4bfb42-3a65-4ab3-8064-dacf327eac8b", "150db9f3-7459-4053-a567-ef3ad504a2a6", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 1000.0 },
                    { "b0ec8851-4ceb-499f-ac44-4d4338748e68", "629b5c0d-ceca-4334-b431-3bcb9fc9591c", "33386e00-34b0-4fcd-8c08-37bda6065b27", 2000.0 },
                    { "f33fda2e-a9fb-4f34-b97e-291dcab49059", "e73e1be7-8370-4a6b-b8af-2f897847430a", "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f", 666.0 },
                    { "ed2f4ce7-2cfa-4a92-9fd7-376c6f13de24", "e73e1be7-8370-4a6b-b8af-2f897847430a", "33386e00-34b0-4fcd-8c08-37bda6065b27", 1408.0 }
                });
        }
    }
}
