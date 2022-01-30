CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Address" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Address" PRIMARY KEY ("Id")
);

CREATE TABLE "Cart" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Cart" PRIMARY KEY ("Id")
);

CREATE TABLE "Category" (
    "CategoryId" text NOT NULL,
    "Name" text NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "UpdatedDate" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Category" PRIMARY KEY ("CategoryId")
);

CREATE TABLE "Company" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Company" PRIMARY KEY ("Id")
);

CREATE TABLE "Country" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Country" PRIMARY KEY ("Id")
);

CREATE TABLE "Order" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Order" PRIMARY KEY ("Id")
);

CREATE TABLE "OrderDetail" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_OrderDetail" PRIMARY KEY ("Id")
);

CREATE TABLE "Person" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Person" PRIMARY KEY ("Id")
);

CREATE TABLE "SubCategory" (
    "Id" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_SubCategory" PRIMARY KEY ("Id")
);

CREATE TABLE "Product" (
    "ProductId" text NOT NULL,
    "Name" text NOT NULL,
    "Barcode" text NOT NULL,
    "Description" text NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "UpdatedDate" timestamp without time zone NOT NULL,
    "CategoryId" text NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("ProductId"),
    CONSTRAINT "FK_Product_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Category" ("CategoryId")
);

CREATE INDEX "IX_Product_CategoryId" ON "Product" ("CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220126133239_InitialModel', '6.0.1');

COMMIT;

